using Invigulus.Data;
using Invigulus.Data.Domain;
using System;
using System.Linq;

namespace Invigulus.Business
{
    public class ExamineeManager
    {
        // add an examinee to the db
        public static void Add(Examinee examinee)
        {
            var context = new ExamineeContext();
            context.Examinees.Add(examinee);
            context.SaveChanges();
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
