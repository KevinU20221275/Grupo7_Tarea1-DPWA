using FerreteriaApp.Models;
using System.Data;
using System.Data.SqlClient;

namespace FerreteriaApp.Data
{
    public class FerreteriaData
    {
        // cambiar la cadena de conexion a tu servidor de base de datos al hacer pruebas
        string connectionString = "Data Source=DESKTOP-9N00BC4\\SQLEXPRESS;Initial Catalog=Ferreteria;Integrated Security=True;Encrypt=False";

        public IEnumerable<FerreteriaModel> GetAll()
        {
            List<FerreteriaModel> ferreteriaLits = new List<FerreteriaModel>();

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (var command =  new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT Id, Name, Address, Phone, Email FROM Ferreterias;";
                    command.CommandType = CommandType.Text;

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            FerreteriaModel ferreteriaModel = new FerreteriaModel();
                            ferreteriaModel.Id = Convert.ToInt32(reader["ID"]);
                            ferreteriaModel.Name = reader["Name"].ToString();
                            ferreteriaModel.Address = reader["Address"].ToString();
                            ferreteriaModel.Phone = reader["Phone"].ToString();
                            ferreteriaModel.Email = reader["Email"].ToString();

                            ferreteriaLits.Add(ferreteriaModel);
                        }
                    }
                }
            }

            return ferreteriaLits;
        }

        public FerreteriaModel ?GetById(int Id)
        {
            FerreteriaModel ferreteriaModel = new FerreteriaModel();

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                
                using (var command = new SqlCommand()) 
                {
                    command.Connection = connection;
                    command.CommandText = @"SELECT Id, Name, Address, Phone, Email FROM Ferreterias WHERE Id = @Id";
                    command.Parameters.AddWithValue("@Id", Id);

                    command.CommandType = CommandType.Text;

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ferreteriaModel.Id = Convert.ToInt32(reader["ID"]);
                            ferreteriaModel.Name = reader["Name"].ToString();
                            ferreteriaModel.Address = reader["Address"].ToString();
                            ferreteriaModel.Phone = reader["Phone"].ToString();
                            ferreteriaModel.Email = reader["Email"].ToString();
                        }
                    }
                }
            }

            return ferreteriaModel;
        }

        public void Add(FerreteriaModel ferreteria)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "INSERT INTO Ferreterias VALUES(@Name, @Address, @Phone, @Email)";

                    command.Parameters.AddWithValue("@Name", ferreteria.Name);
                    command.Parameters.AddWithValue("@Address", ferreteria.Address);
                    command.Parameters.AddWithValue("@Phone", ferreteria.Phone);
                    command.Parameters.AddWithValue("@Email", ferreteria.Email);

                    command.CommandType = CommandType.Text;

                    command.ExecuteNonQuery();
                }
            }
        }

        public void Edit(FerreteriaModel ferreteria)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"UPDATE Ferreterias 
                                           SET Name = @Name,
                                           Address = @Address,
                                           Phone = @Phone,
                                           Email = @Email
                                           WHERE Id = @Id";

                    command.Parameters.AddWithValue("@Name", ferreteria.Name);
                    command.Parameters.AddWithValue("@Address", ferreteria.Address);
                    command.Parameters.AddWithValue("@Phone", ferreteria.Phone);
                    command.Parameters.AddWithValue("@Email", ferreteria.Email);
                    command.Parameters.AddWithValue("@Id", ferreteria.Id);

                    command.CommandType = CommandType.Text;

                    command.ExecuteNonQuery();
                }
            }
        }
        public void Delete(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"DELETE FROM Ferreterias
                                           WHERE Id = @Id";

                    command.Parameters.AddWithValue("@Id", id);

                    command.CommandType = CommandType.Text;

                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
