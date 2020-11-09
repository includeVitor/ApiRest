using Microsoft.Extensions.DependencyInjection;
using SmartDataInitiative.Business.Interfaces;
using SmartDataInitiative.Business.Interfaces.Services;
using SmartDataInitiative.Business.Notications;
using SmartDataInitiative.Business.Services;
using SmartDataInitiative.Data.Context;
using SmartDataInitiative.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartDataInitiative.Api.Configuration
{
    public static class DependencyInjectionConfig { 
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            // context

            services.AddScoped<MyDbContext>();


            // repository

            services.AddScoped<IProjectRepository, ProjectRepository>();
            services.AddScoped<IFieldRepository, FieldRespository>();
            services.AddScoped<IReportModelRepository, ReportModelRespository>();
            services.AddScoped<IModelRespository, ModelRepository>();
            services.AddScoped<IReportRepository, ReportRepository>();
            services.AddScoped<IFeedbackRepository, FeedbackRepository>();


            // services

            services.AddScoped<INotify, Notifier>();

            services.AddScoped<IProjectService, ProjectService>();
            services.AddScoped<IFieldService, FieldService>();
            services.AddScoped<IReportModelService, ReportModelService>();
            services.AddScoped<IModelService, ModelService>();
            services.AddScoped<IReportService, ReportService>();
            services.AddScoped<IFeedbackService, FeedbackService>();


           

            return services;
        }
    }
}
