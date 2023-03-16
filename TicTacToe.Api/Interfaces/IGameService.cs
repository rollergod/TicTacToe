using TicTacToe.Api.Models;
using TicTacToe.Api.Models.Intefaces;

namespace TicTacToe.Api.Interfaces
{
    public interface IGameService
    {
        public XorO Turn();
        public Board Put(int xCord, int yCord);
        public string Winner();
        public void NewGame();
    }
}
