﻿namespace BKK_API_manager

open FSharp.Data
open System
open System.IO

type DepartureData(route:JsonStructures.FictiveStructure.Route, destination, headsign, addMinutes) =
    member this.route = route
    member this.destination = destination
    member this.headsign = headsign
    member this.addMinutes = addMinutes

module FictiveRoutes =
    let defaultPath = "fiktiv.json"
    let getJson(path) = JsonStructures.FictiveStructure.Parse(File.ReadAllText(path))
    let json = getJson(defaultPath)

    let stops = 
        let stops = JsonStructures.StopsStructure.Parse(File.ReadAllText("megallok.json")).Stops
        Array.sortBy (fun (s:JsonStructures.StopsStructure.Stop) -> s.LongName) stops

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

    let getRoutesAndDestinationsFromStop(stopId) =
        //Array.sortBy (fun (departureData:DepartureData) -> departureData.route.RouteName)
            [|
            for (route:JsonStructures.FictiveStructure.Route) in json.Routes do
                for (destination:JsonStructures.FictiveStructure.Destination) in route.Destinations do
                    for (headsign:JsonStructures.FictiveStructure.Headsign) in destination.Headsigns do
                        for (stop:JsonStructures.FictiveStructure.Stop) in headsign.Stops do
                            if stop.StopId = stopId then
                                yield new DepartureData(route, destination, headsign.Name, stop.Time)
        |]

    let getDepartures(stopIds:string array) =
        Array.sortBy (fun (dep:Departure) -> dep.departure) [|
        for stopId in stopIds do
            let routesAndDestinationsFromStop = getRoutesAndDestinationsFromStop(stopId)
            for (departureData:DepartureData) in routesAndDestinationsFromStop do
                let route = departureData.route
                let destination = departureData.destination
                
                let departureTimes = 
                    if DateTime.Today.DayOfWeek = DayOfWeek.Sunday || DateTime.Today.DayOfWeek = DayOfWeek.Saturday
                    then
                        match destination.DepartureTimes.WeekendTimes with
                        |x when x[0] = "*" -> destination.DepartureTimes.WeekdayTimes
                        |_ -> destination.DepartureTimes.WeekendTimes
                    else
                        destination.DepartureTimes.WeekdayTimes


                for departure in departureTimes do
                    let currentTimeUnix = DateTimeOffset.Now.ToUnixTimeMilliseconds()
                    let departureUnix = DateTimeOffset.Parse(departure).AddMinutes(departureData.addMinutes).ToUnixTimeSeconds()

                    if departureUnix > (currentTimeUnix / 1000L) && (departureUnix - (currentTimeUnix / 1000L)) / 60L <= 60L then
                        yield new Departure("", new Route(departureData.headsign, route.RouteId, route.RouteName, route.RouteType, route.Color, route.TextColor), departureUnix, currentTimeUnix, getExit(stopId))
        |]