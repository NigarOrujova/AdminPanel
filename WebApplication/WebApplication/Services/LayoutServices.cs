using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.DAL;

namespace WebApplication.Services
{
    public class LayoutServices
    {
        private AppDbContext _context { get; }
        public LayoutServices(AppDbContext context)
        {
            _context = context;
        }
        public Dictionary<string,string> GetSetting()
        {
            return _context.Settings.AsEnumerable().ToDictionary(s => s.Key, s => s.Value);
        }
    }
}
