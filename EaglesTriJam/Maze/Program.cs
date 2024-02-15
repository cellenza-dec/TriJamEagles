// See https://aka.ms/new-console-template for more information


using Maze;

Board board = new Board();
    
board.Display();

board.UpdateBoardDisplay(1, 1, 'B');

Console.SetCursorPosition(5, 5);


static char GetRandomSprite()
{
    var spriteChars = new char[] { '╣', '║', '╗', '╝', '╚', '╔', '╩', '╦', '╠', '═', '╬' };
    var random = new Random();
    var index = random.Next(0, spriteChars.Length-1);
    return spriteChars[index];
}