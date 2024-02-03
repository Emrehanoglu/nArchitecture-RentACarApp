using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistance.EntityConfigurations;

public class ModelConfiguration : IEntityTypeConfiguration<Model>
{
	//tüm konfigürasyonlarımı burada yapabilirim
	public void Configure(EntityTypeBuilder<Model> builder)
	{
		//veritabanındaki Models tablosuna karsılık gelsin
		//Id alanı key bir alan olsun
		builder.ToTable("Models").HasKey(b => b.Id);

		//Models entitysinin Id prop 'u veritabanındaki
		//Models tablosundaki Id alanına karsılık gelsin,
		//Id alanı gerekli bir alan olsun
		builder.Property(b => b.Id).HasColumnName("Id").IsRequired();
		builder.Property(b => b.Name).HasColumnName("Name").IsRequired();
		builder.Property(b => b.BrandId).HasColumnName("BrandId").IsRequired();
		builder.Property(b => b.FuelId).HasColumnName("FuelId").IsRequired();
		builder.Property(b => b.TransmissionId).HasColumnName("TransmissionId").IsRequired();
		builder.Property(b => b.DailyPrice).HasColumnName("DailyPrice").IsRequired();
		builder.Property(b => b.ImageUrl).HasColumnName("ImageUrl").IsRequired();
		builder.Property(b => b.CreatedDate).HasColumnName("CreatedDate").IsRequired();
		builder.Property(b => b.UpdatedDate).HasColumnName("UpdatedDate");
		builder.Property(b => b.DeletedDate).HasColumnName("DeletedDate");

		//Model tablosundaki Name alanı tekrar edilemesin yani uniqe bir alan olsun istiyorum
		builder.HasIndex(indexExpression: b => b.Name, name: "UK_Models_Name").IsUnique();

		//bire bir ilişkiden dolayı bir modelin bir tane markası olur.
		//bire bir ilişkiden dolayı bir modelin bir tane yakıt tipi olur.
		//bire bir ilişkiden dolayı bir modelin bir tane vites tipi olur.
		builder.HasOne(b => b.Brand);
		builder.HasOne(b => b.Fuel);
		builder.HasOne(b => b.Transmission);

		//bire cok ilişkiden dolayı bir modelin birden fazla arabası olur
		builder.HasMany(b => b.Cars);

		//soft delete olanları getirmeyeceğim global filter 'ı burada yazıyorum.
		//buradaki sorgu Model repositorylerindeki tüm metotlara uygulanacak.
		//DeletedDate yok ise ilgili data silinmiş olarak işaretlenmemiş demektir.
		builder.HasQueryFilter(b => !b.DeletedDate.HasValue);
	}
}
