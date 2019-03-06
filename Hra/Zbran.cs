using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hra
{
    class Zbran : Item
    {
        public int Ovladatelnost;
        public int MinPoskozeni;
        public int MaxPoskozeni;
        public override List<string> VypsatStaty()
        {
            return new List<string> { "Ovladatelnost: " + Ovladatelnost, "Poškození: " + MinPoskozeni + "-" + MaxPoskozeni };
        }
        public override string InvTlacitko()
        {
            return "Vybavit";
        }
    }
}
