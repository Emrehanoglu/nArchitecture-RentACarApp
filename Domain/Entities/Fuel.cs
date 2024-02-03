using Core.Persistance.Repositories;

namespace Domain.Entities;

//her modelin yakıt tipi vardır
public class Fuel : Entity<Guid>
{
	public string Name { get; set; }
	public virtual ICollection<Model> Models { get; set; }
	public Fuel()
	{
		Models = new HashSet<Model>();
	}
	public Fuel(Guid id, string name) : this() //this() ile parametresiz ctor 'u da calıstırsın 
	{
		Id = id;
		Name = name;
	}
}
