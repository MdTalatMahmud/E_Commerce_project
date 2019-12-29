using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Commerce_project.Models
{
    public class CategoryDetail
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<bool> IsDelete { get; set; }
    }
}