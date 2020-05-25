using System;
using System.Collections.Generic;
using System.Text;

namespace Waze2Geo.Models
{
    public class Location
    {
        public double? x { get; set; }
        public double? y { get; set; }
    }

    public class Alert
    {
        public string country { get; set; }
        public int? nThumbsUp { get; set; }
        public int? reportRating { get; set; }
        public int? confidence { get; set; }
        public int? reliability { get; set; }
        public string type { get; set; }
        public string uuid { get; set; }
        public int? magvar { get; set; }
        public string subtype { get; set; }
        public string street { get; set; }
        public string reportDescription { get; set; }
        public Location location { get; set; }
        public object pubMillis { get; set; }
        public string city { get; set; }
        public int? roadType { get; set; }
    }

    public class Line
    {
        public double? x { get; set; }
        public double? y { get; set; }
    }

    public class Segment
    {
    }

    public class Jam
    {
        public string country { get; set; }
        public string city { get; set; }
        public int? level { get; set; }
        public List<Line> line { get; set; }
        public double? speedKMH { get; set; }
        public int? length { get; set; }
        public string turnType { get; set; }
        public string type { get; set; }
        public int? uuid { get; set; }
        public string endNode { get; set; }
        public double? speed { get; set; }
        public List<Segment> segments { get; set; }
        public int? roadType { get; set; }
        public int? delay { get; set; }
        public string street { get; set; }
        public int? id { get; set; }
        public object pubMillis { get; set; }
        public string blockingAlertUuid { get; set; }
        public string startNode { get; set; }
    }

    public class WazeResult
    {
        public List<Alert> alerts { get; set; }
        public long? endTimeMillis { get; set; }
        public long? startTimeMillis { get; set; }
        public string startTime { get; set; }
        public string endTime { get; set; }
        public List<Jam> jams { get; set; }
    }
}
