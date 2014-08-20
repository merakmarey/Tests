using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;
using DishSorter.Application.Interfaces;

namespace DishSorter.Application.Tests
{
    [TestClass]
    public class MenuTests
    {
        [TestMethod]
        public void GetItem_WithMorningAndValidTypeOrderId_ShouldReturnTheItem()
        {

            // Arrange 
            // IoC Setup
            IKernel kernel = new StandardKernel(new DishSorterModule());
            var timeOfTheDay = Enums.TimeOfDay.Morning;

            // Act
            // Get Item
            var menu = kernel.Get<IMenu>();
            var result = menu.GetItem(timeOfTheDay, 1);

            var stringResult = result.Name;

            // Assert
            Assert.AreEqual("egg", stringResult);

        }

        [TestMethod]
        public void GetItem_WithNightAndValidTypeOrderId_ShouldReturnTheItem()
        {
            // Arrange 
            // IoC Setup
            IKernel kernel = new StandardKernel(new DishSorterModule());
            var timeOfTheDay = Enums.TimeOfDay.Night;

            // Act
            // Get Item
            var menu = kernel.Get<IMenu>();
            var result = menu.GetItem(timeOfTheDay, 1);

            var stringResult = result.Name;

            // Assert
            Assert.AreEqual("steak", stringResult);
        }


        [TestMethod]
        public void GetItem_WithMorningAndInvalidTypeOrderId_ShouldReturnNull()
        {
            // Arrange 
            // IoC Setup
            IKernel kernel = new StandardKernel(new DishSorterModule());
            var timeOfTheDay = Enums.TimeOfDay.Morning;

            // Act
            // Get Item
            var menu = kernel.Get<IMenu>();
            var result = menu.GetItem(timeOfTheDay, 4);

            // Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void GetItem_WithNightAndInvalidTypeOrderId_ShouldReturnNull()
        {
            // Arrange 
            // IoC Setup
            IKernel kernel = new StandardKernel(new DishSorterModule());
            var timeOfTheDay = Enums.TimeOfDay.Night;

            // Act
            // Get Item
            var menu = kernel.Get<IMenu>();
            var result = menu.GetItem(timeOfTheDay,5);

            // Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void GetItem_WithUnknownTimeOfDayAndAnyTypeOrderId_ShouldReturnNull()
        {
            // Arrange 
            // IoC Setup
            IKernel kernel = new StandardKernel(new DishSorterModule());
            var timeOfTheDay = Enums.TimeOfDay.Unknown;

            // Act
            // Get Item
            var menu = kernel.Get<IMenu>();
            var result = menu.GetItem(timeOfTheDay, 1);

            // Assert
            Assert.IsNull(result);
        }
    }
}
