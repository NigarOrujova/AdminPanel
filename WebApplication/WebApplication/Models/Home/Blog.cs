using System.Collections.Generic;

namespace WebApplication.Models.Home
{
    public class Blog
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<BlogImage> BlogImages { get; set; }
        public string Date { get; set; }
    }
}
