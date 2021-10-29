using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI_Games.Exptions
{
    public class GameNotExistExcption : Exception
    {
        public GameNotExistExcption() 
            :base("Game not exist or out of system")
        {}
    }
}
