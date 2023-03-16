namespace TicTacToe.Api.Models
{
    public class Coord
    {
        public Coord(int x, int y)
        {
            X = x;
            Y = y;
        }
        public int X { get; private set; }
        public int Y { get; private set; }
    }
}
