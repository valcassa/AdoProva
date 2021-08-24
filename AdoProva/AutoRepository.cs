using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoProva
{
    class AutoRepository : IAutoDBManager
    {


        const string connectionString = @"DataSource=(localdb)\mssqllocaldb
                                Initial catalogue= Concessionaria;" +
                                 "Integrated Security = true;";

        static List<Auto> auto = new List<Auto>();
        private object vehicleRepository;

        public void Delete(Auto auto)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                int idVehicleDel = GetIdVehicle(auto.Id);

                SqlCommand command = new SqlCommand();
                command.CommandType = System.Data.CommandType.Text;
                command.Connection = connection;

                command.CommandText = "elimita da Auto dove Id è Id=@IdAuto";
                command.Parameters.AddWithValue("IdAuto", auto.Id);
                command.ExecuteNonQuery();
                vehicleRepository.DeletebyId(idVehicleDel);
            }
        }

        private int GetIdVehicle(int? id)
        {
            int idVehicleDel = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;

                command.CommandText = "select * from Auto where Id=@IdAuto";
                command.Parameters.AddWithValue("@IdAuto", Id);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    idVehicleDel = (int)reader["idVehicle"];

                }
                return idVehicleDel;
            }

            public List<Auto> Fetch()
            {

                {
                    List<Auto> aut = new List<Auto>();
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        SqlCommand command = new SqlCommand();
                        command.CommandType = System.Data.CommandType.Text;
                        command.CommandText = "select Vehicle.Marca, Vehicle.Modello, Auto.IdAuto, Auto.Alimentazione, Auto.NPorte from Vehicle join Auto on vehicle.Id = Auto.AutoId";

                        SqlDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            var marca = reader["Marca"];
                            var modello = reader["Modello"];
                            var porte = (string)reader["NPorte"];
                            var alimentazione = (string)reader["Alimentazione"];
                            var id = (int)["IdAuto"];

                            Auto auto = new Auto((string)marca, (string)modello, porte, alimentazione, id);
                            aut.Add(aut);


                        }
                    }
                    return aut;
                }
            }

            public Auto GetById(int? id)
            {

                {
                    Auto auto = new Auto();
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        SqlCommand command = new SqlCommand();
                        command.Connection = connection;
                        command.CommandType = System.Data.CommandType.Text;
                        command.CommandText = "select * from Auto where Id=@IdAuto";
                        command.Parameters.AddWithValue("@IdAuto", id);

                        SqlDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            var marca = reader["Marca"];
                            var modello = reader["Modello"];
                            var porte = (string)reader["NPorte"];
                            var alimentazione = (string)reader["Alimentazione"];

 
                             auto = new Auto((string)marca, (string)modello, porte, alimentazione, id);

                        }
                        return auto;
                    }

                public void Insert(Auto auto)
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        Vehicles vehicle = new Vehicles(auto.Marca, auto.Modello, null);
                        vehicleRepository.Insert(vehicle);
                        int idVehicle = vehicleRepository.GetId(vehicle);

                        SqlCommand command = new SqlCommand();
                        command.Connection = connection;
                        command.CommandType = System.Data.CommandType.Text;
                        command.CommandText = "inserisci i valori (@nporte, @AutoId)";
                        command.Parameters.AddWithValue("@nporte", Auto.NPorte);
                        command.Parameters.AddWithValue("@AutoId", idVehicle);

                        command.ExecuteNonQuery();
                    }
                }
                     
                }

                public void Update(Auto auto)
                {
                    var AutodaCancellare = GetById(auto.Id);
                    Delete(AutodaCancellare);
                    Insert(auto);
                }
            }
        }
    }
