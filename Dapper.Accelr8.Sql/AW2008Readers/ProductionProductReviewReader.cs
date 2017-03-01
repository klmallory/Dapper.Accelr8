
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
    public class ProductionProductReviewReader : EntityReader<int, ProductionProductReview>
    {
        public ProductionProductReviewReader(
            ProductionProductReviewTableInfo tableInfo
            , string connectionStringName
            , DapperExecuter executer
            , QueryBuilder queryBuilder
            , JoinBuilder joinBuilder
            , ILoc8 loc8r) 
            : base(tableInfo, connectionStringName, executer, queryBuilder, joinBuilder, loc8r)
        { }

		//Child Count 0
		//Parent Count 1
		
			/// <summary>
		/// Loads the table Production.ProductReview into class ProductionProductReview
		/// </summary>
		/// <param name="results">ProductionProductReview</param>
		/// <param name="row"></param>
        public override ProductionProductReview LoadEntity(dynamic row)
        {
            var dataRow = (IDictionary<string, object>)row;
            var domain = new ProductionProductReview();
			domain.Loaded = false;

			domain.Id = GetRowData<int>(dataRow, IdColumn);
				domain.ProductID = GetRowData<int>(dataRow, "ProductID"); 
      		domain.ReviewerName = GetRowData<object>(dataRow, "ReviewerName"); 
      		domain.ReviewDate = GetRowData<DateTime>(dataRow, "ReviewDate"); 
      		domain.EmailAddress = GetRowData<string>(dataRow, "EmailAddress"); 
      		domain.Rating = GetRowData<int>(dataRow, "Rating"); 
      		domain.Comments = GetRowData<string>(dataRow, "Comments"); 
      		domain.ModifiedDate = GetRowData<DateTime>(dataRow, "ModifiedDate"); 
      			
			domain.IsDirty = false;
			domain.Loaded = true;
			return domain;
		}

		/// <summary>
		/// Add All the children to the query for the specified int Id.
		/// </summary>
		/// <param name="results">IEntityReader<int, ProductionProductReview></param>
		/// <param name="id">int</param>
        public override IEntityReader<int, ProductionProductReview> WithAllChildrenForId(int id)
        {
			base.WithAllChildrenForId(id);

			
            return this;
        }

        public override void SetAllChildrenForExisting(ProductionProductReview entity)
        {
				
			entity.Loaded = true;
		}

		public override void SetAllChildrenForExisting(IList<ProductionProductReview> entities)
        {
					
		}
    }
}
		