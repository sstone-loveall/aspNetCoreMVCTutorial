using System.Collections.Generic;
using aspNetCoreMVCTutorial.Domain;

namespace aspNetCoreMVCTutorial.Repository
{
	public interface IPieRepository
	{
		IEnumerable<Pie> GetAllPies();

		Pie GetPieById(int pieId);
	}
}