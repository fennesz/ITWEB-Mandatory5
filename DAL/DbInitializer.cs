using System;
using System.Linq;
using ITWEB_Mandatory5.Models;

namespace ITWEB_Mandatory5.DAL
{
    public static class DbInitializer
    {

        public static void Initialize(ApplicationContext context, IRepository<Component> compRepo)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Components.Any())
            {
                return;   // DB has been seeded
            }

            var components = new Component[]
            {
            new Component
            {
                AdminComment = "This component shouldn't be given to students",
                ComponentNumber = 1337,
                SerialNo = "1337-KGLK",
                Status = ComponentStatus.ReservedAdmin,
                UserComment = "I loaned this, sincerely a student. LOL!"
            },
                new Component
                {
                    AdminComment = "This is another lousy component",
                    ComponentNumber = 42,
                    SerialNo = "42-yo",
                    Status = ComponentStatus.Defect,
                    UserComment = "Shit didn't work... wtf?"
                },

            };

            foreach (Component s in components)
            {
                compRepo.Insert(s);
            }
            
        }
    }
}
