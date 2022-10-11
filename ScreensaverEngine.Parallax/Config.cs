using System.Numerics;

namespace ScreensaverEngine.Parallax
{
    public class Config
    {
        // TODO: Refine these speed values
        public readonly Layer[] mountainLayers = new Layer[]
        {
            new Layer("Mountains.bg.png", 0, true, customScale: new Vector2(1280, 720)),
            new Layer("Mountains.moon.png", 0, true, customScale: new Vector2(1280, 720)),
            new Layer("Mountains.clouds.png", 5, true, customScale: new Vector2(1280, 720)),
            new Layer("Mountains.mountain-far.png", -10, true, customScale : new Vector2(1280, 720)),
            new Layer("Mountains.mountain.png", -20, true, customScale : new Vector2(1280, 720)),
            new Layer("Mountains.trees-far.png", -80, true, customScale: new Vector2(1280, 720)),
            new Layer("Mountains.trees.png", -160, true, customScale: new Vector2(1280, 720))
        };

        // TODO
        public Layer[] GetUserSelectedLayers()
        {
            return mountainLayers;
        }
    }
}
