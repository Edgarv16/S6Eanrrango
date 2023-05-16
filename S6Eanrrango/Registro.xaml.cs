using S6Eanrrango.Ws;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace S6Eanrrango
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Registro : ContentPage
	{
        

        public Registro ()
		{
			InitializeComponent ();
		}

        public Registro(Datos datos)
        {
            InitializeComponent();
            txtCodigo.Text = datos.codigo.ToString();
            txtNombre.Text = datos.nombre.ToString();
            txtApellido.Text = datos.apellido.ToString();
            txtEdad.Text = datos.edad.ToString(); 
        }


        private void btnInsertar_Clicked(object sender, EventArgs e)
        {
			try
			{
				WebClient cliente = new WebClient();
				var parametro = new System.Collections.Specialized.NameValueCollection();
				parametro.Add("codigo",txtCodigo.Text);
                parametro.Add("nombre", txtNombre.Text);
                parametro.Add("apellido", txtApellido.Text);
                parametro.Add("edad", txtEdad.Text);

				cliente.UploadValues("http://192.168.1.4/moviles/post.php","POST",parametro);
                DisplayAlert("ALERTA", "DATO INGRESADO", "Cerrar");

            }
			catch (Exception ex)
			{

				DisplayAlert("ALERTA", ex.Message,"Cerrar");
			}

        }

        private void btnRegresar_Clicked(object sender, EventArgs e)
        {
			Navigation.PushAsync(new MainPage());
        }

        private void btnActualizar_Clicked(object sender, EventArgs e)
        {
			try
			{

                WebClient cliente = new WebClient();
                var parametro = new System.Collections.Specialized.NameValueCollection();

                cliente.UploadValues("http://192.168.1.4/moviles/post.php?codigo="  + txtCodigo.Text + "&nombre=" + txtNombre.Text + "&apellido=" + txtApellido.Text + "&edad=" + txtEdad.Text, "PUT", parametro);
                DisplayAlert("ALERTA", "Dato Actualizado", "Cerrar");
                Navigation.PushAsync(new MainPage());

            }
			catch (Exception ex)
			{
                DisplayAlert("ALERTA", ex.Message, "Cerrar");
            }

        }

        private void btnEliminar_Clicked(object sender, EventArgs e)
        {
			try
			{
                WebClient cliente = new WebClient();
                var parametro = new System.Collections.Specialized.NameValueCollection();

                byte[] res = cliente.UploadValues("http://192.168.1.4/moviles/post.php?codigo=" + txtCodigo.Text, "DELETE", parametro);
                var r = System.Text.ASCIIEncoding.UTF8.GetString(res);
                DisplayAlert("ALERTA", "Dato Eliminado", "Cerrar");
                Navigation.PushAsync(new MainPage());
            }
			catch (Exception ex)
			{
                DisplayAlert("ALERTA", ex.Message, "Cerrar");

            }

        }
    }
}