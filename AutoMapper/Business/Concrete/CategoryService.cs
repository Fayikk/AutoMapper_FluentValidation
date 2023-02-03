using AutoMapper;
using AutoMapper_FluentValidation.Business.Abstract;
using AutoMapper_FluentValidation.ContextDb;
using AutoMapper_FluentValidation.Dto;
using AutoMapper_FluentValidation.Entities;

namespace AutoMapper_FluentValidation.Business.Concrete
{
    public class CategoryService : ICategoryService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public CategoryService(ApplicationDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public CategoryDto Create(CategoryDto objDto)
        {
            var obj = _mapper.Map<CategoryDto,Category>(objDto);
            var addedObj = _context.Categories.Add(obj);
            _context.SaveChanges();
            return _mapper.Map<Category, CategoryDto>(addedObj.Entity);
        }

        public int Delete(int id)
        {
            var obj = _context.Categories.FirstOrDefault(x => x.CategoryId == id);
            if (obj != null)
            {
                _context.Remove(obj);
                return _context.SaveChanges();
            }
            return 0;
        }

        public IEnumerable<CategoryDto> GetAll()
        {
            return _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryDto>>(_context.Categories);
        }

        public CategoryDto GetById(int id)
        {
            var obj = _context.Categories.FirstOrDefault(x => x.CategoryId == id);
            if (obj != null)
            {
                return _mapper.Map<Category, CategoryDto>(obj);
            }
            return new CategoryDto();
        }

        public CategoryDto Update(CategoryDto objDto)
        {
            var obj = _context.Categories.FirstOrDefault(x => x.CategoryId == objDto.CategoryId);
            if (obj != null)
            {
                obj.CategoryName = objDto.CategoryName;
                obj.CategoryCount=objDto.CategoryCount;
                _context.SaveChanges();
                return _mapper.Map<Category, CategoryDto>(obj);
            }
            return objDto;
        }
    }
}
