using Newtonsoft.Json;
using Proyecto_tortas.app.Pages;
using System.Text;

namespace Proyecto_tortas.app
{
    public partial class MainPage : ContentPage
    {
        private readonly HttpClient _httpClient = new HttpClient();
        

        public MainPage()
        {
            InitializeComponent();

        }

        private void btnLogin_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new NavigationPage(new Menu());
        }

        private async void btnRegister_Clicked(object sender, EventArgs e)
        {
            /*if(txtUser.Text == null || txtEmail == null || txtPassword == null)
            {
                await DisplayAlert("Error", "Rellena todos los campos", "OK");
            }
            else
            {
                User user = new User()
                {
                    UserName = txtUser.Text,
                    Email = txtEmail.Text,
                    Password = txtPassword.Text,
                };

                string json = JsonConvert.SerializeObject(user);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                string url = "https://guiajavier.azurewebsites.net/api/User/registrar";

                var response = await _httpClient.GetAsync(url, content);

            }*/
        }
    }
}