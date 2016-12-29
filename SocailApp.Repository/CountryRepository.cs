using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialApp.DB.Model;

namespace SocailApp.Repository
{
    public class CountryRepository : ICountryRepository
    {
        private SocialAppEntities _context;
        public CountryRepository()
        {
            _context = new SocialAppEntities();
        }
        public IEnumerable<Country> Get()
        {
            return _context.Countries.ToList();
        }
    }
}
