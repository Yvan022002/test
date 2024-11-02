using WebApplication1.infrasructure;
using WebApplication1.Models;
namespace WebApplication1.Service
{
    public interface IUserService
    {
        public void Register(string userName,string mail, string password);
        public bool Authenticate(string userName, string mail, string password);

        public UserDto Login(string userName, string mail, string password);

    }
}
