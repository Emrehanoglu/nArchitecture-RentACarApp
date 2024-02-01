using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Brands.Commands.Delete;

public class DeletedBrandResponse
{
    //işlem sonucuncda bu Id 'yi sildim şeklinde donus olacak
    public Guid Id { get; set; }
}
