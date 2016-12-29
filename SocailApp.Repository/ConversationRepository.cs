using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialApp.DB.Model;
using System.Web;


namespace SocailApp.Repository
{
    public class ConversationRepository : IConversationRepository
    {
        private SocialAppEntities _context;

        public ConversationRepository()
        {
            _context = new SocialAppEntities();
        }

        public IEnumerable<Conversation> Get()
        {
            return _context.Conversations.ToList();
        }

            }
}
