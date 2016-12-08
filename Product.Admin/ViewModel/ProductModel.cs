using Product.Entity.Model;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Product.Admin.ViewModel
{
    public class ProductModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="{0} boş geçilemez.")]
        [DisplayName("Ürün Adı")]
        public string Name { get; set; }
        [Required(ErrorMessage = "{0} boş geçilemez.")]
        [DisplayName("Kategori Adı")]
        public string CategoryName { get; set; }
        [DisplayName("Resim")]
        public virtual ICollection<ProductImage> ProductImages { get; set; }
        public virtual ICollection<ProductFeature> ProductFeatures { get; set; }

        public int CategoryId { get; set; }
    }
}