using AndroidIspitniProjekat.Common;

namespace AndroidIspitniProjekat
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            var user = SecureStorage.Default.GetUser();

            if (user != null && user.Role == "user")
            {
                MainPage = new MainPage();
            }
            else if (user != null && user.Role == "admin")
            {
                MainPage = new AdminPage();
            }
            else
            {
                MainPage = new AuthorizationPage();
            }


            Application.Current.UserAppTheme = AppTheme.Light;
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            var window = base.CreateWindow(activationState);

            window.Width = 600;
            window.Height = 600;

            return window;
        }

        protected override void OnResume()
        {
            base.OnResume();
        }
    }
}
