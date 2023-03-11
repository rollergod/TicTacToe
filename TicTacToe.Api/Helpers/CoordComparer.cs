using System.Diagnostics.CodeAnalysis;
using TicTacToe.Api.Models;

namespace TicTacToe.Api.Helpers
{
    public class CoordComparer : IEqualityComparer<Coord>
    {
        public bool Equals(Coord? x, Coord? y)
        {
            return x.Y == y.Y && x.X == y.X;
        }

        public int GetHashCode([DisallowNull] Coord obj)
        {
            return 0;
        }
    }
}
