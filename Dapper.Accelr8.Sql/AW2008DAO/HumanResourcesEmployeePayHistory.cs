
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
	public class HumanResourcesEmployeePayHistory : Dapper.Accelr8.Repo.Domain.BaseEntity<CompoundKey>
	{
			public HumanResourcesEmployeePayHistory()
		{
					Id = new CompoundKey();
							
			IsDirty = false; 
			_modifiedDate = (DateTime)SqlDateTime.MinValue;
		}


	 
		public static CompoundKey GetCompoundKeyFor(HumanResourcesEmployeePayHistory dao)
		{
			return new CompoundKey()
			{
				Keys = new IComparable[]
				{ 		dao.BusinessEntityID,
							dao.RateChangeDate,
						
				}
			};
		}

			
			protected int _businessEntityID;
		public int BusinessEntityID 
		{ 
			get { return _businessEntityID; }
			set 
			{ 
				_businessEntityID = value;
				this.Id = GetCompoundKeyFor(this);

								IsDirty = true;
							}
		}
			
			protected DateTime _rateChangeDate;
		public DateTime RateChangeDate 
		{ 
			get { return _rateChangeDate; }
			set 
			{ 
				_rateChangeDate = value;
				this.Id = GetCompoundKeyFor(this);

								IsDirty = true;
							}
		}
		
		
		protected decimal _rate;
		public decimal Rate 
		{ 
			get { return _rate; }
			set 
			{ 
				_rate = value;  
				IsDirty = true;
			}
		} 
			
		protected byte _payFrequency;
		public byte PayFrequency 
		{ 
			get { return _payFrequency; }
			set 
			{ 
				_payFrequency = value;  
				IsDirty = true;
			}
		} 
			
		protected DateTime _modifiedDate;
		public DateTime ModifiedDate 
		{ 
			get { return _modifiedDate; }
			set 
			{ 
				_modifiedDate = value;  
				IsDirty = true;
			}
		} 
		 
	//From Foreign Key FK_EmployeePayHistory_Employee_BusinessEntityID	
		protected HumanResourcesEmployee _humanResourcesEmployee;
		public virtual HumanResourcesEmployee HumanResourcesEmployee 
		{ 
			get { return _humanResourcesEmployee; }
			set 
			{ 
				_humanResourcesEmployee = value;  
				IsDirty = true;
			}
		} 
				}
}

		