using System.CodeDom.Compiler;

namespace Maze;

public class Board
{
    private static readonly char[] Header = new char[] {'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H'};
    public int Width = 8;
    public int Height = 8;
    public int SelectedColumn = 0;
    
    public int XPlayer = 0;
    public int YPlayer = 0;

    public Sprite[,] Grid = new Sprite[8, 8];


    public Board()
    {
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                Grid[i, j] = Sprite.GetRandomSprite();
            }
        }
        Display();
        Task.Delay(100).Wait();
        SelectHeader();
        
        Console.Write(Grid[0, 1].Character);
    }
    public void Display()
    {
        Console.Clear();

        SelectHeader();
        Console.WriteLine();
        
        for (int i = 0; i < 8; i++)
        {
            Console.Write(i+1);
            for (int j = 0; j < 8; j++)
            {
                if (i == YPlayer && j == XPlayer)
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
        for (int i = 0; i < 8; i++)
        {
            if (i == SelectedColumn)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            Console.Write(Header[i]);
            
            Console.ResetColor();
        }
    }
    
    public void MoveUp()
    {
        var temp = Grid[0, SelectedColumn];
        for (int i = 0; i < 7; i++)
        {
            Grid[i, SelectedColumn] = Grid[i+1, SelectedColumn];
        }
        Grid[7, SelectedColumn] = temp;
        Display();
    }
    
    public void MoveDown()
    {
        var temp = Grid[7, SelectedColumn];
        for (int i = 7; i > 0; i--)
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
                    YPlayer--;
                    break;
                case Direction.PlayerDown:
                    YPlayer++;
                    break;
                case Direction.PlayerLeft:
                    XPlayer--;
                    break;
                case Direction.PlayerRight:
                    XPlayer++;
                    break;
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
}