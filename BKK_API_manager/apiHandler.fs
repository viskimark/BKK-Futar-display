namespace BKK_API_manager

open FSharp.Data
open System.IO

module apiHandler =
    //let mutable private stopId = "stopId=BKK_F01703&stopId=BKK_F01701&"
    let stopIds (stop:JsonStructures.StopsStructure.Stop) =
        let mutable str = ""
        for id in stop.Ids do
            str <- str + "stopId=BKK_" + id + "&"
        str
        //stopId <- ""
        //for id in stopIds do
        //    stopId <- stopId + "stopId=" + id + "&"

    let key = File.ReadAllText "key.txt"
    let stopDeparturesUrl (stop:JsonStructures.StopsStructure.Stop) = "https://futar.bkk.hu/api/query/v1/ws/otp/api/where/arrivals-and-departures-for-stop?minutesBefore=1&minutesAfter=60&" + stopIds(stop) + "onlyDepartures=true&limit=60&version=4&includeReferences=compact&key=" + key
    
    let getJson url =
        async {
            let! text = Http.AsyncRequestString(url, responseEncodingOverride="UTF-8")
            return JsonStructures.StopDepartureStructure.Parse(text)
        }
    
    let stops = 
        JsonStructures.StopsStructure.Parse(File.ReadAllText("megallok.json")).Stops
        |> Array.sortBy (fun (s:JsonStructures.StopsStructure.Stop) -> s.LongName)
    let getStopLongName(index) =
        stops[index].LongName
    let getStopShortName(index) =
        stops[index].ShortName
    let stopNames =
        [|for stop in stops do stop.LongName|]

    let private exits =
        [|
            for stop in stops do
                for i in 0..stop.Ids.Length - 1 do
                    let exit =
                        if stop.Exits.Length > 0 then stop.Exits[i] else "-"
                    yield (stop.Ids[i], exit)
        |]

    let getExit(stopId) =
        let arr = 
            [|
                for exit in exits do
                    if ("BKK_" + (fst exit)) = stopId then yield (snd exit)
            |]
        if arr.Length > 0 then arr[0] else "-"

    let getDeparturesFromJson (json:JsonStructures.StopDepartureStructure.Root) = 
        let references = json.Data.References

        Array.map (fun (departure:JsonStructures.StopDepartureStructure.StopTime) ->
            let departureTime =
                match departure.PredictedDepartureTime with
                |None -> departure.DepartureTime
                |Some time -> time

            new Departure(departure.TripId, new Route(departure.StopHeadsign, departure.TripId, references), departureTime, json.CurrentTime, getExit(departure.StopId))
        ) json.Data.Entry.StopTimes
            

    let getDepartures (stop:JsonStructures.StopsStructure.Stop) =
        async {
            try
                let! json = getJson (stopDeparturesUrl stop)
                return getDeparturesFromJson(json)
            with
                |ex -> 
                    return [||]
        } |> Async.StartAsTask
        
    let getDeparturesWithFictive(stop:JsonStructures.StopsStructure.Stop, fictiveDeparturesPath) =
        let departures = getDepartures(stop).Result
        let fictiveDepartures = FictiveRoutes.getDepartures(stop.Ids)

        let combinedDepartures = Array.append (departures) (fictiveDepartures)
        let sort = Array.sortBy (fun (dep:Departure) -> 
            dep.timeUntilDeparture.time) combinedDepartures
        //Array.iter (fun (dep:Departure) -> 
        //    printfn "%s %s" dep.departureAsString dep.route.destination) sort
        sort
