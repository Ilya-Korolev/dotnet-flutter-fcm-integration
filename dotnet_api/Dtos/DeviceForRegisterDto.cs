using System;
using System.ComponentModel.DataAnnotations;

namespace DotnetApi.Dtos
{
    public class DeviceForRegisterDto
    {
        [Required]
        public string FcmToken { get; set; }

        public string Platform { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}