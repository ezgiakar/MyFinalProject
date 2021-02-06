using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    // teknolojilerin adı geçmez. IProductDal kullanılır burada.
    public class ProductManager : IProductService
    {
        IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public List<Product> GetAll()
        {
            //iş kodları varsa yazılır. şimdilik simulation. buraya iş kodu yazdık diyelim.
            //yetkisi var  mı diye kodlar yazılır.
            //sonra ürğnğ verir kurallardan geçerse.

            return _productDal.GetAll();
        }

        public List<Product> GetAllByCategoryId(int id)
        {
            return _productDal.GetAll(p => p.CategoryId == id);
        }

        public List<Product> GetByUnitPrice(decimal min, decimal max)
        {
            return _productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max);
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            return _productDal.GetProductDetails();
        }
    }
}
