using System.Collections.Generic;
using DishSorter.Application.Enums;

namespace DishSorter.Application.Interfaces
{
    public interface IDishSorter
    {
       List<string> SortDishes(TimeOfDay timeOfDay, IEnumerable<int> foodItemsInput);
    }
}
 