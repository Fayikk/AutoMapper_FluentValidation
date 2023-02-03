using AutoMapper;
using AutoMapper_FluentValidation.Business.Abstract;
using AutoMapper_FluentValidation.ContextDb;
using AutoMapper_FluentValidation.Dto;
using AutoMapper_FluentValidation.Entities;

namespace AutoMapper_FluentValidation.Business.Concrete
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public ProductService(ApplicationDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ProductDto Create(ProductDto objDto)
        {
            var obj = _mapper.Map<ProductDto, Product>(objDto);
            var addObj = _context.Products.Add(obj);
            _context.SaveChanges();
            return _mapper.Map<Product,ProductDto >(addObj.Entity);

        }

        public int Delete(int id)
        {
            var obj = _context.Products.FirstOrDefault(x => x.ProductId == id);

            if (obj != null)
            {
                _context.Remove(obj);
                _context.SaveChanges();
            }
            return 0;
        }

        public IEnumerable<ProductDto> GetAll()
        {
            return _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDto>>(_context.Products);
        }

        public ProductDto GetById(int id)
        {
            var obj = _context.Products.FirstOrDefault(x => x.ProductId == id);
            if (obj != null)
            {
                return _mapper.Map<Product,ProductDto >(obj);
            }
            return new ProductDto();
        }

        public ProductDto Update(ProductDto objDto)
        {
            var obj = _context.Products.FirstOrDefault(x=>x.ProductId == objDto.ProductId);
            if(obj != null)
            {
                obj.ProductName = objDto.ProductName;
                obj.Price = objDto.Price;
                _context.SaveChanges();
                return _mapper.Map<Product,ProductDto>(obj);
            }
            return objDto;
        }
    }
}
