using WebApplication1.infrasructure;
namespace WebApplication1.infrasructure
{
    public interface IUserRepository
    {
        public List<User> GetAll();
        public void CreateUser(string userName, string mail, string password);

    }
}
