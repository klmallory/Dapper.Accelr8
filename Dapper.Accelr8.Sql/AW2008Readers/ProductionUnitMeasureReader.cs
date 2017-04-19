
using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Text;

using Dapper.Accelr8.Sql.AW2008DAO;
using Dapper.Accelr8.AW2008TableInfos;
using Dapper;
using Dapper.Accelr8.Sql;
using Dapper.Accelr8.Domain;
using Dapper.Accelr8.Repo;
using Dapper.Accelr8.Repo.Parameters;
using Dapper.Accelr8.Repo.Contracts;

namespace Dapper.Accelr8.AW2008Readers
{
    public class ProductionUnitMeasureReader : EntityReader<string, ProductionUnitMeasure>
    {
        public ProductionUnitMeasureReader(
            ProductionUnitMeasureTableInfo tableInfo
            , string connectionStringName
            , DapperExecuter executer
            , QueryBuilder queryBuilder
            , JoinBuilder joinBuilder
            , ILoc8 loc8r) 
            : base(tableInfo, connectionStringName, executer, queryBuilder, joinBuilder, loc8r)
        {
			if (s_loc8r == null)
				s_loc8r = loc8r;		 
		}

		static ILoc8 s_loc8r = null;

		//Child Count 4
		//Parent Count 0
				//Is CompoundKey False
		protected static IEntityReader<int , ProductionBillOfMaterial> GetProductionBillOfMaterialReader()
		{
			return s_loc8r.GetReader<int , ProductionBillOfMaterial>();
		}

				//Is CompoundKey False
		protected static IEntityReader<int , ProductionProduct> GetProductionProductReader()
		{
			return s_loc8r.GetReader<int , ProductionProduct>();
		}

				//Is CompoundKey True
		protected static IEntityReader<CompoundKey , PurchasingProductVendor> GetPurchasingProductVendorReader()
		{
			return s_loc8r.GetReader<CompoundKey , PurchasingProductVendor>();
		}

		
		/// <summary>
		/// Sets the children of type ProductionBillOfMaterial on the parent on ProductionBillOfMaterials.
		/// From foriegn key FK_BillOfMaterials_UnitMeasure_UnitMeasureCode
		/// </summary>
		/// <param name="results"></param>
		/// <param name="children"></param>
		public void SetChildrenProductionBillOfMaterials(IList<ProductionUnitMeasure> results, IList<object> children)
		{
			//Child Id Type: int
			//Child Type: ProductionBillOfMaterial

			if (results == null || results.Count < 1 || children == null || children.Count < 1)
				return;

			var typedChildren = children.OfType<ProductionBillOfMaterial>();

			foreach (var r in results)
			{
				if (r == null)
					continue;
				r.Loaded = false;
				

				r.ProductionBillOfMaterials = typedChildren.Where(b =>  b.UnitMeasureCode == r.Id ).ToList();
				r.ProductionBillOfMaterials.ToList().ForEach(b => { b.Loaded = false; b.ProductionUnitMeasure = r; b.Loaded = true; });
				
				r.Loaded = true;
			}
		}

		/// <summary>
		/// Sets the children of type ProductionProduct on the parent on ProductionProducts.
		/// From foriegn key FK_Product_UnitMeasure_SizeUnitMeasureCode
		/// </summary>
		/// <param name="results"></param>
		/// <param name="children"></param>
		public void SetChildrenProductionProducts1(IList<ProductionUnitMeasure> results, IList<object> children)
		{
			//Child Id Type: int
			//Child Type: ProductionProduct

			if (results == null || results.Count < 1 || children == null || children.Count < 1)
				return;

			var typedChildren = children.OfType<ProductionProduct>();

			foreach (var r in results)
			{
				if (r == null)
					continue;
				r.Loaded = false;
				

				r.ProductionProducts1 = typedChildren.Where(b =>  b.SizeUnitMeasureCode == r.Id ).ToList();
				r.ProductionProducts1.ToList().ForEach(b => { b.Loaded = false; b.ProductionUnitMeasure1 = r; b.Loaded = true; });
				
				r.Loaded = true;
			}
		}

		/// <summary>
		/// Sets the children of type ProductionProduct on the parent on ProductionProducts.
		/// From foriegn key FK_Product_UnitMeasure_WeightUnitMeasureCode
		/// </summary>
		/// <param name="results"></param>
		/// <param name="children"></param>
		public void SetChildrenProductionProducts2(IList<ProductionUnitMeasure> results, IList<object> children)
		{
			//Child Id Type: int
			//Child Type: ProductionProduct

			if (results == null || results.Count < 1 || children == null || children.Count < 1)
				return;

			var typedChildren = children.OfType<ProductionProduct>();

			foreach (var r in results)
			{
				if (r == null)
					continue;
				r.Loaded = false;
				

				r.ProductionProducts2 = typedChildren.Where(b =>  b.WeightUnitMeasureCode == r.Id ).ToList();
				r.ProductionProducts2.ToList().ForEach(b => { b.Loaded = false; b.ProductionUnitMeasure2 = r; b.Loaded = true; });
				
				r.Loaded = true;
			}
		}

		/// <summary>
		/// Sets the children of type PurchasingProductVendor on the parent on PurchasingProductVendors.
		/// From foriegn key FK_ProductVendor_UnitMeasure_UnitMeasureCode
		/// </summary>
		/// <param name="results"></param>
		/// <param name="children"></param>
		public void SetChildrenPurchasingProductVendors(IList<ProductionUnitMeasure> results, IList<object> children)
		{
			//Child Id Type: CompoundKey
			//Child Type: PurchasingProductVendor

			if (results == null || results.Count < 1 || children == null || children.Count < 1)
				return;

			var typedChildren = children.OfType<PurchasingProductVendor>();

			foreach (var r in results)
			{
				if (r == null)
					continue;
				r.Loaded = false;
				

				r.PurchasingProductVendors = typedChildren.Where(b =>  b.UnitMeasureCode == r.Id ).ToList();
				r.PurchasingProductVendors.ToList().ForEach(b => { b.Loaded = false; b.ProductionUnitMeasure = r; b.Loaded = true; });
				
				r.Loaded = true;
			}
		}

			/// <summary>
		/// Loads the table Production.UnitMeasure into class ProductionUnitMeasure
		/// </summary>
		/// <param name="results">ProductionUnitMeasure</param>
		/// <param name="row"></param>
        public override ProductionUnitMeasure LoadEntity(dynamic row)
        {
            var dataRow = (IDictionary<string, object>)row;
            var domain = new ProductionUnitMeasure();
			domain.Loaded = false;

			domain.Id = GetRowData<string>(dataRow, "UnitMeasureCode"); 
      		domain.Name = GetRowData<object>(dataRow, "Name"); 
      		domain.ModifiedDate = GetRowData<DateTime>(dataRow, "ModifiedDate"); 
      			
			domain.IsDirty = false;
			domain.Loaded = true;
			return domain;
		}

		/// <summary>
		/// Add All the children to the query for the specified string Id.
		/// </summary>
		/// <param name="results">IEntityReader<string, ProductionUnitMeasure></param>
		/// <param name="id">string</param>
        public override IEntityReader<string, ProductionUnitMeasure> WithAllChildrenForExisting(ProductionUnitMeasure existing)
        {
						WithChildForParentValues(GetProductionBillOfMaterialReader()
				, new object[] {  existing.Id,  } 
				, new string[] {  "UnitMeasureCode",  }
				, SetChildrenProductionBillOfMaterials);
						WithChildForParentValues(GetProductionProductReader()
				, new object[] {  existing.Id,  } 
				, new string[] {  "SizeUnitMeasureCode",  }
				, SetChildrenProductionProducts1);
						WithChildForParentValues(GetProductionProductReader()
				, new object[] {  existing.Id,  } 
				, new string[] {  "WeightUnitMeasureCode",  }
				, SetChildrenProductionProducts2);
						WithChildForParentValues(GetPurchasingProductVendorReader()
				, new object[] {  existing.Id,  } 
				, new string[] {  "UnitMeasureCode",  }
				, SetChildrenPurchasingProductVendors);
			
            return this;
        }


        public override void SetAllChildrenForExisting(ProductionUnitMeasure entity)
        {
			ClearAllQueries();

            if (entity == null)
                return;

						WithChildForParentValues(GetProductionBillOfMaterialReader()
				, new object[] {  entity.Id,  } 
				, new string[] {  "UnitMeasureCode",  }
				, SetChildrenProductionBillOfMaterials);

						WithChildForParentValues(GetProductionProductReader()
				, new object[] {  entity.Id,  } 
				, new string[] {  "SizeUnitMeasureCode",  }
				, SetChildrenProductionProducts1);

						WithChildForParentValues(GetProductionProductReader()
				, new object[] {  entity.Id,  } 
				, new string[] {  "WeightUnitMeasureCode",  }
				, SetChildrenProductionProducts2);

						WithChildForParentValues(GetPurchasingProductVendorReader()
				, new object[] {  entity.Id,  } 
				, new string[] {  "UnitMeasureCode",  }
				, SetChildrenPurchasingProductVendors);

			
QueryResultForChildrenOnly(new List<ProductionUnitMeasure>() { entity });
			entity.Loaded = false;
			GetProductionBillOfMaterialReader().SetAllChildrenForExisting(entity.ProductionBillOfMaterials);
			GetProductionProductReader().SetAllChildrenForExisting(entity.ProductionProducts);
			GetProductionProductReader().SetAllChildrenForExisting(entity.ProductionProducts);
			GetPurchasingProductVendorReader().SetAllChildrenForExisting(entity.PurchasingProductVendors);
				
			entity.Loaded = true;
		}

		public override void SetAllChildrenForExisting(IList<ProductionUnitMeasure> entities)
        {
			ClearAllQueries();

            if (entities == null || entities.Count < 1)
                return;

			entities = entities.Where(e => e != null).ToList();

            if (entities.Count < 1)
                return;

			WithChildForParentsValues(GetProductionBillOfMaterialReader()
				, entities.Select(s => new object[] {  s.Id,  }).ToList() 
				, new string[] {  "UnitMeasureCode",  }
				, SetChildrenProductionBillOfMaterials);

			WithChildForParentsValues(GetProductionProductReader()
				, entities.Select(s => new object[] {  s.Id,  }).ToList() 
				, new string[] {  "SizeUnitMeasureCode",  }
				, SetChildrenProductionProducts1);

			WithChildForParentsValues(GetProductionProductReader()
				, entities.Select(s => new object[] {  s.Id,  }).ToList() 
				, new string[] {  "WeightUnitMeasureCode",  }
				, SetChildrenProductionProducts2);

			WithChildForParentsValues(GetPurchasingProductVendorReader()
				, entities.Select(s => new object[] {  s.Id,  }).ToList() 
				, new string[] {  "UnitMeasureCode",  }
				, SetChildrenPurchasingProductVendors);

					
			QueryResultForChildrenOnly(entities);

			GetProductionBillOfMaterialReader().SetAllChildrenForExisting(entities.SelectMany(e => e.ProductionBillOfMaterials).ToList());
			GetProductionProductReader().SetAllChildrenForExisting(entities.SelectMany(e => e.ProductionProducts1).ToList());
			GetProductionProductReader().SetAllChildrenForExisting(entities.SelectMany(e => e.ProductionProducts2).ToList());
			GetPurchasingProductVendorReader().SetAllChildrenForExisting(entities.SelectMany(e => e.PurchasingProductVendors).ToList());
					
		}
    }
}
		