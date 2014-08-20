using System.Collections.Generic;
using System.Linq;
using DishSorter.Application.Enums;
using DishSorter.Application.Interfaces;
using DishSorter.Application.Models;

namespace DishSorter.Application
{
    public class DishSorter : IDishSorter
    {
        #region Fields
        private readonly IMenu _menu;
        #endregion // Fields

        #region Constructors
        public DishSorter(IMenu menu)
        {
            _menu = menu;
        }
        #endregion // Constructors

        #region IDishSorter implementation

        public List<string> SortDishes(TimeOfDay timeOfDay, IEnumerable<int> foodItemList)
        {
            // create error element and ensure it's the last 
            var errorMenuItem = new FoodItem()
            {
                Name = "error",
                Type = FoodItemType.Unknown,
                AllowMultiple = false,
                TypeOrderId = foodItemList.Count() + 1
            };

            var foodItems = new List<FoodItem>();

            foreach (var typeOrderId in foodItemList)
            {
                var item = _menu.GetItem(timeOfDay, typeOrderId);
                if (item != null)
                {

                    if (foodItems.Any(x => x.TypeOrderId == typeOrderId))
                    {
                        // the item it's already part of the result
                        if (item.AllowMultiple)
                        {
                            var seekElement = foodItems.Where(f => f.Name == item.Name).First();
                            // the item can exist multiple times, increase element counter
                            foodItems[foodItems.IndexOf(seekElement)].Count++;
                        }
                        else
                        {
                            // item cannot exist more than once
                            foodItems.Add(errorMenuItem);
                            break;
                        }
                    }
                    else
                    {
                        // Item doesnt exist on the results, add it
                        foodItems.Add(item);
                    }
                }
                else
                {
                    // non existent item
                    foodItems.Add(errorMenuItem);
                    break;
                }
            }
            
            return foodItems.OrderBy(x => x.TypeOrderId).Select(FormatName).ToList();
        }

        #endregion // IDishSorter implementation

        #region Private Methods

        private static string FormatName(FoodItem foodItem)
        {
            var result = foodItem.Name;
            if (foodItem.Count > 0)
                result += string.Format(" (x{0})", foodItem.Count+1);

            return result;
        }
        #endregion // Private Methods
    }
}
