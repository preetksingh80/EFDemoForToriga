using Core.Entities;
using Core.Services.EF.Context;
using Core.Services.EF.Implementations;
using NUnit.Framework;

namespace Core.Tests.Services.SlowDBTest
{
    [TestFixture]
    public class WhileQueryingFromDbUsingEf{

       [Test]
        public void WeShouldGet4RowsOfDataBack()
        {
            var context = new MyDataContext("DbConnectionString");
            var dataService = new MyDataService<MyData>(context);
            var data = dataService.GetAll();
            Assert.IsTrue(data.Count == 4);

        }

    }
}
