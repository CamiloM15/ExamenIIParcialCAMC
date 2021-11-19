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
    public partial class Alumnos : ContentPage
    {
        public Alumnos()
        {
            InitializeComponent();
        }

        private async void traerEstudiantes(string rne)
        {
            try
            {
                AlumnoManager manager = new AlumnoManager();
                var res = await manager.TraerEstudiantes(rne);
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

        private void BuscarAlumno(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtAlumno.Text))
            {

            }
            else traerEstudiantes(txtAlumno.Text);
        }
    }
}