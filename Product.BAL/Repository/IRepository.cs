using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Product.BAL.Repository
{
   public interface  IRepository<T> where T :class
        //interfacemiz generic olacagı için <T> yazdık.T her şey olabilir.whre T:class deyince T sadece class olacak diyoruz.
        //Bu interfacenın amacı bizim data giden bilgilerin metotlarını tanımlamak.update ,add,delet vb gibi metotlar olacak.
    {
        IEnumerable<T> GetAll(); //Get all butun listeyi getiren metot.Liste doner.
        T GetById(int id);//T=>tek bir nesne(model) donenen ıd ye gore bir model getir metodu.
        T Get(Expression<Func<T,bool>> Expression); //tek bir model donen istenilen bilgiye gore getirir.Yanı (a=>a.x)Expressin a gore getirir.expression geriye bool doner
        IQueryable<T> GetAll(Expression<Func<T,bool>> EpressionList);//istenilen bilgiye(expressiona ait) birden fazla model getirir.yanı liste halınde getirir.
        bool Add(T model);
        bool Update(T model);

        bool Delete(T model);
        int Count();
 

       // Metot işlemleri bittikten sonra bu metotları dolduracak interface ekliyoruzz.

    }
}
