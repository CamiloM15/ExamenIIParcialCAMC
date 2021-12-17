using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
namespace ExamenIIParcialCAMC.Classes
{
    class ReporteManager
    {
        private HttpClient getCliente()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Add("Connection", "close");
            return client;
        }


        public async Task<IEnumerable<Reporte>> VerReporte(string rne)
        {
            HttpClient client = getCliente();
            var res = await client.GetAsync(App.url + "verReporte.php?rne=" + rne);
            if (res.IsSuccessStatusCode)
            {
                string content = await res.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IEnumerable<Reporte>>(content);
            }
            return Enumerable.Empty<Reporte>();
        }
    }
}
