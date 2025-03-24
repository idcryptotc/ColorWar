using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ColorWar;

internal class Game
{
    private readonly FieldModel gameField;
    private readonly PictureBox fieldControl;
    private readonly Dictionary<Who, List<PictureBox>> buttons;

    public Game(PictureBox fieldControl, Dictionary<Who, List<PictureBox>> buttons)
    {
        gameField = new(52, 35);
        this.fieldControl = fieldControl;
        this.buttons = buttons;
        FillField();
    }

    public void FillField()
    {
        using Graphics g = Graphics.FromImage(fieldControl.Image);
        {
            for (var i = 0; i < gameField.Width; ++i)
            {
                for (var j = 0; j < gameField.Height; ++j)
                {
                    g.DrawImage(ResourceManager.colors[gameField[i, j].Color], i * 16, j * 16);
                }
            }

            fieldControl.Refresh();
        }
    }

    public void ChangeColor(PictureBox button)
    {
        (var who, var color) = GetParametersButton(button);

        switch (who)
        {
        case Who.First:
            {
                SetParametersButton(Who.First, Who.Second, button);
                break;
            }
        case Who.Second:
            {
                SetParametersButton(Who.Second, Who.First, button);
                break;
            }
        }

        gameField.UpdateGameField(who, color);
        FillField();
    }

    private void SetParametersButton(Who who1, Who who2, PictureBox button)
    {
        buttons[who1].ForEach(x =>
        {
            x.Image = new Bitmap(ResourceManager.colors[ColorCell.cross], new Size(40, 40));
            x.Tag = false;
        });

        var current = buttons[who2].First(x => x.Name == button.Name.Replace(who1.ToString(), who2.ToString()));
        current.Image = new Bitmap(ResourceManager.colors[ColorCell.cross], new Size(40, 40));
        current.Tag = false;

        foreach (var otherButton in buttons[who2].Except([current]))
        {
            otherButton.Image = new Bitmap(ResourceManager.colors[GetParametersButton(otherButton).color], new Size(40, 40));
            otherButton.Tag = true;
        }
    }

    private static (Who who, ColorCell color) GetParametersButton(PictureBox button)
        => button.Name switch
        {
            "ButtonFirstBlue" => (Who.First, ColorCell.blue),
            "ButtonFirstLime" => (Who.First, ColorCell.green),
            "ButtonFirstCyan" => (Who.First, ColorCell.cyan),
            "ButtonFirstRed" => (Who.First, ColorCell.red),
            "ButtonFirstFuchsia" => (Who.First, ColorCell.fuchsia),
            "ButtonSecondBlue" => (Who.Second, ColorCell.blue),
            "ButtonSecondLime" => (Who.Second, ColorCell.green),
            "ButtonSecondCyan" => (Who.Second, ColorCell.cyan),
            "ButtonSecondRed" => (Who.Second, ColorCell.red),
            "ButtonSecondFuchsia" => (Who.Second, ColorCell.fuchsia),
            _ => (Who.Neutral, ColorCell.neutral)
        };
}
