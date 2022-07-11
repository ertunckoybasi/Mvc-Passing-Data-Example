using Bogus;
using MvcPassingDataExample.Models;
using System;
using System.Collections;
using System.Collections.Generic;

namespace MvcPassingDataExample.Services
{
    public class DataService : IDataService
    {
        public IEnumerable<Employee> GetEmployees()
        {
            var employeeFaker = new Faker<Employee>("en")
            .RuleFor(i => i.Id, i => i.IndexFaker)
            .RuleFor(i => i.FirstName, i => i.Name.FirstName().ToString())
            .RuleFor(i => i.LastName, i => i.Person.LastName)
            .RuleFor(i => i.JobTitle, i => i.Name.JobType().ToString())
            .RuleFor(i => i.JobDescription, i => i.Name.JobDescriptor().ToString());

            List<Employee> employees = employeeFaker.Generate(10);
            return employees;
        }
        public IEnumerable<Product> GetProducts()
        {
            var productFaker = new Faker<Product>("en")
           .RuleFor(i => i.Id, i => i.IndexFaker)
           .RuleFor(i => i.Name, i => i.Commerce.ProductName())
           .RuleFor(i => i.Description, i => i.Commerce.ProductDescription())
           .RuleFor(i => i.PictureUri, i => i.Image.PicsumUrl())
           .RuleFor(i => i.Price, i => Convert.ToDecimal(i.Commerce.Price(4, 5000, 2)))
           .RuleFor(i => i.Category, i => i.Commerce.Categories(1)[0]);

            List<Product> products = productFaker.Generate(10);
            return products;
        }


    }
}
