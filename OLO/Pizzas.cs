using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OLO.Entities;
using OLO.Services.OloServiceClient;
namespace OLO
{
    public class Pizzas
    {
        public ToppingReport GetPopularToppingReport()
        {
            ToppingReport toppingReport = null;
            try
            {
                PizzaServiceClient pizzaServiceClient = new PizzaServiceClient();
                List<Pizza> pizzaList = pizzaServiceClient.GetPizzaList();
                if (pizzaList != null)
                {
                    if (pizzaList.Count > 0)
                    {
                        toppingReport = new ToppingReport();

                        List<string> pizzaToppingList = new List<string>();
                        List<string> pizzaToppingCombinationList = new List<string>();
                        foreach (Pizza pizza in pizzaList)
                        {
                            if (pizza.Toppings != null)
                            {

                                if (pizza.Toppings.Count > 0)
                                {
                                    //only add combinations to this list
                                    if (pizza.Toppings.Count > 1)
                                    {
                                        pizzaToppingCombinationList.Add(String.Join(",", pizza.Toppings.OrderBy(s => s).ToArray()));
                                    }
                                    pizzaToppingList.AddRange(pizza.Toppings);
                                }
                            }
                        }

                        if (pizzaToppingList.Count > 0)
                        {
                            toppingReport.popularToppingList = pizzaToppingList.GroupBy(s => s).Select((t, index) => new PopularTopping {  Name = t.Key, Count = t.Count() }).OrderByDescending(pt => pt.Count).ToList();
                            toppingReport.popularToppingList = toppingReport.popularToppingList.Select((t, index) => new PopularTopping { Rank = index+1, Name = t.Name, Count = t.Count }).OrderBy(pt => pt.Rank).ToList();

                        }
                        if (pizzaToppingList.Count > 0)
                        {
                            toppingReport.popularToppingCombinationList = pizzaToppingCombinationList.GroupBy(s => s).Select((t, index) => new PopularTopping { Rank = index, Name = t.Key, Count = t.Count() }).OrderByDescending(pt => pt.Count).ToList();
                            toppingReport.popularToppingCombinationList = toppingReport.popularToppingCombinationList.Select((t, index) => new PopularTopping { Rank = index + 1, Name = t.Name, Count = t.Count }).OrderBy(pt => pt.Rank).ToList();

                        }
                    }

                }
            }
            catch (Exception exc)
            {
                throw exc;
            }
            return toppingReport;
        }
    }
}
