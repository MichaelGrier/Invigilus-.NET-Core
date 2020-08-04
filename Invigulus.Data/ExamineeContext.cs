using Invigulus.Data.Domain;
using Microsoft.EntityFrameworkCore;
using System;

namespace Invigulus.Data
{
    public class ExamineeContext : InvigulusContext
    {
        public ExamineeContext() : base() { }

        public DbSet<Examinee> Examinees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // change this connection string to work on your local machine
            optionsBuilder.UseSqlServer(@"Server=localhost\sqlexpress;
                                          Database=Invigulus;
                                          Trusted_Connection=True;");
        }
    }
}
