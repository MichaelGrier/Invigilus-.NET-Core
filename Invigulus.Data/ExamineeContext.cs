using Invigulus.Data.Domain;
using Microsoft.EntityFrameworkCore;
using System;

namespace Invigulus.Data
{
    public class ExamineeContext : DbContext
    {
        public ExamineeContext() : base() { }

        public DbSet<Examinee> Examinees { get; set; }
    }
}
