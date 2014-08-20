using System.Collections.Generic;

namespace DishSorter.Application.Interfaces
{
    public interface IRepository<out T> where T : class
    {
        IEnumerable<T> ReadAll();
    }
}
 