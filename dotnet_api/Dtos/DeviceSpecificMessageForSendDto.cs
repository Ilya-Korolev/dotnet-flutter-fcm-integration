using System.ComponentModel.DataAnnotations;

namespace DotnetApi.Dtos
{
    public class DeviceSpecificMessageForSendDto
    {
        [Required]
        public string FcmToken { get; set; }

        [Required]
        public string Title { get; set; }

        public string Body { get; set; }
    }
}