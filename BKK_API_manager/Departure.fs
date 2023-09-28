namespace BKK_API_manager

open FSharp.Data
open System

type RouteType =
|BUS
|TRAM
|TROLLEYBUS

type Route(destination:string, routeId:string, routeName:string, routeType:string, color:string, textColor:string) =
    member this.destination = destination
    member this.routeId = routeId
    member this.routeName = routeName
    member this.routeType = 
        match routeType with
            |"TRAM" -> RouteType.TRAM
            |"TROLLEYBUS" -> RouteType.TROLLEYBUS
            |_ -> RouteType.BUS
    member this.color = color
    member this.textColor = textColor

    new (destination:string, tripId:string, references:JsonStructures.StopDepartureStructure.References) =
        let destination = destination

        let routeId =
            match references.Trips.JsonValue.TryGetProperty tripId with
            |None -> ""
            |Some tripId ->
                match tripId.TryGetProperty "routeId" with
                |None -> ""
                |Some routeId -> routeId.AsString()

        let routeName =
            match references.Routes.JsonValue.TryGetProperty routeId with
            |None -> routeId
            |Some _routeId ->
                match _routeId.TryGetProperty "shortName" with
                |None -> routeId
                |Some shortName -> shortName.AsString()

        let routeType =
            match references.Routes.JsonValue.TryGetProperty routeId with
            |None -> "BUS"
            |Some _routeId ->
                match _routeId.TryGetProperty "type" with
                |None -> "BUS"
                |Some _type -> _type.AsString()

        let color =
            match references.Routes.JsonValue.TryGetProperty routeId with
            |None -> routeId
            |Some _routeId ->
                (_routeId.TryGetProperty "color").Value.AsString()

        let textColor =
            match references.Routes.JsonValue.TryGetProperty routeId with
            |None -> routeId
            |Some _routeId ->
                (_routeId.TryGetProperty "textColor").Value.AsString()
        
        new Route(destination, routeId, routeName, routeType, color, textColor)

type TimeUntilDeparture(departure, currentTime) =
    let departure = departure
    let currentTime = currentTime
    
    member this.timeInSeconds = departure - (currentTime / 1000L) + 30L
    member this.time = this.timeInSeconds / 60L
    override this.ToString() =
        if this.time > 0 then
            sprintf "%i'" this.time
        else
            sprintf "MOST"

type Departure(tripId:string, route:Route, departure:int64, currentTime:int64, exit:string) =
    member this.tripId = tripId

    member this.route = route

    member this.departure = departure
    member this.currentTime = currentTime
    
    member this.departureAsString = DateTimeOffset.FromUnixTimeSeconds(departure).ToString("H:mm")
    member this.currentTimeAsString = DateTimeOffset.FromUnixTimeMilliseconds(currentTime).ToString("H:mm")
    member this.timeUntilDeparture = new TimeUntilDeparture(departure, currentTime)

    member this.exit = exit