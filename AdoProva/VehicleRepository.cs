using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoProva
{
    class VehicleRepository : IVehicleDbManager
    {
        const string connectionString = @"Data Source = (localdb)\MSSQLLocalDB;" +
                                         "Initial Catalog = Magazzino;" +
                                         "Integrated Security = true;";

        public void Delete(Vehicles vehicle)
        {
            throw new NotImplementedException();
        }

        public List<Vehicles> Fetch()
        {
            throw new NotImplementedException();
        }

        public Vehicles GetById(int? id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Vehicles vehicle)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "insert into Vehicle values(@marca, @modello)";

                command.Parameters.AddWithValue("@brand", vehicle.Marca);
                command.Parameters.AddWithValue("@model", vehicle.Modello);

                command.ExecuteNonQuery();
            }
        }

        public void Update(Vehicles vehicle)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.CommandType = System.Data.CommandType.Text;
                command.Connection = connection;

                command.CommandText = "update Vehicle set Brand = @brand, Model = @model where Id = @id";
                command.Parameters.AddWithValue("@brand", vehicle.Marca);
                command.Parameters.AddWithValue("@model", vehicle.Modello);
                command.Parameters.AddWithValue("@id", vehicle.Id);

                command.ExecuteNonQuery();
            }
        }

        internal void DeleteById(int idVehicleToDelete)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "delete from Vehicle where Id = @id";
                command.Parameters.AddWithValue("@id", idVehicleToDelete);

                command.ExecuteNonQuery();
            }
        }

        internal int GetId(Vehicles vehicle)
        {
            int idVehicle = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "select Id from vehicle where Brand = @marca and Model = @modello";
                command.Parameters.AddWithValue("@marca", vehicle.Marca);
                command.Parameters.AddWithValue("@modello", vehicle.Modello);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    idVehicle = (int)reader["Id"];
                }
            }

            return idVehicle;
        }
    }
}
