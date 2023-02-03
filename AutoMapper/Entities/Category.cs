using System.ComponentModel.DataAnnotations;

namespace AutoMapper_FluentValidation.Entities
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
    
        public string CategoryName { get; set; }    
        public int CategoryCount { get; set; }
    }
}
