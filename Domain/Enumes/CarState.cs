using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Enumes;

public enum CarState
{
	Available=1,	//araba uygunsa 1 diye tut,
	Rented=2,		//araba kiradaysa 2 diye tut,
	Maintenance=3	//araba bakımdaysa 3 diye tuy
}
