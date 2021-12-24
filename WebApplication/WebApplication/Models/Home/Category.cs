using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models.Home
{
    public class Category
    {
        public int Id { get; set; }
        [Required,MaxLength(50)]
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
