namespace Gift_Ideas.ViewModels
{
    public class UserRegisterViewModel
    {
        public string Email { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public UserRegisterViewModel()
            : this(string.Empty, string.Empty, string.Empty)
        {
        }

        public UserRegisterViewModel(string email, string password, string username)
        {
            this.Email = email;
            this.Password = password;
            this.Username = username;
        }
    }
}