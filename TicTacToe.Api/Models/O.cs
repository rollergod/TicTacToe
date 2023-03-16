using TicTacToe.Api.Models.Intefaces;

namespace TicTacToe.Api.Models
{
    public class O : XorO
    {
        public override string ToString()
        {
            return typeof(O).Name;
        }
    }
}
