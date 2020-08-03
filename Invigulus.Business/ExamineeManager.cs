using Invigulus.Data;
using Invigulus.Data.Domain;
using System;

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
    }
}
