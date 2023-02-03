using AutoMapper_FluentValidation.Dto;

namespace AutoMapper_FluentValidation.Business.Abstract
{
    public interface IProductService
    {
        public ProductDto Create(ProductDto objDto);
        public ProductDto Update(ProductDto objDto);
        public int Delete(int id);
        public ProductDto GetById(int id);
        public IEnumerable<ProductDto> GetAll();
    }
}
