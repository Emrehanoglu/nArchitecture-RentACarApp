using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistance.EntityConfigurations;

public class CarConfiguration : IEntityTypeConfiguration<Car>
{
	//tüm konfigürasyonlarımı burada yapabilirim
	public void Configure(EntityTypeBuilder<Car> builder)
	{
		//veritabanındaki Cars tablosuna karsılık gelsin
		//Id alanı key bir alan olsun
		builder.ToTable("Cars").HasKey(b => b.Id);

		//Cars entitysinin Id prop 'u veritabanındaki
		//Cars tablosundaki Id alanına karsılık gelsin,
		//Id alanı gerekli bir alan olsun
		builder.Property(b => b.Id).HasColumnName("Id").IsRequired();
		builder.Property(b => b.ModelId).HasColumnName("ModelId").IsRequired();
		builder.Property(b => b.Kilometer).HasColumnName("Kilometer").IsRequired();
		builder.Property(b => b.CarState).HasColumnName("State").IsRequired();
		builder.Property(b => b.ModelYear).HasColumnName("ModelYear").IsRequired();
		builder.Property(b => b.CreatedDate).HasColumnName("CreatedDate").IsRequired();
		builder.Property(b => b.UpdatedDate).HasColumnName("UpdatedDate");
		builder.Property(b => b.DeletedDate).HasColumnName("DeletedDate");

		//bire bir ilişkiden dolayı bir arabanın bir tane modeli olur.
		builder.HasOne(b => b.Model);

		//soft delete olanları getirmeyeceğim global filter 'ı burada yazıyorum.
		//buradaki sorgu Car repositorylerindeki tüm metotlara uygulanacak.
		//DeletedDate yok ise ilgili data silinmiş olarak işaretlenmemiş demektir.
		builder.HasQueryFilter(b => !b.DeletedDate.HasValue);
	}
}