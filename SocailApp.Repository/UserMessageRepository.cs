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

        public void SendMessage(UserMessage message)
        {
            var conversation = _context.Conversations
                .Where(s => (s.UserFrom == message.MessageFrom ||
                s.UserTo == message.MessageFrom) &&
                s.UserFrom == message.MessageTo ||
                s.UserTo == message.MessageTo).FirstOrDefault();
            if (conversation == null)
            {
                conversation = new Conversation()
                {
                    UserFrom = message.MessageFrom,
                    UserTo = message.MessageTo.Value           
                };
                _context.Conversations.Add(conversation);
            }
            conversation.UserMessages.Add(message);

            _context.SaveChanges();
        }
    }
}
