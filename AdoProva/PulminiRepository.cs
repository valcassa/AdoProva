using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoProva
{
    class PulminiRepository : IPulminiDBManager
    {
        

        const string connectionString = @"DataSource=(localdb)\mssqllocaldb
                                Initial catalogue= Concessionaria;"+
                                 "Integrated Security = true;";

        public void Delete(Pulmini pul)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                int idVehicleDel = GetIdVehicle(pul.Id);

                SqlCommand command = new SqlCommand();
                command.CommandType = System.Data.CommandType.Text;
                command.Connection = connection;

                command.CommandText = "elimita da Pulmini dove Id è Id=@PulminiId";
                command.Parameters.AddWithValue("@PulminiId", pul.Id);
                command.ExecuteNonQuery();
                vehicleRepository.DeletebyId(idVehicleDel);
            }    
        }

        private int GetIdVehicle(int? id)
        {
            int idVehicleDel = 0;

            using (SqlConnection connection = new SqlConnection(connectionString)) {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;

                command.CommandText = "select * from Pulmini where Id=@PulminiId";
                command.Parameters.AddWithValue("@PulminiId", Id);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                { idVehicleDel = (int)reader["idVehicle"];

                }
                return idVehicleDel;
            }

            public List<Pulmini> Fetch()

            { List<Pulmini> pul = new List<Pulmini>();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand();
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = "select Vehicle.Marca, Vehicle.Modello, Pulmini.PulminiId, Pulmini.NPosti from Vehicle join Pulmini on vehicle.Id = Pulmini.IdVehicle";

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        var marca = reader["Marca"];
                        var modello = reader["Modello"];
                        var posti = (int)reader["NPosti"];
                        var id = (int)["PulminiId"];

                        Pulmini pulmini = new Pulmini((string)marca, (string)modello, posti, id);
                        pul.Add(pulmini);


                    }
                }
                return pul;
            }
        }

         //public List<Pulmini> pul = new List<Pulmini>
        //{
          // new Pulmini ("Iveco", "Mod", 20, 01),
           //new Pulmini("Fiat", "Mod2", 30, 02),
           //new Pulmini ("Piaggio", "Mod3", 15, 03)
            //};



      //  public void Delete(Pulmini pulmini)
        //{
          //  pul.Remove(pulmini); }


        public Pulmini GetById(int? id)
        {
            return pulmini.Find(pul => pul.Id == id);
        }

        public void Insert(Pulmini pulmini)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                Vehicles vehicle = new Vehicles(pulmini.Marca, pulmini.Modello, null);
                vehicleRepository.Insert(vehicle);
                int idVehicle = vehicleRepository.GetId(vehicle);

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "inserisci i valori (@nposti, @idVehicle)";
                command.Parameters.AddWithValue("@nposti", Pulmini.NPosti);
                command.Parameters.AddWithValue("@idVehicle", idVehicle);

                command.ExecuteNonQuery();
            }
        }

        public void Update(Pulmini pul)
        {
            var PulminodaCancellare = GetById(pul.Id);
            Delete(PulminodaCancellare);
            Insert(pul);

        }

        private class vehicleRepository
        {
            internal static int GetById(int? id)
            {
                Pulmini pulmini = new Pulmini();
                using(SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = "select * from Pulmini where Id=@PulminiId";
                    command.Parameters.AddWithValue("@PulminiId", id);

                    SqlDataReader reader = command.ExecuteReader();

                    while(reader.Read())
                    {
                        var modello = (string)reader["Modello"];
                        var marca = (string)reader["Marca"];
                        var nposti = (int)reader["NPosti"];

                        pulmini = new Pulmini(modello, marca, nposti, id);

                    }
                    return pulmini;
                }
            }

            internal static void Insert(Vehicles vehicle)
            {
                throw new NotImplementedException();
            }

            internal static void Update(Pulmini pulmini)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = "aggiorna Pulmini set Marca = @marca, Modello = @model, NPosti = @nposti where Id = @PulminiId";
                    command.Parameters.AddWithValue("@marca", pulmini.Marca);
                    command.Parameters.AddWithValue("@modello", pulmini.Modello);
                    command.Parameters.AddWithValue("@NPosti", pulmini.NPosti);
                    command.Parameters.AddWithValue("PulminiId", pulmini.Id);

                    command.ExecuteNonQuery();
                }
            }
    }
}

    } 