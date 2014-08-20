using System;
using System.Collections.Generic;
using System.Linq;
using DishSorter.Application.Enums;
using DishSorter.Application.Interfaces;

namespace DishSorter
{
    internal class UserInterface : IUserInterface
    {
        private List<string> _userInputArray;

        public void ProcessInput()
        {
            Console.Write("Enter parameters :");
            var userInput = Console.ReadLine().ToLower();
            if (userInput != null)
                _userInputArray = userInput.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries).ToList();
        }

        public TimeOfDay GetTimeOfTheDay()
        {
            if (_userInputArray.Any())
            {
                TimeOfDay result;
                if (Enum.TryParse(_userInputArray[0], true, out result))
                    return result;
            }
              
            throw new Exception("Time of day can only be morning or night");
        }

        public IEnumerable<int> GetDishes()
        {
            if (_userInputArray.Count <= 1) 
                throw new ArgumentException("Missing dish selection");
            
            try
            {
                var sub = _userInputArray.GetRange(1, _userInputArray.Count - 1);
                return sub.ConvertAll(Int32.Parse);
            }
            catch 
            {
                throw new ArgumentException("Invalid Parameter conversion error");
            }
        }

    }
}
