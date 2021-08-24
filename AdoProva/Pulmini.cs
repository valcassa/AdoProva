using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoProva
{
    class Pulmini : Vehicles
    {

        public int NPosti { get; set; }

        public Pulmini(string marca, string modello, int nposti, int?id )
            :base(marca, modello, id)
        {
            NPosti = nposti;
        }
    }


}
