using System.Net.Http.Headers;

namespace Proyecto_tortas.app.Pages;


public partial class Lista_comida : ContentPage
{
    HttpClient client = new HttpClient();

    public Lista_comida()
	{
		InitializeComponent();

	}

	private async void Get_Comidas()
	{
		var token = await SecureStorage.GetAsync("Token");
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
		string url = "lsiajavier.database.windows.net/api/Alimento";
    }

	private void btnIzq_Clicked(object sender, EventArgs e)
	{

	}

	private void btnDer_Clicked(object sender, EventArgs e)
	{

	}
}