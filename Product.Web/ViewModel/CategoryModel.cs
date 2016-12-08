using Product.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Product.Web.ViewModel
{
    public class CategoryModel
    {
        public Category CurrentCategory { get; set; }
        public List<Category> ListCategory { get; set; }
        public List<product> ListProduct { get; set; }
    }
}