using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    //T yi sınırlandırmak için generic constraint yaparız
    // where T:class --- > T referans tip olabilir demek, class demek değil
    // IEntity, ientity veya onu implemente eden bir nesne olabilir. Yani IEntity'in kendisini de
    //miras bıraktığı class'ı da alabilir demek.
    //new(): new'lenebilir olmalı !
    public interface IEntityRepository<T> where T:class, IEntity, new()
    {
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        //interface methodları default
        //olarak publictir

    }
}
