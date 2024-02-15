using System.CodeDom.Compiler;

namespace Maze;

public class Board
{
    private const int acsiiIndexA = 'A';
    private static readonly char[] Header = new char[] {'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H'};
    private readonly int _width ;
    private readonly int _height ;
    public int SelectedColumn = 0;
    
    public int XPlayer = 0;
    public int YPlayer = 0;

    public readonly Sprite[,] Grid;
    
    public Board(int width, int height)
    {
        _width = width;
        _height = height;
        Grid = new Sprite[_height, _width];
        
        for (int i = 0; i < _height; i++)
        {
            for (int j = 0; j < _width; j++)
            {
                Grid[i, j] = Sprite.GetRandomSprite();
            }
        }
        Display();
        Task.Delay(100).Wait();
        SelectHeader();
    }
    public void Display()
    {
        Console.Clear();

        SelectHeader();
        Console.WriteLine();
        
        for (int i = 0; i < _height; i++)
        {
            Console.Write(i+1);
            for (int j = 0; j < _width; j++)
            {
                if (i == XPlayer && j == YPlayer)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                Console.Write(Grid[i, j].Character);
                Console.ResetColor();
            }

            Console.WriteLine();
        }
    }

    public void SelectHeader()
    {
        Console.SetCursorPosition(0, 0);
        Console.Write(' ');
        for (int i = 0; i < _width; i++)
        {
            if (i == SelectedColumn)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            Console.Write((char)(acsiiIndexA + i));
            
            Console.ResetColor();
        }
    }
    
    public void MoveUp()
    {
        var temp = Grid[0, SelectedColumn];
        for (int i = 0; i < _height-1; i++)
        {
            Grid[i, SelectedColumn] = Grid[i+1, SelectedColumn];
        }
        Grid[_height-1, SelectedColumn] = temp;
        Display();
    }
    
    public void MoveDown()
    {
        var temp = Grid[_height-1, SelectedColumn];
        for (int i = _height-1; i > 0; i--)
        {
            Grid[i, SelectedColumn] = Grid[i-1, SelectedColumn];
        }
        Grid[0, SelectedColumn] = temp;
        Display();
    }
    
    public void MoveBoard(Direction direction)
    {
        switch (direction)
        {
            case Direction.Up:
                MoveUp();
                break;
            case Direction.Down:
                MoveDown();
                break;
        }
    }
    
    public void MovePlayer(Direction direction)
    {
        if(Sprite.CanMove(Grid[XPlayer, YPlayer], GetNextSprite(direction), direction))
        {
            switch (direction)
            {
                case Direction.PlayerUp:
                    XPlayer--;
                    break;
                case Direction.PlayerDown:
                    XPlayer++;
                    break;
                case Direction.PlayerLeft:
                    YPlayer--;
                    break;
                case Direction.PlayerRight:
                    YPlayer++;
                    break;
            }
            
            if(XPlayer == 7 && YPlayer == 7)
            {
                DisplayWin();
                Environment.Exit(0);
            }
        }
        else
        {
            Console.Beep();
        }
        Display();
    }
    
    
    
    public Sprite GetNextSprite(Direction direction)
    {
        switch (direction)
        {
            case Direction.PlayerUp:
                return Grid[XPlayer-1, YPlayer];
            case Direction.PlayerDown:
                return Grid[XPlayer+1, YPlayer];
            case Direction.PlayerLeft:
                return Grid[XPlayer, YPlayer-1];
            case Direction.PlayerRight:
                default:
                return Grid[XPlayer, YPlayer+1];
        }
    }
    
    
    public void DisplayWin()
    {
        Console.Clear();
        Console.WriteLine("You win!");
    }
}