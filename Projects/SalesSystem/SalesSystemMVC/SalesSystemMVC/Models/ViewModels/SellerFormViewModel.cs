﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesSystemMVC.Models.ViewModels
{
	public class SellerFormViewModel
	{

		public Seller Seller { get; set; }
		public ICollection<Department> Departments { get; set; }
	}
}
