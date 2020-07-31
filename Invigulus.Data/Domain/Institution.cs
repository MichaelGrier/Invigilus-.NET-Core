using System;
using System.Collections.Generic;

namespace Invigulus.Data.Domain
{
    public partial class Institution
    {
        public Institution()
        {
            Exam = new HashSet<Exam>();
        }

        public int InstitutionId { get; set; }
        public string InstitutionName { get; set; }
        public string InstitutionStreetAddress { get; set; }
        public string InstitutionProvince { get; set; }
        public string InstitutionPostal { get; set; }
        public string InstitutionPhone { get; set; }
        public string InstitutionEmail { get; set; }

        public virtual ICollection<Exam> Exam { get; set; }
    }
}
