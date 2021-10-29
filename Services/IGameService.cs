using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_Games.InputModel;
using WebAPI_Games.ViewModel;

namespace WebAPI_Games.Services
{
    public interface IGameService : IDisposable
    {
        Task<List<GameViewModel>> Get(int Pages, int number);
        Task<GameViewModel> Get(Guid id);
        Task<GameViewModel> Post(GameInputModel game);
        Task Put(Guid id,GameInputModel game);
        Task Patch(Guid id, double price);
        Task Delete(Guid id);
    }
}
