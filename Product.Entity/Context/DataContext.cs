using Product.Entity.Model;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Product.Entity.Context
{
    public class DataContext : DbContext//Dbcontext sınıfını kendi Datacontext sınıfına inherit ediyoruz.
    {
        public DataContext() : base("ProductManagementDb")//app konfigteki connectionstring name i gelecek buraya.yoksa database ı sql de olusturmaz.defaultta olusturur.
        {
        }
        //Bu alan Model dekı claslara  ait tablo ve proplara ait kolonlar oluşumları gerçekleşecektir.
        //tablo isimlerimi tekil olarak verdim.
        public DbSet<Category> Category { get; set; }
        public DbSet<product> Product { get; set; }
        public DbSet<ProductImage> ProductImage { get; set; }
        public DbSet<ProductFeature> ProductFeature { get; set; }
        //Normal sartlar da db de tablo ısımlerı cogul olarak yazılır.yanı sonuna s takısı verır.
        //db de tablo isimleri tekıl olarak gelsin istiyorsak asagıdakı metodu kullanıyoruz.

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {//Tablo adındaki s takısını siler.
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
        //Bunları yazdıktan sonra app konfig te connection string ayarlarını yap.
    }
}
