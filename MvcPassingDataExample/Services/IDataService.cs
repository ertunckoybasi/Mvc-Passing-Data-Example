using MvcPassingDataExample.Models;
using System.Collections.Generic;

namespace MvcPassingDataExample.Services
{
    public interface IDataService
    {
        IEnumerable<Product> GetProducts();
        IEnumerable<Employee> GetEmployees();
    }
}
