using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net.Http;
namespace OLO.Services.OloServiceClient
{
    public class BaseServiceClient
    {
        public enum Method { GET, POST, PUT, DELETE };

        public async Task<string> SendWebRequest(Method method, string url, string postData)
        {
            string responseString = string.Empty;
            try
            {
                HttpClient client = new HttpClient();
                DateTime requestDateTime = DateTime.Now;


                switch (method)
                {
                    case Method.GET:
                        using (var response = await client.GetAsync(url))
                        {
                            if (response.IsSuccessStatusCode)
                            {
                                // Horray it went well!
                                responseString = await response.Content.ReadAsStringAsync();

                            }
                        }
                        break;
                    case Method.POST:
                        StringContent queryString = new StringContent(postData);

                        using (var response = await client.PostAsync(url, queryString))
                        {
                            if (response.IsSuccessStatusCode)
                            {
                                // Horray it went well!
                                responseString = await response.Content.ReadAsStringAsync();

                            }
                        }
                        break;
                }

            }
            catch (Exception exc)
            {
                throw exc;
            }
            return responseString;
        }



    }
}
