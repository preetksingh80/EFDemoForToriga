using System.Data.Entity;
using Core.Entities;

namespace Core.Services.EF.Context
{
    public class MyDataContext : DbContext
    {
        public MyDataContext(string connectionStringName):base(connectionStringName){}

        public DbSet<MyData> MyData { get; set; }
    }
}
