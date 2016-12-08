using Product.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Product.Web.ViewModel
{
    public class ProductModel
    {
        public product CurrentProduct { get; set; }
        public List<Category> ListCategory { get; set; }
    }
}