using Microsoft.Xna.Framework.Graphics;
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
        public static Texture2D LoadTexture2DFromManifest(this Assembly currentAssembly, GraphicsDevice graphicsDevice, string fileName)
        {
            string contentDir = $"{currentAssembly.GetName().Name}.Content";

            return Texture2D.FromStream(graphicsDevice, currentAssembly.GetManifestResourceStream($"{contentDir}.{fileName}"));
        }
    }
}
