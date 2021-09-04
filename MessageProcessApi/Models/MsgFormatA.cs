using System;
using System.ComponentModel.DataAnnotations;

namespace MessageProcessApi.Models
{
    public class MsgFormatA
    {
        [Key]
        public int Id { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string Type { get; set; }
        public string Text { get; set; }
        public DateTime SendTime { get; set; }
    }
}
