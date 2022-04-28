using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoneWeather.Class.Tools.API.OpenWeatherMap.Result.CurrentWeather
{
    internal class Wind
    {
        #region 声明字段
        internal int Speed { get; }
        internal string Deg { get; }
        #endregion

        #region 构造方法
        internal Wind(JToken WeatherData)
        {
            if (WeatherData == null)
            {
                throw new ArgumentNullException("The value cannot be null.");
            }
            this.Speed = WeatherData.Value<int>("speed");
            this.Deg = WeatherData.Value<string>("deg");
        }
        #endregion
    }
}
