namespace SnakeGame;

class Renderer
{
    public void Render(Grid grid, Snake snake, Food food)
    {
        Console.SetCursorPosition(0, 0);

        for (int y = 0; y < grid.Height; y++)
        {
            for (int x = 0; x < grid.Width; x++)
            {
                Point currentPoint = new Point(x, y);

                if (snake.Head.Equals(currentPoint))
                    Console.Write("H");
                else if (snake.Body.Contains(currentPoint))
                    Console.Write("T");
                else if (food.Position.Equals(currentPoint))
                    Console.Write("O");
                else
                    Console.Write(".");
            }

            Console.WriteLine();
        }
    }
}