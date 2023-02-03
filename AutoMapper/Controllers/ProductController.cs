using AutoMapper_FluentValidation.Business.Abstract;
using AutoMapper_FluentValidation.Dto;
using AutoMapper_FluentValidation.Entities;
using AutoMapper_FluentValidation.Validation;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutoMapper_FluentValidation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
           var result = _productService.GetAll();
            return Ok(result);
        }
        [HttpPost]
        public IActionResult AddProduct(ProductDto product)
        {
            ProductValidator validations = new ProductValidator();

            ValidationResult results = validations.Validate(product);

            if (results.IsValid)
            {
                var result = _productService.Create(product);
                return Ok(result);
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    return BadRequest(item.ErrorMessage);
                }
            }
            return null;
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct([FromRoute]int id)
        {
            var result = _productService.Delete(id);
            return Ok(result);
        }

        [HttpPut]
        public IActionResult UpdateProduct(ProductDto product)
        {
            var result = _productService.Update(product);
            return Ok(result);
        }
        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute]int id)
        {
            var result = _productService.GetById(id);
            return Ok(result);
        }

    }
}
