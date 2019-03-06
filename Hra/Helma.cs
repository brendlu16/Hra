using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hra
{
    class Helma : Item
    {
        public int Ochrana;
        public override List<string> VypsatStaty()
        {
            return new List<string> { "Hodnota: " + Hodnota, "Ochrana: " + Ochrana.ToString() + "%" };
        }
        public override string InvTlacitko()
        {
            return "Nasadit";
        }
    }
}
