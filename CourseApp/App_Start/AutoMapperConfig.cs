using AutoMapper;
using CourseApp.Areas.Admin.Models;
using CourseApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CourseApp.App_Start
{
    public class AutoMapperConfig
    {
        public static IMapper Mapper  { get; private set; }
        public static void Init()
        {
            var config = new MapperConfiguration(cfg =>
             {
                 cfg.CreateMap<Category, CategoryModel>()
                 .ForMember(dst=> dst.Id,src=>src.MapFrom(e=>e.Id))
                 .ForMember(dst=> dst.Name,src=>src.MapFrom(e=>e.Name))
                 .ForMember(dst=> dst.ParentId,src=>src.MapFrom(e=>e.ParentId ))
                 .ForMember(dst=> dst.ParentName,src=>src.MapFrom(e=>e.Category2.Name))
                 .ReverseMap();

                 cfg.CreateMap<Trainer, TrainerModel>().ReverseMap();

             });
          Mapper=  config.CreateMapper();
        }
    }
   
}