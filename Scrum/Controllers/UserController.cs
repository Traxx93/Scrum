using AutoMapper;
using Scrum.Infrastructure.Context;
using Scrum.Infrastructure.Entities;
using Scrum.Infrastructure.Enums;
using Scrum.Models.UserViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Scrum.Controllers
{
    public class UserController : Controller
    {
        IMapper mapper;
        ScrumContext context;

        public UserController(IMapper mapper, ScrumContext dbContext)
        {
            this.mapper = mapper;
            this.context = dbContext;
        }

        
        // GET: User
        [HttpGet]
        public ActionResult IndexUser()
        {
            var usersEntities = context.Users.ToList();
            var usersViewModel = mapper.Map<IEnumerable<User>, IEnumerable<ListOfUsersViewModel>>(usersEntities);

            return View(usersViewModel);
        }
        [HttpGet]
        public ActionResult AddUser()
        {
            var addUserViewModel = new AddUserViewModel();

            return View(addUserViewModel);
        }

        [HttpPost]
        public ActionResult AddUser(AddUserViewModel addUserViewModel)
        {
            if (ModelState.IsValid)
            {
                var userEntity = mapper.Map<AddUserViewModel, User>(addUserViewModel);
            
                context.Users.Add(userEntity);
                context.SaveChanges();
                return RedirectToAction("IndexUser");
            }

            return View(addUserViewModel);
        }
        [HttpGet]
        public ActionResult EditUser(int id)
        {
            var editUserEntity = context.Users.Where(u => u.UserID == id).FirstOrDefault();
            var editUserViewModel = mapper.Map<User, EditUserViewModel>(editUserEntity);
            
            return View(editUserViewModel);
        }

        public ActionResult EditUser(EditUserViewModel editUserViewModel)
        {
            if (ModelState.IsValid)
            {
                var editUserEntity = context.Users.Find(editUserViewModel.UserID);

                editUserEntity.FirstName = editUserViewModel.FirstName;
                editUserEntity.LastName = editUserViewModel.LastName;
                editUserEntity.Role = editUserViewModel.Role;

                context.SaveChanges();
                return RedirectToAction("IndexUsers");
            }

            return View(editUserViewModel);
        }

        [HttpGet]
        public ActionResult DetailsUser(int id)
        {
            var detailsUserEntity = context.Users.Find(id);

            var detailsUserViewModel = mapper.Map<User, DetailsUserViewModel>(detailsUserEntity);
            return View(detailsUserViewModel);
        }
        
        //public MvcHtmlString SelectListItem ListOfRoles()
        //{
        //    IEnumerable<Role> values = Enum.GetValues(typeof(Role)).Cast<Role>();
        //    IEnumerable<SelectListItem> items = from value on values


        //    return;
        //}
    }

}