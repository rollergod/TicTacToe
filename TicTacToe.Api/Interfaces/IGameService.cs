using TicTacToe.Api.Models;
using TicTacToe.Api.Models.Intefaces;

namespace TicTacToe.Api.Interfaces
{
    public interface IGameService
    {
        public XorO Turn();
        public string PrintTable();
        public Board Put(int xCord, int yCord);
        public string PrintFreeCoordinates();
        public string Winner();
    }
}
