using Discord;
using Discord.Commands;
using Discord.Interactions;
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
    public static class Commands
    {
        #region 定义命令
        #region 文本命令
        public static string[] ConfigNames = new string[1] { "Lang" };

        internal static async Task Config(string ConfigName, string ConfigValue, SocketSlashCommand command)
        {
            string Author = $"{command.User.Username}#{command.User.Discriminator}";
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
                            await Help(command);
                            return;
                    }
                    ConfigSet cs = new ConfigSet("Stone Weather\\Config.ini", true);
                    cs.SetConfigValue(Author, Lang.Language[Author].Name);
                    cs.WriteConfigToFile(ConfigFile.newFile);
                    await command.RespondAsync(Lang.Language[Author].GetLanguage_Configured_Tip(command.User.Mention, Lang.Language[Author].Name), ephemeral: true);
                    break;
                default:
                    await Help(command);
                    break;
            }
        }

        internal static async Task Help(SocketSlashCommand command)
        {
            UpdateLang(command);
            string Author = $"{command.User.Username}#{command.User.Discriminator}";
            var embed = new EmbedBuilder
            {
                Title = Lang.Language[Author].Help_Name,
            };
            embed.AddField(Lang.Language[Author].Command, @$"{Lang.Language[Author].CommandHelp_SW_Description}

{Lang.Language[Author].CommandHelp_Config_Description}
");
            await command.RespondAsync(embed: embed.Build(), ephemeral: true);
        }

        internal static async Task SearchWeather(string City, SocketSlashCommand command)
        {
            UpdateLang(command);
            string Author = $"{command.User.Username}#{command.User.Discriminator}";
            Tools.API.OpenWeatherMap.Result.CurrentWeather.WeatherResult WeatherInfo = null;
            try
            {
                WeatherInfo = await Tools.API.OpenWeatherMap.OpenWeatherMapAPI.GetCurrentWeatherResultAsync("98f7ba2a3a339b38b21a199b146425f3", City, Lang.Language[Author].Name);
            }
            catch (ArgumentException ex)
            {
                await command.RespondAsync(Lang.Language[Author].CityIsNotCorrectTip);
                return;
            }
            var embed = new EmbedBuilder
            {
                Title = Lang.Language[Author].GetCityName(WeatherInfo.Name),
                Color = Color.Green,
                ImageUrl = $"https://openweathermap.org/themes/openweathermap/assets/vendor/owm/img/widgets/{WeatherInfo.Weather.Icon}.png"
            };
            embed.AddField(Lang.Language[Author].Weather_CurrentTemp_Name, $"{WeatherInfo.Main.Temp}°C", true);
            embed.AddField(Lang.Language[Author].Weather_MaxTemp_Name, $"{WeatherInfo.Main.Temp_Max}°C", true);
            embed.AddField(Lang.Language[Author].Weather_MinTemp_Name, $"{WeatherInfo.Main.Temp_Min}°C", true);
            embed.AddField(Lang.Language[Author].Weather_Feels_Like_Name, $"{WeatherInfo.Main.Feels_Like}°C", true);
            embed.AddField(Lang.Language[Author].Weather_Description_Name, $"{WeatherInfo.Weather.Description}", true);
            embed.AddField(Lang.Language[Author].Weather_Humidity_Name, $"{WeatherInfo.Main.Humidity} %", true);
            await command.RespondAsync(embed: embed.Build(), ephemeral: true);
        }

        internal static void UpdateLang(SocketSlashCommand command)
        {
            string Author = $"{command.User.Username}#{command.User.Discriminator}";
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
    }
}
