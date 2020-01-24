using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NsPluginExample.Domain.Models.NsModels.OAuth;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace NsPluginExample.DAL.Mappings
{
    class OauthTokenMapping: IEntityTypeConfiguration<OAuth2Token>
    {
        public void Configure(EntityTypeBuilder<OAuth2Token> builder)
        {
            builder.ToTable("OAuthToken").HasKey(x => x.Id);
            builder.Property(x => x.Id).HasValueGenerator<GuidValueGenerator>();
            builder.Ignore(x => x.IsExpired);
        }
    }
}
