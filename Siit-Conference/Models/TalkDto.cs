using Conference.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Siit_Conference.Models
{
    public class TalkDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Level { get; set; }
        public bool Active { get; set; }
        public bool FeedbackEnabled { get; set; }

        [DisplayName("Speaker Name")]
        public int SpeakerId { get; set; }
        public virtual Speaker Speaker { get; set; }
    }
}
