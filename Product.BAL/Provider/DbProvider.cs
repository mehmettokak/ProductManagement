using Product.BAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Product.Entity.Context;
using System.Data.Entity.Migrations;

namespace Product.BAL.Provider
{
    public class DbProvider<T> : IRepository<T> where T : class
    {
        private static DataContext context;
       
        //Singleton Pattern //tek bir onrnek alınıp birden faza işlem yapılsın diye.
        public DataContext Context {
            get
            {
                if (context == null) context = new DataContext();
                return context;
               
            }
            set { context = value; }
        }
        public IEnumerable<T> GetAll()
        {
            return Context.Set<T>();
        }
        public IQueryable<T> GetAll(Expression<Func<T, bool>> EpressionList)
        {
            return Context.Set<T>().Where(EpressionList);
        }
        public T Get(Expression<Func<T, bool>> Expression)
        {
            return Context.Set<T>().FirstOrDefault(Expression);
        }
        public T GetById(int id)
        {
            return Context.Set<T>().Find(id);
        }
        public bool Add(T model)
        {
            Context.Set<T>().Add(model);
           int count= Context.SaveChanges();
           Context = new DataContext();//ekleme işleminden sonra contexti yenilemek lazım.Select anında aynı singloten i kullandıgı sorun cıkabililr yani eklendiğinden haberdar olmayabilir. bunun için yenilemek gerek.Binevi db mizi refresh etmiş oluyoruz.
            return count > 0;
        }
        public bool Update(T model)
        {
            Context.Set<T>().AddOrUpdate(model);
            int count = Context.SaveChanges();
            Context = new DataContext();//güncelleme işleminden sonra contexti yenilemek lazım.Select anında aynı singloten i kullandıgı sorun cıkabililr yani guncellendiğinden haberdar olmayabilir. bunun için yenilemek gerek.Binevi db mizi refresh etmiş oluyoruz.
            return count > 0;
        }
        public bool Delete(T model)
        {
            Context.Set<T>().Remove(model);
            int count = Context.SaveChanges();
            context = new DataContext();//tablo silindi.bunun guncellenmesi için new yapıyoruz.ki db nin haberi olsun silindiğinden.
            return count > 0;
        }
        public int Count()
        {
            return Context.Set<T>().Count();
        }
   
    }
}
