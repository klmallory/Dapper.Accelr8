
using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Text;

using Dapper.Accelr8.Sql.AW2008DAO;
using Dapper;
using Dapper.Accelr8.Domain;
using System.Data.SqlTypes;

namespace Dapper.Accelr8.Sql.AW2008DAO
{
	public partial class SalesvPersonDemographic : Dapper.Accelr8.Repo.Domain.BaseEntity<int>
	{
			public SalesvPersonDemographic()
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
			
		protected decimal? _totalPurchaseYTD;
		public decimal? TotalPurchaseYTD 
		{ 
			get { return _totalPurchaseYTD; }
			set 
			{ 
				_totalPurchaseYTD = value;  
				IsDirty = true;
			}
		} 
			
		protected DateTime? _dateFirstPurchase;
		public DateTime? DateFirstPurchase 
		{ 
			get { return _dateFirstPurchase; }
			set 
			{ 
				_dateFirstPurchase = value;  
				IsDirty = true;
			}
		} 
			
		protected DateTime? _birthDate;
		public DateTime? BirthDate 
		{ 
			get { return _birthDate; }
			set 
			{ 
				_birthDate = value;  
				IsDirty = true;
			}
		} 
			
		protected string _maritalStatus;
		public string MaritalStatus 
		{ 
			get { return _maritalStatus; }
			set 
			{ 
				_maritalStatus = value;  
				IsDirty = true;
			}
		} 
			
		protected string _yearlyIncome;
		public string YearlyIncome 
		{ 
			get { return _yearlyIncome; }
			set 
			{ 
				_yearlyIncome = value;  
				IsDirty = true;
			}
		} 
			
		protected string _gender;
		public string Gender 
		{ 
			get { return _gender; }
			set 
			{ 
				_gender = value;  
				IsDirty = true;
			}
		} 
			
		protected int? _totalChildren;
		public int? TotalChildren 
		{ 
			get { return _totalChildren; }
			set 
			{ 
				_totalChildren = value;  
				IsDirty = true;
			}
		} 
			
		protected int? _numberChildrenAtHome;
		public int? NumberChildrenAtHome 
		{ 
			get { return _numberChildrenAtHome; }
			set 
			{ 
				_numberChildrenAtHome = value;  
				IsDirty = true;
			}
		} 
			
		protected string _education;
		public string Education 
		{ 
			get { return _education; }
			set 
			{ 
				_education = value;  
				IsDirty = true;
			}
		} 
			
		protected string _occupation;
		public string Occupation 
		{ 
			get { return _occupation; }
			set 
			{ 
				_occupation = value;  
				IsDirty = true;
			}
		} 
			
		protected bool? _homeOwnerFlag;
		public bool? HomeOwnerFlag 
		{ 
			get { return _homeOwnerFlag; }
			set 
			{ 
				_homeOwnerFlag = value;  
				IsDirty = true;
			}
		} 
			
		protected int? _numberCarsOwned;
		public int? NumberCarsOwned 
		{ 
			get { return _numberCarsOwned; }
			set 
			{ 
				_numberCarsOwned = value;  
				IsDirty = true;
			}
		} 
				}
}

		