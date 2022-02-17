using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using Core.Aspects.Autofac.Validation;
using System.Linq;
using Core.Utilities.Business;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;
        ICategoryService _categoryService;

        public ProductManager(IProductDal productDal, ICategoryService categoryService)
        {    //bir entity manager, kendisi hariç başka bir Dal tarafından enjecte edilemez !!!!
            //ICategoryDal bu yüzden çok yanlış ! o yüzden de biz, ICategoryService enjecte ediyoruz !
            _productDal = productDal;
            _categoryService = categoryService;
        }

        [ValidationAspect(typeof(ProductValidator))]
        public IResult Add(Product product)
        {
            //cross cutting concerns -> log, transactions, validation, authorization, cache
            //validation

            //bu alttaki kodlar Fluentvaldation ile yapılır
            //if (product.UnitPrice<=0)
            //{
            //    return new ErrorResult(Messages.UnitPriceInvalid);
            //}
            //if (product.ProductName.Length<2)
            //{
            //    return new ErrorResult(Messages.ProductNameInvalid);
            //}
            //var context = new ValidationContext<Product>(product);
            //ProductValidator productValidator = new ProductValidator();
            //var result = productValidator.Validate(context);
            //if (!result.IsValid)
            //{
            //    throw new ValidationException(result.Errors);
            //}
            //ValidationTool.Validate(new ProductValidator(), product);
            //üstteki kodları zaten ValidationRules klasöründe yazdık !
            IResult result = BusinessRules.Run(ChechIfProductNameExists(product.ProductName),
                ChechIfProductCountOfCategoryCorrect(product.CategoryId),CheckIfCategoryLimitExceded());

            if (result !=null)
            {
                return result;
            }
            _productDal.Add(product);

            return new SuccessResult(Messages.ProductAdded);
            //if (ChechIfProductCountOfCategoryCorrect(product.CategoryId).Success)
            //{
            //    if (ChechIfProductNameExists(product.ProductName).Success)
            //    {
            //        _productDal.Add(product);

            //        return new SuccessResult(Messages.ProductAdded);
            //    }
            //}    
            //return new ErrorResult();
            //bunları  da business.Run() ' a yazdırdık
            
        }


        public IDataResult<List<Product>> GetAll()
        {
            //iş kodları
            //Yetkisi var mı ?
            if (DateTime.Now.Hour == 20)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            }

            return new SuccessDataResult<List<Product>>(_productDal.GetAll(),Messages.ProductListed);
           



        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == id));
        }

        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductId == productId));
        }

        public IDataResult<List<Product>>GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max));
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProcutDetails());
        }
        [ValidationAspect(typeof(ProductValidator))]
        public IResult Update(Product product)
        {

            throw new NotImplementedException();
        }

        private IResult ChechIfProductCountOfCategoryCorrect(int categoryId)
        {
            var result = _productDal.GetAll(p => p.CategoryId == categoryId).Count;
            if (result >= 15)
            {
                return new ErrorResult(Messages.ProductCountOfCategoryError);
            }
            return new SuccessResult();
        }
        private IResult ChechIfProductNameExists(string productName)
        {
            var result = _productDal.GetAll(p => p.ProductName == productName).Any();
            if (result)
            {
                return new ErrorResult(Messages.ProductNameAlreadyExists);
            }
            return new SuccessResult();
        }
        private IResult CheckIfCategoryLimitExceded()
        {
            var result = _categoryService.GetAll();
            if (result.Data.Count>15)
            {
                return new ErrorResult(Messages.CategoryLimitExceded);
            }
            return new SuccessResult(); 
        }


    }
}
