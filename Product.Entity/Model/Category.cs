using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Product.Entity.Model
{
    public class Category
    {
        [Key] //PrimaryKey
        public int Id { get; set; }
        [Required(ErrorMessage ="{0} alanı boş geçilemez.")] //NotNull Boş olmasın.Boş olursa hata mesajı verecektir.{0}=>prop adı,Kategori Adı gelecek
        [DisplayName("Kategori Adı")]
        public string Name { get; set; }
        public virtual ICollection<product> Products { get; set; }
        //prop ları ayarladıktan sonra dataları db den getirmek için contex sınıfı olusturmalıyuz.
    }
}
