using AndroidIspitniProjekat.Business.DTO;
using AndroidIspitniProjekat.Common;
using AndroidIspitniProjekat.Validators;
using FluentValidation.Results;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AndroidIspitniProjekat.ViewModels
{
    public class LoginViewModel
    {
        public Prop<string> Email { get; set; } = new Prop<string>();
        public Prop<string> Password { get; set; } = new Prop<string>();
        public Prop<bool> ButtonEnabled { get; set; } = new Prop<bool>();
        public Prop<bool> InvalidCredentials { get; set; } = new Prop<bool>();

        public LoginViewModel()
        {
            LoginCommand = new Command(Login);

            Email.OnChange = Validate;
            Password.OnChange = Validate;
            ButtonEnabled.Value = true;

            Email.Value = "djole@email";
            Password.Value = "Sifra123";
        }

        private void Validate()
        {
            LoginViewModelValidator validator = new LoginViewModelValidator();

            ValidationResult result = validator.Validate(this);

            if (!result.IsValid)
            {
                //GetError - nas extension metod
                Email.Error = result.GetError("Email");
                Password.Error = result.GetError("Password");
            }
            else
            {
                Email.Error = null;
                Password.Error = null;

                ButtonEnabled.Value = true;
            }
        }

        public ICommand LoginCommand { get; }

        private async void Login()
        {
            string email = Email.Value;
            string password = Password.Value;

            RestRequest request = new RestRequest("Auth", Method.Post);
            request.AddJsonBody(new { email, password });

            RestResponse<TokenDto> response = Api.Client.Execute<TokenDto>(request);

            if (response.IsSuccessful)
            {

                Task t = SecureStorage.Default.SetAsync("token", response.Data.Token);

                await t;

                AndroidIspitniProjekat.Business.DTO.User u = SecureStorage.Default.GetUser();

                InvalidCredentials.Value = false;
                if (u.Role == "user")
                {
                    App.Current.MainPage = new MainPage();
                }
                else
                {
                    App.Current.MainPage = new AdminPage();
                }
            }
            else
            {
                InvalidCredentials.Value = true;
            }
        }

    }
}
