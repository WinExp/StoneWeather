using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoneWeather.Class.Tools.API.OpenWeatherMap.Result.OpenWeatherMap
{
    internal class Clouds
    {
        #region 声明字段
        internal double All { get; }
        #endregion

        #region 构造方法
        internal Clouds(JToken WeatherData)
        {
            if (WeatherData == null)
            {
                throw new ArgumentNullException("The value cannot be null.");
            }
            this.All = WeatherData.Value<int>("all");
        }
        #endregion
    }
}
