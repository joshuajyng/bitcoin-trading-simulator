using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using A2.Models;
using Newtonsoft.Json;

namespace A2.Services
{
    public class btcapi
    {
        private string url = "https://pro-api.coinmarketcap.com/v1/cryptocurrency/listings/latest?start=1&limit=1&convert=USD&CMC_PRO_API_KEY=6cea20ec-185b-4ac6-b08f-7d999a457f70";

        
        public btcapi()
        {
          

        }
        protected HttpResponseMessage GET(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                var result = client.GetAsync(url);
                result.Wait();
                return result.Result;
            }
        }

        public Root getInfo()
        {
            var response = GET(url);

            string content = response.Content.ReadAsStringAsync().Result;
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return JsonConvert.DeserializeObject<Root>(content);
            }
            else
            {
                return null;
            }


        }

    }
    }
