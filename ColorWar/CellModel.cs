using System;
using System.Windows.Forms;

namespace ColorWar;

internal class CellModel
{
    public ColorCell Color { get; set; }
    public int X { get; set; }
    public int Y { get; set; }
    public Who Who { get; set; }

    public CellModel Top { get; set; }
    public CellModel Right { get; set; }
    public CellModel Bottom { get; set; }
    public CellModel Left { get; set; }

    public void ChangeCell(Who player, ColorCell color, bool forBlack = false)
    {
        if (forBlack)
        {
            Color = ColorCell.black;
        }
        else
        {
            if (Color == ColorCell.flag)
            {
                MessageBox.Show("Ты захватил центр!");
            }
            else if (Color == ColorCell.multi)
            {
                var r = new Random();
                FieldModel.ChangeColorCollection.Enqueue((ColorCell)r.Next(0, 5));
            }

            if (Color == ColorCell.cross)
            {
                MessageBox.Show("БА-БАХ!");
                Color = ColorCell.black;
                var r = new Random();
                color = (ColorCell)r.Next(0, 5);
                forBlack = true;
            }
            else
            {
                Color = ConvertColor(color);
                Who = player;
            }
        }

        if (Top.CheckCell(color, forBlack))
        {
            Top.ChangeCell(player, color, forBlack);
        }

        if (Right.CheckCell(color, forBlack))
        {
            Right.ChangeCell(player, color, forBlack);
        }

        if (Bottom.CheckCell(color, forBlack))
        {
            Bottom.ChangeCell(player, color, forBlack);
        }

        if (Left.CheckCell(color, forBlack))
        {
            Left.ChangeCell(player, color, forBlack);
        }
    }

    public static ColorCell ConvertColor(ColorCell colorCell)
        => colorCell switch
        {
            ColorCell.blue => ColorCell.blueset,
            ColorCell.green => ColorCell.greenset,
            ColorCell.cyan => ColorCell.cyanset,
            ColorCell.red => ColorCell.redset,
            ColorCell.fuchsia => ColorCell.fuchsiaset,
            _ => ColorCell.neutral
        };
}
