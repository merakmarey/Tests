
using System.Collections.Generic;
using DishSorter.Application.Enums;

namespace DishSorter.Application.Interfaces
{
    public interface IUserInterface
    {
        void ProcessInput();
        IEnumerable<int> GetDishes();
        TimeOfDay GetTimeOfTheDay();
    }
}
