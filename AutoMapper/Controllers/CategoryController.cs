using AutoMapper_FluentValidation.Business.Abstract;
using AutoMapper_FluentValidation.Dto;
using AutoMapper_FluentValidation.Validation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutoMapper_FluentValidation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService; 
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService; 
        }

    //Create,read,delete,update

       [HttpGet]
       public  IActionResult GetAll()
        {
            var result = _categoryService.GetAll();
            return Ok(result);
        
        }

        [HttpPost]
        public IActionResult CreateCategory(CategoryDto category)
        {
            CategoryValidator validations = new CategoryValidator();

            ValidationResult results = validations.Validate(category);

            if (results.IsValid)
            {
                var result = _categoryService.Create(category);
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

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var result = _categoryService.GetById(id);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCategory([FromRoute]int id)
        {
            var result = _categoryService.Delete(id);
            return Ok(result + "Deleted");
        }

        [HttpPut]
        public IActionResult UpdateCategory(CategoryDto categoryDto)
        {
            var result = _categoryService.Update(categoryDto);
            return Ok(result);
        }


    }
}
