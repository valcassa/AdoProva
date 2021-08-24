using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoProva
{
    class Menu
    {
        internal static void Start()
        {
            Console.WriteLine("1) Visualizza tutti i veicoli");
            Console.WriteLine("2) Visualizza tutte le moto");
            Console.WriteLine("3) Visualizza tutte le auto");
            Console.WriteLine("4) Visualizza tutti i pulmini");
            Console.WriteLine("5) Inserisci nuovo veicolo");
            Console.WriteLine("6) Vendi un veicolo");
            Console.WriteLine("Premi 0 per uscire");


            string scelta = Console.ReadLine(); 

            switch(scelta)
            {
                case "1":
                    DealManager.ShowVehicles();
                    break;

                case "2":
                    DealManager.ShowAuto();
                    break;

                case "3":
                    DealManager.ShowMoto();

                    break;

                case "4":
                    DealManager.ShowBus();

                    break;

                case "5":
                    DealManager.AddVehicles();
                    break;

                case "6":
                    DealManager.SellVehicles();
                    break;

                case "0":
                    break;


            }
                }
    }
}
