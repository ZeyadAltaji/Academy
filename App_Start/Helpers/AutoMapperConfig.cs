﻿using Academy.Models;
using AutoMapper;
using Data_Access;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Academy
{
    public static class AutoMapperConfig
    {
        public static IMapper Mapper { get;private set; }
        public static void init()
        {

            var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Category, CategoryModel>()
                    .ForMember(dst => dst.ParentID, src => src.MapFrom(e => e.Category2.Parent_ID))
                    .ForMember(dst => dst.ParentName, src => src.MapFrom(e => e.Category2.Name))
                    .ReverseMap();
                    cfg.CreateMap<Trainer, TrainerModel>().ReverseMap();

                    cfg.CreateMap<Course, CourseModel>()
                    .ForMember(dst => dst.TrainerName,src => src.MapFrom(e=>e.Trainer.Name))
                    .ForMember(dst => dst.CategoryName,src => src.MapFrom(e=>e.Category.Name))
                    .ReverseMap();
               

                });
            Mapper =config.CreateMapper();  
        }
    }
}