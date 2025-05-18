using InstagramApiSharp;
using InstagramApiSharp.API;
using InstagramApiSharp.Classes;
using TesterProject.BusinessEntities.Instagram;

namespace TesterProject.BusinessLogic.Interfaces.Instagram
{
    public interface IInstagramConnector
    {
        Task<IInstaApi> CreateConnection(string userName, string password);
        Task<IResult<InstagramApiSharp.Classes.Models.InstaDirectInboxThreadList>> SendMessage(IInstaApi login, string message, string userToSend);
        Task<List<InstagramMessage>> ReceiveMessages(IInstaApi login, int cantMessagesPerChat = 1, PaginationParameters? pagination = null);
    }
}
