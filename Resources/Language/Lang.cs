using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoneWeather.Resources.Language
{
    internal static class Lang
    {
        internal static zh_CN zh_CN = new zh_CN();
        internal static en_US en_US = new en_US();
        internal static Dictionary<string, Languages> Language = new Dictionary<string, Languages>();
        internal static Languages GlobalLanguage = zh_CN;
    }
}
