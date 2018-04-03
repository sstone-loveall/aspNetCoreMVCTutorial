using System;
using System.Collections.Generic;

namespace aspNetCoreMVCTutorial.ViewModels.Home
{
	public class PieListViewModel
	{
		public IEnumerable<Domain.Pie> Pies { get; set; }

		public String Title { get; set; }
	}
}