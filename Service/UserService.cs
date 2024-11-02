using WebApplication1.infrasructure;
using WebApplication1.Models;

namespace WebApplication1.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        public UserService(IUserRepository userRepository) { 
            _repository = userRepository;
        }
        public bool Authenticate(string userName,string mail, string password)
        {
            var user=_repository.GetAll().FirstOrDefault(u => u.Name==userName && u.Email==mail && u.Password==password );
            return user != null;

        }

        public UserDto Login(string userName,string mail, string password)
        {
            if (Authenticate(userName, mail, password))
            {
               return new UserDto(userName, mail, password);
            }
            throw new Exception("cet utilisateur n'existe pas deja");
        }

        public void Register(string userName,string mail, string password)
        {
            if (!Authenticate(userName, mail, password))
            {
                _repository.CreateUser(userName, mail, password);
            }
            throw new Exception("cet utilisateur existe deja");
            
        }
    }
}
