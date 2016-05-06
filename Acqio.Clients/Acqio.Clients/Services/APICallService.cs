using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Acqio.Clients.Services
{
    public class APICallService
    {
        static readonly string ApiUrl = "http://192.168.0.12/Acqio/api/{0}";

        public async Task<ObservableCollection<T>> GetObservableCollectionAsync<T>(string method, string param) where T : class
        {
            List<T> list = await GetListAsync<T>(method, param);
            return new ObservableCollection<T>(list);
        }

        public async Task<List<T>> GetListAsync<T>(string method, string param) where T : class
        {

            var client = new System.Net.Http.HttpClient();

            //Definide o Header de resultado para JSON, para evitar que seja retornado um HTML ou XML
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            //Formata a Url com o metodo e o parametro enviado e inicia o acesso a Api. Como o acesso será por meio
            //da Internet, pode demorar muito, para que o aplicativo não trave usamos um método assincrono
            //e colocamos a keyword AWAIT, para que a Thread principal - UI - continuo sendo executada
            //e o método so volte a ser executado quando o download das informações for finalizado
            var response = await client.GetAsync(string.Format(ApiUrl + "/{1}", method, param));

            //Lê a string retornada
            var JsonResult = response.Content.ReadAsStringAsync().Result;

            if (typeof(T) == typeof(string))
                return null;

            //Converte o resultado Json para uma Classe utilizando as Libs do Newtonsoft.Json
            var rootobject = JsonConvert.DeserializeObject<List<T>>(JsonResult);

            return rootobject;
        }

        public async Task<T> GetAsync<T>(string method, string param) where T : class
        {

            var client = new System.Net.Http.HttpClient();

            //Definide o Header de resultado para JSON, para evitar que seja retornado um HTML ou XML
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            //Formata a Url com o metodo e o parametro enviado e inicia o acesso a Api. Como o acesso será por meio
            //da Internet, pode demorar muito, para que o aplicativo não trave usamos um método assincrono
            //e colocamos a keyword AWAIT, para que a Thread principal - UI - continuo sendo executada
            //e o método so volte a ser executado quando o download das informações for finalizado
            var response = await client.GetAsync(string.Format(ApiUrl + "/{1}", method, param));

            //Lê a string retornada
            var JsonResult = response.Content.ReadAsStringAsync().Result;

            if (typeof(T) == typeof(string))
                return null;

            //Converte o resultado Json para uma Classe utilizando as Libs do Newtonsoft.Json
            var rootobject = JsonConvert.DeserializeObject<List<T>>(JsonResult);

            return rootobject[0];
        }

        public async Task<string> PutAsync<T>(string method, string param, T item) where T : class
        {
            var client = new System.Net.Http.HttpClient();

            var json = JsonConvert.SerializeObject(item);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PutAsync(string.Format(ApiUrl + "/{1}", method, param), content);
            if (response.IsSuccessStatusCode)
            {
                return String.Empty;
            }
            else
            {
                string retorno = await response.Content.ReadAsStringAsync();
                return retorno;
            }
        }

        public async Task<string> PostAsync<T>(string method, T item) where T : class
        {
            var client = new System.Net.Http.HttpClient();

            var json = JsonConvert.SerializeObject(item);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync(string.Format(ApiUrl, method), content);
            if (response.IsSuccessStatusCode)
            {
                return String.Empty;
            }
            else
            {
                string retorno = await response.Content.ReadAsStringAsync();
                return retorno;
            }
        }
    }
}
