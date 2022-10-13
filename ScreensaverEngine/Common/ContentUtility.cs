using Microsoft.Xna.Framework.Graphics;
using System.IO;
using System.Reflection;

namespace ScreensaverEngine
{
    public static class ContentUtility
    {
        /// <summary>
        /// Loads a Texture2D from the Content directory embedded within the specified assembly. 
        /// This assumes the content directory is "{<see cref="Assembly.GetName().Name"/>}.Content". 
        /// </summary>
        /// <returns></returns>
        public static Texture2D LoadTexture2DFromManifest(Assembly currentAssembly, GraphicsDevice graphicsDevice, string fileName)
        {
            using var stream = currentAssembly.GetManifestResourceStream($"{GetManifestContentDirectory(currentAssembly)}.{fileName}");

            if (stream == null)
            {
                throw new FileNotFoundException($"File {fileName} is missing!");
            }

            return Texture2D.FromStream(graphicsDevice, stream);
        }

        public static string GetManifestContentDirectory(Assembly currentAssembly)
        {
            return $"{currentAssembly.GetName().Name}.Content";
        }
    }
}
