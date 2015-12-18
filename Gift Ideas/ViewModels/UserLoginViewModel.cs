namespace Gift_Ideas.ViewModels
{
    public class UserLoginViewModel
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public UserLoginViewModel() 
            :this(string.Empty, string.Empty)
        {
        }

        public UserLoginViewModel(string username, string password)
        {
            this.Username = username;
            this.Password = password;
        }
    }
}