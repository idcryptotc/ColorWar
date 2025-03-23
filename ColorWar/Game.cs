using System.Drawing;
using System.Windows.Forms;

namespace ColorWar;

internal class Game
{
    private readonly FieldModel gameField;
    private readonly PictureBox fieldControl;

    public Game(PictureBox fieldControl)
    {
        gameField = new(52, 35);
        this.fieldControl = fieldControl;
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
                    var postfix = gameField[i, j].Who == Who.Neutral
                        || gameField[i, j].Color == ColorCell.neutral
                            ? "" : "set";
                    g.DrawImage(ResourceManager.colors[$"{gameField[i, j].Color}{postfix}"], i * 16, j * 16);
                }
            }

            fieldControl.Refresh();
        }
    }

    public void ChangeColor(PictureBox button)
    {
        (var who, var color) = button.Name switch
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

        gameField.UpdateGameField(who, color);
        FillField();
    }
}
