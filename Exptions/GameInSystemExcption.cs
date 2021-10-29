using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI_Games.Exptions
{
    public class GameInSystemExcption : Exception
    {
        public GameInSystemExcption()
            :base("Game in system error")
        {}
    }
}
