namespace BKK_API_manager

open FSharp.Data

module JsonStructures =
    type StopDepartureStructure = JsonProvider<
    """ {
      "currentTime": 1683558415924,
      "version": 4,
      "status": "OK",
      "code": 200,
      "text": "OK",
      "data": {
        "limitExceeded": false,
        "entry": {
          "stopId": "BKK_F01703",
          "routeIds": [
            "BKK_0850",
            "BKK_0855",
            "BKK_1850",
            "BKK_9090"
          ],
          "alertIds": [],
          "nearbyStopIds": [],
          "stopTimes": [
            {
              "stopId": "BKK_F01703",
              "stopHeadsign": "Örs vezér tere M+H",
              "departureTime": 1683558420,
              "predictedDepartureTime": 1683558492,
              "tripId": "BKK_C620118784",
              "serviceDate": "20230508",
              "mayRequireBooking": false
            },
            {
              "stopId": "BKK_F01703",
              "stopHeadsign": "Örs vezér tere M+H",
              "departureTime": 1683558720,
              "predictedDepartureTime": 1683558714,
              "tripId": "BKK_C620118789",
              "serviceDate": "20230508",
              "mayRequireBooking": false
            },
            {
              "stopId": "BKK_F01703",
              "stopHeadsign": "Kőbánya alsó vasútállomás",
              "departureTime": 1683558720,
              "predictedDepartureTime": 1683558720,
              "tripId": "BKK_C61189503",
              "serviceDate": "20230508",
              "mayRequireBooking": false
            },
            {
              "stopId": "BKK_F01701",
              "stopHeadsign": "Kőbánya-Kispest M",
              "departureTime": 1683558720,
              "predictedDepartureTime": 1683558732,
              "tripId": "BKK_C620118827",
              "serviceDate": "20230508",
              "mayRequireBooking": false
            },
            {
              "stopId": "BKK_F01701",
              "stopHeadsign": "Kőbánya-Kispest M",
              "departureTime": 1683559020,
              "predictedDepartureTime": 1683558990,
              "tripId": "BKK_C620118837",
              "serviceDate": "20230508",
              "mayRequireBooking": false
            },
            {
              "stopId": "BKK_F01701",
              "stopHeadsign": "Újhegy",
              "departureTime": 1683559020,
              "predictedDepartureTime": 1683559020,
              "tripId": "BKK_C61189513",
              "serviceDate": "20230508",
              "mayRequireBooking": false
            },
            {
              "stopId": "BKK_F01703",
              "stopHeadsign": "Örs vezér tere M+H",
              "departureTime": 1683559020,
              "predictedDepartureTime": 1683559069,
              "tripId": "BKK_C620118794",
              "serviceDate": "20230508",
              "mayRequireBooking": false
            },
            {
              "stopId": "BKK_F01703",
              "stopHeadsign": "Örs vezér tere M+H",
              "departureTime": 1683559260,
              "predictedDepartureTime": 1683559260,
              "tripId": "BKK_C620118799",
              "serviceDate": "20230508",
              "mayRequireBooking": false
            },
            {
              "stopId": "BKK_F01701",
              "stopHeadsign": "Kőbánya-Kispest M",
              "departureTime": 1683559320,
              "predictedDepartureTime": 1683559320,
              "tripId": "BKK_C620118842",
              "serviceDate": "20230508",
              "mayRequireBooking": false
            },
            {
              "stopId": "BKK_F01703",
              "stopHeadsign": "Kőbánya alsó vasútállomás",
              "departureTime": 1683559620,
              "tripId": "BKK_C61189515",
              "serviceDate": "20230508",
              "mayRequireBooking": false
            },
            {
              "stopId": "BKK_F01703",
              "stopHeadsign": "Örs vezér tere M+H",
              "departureTime": 1683559620,
              "tripId": "BKK_C620118804",
              "serviceDate": "20230508",
              "mayRequireBooking": false
            },
            {
              "stopId": "BKK_F01701",
              "stopHeadsign": "Kőbánya-Kispest M",
              "departureTime": 1683559620,
              "tripId": "BKK_C620118852",
              "serviceDate": "20230508",
              "mayRequireBooking": false
            },
            {
              "stopId": "BKK_F01703",
              "stopHeadsign": "Örs vezér tere M+H",
              "departureTime": 1683559860,
              "tripId": "BKK_C620118809",
              "serviceDate": "20230508",
              "mayRequireBooking": false
            },
            {
              "stopId": "BKK_F01701",
              "stopHeadsign": "Újhegy",
              "departureTime": 1683559920,
              "tripId": "BKK_C61189521",
              "serviceDate": "20230508",
              "mayRequireBooking": false
            },
            {
              "stopId": "BKK_F01701",
              "stopHeadsign": "Kőbánya-Kispest M",
              "departureTime": 1683559920,
              "tripId": "BKK_C620118857",
              "serviceDate": "20230508",
              "mayRequireBooking": false
            }
          ]
        },
        "references": {
          "agencies": {
            "BKK_BKK": {
              "id": "BKK_BKK",
              "name": "BKK",
              "url": "http://www.bkk.hu",
              "timezone": "Europe/Budapest",
              "lang": "hu",
              "phone": "+36 1 3 255 255"
            }
          },
          "routes": {
            "BKK_1850": {
              "id": "BKK_1850",
              "shortName": "185",
              "type": "BUS",
              "color": "009EE3",
              "textColor": "FFFFFF",
              "agencyId": "BKK_BKK",
              "iconDisplayType": "BOX",
              "iconDisplayText": "185",
              "bikesAllowed": false,
              "style": {
                "color": "009EE3",
                "icon": {
                  "type": "BOX",
                  "text": "185",
                  "textColor": "FFFFFF"
                },
                "vehicleIcon": {
                  "name": "bus",
                  "color": "009EE3",
                  "secondaryColor": "FFFFFF"
                },
                "groupId": 9
              },
              "sortOrder": 306
            },
            "BKK_0855": {
              "id": "BKK_0855",
              "shortName": "85E",
              "type": "BUS",
              "color": "009EE3",
              "textColor": "FFFFFF",
              "agencyId": "BKK_BKK",
              "iconDisplayType": "BOX",
              "iconDisplayText": "85E",
              "bikesAllowed": false,
              "style": {
                "color": "009EE3",
                "icon": {
                  "type": "BOX",
                  "text": "85E",
                  "textColor": "FFFFFF"
                },
                "vehicleIcon": {
                  "name": "bus",
                  "color": "009EE3",
                  "secondaryColor": "FFFFFF"
                },
                "groupId": 9
              },
              "sortOrder": 200
            },
            "BKK_9090": {
              "id": "BKK_9090",
              "shortName": "909",
              "type": "BUS",
              "color": "000000",
              "textColor": "FFFFFF",
              "agencyId": "BKK_BKK",
              "iconDisplayType": "BOX",
              "iconDisplayText": "909",
              "bikesAllowed": false,
              "style": {
                "color": "000000",
                "icon": {
                  "type": "BOX",
                  "text": "909",
                  "textColor": "FFFFFF"
                },
                "vehicleIcon": {
                  "name": "night-bus",
                  "color": "1E1E1E",
                  "secondaryColor": "FFFFFF"
                },
                "groupId": 13
              },
              "sortOrder": 826
            },
            "BKK_0850": {
              "id": "BKK_0850",
              "shortName": "85",
              "type": "BUS",
              "color": "009EE3",
              "textColor": "FFFFFF",
              "agencyId": "BKK_BKK",
              "iconDisplayType": "BOX",
              "iconDisplayText": "85",
              "bikesAllowed": false,
              "style": {
                "color": "009EE3",
                "icon": {
                  "type": "BOX",
                  "text": "85",
                  "textColor": "FFFFFF"
                },
                "vehicleIcon": {
                  "name": "bus",
                  "color": "009EE3",
                  "secondaryColor": "FFFFFF"
                },
                "groupId": 9
              },
              "sortOrder": 199
            }
          },
          "stops": {
            "BKK_F01703": {
              "id": "BKK_F01703",
              "vertex": "BKK:BKK_F01703",
              "lat": 47.476907,
              "lon": 19.158952,
              "name": "Lavotta utca",
              "code": "F01703",
              "direction": "-46",
              "description": "4691",
              "locationType": 0,
              "parentStationId": "BKK_CSF01703",
              "type": "BUS",
              "wheelchairBoarding": true,
              "routeIds": [
                "BKK_0850",
                "BKK_0855",
                "BKK_1850",
                "BKK_9090"
              ],
              "stopColorType": "BUS",
              "style": {
                "colors": [
                  "000000",
                  "009EE3"
                ]
              }
            },
            "BKK_F01701": {
              "id": "BKK_F01701",
              "vertex": "BKK:BKK_F01701",
              "lat": 47.475218,
              "lon": 19.157091,
              "name": "Lavotta utca",
              "code": "F01701",
              "direction": "126",
              "description": "4687",
              "locationType": 0,
              "parentStationId": "BKK_CSF01701",
              "type": "BUS",
              "wheelchairBoarding": true,
              "routeIds": [
                "BKK_0850",
                "BKK_0855",
                "BKK_1850",
                "BKK_9090"
              ],
              "stopColorType": "BUS",
              "style": {
                "colors": [
                  "000000",
                  "009EE3"
                ]
              }
            }
          },
          "trips": {
            "BKK_C620118804": {
              "id": "BKK_C620118804",
              "routeId": "BKK_0855",
              "shapeId": "BKK_C620118804",
              "blockId": "C62011_0850_11_21",
              "tripHeadsign": "Örs vezér tere M+H",
              "serviceId": "BKK_C62011AHCYM-0081",
              "directionId": "1",
              "bikesAllowed": false,
              "wheelchairAccessible": true
            }
          },
          "alerts": {}
        },
        "class": "entryWithReferences"
      }
    } """>
    type StopsStructure = JsonProvider<Sample=
    """ {
	    "stops": [
		    {
			    "longName": "typeof<string>",
			    "shortName": "typeof<string>",
			    "ids": [
				    "typeof<string>",
				    "typeof<string>"
			    ],
                "exits": [
				    "typeof<string>",
				    "typeof<string>"
			    ]
		    },
		    {
			    "longName": "typeof<string>",
			    "shortName": "typeof<string>",
			    "ids": [
				    "typeof<string>",
				    "typeof<string>"
			    ],
			    "exits": [
				    "typeof<string>",
				    "typeof<string>"
			    ]
		    }
        ]
    } """, InferenceMode=InferenceMode.ValuesAndInlineSchemasOverrides>
    type FictiveStructure = JsonProvider<Sample=
    """ {
  "routes": [
    {
      "routeId": "typeof<string>",
      "routeName": "typeof<string>",
      "routeType": "typeof<string>",
      "color": "typeof<string>",
      "textColor": "typeof<string>",
      "destinations": [
        {
          "headsigns": [
            {
              "name": "typeof<string>",
              "stops": [
                {
                  "stopId": "typeof<string>",
                  "time": "typeof<int>"
                }
              ]
            }
          ],
          "departureTimes": {
            "weekdayTimes": [
              "<typeof:string>"
            ],
            "weekendTimes": [
              "<typeof:string>"
            ]
          }
        }
      ]
    }
  ]
} """, InferenceMode=InferenceMode.ValuesAndInlineSchemasOverrides>