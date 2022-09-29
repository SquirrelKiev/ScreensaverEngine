using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace ScreensaverEngine
{
    public class Engine : Game
    {
        public GraphicsDeviceManager Graphics { get; private set; }
        public Matrix ScreenMatrix { get; private set; }
        public Viewport Viewport { get; private set; }

        private SpriteBatch spriteBatch;

        public static int Width { get; private set; } = 1280;
        public static int Height { get; private set; } = 720;
        public int ViewWidth { get; private set; }
        public int ViewHeight { get; private set; }

        Texture2D rectangle;

        public Engine()
        {
            Graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

#if DEBUG
            Graphics.PreferredBackBufferWidth = 1280;
            Graphics.PreferredBackBufferHeight = 720;
#else
            Graphics.PreferredBackBufferWidth  = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            Graphics.PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
            Graphics.IsFullScreen = true;
#endif
        }

        protected override void Initialize()
        {
            base.Initialize();

            UpdateView();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            rectangle = new Texture2D(GraphicsDevice, 1, 1);
            rectangle.SetData(new Color[] { Color.White });
        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Viewport = Viewport;
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin(transformMatrix: ScreenMatrix);
            {
                
            }
            spriteBatch.End();

            base.Draw(gameTime);
        }

        private void UpdateView()
        {
            float screenWidth = GraphicsDevice.PresentationParameters.BackBufferWidth;
            float screenHeight = GraphicsDevice.PresentationParameters.BackBufferHeight;

            if (screenWidth / Width > screenHeight / Height)
            {
                ViewWidth = (int)(screenHeight / Height * Width);
                ViewHeight = (int)screenHeight;
            }
            else
            {
                ViewWidth = (int)screenWidth;
                ViewHeight = (int)(screenWidth / Width * Height);
            }

            // update screen matrix
            ScreenMatrix = Matrix.CreateScale(ViewWidth / (float)Width);

            // update viewport
            Viewport = new Viewport
            {
                X = (int)(screenWidth / 2 - ViewWidth / 2),
                Y = (int)(screenHeight / 2 - ViewHeight / 2),
                Width = ViewWidth,
                Height = ViewHeight,
                MinDepth = 0,
                MaxDepth = 1
            };
        }
    }
}