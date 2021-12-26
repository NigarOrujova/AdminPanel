using System.Collections.Generic;
using WebApplication.Models.Home;

namespace WebApplication.ViewModel
{
    public class FooterViewModel
    {
        public List<Service> Services { get; set; }
        public List<SocialMedia> SocialMedias { get; set; }
        public List<Company> Companies { get; set; }
    }
}
