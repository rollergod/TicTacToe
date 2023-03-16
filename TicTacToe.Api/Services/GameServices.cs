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
        public Board Put(int xCord, int yCord)
        {

            if (xCord > 2 || yCord > 2)
                throw new IndexOutOfRangeException($"Координаты ({xCord},{yCord}) выходят за пределы таблицы");

            var coord = new Coord(xCord, yCord);
            var turn = Turn();

            switch (turn)
            {
                case X:
                    if (PlaceIsNotNull(_board.OsCoords, coord))
                    {
                        throw new PositionIsNotNullException(xCord, yCord);
                    }
                    _board.AddXCoord(coord);
                    return new Board(_board.XsCoords, _board.OsCoords);
                case O:
                    if (PlaceIsNotNull(_board.XsCoords, coord))
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
            }
            else if (WinCoords(_board.OsCoords))
            {
                winner = "O win";
            }
            else if (_board.XsCoords.Union(_board.OsCoords).Count() == Constants.MAXIMUM_BLOCKS_ON_BOARD)
            {
                winner = "Draw";
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
