// See https://aka.ms/new-console-template for more information


using System.Text.RegularExpressions;
using Maze;

Board board = new Board(width:2, height:4);
bool stop = false;

do
{

    try
    {
        var direction = InputManager.GetDirection();
        switch (direction)
        {
            case Direction.Right:
                board.SelectedColumn ++;
                board.Display();
                break;
            case Direction.Left:
                board.SelectedColumn --;
                board.Display();
                break;
            case Direction.Up:
            case Direction.Down:
                board.MoveBoard(direction);
                break;
            case Direction.PlayerUp:
            case Direction.PlayerDown:
            case Direction.PlayerLeft:
            case Direction.PlayerRight:
                board.MovePlayer(direction);
                break;
            case Direction.Stop:
                stop = true;
                break;
        }
    }
    catch (Exception e)
    {
        Console.Beep();
    }
    
}while (!stop);