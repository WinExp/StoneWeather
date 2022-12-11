using Panuon.UI.Silver;
using StoneWeather.Class.Discords;
using StoneWeather.Class.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace StoneWeather
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : WindowX
    {
        #region 声明字段
        private DiscordBot Bot = new DiscordBot();
        #endregion

        #region 核心方法
        public MainWindow()
        {
            InitializeComponent();
            try
            {
                ConfigLoad con = new ConfigLoad("Stone Weather\\Config.ini");
                string Base64Data = con.GetStringValue("BotToken");
                byte[] FromBase64Data = Convert.FromBase64String(Base64Data);
                string DecryptedData = null;
                using (Class.Crypto.AES AES = new Class.Crypto.AES())
                {
                    string ID = Class.Tools.Device.ID.GetIdentificationCode();
                    DecryptedData = Encoding.UTF8.GetString(AES.Decrypt(FromBase64Data, ID));
                }
                this.BotTokenPasswordBox.Password = DecryptedData;
            }
            catch { }
            this.Closed += delegate
            {
                StopBot("Close", new RoutedEventArgs());
            };
        }
        #endregion

        #region UI 元素方法
        internal async void StartBot(object sender, RoutedEventArgs e)
        {
            this.StartBotButton.IsEnabled = false;
            ButtonHelper.SetIsPending(this.StartBotButton, true);
            Task.Run(async () =>
            {
                await Bot.Connect(this.BotTokenPasswordBox.Password);
                Bot.Client.Ready += delegate
                {
                    this.Dispatcher.BeginInvoke(() =>
                    {
                        ButtonHelper.SetIsPending(this.StartBotButton, false);
                        this.StopBotButton.IsEnabled = true;
                    });
                    return Task.CompletedTask;
                };
            });
        }

        internal async void StopBot(object sender, RoutedEventArgs e)
        {
            this.StopBotButton.IsEnabled = false;
            ButtonHelper.SetIsPending(this.StopBotButton, true);
            Task.Run(async () =>
            {
                await Bot.Disconnect();
                this.Dispatcher.BeginInvoke(() =>
                {
                    ButtonHelper.SetIsPending(this.StopBotButton, false);
                    this.StartBotButton.IsEnabled = true;
                });
            });
        }

        internal void SaveBotToken(object sender, RoutedEventArgs e)
        {
            this.SaveBotTokenButton.IsEnabled = false;
            ButtonHelper.SetIsPending(this.SaveBotTokenButton, true);
            ConfigSet cs = new ConfigSet("Stone Weather\\Config.ini", true);
            byte[] ByteData = Encoding.UTF8.GetBytes(this.BotTokenPasswordBox.Password);
            byte[] EncryptedData = null;
            using (Class.Crypto.AES AES = new Class.Crypto.AES())
            {
                string ID = Class.Tools.Device.ID.GetIdentificationCode();
                EncryptedData = AES.Encrypt(ByteData, ID);
            }
            cs.SetConfigValue("BotToken", Convert.ToBase64String(EncryptedData));
            cs.WriteConfigToFile(ConfigFile.newFile);
            ButtonHelper.SetIsPending(this.SaveBotTokenButton, false);
            this.SaveBotTokenButton.IsEnabled = true;
        }
        #endregion
    }
}
