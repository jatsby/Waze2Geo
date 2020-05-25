using GeoJSON.Net.Geometry;
using System;
using System.Collections.Generic;
using System.Text;

namespace Waze2Geo.Models
{
    // Jams only for now
    public class WazeGeoJson
    {
        public string type { get; set; } // FeatureCollection
        public List<Feature> features { get; set; }
    }

    public class Properties //whatevs, custom stuff (waze extra properties)
    {
        public string type { get; set; } // ROAD_CLOSED
        public string subType { get; set; } // ROAD_CLOSED_EVENT
        public string street { get; set; } // Long Bay Rd
        public string reportDescription { get; set; }
        public string city { get; set; }

        // Jam-specific
        public double? speed { get; set; }
        public string endNode { get; set; }

    }

    public class Geometry
    {
        public string type { get; set; } // LineString, point, etc.
        public dynamic coordinates { get; set; } //List<double> for a Point, List<List<double>> for LineString
    }

    public class Feature
    {
        public string type { get; set; } //jam or alert?
        public Properties properties { get; set; }
        public Geometry geometry { get; set; }
    }
}
