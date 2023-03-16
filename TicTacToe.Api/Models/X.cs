using TicTacToe.Api.Models.Intefaces;

namespace TicTacToe.Api.Models
{
    public class X : XorO
    {
        public override string ToString()
        {
            return typeof(X).Name;
        }
    }
}
