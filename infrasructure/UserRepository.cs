
using System.Data.SqlClient;
using System.Globalization;

namespace WebApplication1.infrasructure
{
    public class UserRepository : IUserRepository
    {
        private readonly string? connexionString;
        public UserRepository(IConfiguration config) {
            connexionString = config["ConnexionStrings:sqlServer"];

        }
        public List<User> GetAll()
        {
            List<User> users = new List<User>();
            var connexion = new SqlConnection(connexionString);
            try
            {
                connexion.Open();
                string request = "SELECT * FROM user";
                using(var commande=new SqlCommand(request, connexion))
                {
                    using(var reader =commande.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            users.Add(new User
                            (
                                reader.GetString(0),
                                 reader.GetString(1),
                                 reader.GetString(2),
                                 reader.GetString(3)

                            ));
                        }
                    }
                }
                return users;

            }catch (Exception ex) { throw; }
        }
        public void CreateUser(string userName, string mail, string password) {
            var connexion = new SqlConnection(connexionString);
            try
            {
                connexion.Open();
                string request = "INSERT INTO user(name,mail,password) values(@name,@mail,@password)";
                using(var commande=new SqlCommand(request, connexion))
                {
                    commande.Parameters.AddWithValue("username", userName);
                    commande.Parameters.AddWithValue ("email", mail);
                    commande.Parameters.AddWithValue("password", password);
                    commande.ExecuteNonQuery();
                }
            }catch(Exception ex) { throw; }
        }
    }
}
