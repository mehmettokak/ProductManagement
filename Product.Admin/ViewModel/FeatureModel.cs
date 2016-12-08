using Product.Entity.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Product.Admin.ViewModel
{
    public class FeatureModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "{0} alanı boş geçilemez.")]
        [DisplayName("Ürün Özellik Adı")]
        public string Name { get; set; }
        [Required(ErrorMessage = "{0} alanı boş geçilemez.")] 
        [DisplayName("Ürün Özellik Değeri")]
        public string Value { get; set; }
        public virtual product Product { get; set; }
    }
}