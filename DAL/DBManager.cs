using BOL;
using MySql.Data.MySqlClient;
namespace DAL
{
    public class DBManager
    {
        public static string connString = @"server=localhost;port=3306;user=root;password=root123;database=bhagyesh";

        public static List<Product> getAllProducts()
        {
            List<Product> products = new List<Product>();
            MySqlConnection conn = new MySqlConnection(connString);

            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                string query = "select * from products";
                cmd.CommandText = query;

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int id = int.Parse(reader["id"].ToString());
                    string name = reader["panme"].ToString();
                    int quantity = int.Parse(reader["qty"].ToString());
                    Category category = Enum.Parse<Category>(reader["category"].ToString());
                    double price = double.Parse(reader["price"].ToString());

                    Product product = new Product(id, name, quantity, category, price);
                    products.Add(product);
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { conn.Close(); }

            return products;
        }

        public static void insertProduct(Product product)
        {
            MySqlConnection conn = new MySqlConnection(connString);

            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                string query = "insert into products values('" + product.ID + "','" + product.Name + "','" + product.Quantity + "','" + product.CATEGORY + "','" + product.Price + "')";
                cmd.CommandText = query;

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            finally { conn.Close(); }


        }

        public static String deleteProduct(int id)
        {
            MySqlConnection conn = new MySqlConnection(connString);
            String mesg = "Not deleted";
            try
            {

                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                string query = "Delete from products where id=" + id;
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();
                mesg = "deleted";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
            finally 
            { 
                conn.Close(); 
            }
            return mesg;
        }
    }
        
}
