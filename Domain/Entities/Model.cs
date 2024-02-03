using Core.Persistance.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class Model : Entity<Guid>
{
	public Guid BrandId { get; set; } //modelin hangi marka id 'sine sahip olduğu bilgisi
	public Guid FuelId { get; set; } //modelin yakıt id 'si
	public Guid TransmissionId { get; set; } //modelin vites tipi id 'si
	public string Name { get; set; } //modelin adı
	public decimal DailyPrice { get; set; } //modelin günlük fiyatı
	public string ImageUrl { get; set; }

	public virtual Brand? Brand { get; set; } //bir modelin bir markası olur
	public virtual Fuel? Fuel { get; set; } //bir modelin bir yakıt tipi olur 
	public virtual Transmission? Transmission { get; set; } //bir modelin bir vites tipi olur
	public virtual ICollection<Car> Cars { get; set; } //bir modelin birden fazla arabası olur

    public Model()
    {
		Cars = new HashSet<Car>();
    }

	//yardımcı ctor
	public Model(Guid id, Guid brandId, Guid fuelId, Guid transmissionId, string name, decimal dailyPrice, string imageUrl):this()
	{
		Id = id;
		BrandId = brandId;
		FuelId = fuelId;
		TransmissionId = transmissionId;
		Name = name;
		DailyPrice = dailyPrice;
		ImageUrl = imageUrl;
	}
}