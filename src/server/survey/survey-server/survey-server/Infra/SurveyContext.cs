using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using survey_server.Model;

namespace survey_server.Infra
{
    public class SurveyContext : DbContext
    {

        public SurveyContext(DbContextOptions options) 
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new SurveyConfig());
        }
    }

    public class SurveyConfig : IEntityTypeConfiguration<SurveyEntity>
    {
        public void Configure(EntityTypeBuilder<SurveyEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Idade).IsRequired();
            builder.Property(x => x.Estado).IsRequired();
            builder.Property(x => x.AreaAtuacao).IsRequired();
            builder.Property(x => x.TrabalhouAzure).IsRequired();
            builder.Property(x => x.TrabalhouAws).IsRequired();
            builder.Property(x => x.TrabalhouGoogleCloud).IsRequired();
            builder.Property(x => x.NivelInteresseGoogleCloud).IsRequired();
        }
    }
}
