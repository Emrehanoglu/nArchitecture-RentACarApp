using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Contexts;

public class BaseDbContext:DbContext
{
    protected IConfiguration Configuration { get; set; }
    public DbSet<Brand> Brands { get; set; }
    public DbSet<Car> Cars { get; set; }
    public DbSet<Model> Models { get; set; }
    public DbSet<Fuel> Fuels { get; set; }
    public DbSet<Transmission> Transmissions { get; set; }

    //veritabanına erişmek için konfigürasyonlarımı yapıyorum
    public BaseDbContext(DbContextOptions dbContextOptions, IConfiguration configuration):base(dbContextOptions)
    {
        Configuration = configuration;
        Database.EnsureCreated(); //once veritabanının olustuğundan emin ol diyorum
    }

	//buradaki Brand entitysini olduğu gibi değilde konfigüre ederek kullanacağım
	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
        //assembly 'deki mevcut konfigürasyonları bul ve uygula demiş oluyorum
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
	}
}
