using DishSorter.Application.Enums;
using DishSorter.Application.Models;

namespace DishSorter.Application.Interfaces
{
    public interface IMenu
    {
        FoodItem GetItem(TimeOfDay timeOfDay, int typeOrderId);
    }
}
 