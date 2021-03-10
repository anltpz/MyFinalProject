using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    // generic constraint --generic kısıt
    //class: referans tip
    //IEntity olabilir yada bunu implemente eden bir nesne olabilir
    // newlene bilir olamalı
   public interface IEntityRepository<T> where T:class,IEntity,new()
    {
        List<T> GetAll(Expression<Func<T,bool>> filter=null);// tüm datayı getir bir filtre vermek istiyorsan Expression yaz  filter null dersek filtre vermez
        T Get(Expression<Func<T,bool>> filter); // tek bir datanın bilgilerini almak için filter null değil 
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
       // List<T> GetAllByCategorty(int catgoryId);// exprenssion yazınca buraya gerek kalmadı 
    }
}
