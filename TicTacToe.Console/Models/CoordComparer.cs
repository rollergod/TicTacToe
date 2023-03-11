using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Console.Models
{
    internal class CoordComparer : IEqualityComparer<Coord>
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
