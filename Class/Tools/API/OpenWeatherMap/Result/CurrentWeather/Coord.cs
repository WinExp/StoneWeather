using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoneWeather.Class.Tools.API.OpenWeatherMap.Result.CurrentWeather
{
    internal class Coord
    {
        #region 声明字段
        internal double Longitude { get; }
        internal double Latitude { get; }
        #endregion

        #region 构造方法
        internal Coord(JToken CoordData)
        {
            if (CoordData == null)
            {
                throw new ArgumentNullException("The value cannot be null.");
            }
            this.Longitude = CoordData.Value<double>("lon");
            this.Latitude = CoordData.Value<double>("lat");
        }
        #endregion
    }
}
