
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
	public class SalesSalesTerritoryHistory : Dapper.Accelr8.Repo.Domain.BaseEntity<CompoundKey>
	{
			public SalesSalesTerritoryHistory()
		{
					Id = new CompoundKey();
							
			IsDirty = false; 
			_modifiedDate = (DateTime)SqlDateTime.MinValue;
		}


	 
		public static CompoundKey GetCompoundKeyFor(SalesSalesTerritoryHistory dao)
		{
			return new CompoundKey()
			{
				Keys = new IComparable[]
				{ 		dao.BusinessEntityID,
							dao.TerritoryID,
							dao.StartDate,
						
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
			
			protected int _territoryID;
		public int TerritoryID 
		{ 
			get { return _territoryID; }
			set 
			{ 
				_territoryID = value;
				this.Id = GetCompoundKeyFor(this);

								IsDirty = true;
							}
		}
			
			protected DateTime _startDate;
		public DateTime StartDate 
		{ 
			get { return _startDate; }
			set 
			{ 
				_startDate = value;
				this.Id = GetCompoundKeyFor(this);

								IsDirty = true;
							}
		}
		
		
		protected DateTime? _endDate;
		public DateTime? EndDate 
		{ 
			get { return _endDate; }
			set 
			{ 
				_endDate = value;  
				IsDirty = true;
			}
		} 
			
		protected Guid _rowguid;
		public Guid rowguid 
		{ 
			get { return _rowguid; }
			set 
			{ 
				_rowguid = value;  
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
		 
	//From Foreign Key FK_SalesTerritoryHistory_SalesPerson_BusinessEntityID	
		protected SalesSalesPerson _salesSalesPerson;
		public virtual SalesSalesPerson SalesSalesPerson 
		{ 
			get { return _salesSalesPerson; }
			set 
			{ 
				_salesSalesPerson = value;  
				IsDirty = true;
			}
		} 
		 
	//From Foreign Key FK_SalesTerritoryHistory_SalesTerritory_TerritoryID	
		protected SalesSalesTerritory _salesSalesTerritory;
		public virtual SalesSalesTerritory SalesSalesTerritory 
		{ 
			get { return _salesSalesTerritory; }
			set 
			{ 
				_salesSalesTerritory = value;  
				IsDirty = true;
			}
		} 
				}
}

		