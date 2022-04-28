using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace StoneWeather.Class.Tools.Net.Http
{
    internal static class Client
    {
        #region Http Client 方法
        internal static async Task<string> GetRequest(string Uri)
        {
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(Uri);
                return await response.Content.ReadAsStringAsync();
            }
        }
        #endregion
    }
}
