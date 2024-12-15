namespace SnakeGame;

class Grid
{
    public int Width { get; }
    public int Height { get; }

    public Grid(int width, int height)
    {
        Width = width;
        Height = height;
    }

    public bool IsOutOfBounds(Point position)
    {
        return position.X < 0 || position.X >= Width || position.Y < 0 || position.Y >= Height;
    }
}
