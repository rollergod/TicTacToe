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

        [HttpGet(Name = "GetTable")]
        public IActionResult PrintTable()
        {
            var table = _gameService.PrintTable();

            return Ok(table);
        }

        [HttpGet("free-coordinates",Name = "GetFreeCoordinates")]
        public IActionResult PrintFreeCoordinates()
        {
            var table = _gameService.PrintFreeCoordinates();

            return Ok(table);
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

            return RedirectToRoute("GetTable");
        }

        [HttpPost("new-game")]
        public IActionResult InitializeNewGame()
        {
            _gameService.NewGame();

            return RedirectToRoute("GetTable");
        }
    }
}