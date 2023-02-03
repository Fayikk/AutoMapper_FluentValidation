using AutoMapper_FluentValidation.Dto;

namespace AutoMapper_FluentValidation.Business.Abstract
{
    public interface ICategoryService
    {
        public CategoryDto Create(CategoryDto objDto);
        public CategoryDto Update(CategoryDto objDto);
        public int Delete(int id);  
        public CategoryDto GetById(int id);
        public IEnumerable<CategoryDto> GetAll();
    }
}
