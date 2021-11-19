using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ExamenIIParcialCAMC
{
    public partial class App : Application
    {
        public static string url;
        public App()
        {
            InitializeComponent();
            url = "https://examenmovil2.000webhostapp.com/Examen2/";
            MainPage = new NavigationPage(new MainPage());
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
