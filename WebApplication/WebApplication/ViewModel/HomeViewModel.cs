using System.Collections.Generic;
using WebApplication.Models;
using WebApplication.Models.Home;
using WebApplication.Models.Product;

namespace WebApplication.ViewModel
{
    public class HomeViewModel
    {
        public List<Models.Slider> Sliders { get; set; }
        public SliderIntro SliderIntro { get; set; }
        public List<Category> Categories { get; set; }
        public List<Product> Products { get; set; }
        public About About { get; set; }
        public List<ListUnstyled> ListUnstyleds { get; set; }
        public List<OurTeam> OurTeams { get; set; }
        public List<Blog> Blogs { get; set; }
        public List<Say> Says { get; set; }
        public Setting Setting { get; set; }
    }
}
