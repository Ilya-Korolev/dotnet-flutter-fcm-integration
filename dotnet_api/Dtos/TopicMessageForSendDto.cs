using System.ComponentModel.DataAnnotations;

namespace DotnetApi.Dtos
{
    public class TopicMessageForSendDto
    {
        [Required]
        public string Topic { get; set; }

        [Required]
        public string Title { get; set; }

        public string Body { get; set; }
    }
}