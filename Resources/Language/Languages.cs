using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoneWeather.Resources.Language
{
    internal class Languages
    {
        internal string Name;
        internal string Help_Name;
        internal string Command;
        internal string CommandHelp_SW_Description;
        internal string CommandHelp_Config_Description;
        internal string Weather_CurrentTemp_Name;
        internal string Weather_MaxTemp_Name;
        internal string Weather_MinTemp_Name;
        internal string Weather_Feels_Like_Name;
        internal string Weather_Description_Name;
        internal string Weather_Humidity_Name;
        internal string CityIsNotCorrectTip;
        internal string SearchingWeatherTip;

        internal virtual string GetCityName(string CityName) { return null; }

        internal virtual string GetLanguage_Configured_Tip(string Author, string LanguageName) { return null; }
    }
}
