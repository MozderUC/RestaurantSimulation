using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Moq;
using NUnit.Framework;
using RestaurantSimulation.BLL.Services;
using RestaurantSimulation.DAL.Repositories;
using RestaurantSimulation.DAL.Entities;
using RestaurantSimulation.BLL.Services.CustomExeptions;

namespace RestaurantSimulation.BLL.Tests.IntegrationTesting
{
    [TestFixture]
    public class DbUsageVegetableStorageService
    {
        [Test]
        public void DbUsageToVegetableStorageService()
        {
            // Arrange
            var eFUnitOfWork = new EFUnitOfWork("name=RestaurantContextIntegrationTest");        
            var vegetableStorageService = new VegetableStorageService(eFUnitOfWork);
            var comparer = new VegetableComparer();
            var vegetablesToSalad = new Dictionary<int, string>
            {
                {12, "Potato"},
                {13, "Tomato"}
            };

            // Act
            var ingredient = vegetableStorageService.GetVegetables(vegetablesToSalad);

            //Assert
            CollectionAssert.AreEqual(ingredient.OrderBy(foo => foo, comparer), new List<Models.Vegetable>
            {
                new Models.Vegetable{Weight = 12, Name = "Potato"},
                new Models.Vegetable{Weight = 13, Name = "Tomato"}
            }.OrderBy(foo => foo, comparer), comparer);

        }

        private class VegetableComparer : IComparer, IComparer<Models.Vegetable>
        {
            public int Compare(object x, object y)
            {
                if (!(x is Models.Vegetable lhs) || !(y is Models.Vegetable rhs)) throw new InvalidOperationException();
                return Compare(lhs, rhs);
            }

            public int Compare(Models.Vegetable x, Models.Vegetable y)
            {
                int temp;
                if (x == null || y == null)
                    throw new InvalidOperationException();
                return (temp = string.Compare(x.Name, y.Name, StringComparison.Ordinal)) != 0 ? temp : x.Weight.CompareTo(y.Weight);
            }
        }
    }
}
