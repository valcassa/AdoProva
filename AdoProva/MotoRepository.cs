using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoProva
{
    class MotoRepository:IMotoDBManager
    {

        const string connectionString = @"DataSource=(localdb)\mssqllocaldb
                                Initial catalogue= Concessionaria;";

        static List<Moto> moto = new List<Moto>();
        Moto m = new Moto();
        

            public void Delete(Moto moto)
        {
                    throw new NotImplementedException();
        }

        public List<Moto> Fetch()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.CommandType = System.Data.CommandType.Text;
                command.Connection = connection;
                command.CommandText = "select Vehicle.Brand, Vehicle.Model, Bike.IdBike, Bike.ProdYear"+
                    "from dbo.Vehicle"+
                    "join dbo.Bike on Vehicle.IdVehicle = Bike.IdVehicle";
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var brand = reader["Brand"];
                    var model = reader["Model"];
                    var year = (int)reader["ProdYear"];
                    var id = (int)reader["Id"];

                    Bike bike = new Bike((string))

                }
            }

        }


        public Auto Get()
        {
            throw new NotImplementedException();
        }

        public void Insert(Moto moto)
        {
            throw new NotImplementedException();
        }

        public void Update(Moto moto)
        {
            throw new NotImplementedException();
        }
    }

} 
