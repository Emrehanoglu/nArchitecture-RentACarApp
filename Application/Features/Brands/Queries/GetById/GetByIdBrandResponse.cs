using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Brands.Queries.GetById;

public class GetByIdBrandResponse
{
	public Guid Id { get; set; }
	public string Name { get; set; }
	public DateTime CreatedDate { get; set; } //bu nesne ne zaman olusturuldu
	public DateTime? UpdatedDate { get; set; } //bu nesne ne zaman güncellendi, nesne ilk olustuğunda nullable olabilir
	public DateTime? DeletedDate { get; set; } //bu nesne ne zaman silindi, nesne ilk olustuğunda nullable olabilir
}
