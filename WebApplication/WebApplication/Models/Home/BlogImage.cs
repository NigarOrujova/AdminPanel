using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models.Home
{
    public class BlogImage
    {
        public int Id { get; set; }
        public bool IsMain { get; set; }
        public string Image { get; set; }
        public int BlogId { get; set; }
        public Blog Blog { get; set; }
    }
}
