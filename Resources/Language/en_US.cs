using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoneWeather.Resources.Language
{
    internal class en_US : Languages
    {
        internal readonly new string Name = "en_US";
        internal readonly new string Help_Name = "Help";
        internal readonly new string Command = "Command";
        internal readonly new string CommandHelp_SW_Description = @"**/sw**
Usage: /sw <city/country name>
Example: /sw Shenzhen";
        internal readonly new string CommandHelp_Config_Description = @"**/config**
Usage: /config <Config Name> <Config Value>
Example: /config Lang en_US";
        internal readonly new string Weather_CurrentTemp_Name = "Current Temperature";
        internal readonly new string Weather_MaxTemp_Name = "High Temperature";
        internal readonly new string Weather_MinTemp_Name = "Low Temperature";
        internal readonly new string Weather_Feels_Like_Name = "Feels Like";
        internal readonly new string Weather_Description_Name = "Weather";
        internal readonly new string Weather_Humidity_Name = "Humidity";
        internal readonly new string CityIsNotCorrectTip = "The city you entered does not exist.";
        internal readonly new string SearchingWeatherTip = "Checking the weather...";

        internal en_US()
        {
            base.Name = this.Name;
            base.Help_Name = this.Help_Name;
            base.Command = this.Command;
            base.CommandHelp_SW_Description = this.CommandHelp_SW_Description;
            base.CommandHelp_Config_Description = this.CommandHelp_Config_Description;
            base.Weather_CurrentTemp_Name = this.Weather_CurrentTemp_Name;
            base.Weather_MaxTemp_Name = this.Weather_MaxTemp_Name;
            base.Weather_MinTemp_Name = this.Weather_MinTemp_Name;
            base.Weather_Feels_Like_Name = this.Weather_Feels_Like_Name;
            base.Weather_Description_Name = this.Weather_Description_Name;
            base.Weather_Humidity_Name = this.Weather_Humidity_Name;
            base.CityIsNotCorrectTip = this.CityIsNotCorrectTip;
            base.SearchingWeatherTip = this.SearchingWeatherTip;
        }

        internal override string GetCityName(string CityName)
        {
            return $"Current Weather in {CityName}";
        }

        internal override string GetLanguage_Configured_Tip(string Author, string LanguageName)
        {
            return $"{Author} Changed your default language to {LanguageName}.";
        }
    }
}
