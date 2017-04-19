
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
	public class SalesvSalesPersonSalesByFiscalYear : Dapper.Accelr8.Repo.Domain.BaseEntity<int>
	{
			public SalesvSalesPersonSalesByFiscalYear()
		{
							
			IsDirty = false; 
			}


	
		
		protected int? _salesPersonID;
		public int? SalesPersonID 
		{ 
			get { return _salesPersonID; }
			set 
			{ 
				_salesPersonID = value;  
				IsDirty = true;
			}
		} 
			
		protected string _fullName;
		public string FullName 
		{ 
			get { return _fullName; }
			set 
			{ 
				_fullName = value;  
				IsDirty = true;
			}
		} 
			
		protected string _jobTitle;
		public string JobTitle 
		{ 
			get { return _jobTitle; }
			set 
			{ 
				_jobTitle = value;  
				IsDirty = true;
			}
		} 
			
		protected object _salesTerritory;
		public object SalesTerritory 
		{ 
			get { return _salesTerritory; }
			set 
			{ 
				_salesTerritory = value;  
				IsDirty = true;
			}
		} 
			
		protected decimal? __N_2002;
		public decimal? _N_2002 
		{ 
			get { return __N_2002; }
			set 
			{ 
				__N_2002 = value;  
				IsDirty = true;
			}
		} 
			
		protected decimal? __N_2003;
		public decimal? _N_2003 
		{ 
			get { return __N_2003; }
			set 
			{ 
				__N_2003 = value;  
				IsDirty = true;
			}
		} 
			
		protected decimal? __N_2004;
		public decimal? _N_2004 
		{ 
			get { return __N_2004; }
			set 
			{ 
				__N_2004 = value;  
				IsDirty = true;
			}
		} 
				}
}

		