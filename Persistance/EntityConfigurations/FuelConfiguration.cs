using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistance.EntityConfigurations;

public class FuelConfiguration : IEntityTypeConfiguration<Fuel>
{
	//tüm konfigürasyonlarımı burada yapabilirim
	public void Configure(EntityTypeBuilder<Fuel> builder)
	{
		//veritabanındaki Fuels tablosuna karsılık gelsin
		//Id alanı key bir alan olsun
		builder.ToTable("Fuels").HasKey(b => b.Id);

		//Fuels entitysinin Id prop 'u veritabanındaki
		//Fuels tablosundaki Id alanına karsılık gelsin,
		//Id alanı gerekli bir alan olsun
		builder.Property(b => b.Id).HasColumnName("Id").IsRequired();
		builder.Property(b => b.Name).HasColumnName("Name").IsRequired();
		builder.Property(b => b.CreatedDate).HasColumnName("CreatedDate").IsRequired();
		builder.Property(b => b.UpdatedDate).HasColumnName("UpdatedDate");
		builder.Property(b => b.DeletedDate).HasColumnName("DeletedDate");

		//Fuel tablosundaki Name alanı tekrar edilemesin yani uniqe bir alan olsun istiyorum
		builder.HasIndex(indexExpression: b => b.Name, name: "UK_Fuels_Name").IsUnique();

		//bire cok ilişkiden dolayı bir marka birden fazla modele sahip olabilir.
		builder.HasMany(b => b.Models);

		//soft delete olanları getirmeyeceğim global filter 'ı burada yazıyorum.
		//buradaki sorgu Fuel repositorylerindeki tüm metotlara uygulanacak.
		//DeletedDate yok ise ilgili data silinmiş olarak işaretlenmemiş demektir.
		builder.HasQueryFilter(b => !b.DeletedDate.HasValue);
	}
}
