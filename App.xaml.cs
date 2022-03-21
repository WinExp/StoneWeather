using AutoUpdaterDotNET;
using StoneWeather.Class.Tools;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace StoneWeather
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            this.Startup += delegate
            {
                AutoUpdater.DownloadPath = AppDomain.CurrentDomain.BaseDirectory + "Stone Weather\\UpdateFiles";
                AutoUpdater.UpdateMode = Mode.Forced;
                AutoUpdater.Start("https://we-bucket.oss-cn-shenzhen.aliyuncs.com/App/Stone%20Weather/Update/UpdateInfo.xml");
                File file = new File();
                file.WriteStringInFile("", false);
                try
                {
                    ConfigLoad con = new ConfigLoad("Stone Weather\\Config.ini");
                    string Lang = con.GetStringValue("GlobalLang");
                    if (Lang == null)
                    {
                        ConfigSet cs = new ConfigSet("Stone Weather\\Config.ini", true);
                        cs.SetConfigValue("GlobalLang", "zh_CN");
                        cs.WriteConfigToFile(ConfigFile.newFile);
                    }
                    switch (Lang)
                    {
                        case "zh_CN":
                            StoneWeather.Resources.Language.Lang.GlobalLanguage = StoneWeather.Resources.Language.Lang.zh_CN;
                            break;
                        case "en_US":
                            StoneWeather.Resources.Language.Lang.GlobalLanguage = StoneWeather.Resources.Language.Lang.en_US;
                            break;
                        default:
                            break;
                    }
                    file = new File("Stone Weather\\Config.ini");
                    List<string> Result = file.ReadFileString();
                    foreach (string ResultItem in Result)
                    {
                        string Author = ResultItem.Split('=')[0];
                        string Language = ResultItem.Split('=')[1];
                        switch (Language)
                        {
                            case "zh_CN":
                                StoneWeather.Resources.Language.Lang.Language[Author] = StoneWeather.Resources.Language.Lang.zh_CN;
                                break;
                            case "en_US":
                                StoneWeather.Resources.Language.Lang.Language[Author] = StoneWeather.Resources.Language.Lang.en_US;
                                break;
                            default:
                                break;
                        }
                    }
                }
                catch { }
            };
        }
    }
}
