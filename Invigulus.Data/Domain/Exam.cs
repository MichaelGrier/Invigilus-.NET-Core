using System;
using System.Collections.Generic;

namespace Invigulus.Data.Domain
{
    public partial class Exam
    {
        public Exam()
        {
            UserSession = new HashSet<UserSession>();
        }

        public int ExamId { get; set; }
        public int? InstitutionId { get; set; }
        public string ExamName { get; set; }
        public string ExamDuration { get; set; }

        public virtual Institution Institution { get; set; }
        public virtual ICollection<UserSession> UserSession { get; set; }
    }
}
