using System.Numerics;

namespace ScreensaverEngine.Parallax
{
    public class Config
    {
        // TODO: Refine these speed values
        public readonly Layer[] mountainLayers = {
            new("Mountains.bg.png", 0, true, customScale: new Vector2(1280, 720)),
            new("Mountains.moon.png", 0, true, customScale: new Vector2(1280, 720)),
            new("Mountains.clouds.png", 5, true, customScale: new Vector2(1280, 720)),
            new("Mountains.mountain-far.png", -10, true, customScale : new Vector2(1280, 720)),
            new("Mountains.mountain.png", -20, true, customScale : new Vector2(1280, 720)),
            new("Mountains.trees-far.png", -80, true, customScale: new Vector2(1280, 720)),
            new("Mountains.trees.png", -160, true, customScale: new Vector2(1280, 720))
        };

        // TODO: Make this functional
        public Layer[] GetUserSelectedLayers()
        {
            return mountainLayers;
        }
    }
}
