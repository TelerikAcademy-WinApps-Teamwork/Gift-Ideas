using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Parse;
using Gift_Ideas.ViewModels;
using System.Net;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Gift_Ideas.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class RegisterPage : Page
    {
        public RegisterPage()
        {
            this.InitializeComponent();
        }

        private void OnLoginButtonClick(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(LoginPage), null);
        }

        private async void OnRegisterButtonClick(object sender, RoutedEventArgs e)
        {
            var user = this.DataContext as UserRegisterViewModel;

            if (user.Username == string.Empty)
            {
                this.Toast.Message = "Please enter username!";
                return;
            }
            else if (user.Email == string.Empty)
            {
                this.Toast.Message = "Please enter email!";
                return;
            }
            else if (user.Password == string.Empty)
            {
                this.Toast.Message = "Please enter password!";
                return;
            }

            var newUser = new ParseUser
            {
                Username = user.Username,
                Email = user.Email,
                Password = user.Password
            };

            try
            {
                await newUser.SignUpAsync();
            }
            //catch (ParseException ex)
            //{
            //    if (ex.Code == ParseException.ErrorCode.UsernameTaken)
            //    {
            //        this.Toast.Message = "Username is already taken!";
            //    }
            //    else if (ex.Code == ParseException.ErrorCode.UsernameMissing)
            //    {
            //        this.Toast.Message = "Please enter username!";
            //    }
            //    else if (ex.Code == ParseException.ErrorCode.EmailMissing)
            //    {
            //        this.Toast.Message = "Please enter email!";
            //    }
            //    else if (ex.Code == ParseException.ErrorCode.EmailTaken)
            //    {
            //        this.Toast.Message = "Email is already taken!";
            //    }
            //    else if (ex.Code == ParseException.ErrorCode.PasswordMissing)
            //    {
            //        this.Toast.Message = "Please enter password!";
            //    }
            //    else if (ex.Code == ParseException.ErrorCode.ConnectionFailed)
            //    {
            //        this.Toast.Message = "The server is unavailable at the moment!";
            //    }
            //    return;
            //}
            catch (WebException ex)
            {
                this.Toast.Message = "Username or email is already taken!";
                return;
            }
            catch (Exception ex)
            {
                this.Toast.Message = "No internet connection!";
                return;
            }

            this.Frame.Navigate(typeof(LoginPage), null);
        }
    }
}
