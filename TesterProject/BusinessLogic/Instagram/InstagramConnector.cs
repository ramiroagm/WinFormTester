using InstagramApiSharp;
using InstagramApiSharp.API;
using InstagramApiSharp.API.Builder;
using InstagramApiSharp.Classes;
using InstagramApiSharp.Logger;
using TesterProject.BusinessEntities;
using TesterProject.BusinessLogic.Interfaces.Instagram;

namespace TesterProject.BusinessLogic.Instagram
{
    public class InstagramConnector : IInstagramConnector
    {
        public InstagramConnector() { }

        public async Task<IInstaApi> CreateConnection(string userName, string password)
        {
            UserSessionData userSession = new()
            {
                UserName = userName,
                Password = password
            };

            IInstaApi instaApi = InstaApiBuilder.CreateBuilder()
                .SetUser(userSession)
                .UseLogger(new DebugLogger(LogLevel.All))
                .Build();

            IResult<InstaLoginResult> loginResult = await instaApi.LoginAsync();
            if (!loginResult.Succeeded)
            {
                throw new Exception("Error al iniciar sesión en Instagram");
            }

            return instaApi;
        }

        public async Task<IResult<InstagramApiSharp.Classes.Models.InstaDirectInboxThreadList>> SendMessage(IInstaApi login, string message, string userToSend)
        {
            IResult<InstagramApiSharp.Classes.Models.InstaUser> user = await login.UserProcessor.GetUserAsync(userToSend);
            if (user.Succeeded)
            {
                var userId = user.Value.Pk;
                var sendMessageResult = await login.MessagingProcessor.SendDirectTextAsync(userId.ToString(), null, message);

                return sendMessageResult;
            }
            else
            {
                throw new Exception("Error al buscar usuario");
            }
        }

        public async Task<List<InstagramMessage>> ReceiveMessages(IInstaApi login, int cantMessagesPerChat = 1, PaginationParameters? pagination = null)
        {
            var inbox = await login.MessagingProcessor.GetDirectInboxAsync(pagination);
            List<InstagramMessage> messages = [];
            if (inbox.Succeeded)
            {
                foreach (var thread in inbox.Value.Inbox.Threads)
                {
                    for (int i = 1; i <= cantMessagesPerChat; i++)
                    {
                        InstagramMessage message = new()
                        {
                            Message = thread.Items[i].Text,
                            UserId = thread.Items[i].UserId
                        };
                        messages.Add(message);
                    }
                }
                return messages;
            }
            else
            {
                throw new Exception("Error trayendo los mensajes de este usuario");
            }
        }
    }
}