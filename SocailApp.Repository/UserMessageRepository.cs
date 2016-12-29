using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialApp.DB.Model;

namespace SocailApp.Repository
{
   public class UserMessageRepository : IUserMessageRepository
    {
        private readonly SocialAppEntities _context;
        public UserMessageRepository()
        {
            _context = new SocialAppEntities();
        }
        public List<UserMessage> GetMessage()
        {
            return _context.UserMessages.ToList();
        }
    }
}
