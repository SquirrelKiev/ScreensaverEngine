using Newtonsoft.Json;
using ScreensaverEngine.Config;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ScreensaverEngine
{
    public static class ConfigUtility
    {
        public static string BaseConfigPath
        {
            get
            {
                var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "ScreensaverEngine");
                Directory.CreateDirectory(path);

                return path;
            }
        }

        public static T LoadConfig<T>() where T : new()
        {
            string configPath = GetConfigPath<T>();

            T config;
            if (File.Exists(configPath))
            {
                config = JsonConvert.DeserializeObject<T>(File.ReadAllText(configPath));
            }
            else
            {
                config = new T();
            }

            return config;
        }

        public static void SaveConfig<T>(T value)
        {
            var json = JsonConvert.SerializeObject(value);

            File.WriteAllText(GetConfigPath<T>(), json);
        }

        public static string GetConfigPath<T>()
        {
            var assembly = typeof(T).Assembly;

            string basePath;
            if (assembly == Assembly.GetExecutingAssembly())
            {
                basePath = BaseConfigPath;
            }
            else
            {
                basePath = Path.Combine(BaseConfigPath, "Screensavers");
            }

            Directory.CreateDirectory(basePath);

            string path = Path.Combine(basePath, $"{assembly.GetName().Name}.json");

            return path;
        }
    }
}
