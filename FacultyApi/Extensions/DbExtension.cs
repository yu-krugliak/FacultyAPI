using FacultyApi.DataBase;
using FacultyApi.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FacultyApi.Controllers
{
    public static class DbExtension
    {
        public static void AddDbServices(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddEntityFrameworkNpgsql()
                .AddDbContext<Context>(optionsBuilder =>
                    optionsBuilder.UseNpgsql(Configuration.GetConnectionString("FacultyDb"),
                        contextOptionsBuilder => contextOptionsBuilder
                            .MigrationsAssembly("DbMigrations")));

            services.AddScoped<IStudentsRepository, StudentsRepository>();
            services.AddScoped<IGroupsRepository, GroupsRepository>();
            services.AddScoped<IEducationTypesRepository, EducationTypesRepository>();
            services.AddScoped<ISubjectsRepository, SubjectsRepository>();
            services.AddScoped<ILecturersRepository, LecturersRepository>();
            services.AddScoped<ILessonsRepository, LessonsRepository>();
        }

    }
}
