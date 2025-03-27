namespace ColorWar;

/// <summary>
/// Цвета.
/// </summary>
public enum ColorCell : int
{
    blue,
    green,
    cyan,
    red,
    fuchsia,
    neutral,
    multi,
    cross,
    flag,
    blueset,
    greenset,
    cyanset,
    redset,
    fuchsiaset,
    black,
}

/// <summary>
/// Кому принадлежит.
/// </summary>
public enum Who
{
    Neutral,
    First,
    Second,
    Computer,
}

public enum ColorCost : int
{
    Blue,
    Green,
    Cyan,
    Red,
    Fuchsia,
    Flag,
}