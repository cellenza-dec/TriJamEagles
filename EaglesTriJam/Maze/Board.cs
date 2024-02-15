namespace Maze;

public class Board
{
        public char[,] grid =
        {
            {'A', 'A', 'A'},
            {'A', 'A', 'A'},
            {'A', 'A', 'A'}
        };


        public void Display()
        {
            for( int i = 0; i < 3; i++)
            {
                for( int j = 0; j < 3; j++)
                {
                    Console.Write(grid[i,j]);
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
}