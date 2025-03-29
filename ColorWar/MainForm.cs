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
    private Game Game;
    private Player PlayerFirst;
    private Player PlayerSecond;
    private readonly Dictionary<Who, List<PictureBox>> buttons;

    /// <summary>
    /// Конструктор формы.
    /// </summary>
    public MainForm()
    {
        Icon = new Icon(new MemoryStream(Properties.Resources.ColorWar));
        InitializeComponent();
        ResourceManager.SetDefaultBackground(Field);

        buttons = new()
        {
            [Who.First] = [ButtonFirstBlue, ButtonFirstLime, ButtonFirstCyan, ButtonFirstRed, ButtonFirstFuchsia],
            [Who.Second] = [ButtonSecondBlue, ButtonSecondLime, ButtonSecondCyan, ButtonSecondRed, ButtonSecondFuchsia],
        };

        StartNewGame();
    }

    private void StartNewGame()
    {
        ScoreFirstPlayer.Text = "0";
        PercentFirstPlayer.Text = "0%";
        ScoreSecondPlayer.Text = "0";
        PercentSecondPlayer.Text = "0%";
        var coin = LocalRandom.GetNumber(2);
        PlayerFirst = new Player(Who.First, coin is 0);
        PlayerSecond = new Player(Who.Second, coin is 1);
        Game = new(Field, buttons, PlayerFirst, PlayerSecond);
        MessageBox.Show($"Игрок {Game.ActivePlayer.Who} ходит первым.");
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
            var percent = Game.GetPercentPlayerString();

            switch (Game.ActivePlayer.Who)
            {
            case Who.First:
                ScoreFirstPlayer.Text = score;
                PercentFirstPlayer.Text = percent;
                break;
            case Who.Second:
                ScoreSecondPlayer.Text = score;
                PercentSecondPlayer.Text = percent;
                break;
            }

            if (Game.ActivePlayer.Percent > 50.0f)
            {
                MessageBox.Show($"Игра окончена! Победил игрок {Game.GetWinner()}");
                StartNewGame();
            }
            else
            {
                Game.ChangePlayer();
            }
        }
    }
}
