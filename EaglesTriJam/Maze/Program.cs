// See https://aka.ms/new-console-template for more information


using Maze;

Board board = new Board();
bool stop = false;
int columnNumber = 0;

do
{
    var direction = InputManager.GetDirection();
    switch (direction)
    {
        case Maze.Direction.Right:
            columnNumber++;
            break;
        case Maze.Direction.Left:
            columnNumber--;
            break;
        case Maze.Direction.Up:
        case Maze.Direction.Down:
            board.MoveBoard(columnNumber, direction);
            break;
        case Maze.Direction.Stop:
            stop = true;
            break;
    }
    
}while (!stop);



// board.Display();
//
// Console.WriteLine();
// Console.WriteLine();
// Console.WriteLine();
//
// board.MoveDown(0);
// board.MoveUp(0);