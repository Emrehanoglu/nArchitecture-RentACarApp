using Core.Persistance.Repositories;
using Domain.Enumes;

namespace Domain.Entities;

//araba nesnesini karsılayacak
public class Car : Entity<Guid>
{
	public Guid ModelId { get; set; } //bu araba hangi model 'e ait id bilgisi
	public int Kilometer { get; set; } //arabanın kilometre bilgisi
    public short ModelYear { get; set; } //arabanın model yılı
	public string Plate { get; set; } //arabanın plaka bilgisi
    public short MinFindexScore { get; set; } //arabanın min. findex skor bilgisi
	public CarState CarState { get; set; } //arabanın durumu bilgisi, kirada mı, bakımda mı, uygun mu değil mi

    public virtual Model? Model { get; set; }

    public Car()
    {
        
    }

	public Car(
		Guid id,
		Guid modelId,
		CarState carState,
		int kilometer,
		short modelYear,
		string plate,
		short minFindexScore
	)
		: this()
	{
		Id = id;
		ModelId = modelId;
		CarState = carState;
		Kilometer = kilometer;
		ModelYear = modelYear;
		Plate = plate;
		MinFindexScore = minFindexScore;
	}
}