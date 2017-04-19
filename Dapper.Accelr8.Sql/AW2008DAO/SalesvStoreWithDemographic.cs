
using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Text;

using Dapper.Accelr8.Sql.AW2008DAO;
using Dapper;
using Dapper.Accelr8.Repo;
using Dapper.Accelr8.Domain;
using System.Data.SqlTypes;

namespace Dapper.Accelr8.Sql.AW2008DAO
{
	public class SalesvStoreWithDemographic : Dapper.Accelr8.Repo.Domain.BaseEntity<int>
	{
			public SalesvStoreWithDemographic()
		{
							
			IsDirty = false; 
			}


	
		
		protected int _businessEntityID;
		public int BusinessEntityID 
		{ 
			get { return _businessEntityID; }
			set 
			{ 
				_businessEntityID = value;  
				IsDirty = true;
			}
		} 
			
		protected object _name;
		public object Name 
		{ 
			get { return _name; }
			set 
			{ 
				_name = value;  
				IsDirty = true;
			}
		} 
			
		protected decimal? _annualSales;
		public decimal? AnnualSales 
		{ 
			get { return _annualSales; }
			set 
			{ 
				_annualSales = value;  
				IsDirty = true;
			}
		} 
			
		protected decimal? _annualRevenue;
		public decimal? AnnualRevenue 
		{ 
			get { return _annualRevenue; }
			set 
			{ 
				_annualRevenue = value;  
				IsDirty = true;
			}
		} 
			
		protected string _bankName;
		public string BankName 
		{ 
			get { return _bankName; }
			set 
			{ 
				_bankName = value;  
				IsDirty = true;
			}
		} 
			
		protected string _businessType;
		public string BusinessType 
		{ 
			get { return _businessType; }
			set 
			{ 
				_businessType = value;  
				IsDirty = true;
			}
		} 
			
		protected int? _yearOpened;
		public int? YearOpened 
		{ 
			get { return _yearOpened; }
			set 
			{ 
				_yearOpened = value;  
				IsDirty = true;
			}
		} 
			
		protected string _specialty;
		public string Specialty 
		{ 
			get { return _specialty; }
			set 
			{ 
				_specialty = value;  
				IsDirty = true;
			}
		} 
			
		protected int? _squareFeet;
		public int? SquareFeet 
		{ 
			get { return _squareFeet; }
			set 
			{ 
				_squareFeet = value;  
				IsDirty = true;
			}
		} 
			
		protected string _brands;
		public string Brands 
		{ 
			get { return _brands; }
			set 
			{ 
				_brands = value;  
				IsDirty = true;
			}
		} 
			
		protected string _internet;
		public string Internet 
		{ 
			get { return _internet; }
			set 
			{ 
				_internet = value;  
				IsDirty = true;
			}
		} 
			
		protected int? _numberEmployees;
		public int? NumberEmployees 
		{ 
			get { return _numberEmployees; }
			set 
			{ 
				_numberEmployees = value;  
				IsDirty = true;
			}
		} 
				}
}

		