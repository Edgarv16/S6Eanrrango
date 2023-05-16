using Newtonsoft.Json;
using S6Eanrrango.Ws;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific.AppCompat;

namespace S6Eanrrango
{
    public partial class MainPage : ContentPage
    {
        private const string Url = "http://192.168.1.4/moviles/post.php";  
        private readonly HttpClient client = new HttpClient();
       // private ObservableCollection<S6Eanrrango.Ws.Datos> _post;
        private ObservableCollection<S6Eanrrango.Ws.Datos> _post;


        public MainPage()
        {
            InitializeComponent();
            Obtener();         
        }

        private async void btnGet_Clicked(object sender, EventArgs e)
        {
            var content = await client.GetStringAsync(Url);
            List<S6Eanrrango.Ws.Datos> posts = JsonConvert.DeserializeObject<List<S6Eanrrango.Ws.Datos>>(content);
            _post = new ObservableCollection<S6Eanrrango.Ws.Datos>(posts);

            MyListView.ItemsSource = _post;

        }

        public async void Obtener()
        {
            var content = await client.GetStringAsync(Url);
            List<S6Eanrrango.Ws.Datos> posts = JsonConvert.DeserializeObject<List<S6Eanrrango.Ws.Datos>>(content);
            _post = new ObservableCollection<S6Eanrrango.Ws.Datos>(posts);

            MyListView.ItemsSource = _post;
        }

        // private void btnRegistro_Clicked(object sender,EventArgs e)
        //{
        //var mensaje = "BIENVENIDO";
        //DependencyService.Get<mensaje>().longAlert(mensaje);
        //NavigationPage.PushAsync(new Registro);
        //}

        private void MyListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var obj = (Datos)e.SelectedItem;

            if (!string.IsNullOrEmpty(obj.codigo.ToString()))
            {
                if (obj != null)
                {

                    Navigation.PushAsync(new Registro(obj));
                }

            }
        }

    }
}
