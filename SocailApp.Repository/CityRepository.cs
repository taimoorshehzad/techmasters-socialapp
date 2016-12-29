using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialApp.DB.Model;

namespace SocailApp.Repository
{
    public class CityRepository : ICityRepository
    {
        private SocialAppEntities _context;
        public CityRepository()
        {
            _context = new SocialAppEntities();
        }
        public IEnumerable<City> Get()
        {
            return _context.Cities.ToList();
        }
    }
}
