using Application.Contracts.Repositories;
using Application.Contracts.Services;
using Application.Services;
using Infrastructure.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Ioc;

public static class DependencyContainer
{
    public static void RegisterServices(IServiceCollection service)
    {
        service.AddScoped<ICourseService, CourseService>();
        service.AddScoped<IUserService, UserService>();

        service.AddScoped<ICourseRepository, CourseRepository>();
        service.AddScoped<IUserRepository, UserRepository>();
    }
}