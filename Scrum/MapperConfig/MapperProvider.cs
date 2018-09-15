using AutoMapper;
using Scrum.Infrastructure.Entities;
using Scrum.Models.ProjectViewModel;
using Scrum.Models.SprintViewModel;
using Scrum.Models.UserViewModel;
using Scrum.Models.WorkItemViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Scrum.MapperConfig
{
    public static class MapperProvider
    {
        public static MapperConfiguration Initialize()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, ListOfUsersViewModel>();
                cfg.CreateMap<User, AddUserViewModel>();
                cfg.CreateMap<AddUserViewModel, User>();
                cfg.CreateMap<EditUserViewModel, User>();
                cfg.CreateMap<User, EditUserViewModel>(); 
                cfg.CreateMap<User, DetailsUserViewModel>();


                cfg.CreateMap<WorkItem, WorkItemViewModel>();
                cfg.CreateMap<AddWorkItemViewModel, WorkItem>();
                cfg.CreateMap<WorkItem, EditWorkItemViewModel>();
                cfg.CreateMap<EditWorkItemViewModel, WorkItem>();
                cfg.CreateMap<WorkItem, DetailWorkItemViewModel>();

                cfg.CreateMap<Sprint, SprintViewModel>();
                cfg.CreateMap<AddSprintViewModel, Sprint>();
                cfg.CreateMap<Sprint, EditSprintViewModel>();
                cfg.CreateMap<EditSprintViewModel, Sprint>();
                cfg.CreateMap<Sprint, DetailSprintViewModel>();


                cfg.CreateMap<Project, ProjectViewModel>();
                cfg.CreateMap<AddProjectViewModel, Project>();
                cfg.CreateMap<EditProjectViewModel, Project>();
                cfg.CreateMap<Project, EditProjectViewModel>();
                cfg.CreateMap<Sprint, DetailsProjectViewModel>();

            });
            return config;
        }

    }
}