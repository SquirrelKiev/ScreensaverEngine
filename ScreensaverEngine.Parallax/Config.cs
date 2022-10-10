namespace ScreensaverEngine.Parallax
{
    public class Config
    {
        // TODO: Refine these speed values
        public readonly Layer[] mountainLayers = new Layer[]
        {
            new Layer("parallax-mountain-bg.png", 0, true),
            new Layer("parallax-mountain-montain-far.png", 100, true),
            new Layer("parallax-mountain-mountains.png", 100, true),
            new Layer("parallax-mountain-trees.png", 100, true),
            new Layer("parallax-mountain-foreground-trees.png", 100, true)
        };

        // TODO
        public Layer[] GetUserSelectedLayers()
        {
            return mountainLayers;
        }
    }
}
