
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
    public class ProductionProductModelIllustrationReader : EntityReader<CompoundKey, ProductionProductModelIllustration>
    {
        public ProductionProductModelIllustrationReader(
            ProductionProductModelIllustrationTableInfo tableInfo
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

		//Child Count 0
		//Parent Count 2
		
			/// <summary>
		/// Loads the table Production.ProductModelIllustration into class ProductionProductModelIllustration
		/// </summary>
		/// <param name="results">ProductionProductModelIllustration</param>
		/// <param name="row"></param>
        public override ProductionProductModelIllustration LoadEntity(dynamic row)
        {
            var dataRow = (IDictionary<string, object>)row;
            var domain = new ProductionProductModelIllustration();
			domain.Loaded = false;

			domain.ProductModelID = GetRowData<int>(dataRow, "ProductModelID"); 
      		domain.IllustrationID = GetRowData<int>(dataRow, "IllustrationID"); 
      		domain.ModifiedDate = GetRowData<DateTime>(dataRow, "ModifiedDate"); 
      				domain.Id = ProductionProductModelIllustration.GetCompoundKeyFor(domain); 
			domain.IsDirty = false;
			domain.Loaded = true;
			return domain;
		}

		/// <summary>
		/// Add All the children to the query for the specified CompoundKey Id.
		/// </summary>
		/// <param name="results">IEntityReader<CompoundKey, ProductionProductModelIllustration></param>
		/// <param name="id">CompoundKey</param>
        public override IEntityReader<CompoundKey, ProductionProductModelIllustration> WithAllChildrenForExisting(ProductionProductModelIllustration existing)
        {
			
            return this;
        }


        public override void SetAllChildrenForExisting(ProductionProductModelIllustration entity)
        {
				
			entity.Loaded = true;
		}

		public override void SetAllChildrenForExisting(IList<ProductionProductModelIllustration> entities)
        {
					
		}
    }
}
		