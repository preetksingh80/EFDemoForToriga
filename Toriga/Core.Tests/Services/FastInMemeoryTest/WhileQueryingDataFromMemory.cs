using System.Collections.Generic;
using Core.Entities;
using Core.Services;
using Core.Services.InMemory.Implementations;
using NUnit.Framework;

namespace Core.Tests.Services.FastInMemeoryTest
{
    public class WhileQueryingDataFromMemory
    {
        public List<MyData> InMemoryData { get; set; }

        [TestFixtureSetUp]
        public void Setup()
        {
            InMemoryData = new List<MyData>
                {
                    new MyData {Id = 1, Column1 = "Column1", Column2 = "Column2", Column3 = "Column3"},
                    new MyData {Id = 2, Column1 = "Column1", Column2 = "Column2", Column3 = "Column3"},
                    new MyData {Id = 3, Column1 = "Column1", Column2 = "Column2", Column3 = "Column3"},
                    new MyData {Id = 4, Column1 = "Column1", Column2 = "Column2", Column3 = "Column3"}
                };

         
        }

        [Test]
        public void WeShouldGetTheSameDataThatWeSeededInTheDataService()
        {
            var inMemoryDataService = new InMemoryDataService<MyData>(InMemoryData);
            var data = inMemoryDataService.GetAll();
            CollectionAssert.AreEqual(data, InMemoryData);
        }

        [Test]
        public void WeShouldBeAbleToQueryData()
        {
            var inMemoryDataService = new InMemoryDataService<MyData>(InMemoryData);
            var data = inMemoryDataService.Find(myData => myData.Id > 1);
            Assert.IsTrue(data.Count == 3);
        }
    }
}