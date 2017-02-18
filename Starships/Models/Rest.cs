using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace Starships.Models
{
    public class Rest
    {
        public Rest()
        {

        }

        /// <summary>
        /// This method convert JSON to a any type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="input"></param>
        /// <returns></returns>
        public static T Deserialize<T>(string input)
        {
            return JsonConvert.DeserializeObject<T>(input);
        }

        /// <summary>
        /// Do post in SW API
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public GridDTO SendRequestion(string url)
        {
            var httpClient = new HttpClient();
            GridDTO gridDTO = new GridDTO();
            try
            {
                using (httpClient)
                {
                    httpClient.BaseAddress = new Uri(url);
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Accept-Encoding", "identity");

                    HttpResponseMessage response = new HttpResponseMessage();
                    response = httpClient.GetAsync(url).Result;

                    if (response.IsSuccessStatusCode)
                        return Deserialize<GridDTO>(response.Content.ReadAsStringAsync().Result);
                }
            }
            finally
            {
                if (httpClient != null)
                {
                    httpClient.Dispose();
                    httpClient = null;
                }
            }
            return gridDTO;
        }

    }
}