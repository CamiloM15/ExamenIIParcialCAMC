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
    public partial class Lectivo : ContentPage
    {
        public Lectivo()
        {
            InitializeComponent();
        }
        private async void traerLista(String alectivo)
        {
            
            try
            {
                LectivoManager manager = new LectivoManager();
                var res = await manager.TraerLista(alectivo);
                if (res != null)
                {
                    lstEstudent.ItemsSource = res;
                }
            }
            catch (Exception e)
            {
                await DisplayAlert("Mensaje de Error", e.Message.ToString(), "OK");
            }
        }

        private void ListadoLectivo(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtAlectivo.Text))
            {

            }
            else traerLista(txtAlectivo.Text);
        }
    }
}