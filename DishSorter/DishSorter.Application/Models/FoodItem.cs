using DishSorter.Application.Enums;

namespace DishSorter.Application.Models
{
    public class FoodItem
    {
        public int TypeOrderId { get; set; }
        public TimeOfDay TimeOfDay { get; set; }
        public string Name { get; set; }
        public FoodItemType Type { get; set; }
        public int Count { get; set; }
        public bool AllowMultiple { get; set; }
    }
}
