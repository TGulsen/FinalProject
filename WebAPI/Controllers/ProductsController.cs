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
    [ApiController]
    public class ProductsController : ControllerBase
    {
        // Bağımlılığı kırmak için const. injection yaparız.
        // naming convention (isimlendirme standartı)
        // IoC Container yapısı.
        IProductService _productService;

        // Loosely coupled:gevşek bağımlılık,soyuta bağımlılık.
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            //Dependency Chain-- bağımlılık zinciri mevcut;
            //IProductService productService = new ProductManager(new EfProductdal()); bağımlılığını kaldırdık.
            var result = _productService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getbyid")]

        public IActionResult GetById(int id)
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
            if (result.Success==true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        // güncellemeler için httppush kullanılabilir, silmek için httpdelete kullanılabilir.
    }
}
