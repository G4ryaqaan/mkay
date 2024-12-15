namespace SnakeGame;

class Snake
{
    public List<Point> Body { get; private set; }
    public Point Head => Body.First();

    public Snake(Point startPosition)
    {
        this.Body = new List<Point> { startPosition };
    }

    public void Move(Direction direction)
    {
        Point newHead = direction switch
        {
            Direction.Up => new Point(Head.X, Head.Y - 1),
            Direction.Down => new Point(Head.X, Head.Y + 1),
            Direction.Left => new Point(Head.X - 1, Head.Y),
            Direction.Right => new Point(Head.X + 1, Head.Y),
            _ => Head
        };

        Body.Insert(0, newHead);
        Body.RemoveAt(Body.Count - 1);
    }

    public void Grow()
    {
        Body.Add(Body.Last());
    }

    public bool CheckSelfCollision()
    {
        return Body.Skip(1).Any(segment => segment.Equals(Head));
    }
}