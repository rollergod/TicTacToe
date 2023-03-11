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

        [HttpPost]
        public IActionResult MakeStep(int xCord,int yCord)
        {
            var gameAfterStep = _gameService.Put(xCord,yCord);
            return Ok();
        }
    }
}