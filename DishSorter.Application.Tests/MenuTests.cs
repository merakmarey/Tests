using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DishSorter.Application.Tests
{
    [TestClass]
    public class MenuTests
    {
        [TestMethod]
        public void GetItem_WithMorningAndValidTypeOrderId_ShouldReturnTheItem()
        {
            // Arrange
            // Act
            // Assert
        }

        [TestMethod]
        public void GetItem_WithNightAndValidTypeOrderId_ShouldReturnTheItem()
        {
            // Arrange
            // Act
            // Assert
        }


        [TestMethod]
        public void GetItem_WithMorningAndInalidTypeOrderId_ShouldReturnNull()
        {
            // Arrange
            // Act
            // Assert
        }

        [TestMethod]
        public void GetItem_WithNightAndInalidTypeOrderId_ShouldReturnNull()
        {
            // Arrange
            // Act
            // Assert
        }

        [TestMethod]
        public void GetItem_WithUnknownTimeOfDayAndAnyTypeOrderId_ShouldReturnNull()
        {
            // Arrange
            // Act
            // Assert
        }
    }
}
