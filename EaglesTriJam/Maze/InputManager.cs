namespace Maze;

public class InputManager
{
    public static Direction GetDirection()
    {
        var input = Console.ReadKey();
        
        switch (input.Key)
        {
            case ConsoleKey.UpArrow:
                return Direction.Up;
            case ConsoleKey.DownArrow:
                return Direction.Down;
            case ConsoleKey.LeftArrow:
                return Direction.Left;
            case ConsoleKey.RightArrow:
                return Direction.Right;
            
            case ConsoleKey.Q:
                return Direction.PlayerLeft;
            case ConsoleKey.Z:
                return Direction.PlayerUp;
            case ConsoleKey.D:
                return Direction.PlayerRight;
            case ConsoleKey.S:
                return Direction.PlayerDown;
            
            default:
                return Direction.Stop;
        }
    }
}