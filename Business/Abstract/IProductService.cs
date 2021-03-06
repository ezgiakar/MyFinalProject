﻿using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IProductService
    {
        IDataResult<List<Product>> GetAll();
        IDataResult<List<Product>> GetAllByCategoryId(int id);
        IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max);
        IDataResult<List<ProductDetailDto>> GetProductDetails();
        IDataResult<Product> GetById(int productId);
        IResult Update(Product product);
        IResult Add(Product product);
        IResult AddTransactionalTest(Product product); // aynı süreçte iki tane işlem var.işlem sorunlu oldu işlemin geri alınması gerkiyor.
    }
}
