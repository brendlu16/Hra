using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hra
{
    public abstract class Item
    {
        public int ID;
        public string Name;
        public int Hodnota;
        public abstract List<string> VypsatStaty();
        public abstract string InvTlacitko();
    }
}