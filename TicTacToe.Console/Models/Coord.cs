namespace TicTacToe.Console.Models
{
    public class Coord 
    {
        public Coord(int x, int y,char symbol = '.')
        {
            X = x;
            Y = y;
            Symbol = symbol;
        }
        public int X { get; private set; }
        public int Y { get; private set; }
        public char Symbol { get; set; }
    }
}
