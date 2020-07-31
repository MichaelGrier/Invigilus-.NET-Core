using System;
using System.Collections.Generic;

namespace Invigulus.Data.Domain
{
    public partial class Proctor
    {
        public Proctor()
        {
            UserSession = new HashSet<UserSession>();
        }

        public int ProctorId { get; set; }
        public string ProctorFirstname { get; set; }
        public string ProctorLastname { get; set; }
        public string ProctorEmail { get; set; }

        public virtual ICollection<UserSession> UserSession { get; set; }
    }
}
