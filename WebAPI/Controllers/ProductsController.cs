using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]   //Attribute , bir class ile ilgili bilgi verme yöntemi, bu class bir
                      //controllerdır
    public class ProductsController : ControllerBase
    {
        //loosely coupled (gevşek bağımlılık)
        IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            //IProductService productService = new ProductManager(new EfProductDal()); 
            //bu kısımda bir bağımlılık zinciri var 
            //product service manager'a o da efproduct'a ihtiyaç duyuyor
            // onu engellemek için yukarıdaki kod bloğu yazılır !
            //IoC Container -- Inversion of Control
            var result = _productService.GetAll();
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);


        }
        [HttpGet("getById")]
        public IActionResult Get(int id)
        {
            var result = _productService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }



        [HttpPost("add")]
        public IActionResult Add(Product product)
        {
            var result = _productService.Add(product);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        
    
    }


}
