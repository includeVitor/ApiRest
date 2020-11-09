using Microsoft.Extensions.DependencyInjection;
using SmartDataInitiative.Business.Interfaces;
using SmartDataInitiative.Business.Interfaces.Services;
using SmartDataInitiative.Business.Notications;
using SmartDataInitiative.Business.Services;
using SmartDataInitiative.Data.Context;
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

            // services

            services.AddScoped<IProjectService, ProjectService>();
            services.AddScoped<IFieldService, FieldService>();
            services.AddScoped<IReportModelService, ReportModelService>();
            services.AddScoped<IModelService, ModelService>();
            services.AddScoped<IReportService, ReportService>();
            services.AddScoped<IFeedbackService, FeedbackService>();


            services.AddScoped<INotify, Notifier>();

            return services;
        }
    }
}
