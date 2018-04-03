using System;
using System.ComponentModel.DataAnnotations;

namespace aspNetCoreMVCTutorial.ViewModels.Account
{
	public class LoginViewModel
	{
		[Required]
		[Display(Name = "User Name")]
		public String Username { get; set; }

		[Required]
		[DataType(DataType.Password)]
		public String Password { get; set; }

		public String ErrorMessage { get; set; }
	}
}