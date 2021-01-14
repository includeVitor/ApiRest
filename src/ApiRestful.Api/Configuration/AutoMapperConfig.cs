using AutoMapper;
using ApiRestful.Api.ViewModels;
using ApiRestful.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestful.Api.Configuration
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Project, ProjectViewModel>().ReverseMap();
            CreateMap<Field, FieldViewModel>().ReverseMap();
            CreateMap<ReportModel, ReportModelViewModel>().ReverseMap();
            CreateMap<Model, ModelViewModel>().ReverseMap();
            CreateMap<Report, ReportViewModel>().ReverseMap();
            CreateMap<Feedback, FeedbackViewModel>().ReverseMap();
        }
    }
}
