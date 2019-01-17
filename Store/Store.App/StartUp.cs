using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Store.Data;
using Store.Services;
using Store.Services.Contracts;
using AutoMapper;
using System;

namespace Store.App
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var serviceProvider = ConfigureService();

            var engine = new Engine(serviceProvider);
            engine.Run();
        }

        private static IServiceProvider ConfigureService()
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddDbContext<StoreDbContext>(x => x.UseSqlServer(ServerConfiguration.ConnectionString));

            serviceCollection.AddTransient<IDatabaseInitializerService, DatabaseInitializerService>();
            serviceCollection.AddTransient<IUserService, UserService>();
            serviceCollection.AddTransient<IProductService, ProductService>();
            serviceCollection.AddTransient<ICategoryService, CategoryService>();
            serviceCollection.AddTransient<ICommentService, CommentService>();

            serviceCollection.AddSingleton<IUserSessionService, UserSessionService>();

            serviceCollection.AddAutoMapper(x => x.AddProfile<StoreFrofile>());

            var serviceProvider = serviceCollection.BuildServiceProvider();

            return serviceProvider;
        }
    }
}
