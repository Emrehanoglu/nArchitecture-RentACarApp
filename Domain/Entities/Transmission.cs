using Core.Persistance.Repositories;

namespace Domain.Entities;

//her modelin vites tipi vardır
public class Transmission : Entity<Guid>
{
	public string Name { get; set; } //otomatik mi manuel mi
	public virtual ICollection<Model> Models { get; set; }
	public Transmission()
	{
		Models = new HashSet<Model>();
	}
	public Transmission(Guid id, string name) : this() //this() ile parametresiz ctor 'u da calıstırsın 
	{
		Id = id;
		Name = name;
	}
}
