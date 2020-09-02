using System.Collections.Generic;
using System.Threading.Tasks;
using FirebaseAdmin.Messaging;

namespace DotnetApi.Data
{
    public interface IFirebaseRepository
    {
        public Task SendMessageAsync(Message message);

        public Task SubscribeToTopicAsync(IReadOnlyList<string> fcmTokens, string topicName);

        public Task UnsubscribeFromTopicAsync(IReadOnlyList<string> fcmTokens, string topicName);
    }
}