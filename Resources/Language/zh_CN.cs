using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoneWeather.Resources.Language
{
    internal class zh_CN : Languages
    {
        internal readonly new string Name = "zh_CN";
        internal readonly new string Help_Name = "帮助";
        internal readonly new string Command = "指令";
        internal readonly new string CommandHelp_SearchWeather_Description = @"**s!search-weather**
用法：s!search-weather <城市/国家名称>
示例：s!search-weather Shenzhen";
        internal readonly new string CommandHelp_SW_Description = @"**s!sw**
用法：s!sw <城市/国家名称>
示例：s!sw Shenzhen";
        internal readonly new string CommandHelp_Config_Description = @"**s!config**
用法: s!config <配置名称> <配置值>
示例: s!config Lang zh_CN";
        internal readonly new string Weather_CurrentTemp_Name = "当前温度";
        internal readonly new string Weather_MaxTemp_Name = "最大温度";
        internal readonly new string Weather_MinTemp_Name = "最小温度";
        internal readonly new string Weather_Feels_Like_Name = "感受温度";
        internal readonly new string Weather_Description_Name = "天气情况";
        internal readonly new string Weather_Humidity_Name = "湿度";
        internal readonly new string CityIsNotCorrectTip = "您输入的城市不存在。";
        internal readonly new string SearchingWeatherTip = "正在查询天气...";

        internal zh_CN()
        {
            base.Name = this.Name;
            base.Help_Name = this.Help_Name;
            base.Command = this.Command;
            base.CommandHelp_SearchWeather_Description= this.CommandHelp_SearchWeather_Description;
            base.CommandHelp_SW_Description = this.CommandHelp_SW_Description;
            base.Weather_CurrentTemp_Name = this.Weather_CurrentTemp_Name;
            base.Weather_MaxTemp_Name = this.Weather_MaxTemp_Name;
            base.Weather_MinTemp_Name = this.Weather_MinTemp_Name;
            base.Weather_Feels_Like_Name= this.Weather_Feels_Like_Name;
            base.Weather_Description_Name = this.Weather_Description_Name;
            base.Weather_Humidity_Name= this.Weather_Humidity_Name;
            base.CommandHelp_Config_Description = this.CommandHelp_Config_Description;
            base.CityIsNotCorrectTip = this.CityIsNotCorrectTip;
            base.SearchingWeatherTip = this.SearchingWeatherTip;
        }

        internal override string GetCityName(string CityName)
        {
            return $"当前 {CityName} 的天气";
        }

        internal override string GetLanguage_Configured_Tip(string Author, string LanguageName)
        {
            return $"{Author} 已将您的默认语言更改为 {LanguageName}。";
        }
    }
}
