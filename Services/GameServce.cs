using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_Games.Entities;
using WebAPI_Games.Exptions;
using WebAPI_Games.InputModel;
using WebAPI_Games.Repository;
using WebAPI_Games.ViewModel;

namespace WebAPI_Games.Services
{
    public class GameServce : IGameService
    {
        private readonly IRepository _gameRepository;

        public GameServce(IRepository jogoRepository)
        {
            _gameRepository = jogoRepository;
        }

        public async Task<List<GameViewModel>> Get(int Pages, int number)
        {
            var gamer = await _gameRepository.Get(Pages, number);

            return gamer.Select(gamer => new GameViewModel
            {
                Id = gamer.Id,
                Name = gamer.Name,
                Studio = gamer.Studio,
                Price = gamer.Price
            })
                               .ToList();
        }

        public async Task<GameViewModel> Get(Guid id)
        {
            var gamer = await _gameRepository.Get(id);

            if (gamer == null)
                return null;

            return new GameViewModel
            {
                Id = gamer.Id,
                Name = gamer.Name,
                Studio = gamer.Studio,
                Price = gamer.Price
            };
        }

        public async Task<GameViewModel> Put(GameInputModel game)
        {
            var entitieGame = await _gameRepository.Get(game.Name, game.Studio);

            if (entitieGame.Count > 0)
                throw new GameInSystemExcption();

            var gameInsert = new Games
            {
                Id = Guid.NewGuid(),
                Name = game.Name,
                Studio = game.Studio,
                Price = game.Price
            };

            await _gameRepository.Put(gameInsert);

            return new GameViewModel
            {
                Id = gameInsert.Id,
                Name = game.Name,
                Studio = game.Studio,
                Price = game.Price
            };
        }

        public async Task Patch(Guid id, GameInputModel game)
        {
            var entiteGame = await _gameRepository.Get(id);

            if (entiteGame == null)
                throw new GameNotExistExcption();

            entiteGame.Name = game.Name;
            entiteGame.Studio = game.Studio;
            entiteGame.Price = game.Price;

            await _gameRepository.Patch(entiteGame);
        }

        public async Task Patch(Guid id, double Price)
        {
            var entiteGame = await _gameRepository.Get(id);

            if (entiteGame == null)
                throw new GameNotExistExcption();

            entiteGame.Price = Price;

            await _gameRepository.Patch(entiteGame);
        }

        public async Task Delete(Guid id)
        {
            var game = await _gameRepository.Get(id);

            if (game == null)
                throw new GameNotExistExcption();

            await _gameRepository.Delete(id);
        }

        public void Dispose()
        {
            _gameRepository?.Dispose();
        }

        Task<List<GameViewModel>> IGameService.Get(int Pages, int number)
        {
            throw new NotImplementedException();
        }

        Task<GameViewModel> IGameService.Get(Guid id)
        {
            throw new NotImplementedException();
        }

        Task<GameViewModel> IGameService.Post(GameInputModel game)
        {
            throw new NotImplementedException();
        }

        Task IGameService.Put(Guid id, GameInputModel game)
        {
            throw new NotImplementedException();
        }

        Task IGameService.Patch(Guid id, double price)
        {
            throw new NotImplementedException();
        }

        Task IGameService.Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        void IDisposable.Dispose()
        {
            throw new NotImplementedException();
        }
    }    
}