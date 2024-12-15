namespace SnakeGame;

class Food
{
    public Point Position { get; private set; }

    public void Spawn(Grid grid, List<Point> snakeBody)
    {
        Random random = new Random();
        Point newFoodPosition;

        do
        {
            newFoodPosition = new Point(random.Next(0, grid.Width), random.Next(0, grid.Height));
        } while (snakeBody.Contains(newFoodPosition));

        Position = newFoodPosition;
    }
}