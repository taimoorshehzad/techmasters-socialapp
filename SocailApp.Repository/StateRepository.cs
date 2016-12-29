using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialApp.DB.Model;

namespace SocailApp.Repository
{
    public class StateRepository : IStateRepository
    {
        private SocialAppEntities _context;
        public StateRepository()
        {
            _context = new SocialAppEntities();
        }
        public IEnumerable<State> Get()
        {
            return _context.States.ToList(); 
        }
    }
}
