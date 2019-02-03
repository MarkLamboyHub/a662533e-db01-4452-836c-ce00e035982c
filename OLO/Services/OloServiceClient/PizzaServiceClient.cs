using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OLO.Entities;
using Newtonsoft.Json;
namespace OLO.Services.OloServiceClient
{
    public class PizzaServiceClient : BaseServiceClient
    {
        public List<Pizza> GetPizzaList()
        {
            List<Pizza> pizzaList = null;
            try
            {
                string responseString = this.SendWebRequest(Method.GET, "http://files.olo.com/pizzas.json", null).Result;
                if (!string.IsNullOrEmpty(responseString))
                {
                    pizzaList = JsonConvert.DeserializeObject<List<Pizza>>(responseString);
                }
            }
            catch (Exception exc)
            {
                throw exc;
            }
            return pizzaList;
        }
    }
}
