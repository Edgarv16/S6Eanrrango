using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using S6Eanrrango.Droid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
[assembly: Xamarin.Forms.Dependency(typeof(mensajeAndroid))] // Para que Este archivo sea considerado al momento de ejecutar el App 

namespace S6Eanrrango.Droid
{
    public class mensajeAndroid : mensaje
    {
        public void longAlert(string mensaje)
        {
            Toast.MakeText(Application.Context,mensaje,ToastLength.Long).Show();// 5 segundos
        }

        public void shortAlert(string mensaje)
        {
            Toast.MakeText(Application.Context, mensaje, ToastLength.Short).Show();// 3 segundos
        }
    }
}