
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
	public class SalesSpecialOfferProduct : Dapper.Accelr8.Repo.Domain.BaseEntity<CompoundKey>
	{
			public SalesSpecialOfferProduct()
		{
					Id = new CompoundKey();
							
			IsDirty = false; 
			_salesSalesOrderDetails = new List<SalesSalesOrderDetail>();
		_modifiedDate = (DateTime)SqlDateTime.MinValue;
		}


	 
		public static CompoundKey GetCompoundKeyFor(SalesSpecialOfferProduct dao)
		{
			return new CompoundKey()
			{
				Keys = new IComparable[]
				{ 		dao.SpecialOfferID,
							dao.ProductID,
						
				}
			};
		}

			
			protected int _specialOfferID;
		public int SpecialOfferID 
		{ 
			get { return _specialOfferID; }
			set 
			{ 
				_specialOfferID = value;
				this.Id = GetCompoundKeyFor(this);

								IsDirty = true;
							}
		}
			
			protected int _productID;
		public int ProductID 
		{ 
			get { return _productID; }
			set 
			{ 
				_productID = value;
				this.Id = GetCompoundKeyFor(this);

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
		 
	//From Foreign Key FK_SpecialOfferProduct_SpecialOffer_SpecialOfferID	
		protected SalesSpecialOffer _salesSpecialOffer;
		public virtual SalesSpecialOffer SalesSpecialOffer 
		{ 
			get { return _salesSpecialOffer; }
			set 
			{ 
				_salesSpecialOffer = value;  
				IsDirty = true;
			}
		} 
		 
	//From Foreign Key FK_SpecialOfferProduct_Product_ProductID	
		protected ProductionProduct _productionProduct;
		public virtual ProductionProduct ProductionProduct 
		{ 
			get { return _productionProduct; }
			set 
			{ 
				_productionProduct = value;  
				IsDirty = true;
			}
		} 
		 
	//From Foreign Key FK_SalesOrderDetail_SpecialOfferProduct_SpecialOfferIDProductID	
		protected IList<SalesSalesOrderDetail> _salesSalesOrderDetails;
		public virtual IList<SalesSalesOrderDetail> SalesSalesOrderDetails 
		{ 
			get { return _salesSalesOrderDetails; }
			set 
			{ 
				_salesSalesOrderDetails = value;  
				IsDirty = true;
			}
		} 
					}
}

		