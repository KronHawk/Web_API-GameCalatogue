using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_Games.Exptions;
using WebAPI_Games.InputModel;
using WebAPI_Games.Services;
using WebAPI_Games.ViewModel;

namespace WebAPI_Games.Controllers.V1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class Jogos : ControllerBase
    {
        private readonly IGameService _gameService;

        public Jogos(IGameService gameService)
        {
            _gameService = gameService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GameViewModel>>> Get([FromQuery, Range(1, int.MaxValue)] int Pages = 1, [FromQuery, Range(1, 50)] int number = 5)
        {
            var jogos = await _gameService.Get(Pages, number);

            if (jogos.Count() == 0)
                return NoContent();

            return Ok(jogos);
        }

        [HttpGet("{idGame:guid}")]
        public async Task<ActionResult<GameViewModel>> Get([FromRoute] Guid idGame)
        {
            var jogo = await _gameService.Get(idGame);

            if (jogo == null)
                return NoContent();

            return Ok(jogo);
        }

        [HttpPost]
        public async Task<ActionResult<GameViewModel>> Post([FromBody] GameInputModel gameInputModel)
        {
            try
            {
                var jogo = await _gameService.Post(gameInputModel);

                return Ok(jogo);
            }
            catch (GameInSystemExcption ex)
            {
                return UnprocessableEntity("Já existe um jogo com este nome para esta produtora");
            }
        }

        [HttpPut("{idGame:guid}")]
        public async Task<ActionResult> Put([FromRoute] Guid idGame, [FromBody] GameInputModel gameInputModel)
        {
            try
            {
                await _gameService.Put(idGame, gameInputModel);

                return Ok();
            }
            catch (GameNotExistExcption ex)
            {
                return NotFound("Não existe este jogo");
            }
        }

        [HttpPatch("{idGame:guid}/price/{price:double}")]
        public async Task<ActionResult> Patch([FromRoute] Guid idGame, [FromRoute] double price)
        {
            try
            {
                await _gameService.Patch(idGame, price);

                return Ok();
            }
            catch (GameNotExistExcption ex)
            {
                return NotFound("Não existe este jogo");
            }
        }

        [HttpDelete("{idGame:guid}")]
        public async Task<ActionResult> Delete([FromRoute] Guid idGame)
        {
            try
            {
                await _gameService.Delete(idGame);

                return Ok();
            }
            catch (GameNotExistExcption ex)
            {
                return NotFound("Não existe este jogo");
            }
        }
    }
}
