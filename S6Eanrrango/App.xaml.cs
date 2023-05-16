using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace S6Eanrrango
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            //InitializeDatabase();

            MainPage = new NavigationPage(new Registro()); // se habilita la navegación en la ventana 
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
