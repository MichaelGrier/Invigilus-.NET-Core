using Invigulus.Data;
using Invigulus.Data.Domain;
using System;
using System.Linq;

namespace Invigulus.Business
{
    public class ExamineeManager
    {
        public static Examinee GetLast()
        {
            var context = new ExamineeContext();
            var examinee = context.Examinees
                           .OrderByDescending(e => e.ExamineeId)
                           .FirstOrDefault();
            return examinee;
        }

        public static void Add(Examinee examinee)
        {
            var context = new ExamineeContext();
            context.Examinees.Add(examinee);
            context.SaveChanges();
        }

        public static void Update(Examinee examinee)
        {
            var context = new ExamineeContext();
            var examineeToEdit = context.Examinees.Find(examinee.ExamineeId);
            examineeToEdit.ExamineeFirstname = examinee.ExamineeFirstname;
            examineeToEdit.ExamineeLastname = examinee.ExamineeLastname;
            examineeToEdit.ExamineeEmail = examinee.ExamineeEmail;
            context.SaveChanges();
        }

        public static Examinee Find(int id)
        {
            var context = new ExamineeContext();
            var examinee = context.Examinees.Find(id);
            return examinee;
        }

        // authenticate an examinee's info against the db
        public static Examinee Authenticate(int id, string email)
        {
            var context = new ExamineeContext();
            // if examinee w/ matching id and email exists, return it. if not, return null
            var examinee = context.Examinees.SingleOrDefault(ex => ex.ExamineeId == id && ex.ExamineeEmail == email);
            return examinee;
        }
    }
}
