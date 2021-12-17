using ExamenIIParcialCAMC.Classes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ExamenIIParcialCAMC
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Parentezco : ContentPage
    {
        List<Parentesco> lm = new List<Parentesco>();
        public Parentezco( )
        {
            InitializeComponent();
            llenarParentesco();
        }

        async void llenarParentesco()
        {
            lm.Clear();
            HttpClient cliente = new HttpClient();
            HttpResponseMessage response = new HttpResponseMessage();
            response = await cliente.GetAsync(App.url + "verTipo.php");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                lm = JsonConvert.DeserializeObject<List<Parentesco>>(content);

                //Llenar el ComboBox con List solamente con una variable.
                foreach (var objeto in lm)
                {
                    cbotipo.Items.Add(objeto.tipoParentesco);

                }
            }

        }

        private void Button_Clicked(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtIdParentezco.Text))
            {

            }
            else if (string.IsNullOrEmpty(txtNombreParentezco.Text))
            {

            }
            else if (string.IsNullOrEmpty(txtTelefonoParentezco.Text))
            {

            }
            else if (string.IsNullOrEmpty(txtDireccion.Text))
            {

            }
            else if (string.IsNullOrEmpty(txtAlumnoRne.Text))
            {

            }

            else
            {
                int indexp = cbotipo.SelectedIndex;
                Parentesco p = lm[indexp];
                string codigop = p.idTipo;

                WebClient cliente = new WebClient();
                var parametros = new System.Collections.Specialized.NameValueCollection();
                parametros.Add("idParentezco", txtIdParentezco.Text);
                parametros.Add("nombreParentezco", txtNombreParentezco.Text);
                parametros.Add("TelefonoParentezco", txtTelefonoParentezco.Text);
                parametros.Add("direccion", txtDireccion.Text);
                parametros.Add("idTipo", codigop.ToString());
                parametros.Add("alumno_rne", txtAlumnoRne.Text);





                byte[] response = cliente.UploadValues(App.url + "insertParentezco.php", "POST", parametros);
                string c = Encoding.ASCII.GetString(response);

                if (c.Equals("1"))
                {
                    DisplayAlert("Informacion", "Se almacenó Satisfactoriamente", "OK");
                    txtIdParentezco.Text = "";
                    txtNombreParentezco.Text = "";
                    txtTelefonoParentezco.Text = "";
                    txtDireccion.Text = "";
                    txtAlumnoRne.Text = "";

                }
                else
                {
                    DisplayAlert("Informacion", "Error al almacenar Parentesco", "OK");
                }
            }
        }
    }
}