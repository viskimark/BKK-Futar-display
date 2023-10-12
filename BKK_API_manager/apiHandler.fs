﻿namespace BKK_API_manager

open FSharp.Data
open System.IO

type apiHandler(key:string, stops:JsonStructures.Stop[]) =
    //let mutable private stopId = "stopId=BKK_F01703&stopId=BKK_F01701&"
    //let megallokJson = Http.RequestString(@"https://raw.githubusercontent.com/viskimark/BKK-Futar-display/23f5fe94527f9ec695f9a165a2576538f6ba99ff/megallok.json", responseEncodingOverride="UTF-8")
    let stopIds (stop:JsonStructures.Stop) =
        let mutable str = ""
        for id in stop.ids do
            str <- str + "stopId=BKK_" + id + "&"
        str
        //stopId <- ""
        //for id in stopIds do
        //    stopId <- stopId + "stopId=" + id + "&"

    let stopDeparturesUrl (stop:JsonStructures.Stop) = "https://futar.bkk.hu/api/query/v1/ws/otp/api/where/arrivals-and-departures-for-stop?minutesBefore=1&minutesAfter=60&" + stopIds(stop) + "onlyDepartures=true&limit=60&version=4&includeReferences=compact&key=" + key

    let getJson (url:string) =
        async {
            let Http = new System.Net.Http.HttpClient()
            let! text = Http.GetStringAsync(url) |> Async.AwaitTask
            return JsonStructuresFS.StopDepartureStructure.Parse(text)
        }
    
    member this.stops = 
        stops
        |> Array.sortBy (fun (s:JsonStructures.Stop) -> s.longName)
    member this.stopNames =
        [|for stop in this.stops do stop.longName|]

    member this.exits =
        [|
            for stop in this.stops do
                for i in 0..stop.ids.Length - 1 do
                    let exit =
                        if stop.exits.Length > 0 then stop.exits[i] else "-"
                    yield (stop.ids[i], exit)
        |]

    member this.getStopLongName(index) =
        this.stops[index].longName
    member this.getStopShortName(index) =
        this.stops[index].shortName

    member this.getExit(stopId) =
        let arr = 
            [|
                for exit in this.exits do
                    if ("BKK_" + (fst exit)) = stopId then yield (snd exit)
            |]
        if arr.Length > 0 then arr[0] else "-"

    member this.getDeparturesFromJson (json:JsonStructuresFS.StopDepartureStructure.Root) = 
        let references = json.Data.References

        Array.map (fun (departure:JsonStructuresFS.StopDepartureStructure.StopTime) ->
            let departureTime =
                match departure.PredictedDepartureTime with
                |None -> departure.DepartureTime
                |Some time -> time

            new Departure(departure.TripId, new Route(departure.StopHeadsign, departure.TripId, references), departureTime, json.CurrentTime, this.getExit(departure.StopId))
        ) json.Data.Entry.StopTimes
            

    member this.getDepartures (stop:JsonStructures.Stop) =
        async {
            try
                let! json = getJson (stopDeparturesUrl stop)
                return this.getDeparturesFromJson(json)
            with
                |ex -> 
                    printfn "Could not load departures"
                    return [||]
        }
        
    member this.getDeparturesWithFictive(stop:JsonStructures.Stop, fictiveDeparturesPath) =
        async{
            let! departures = this.getDepartures(stop)
            let fictiveDepartures = [||]//FictiveRoutes.getDepartures(stop.Ids)

            let combinedDepartures = Array.append (departures) (fictiveDepartures)
            let sort = Array.sortBy (fun (dep:Departure) -> 
                dep.timeUntilDeparture.time) combinedDepartures
            //Array.iter (fun (dep:Departure) -> 
            //    printfn "%s %s" dep.departureAsString dep.route.destination) sort
            return sort
        } |> Async.StartAsTask
