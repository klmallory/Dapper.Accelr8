
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
    public class ProductionvProductAndDescriptionReader : EntityReader<int, ProductionvProductAndDescription>
    {
        public ProductionvProductAndDescriptionReader(
            ProductionvProductAndDescriptionTableInfo tableInfo
            , string connectionStringName
            , DapperExecuter executer
            , QueryBuilder queryBuilder
            , JoinBuilder joinBuilder
            , ILoc8 loc8r) 
            : base(tableInfo, connectionStringName, executer, queryBuilder, joinBuilder, loc8r)
        { }

		//Child Count 0
		//Parent Count 0
		
			/// <summary>
		/// Loads the table Production.vProductAndDescription into class ProductionvProductAndDescription
		/// </summary>
		/// <param name="results">ProductionvProductAndDescription</param>
		/// <param name="row"></param>
        public override ProductionvProductAndDescription LoadEntity(dynamic row)
        {
            var dataRow = (IDictionary<string, object>)row;
            var domain = new ProductionvProductAndDescription();
			domain.Loaded = false;

				domain.ProductID = GetRowData<int>(dataRow, "ProductID"); 
      		domain.Name = GetRowData<object>(dataRow, "Name"); 
      		domain.ProductModel = GetRowData<object>(dataRow, "ProductModel"); 
      		domain.CultureID = GetRowData<string>(dataRow, "CultureID"); 
      		domain.Description = GetRowData<string>(dataRow, "Description"); 
      			
			domain.IsDirty = false;
			domain.Loaded = true;
			return domain;
		}

		/// <summary>
		/// Add All the children to the query for the specified int Id.
		/// </summary>
		/// <param name="results">IEntityReader<int, ProductionvProductAndDescription></param>
		/// <param name="id">int</param>
        public override IEntityReader<int, ProductionvProductAndDescription> WithAllChildrenForId(int id)
        {
			base.WithAllChildrenForId(id);

			
            return this;
        }

        public override void SetAllChildrenForExisting(ProductionvProductAndDescription entity)
        {
				
			entity.Loaded = true;
		}

		public override void SetAllChildrenForExisting(IList<ProductionvProductAndDescription> entities)
        {
					
		}
    }
}
		