
using System.Data.SqlClient;

namespace WebApplication1.infrasructure
{
    public class ProductRepository : IProductRepository
    {
        private readonly string? connexionString;
        public ProductRepository(IConfiguration config)
        {
            connexionString = config["ConnexionStrings:sqlServer"];

        }
        public List<Product> GetAll()
        {
            List<Product> users = new List<Product>();
            var connexion = new SqlConnection(connexionString);
            try
            {
                connexion.Open();
                string request = "SELECT * FROM product";
                using (var commande = new SqlCommand(request, connexion))
                {
                    using (var reader = commande.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            users.Add(new Product
                            (
                                reader.GetString(0),
                                 reader.GetString(1),
                                 reader.GetString(2),
                                 reader.GetDecimal(3)

                            ));
                        }
                    }
                }
                return users;

            }
            catch (Exception ex) { throw; }
        }

        public Product GetById(String id)
        {
            var connexion = new SqlConnection(connexionString);
            try
            {
                connexion.Open();
                string request = "SELECT * FROM product where id=@id";
                Product product=new Product();
                using (var commande = new SqlCommand(request, connexion))
                {
                    commande.Parameters.AddWithValue("id", id);

                    using(var reader = commande.ExecuteReader()) {
                        if (reader.Read())
                        {
                                 product=new Product{Id =reader.GetString(0),
                                                Name= reader.GetString(1),
                                                Description=reader.GetString(2),
                                                Price=reader.GetDecimal(3)
                                 };
                        }
                    }
                }
                return product;

            }
            catch(Exception ex) { throw; }
        }
        public void CreateProduct(string name, string description, decimal price)
        {
            var connexion = new SqlConnection(connexionString);
            try
            {
                connexion.Open();
                string request = "INSERT INTO user(name,description,price) values(@name,@description,@price)";
                using (var commande = new SqlCommand(request, connexion))
                {
                    commande.Parameters.AddWithValue("name", name);
                    commande.Parameters.AddWithValue("description", description);
                    commande.Parameters.AddWithValue("price", price);
                    commande.ExecuteNonQuery();
                }
            }
            catch (Exception ex) { throw; }
        }
    }
}
