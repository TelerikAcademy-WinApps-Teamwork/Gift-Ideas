namespace Gift_Ideas.ViewModels
{
    public class UserLoginViewModel
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public UserLoginViewModel() 
            :this(string.Empty, string.Empty)
        {
        }

        public UserLoginViewModel(string email, string password)
        {
            this.Email = email;
            this.Password = password;
        }
    }
}