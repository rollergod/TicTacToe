using TicTacToe.Console.Models.Intefaces;

namespace TicTacToe.Console.Models
{
    internal class Board
    {
        private Board(List<Coord> xs, List<Coord> ys)
        {
            _xs = xs;
            _os = ys;
        }
        private Board()
        {
            _xs = new List<Coord>();
            _os = new List<Coord>();

            _gameboard = new Coord[,]
           {
                { new Coord(0,0,'.'),new Coord(1,0,'.'),new Coord(2,0,'.') },
                { new Coord(0,1,'.'),new Coord(1,1,'.'),new Coord(2,1,'.')},
                { new Coord(0,2,'.'),new Coord(1,2,'.'),new Coord(2,2,'.') },
           };
        }

        public bool IsGameFinished { get; private set; } = false;

        private readonly List<Coord> _xs;
        private readonly List<Coord> _os;
        private Coord[,] _gameboard;
        private List<List<Coord>> _victoryLines = new()
        {
            new List<Coord>() {new Coord(0,0,'.'), new Coord(0, 1,'.') , new Coord(0, 2,'.') },
            new List<Coord>() {new Coord(1,0,'.'), new Coord(1, 1,'.') , new Coord(1, 2,'.') },
            new List<Coord>() {new Coord(2,0,'.'), new Coord(2, 1,'.') , new Coord(2, 2,'.') },

            new List<Coord>() {new Coord(0,0,'.'), new Coord(1, 0,'.') , new Coord(2, 0,'.') },
            new List<Coord>() {new Coord(0,1,'.'), new Coord(1, 1,'.') , new Coord(2, 1,'.') },
            new List<Coord>() {new Coord(0,2,'.'), new Coord(1, 2,'.') , new Coord(2, 2,'.') },

            new List<Coord>() {new Coord(0,0,'.'), new Coord(1, 1,'.') , new Coord(2, 2,'.') },
            new List<Coord>() {new Coord(0,2,'.'), new Coord(1, 1,'.') , new Coord(2, 0,'.') },
        };

        public void PrintBoard()
        {
            for (int i = 0; i < _gameboard.GetLength(0); i++)
            {
                for (int j = 0; j < _gameboard.GetLength(1); j++)
                {
                    _gameboard[i, j].Symbol = GetSymbol(i, j);
                    System.Console.Write(_gameboard[i,j].Symbol);
                }
                System.Console.WriteLine();
            }
        }

        private char GetSymbol(int i,int j)
        {
            var value = _xs.Union(_os)
                .FirstOrDefault(x => x.X == _gameboard[i, j].X && x.Y == _gameboard[i, j].Y);

            return value != null ? value.Symbol : '.'; 
        }

        public XorO Turn()
        {
            return _xs.Count == _os.Count ? 
                new X() : 
                new O();
        }

        public Board Put(int xCord, int yCord)
        {
            var coord = new Coord(xCord, yCord);
            var turn = Turn();

            switch (turn)
            {
                case X:
                    coord.Symbol = 'X';
                    if (PlaceIsNotNull(_os, coord))
                    {
                        System.Console.WriteLine("Место занято");
                        return this;
                    }
                    _xs.Add(coord);
                    return new Board(_xs, _os);
                case O:
                    coord.Symbol = 'O';
                    if (PlaceIsNotNull(_xs,coord)) // while loop
                    {
                        System.Console.WriteLine("Место занято");
                        return this;
                    }
                    _os.Add(coord);
                    return new Board(_xs, _os);

                default:
                    return null;
            }
        }

        private bool PlaceIsNotNull(List<Coord> coords,Coord coord)
        {
            return coords.Any(i => i.X == coord.X && i.Y == coord.Y);
        }

        public void FreeCoordinates()
        {
            System.Console.WriteLine("Свободные координаты X / O");
            for (int i = 0; i < _gameboard.GetLength(0); i++)
            {
                for (int j = 0; j < _gameboard.GetLength(1); j++)
                {
                    if(_gameboard[i, j].Symbol == '.')
                        System.Console.Write($"{_gameboard[i, j].X} / {_gameboard[i, j].Y} \n");
                }
            }
        }

        public void Winner()
        {
            if (WinCoords(_xs))
            {
                System.Console.WriteLine("X win");
                IsGameFinished = true;
            }
            else if (WinCoords(_os))
            {
                System.Console.WriteLine("O win");
                IsGameFinished = true;
            }
            else if (_xs.Union(_os).Count() == Constants.MAXIMUM_BLOCKS_ON_BOARD)
            {
                System.Console.WriteLine("Draw");
                IsGameFinished = true;
            }
        }

        private bool WinCoords(List<Coord> coords)
        {
            var isGameHasVictoryLine = _victoryLines.Any(victoryLine =>
            {
                var inter = victoryLine.Intersect(coords,new CoordComparer());
              
                return inter.Count() == 3;
            });

            return isGameHasVictoryLine;
        }

        public static Board StartGame()
        {
            return new Board();
        }
    }
}
