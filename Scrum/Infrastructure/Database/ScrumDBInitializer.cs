using Scrum.Infrastructure.Context;
using Scrum.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Scrum.Infrastructure.Database
{
    /// <summary>
    /// This method is used to initialize database each time the application is started
    /// </summary>
    public class ScrumDBInitializer : DropCreateDatabaseAlways<ScrumContext>
    {
        protected override void Seed(ScrumContext context)
        {

            var user1 = new User() { FirstName = "Korisnik", LastName = "Korisnik 1", Role = Enums.Role.PRODUCT_OWNER, UserName = "Kor1", Password = "s"};
            var user2 = new User() { FirstName = "Korisnik", LastName = "Korisnik 2", Role = Enums.Role.SCRUM_MASTER, UserName = "Kor2", Password = "s" };
            var user3 = new User() { FirstName = "Korisnik", LastName = "Korisnik 3", Role = Enums.Role.TEAM_MEMBER, UserName = "Kor3", Password = "s" };
            var user4 = new User() { FirstName = "Korisnik", LastName = "Korisnik 4", Role = Enums.Role.TEAM_MEMBER, UserName = "Kor4", Password = "s" };

            context.Users.Add(user1);
            context.Users.Add(user2);
            context.Users.Add(user3);
            context.Users.Add(user4);

            context.SaveChanges();

            var workItem1 = new WorkItem() { Subject = "Subject 1", Description = "Some description 1", Status = Enums.Status.TO_DO, UserID = 1 };
            var workItem2 = new WorkItem() { Subject = "Subject 2", Description = "Some description 2", Status = Enums.Status.TO_DO, UserID = 2 };
            var workItem3 = new WorkItem() { Subject = "Subject 3", Description = "Some description 3", Status = Enums.Status.TO_DO, UserID = 3 };


            var workItemsList = new List<WorkItem>();

            workItemsList.Add(workItem1);
            workItemsList.Add(workItem2);
            workItemsList.Add(workItem3);


            context.WorkItems.Add(workItem1);
            context.WorkItems.Add(workItem2);
            context.WorkItems.Add(workItem3);

            context.SaveChanges();

            var project1 = new Project() { ProjectName = "Project 1", Description = "Project description 1", Owner = "Some name 1" };
            var project2 = new Project() { ProjectName = "Project 2", Description = "Project description 2", Owner = "Some name 2" };
            var project3 = new Project() { ProjectName = "Project 3", Description = "Project description 3", Owner = "Some name 3" };
            Console.WriteLine("{0} {1} {2}", project1.ProjectID, project2.ProjectID, project3.ProjectID);

            context.Project.Add(project1);
            context.Project.Add(project2);
            context.Project.Add(project3);

            context.SaveChanges();

            var sprint1 = new Sprint() { MainTask = "Main task", SprintName = "Sprint1", StartDate = DateTime.UtcNow.AddDays(-3), EndDate = DateTime.UtcNow.AddDays(20), ProjectID = project1.ProjectID };


            context.Sprint.Add(sprint1);
            context.SaveChanges();


            base.Seed(context);
        }
    }
}