using AutoMapper;
using Scrum.Infrastructure.Context;
using Scrum.Infrastructure.Entities;
using Scrum.Models.ProjectViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Scrum.Controllers
{
    public class ProjectController : Controller
    {
        IMapper mapper;
        ScrumContext context;

        public ProjectController(IMapper mapper, ScrumContext context)
        {
            this.mapper = mapper;
            this.context = context;
        }
        // GET: Project
        [HttpGet]
        public ActionResult IndexProject()
        {
            var projectEntities = context.Project.ToList();
            var projectViewModel = mapper.Map<IEnumerable<Project>, IEnumerable<ProjectViewModel>>(projectEntities);

            return View(projectViewModel);
        }

        // GET: Project/Details/5
        public ActionResult DetailsProject(int id)
        {
            var projetEntity = context.Project.Find(id);
            var projectViewModel = mapper.Map<Project, DetailsProjectViewModel>(projetEntity);

            return View(projectViewModel);
        }

        // GET: Project/Create
        public ActionResult AddProject()
        {
            var addProjectViewModel = new AddProjectViewModel();
            
            return View(addProjectViewModel);
        }

        // POST: Project/Create
        [HttpPost]
        public ActionResult AddProject(AddProjectViewModel newProjectViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var projectEntity = mapper.Map<AddProjectViewModel, Project>(newProjectViewModel);

                    context.Project.Add(projectEntity);
                    context.SaveChanges();
                    return RedirectToAction("IndexProject");

                }

                return View(newProjectViewModel);
            }
            catch
            {
                return View(newProjectViewModel);
            }
        }

        // GET: Project/Edit/5
        public ActionResult Edit(int id)
        {
            var projectEntity = context.Project.Find(id);
            var projectViewModel = mapper.Map<Project, EditProjectViewModel>(projectEntity);

            return View(projectViewModel);
        }

        // POST: Project/Edit/5
        [HttpPost]
        public ActionResult Edit(EditProjectViewModel projectViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var projectEntity = context.Project.Find(projectViewModel.ProjectID);

                    projectEntity.ProjectName = projectViewModel.ProjectName;
                    projectEntity.Description = projectViewModel.Description;
                    projectEntity.Owner = projectViewModel.Owner;

                    context.SaveChanges();
                    return RedirectToAction("IndexProject");
                
                }

                return View(projectViewModel);
            }
            catch
            {
                return View(projectViewModel);
            }
        }
        

    }
}
