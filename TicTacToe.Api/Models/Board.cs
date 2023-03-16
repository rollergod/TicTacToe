using TicTacToe.Api.Helpers;

namespace TicTacToe.Api.Models
{
    public class Board
    {
        internal Board(List<Coord> xs, List<Coord> ys)
        {
            _xs = xs;
            _os = ys;
        }
        internal Board()
        {
            _xs = new List<Coord>();
            _os = new List<Coord>();

            // _gameboard = new Coord[,]
            //{
            //     { new Coord(0,0,),new Coord(1,0,),new Coord(2,0,) },
            //     { new Coord(0,1,),new Coord(1,1,),new Coord(2,1,)},
            //     { new Coord(0,2,),new Coord(1,2,),new Coord(2,2,) },
            //};
            _gameboard = new int[3, 3]
            {
                { 0,0,0 },
                { 0,0,0 },
                { 0,0,0 }
            };
        }

        public bool IsGameFinished { get; private set; } = false;
        public int[,] GameBoard { get { return _gameboard; } }
        public List<Coord> XsCoords { get { return _xs; } }
        public List<Coord> OsCoords { get { return _os; } }
        public List<List<Coord>> VictoryLines { get { return _victoryLines; } }

        private readonly List<Coord> _xs;
        private readonly List<Coord> _os;
        //private Coord[,] _gameboard;
        private int[,] _gameboard;
        private List<List<Coord>> _victoryLines = new()
        {
            new List<Coord>() {new Coord(0,0), new Coord(0, 1) , new Coord(0, 2) },
            new List<Coord>() {new Coord(1,0), new Coord(1, 1) , new Coord(1, 2) },
            new List<Coord>() {new Coord(2,0), new Coord(2, 1) , new Coord(2, 2) },

            new List<Coord>() {new Coord(0,0), new Coord(1, 0) , new Coord(2, 0) },
            new List<Coord>() {new Coord(0,1), new Coord(1, 1) , new Coord(2, 1) },
            new List<Coord>() {new Coord(0,2), new Coord(1, 2) , new Coord(2, 2) },

            new List<Coord>() {new Coord(0,0), new Coord(1, 1) , new Coord(2, 2) },
            new List<Coord>() {new Coord(0,2), new Coord(1, 1) , new Coord(2, 0) },
        };

        public void AddXCoord(Coord coord)
        {
            _gameboard[coord.X, coord.Y] = Constants.X_SYMBOL;
            _xs.Add(coord);
        }

        public void AddOCoord(Coord coord)
        {
            _gameboard[coord.X, coord.Y] = Constants.O_SYMBOL;
            _os.Add(coord);
        }
    }
}
