using System;
using Xunit;
using Vacation.Models;
using Moq;
using Vacation.Controllers;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http;
using System.Web.Http.Results;
using Microsoft.EntityFrameworkCore;

namespace XUnitTestVacation
{
    public class UnitTestVacation
    {
        private VacationDBContext GetContextWithData()
        {
            var options = new DbContextOptionsBuilder<VacationDBContext>()
                     .UseInMemoryDatabase(Guid.NewGuid().ToString())
                     .Options;
            var context = new VacationDBContext(options);

            var Country1 = new Country { Id = 1, Name = "USA" };
            var Country2 = new Country { Id = 2, Name = "Italy" };
            context.Countries.Add(Country1);
            context.Countries.Add(Country2);

            context.Cities.Add(new City { Id = 1, Name = "Texas", Country = Country1 });
            context.Cities.Add(new City { Id = 2, Name = "NewYork", Country = Country1 });
            context.Cities.Add(new City { Id = 3, Name = "Madtid", Country = Country2 });
            context.Cities.Add(new City { Id = 4, Name = "Rym", Country = Country1 });

            context.SaveChanges();

            return context;
        }

        [Fact]
        public async void Test1()
        {
            var context = GetContextWithData();
            var controller = new CitiesController(context);
            var city = new City { Id = 4, Name = "RRRym", CountryId = 2};

            var result = await controller.PutCity(3, city);
            var ans = context.Cities.Where(a => a.Name == "RRRym").ToList();
            var size = ans.Count;

            Assert.Equal(0, size);
        }

        [Fact]
        public void Test2()
        {
            var context = GetContextWithData();
            var controller = new CountriesController(context);
            var Country = new Country{ Id = 3, Name = "Canada" };

            var result = controller.PostCountry(Country) as IEnumerable<Country>;

            Assert.Null(result);
        }
        

        [Fact]
        public void GetCategoriesNotNull()
        {
            var context = GetContextWithData();
            var controller = new CountriesController(context);
            
            var result = controller.GetCountry(-1) as IEnumerable<Country>;

            Assert.Null(result);
            
        }
    }
}
