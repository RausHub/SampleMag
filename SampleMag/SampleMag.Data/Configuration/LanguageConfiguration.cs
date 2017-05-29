using SampleMag.Entity;

namespace SampleMag.Data
{
    public class LanguageConfiguration : EntityBaseConfiguration<Language>
    {
        public LanguageConfiguration()
        {
            Property(l => l.Name).IsRequired().HasMaxLength(50);
        }
    }
}
