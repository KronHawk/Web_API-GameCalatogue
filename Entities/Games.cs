using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI_Games.Entities
{
    public class Games
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Studio { get; set; }
        public double Price { get; set; }
    }
}
