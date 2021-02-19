﻿using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using FluentValidation;
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

        // [LogAspect] //// AOP



        [ValidationAspect(typeof(ProductValidator))]
        public IResult Add(Product product)
        {

            //Loglama
            //cachermove
            //performance
            //transaction
            //yetkilendirme

            _productDal.Add(product);

            return new SuccessResult(Messages.ProductAdded);
        }


        public IDataResult<List<Product>> GetAll()
        {
            //iş kodları varsa yazılır. şimdilik simulation. buraya iş kodu yazdık diyelim.
            //yetkisi var  mı diye kodlar yazılır.
            //sonra ürğnğ verir kurallardan geçerse.
            if (DateTime.Now.Hour==1)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            }

            return new SuccessDataResult<List<Product>>(_productDal.GetAll(), Messages.ProductListed);
        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return  new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == id));
        }

        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductId == productId));
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max));
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails());
        }
    }
}
