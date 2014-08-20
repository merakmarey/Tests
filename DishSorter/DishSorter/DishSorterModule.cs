
using DishSorter.Application;
using DishSorter.Application.Interfaces;
using DishSorter.Application.Models;
using DishSorter.Infrastructure.Data.Repositories;
using Ninject.Modules;

namespace DishSorter
{
    public class DishSorterModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IRepository<FoodItem>>().To<FoodItemRepository>();
            Bind<IMenu>().To<Menu>();
            Bind<IUserInterface>().To<UserInterface>();
            Bind<IDishSorter>().To<Application.DishSorter>();
        }
    }
}
