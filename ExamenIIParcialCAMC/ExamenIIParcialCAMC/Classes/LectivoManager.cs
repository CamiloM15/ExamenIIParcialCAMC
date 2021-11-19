using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ExamenIIParcialCAMC.Classes
{
    class LectivoManager
    {
        private HttpClient getCliente()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Add("Connection", "close");
            return client;
        }

        public async Task<IEnumerable<Lectivo>> TraerLista(String alectivo)
        {
            HttpClient client = getCliente();
            var res = await client.GetAsync(App.url + "verLectivo.php?alectivo=" + alectivo);
            if (res.IsSuccessStatusCode)
            {
                string content = await res.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IEnumerable<Lectivo>>(content);
            }
            return Enumerable.Empty<Lectivo>();
        }
    }
}
