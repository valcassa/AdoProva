using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoProva
{
    class Vehicles
    {

        public string Marca { get; set; }
        public string Modello { get; set; }
        public int? Id { get; set; }

        public Vehicles()
        {

        }
        public Vehicles(string marca, string modello, int? id)
        {
            Marca = marca;
            Modello = modello;
            Id = id;
        }
    }
}
