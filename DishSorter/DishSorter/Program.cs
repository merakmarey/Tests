using System;
using DishSorter.Application.Interfaces;
using Ninject;

namespace DishSorter
{
    class Program
    {
        static void Main(string[] args)
        {
            // IoC Setup
            IKernel kernel = new StandardKernel(new DishSorterModule());
            var ui = kernel.Get<IUserInterface>();
            
            // Get & Process input
            ui.ProcessInput();
            var timeOfTheDay = ui.GetTimeOfTheDay();
            var dishes = ui.GetDishes();

            // Sort Dishes
            var dishSorter = kernel.Get<IDishSorter>();
            var result = dishSorter.SortDishes(timeOfTheDay, dishes);
            
            // Output
            Console.WriteLine(String.Join(",", result));
            Console.ReadLine();
        }
    }
}
