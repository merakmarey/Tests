using System.Collections.Generic;
using System.Linq;
using DishSorter.Application.Enums;
using DishSorter.Application.Interfaces;
using DishSorter.Application.Models;

namespace DishSorter.Application
{
    public class Menu : IMenu
    {
        #region Fields
        private IEnumerable<FoodItem> _foodItems;
        private readonly IRepository<FoodItem> _foodItemRepository;
        #endregion // Fields

        #region Constructors
        public Menu(IRepository<FoodItem> foodItemRepository)
        {
            _foodItemRepository = foodItemRepository;
        }
        #endregion // Constructors

        #region IMenu implementation

        public FoodItem GetItem(TimeOfDay timeOfDay, int typeOrderId)
        {
            if (_foodItems == null)
                _foodItems = _foodItemRepository.ReadAll();

            return _foodItems.FirstOrDefault(p => p.TimeOfDay == timeOfDay && p.TypeOrderId == typeOrderId);
        }

        #endregion // IMenu implementation
    }
}
