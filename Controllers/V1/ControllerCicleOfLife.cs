using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI_Games.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    public class ControllerCicleOfLife : ControllerBase
    {
        public readonly IExmpleSingleton _exmpleSingleton1;
        public readonly IExmpleSingleton _exmpleSingleton2;

        public readonly IExmplecoped _exmpleScoped1;
        public readonly IExmplecoped _exmpleScoped2;

        public readonly IExmpleTransient _exmpleTransient1;
        public readonly IExmpleTransient _exmpleTransient2;

        public ControllerCicleOfLife(IExmpleSingleton exemploSingleton1,
                                       IExmpleSingleton exemploSingleton2,
                                       IExmplecoped exemploScoped1,
                                       IExmplecoped exemploScoped2,
                                       IExmpleTransient exemploTransient1,
                                       IExmpleTransient exemploTransient2)
        {
            _exmpleSingleton1 = exemploSingleton1;
            _exmpleSingleton2 = exemploSingleton2;
            _exmpleScoped1 = exemploScoped1;
            _exmpleScoped2 = exemploScoped2;
            _exmpleTransient1 = exemploTransient1;
            _exmpleTransient2 = exemploTransient2;
        }

        [HttpGet]
        public Task<string> Get()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"Singleton 1: {_exmpleSingleton1.Id}");
            stringBuilder.AppendLine($"Singleton 2: {_exmpleSingleton2.Id}");
            stringBuilder.AppendLine();
            stringBuilder.AppendLine($"Scoped 1: {_exmpleScoped1.Id}");
            stringBuilder.AppendLine($"Scoped 2: {_exmpleScoped2.Id}");
            stringBuilder.AppendLine();
            stringBuilder.AppendLine($"Transient 1: {_exmpleTransient1.Id}");
            stringBuilder.AppendLine($"Transient 2: {_exmpleTransient2.Id}");

            return Task.FromResult(stringBuilder.ToString());
        }

    }

    public interface IExemploGeral
    {
        public Guid Id { get; }
    }

    public interface IExmpleSingleton : IExemploGeral
    { }

    public interface IExmplecoped : IExemploGeral
    { }

    public interface IExmpleTransient : IExemploGeral
    { }

    public class ExemploCicloDeVida : IExmpleSingleton, IExmplecoped, IExmpleTransient
    {
        private readonly Guid _guid;

        public ExemploCicloDeVida()
        {
            _guid = Guid.NewGuid();
        }

        public Guid Id => _guid;
    }
}
