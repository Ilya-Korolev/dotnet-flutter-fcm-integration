using System;
using System.Threading.Tasks;
using DotnetApi.Data;
using DotnetApi.Dtos;
using FirebaseAdmin.Messaging;
using Microsoft.AspNetCore.Mvc;

namespace DotnetApi.Controllers
{
   [ApiController]
   [Route("api/[controller]")]
   public class MessagingController : ControllerBase
   {
      private readonly IFirebaseRepository _repo;

      public MessagingController(IFirebaseRepository repo)
      {
         _repo = repo;
      }

      [HttpPost("send-device-specific-message")]
      public async Task<IActionResult> SendDeviceSpecificMessage(DeviceSpecificMessageForSendDto messageDto)
      {
         var message = new Message
         {
            Token = messageDto.FcmToken,
            Notification = new Notification
            {
               Title = messageDto.Title,
               Body = messageDto.Body,
            }
         };

         await _repo.SendMessageAsync(message);

         return NoContent();
      }

      [HttpPost("send-topic-message")]
      public async Task<IActionResult> SendTopicMessage(TopicMessageForSendDto messageDto)
      {
         var message = new Message
         {
            Topic = messageDto.Topic,
            Notification = new Notification
            {
               Title = messageDto.Title,
               Body = messageDto.Body,
            }
         };

         await _repo.SendMessageAsync(message);

         return NoContent();
      }

      [HttpPost("register-device")]
      public async Task<IActionResult> RegisterDevice([FromBody] DeviceForRegisterDto device)
      {
         device.CreatedAt = DateTime.Now;

         await _repo.SubscribeToTopicAsync(new[] {device.FcmToken}, "news");

         // Save the device info to your database

         return NoContent();
      }
   }
}