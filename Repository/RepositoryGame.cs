using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_Games.Entities;

namespace WebAPI_Games.Repository
{
    public class RepositoryGame : IRepository
    {
        private static Dictionary<Guid, Games> games = new Dictionary<Guid, Games>()
        {
            {Guid.Parse("0ca314a5-9282-45d8-92c3-2985f2a9fd04"), new Games{ Id = Guid.Parse("0ca314a5-9282-45d8-92c3-2985f2a9fd04"), Name = "Fifa 21", Studio = "EA", Price = 200} },
            {Guid.Parse("eb909ced-1862-4789-8641-1bba36c23db3"), new Games{ Id = Guid.Parse("eb909ced-1862-4789-8641-1bba36c23db3"), Name = "Fifa 20", Studio = "EA", Price = 190} },
            {Guid.Parse("5e99c84a-108b-4dfa-ab7e-d8c55957a7ec"), new Games{ Id = Guid.Parse("5e99c84a-108b-4dfa-ab7e-d8c55957a7ec"), Name = "Fifa 19", Studio = "EA", Price = 180} },
            {Guid.Parse("da033439-f352-4539-879f-515759312d53"), new Games{ Id = Guid.Parse("da033439-f352-4539-879f-515759312d53"), Name = "Fifa 18", Studio = "EA", Price = 170} },
            {Guid.Parse("92576bd2-388e-4f5d-96c1-8bfda6c5a268"), new Games{ Id = Guid.Parse("92576bd2-388e-4f5d-96c1-8bfda6c5a268"), Name = "Street Fighter V", Studio = "Capcom", Price = 80} },
            {Guid.Parse("c3c9b5da-6a45-4de1-b28b-491cbf83b589"), new Games{ Id = Guid.Parse("c3c9b5da-6a45-4de1-b28b-491cbf83b589"), Name = "Grand Theft Auto V", Studio = "Rockstar", Price = 190} }
        };
        private object nome;

        public Task<List<Games>> Get(int Pages, int number)
        {
            return Task.FromResult(games.Values.Skip((Pages - 1) * number).Take(number).ToList());
        }

        public Task<Games> Get(Guid id)
        {
            if (!games.ContainsKey(id))
                return Task.FromResult<Games>(null);

            return Task.FromResult(games[id]);
        }

        public Task<List<Games>> Get(string Name, string studio)
        {
            return Task.FromResult(games.Values.Where(game => game.Name.Equals(Name) && game.Studio.Equals(studio)).ToList());
        }

        public Task<List<Games>> GetWithoutLambda(string Name, string Studio)
        {
            var retorno = new List<Games>();

            foreach (var game in games.Values)
            {
                if (game.Name.Equals(Name) && game.Studio.Equals(Studio))
                    retorno.Add(game);
            }

            return Task.FromResult(retorno);
        }

        public Task Put(Games game)
        {
            games.Add(game.Id, game);
            return Task.CompletedTask;
        }

        public Task Patch(Games game)
        {
            games[game.Id] = game;
            return Task.CompletedTask;
        }

        public Task Delete(Guid id)
        {
            games.Remove(id);
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            //Fechar conexão com o banco
        }
    }
}