using System.CodeDom.Compiler;

namespace Maze;

public class Board
{
    public char[] spriteChars =  new char[] { '╣', '║', '╗', '╝', '╚', '╔', '╩', '╦', '╠', '═', '╬' };
    public int width = 8;
    public int height = 8;

    public char[,] grid = new char[8, 8];


    public Board()
    {
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                grid[i, j] = GenerateRandomSprite();
            }
        }
        Display();
    }
    
    public  char GenerateRandomSprite()
    {
        var random = new Random();
        var index = random.Next(0, spriteChars.Length-1);
        return spriteChars[index];
    }
    public void Display()
    {
        Console.Clear();
        Console.Write(" A");
        Console.Write('B');
        Console.Write('C');
        Console.Write('D');
        Console.Write('E');
        Console.Write('F');
        Console.Write('G');
        Console.Write('H');
        Console.WriteLine();
        
        for (int i = 0; i < 8; i++)
        {
            Console.Write(i+1);
            for (int j = 0; j < 8; j++)
            {
                Console.Write(grid[i, j]);
            }

            Console.WriteLine();
        }
    }

    public void UpdateCell(int x, int y, char value)
    {
        grid[x, y] = value;
        UpdateBoardDisplay(x, y, value);
    }
    
    public void UpdateBoardDisplay(int x, int y, char value)
    {
        Console.SetCursorPosition(x, y);
        Console.Write(value);
    }
    
    public void MoveUp(int columnNumber)
    {
        var temp = grid[0, columnNumber];
        for (int i = 0; i < 7; i++)
        {
            grid[i, columnNumber] = grid[i+1, columnNumber];
        }
        grid[7, columnNumber] = temp;
        Display();
    }
    
    public void MoveDown(int columnNumber)
    {
        var temp = grid[7, columnNumber];
        for (int i = 7; i > 0; i--)
        {
            grid[i, columnNumber] = grid[i-1, columnNumber];
        }
        grid[0, columnNumber] = temp;
        Display();
    }
    
    public void MoveBoard(int y, Direction direction)
    {
        switch (direction)
        {
            case Direction.Up:
                MoveUp(y);
                break;
            case Direction.Down:
                MoveDown(y);
                break;
        }
    }
}