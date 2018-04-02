using System.Collections.Generic;
using aspNetCoreMVCTutorial.Domain;
using aspNetCoreMVCTutorial.Repository;

namespace aspNetCoreMVCTutorial.Service
{
	public class PieService : IPieService
	{
		private IPieRepository _pieRepository;

		public PieService(IPieRepository pieRepository)
		{
			_pieRepository = pieRepository;
		}

		public IEnumerable<Pie> GetAllPies()
		{
			return _pieRepository.GetAllPies();
		}

		public Pie GetPieById(int pieId)
		{
			return _pieRepository.GetPieById(pieId);
		}
	}
}