using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ColorWar;

/// <summary>
/// Форма.
/// </summary>
public partial class MainForm : Form
{
    private readonly Game Game;
    private readonly Player PlayerFirst;
    private readonly Player PlayerSecond;

    /// <summary>
    /// Конструктор формы.
    /// </summary>
    public MainForm()
    {
        Icon = new Icon(new MemoryStream(Properties.Resources.ColorWar));
        InitializeComponent();
        ResourceManager.SetDefaultBackground(Field);

        Dictionary<Who, List<PictureBox>> buttons = new()
        {
            [Who.First] = [ButtonFirstBlue, ButtonFirstLime, ButtonFirstCyan, ButtonFirstRed, ButtonFirstFuchsia],
            [Who.Second] = [ButtonSecondBlue, ButtonSecondLime, ButtonSecondCyan, ButtonSecondRed, ButtonSecondFuchsia],
        };

        var coin = LocalRandom.GetNumber(2);
        PlayerFirst = new Player(Who.First, coin is 0);
        PlayerSecond = new Player(Who.Second, coin is 1);
        Game = new(Field, buttons, PlayerFirst, PlayerSecond);
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
            var score = Game.ActivePlayer.Score.ToString();

            switch (Game.ActivePlayer.Who)
            {
            case Who.First:
                ScoreFirstPlayer.Text = score;
                break;
            case Who.Second:
                ScoreSecondPlayer.Text = score;
                break;
            }

            Game.ChangePlayer();
        }
    }
}
