using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace VargasCristianTareaS6
{
    public partial class MainPage : ContentPage
    {
        private const string Url = "http://192.168.227.161/moviles/post.php";
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<VargasCristianTareaS6.GET> _post;

        public MainPage()
        {
            InitializeComponent();

        }


        private async void btnGet_Clicked(object sender, EventArgs e)
        {
            try
            {
                var content = await client.GetStringAsync(Url);
                List<VargasCristianTareaS6.GET> posts = JsonConvert.DeserializeObject<List<VargasCristianTareaS6.GET>>(content);
                _post = new ObservableCollection<VargasCristianTareaS6.GET>(posts);

                MylistView.ItemsSource = _post;
            }
            catch (Exception ex)
            {

                DisplayAlert("Alerta", ex.Message, "ok");
            }

        }

        private async void btnInsertar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Insertar());
        }

        private async void btnActualizar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Actualizar());
        }

        private async void btnEliminar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Eliminar());
        }
    }
}
