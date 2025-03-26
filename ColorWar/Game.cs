using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ColorWar;

/// <summary>
/// Текущая игра.
/// </summary>
internal class Game
{
    private readonly FieldModel gameField;
    private readonly PictureBox fieldControl;
    private readonly Dictionary<Who, List<PictureBox>> buttons;

    /// <summary>
    /// Конструктор текущей игры.
    /// </summary>
    /// <param name="fieldControl">Элемент для отрисовки поля.</param>
    /// <param name="buttons">Кнопки управления.</param>
    public Game(PictureBox fieldControl, Dictionary<Who, List<PictureBox>> buttons)
    {
        gameField = new(52, 35, this);
        this.fieldControl = fieldControl;
        this.buttons = buttons;
        FillField();
    }

    /// <summary>
    /// Заполнить поле.
    /// </summary>
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

    /// <summary>
    /// Изменить цвет.
    /// </summary>
    /// <param name="button">Кнопка.</param>
    public void ChangeColor(PictureBox button)
    {
        (var player, var color) = GetParametersButton(button);
        UpdateGame(player, color, button);
    }

    /// <summary>
    /// Изменить цвет.
    /// </summary>
    /// <param name="player">Игрок.</param>
    /// <param name="color">Цвет.</param>
    public void ChangeColor(Who player, ColorCell color)
    {
        var button = GetButtonByParameters(player, color);
        UpdateGame(player, color, button);
    }

    /// <summary>
    /// Получить цвет кнопки.
    /// </summary>
    /// <param name="player">Игрок.</param>
    /// <returns>Цвет кнопки.</returns>
    public ColorCell GetColor(Who player)
    {
        return GetParametersButton(buttons[player].First(x => x.Tag is false)).color;
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

    private void UpdateGame(Who who, ColorCell color, PictureBox button)
    {
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

    private PictureBox GetButtonByParameters(Who who, ColorCell color)
    {
        var buttonName = (who, color) switch
        {
            (Who.First, ColorCell.blue) => "ButtonFirstBlue",
            (Who.First, ColorCell.green) => "ButtonFirstLime",
            (Who.First, ColorCell.cyan) => "ButtonFirstCyan",
            (Who.First, ColorCell.red) => "ButtonFirstRed",
            (Who.First, ColorCell.fuchsia) => "ButtonFirstFuchsia",
            (Who.Second, ColorCell.blue) => "ButtonSecondBlue",
            (Who.Second, ColorCell.green) => "ButtonSecondLime",
            (Who.Second, ColorCell.cyan) => "ButtonSecondCyan",
            (Who.Second, ColorCell.red) => "ButtonSecondRed",
            (Who.Second, ColorCell.fuchsia) => "ButtonSecondFuchsia",
            _ => null
        };

        return buttons.Values.SelectMany(x => x).First(x => x.Name == buttonName);
    }
}
