using AutoMapper;
using Scrum.Infrastructure.Context;
using Scrum.Infrastructure.Entities;
using Scrum.Infrastructure.Enums;
using Scrum.Models.WorkItemViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Scrum.Controllers
{
    public class WorkItemController : Controller
    {

        IMapper mapper;
        ScrumContext context;

        public WorkItemController(IMapper mapper, ScrumContext context)
        {
            this.mapper = mapper;
            this.context = context;
        }


        [HttpGet]
        public ActionResult IndexWorkItem()
        {
            var workItemsEntities = context.WorkItems.ToList();
            var workItemsViewModel = mapper.Map<IEnumerable<WorkItem>, IEnumerable<WorkItemViewModel>>(workItemsEntities);
            var userEntity = new User();
            foreach (var item in workItemsViewModel)
            {
                userEntity = context.Users.Find(item.UserID);
                item.UserFirstName = userEntity.FirstName;
                item.UserLastName = userEntity.LastName;
            }
            return View(workItemsViewModel);
        }
        [HttpGet]
        public ActionResult AddWorkItem(int? id)
        {
            var addWorkItemViewModel = new AddWorkItemViewModel();
            if (id != null)
            {
                addWorkItemViewModel.UserID = id;
            }
            else
            {
                addWorkItemViewModel.ListOfUserIDs = getAllUsers();
            }
            return View(addWorkItemViewModel);
        }

        [HttpPost]
        public ActionResult AddWorkItem(AddWorkItemViewModel addWorkItemViewModel)
        {
            if (ModelState.IsValid)
            {
                var workItemEntity = mapper.Map<AddWorkItemViewModel, WorkItem>(addWorkItemViewModel);
                context.WorkItems.Add(workItemEntity);
                context.SaveChanges();
                return RedirectToAction("IndexWorkItem");
            }

            return View("AddWorkItem");

        }

        public ActionResult EditWorkItem(int? id)
        {
            var workItemEntity = context.WorkItems.Find(id);
            var workItemViewModel = mapper.Map<WorkItem, EditWorkItemViewModel>(workItemEntity);

            workItemViewModel.ListOfUserIDs = getAllUsers();

            return View(workItemViewModel);
        }
        [HttpPost]
        public ActionResult EditWorkItem(EditWorkItemViewModel model)
        {
            if (ModelState.IsValid)
            {
                var workItemEntity = context.WorkItems.Find(model.WorkItemID);
                workItemEntity.Subject = model.Subject;
                workItemEntity.Status = model.Status;
                workItemEntity.Description = model.Description;
                workItemEntity.UserID = model.UserID;
                context.SaveChanges();
                return RedirectToAction("IndexWorkItem");
            }

            return View(model);
        }

        public ActionResult DetailWorkItem(int id)
        {
            var workItemEntity = context.WorkItems.Find(id);
            var workItemViewModel = mapper.Map<WorkItem, DetailWorkItemViewModel>(workItemEntity);
            
            if(workItemEntity.UserID != null)
            {
                var userEntity = context.Users.Find(workItemViewModel.UserID);
                workItemViewModel.UserFirstName = userEntity.FirstName;
                workItemViewModel.UserLastName = userEntity.LastName;
            }
            return View(workItemViewModel);
        }


        private IEnumerable<SelectListItem> getAllUsers()
        {
            var allUsers = context.Users.Select(u =>
                new SelectListItem
                {
                    Value = u.UserID.ToString(),
                    Text = u.FirstName + " " + u.LastName
                }
            ).ToList();

            var userIDs = new SelectList(allUsers, "Value", "Text");
            return userIDs;
        }

        [HttpPost]
        public ActionResult ChangeStatus(EditWorkItemViewModel model)
        {
            var workItemEntity = context.WorkItems.Find(model.WorkItemID);
            workItemEntity.Status = (Scrum.Infrastructure.Enums.Status)((int)(model.Status + 1) % 3);
            if(workItemEntity.Status == Infrastructure.Enums.Status.IN_PROGRESS)
            {
                workItemEntity.StartDate = DateTime.Today;
            }
            

            context.SaveChanges();

            return RedirectToAction("EditWorkItem");
        }


        [HttpPost]
        public void ChangeStatusOfWorkItem(int id, string status)
        {
            var workItemEntity = context.WorkItems.Find(id);

            switch (status) {

                case "to-do":
                        workItemEntity.Status = Status.TO_DO;
                        break;
                case "in-progress":
                    workItemEntity.Status = Status.IN_PROGRESS;
                    break;
                case "done":
                    workItemEntity.Status = Status.DONE;
                    break;
            }
            
        }
    }
}
