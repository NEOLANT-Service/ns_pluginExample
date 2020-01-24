using Microsoft.EntityFrameworkCore;
using NsPluginExample.Domain.Models.NsModels.OAuth;

namespace NsPluginExample.DAL.Contexts
{
    /// <summary>
    /// Контекст доступа к БД
    /// </summary>
    public class NsPluginExampleContext: DbContext
    {
        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public NsPluginExampleContext()
        {

        }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="options">Настройки контекста</param>
        public NsPluginExampleContext(DbContextOptions<NsPluginExampleContext> options):base(options)
        {

        }

        #region Repositories

        /// <summary>
        /// Токены безопасности
        /// </summary>
        public DbSet<OAuth2Token> OAuthTokens { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new Mappings.OauthTokenMapping());

            base.OnModelCreating(modelBuilder);
        }
    }
}
