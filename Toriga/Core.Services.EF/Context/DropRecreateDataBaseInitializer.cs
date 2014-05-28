using System.Collections.Generic;
using System.Data.Entity;
using Core.Entities;

namespace Core.Services.EF.Context
{
    public class DropRecreateDataBaseInitializer: DropCreateDatabaseAlways<MyDataContext>
    {
        protected override void Seed(MyDataContext context)
        {
            var data = new List<MyData>
                {
                    new MyData {Id = 1, Column1 = "Column1", Column2 = "Column2", Column3 = "Column3"},
                    new MyData {Id = 2, Column1 = "Column1", Column2 = "Column2", Column3 = "Column3"},
                    new MyData {Id = 3, Column1 = "Column1", Column2 = "Column2", Column3 = "Column3"},
                    new MyData {Id = 4, Column1 = "Column1", Column2 = "Column2", Column3 = "Column3"}
                };

            context.MyData.AddRange(data);
            context.SaveChanges();
        }
    }
}