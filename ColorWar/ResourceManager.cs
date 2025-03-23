using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ColorWar;

internal static class ResourceManager
{
    internal static readonly Dictionary<string, Bitmap> colors = [];

    static ResourceManager()
    {
        GetImagesFromResources();
    }

    internal static void SetDefaultBackground(PictureBox fieldControl)
    {
        var background = new Bitmap(new MemoryStream(Properties.Resources.Background));
        fieldControl.Image = background;
    }

    internal static void GetImagesFromResources()
    {
        using var bmpFull = new Bitmap(new MemoryStream(Properties.Resources.Colors));
        {
            AddBmp(new Rectangle(0, 0, 16, 16), "blue", bmpFull);
            AddBmp(new Rectangle(16, 0, 16, 16), "green", bmpFull);
            AddBmp(new Rectangle(32, 0, 16, 16), "cyan", bmpFull);
            AddBmp(new Rectangle(48, 0, 16, 16), "red", bmpFull);
            AddBmp(new Rectangle(64, 0, 16, 16), "fuchsia", bmpFull);
            AddBmp(new Rectangle(0, 16, 16, 16), "blueset", bmpFull);
            AddBmp(new Rectangle(16, 16, 16, 16), "greenset", bmpFull);
            AddBmp(new Rectangle(32, 16, 16, 16), "cyanset", bmpFull);
            AddBmp(new Rectangle(48, 16, 16, 16), "redset", bmpFull);
            AddBmp(new Rectangle(64, 16, 16, 16), "fuchsiaset", bmpFull);
            AddBmp(new Rectangle(0, 32, 16, 16), "neutral", bmpFull);
            AddBmp(new Rectangle(16, 32, 16, 16), "cross", bmpFull);
            AddBmp(new Rectangle(32, 32, 16, 16), "multi", bmpFull);
            AddBmp(new Rectangle(48, 32, 16, 16), "flag", bmpFull);
        }
    }

    internal static void AddBmp(Rectangle rt, string name, Bitmap bmpFull)
    {
        var miniBmp = new Bitmap(16, 16);
        using var g1 = Graphics.FromImage(miniBmp);
        g1.DrawImage(bmpFull, 0, 0, rt, GraphicsUnit.Pixel);
        colors.Add(name, miniBmp);
    }
}
