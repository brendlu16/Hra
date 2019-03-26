using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hra
{
    class Stit : Item
    {
        public int Hmotnost;
        public int MinBlok;
        public int MaxBlok;
        public override List<string> VypsatStaty()
        {
            return new List<string> { "Hmotnost: " + Hmotnost, "Blokování: " + MinBlok + "-" + MaxBlok };
        }
        public override string InvTlacitko()
        {
            return "Vybavit";
        }
    }
}
