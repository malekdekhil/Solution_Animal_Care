using Animal_Care_WebAPI.Resources.EventResources;
using Animal_Care_WebAPI.Resources.RoleResources;
using Animal_Care_WebAPI.Resources.UserResources;
using AutoMapper;
using Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Animal_Care_WebAPI.Mapping
{
    public class Mapping:Profile
    {
        public Mapping()
        {
            // event----------------------------------
            //Mapp de BDD Vers Ressources(vue)
            CreateMap<Event, EventResource>();
            CreateMap<Event, SaveEventResouce>();
            CreateMap<Event, EventResourceUpdate>();
             //Mapp Ressources(vue) vers BDD
            CreateMap<EventResource, Event>();
             CreateMap<EventResourceUpdate, Event>();
 


            // User-------------------------------------
            //Mapp de BDD Vers Ressources(vue)
            CreateMap<User, UserResource>();
            //Mapp Ressources(vue) ver BDD
            CreateMap<UserResource, User>();

            // pr save je doit changer le user pr le mdp
 
            // Role-------------------------------------
            CreateMap<Role, RoleResource>();
            CreateMap<RoleResource, Role>();

        }
    }
}
