using System;
using System.Collections.Generic;

namespace Invigulus.Data.Domain
{
    public partial class Examinee
    {
        public Examinee()
        {
            UserSession = new HashSet<UserSession>();
        }

        public int ExamineeId { get; set; }
        public string ExamineeFirstname { get; set; }
        public string ExamineeLastname { get; set; }
        public string ExamineeEmail { get; set; }

        public virtual ICollection<UserSession> UserSession { get; set; }
    }
}
