﻿using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.EntityConfigurations;

public class BrandConfiguration : IEntityTypeConfiguration<Brand>
{
	//tüm konfigürasyonlarımı burada yapabilirim
	public void Configure(EntityTypeBuilder<Brand> builder)
	{
		//veritabanındaki Brands tablosuna karsılık gelsin
		//Id alanı key bir alan olsun
		builder.ToTable("Brands").HasKey(b => b.Id);

		//Brands entitysinin Id prop 'u veritabanındaki
		//Brands tablosundaki Id alanına karsılık gelsin,
		//Id alanı gerekli bir alan olsun
		builder.Property(b => b.Id).HasColumnName("Id").IsRequired();
		builder.Property(b => b.Name).HasColumnName("Name").IsRequired();
		builder.Property(b => b.CreatedDate).HasColumnName("CreatedDate").IsRequired();
		builder.Property(b => b.UpdatedDate).HasColumnName("UpdatedDate");
		builder.Property(b => b.DeletedDate).HasColumnName("DeletedDate");

		//Brand tablosundaki Name alanı tekrar edilemesin yani uniqe bir alan olsun istiyorum
		builder.HasIndex(indexExpression:b=>b.Name, name:"UK_Brands_Name").IsUnique();

		//bire cok ilişkiden dolayı bir marka birden fazla modele sahip olabilir.
		builder.HasMany(b=>b.Models);

		//soft delete olanları getirmeyeceğim global filter 'ı burada yazıyorum.
		//buradaki sorgu Brand repositorylerindeki tüm metotlara uygulanacak.
		//DeletedDate yok ise ilgili data silinmiş olarak işaretlenmemiş demektir.
		builder.HasQueryFilter(b=>!b.DeletedDate.HasValue);
	}
}