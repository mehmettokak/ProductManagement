using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Entity.Model
{
    public class ProductFeature
    {//burada product ozellıkler tutulacak.Fiyat,açıklama renk vb gibi.
        [Key] //PrimaryKey
        public int Id { get; set; }
        [Required(ErrorMessage = "{0} alanı boş geçilemez.")]  //NotNull Boş olmasın
        [DisplayName("Ürün Özellik Adı")]
        public string Name { get; set; }
        [Required(ErrorMessage = "{0} alanı boş geçilemez.")] //NotNull Boş olmasın
        [DisplayName("Ürün Özellik Değeri")]
        public string Value { get; set; }
        [Required]
        public int ProductId { get; set; }
        public virtual product Product { get; set; }
        //prop ları ayarladıktan sonra dataları db den getirmek için contex sınıfı olusturmalıyuz.
    }
}
