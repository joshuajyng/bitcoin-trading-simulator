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
        //Insert your Private Key from coinmarketcap here
        private string url = "https://pro-api.coinmarketcap.com/v1/cryptocurrency/listings/latest?start=1&limit=1&convert=USD&CMC_PRO_API_KEY=";

        
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
