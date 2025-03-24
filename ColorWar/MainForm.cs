using System;
using System.Collections.Generic;
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

        ButtonFirstBlue.Image = new Bitmap(ResourceManager.colors[ColorCell.blue], new Size(40, 40));
        ButtonFirstBlue.Tag = true;
        ButtonFirstLime.Image = new Bitmap(ResourceManager.colors[ColorCell.green], new Size(40, 40));
        ButtonFirstLime.Tag = true;
        ButtonFirstCyan.Image = new Bitmap(ResourceManager.colors[ColorCell.cyan], new Size(40, 40));
        ButtonFirstCyan.Tag = true;
        ButtonFirstRed.Image = new Bitmap(ResourceManager.colors[ColorCell.red], new Size(40, 40));
        ButtonFirstRed.Tag = true;
        ButtonFirstFuchsia.Image = new Bitmap(ResourceManager.colors[ColorCell.fuchsia], new Size(40, 40));
        ButtonFirstFuchsia.Tag = true;
        ButtonSecondBlue.Image = new Bitmap(ResourceManager.colors[ColorCell.blue], new Size(40, 40));
        ButtonSecondBlue.Tag = true;
        ButtonSecondLime.Image = new Bitmap(ResourceManager.colors[ColorCell.green], new Size(40, 40));
        ButtonSecondLime.Tag = true;
        ButtonSecondCyan.Image = new Bitmap(ResourceManager.colors[ColorCell.cyan], new Size(40, 40));
        ButtonSecondCyan.Tag = true;
        ButtonSecondRed.Image = new Bitmap(ResourceManager.colors[ColorCell.red], new Size(40, 40));
        ButtonSecondRed.Tag = true;
        ButtonSecondFuchsia.Image = new Bitmap(ResourceManager.colors[ColorCell.fuchsia], new Size(40, 40));
        ButtonSecondFuchsia.Tag = true;

        Dictionary<Who, List<PictureBox>> buttons = new()
        {
            [Who.First] = [ButtonFirstBlue, ButtonFirstLime, ButtonFirstCyan, ButtonFirstRed, ButtonFirstFuchsia],
            [Who.Second] = [ButtonSecondBlue, ButtonSecondLime, ButtonSecondCyan, ButtonSecondRed, ButtonSecondFuchsia],
        };

        Game = new(Field, buttons);
    }

    private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
    {
        Field.Image.Dispose();
    }

    private void Button_Click(object sender, EventArgs e)
    {
        if (sender is PictureBox button
            && button.Tag is bool isEnabled
            && isEnabled)
        {
            Game.ChangeColor(button);
        }
    }
}
