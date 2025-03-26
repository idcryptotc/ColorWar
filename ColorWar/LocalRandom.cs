using System;

namespace ColorWar;

/// <summary>
/// Местный рандом.
/// </summary>
internal static class LocalRandom
{
    private static readonly Random random = new();

    /// <summary>
    /// Получить случайный цвет.
    /// </summary>
    /// <returns>Цвет.</returns>
    public static ColorCell GetColor()
    {
        return (ColorCell)random.Next(0, 5);
    }

    /// <summary>
    /// Получить случайный цвет ячейки с бонусом.
    /// </summary>
    /// <returns>Цвет.</returns>
    public static ColorCell GetColorSpecial()
    {
        return (ColorCell)random.Next(5, 8);
    }

    /// <summary>
    /// Получить случайный цвет.
    /// </summary>
    /// <param name="exceptcolor">Исключаемый цвет.</param>
    /// <returns>Цвет.</returns>
    public static ColorCell GetColorWithout(ColorCell exceptcolor)
    {
        ColorCell newColor;

        do
        {
            newColor = GetColor();
        }
        while (exceptcolor == newColor);

        return newColor;
    }

    /// <summary>
    /// Получить количество бонусов на игру.
    /// </summary>
    /// <param name="min">Минимальное количество.</param>
    /// <param name="max">Максимальное количество.</param>
    /// <returns>Количество.</returns>
    public static int GetSpecialCount(int min, int max)
    {
        return random.Next(min, max);
    }

    /// <summary>
    /// Получить случайное число от 0 до заданного.
    /// </summary>
    /// <param name="max">Заданное число.</param>
    /// <returns>Число.</returns>
    public static int GetNumber(int max)
    {
        return random.Next(max);
    }
}
