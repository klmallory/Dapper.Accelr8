
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
	public partial class SalesSalesTerritoryHistory : Dapper.Accelr8.Repo.Domain.BaseEntity<int>
	{
			public SalesSalesTerritoryHistory()
		{			
			IsDirty = false; 
			_modifiedDate = (DateTime)SqlDateTime.MinValue;
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

		