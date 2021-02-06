using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess
{
    //generic constraint: generic kısıt.
    //class demek referans tip olabilir demektir. yani yalnızca class alınmaz.
    //herhangi bir cllass yazamasın sadece belirli classları yazsın.
    //o zaman IEntity yazdık böylece IEntity ile implement edilmiş olmalı kuralı verdim.
    public interface IEntityRepository<T> where T: class, IEntity, new()
    {
        List<T> GetAll(Expression<Func<T, bool>> filter=null);
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);

        //List<T> GetAllByCategory(int categoryId); bu koda gerek kalmaz. üzerideki expression yapısı ile.
        //bu filtreleri üstteki yapı ile yaparız.
    }
}
