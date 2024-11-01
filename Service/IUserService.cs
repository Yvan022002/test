using WebApplication1.infrasructure;
namespace WebApplication1.Service
{
    public interface IUserService
    {
        public void Register(string userName, string password);
        public bool Authenticate(string userName, string password);

        public User Login(string userName, string password);

    }
}
