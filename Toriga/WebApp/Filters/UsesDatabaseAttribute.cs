using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Core.Entities;
using Core.Services;
using Core.Services.EF.Context;
using Core.Services.EF.Implementations;
using Core.Services.InMemory.Implementations;

namespace WebApp.Filters
{
    public class UsesDatabaseAttribute:ActionFilterAttribute
    {       
        
        protected List<MyData> InMemoryData { get; set; }
        protected IMyDataService<MyData> DataService { get; set; }

        public UsesDatabaseAttribute()
        {
             InMemoryData = new List<MyData>
                {
                    new MyData {Id = 1, Column1 = "Column1 From Memory", Column2 = "Column2", Column3 = "Column3"},
                    new MyData {Id = 2, Column1 = "Column1 From Memory", Column2 = "Column2", Column3 = "Column3"},
                    new MyData {Id = 3, Column1 = "Column1 From Memory", Column2 = "Column2", Column3 = "Column3"},
                    new MyData {Id = 4, Column1 = "Column1 From Memory", Column2 = "Column2", Column3 = "Column3"}
                };
        }

 


        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            var dataServiceTypeToCreate = ConfigurationManager.AppSettings["DataService"];

            if (dataServiceTypeToCreate == "DB")
            {
                var context = new MyDataContext(connectionString);
                DataService = new MyDataService<MyData>(context);
            }
            else
            {
                DataService = new InMemoryDataService<MyData>(InMemoryData);
            }
            HttpContext.Current.Items.Add("DataService", DataService);
            base.OnActionExecuting(filterContext);
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            DataService = HttpContext.Current.Items["DataService"] as IMyDataService<MyData>;
            DataService.Dispose();
            base.OnResultExecuted(filterContext);
        }
    }
}