namespace SnakeGame;

class GameManager
{
    private Snake Snake;
    private Food Food;
    private Grid Grid;
    private Renderer Renderer;
    private Direction CurrentDirection;
    private bool IsGameOver;

    private const int GridWidth = 15;
    private const int GridHeight = 15;
    private const int GameSpeed = 300;

    public void StartGame()
    {
        Initialize();
        GameLoop();
    }

    private void Initialize()
    {
        Grid = new Grid(GridWidth, GridHeight);
        Snake = new Snake(new Point(GridWidth / 2, GridHeight / 2));
        Food = new Food();
        Renderer = new Renderer();
        CurrentDirection = Direction.Right;
        Food.Spawn(Grid, Snake.Body);
        IsGameOver = false;
    }

    private void GameLoop()
    {
        while (!IsGameOver)
        {
            ProcessInput();
            UpdateGame();
            Renderer.Render(Grid, Snake, Food);
            Thread.Sleep(GameSpeed); 
        }

        Console.Clear();
        Console.WriteLine("Game Over! Your score: " + (Snake.Body.Count - 1));
    }

    private void ProcessInput()
    {
        if (Console.KeyAvailable)
        {
            ConsoleKey key = Console.ReadKey(true).Key;
            CurrentDirection = key switch
            {
                ConsoleKey.W when CurrentDirection != Direction.Down => Direction.Up,
                ConsoleKey.S when CurrentDirection != Direction.Up => Direction.Down,
                ConsoleKey.A when CurrentDirection != Direction.Right => Direction.Left,
                ConsoleKey.D when CurrentDirection != Direction.Left => Direction.Right,
                _ => CurrentDirection
            };
        }
    }

    private void UpdateGame()
    {
        Snake.Move(CurrentDirection);

        if (Grid.IsOutOfBounds(Snake.Head) || Snake.CheckSelfCollision())
        {
            IsGameOver = true;
            return;
        }

        if (Snake.Head.Equals(Food.Position))
        {
            Snake.Grow();
            Food.Spawn(Grid, Snake.Body);
        }
    }
}