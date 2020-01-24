using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NsPluginExample.DAL.Contexts;

namespace NsPluginExample
{
    internal static class Migrations
    {
        /// <summary>
        /// Выполнит миграции БД
        /// </summary>
        /// <param name="services"></param>
        public static void UseMigrations(this IServiceCollection services)
        {
            using (var context = services.BuildServiceProvider().GetService<NsPluginExampleContext>())
            {
                context.Database.Migrate();
            }
        }
    }
}
