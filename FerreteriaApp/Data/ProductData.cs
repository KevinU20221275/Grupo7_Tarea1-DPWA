using FerreteriaApp.Models;
using System.Data;
using System.Data.SqlClient;

namespace FerreteriaApp.Data
{
    public class ProductData
    {
        // cambiar la cadena de conexion a tu servidor de base de datos al hacer pruebas
        string connectionString = "Data Source=DESKTOP-9N00BC4\\SQLEXPRESS;Initial Catalog=Ferreteria;Integrated Security=True;Encrypt=False";

        public IEnumerable<ProductModel> GetAllProducts()
        {
            List<ProductModel> productsList = new List<ProductModel>();

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT Id, ProductName, ProductDescription, ProductCategory, Stock, Price, ExpirationDate FROM Product ";
                    command.CommandType = CommandType.Text;

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ProductModel productModel = new ProductModel();
                            productModel.Id = Convert.ToInt32(reader["Id"]);
                            productModel.ProductName = reader["ProductName"].ToString();
                            productModel.ProductDescription = reader["ProductDescription"].ToString();
                            productModel.ProductCategory = reader["ProductCategory"].ToString();
                            productModel.Stock = Convert.ToInt32(reader["Stock"]);
                            productModel.Price = Convert.ToDouble(reader["Price"]);
                            productModel.ExpirationDate = reader["ExpirationDate"].ToString();

                            productsList.Add(productModel);
                        }
                    }
                }
            }

            return productsList;


        }

        public void Add(ProductModel product)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"INSERT INTO Product 
                                           VALUES(@ProductName, @ProductDescription, @ProductCategory, @Stock, @Price, @ExpirationDate)";

                    command.Parameters.AddWithValue("@ProductName", product.ProductName);
                    command.Parameters.AddWithValue("@ProductDescription", product.ProductDescription);
                    command.Parameters.AddWithValue("@ProductCategory", product.ProductCategory);
                    command.Parameters.AddWithValue("@Stock", product.Stock);
                    command.Parameters.AddWithValue("@Price", product.Price);
                    command.Parameters.AddWithValue("@Expirationdate", product.ExpirationDate);


                    command.CommandType = CommandType.Text;

                    command.ExecuteNonQuery();
                }
            }
        }

        public ProductModel? GetById(int id)
        {
            ProductModel productModel = new ProductModel();

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"SELECT Id, ProductName, ProductDescription, ProductCategory, Stock, Price, ExpirationDate  FROM Product
                                            WHERE Id = @Id";

                    command.Parameters.AddWithValue("@Id", id);

                    command.CommandType = CommandType.Text;

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            productModel.Id = Convert.ToInt32(reader["Id"]);
                            productModel.ProductName = reader["ProductName"].ToString();
                            productModel.ProductDescription = reader["ProductDescription"].ToString();
                            productModel.ProductCategory = reader["ProductCategory"].ToString();
                            productModel.Stock = Convert.ToInt32(reader["Stock"]);
                            productModel.Price = Convert.ToDouble(reader["Price"]);
                            productModel.ExpirationDate = reader["ExpirationDate"].ToString();
                        }
                    }
                }
            }

            return productModel;
        }

        public void Edit(ProductModel product)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"UPDATE Product 
                                           SET ProductName = @ProductName,
                                           ProductDescription = @ProductDescription,
                                           ProductCategory = @ProductCategory,
                                           Stock = @Stock,
                                           Price = @Price,
                                           ExpirationDate = @ExpirationDate
                                           WHERE Id = @Id";

                    command.Parameters.AddWithValue("@ProductName", product.ProductName);
                    command.Parameters.AddWithValue("@ProductDescription", product.ProductDescription);
                    command.Parameters.AddWithValue("@ProductCategory", product.ProductCategory);
                    command.Parameters.AddWithValue("@Stock", product.Stock);
                    command.Parameters.AddWithValue("@Price", product.Price);
                    command.Parameters.AddWithValue("@ExpirationDate", product.ExpirationDate);
                    command.Parameters.AddWithValue("@Id", product.Id);

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
                    command.CommandText = @"DELETE FROM Product
                                           WHERE Id = @Id";

                    command.Parameters.AddWithValue("@Id", id);

                    command.CommandType = CommandType.Text;

                    command.ExecuteNonQuery();
                }
            }
        }

    }
}
