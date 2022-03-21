using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoneWeather.Class.Tools.API.OpenWeatherMap.Result.OpenWeatherMap
{
    internal class WeatherResult
    {
        #region 声明字段
        internal Coord Coord { get; }
        internal Weather Weather { get; }
        internal string Base { get; }
        internal Main Main { get; }
        internal double Visibility { get; }
        internal Wind Wind { get; }
        internal Clouds Clouds { get; }
        internal double DT { get; }
        internal Sys Sys { get; }
        internal int Timezone { get; }
        internal int ID { get; }
        internal string Name { get; }
        internal int Cod { get; }
        #endregion

        #region 构造方法
        internal WeatherResult(string Json)
        {
            var JsonData = JObject.Parse(Json);
            if (JsonData.Value<string>("cod") == "404")
            {
                throw new ArgumentException("404");
            }
            else if (JsonData.Value<string>("cod") == "401")
            {
                throw new ArgumentException("401");
            }
            this.Coord = new Coord(JsonData.Value<JToken>("coord"));
            foreach (JToken weather in JsonData.Value<JToken>("weather"))
            {
                this.Weather = new Weather(weather);
            }
            this.Base = JsonData.Value<string>("base");
            this.Main = new Main(JsonData.Value<JToken>("main"));
            this.Visibility = JsonData.Value<double>("visibility");
            this.Wind = new Wind(JsonData.Value<JToken>("wind"));
            this.Clouds = new Clouds(JsonData.Value<JToken>("clouds"));
            this.DT = JsonData.Value<double>("dt");
            this.Sys = new Sys(JsonData.Value<JToken>("sys"));
            this.Timezone = JsonData.Value<int>("timezone");
            this.ID = JsonData.Value<int>("id");
            this.Name = JsonData.Value<string>("name");
            this.Cod = JsonData.Value<int>("cod");
        }
        #endregion
    }
}
