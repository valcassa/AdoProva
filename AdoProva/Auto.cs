using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoProva
{
    class Auto : Vehicles
    {
         
        public string Alimentazione { get; set; }
        public static string NPorte { get; set; }

  
        public Auto(string marca, string modello, string alimentazione, string nporte, int? id)
               :base(marca, modello, id)
                {
             Alimentazione = alimentazione;
                NPorte = nporte;
                }       
    }
}
