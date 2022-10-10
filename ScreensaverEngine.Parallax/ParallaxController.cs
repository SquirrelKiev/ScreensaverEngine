using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace ScreensaverEngine.Parallax
{
    public class ParallaxController : Component
    {
        private Texture2D[] layers;
        private Assembly currentAssembly;
        private Config config;
        private Layer[] selectedLayers;

        public override void Initialize()
        {
            currentAssembly = Assembly.GetExecutingAssembly();
            config = new Config();

            selectedLayers = config.GetUserSelectedLayers();
        }

        public override void LoadContent(GraphicsDevice graphicsDevice)
        {
            List<Texture2D> layers = new List<Texture2D>();

            foreach(Layer layer in selectedLayers)
            {
                if (layer.isEmbedded)
                {
                    layers.Add(ContentUtility.LoadTexture2DFromManifest(currentAssembly, graphicsDevice, layer.filePath));
                }
                else
                {
                    // TODO: Check if file is actually a bitmap
                    if (File.Exists(layer.filePath))
                    {
                        layers.Add(Texture2D.FromFile(graphicsDevice, layer.filePath));
                    }
                }
            }

            this.layers = layers.ToArray();
        }

        public override void Update(GameTime gameTime)
        {
            
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            
        }
    }
}