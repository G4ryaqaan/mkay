using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace SnakeGame;

class Program
{
    static void Main(string[] args)
    {
        GameManager gameManager = new GameManager();
        gameManager.StartGame();
    }
}
