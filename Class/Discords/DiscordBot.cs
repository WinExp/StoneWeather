using Discord;
using Discord.Commands;
using Discord.Net;
using Discord.Net.Rest;
using Discord.Rest;
using Discord.WebSocket;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace StoneWeather.Class.Discords
{
    internal class DiscordBot
    {
        #region 声明字段
        internal DiscordSocketClient Client;
        internal CommandService Commands;
        private readonly IServiceProvider Services;
        #endregion

        #region 核心方法
        internal DiscordBot(bool useProxy = true)
        {
            var config = new DiscordSocketConfig
            {
                RestClientProvider = DefaultRestClientProvider.Create(useProxy)
            };
            this.Client = new DiscordSocketClient(config);
            this.Commands = new CommandService();
            this.Client.Log += Log;
            CommandHandler handler = new CommandHandler(this.Client, this.Commands, this.Services);
            this.Client.Ready += handler.InstallCommandsAsync;
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
