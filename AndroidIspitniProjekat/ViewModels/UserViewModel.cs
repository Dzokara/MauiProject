using AndroidIspitniProjekat.Business.DTO;
using AndroidIspitniProjekat.Common;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AndroidIspitniProjekat.ViewModels
{
    public class UserViewModel
    {
        public Prop<string> Username { get; set; } = new Prop<string>();

        public ICommand LogoutCommand { get; private set; }

        public UserViewModel()
        {
            LogoutCommand = new Command(OnLogout);
            var user = SecureStorage.Default.GetUser();

            Username.Value = user.Username;


        }

        private async void OnLogout()
        {
            string token = SecureStorage.Default.GetUser().Token;

            RestRequest request = new RestRequest("Auth", Method.Delete);

            var response = Api.Client.Execute<TokenDto>(request);

            SecureStorage.Default.Remove("token");

            App.Current.MainPage = new AuthorizationPage();
        }

    }
}
