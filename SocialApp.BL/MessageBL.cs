using SocailApp.Repository;
using SocialApp.DB.ViewModel;
using System.Collections.Generic;
using System.Linq;

namespace SocialApp.BL
{
    public class MessageBL
    {
        IConversationRepository ConversationRepository = new ConversationRepository();
        IUserMessageRepository UserMessageRepository = new UserMessageRepository();
        IUserProfileRepository ProfileRepository = new UserProfileRepository();
        public List<ConversationViewModel> Conversation(string user)
        {
            List<ConversationViewModel> viewModelList = new List<ConversationViewModel>();
            int userid = ProfileRepository.Get().FirstOrDefault(m => m.UserID == user).UserProfileID;
            var conversations = ConversationRepository.Get().Where(m=>m.UserFrom== userid).ToList();

            foreach (var item in conversations)
            {
                ConversationViewModel viewModel = new ConversationViewModel();
                viewModel.ConversationID = item.ConversationID;
                viewModel.Conversations = ProfileRepository.Get().FirstOrDefault(s => s.UserProfileID == item.UserTo).FirstName +" "+ ProfileRepository.Get().FirstOrDefault(s => s.UserProfileID == item.UserTo).LastName;
                viewModelList.Add(viewModel);
            }
            return viewModelList;
        }
        public List<UserMessageViewModel> userMessage(int? id)
        {
            List<UserMessageViewModel> viewModelList = new List<UserMessageViewModel>();
            var UserMessage = UserMessageRepository.GetMessage().Where(s => s.ConversationID == id).ToList();

            foreach (var item in UserMessage)
            {
                UserMessageViewModel viewModel = new UserMessageViewModel();
                viewModel.Message = item.Message;
                viewModel.MessageFrom = ProfileRepository.Get().FirstOrDefault(s => s.UserProfileID == item.MessageFrom).FirstName + " " + ProfileRepository.Get().FirstOrDefault(s => s.UserProfileID == item.MessageFrom).LastName;
                viewModelList.Add(viewModel);
            }
            return viewModelList;
        }
    }

}   
