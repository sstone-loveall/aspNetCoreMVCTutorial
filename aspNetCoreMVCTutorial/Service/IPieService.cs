using System.Collections.Generic;
using aspNetCoreMVCTutorial.Domain;

namespace aspNetCoreMVCTutorial.Service
{
	public interface IPieService
	{
		IEnumerable<Pie> GetAllPies();

		Pie GetPieById(int pieId);
	}
}