﻿using System.Collections.Generic;
using System.Linq;
using aspNetCoreMVCTutorial.Domain;
using aspNetCoreMVCTutorial.Repository.EntityFramework;

namespace aspNetCoreMVCTutorial.Repository.Impl
{
	public class PieRepository : IPieRepository
	{
		private readonly AppDbContext _appDbContext;

		public PieRepository(AppDbContext appDbContext)
		{
			_appDbContext = appDbContext;
		}

		public IEnumerable<Pie> GetAllPies()
		{
			return _appDbContext.Pies;
		}

		public Pie GetPieById(int pieId)
		{
			return _appDbContext.Pies.FirstOrDefault(p => p.Id == pieId);
		}
	}
}