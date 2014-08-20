using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using DishSorter.Application;
using DishSorter.Infrastructure.Data;
using Ninject;
using DishSorter.Application.Interfaces;

namespace DishSorter.Application.Tests
{
    [TestClass]
    public class DishSorterTests
    {
        [TestMethod]
        public void SortDishes_WithMorningAndValidSelection_ShouldReturnFoodItems()
        {
            // Arrange
            // IoC Setup
            IKernel kernel = new StandardKernel(new DishSorterModule());
            var timeOfTheDay = Enums.TimeOfDay.Morning;
            var dishes = new List<int>() { 1, 2, 3, 3 };

            // Act
            // Sort Dishes
            var dishSorter = kernel.Get<IDishSorter>();
            var result = dishSorter.SortDishes(timeOfTheDay, dishes);

            var stringResult = String.Join(",", result);

            // Assert
             Assert.AreEqual("egg,Toast,coffee (x2)",stringResult);
        }

        [TestMethod]
        public void SortDishes_WithNightAndValidSelection_ShouldReturnFoodItems()
        {
            // Arrange 
            // IoC Setup
            IKernel kernel = new StandardKernel(new DishSorterModule());
            var timeOfTheDay = Enums.TimeOfDay.Night;
            var dishes = new List<int>() { 1, 2, 3, 4, 2 };

            // Act
            // Sort Dishes
            var dishSorter = kernel.Get<IDishSorter>();
            var result = dishSorter.SortDishes(timeOfTheDay, dishes);

            var stringResult = String.Join(",", result);

            // Assert
            Assert.AreEqual("steak,potato (x2),wine,cake", stringResult);
        }

        [TestMethod]
        public void SortDishes_WithMorningAndSomeInvalidSelection_ShouldReturnErrorForInvalidSelectionOtherwiseFoodItems()
        {
            // Arrange 
            // IoC Setup
            IKernel kernel = new StandardKernel(new DishSorterModule());
            var timeOfTheDay = Enums.TimeOfDay.Morning;
            var dishes = new List<int>() { 1, 2, 3, 1 };

            // Act
            // Sort Dishes
            var dishSorter = kernel.Get<IDishSorter>();
            var result = dishSorter.SortDishes(timeOfTheDay, dishes);

            var stringResult = String.Join(",", result);

            // Assert
            Assert.AreEqual("egg,Toast,coffee,error", stringResult);
        }

        [TestMethod]
        public void SortDishes_WithNightAndSomeInvalidSelection_ShouldReturnErrorForInvalidSelectionOtherwiseFoodItems()
        {
            // Arrange 
            // IoC Setup
            IKernel kernel = new StandardKernel(new DishSorterModule());
            var timeOfTheDay = Enums.TimeOfDay.Night;
            var dishes = new List<int>() { 1, 2, 3, 4, 5 };

            // Act
            // Sort Dishes
            var dishSorter = kernel.Get<IDishSorter>();
            var result = dishSorter.SortDishes(timeOfTheDay, dishes);

            var stringResult = String.Join(",", result);

            // Assert
            Assert.AreEqual("steak,potato,wine,cake,error", stringResult);
        }
    }
}
