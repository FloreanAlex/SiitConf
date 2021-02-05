using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Conference.Domain
{

    public partial class Speaker
    {
        public string FullName { get { return FirstName + " " + LastName; } }
    }
}
