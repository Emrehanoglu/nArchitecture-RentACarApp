using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistance.EntityConfigurations;

public class TransmissionConfiguration : IEntityTypeConfiguration<Transmission>
{
	//tüm konfigürasyonlarımı burada yapabilirim
	public void Configure(EntityTypeBuilder<Transmission> builder)
	{
		//veritabanındaki Transmissions tablosuna karsılık gelsin
		//Id alanı key bir alan olsun
		builder.ToTable("Transmissions").HasKey(b => b.Id);

		//Transmissions entitysinin Id prop 'u veritabanındaki
		//Transmissions tablosundaki Id alanına karsılık gelsin,
		//Id alanı gerekli bir alan olsun
		builder.Property(b => b.Id).HasColumnName("Id").IsRequired();
		builder.Property(b => b.Name).HasColumnName("Name").IsRequired();
		builder.Property(b => b.CreatedDate).HasColumnName("CreatedDate").IsRequired();
		builder.Property(b => b.UpdatedDate).HasColumnName("UpdatedDate");
		builder.Property(b => b.DeletedDate).HasColumnName("DeletedDate");

		//Transmission tablosundaki Name alanı tekrar edilemesin yani uniqe bir alan olsun istiyorum
		builder.HasIndex(indexExpression: b => b.Name, name: "UK_Transmissions_Name").IsUnique();

		//bire cok ilişkiden dolayı bir marka birden fazla modele sahip olabilir.
		builder.HasMany(b => b.Models);

		//soft delete olanları getirmeyeceğim global filter 'ı burada yazıyorum.
		//buradaki sorgu Transmission repositorylerindeki tüm metotlara uygulanacak.
		//DeletedDate yok ise ilgili data silinmiş olarak işaretlenmemiş demektir.
		builder.HasQueryFilter(b => !b.DeletedDate.HasValue);
	}
}
