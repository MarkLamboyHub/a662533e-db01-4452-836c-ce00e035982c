using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OLO.Entities;
namespace OLO
{
    class Program
    {
        static void Main(string[] args)
        {
            renderToppingReport();
        }
        static void renderToppingReport()
        {
            Console.WriteLine("Popular Topping Report");
            Console.WriteLine(" ");
            Pizzas pizzas = new Pizzas();
            Console.WriteLine("Getting topping data from OLO");
            Console.WriteLine("\r\n");
            ToppingReport toppingReport = pizzas.GetPopularToppingReport();
            Console.WriteLine("Here is your report :)");
            Console.WriteLine("\r\n");
            Console.WriteLine("Top 20 Topping Combinations");
            Console.WriteLine("\r\n");
            foreach (PopularTopping popularTopping in toppingReport.popularToppingCombinationList.Take(20))
            {
                Console.WriteLine(string.Format("Rank: {0} | Combination: {1} | Count {2}", popularTopping.Rank, popularTopping.Name, popularTopping.Count));

            }
            Console.WriteLine("\r\n");
            Console.WriteLine("Top 20 Toppings");
            Console.WriteLine("\r\n");
            foreach (PopularTopping popularTopping in toppingReport.popularToppingList.Take(20))
            {
                Console.WriteLine(string.Format("Rank: {0} | Topping: {1} | Count {2}", popularTopping.Rank, popularTopping.Name, popularTopping.Count));

            }
            Console.WriteLine("\r\n");
            Console.WriteLine("Hit Enter to Close Application ");
            Console.ReadLine();
        }
    }
}
