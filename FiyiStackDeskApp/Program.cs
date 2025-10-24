using FiyiStackDeskApp.Areas.CMS.UserBack.Interfaces;
using FiyiStackDeskApp.Areas.CMS.UserBack.Repositories;
using FiyiStackDeskApp.Areas.FiyiStackDeskApp.DataBaseBack.Interfaces;
using FiyiStackDeskApp.Areas.FiyiStackDeskApp.DataBaseBack.Repositories;
using FiyiStackDeskApp.Areas.FiyiStackDeskApp.DataTypeBack.Interfaces;
using FiyiStackDeskApp.Areas.FiyiStackDeskApp.DataTypeBack.Repositories;
using FiyiStackDeskApp.Areas.FiyiStackDeskApp.FieldBack.Interfaces;
using FiyiStackDeskApp.Areas.FiyiStackDeskApp.FieldBack.Repositories;
using FiyiStackDeskApp.Areas.FiyiStackDeskApp.G1ConfigurationBack.Interfaces;
using FiyiStackDeskApp.Areas.FiyiStackDeskApp.G1ConfigurationBack.Repositories;
using FiyiStackDeskApp.Areas.FiyiStackDeskApp.NewsInLoginPageBack.Interfaces;
using FiyiStackDeskApp.Areas.FiyiStackDeskApp.NewsInLoginPageBack.Repositories;
using FiyiStackDeskApp.Areas.FiyiStackDeskApp.ProjectBack.Interfaces;
using FiyiStackDeskApp.Areas.FiyiStackDeskApp.ProjectBack.Repositories;
using FiyiStackDeskApp.Areas.FiyiStackDeskApp.TableBack.Interfaces;
using FiyiStackDeskApp.Areas.FiyiStackDeskApp.TableBack.Repositories;
using FiyiStackDeskApp.Areas.FiyiStackDeskApp.VersionControlBack.Interfaces;
using FiyiStackDeskApp.Areas.FiyiStackDeskApp.VersionControlBack.Repositories;
using FiyiStackDeskApp.Areas.System.FailureBack.Interfaces;
using FiyiStackDeskApp.Areas.System.FailureBack.Repositories;
using FiyiStackDeskApp.DatabaseContexts;
using FiyiStackDeskApp.Forms;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace FiyiStackDeskApp
{
    internal class Program
    {
        public static SharedComponent SharedComponent { get; set; } = new SharedComponent();

        [STAThread]
        static void Main()
        {
            IConfiguration configuration;

#if DEBUG
            // En modo debug, leé desde archivo físico (para desarrollo más cómodo)
            configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.Development.json", optional: true, reloadOnChange: true)
                .Build();
#else
            // En modo release, cargá el JSON embebido en el ejecutable
            configuration = BuildConfigurationFromEmbeddedResource("FiyiStackDeskApp.appsettings.json");
#endif

            var services = new ServiceCollection();

            //ADD SERVICE TO USE DATABASE (SCOPED)
            services.AddDbContext<FiyiStackDeskAppDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            //ADD SERVICES OF SYSTEM AREA
            services.AddScoped<IFailureRepository, FailureRepository>();

            //ADD SERVICES OF CMS AREA
            services.AddScoped<IUserRepository, UserRepository>();

            //ADD SERVICES OF FIYISTACKDESKAPP AREA
            services.AddScoped<IDataTypeRepository, DataTypeRepository>();
            services.AddScoped<IProjectRepository, ProjectRepository>();
            services.AddScoped<IDataBaseRepository, DataBaseRepository>();
            services.AddScoped<ITableRepository, TableRepository>();
            services.AddScoped<IFieldRepository, FieldRepository>();
            services.AddScoped<IVersionControlRepository, VersionControlRepository>();
            services.AddScoped<INewsInLoginPageRepository, NewsInLoginPageRepository>();

            //CONFIGURATIONS
            services.AddScoped<IG1ConfigurationRepository, G1ConfigurationRepository>();

            var serviceProvider = services.BuildServiceProvider();

            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm(serviceProvider));
        }
    }
}