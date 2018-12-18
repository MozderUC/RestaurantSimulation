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

namespace RestaurantSimulation.BLL.Tests
{
    [TestFixture]
    public class VegetableStorageServiceTest
    {
        [Test]
        public void GetVegetables_FindVegetableInStorage_CallVerify()
        {
            // Arrange
            var mock = new Mock<IEFUnitOfWork>();
            mock.Setup(lw => lw.VegetableStorage.GetAll())
                .Returns(new List<VegetableStorage>{ new VegetableStorage { VegetableStock = 20, Vegetable = new Vegetable { Name = "Potato" } } });
        
            var vegetableStorageService = new VegetableStorageService(mock.Object);

            // Act   
            vegetableStorageService.GetVegetables(new Dictionary<int, string>
            {
                {12,"Potato"}
            });

            // Assert
            mock.Verify();
        }

        [Test]
        public void GetVegetables_RaiseNoAmountNeededProductException_CatchException()
        {
            // Arrange
            var mock = new Mock<IEFUnitOfWork>();
            mock.Setup(lw => lw.VegetableStorage.GetAll())
                .Returns(new List<VegetableStorage> { new VegetableStorage { VegetableStock = 2, Vegetable = new Vegetable { Name = "Potato" } } });

            var vegetablesToSalt = new Dictionary<int, string>
            {
                {12,"Potato"}
            };          
            var vegetableStorageService = new VegetableStorageService(mock.Object);


            // Act Assert
            Assert.That(() => vegetableStorageService.GetVegetables(vegetablesToSalt),
                Throws.TypeOf<NoAmountNeededProductException>());
        }

        [Test]
        public void GetVegetables_RaiseNotFoundIngredientException_CatchException()
        {
            // Arrange
            var mock = new Mock<IEFUnitOfWork>();
            mock.Setup(lw => lw.VegetableStorage.GetAll())
                .Returns(new List<VegetableStorage>());

            var vegetablesToSalt = new Dictionary<int, string>
            {
                {12,"Potato"}
            };
            var vegetableStorageService = new VegetableStorageService(mock.Object);

            // Act Assert
            Assert.That(() => vegetableStorageService.GetVegetables(vegetablesToSalt),
                Throws.TypeOf<NotFoundIngredientException>());
        }

        [Test]
        public void GetVegetables_MapStorageVegetablesToCookVegetables_VegetablesList()
        {
            // Arrange
            var mock = new Mock<IEFUnitOfWork>();
            var vegetableStorage = new List<VegetableStorage>
            {
                new VegetableStorage {VegetableStock = 20, Vegetable = new Vegetable {Name = "Potato"}},
                new VegetableStorage {VegetableStock = 30, Vegetable = new Vegetable {Name = "Tomato"}}
            };           
            mock.Setup(lw => lw.VegetableStorage.GetAll())
                .Returns(vegetableStorage);
            var vegetableStorageService = new VegetableStorageService(mock.Object);
            var comparer = new VegetableComparer();

            // Act
            var vegetablesToChef = vegetableStorageService.GetVegetables(new Dictionary<int, string>
            {
                {12, "Potato"},
                {13, "Tomato"}
            });

            // Assert
            CollectionAssert.AreEqual(vegetablesToChef.OrderBy(foo => foo, comparer), new List<Models.Vegetable>
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
                if (x==null || y==null)
                    throw new InvalidOperationException();
                return (temp = string.Compare(x.Name, y.Name, StringComparison.Ordinal)) != 0 ? temp : x.Weight.CompareTo(y.Weight);
            }
        }
    }
}
