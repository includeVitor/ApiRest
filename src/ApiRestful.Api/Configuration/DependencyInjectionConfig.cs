using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using ApiRestful.Api.Extensions;
using ApiRestful.Business.Interfaces;
using ApiRestful.Business.Interfaces.Services;
using ApiRestful.Business.Notications;
using ApiRestful.Business.Services;
using ApiRestful.Data.Context;
using ApiRestful.Data.Repository;


namespace ApiRestful.Api.Configuration
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


            // User
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IUser, AspNetUser>();




            return services;
        }
    }
}
