using System;
using System.Collections.Generic;
using System.Text;
using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOes;

namespace DataAccess.Abstract
{
    public interface IProductDal : IEntityRepository<Product>
    {
        //ürünleri kategoriye göre getir.
        List<ProductDetailDto> GetProductDetails();
    }
}
