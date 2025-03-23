using System;
using System.Collections.Generic;
using System.Linq;

namespace ColorWar;

internal class FieldModel
{
    public int Width { get; set; }
    public int Height { get; set; }
    private int MinSpecial { get => Convert.ToInt32(CellCount * 0.005); }
    private int MaxSpecial { get => Convert.ToInt32(CellCount * 0.015); }
    private int CellCount { get; }

    private CellModel[,] GameField { get; set; }

    public FieldModel(int width, int height)
    {
        Width = width;
        Height = height;
        CellCount = Width * Height;

        GameField = new CellModel[Width, Height];
        var r = new Random();

        for (var i = 0; i < Width; ++i)
        {
            for (var j = 0; j < Height; ++j)
            {
                GameField[i, j] = new CellModel
                {
                    Color = (ColorCell)r.Next(0, 5),
                    X = i,
                    Y = j,
                    Who = Who.Neutral
                };
            }
        }

        for (var i = 0; i < Width; ++i)
        {
            for (var j = 0; j < Height; ++j)
            {
                GameField[i, j].Top = j > 0 ? GameField[i, j - 1] : null;
                GameField[i, j].Right = i < Width - 1 ? GameField[i + 1, j] : null;
                GameField[i, j].Bottom = j < Height - 1 ? GameField[i, j + 1] : null;
                GameField[i, j].Left = i > 0 ? GameField[i - 1, j] : null;
            }
        }

        var special = r.Next(MinSpecial, MaxSpecial);

        for (var i = 0; i < special; ++i)
        {
            GameField[r.Next(Width), r.Next(Height)].Color = (ColorCell)r.Next(5, 8);
        }

        GameField[0, Height - 1].Color = ColorCell.neutral;
        GameField[0, Height - 1].Who = Who.First;

        GameField[Width - 1, 0].Color = ColorCell.neutral;
        GameField[Width - 1, 0].Who = Who.Second;

        GameField[Width / 2, Height / 2].Color = ColorCell.flag;
    }

    public void UpdateGameField(Who player, ColorCell color)
    {
        List<CellModel> listCells = [];

        foreach (var cell in GameField)
        {
            if (cell.Who == player)
            {
                cell.Color = color;
                listCells.Add(cell);
            }
        }

        var newCells = listCells.SelectMany(x =>
            new List<CellModel> { x.Top, x.Right, x.Bottom, x.Left }
                .Where(x => x is not null && x.Color == color))
            .Distinct();

        foreach (var cell in newCells)
        {
            cell.Color = color;
            cell.Who = player;
        }
    }

    public CellModel this[int i, int j]
    {
        get { return GameField[i, j]; }
    }
}
