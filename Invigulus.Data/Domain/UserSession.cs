using System;
using System.Collections.Generic;

namespace Invigulus.Data.Domain
{
    public partial class UserSession
    {
        public int SessionId { get; set; }
        public int? ExamId { get; set; }
        public int? ExamineeId { get; set; }
        public int? ProctorId { get; set; }
        public DateTime? DateTime { get; set; }

        public virtual Exam Exam { get; set; }
        public virtual Examinee Examinee { get; set; }
        public virtual Proctor Proctor { get; set; }
    }
}
