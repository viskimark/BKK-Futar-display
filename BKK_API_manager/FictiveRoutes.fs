namespace BKK_API_manager

open FSharp.Data
open System
open System.IO

type DepartureData(route:JsonStructures.FictiveRoute, destination, headsign, addMinutes) =
    member this.route = route
    member this.destination = destination
    member this.headsign = headsign
    member this.addMinutes = addMinutes

type FictiveRoutes(routes:JsonStructures.FictiveRoute[], exits) =
    //let stops = 
    //    let stops = JsonStructures.StopsStructure.Parse(File.ReadAllText("megallok.json")).Stops
    //    Array.sortBy (fun (s:JsonStructures.StopsStructure.Stop) -> s.LongName) stops

    //let private exits =
    //    [|
    //        for stop in stops do
    //            for i in 0..stop.Ids.Length - 1 do
    //                let exit =
    //                    if stop.Exits.Length > 0 then stop.Exits[i] else "-"
    //                yield (stop.Ids[i], exit)
    //    |]

    let getExit(stopId) =
        let arr = 
            [|
                for exit in exits do
                    if ("BKK_" + (fst exit)) = stopId then yield (snd exit)
            |]
        if arr.Length > 0 then arr[0] else "-"

    let getRoutesAndDestinationsFromStop(stopId) =
        [|
            for route in routes do
                for destination in route.destinations do
                    for headsign in destination.headsigns do
                        for stop in headsign.stops do
                            if stop.stopId = stopId then
                                yield new DepartureData(route, destination, headsign.name, stop.time)
        |]

    member this.getDepartures(stopIds:string array) =
        Array.sortBy (fun (dep:Departure) -> dep.departure) [|
        for stopId in stopIds do
            let routesAndDestinationsFromStop = getRoutesAndDestinationsFromStop(stopId)
            for (departureData:DepartureData) in routesAndDestinationsFromStop do
                let route = departureData.route
                let destination = departureData.destination
                
                let departureTimes = 
                    if DateTime.Today.DayOfWeek = DayOfWeek.Sunday || DateTime.Today.DayOfWeek = DayOfWeek.Saturday
                    then
                        match destination.departureTimes.weekendTimes with
                        |x when x[0] = "*" -> destination.departureTimes.weekdayTimes
                        |_ -> destination.departureTimes.weekendTimes
                    else
                        destination.departureTimes.weekdayTimes


                for departure in departureTimes do
                    let currentTimeUnix = DateTimeOffset.Now.ToUnixTimeMilliseconds()
                    let departureUnix = DateTimeOffset.Parse(departure).AddMinutes(departureData.addMinutes).ToUnixTimeSeconds()

                    if departureUnix > (currentTimeUnix / 1000L) && (departureUnix - (currentTimeUnix / 1000L)) / 60L <= 60L then
                        yield new Departure("", new Route(departureData.headsign, route.routeId, route.routeName, route.routeType, route.color, route.textColor), departureUnix, currentTimeUnix, getExit(stopId))
        |]