using ExamenIIParcialCAMC.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ExamenIIParcialCAMC
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Reporte : ContentPage
    {
        public Reporte()
        {
            InitializeComponent();
        }

        public async void VerReporte(string rne1)
        {
            try
            {
                ReporteManager manager = new ReporteManager();
                var res = await manager.VerReporte(rne1);
                if (res != null)
                {
                    lstEstudents.ItemsSource = res;
                }
                
            }
            catch (Exception e)
            {
                await DisplayAlert("Mensaje de Error", e.Message.ToString(), "OK");
            }
        }
        private void ReporteClick(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtAlumno_rne.Text))
            {

            }
            else VerReporte(txtAlumno_rne.Text);
        }

    }
}