namespace SnakeGame;

class Point
{
    public int X { get; }
    public int Y { get; }

    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }

    public override bool Equals(object obj)
    {
        return obj is Point other && X == other.X && Y == other.Y;
    }
}