using System.Numerics;

namespace ScreensaverEngine.Parallax
{
    public class Config
    {
        // TODO: Refine these speed values
        public readonly Layer[] mountainLayers = new Layer[]
        {
            new Layer("parallax-mountain-bg.png", 0, true, customScale: new Vector2(1280, 720)),
            new Layer("parallax-mountain-montain-far.png", 10, true, customScale : new Vector2(1280, 720)),
            new Layer("parallax-mountain-mountains.png", 20, true, customScale : new Vector2(2560, 720)),
            new Layer("parallax-mountain-trees.png", 40, true, customScale: new Vector2(2560, 720)),
            new Layer("parallax-mountain-foreground-trees.png", 80, true, customScale: new Vector2(2560, 720))
        };

        // TODO
        public Layer[] GetUserSelectedLayers()
        {
            return mountainLayers;
        }
    }
}
