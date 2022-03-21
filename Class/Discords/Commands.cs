using Discord;
using Discord.Commands;
using Discord.WebSocket;
using StoneWeather.Class.Tools;
using StoneWeather.Resources.Language;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoneWeather.Class.Discords
{
    public class Commands : ModuleBase<SocketCommandContext>
    {
        #region 定义命令
        #region 文本命令
        [Command("search-weather")]
        internal async Task SearchWeather(params string[] Countrys)
        {
            string Country = GetCountryName(Countrys);
            SearchWeather(Country);
        }

        [Command("sw")]
        internal async Task sw(params string[] Citys)
        {
            string City = GetCountryName(Citys);
            SearchWeather(City);
        }

        [Command("config")]
        internal async Task Config(string ConfigName, string ConfigValue)
        {
            string Author = $"{CommandHandler.message.Author.Username}#{CommandHandler.message.Author.Discriminator}";
            switch (ConfigName)
            {
                case "Lang":
                    switch (ConfigValue)
                    {
                        case "zh_CN":
                            Lang.Language[Author] = Lang.zh_CN;
                            break;
                        case "en_US":
                            Lang.Language[Author] = Lang.en_US;
                            break;
                        default:
                            await Help();
                            return;
                    }
                    ConfigSet cs = new ConfigSet("Stone Weather\\Config.ini", true);
                    cs.SetConfigValue(Author, Lang.Language[Author].Name);
                    cs.WriteConfigToFile(ConfigFile.newFile);
                    await ReplyAsync(Lang.Language[Author].GetLanguage_Configured_Tip(CommandHandler.message.Author.Mention, Lang.Language[Author].Name));
                    break;
                default:
                    await Help();
                    break;
            }
        }

        [Command("help")]
        internal async Task Help()
        {
            UpdateLang();
            string Author = $"{CommandHandler.message.Author.Username}#{CommandHandler.message.Author.Discriminator}";
            var embed = new EmbedBuilder
            {
                Title = Lang.Language[Author].Help_Name,
            };
            embed.AddField(Lang.Language[Author].Command, @$"{Lang.Language[Author].CommandHelp_SW_Description}

{Lang.Language[Author].CommandHelp_SearchWeather_Description}

{Lang.Language[Author].CommandHelp_Config_Description}
");
            await ReplyAsync(embed: embed.Build());
        }

        internal string GetCountryName(string[] Citys)
        {
            string City = Citys[0];
            for (int i = 1; i < Citys.Length; i++) { City += " "; City += Citys[i]; }
            return City;
        }

        internal async Task SearchWeather(string City)
        {
            UpdateLang();
            string Author = $"{CommandHandler.message.Author.Username}#{CommandHandler.message.Author.Discriminator}";
            var WeatherInfo = await Tools.API.OpenWeatherMap.OpenWeatherMapAPI.GetWeatherAsync("98f7ba2a3a339b38b21a199b146425f3", City, Lang.Language[Author].Name);
            var embed = new EmbedBuilder
            {
                Title = Lang.Language[Author].GetCityName(City),
                Color = Color.Green,
                ImageUrl = $"https://openweathermap.org/themes/openweathermap/assets/vendor/owm/img/widgets/{WeatherInfo.Weather.Icon}.png"
            };
            embed.AddField(Lang.Language[Author].Weather_CurrentTemp_Name, $"{WeatherInfo.Main.CelsiusTemp}°C", true);
            embed.AddField(Lang.Language[Author].Weather_MaxTemp_Name, $"{WeatherInfo.Main.CelsiusTemp_Max}°C", true);
            embed.AddField(Lang.Language[Author].Weather_MinTemp_Name, $"{WeatherInfo.Main.CelsiusTemp_Min}°C", true);
            embed.AddField(Lang.Language[Author].Weather_Feels_Like_Name, $"{WeatherInfo.Main.CelsiusFeels_Like}°C", true);
            embed.AddField(Lang.Language[Author].Weather_Description_Name, $"{WeatherInfo.Weather.Description}", true);
            embed.AddField(Lang.Language[Author].Weather_Humidity_Name, $"{WeatherInfo.Main.Humidity} %", true);
            await ReplyAsync(embed: embed.Build());
        }

        internal void UpdateLang()
        {
            string Author = $"{CommandHandler.message.Author.Username}#{CommandHandler.message.Author.Discriminator}";
            try
            {
                Lang.Language[Author] = Lang.Language[Author];
            }
            catch
            {
                Lang.Language[Author] = Lang.zh_CN;
                ConfigSet cs = new ConfigSet("Stone Weather\\Config.ini", true);
                cs.SetConfigValue(Author, "zh_CN");
                cs.WriteConfigToFile(ConfigFile.newFile);
            }
        }
        #endregion
        #endregion

        #region 事件触发

        #endregion
    }
}
