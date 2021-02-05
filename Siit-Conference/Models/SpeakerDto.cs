using Conference.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Siit_Conference.Models
{
    public class SpeakerDto
    {
        public int Id { get; set; }
        [MinLength(3)]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public string WebSite { get; set; }
        public string JobTitle { get; set; }
        public bool Active { get; set; }
        public virtual Workshop Workshop { get; set; }
        public virtual ICollection<Talk> Talk { get; set; }

    }
}
