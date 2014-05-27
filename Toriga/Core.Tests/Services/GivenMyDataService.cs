using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Core.Services.EF.Context;
using Core.Services.EF.Implementations;
using NUnit.Framework;

namespace Core.Tests.Services
{
    [TestFixture]
    public class GivenMyDataService
    {
        [Test]
        public void Test()
        {
            var context = new MyDataContext("DbConnectionString");
            var dataService = new MyDataService<MyData>(context);

            Assert.IsTrue(true);

        }

    }
}
