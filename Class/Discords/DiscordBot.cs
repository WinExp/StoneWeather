using Discord;
using Discord.Net.Rest;
using Discord.WebSocket;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace StoneWeather.Class.Discords
{
    internal class DiscordBot
    {
        #region 声明字段
        internal DiscordSocketClient Client;
        #endregion

        #region 核心方法
        internal DiscordBot(bool useProxy = true)
        {
            var config = new DiscordSocketConfig
            {
                RestClientProvider = DefaultRestClientProvider.Create(useProxy)
            };
            this.Client = new DiscordSocketClient(config);
            this.Client.Log += Log;
            this.Client.Ready += Client_Ready;
            this.Client.SlashCommandExecuted += Client_SlashCommandExecuted;
        }

        private async Task Client_SlashCommandExecuted(SocketSlashCommand arg)
        {
            switch (arg.CommandName)
            {
                case "help":
                    await Commands.Help(arg);
                    break;
                case "sw":
                    string city = arg.Data.Options.First().Value.ToString();
                    await Commands.SearchWeather(city, arg);
                    break;
                case "config":
                    string name = Commands.ConfigNames[(long)arg.Data.Options.First().Value];
                    string value = arg.Data.Options.Last().Value.ToString();
                    await Commands.Config(name, value, arg);
                    break;
            }
        }

        private async Task Client_Ready()
        {
            var helpCommand = new SlashCommandBuilder()
            .WithName("help")
            .WithDescription("获取 Stone Weather 帮助。");
            await Client.CreateGlobalApplicationCommandAsync(helpCommand.Build());

            var swCommand = new SlashCommandBuilder()
            .WithName("sw")
            .WithDescription("获取天气。")
            .AddOption("city", ApplicationCommandOptionType.String, "你想要查找的城市。", true);
            await Client.CreateGlobalApplicationCommandAsync(swCommand.Build());

            var configCommand = new SlashCommandBuilder()
            .WithName("config")
            .WithDescription("更改配置。")
            .AddOption(new SlashCommandOptionBuilder().WithType(ApplicationCommandOptionType.Integer).WithName("name").WithDescription("配置名称。").WithRequired(true).AddChoice("Lang", 0))
            .AddOption("value", ApplicationCommandOptionType.String, "配置值。", true);
            await Client.CreateGlobalApplicationCommandAsync(configCommand.Build());
        }
        #endregion

        #region 连接 Discord 方法
        internal async Task Connect(string Token)
        {
            await this.Client.LoginAsync(TokenType.Bot, Token);
            await this.Client.StartAsync();
        }

        internal async Task Disconnect()
        {
            await this.Client.LogoutAsync();
            await this.Client.StopAsync();
        }
        #endregion

        #region 其他方法
        private Task Log(LogMessage Message)
        {
            Class.Tools.File File = new Tools.File();
            File.WriteStringInFile(Message.ToString());
            return Task.CompletedTask;
        }
        #endregion
    }

    
}
