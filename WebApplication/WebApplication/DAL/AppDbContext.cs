using Microsoft.EntityFrameworkCore;
using WebApplication.Models;
using WebApplication.Models.Home;
using WebApplication.Models.Product;

namespace WebApplication.DAL
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<SliderIntro> SliderIntro { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<About> About { get; set; }
        public DbSet<ListUnstyled> ListUnstyled { get; set; }
        public DbSet<OurTeam> OurTeams { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<BlogImage> BlogImages { get; set; }
        public DbSet<Say> Says { get; set; }
        public DbSet<Setting> Settings { get; set; }

    }
}
