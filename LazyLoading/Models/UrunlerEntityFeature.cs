using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Metadata.Ecma335;

namespace LazyLoading.Models
{
    public class UrunlerEntityFeature : IEntityTypeConfiguration<Urunler>
    {
        public void Configure(EntityTypeBuilder<Urunler> builder)
        {
            builder.HasData(DataGenerator.UrunlerGenerator());
        }
    }
}
