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
    public class RegisterViewModel
    {
        public Prop<string> Email { get; set; } = new Prop<string>();
        public Prop<string> Password { get; set; } = new Prop<string>();
        public Prop<string> Username { get; set; } = new Prop<string>();
        public Prop<string> FirstName { get; set; } = new Prop<string>();
        public Prop<string> LastName { get; set; } = new Prop<string>();
        public Prop<bool> ButtonEnabled { get; set; } = new Prop<bool>();
        public Prop<bool> InvalidCredentials { get; set; } = new Prop<bool>();

        public RegisterViewModel()
        {
            RegisterCommand = new Command(Register);

            Email.OnChange = Validate;
            Password.OnChange = Validate;
            Username.OnChange = Validate;
            FirstName.OnChange = Validate;
            LastName.OnChange = Validate;
            ButtonEnabled.Value = true;
        }

        private void Validate()
        {
            RegisterViewModelValidator validator = new RegisterViewModelValidator();
            ValidationResult result = validator.Validate(this);

            Email.Error = result.GetError("Email");
            Password.Error = result.GetError("Password");
            Username.Error = result.GetError("Username");
            FirstName.Error = result.GetError("FirstName");
            LastName.Error = result.GetError("LastName");

            ButtonEnabled.Value = result.IsValid;
        }

        public ICommand RegisterCommand { get; }

        private async void Register()
        {
            string email = Email.Value;
            string password = Password.Value;
            string firstName = FirstName.Value;
            string lastName = LastName.Value;
            string username = Username.Value;

            try
            {
                // Assuming Api.Client handles all API requests


                RestRequest request = new RestRequest("Users", Method.Post);
                request.AddJsonBody(new { email, username, firstName, lastName, password });

                RestResponse response = await Api.Client.ExecuteAsync(request);

                if (response.StatusCode == System.Net.HttpStatusCode.Created)
                {
                    InvalidCredentials.Value = false;
                    App.Current.MainPage = new Login(); // Navigate to the login page or the main page
                }
                else
                {
                    InvalidCredentials.Value = true;
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions such as network errors
                InvalidCredentials.Value = true;
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
