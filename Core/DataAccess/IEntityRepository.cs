using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess
{
    // Generic constraint
    public interface IEntityRepository<T> where T:class,IEntity,new() //(T bir referans tip olmalı VE T IEntity ya da ondan miras alan birşey olmalıdır)
    {
        List<T> GetAll(Expression<Func<T,bool>> filter=null); // null ile istersek filtre olmadan çalışacağını gösterir. tüm sonuçları getirir. e-ticaretteki gibi filtreleme. DELEGELER.
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);

    }
}
