using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ColorWar;

public partial class MainForm : Form
{
    private readonly Game Game;
    public MainForm()
    {
        Icon = new Icon(new MemoryStream(Properties.Resources.ColorWar));
        InitializeComponent();
        ResourceManager.SetDefaultBackground(Field);

        Game = new(Field);

        ButtonFirstBlue.Image = new Bitmap(ResourceManager.colors["blue"], new Size(40, 40));
        ButtonFirstLime.Image = new Bitmap(ResourceManager.colors["green"], new Size(40, 40));
        ButtonFirstCyan.Image = new Bitmap(ResourceManager.colors["cyan"], new Size(40, 40));
        ButtonFirstRed.Image = new Bitmap(ResourceManager.colors["red"], new Size(40, 40));
        ButtonFirstFuchsia.Image = new Bitmap(ResourceManager.colors["fuchsia"], new Size(40, 40));
        ButtonSecondBlue.Image = new Bitmap(ResourceManager.colors["blue"], new Size(40, 40));
        ButtonSecondLime.Image = new Bitmap(ResourceManager.colors["green"], new Size(40, 40));
        ButtonSecondCyan.Image = new Bitmap(ResourceManager.colors["cyan"], new Size(40, 40));
        ButtonSecondRed.Image = new Bitmap(ResourceManager.colors["red"], new Size(40, 40));
        ButtonSecondFuchsia.Image = new Bitmap(ResourceManager.colors["fuchsia"], new Size(40, 40));
    }

    private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
    {
        Field.Image.Dispose();
    }

    private void Button_Click(object sender, EventArgs e)
    {
        Game.ChangeColor(sender as PictureBox);
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
