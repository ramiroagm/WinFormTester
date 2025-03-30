using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InstagramApiSharp;
using InstagramApiSharp.API;
using InstagramApiSharp.Classes;
using TesterProyect.BusinessEntities;

namespace TesterProyect.BusinessLogic.Interfaces
{
    public interface IInstagramConnector
    {
        Task<IInstaApi> CreateConnection(string userName, string password);
        Task<IResult<InstagramApiSharp.Classes.Models.InstaDirectInboxThreadList>> SendMessage(IInstaApi login, string message, string userToSend);
        Task<List<InstagramMessage>> ReceiveMessages(IInstaApi login, int cantMessagesPerChat = 1, PaginationParameters? pagination = null);
    }
}
