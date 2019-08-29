using System;
using System.Collections.Generic;
using System.Text;

namespace Omnia.Codebase2019.Models
{

    public enum BeerType
    {
        Lager = 0,
        PaleAle = 1
    }

    public class BasicBeer : Omnia.Fx.Models.JsonTypes.OmniaJsonBase
    {

        public BeerType Type { get; protected set; }

        public string Brand { get; set; }
    }
}
