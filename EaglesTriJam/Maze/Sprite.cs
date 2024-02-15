public class Sprite
{
    public static List<Sprite> Values = new()
    {
        new Sprite('╣', true, true, true, false),
        new Sprite('║', true, true, false, false),
        new Sprite('╗', false, true, true, false),
        new Sprite('╝', true, false, true, false),
        new Sprite('╚', true, false, false, true),
        new Sprite('╔', false, true, false, true),
        new Sprite('╩', true, false, true, true),
        new Sprite('╦', false, true, true, true),
        new Sprite('╠', true, true, false, true),
        new Sprite('═', false, false, true, true),
        new Sprite('╬', true, true, true, true)
    };

    public Sprite(char c, bool u, bool d, bool l, bool r)
    {
        Character = c;
        OpenUp = u;
        OpenDown = d;
        OpenLeft = l;
        OpenRight = r;
    }
    public char Character { get; set; }
    public bool OpenUp{ get; set; }
    public bool OpenDown { get; set; }
    public bool OpenLeft { get; set; }
    public bool OpenRight { get; set; }

    public static char GetRandomSprite()
    {
        var random = new Random();
        var index = random.Next(0, Values.Count-1);
        return Values[index].Character;
    }


    // Return true if two adjacent sprites hava an open path in the given direction
    public static bool CanMove(Sprite from, Sprite to, Direction direction)
    {
        return direction switch
        {
            Direction.Up => from.OpenUp && to.OpenDown,
            Direction.Down => from.OpenDown && to.OpenUp,
            Direction.Left => from.OpenLeft && to.OpenRight,
            Direction.Right => from.OpenRight && to.OpenLeft,
            _ => throw new ArgumentException("Invalid direction"),
        };
    }
}
