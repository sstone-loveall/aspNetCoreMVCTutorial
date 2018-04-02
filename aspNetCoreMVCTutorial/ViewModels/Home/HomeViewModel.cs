using System;
using System.Collections.Generic;

namespace aspNetCoreMVCTutorial.ViewModels.Home
{
	public class HomeViewModel
	{
		public IEnumerable<Domain.Pie> Pies { get; set; }
		public String Title { get; set; }
	}
}