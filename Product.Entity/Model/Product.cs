using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Entity.Model
{
   public class product
    {
        [Key] //PrimaryKey
        public int Id { get; set; }
        [Required(ErrorMessage = "{0} alanı boş geçilemez.")]  //NotNull Boş olmasın
      
        public string Name { get; set; }
        public virtual ICollection<ProductFeature> ProductFeatures { get; set; }
        public virtual ICollection<ProductImage> ProductImages { get; set; }
        public virtual Category Category { get; set; } //bu product hangi kategori altında ise veritabanında product u çektiğimde bana gelmiş olacak.
        //Categori deki id ye foregenkey baglantısını saglmak için
        [Required]
        public int CategoryId { get; set; }
        //prop ları ayarladıktan sonra dataları db den getirmek için contex sınıfı olusturmalıyuz.

    }
}
