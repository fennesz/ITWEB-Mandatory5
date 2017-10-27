using System;
using System.Linq;
using ITWEB_Mandatory5.Models;

namespace ITWEB_Mandatory5.DAL
{
    public static class DbInitializer
    {

        public static void Initialize(ApplicationContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Components.Any())
            {
                return;   // DB has been seeded
            }

            var components = new Models.Component[]
            {
            new Models.Component
            {
                AdminComment = "This component shouldn't be given to students",
                ComponentNumber = 1337,
                SerialNo = "1337-KGLK",
                Status = ComponentStatus.ReservedAdmin,
                UserComment = "I loaned this, sincerely a student. LOL!"
            },
            };

            foreach (Models.Component s in components)
            {
                context.Components.Add(s);
            }
            context.SaveChanges();

            //var categories = new Category[]
            //{
            //    new Category()
            //    {
            //        Name = "The best category"
            //    }
            //};
            //context.SaveChanges();
        }
    }
}
