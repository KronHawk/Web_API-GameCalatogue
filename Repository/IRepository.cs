using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_Games.Entities;

namespace WebAPI_Games.Repository
{
    public interface IRepository : IDisposable
    {
        Task<List<Games>> Get(int Pages, int number);
        Task<Games> Get(Guid id);
        Task<List<Games>> Get(string Name, string Studio);
        Task Put(Games game);
        Task Patch(Games game);
        Task Delete(Guid id);
    }
}