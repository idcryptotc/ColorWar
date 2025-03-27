using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ColorWar;

/// <summary>
/// Модель игрового поля.
/// </summary>
internal class FieldModel
{
    /// <summary>
    /// Очередь для смены цвета.
    /// </summary>
    public static Queue<ColorCell> ChangeColorCollection { get; set; } = [];

    /// <summary>
    /// Ширина игрового поля.
    /// </summary>
    public int Width { get; set; }

    /// <summary>
    /// Высота игрового поля.
    /// </summary>
    public int Height { get; set; }

    /// <summary>
    /// Текущая игра.
    /// </summary>
    public Game CurrentGame { get; }

    private int MinSpecial { get => Convert.ToInt32(CellCount * 0.005); }
    private int MaxSpecial { get => Convert.ToInt32(CellCount * 0.015); }
    private int CellCount { get; }

    private CellModel[,] GameField { get; set; }

    /// <summary>
    /// Конструктор игрового поля.
    /// </summary>
    /// <param name="width">Ширина.</param>
    /// <param name="height">Высота.</param>
    /// <param name="game">Текущая игра.</param>
    public FieldModel(int width, int height, Game game)
    {
        CurrentGame = game;
        Width = width;
        Height = height;
        CellCount = Width * Height;

        GameField = new CellModel[Width, Height];

        for (var i = 0; i < Width; ++i)
        {
            for (var j = 0; j < Height; ++j)
            {
                GameField[i, j] = new CellModel(CurrentGame)
                {
                    Color = LocalRandom.GetColor(),
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

        var special = LocalRandom.GetSpecialCount(MinSpecial, MaxSpecial);

        for (var i = 0; i < special; ++i)
        {
            GameField[LocalRandom.GetNumber(Width), LocalRandom.GetNumber(Height)]
                .Color = LocalRandom.GetColorSpecial();
        }

        GameField[0, Height - 1].Color = ColorCell.neutral;
        GameField[0, Height - 1].Who = Who.First;

        GameField[Width - 1, 0].Color = ColorCell.neutral;
        GameField[Width - 1, 0].Who = Who.Second;

        GameField[Width / 2, Height / 2].Color = ColorCell.flag;
    }

    /// <summary>
    /// Обновить игровое поле.
    /// </summary>
    /// <param name="player">Игрок.</param>
    /// <param name="color">Цвет.</param>
    public void UpdateGameField(Who player, ColorCell color)
    {
        CurrentGame.ActivePlayer.CurrentColor = color;
        List<CellModel> listCells = [];

        foreach (var cell in GameField)
        {
            if (cell.Who == player)
            {
                cell.Color = CellModel.ConvertColor(color);
                listCells.Add(cell);
            }
        }

        var newCells = listCells.SelectMany(x =>
            new List<CellModel> { x.Top, x.Right, x.Bottom, x.Left }
                .Where(x =>
                    x is not null
                    && x.CheckCell(color)
                    && x.Who == Who.Neutral))
            .Distinct();

        foreach (var cell in newCells)
        {
            cell.ChangeCell(player, color);
        }

        while (ChangeColorCollection.Count > 0)
        {
            var newColor = ChangeColorCollection.Dequeue();
            MessageBox.Show($"Новый цвет: {newColor}");
            CurrentGame.ActivePlayer.CurrentColor = newColor;
            CurrentGame.ChangeColor(player, newColor);
        }
    }

    /// <summary>
    /// Интексатор игрового поля.
    /// </summary>
    /// <param name="i">Индекс по ширине.</param>
    /// <param name="j">Индекс по высоте.</param>
    /// <returns>Ячейка.</returns>
    public CellModel this[int i, int j]
    {
        get { return GameField[i, j]; }
    }
}
