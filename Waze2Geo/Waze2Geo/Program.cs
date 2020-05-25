using Flurl.Http;
using GeoJSON.Net.Geometry;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using Waze2Geo.Models;

namespace Waze2Geo
{
    class Program
    {
        static void Main(string[] args)
        {
            //always be asking for URLs to parse
            while (true)
            {
                Console.WriteLine("Please provide a polygon to fetch Waze data for:");
                var baseUrl = "https://na-georss.waze.com/rtserver/web/TGeoRSS?tk=ccp_partner&format=JSON&types=traffic,alerts,irregularities&polygon=";
                var polygon = Console.ReadLine();

                //get Waze data
                var wazeData = GetWazeData(baseUrl + polygon);
                var dataDate = Convert.ToDateTime(wazeData.startTime.Substring(0, 18));
                Console.WriteLine($"Fetched data for {dataDate}");
                var features = new List<Feature>();

                // alerts
                foreach (var alert in wazeData.alerts)
                {
                    var feature = new Feature
                    {
                        type = "Feature",
                        geometry = new Geometry
                        {
                            type = "Point",
                            coordinates = new List<double?> { alert.location.x, alert.location.y },
                        },
                        properties = new Properties {
                            type = alert.type,
                            subType = alert.subtype,
                            city = alert.city,
                            street = alert.street,
                            reportDescription = alert.reportDescription,
                        }
                    };

                    features.Add(feature);
                }

                // jams
                foreach (var jam in wazeData.jams)
                {
                    var coordinates = new List<List<double?>>();
                    foreach (var point in jam.line) {
                        var pointCoordinates = new List<double?> { point.x,point.y };
                        coordinates.Add(pointCoordinates);
                    }

                    var feature = new Feature
                    {
                        type = "Feature",
                        geometry = new Geometry
                        {
                            type = "LineString",
                            coordinates = coordinates
                        },
                        properties = new Properties
                        {
                            type = jam.type,
                            city = jam.city,
                            //subType = jam.subtype, //TODO: add Jam-specific properties (and maybe keep them separate from Alert-specific properties?)
                            street = jam.street,
                            //reportDescription = jam.reportDescription,
                            speed = jam.speed,
                            endNode = jam.endNode,
                        }
                    };

                    features.Add(feature);
                }

                var result = new WazeGeoJson
                {
                    type = "FeatureCollection",
                    features = features
                };

                //write GeoJSON to a file
                var geoJson = JsonConvert.SerializeObject(result);
                File.WriteAllText($@"./waze_{dataDate.ToString("MM-dd-yyyy_HH_mm")}.json", geoJson);
            }
        }

        public static WazeResult GetWazeData(string url)
        {
            try
            {
                var response = url
                    .GetJsonAsync<WazeResult>();
                return response.Result;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception getting Waze JSON with \"{url.Substring(0, 20)}\"...  - {e}");
                return null;
            }
        }

    }
}
