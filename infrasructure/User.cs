namespace WebApplication1.infrasructure
{
    public class User
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public User(string Id,string Name,string Email,string Password) { 
            this.Id = Id;
            this.Name = Name;
            this.Email = Email;
            this.Password = Password;
        }

    }
}
