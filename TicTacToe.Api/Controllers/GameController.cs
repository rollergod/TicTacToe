using Microsoft.AspNetCore.Mvc;
using TicTacToe.Api.Interfaces;

namespace TicTacToe.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GameController : ControllerBase
    {
        private readonly IGameService _gameService;

        public GameController(IGameService gameService)
        {
            _gameService = gameService;
        }

        [HttpGet("turn")]
        public IActionResult Turn()
        {
            var turn = _gameService.Turn();

            return Ok(turn.ToString());
        }

        [HttpPost]
        public IActionResult MakeStep(int xCord,int yCord)
        {
            var gameAfterStep = _gameService.Put(xCord,yCord);

            string winner = _gameService.Winner();

            if (!string.IsNullOrWhiteSpace(winner))
            {
                return Ok(winner);
            }

            return Ok("Ход сделан");
        }

        [HttpPost("new-game")]
        public IActionResult InitializeNewGame()
        {
            _gameService.NewGame();

            return NoContent();
        }
    }
}