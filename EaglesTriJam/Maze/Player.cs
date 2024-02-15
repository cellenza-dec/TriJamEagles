namespace Maze;


public enum Direction
{
    Up,
    Down,
    Left,
    Right,
    Stop
}

public class Player
{
public int X { get; set; }
    public int Y { get; set; }
    
    public Player(Direction direction)
    {
        switch (direction)
        {
            case Direction.Up:
                X ++;
                break;
            case Direction.Down:
                X --;
                break;
            case Direction.Left:
                Y--;
                break;
            case Direction.Right:
                Y++;
                break;
        }
    }
    
    public void Move(int x, int y)
    {
        X += x;
        Y += y;
    }
}