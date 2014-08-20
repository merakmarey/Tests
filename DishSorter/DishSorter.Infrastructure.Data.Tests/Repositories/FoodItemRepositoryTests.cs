using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DishSorter.Infrastructure.Data.Repositories;
using System.Collections.Generic;

namespace DishSorter.Infrastructure.Data.Tests.Repositories
{
    [TestClass]
    public class FoodItemRepositoryTests
    {
        [TestMethod]
        public void ReadAll_ShouldReturnAnEnumerableOfFoodItem()
        {
            
            // Arrange
            var foodRepository = new FoodItemRepository();
            var allFoodItems = foodRepository.ReadAll();
            // Act

            var result = allFoodItems.Select(n => n.Name).ToList();
            var stringResult = String.Join(",", result);
            var needle = "egg,Toast,coffee,steak,potato,wine,cake";
            // Assert
            Assert.AreEqual(needle,stringResult);
        }
    }
}
