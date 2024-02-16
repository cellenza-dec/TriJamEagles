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

    public static Sprite GetRandomSprite()
    {
        var random = new Random();
        var index = random.Next(0, Values.Count-1);
        return Values[index];
    }


    // Return true if two adjacent sprites hava an open path in the given direction
    public static bool CanMove(Sprite from, Sprite to, Direction direction)
    {
        return direction switch
        {
            Direction.PlayerUp => from.OpenUp && to.OpenDown,
            Direction.PlayerDown => from.OpenDown && to.OpenUp,
            Direction.PlayerLeft => from.OpenLeft && to.OpenRight,
            Direction.PlayerRight => from.OpenRight && to.OpenLeft,
            _ => throw new ArgumentException("Invalid direction"),
        };
    }
}
