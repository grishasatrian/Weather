using System;
using System.Collections.Generic;
using System.Text;

namespace Weather.bll
{
    public class WeatherDataModel
    {
        public Coord coord { get; set; }
        public Weather[] weather { get; set; }
        public string _base { get; set; }
        public Main main { get; set; }
        public int visibility { get; set; }
        public Wind wind { get; set; }
        public Clouds clouds { get; set; }
        public int dt { get; set; }
        public Sys sys { get; set; }
        public int timezone { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public int cod { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(" ============================== Weather in {0} =============================", name);
            if (main != null)
            {
                sb.AppendLine();
                sb.AppendFormat(" Temperature: {0} °C ", main.temp);
                sb.AppendLine();
                sb.AppendFormat(" Feels like: {0} ", main.feels_like);
                sb.AppendLine();
                sb.AppendFormat(" Humidity: {0} ", main.humidity);
                sb.AppendLine();
            }
            sb.AppendLine(" ==============================================================================");
            return sb.ToString();
        }
    }

    public class Coord
    {
        public float lon { get; set; }
        public float lat { get; set; }
    }

    public class Main
    {
        public float temp { get; set; }
        public float feels_like { get; set; }
        public float temp_min { get; set; }
        public float temp_max { get; set; }
        public int pressure { get; set; }
        public int humidity { get; set; }
    }

    public class Wind
    {
        public float speed { get; set; }
        public int deg { get; set; }
    }

    public class Clouds
    {
        public int all { get; set; }
    }

    public class Sys
    {
        public int type { get; set; }
        public int id { get; set; }
        public string country { get; set; }
        public int sunrise { get; set; }
        public int sunset { get; set; }
    }

    public class Weather
    {
        public int id { get; set; }
        public string main { get; set; }
        public string description { get; set; }
        public string icon { get; set; }
    }
}