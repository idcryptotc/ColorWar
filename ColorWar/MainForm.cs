using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ColorWar;

public partial class MainForm : Form
{
    private readonly Dictionary<string, Bitmap> colors = [];
    private readonly FieldModel gameField = new(52, 35);

    public MainForm()
    {
        Icon = new Icon(new MemoryStream(Properties.Resources.ColorWar));
        InitializeComponent();
    }

    private void MainForm_Load(object sender, EventArgs e)
    {
        SetDefaultBackground();
        GetImagesFromResources();
        FillField();
    }

    private void FillField()
    {
        using Graphics g = Graphics.FromImage(Field.Image);
        {
            for (var i = 0; i < gameField.Width; ++i)
            {
                for (var j = 0; j < gameField.Height; ++j)
                {
                    g.DrawImage(colors[gameField[i, j].Color.ToString()], i * 16, j * 16);
                }
            }

            Field.Refresh();
        }
    }

    private void SetDefaultBackground()
    {
        var background = new Bitmap(new MemoryStream(Properties.Resources.Background));
        Field.Image = background;
    }

    private void GetImagesFromResources()
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

    private void AddBmp(Rectangle rt, string name, Bitmap bmpFull)
    {
        var miniBmp = new Bitmap(16, 16);
        using var g1 = Graphics.FromImage(miniBmp);
        g1.DrawImage(bmpFull, 0, 0, rt, GraphicsUnit.Pixel);
        colors.Add(name, miniBmp);
    }

    private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
    {
        Field.Image.Dispose();
    }

    private void Button_Focus(object sender, EventArgs e)
    {
        Focus();
    }

    private void Button_Focus(object sender, MouseEventArgs e)
    {
        Focus();
    }
}

public enum ColorCell : int
{
    blue,
    green,
    cyan,
    red,
    fuchsia,
    neutral,
    multi,
    cross,
    flag
}
