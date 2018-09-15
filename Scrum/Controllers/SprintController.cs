using AutoMapper;
using Scrum.Infrastructure.Context;
using Scrum.Infrastructure.Entities;
using Scrum.Models.SprintViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Scrum.Controllers
{
    public class SprintController : Controller
    {

        IMapper mapper;
        ScrumContext context;

        public SprintController(IMapper mapper, ScrumContext context)
        {
            this.mapper = mapper;
            this.context = context;
        }
        // GET: Sprint
        public ActionResult IndexSprints()
        {
            var sprintsEntities = context.Sprint.ToList();
            var sprintViewModel = mapper.Map<IEnumerable<Sprint>, IEnumerable<SprintViewModel>>(sprintsEntities);

            return View(sprintViewModel);
        }

        public ActionResult IndexSprintsForProject(int projectID)
        {
            var projectEntity = context.Project.Find(projectID);
            var sprintsForProject = context.Sprint.Where(s => s.ProjectID == projectID).AsEnumerable();
            var sprintViewModel = mapper.Map<IEnumerable<Sprint>, IEnumerable<SprintViewModel>>(sprintsForProject);
            ViewBag.ProjectID = projectID;
            var project = context.Project.Where(p => p.ProjectID == projectID).FirstOrDefault();
            ViewBag.Project = project;

            return View(sprintViewModel);
        }

        // GET: Sprint/Details/5
        public ActionResult DetailsSprint(int id)
        {
            var sprintEntity = context.Sprint.Find(id);
            var sprintViewModel = mapper.Map<Sprint, DetailSprintViewModel>(sprintEntity);

            return View(sprintViewModel);
        }

        // GET: Sprint/Create
        public ActionResult AddSprint(int projectId)
        {
            var addSprintViewModel = new AddSprintViewModel
            {
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddMonths(1),
                ProjectID = projectId
            };
            ViewBag.ProjectID = projectId;
            return View(addSprintViewModel);
        }

        // POST: Sprint/Create
        [HttpPost]
        public ActionResult AddSprint(AddSprintViewModel addSprintViewModel)
        {

            if (ModelState.IsValid)
            {
                var sprintEntity = mapper.Map<AddSprintViewModel, Sprint>(addSprintViewModel);

                context.Sprint.Add(sprintEntity);
                context.SaveChanges();
                return RedirectToAction("IndexSprintsForProject", new { projectID = addSprintViewModel.ProjectID });
            }
            return View();
        }



        // GET: Sprint/Edit/5
        public ActionResult EditSprint(int id)
        {
            var sprintEntity = context.Sprint.Find(id);
            var sprintVM = mapper.Map<Sprint, EditSprintViewModel>(sprintEntity);

            return View(sprintVM);
        }

        // POST: Sprint/Edit/5
        [HttpPost]
        public ActionResult EditSprint(EditSprintViewModel model)
        {
            try
            {
                var editSprintEntity = context.Sprint.Find(model.SprintID);
                if (ModelState.IsValid)
                {
                    editSprintEntity.MainTask = model.MainTask;
                    editSprintEntity.StartDate = model.StartDate;
                    editSprintEntity.EndDate = model.EndDate;
                    editSprintEntity.ProjectID = model.ProjectID;

                    context.SaveChanges();
                    return RedirectToAction("IndexSprint");
                }

                editSprintEntity.MainTask = model.MainTask;
                editSprintEntity.StartDate = model.StartDate;
                editSprintEntity.EndDate = model.EndDate;
                editSprintEntity.ProjectID = model.ProjectID;


                return View(model);
            }
            catch
            {

                return View(model);
            }
        }


    }
}
