using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hra
{
    class Jidlo : Item
    {
        public int Doplneni;
        public override List<string> VypsatStaty()
        {
            return new List<string> { "Doplnění zdraví: " + Doplneni };
        }
        public override string InvTlacitko()
        {
            return "Sníst";
        }
    }
}
