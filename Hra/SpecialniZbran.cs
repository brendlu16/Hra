using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hra
{
    class SpecialniZbran : Item
    {
        public int Presnost;
        public int MinPoskozeni;
        public int MaxPoskozeni;
        public override List<string> VypsatStaty()
        {
            return new List<string> { "Přesnost: " + Presnost, "Poškození: " + MinPoskozeni + "-" + MaxPoskozeni };
        }
        public override string InvTlacitko()
        {
            return "Vybavit";
        }
    }
}
