using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Core.Entities;

namespace WebApp.Models
{
    public class DataViewModel
    {
        public string Title { get; set; }
        public IEnumerable<string> ColumnHeadings { get; set; }
        public IEnumerable<MyData> Data { get; set; } 
    }
}