using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace ScreensaverEngine.Parallax
{
    public class ParallaxController : Component
    {
        private RuntimeLayer[] layers;
        private Assembly currentAssembly;
        private Config config;

        public override void Initialize()
        {
            currentAssembly = Assembly.GetExecutingAssembly();
            config = new Config();
        }

        public override void LoadContent(GraphicsDevice graphicsDevice)
        {
            List<RuntimeLayer> layers = new List<RuntimeLayer>();

            var selectedLayers = config.GetUserSelectedLayers();

            foreach (Layer layer in selectedLayers)
            {
                Texture2D texture;

                if (layer.isEmbedded)
                {
                    texture = ContentUtility.LoadTexture2DFromManifest(currentAssembly, graphicsDevice, layer.filePath);
                }
                else
                {
                    // TODO: Check if file is actually a bitmap and exists
                    texture = Texture2D.FromFile(graphicsDevice, layer.filePath);
                }

                layers.Add(new RuntimeLayer(layer, texture));
            }

            this.layers = layers.ToArray();
        }

        public override void Update(GameTime gameTime)
        {
            foreach (var layer in layers)
            {
                // Doing this bounding box thing so it loops and shows on screen correctly.
                var bounding = new Rectangle(1 - (int)layer.Scale.X, 
                    layer.Layer.yOffset, 
                    (int)layer.Scale.X, 
                    (int)layer.Scale.Y);

                layer.currentPosition.X += layer.Layer.speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                if (!bounding.Intersects(layer.BoundingBox))
                {
                    layer.currentPosition.X = layer.Layer.speed < 1 - layer.Scale.X ? layer.Scale.X - 1 : 1 - layer.Scale.X;
                }
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            foreach (var layer in layers)
            {
                int copies = (int)((Engine.BaseWidth - layer.currentPosition.X) / layer.Scale.X) + 1;

                //Debug.Log($"{layer.Layer.filePath}: {copies}");

                for (int i = 0; i < copies; i++)
                {
                    var boundingBox = layer.BoundingBox;
                    boundingBox.X += (int)(layer.Scale.X * i);
                    spriteBatch.Draw(layer.Texture, boundingBox, Color.White);
                }
            }
        }
    }
}