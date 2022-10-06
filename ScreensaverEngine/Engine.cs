using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ScreensaverEngine
{
    public class Engine : Game
    {
        #region Variables
        public Config config { get; private set; }

        public GameTime GameTime { get; private set; }

        public GraphicsDeviceManager Graphics { get; private set; }
        public Matrix ScreenMatrix { get; private set; }
        public Viewport Viewport { get; private set; }

        public int BaseWidth { get; private set; } = 1280;
        public int BaseHeight { get; private set; } = 720;
        public int ViewWidth { get; private set; }
        public int ViewHeight { get; private set; }

        public Color BackgroundColor { get; set; } = Color.Black;
        
        public SpriteBatch SpriteBatch { get; private set; }

        private Component[] components;

        public Texture2D Rectangle { get; private set; }
        #endregion Variables

        public Engine()
        {
            config = new Config();

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
            var assemblies = ReflectionUtility.LoadAssembliesInDirectory(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Screensavers"));

            foreach(var assembly in assemblies)
            {
                Debug.Log(assembly.FullName);

                if (assembly.FullName == config.assemblyToLoad)
                {
                    components = ReflectionUtility.GetInstancedTypesFromAssembly<Component>(assembly, true);
                    foreach(var component in components)
                    {
                        component.Engine = this;
                    }

                    break;
                }
            }

            if(components == null)
            {
                Debug.LogError("No screensaver set to use in config!");
                Environment.Exit(1);
            }
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