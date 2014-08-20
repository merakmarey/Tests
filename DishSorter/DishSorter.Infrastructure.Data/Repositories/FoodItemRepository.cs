using System.Collections.Generic;
using DishSorter.Application.Enums;
using DishSorter.Application.Interfaces;
using DishSorter.Application.Models;

namespace DishSorter.Infrastructure.Data.Repositories
{
    public class FoodItemRepository : IRepository<FoodItem>
    {
        /*
         * 
         * To fully complain with maintainability this data should be external, 
         * even when it was not specified on the requirements. Let's YAGNI for now..
         * 
         * */
        public IEnumerable<FoodItem> ReadAll()
        {
            yield return new FoodItem()
            {
                Name = "egg",
                TimeOfDay = TimeOfDay.Morning,
                Type = FoodItemType.Entree,
                AllowMultiple = false,
                TypeOrderId = 1
            };

            yield return new FoodItem()
            {
                Name = "Toast",
                TimeOfDay = TimeOfDay.Morning,
                Type = FoodItemType.Side,
                AllowMultiple = false,
                TypeOrderId = 2
            };

            yield return new FoodItem()
            {
                Name = "coffee",
                TimeOfDay = TimeOfDay.Morning,
                Type = FoodItemType.Drink,
                AllowMultiple = true,
                TypeOrderId = 3
            };

            yield return new FoodItem()
            {
                Name = "steak",
                TimeOfDay = TimeOfDay.Night,
                Type = FoodItemType.Entree,
                AllowMultiple = false,
                TypeOrderId = 1
            };

            yield return new FoodItem()
            {
                Name = "potato",
                TimeOfDay = TimeOfDay.Night,
                Type = FoodItemType.Side,
                AllowMultiple = true,
                TypeOrderId = 2
            };

            yield return new FoodItem()
            {
                Name = "wine",
                TimeOfDay = TimeOfDay.Night,
                Type = FoodItemType.Drink,
                AllowMultiple = false,
                TypeOrderId = 3
            };

            yield return new FoodItem()
            {
                Name = "cake",
                TimeOfDay = TimeOfDay.Night,
                Type = FoodItemType.Dessert,
                AllowMultiple = false,
                TypeOrderId = 4
            };
        }
    }
}
