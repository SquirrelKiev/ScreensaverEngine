using Newtonsoft.Json;
using System;
using System.IO;
using System.Reflection;

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
            var configPath = GetConfigPath<T>();

            var config = File.Exists(configPath) ? JsonConvert.DeserializeObject<T>(File.ReadAllText(configPath)) : new T();

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

            var basePath = assembly == Assembly.GetExecutingAssembly() ? BaseConfigPath : Path.Combine(BaseConfigPath, "Screensavers");

            Directory.CreateDirectory(basePath);

            string path = Path.Combine(basePath, $"{assembly.GetName().Name}.json");

            return path;
        }
    }
}
