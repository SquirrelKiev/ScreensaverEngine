using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Reflection;

namespace ScreensaverEngine
{
    public class Engine : Game
    {
        #region Variables
        public static Engine Instance { get; private set; }

        public static GameTime GameTime { get; private set; }

        public static GraphicsDeviceManager Graphics { get; private set; }
        public static Matrix ScreenMatrix { get; private set; }
        public static Viewport Viewport { get; private set; }

        public static int BaseWidth { get; private set; } = 1280;
        public static int BaseHeight { get; private set; } = 720;
        public static int ViewWidth { get; private set; }
        public static int ViewHeight { get; private set; }

        public static Color BackgroundColor { get; set; } = Color.Black;
        
        public static SpriteBatch SpriteBatch { get; private set; }

        private static Component[] components;

        public static Texture2D Rectangle { get; private set; }
        #endregion

        public Engine()
        {
            Instance = this;

            Graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

#if !DEBUG
            Graphics.PreferredBackBufferWidth = 1280;
            Graphics.PreferredBackBufferHeight = 720;
#else
            Graphics.PreferredBackBufferWidth  = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            Graphics.PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
            Graphics.IsFullScreen = true;
#endif
            // TODO: Dynamically load assembly
            var assembly = Assembly.GetExecutingAssembly();

            components = ReflectionUtility.GetInstancedTypesFromAssembly<Component>(assembly, true);
        }

        protected override void Initialize()
        {
            UpdateView();

            Debug.Log($"Base Width: {BaseWidth}, Base Height: {BaseHeight}");
            Debug.Log($"Window Width: {ViewWidth}, Window Height: {ViewHeight}");

            foreach (var component in components) component.Initialize();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            SpriteBatch = new SpriteBatch(GraphicsDevice);

            Rectangle = new Texture2D(GraphicsDevice, 1, 1);
            Rectangle.SetData(new Color[] { Color.White });

            foreach (var component in components) component.LoadContent(GraphicsDevice);
        }

        protected override void Update(GameTime gameTime)
        {
            GameTime = gameTime;

            foreach (var component in components) component.PreUpdate(gameTime);

            foreach (var component in components) component.Update(gameTime);

            base.Update(gameTime);

            foreach (var component in components) component.PostUpdate(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GameTime = gameTime;

            foreach (var component in components) component.PreDraw();

            base.Draw(gameTime);

            GraphicsDevice.Viewport = Viewport;

            GraphicsDevice.Clear(BackgroundColor);

            SpriteBatch.Begin(transformMatrix: ScreenMatrix);
            {
                foreach (var component in components) component.Draw(SpriteBatch);
            }
            SpriteBatch.End();

            foreach (var component in components) component.PostDraw();
        }

        private void UpdateView()
        {
            float screenWidth = GraphicsDevice.PresentationParameters.BackBufferWidth;
            float screenHeight = GraphicsDevice.PresentationParameters.BackBufferHeight;

            if (screenWidth / BaseWidth > screenHeight / BaseHeight)
            {
                ViewWidth = (int)(screenHeight / BaseHeight * BaseWidth);
                ViewHeight = (int)screenHeight;
            }
            else
            {
                ViewWidth = (int)screenWidth;
                ViewHeight = (int)(screenWidth / BaseWidth * BaseHeight);
            }

            // update screen matrix
            ScreenMatrix = Matrix.CreateScale(ViewWidth / (float)BaseWidth);

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