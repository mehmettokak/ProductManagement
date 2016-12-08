using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Entity.Model
{
  public  class ProductImage
    {
        [Key] //PrimaryKey
        public int Id { get; set; }
        public string ImageUrl { get; set; }
 
        [Required] //NotNull Boş olmasın
        public int ProductId { get; set; }
        public virtual product Product { get; set; }
        
        //prop ları ayarladıktan sonra dataları db den getirmek için contex sınıfı olusturmalıyuz.
    }
}
