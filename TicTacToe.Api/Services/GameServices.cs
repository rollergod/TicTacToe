using TicTacToe.Api.Helpers;
using TicTacToe.Api.Interfaces;
using TicTacToe.Api.Models;
using TicTacToe.Api.Models.Errors.Exceptions;
using TicTacToe.Api.Models.Intefaces;

namespace TicTacToe.Api.Services
{
    public class GameServices : IGameService
    {
        private Board _board = new();
        public string PrintFreeCoordinates()
        {
            string table = "";
            for (int i = 0; i < _board.GameBoard.GetLength(0); i++)
            {
                for (int j = 0; j < _board.GameBoard.GetLength(1); j++)
                {
                    if (_board.GameBoard[i, j].Symbol == '.')
                        table += $"{_board.GameBoard[i, j].X} / {_board.GameBoard[i, j].Y} \n";
                }
            }

            return table;
        }

        public string PrintTable()
        {
            string table = "";
            for (int i = 0; i < _board.GameBoard.GetLength(0); i++)
            {
                for (int j = 0; j < _board.GameBoard.GetLength(1); j++)
                {
                    _board.GameBoard[i, j].Symbol = GetSymbol(i, j);
                    table += _board.GameBoard[i, j].Symbol;
                }
                table += "\n";
            }

            return table;
        }
        private char GetSymbol(int i, int j)
        {
            var value = _board.XsCoords.Union(_board.OsCoords)
                .FirstOrDefault(x => x.X == _board.GameBoard[i, j].X && x.Y == _board.GameBoard[i, j].Y);

            return value != null ? value.Symbol : '.';
        }

        public Board Put(int xCord, int yCord)
        {
            var coord = new Coord(xCord, yCord);
            var turn = Turn();

            switch (turn)
            {
                case X:
                    coord.Symbol = 'X';
                    if (PlaceIsNotNull(_board.OsCoords, coord))
                    {
                        throw new PositionIsNotNullException(xCord, yCord);
                    }
                    _board.AddXCoord(coord);
                    return new Board(_board.XsCoords, _board.OsCoords);
                case O:
                    coord.Symbol = 'O';
                    if (PlaceIsNotNull(_board.XsCoords, coord)) // while loop
                    {
                        throw new PositionIsNotNullException(xCord, yCord);
                    }
                    _board.AddOCoord(coord);
                    return new Board(_board.XsCoords, _board.OsCoords);

                default:
                    return null;
            }
        }

        private bool PlaceIsNotNull(List<Coord> coords, Coord coord)
        {
            return coords.Any(i => i.X == coord.X && i.Y == coord.Y);
        }

        public XorO Turn()
        {
            return _board.XsCoords.Count() == _board.OsCoords.Count() ?
                new X()
                : new O();
        }

        public string Winner()
        {
            string winner = "";
            if (WinCoords(_board.XsCoords))
            {
                winner = "X win";
                //_board.IsGameFinished = true;
            }
            else if (WinCoords(_board.OsCoords))
            {
                winner = "O win";
                //IsGameFinished = true;
            }
            else if (_board.XsCoords.Union(_board.OsCoords).Count() == Constants.MAXIMUM_BLOCKS_ON_BOARD)
            {
                winner = "Draw";
                //IsGameFinished = true;
            }

            return winner;
        }
        private bool WinCoords(List<Coord> coords)
        {
            var isGameHasVictoryLine = _board.VictoryLines.Any(victoryLine =>
            {
                var intersectValues = victoryLine.Intersect(coords, new CoordComparer());

                return intersectValues.Count() == 3;
            });

            return isGameHasVictoryLine;
        }

        public void NewGame()
        {
            _board = new Board();
        }
    }
}
