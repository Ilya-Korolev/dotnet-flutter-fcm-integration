using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FirebaseAdmin;
using FirebaseAdmin.Auth;
using FirebaseAdmin.Messaging;
using Google.Apis.Auth.OAuth2;

namespace DotnetApi.Data
{
   public class FirebaseRepository : IFirebaseRepository
   {
      public FirebaseRepository()
      {
         var options = new AppOptions
         {
            Credential = GoogleCredential.GetApplicationDefault()
         };

         FirebaseApp.Create(options);
      }

      public async Task SendMessageAsync(Message message)
      {
         // Send a message to the device corresponding to the provided registration token.
         var response = await FirebaseMessaging.DefaultInstance.SendAsync(message);

         // Response is a message ID string.
         Console.WriteLine("Successfully sent message: " + response);
      }

      public async Task SubscribeToTopicAsync(IReadOnlyList<string> fcmTokens, string topicName)
      {
         // Subscribe the devices corresponding to the registration tokens to the topic
         var response = await FirebaseMessaging.DefaultInstance.SubscribeToTopicAsync(fcmTokens, topicName);

         Console.WriteLine($"{response.SuccessCount} tokens were subscribed successfully");
      }

      public async Task UnsubscribeFromTopicAsync(IReadOnlyList<string> fcmTokens, string topicName)
      {
         // Unsubscribe the devices corresponding to the registration tokens from the topic
         var response = await FirebaseMessaging.DefaultInstance.SubscribeToTopicAsync(fcmTokens, topicName);

         Console.WriteLine($"{response.SuccessCount} tokens were unsubscribed successfully");
      }
   }
}