using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace PokerHandsAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CardController : ControllerBase
    {        
        public IEnumerable<PokerHandsResults> Get(string p1="", string p2="")
        {
            if (p1.Length == 0) p1 = "Player1";
            if (p2.Length == 0) p1 = "Player2";

            DealCards dc = new DealCards();
            return dc.Deal(p1,p2).ToArray();
            
        }
    }
}
