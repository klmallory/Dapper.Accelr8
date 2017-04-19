
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
    public class ProductionDocumentReader : EntityReader<Microsoft.SqlServer.Types.SqlHierarchyId, ProductionDocument>
    {
        public ProductionDocumentReader(
            ProductionDocumentTableInfo tableInfo
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
		//Parent Count 1
		
			/// <summary>
		/// Loads the table Production.Document into class ProductionDocument
		/// </summary>
		/// <param name="results">ProductionDocument</param>
		/// <param name="row"></param>
        public override ProductionDocument LoadEntity(dynamic row)
        {
            var dataRow = (IDictionary<string, object>)row;
            var domain = new ProductionDocument();
			domain.Loaded = false;

			domain.Id = GetRowData<Microsoft.SqlServer.Types.SqlHierarchyId>(dataRow, "DocumentNode"); 
      		domain.DocumentLevel = GetRowData<short?>(dataRow, "DocumentLevel"); 
      		domain.Title = GetRowData<string>(dataRow, "Title"); 
      		domain.Owner = GetRowData<int>(dataRow, "Owner"); 
      		domain.FolderFlag = GetRowData<bool>(dataRow, "FolderFlag"); 
      		domain.FileName = GetRowData<string>(dataRow, "FileName"); 
      		domain.FileExtension = GetRowData<string>(dataRow, "FileExtension"); 
      		domain.Revision = GetRowData<string>(dataRow, "Revision"); 
      		domain.ChangeNumber = GetRowData<int>(dataRow, "ChangeNumber"); 
      		domain.Status = GetRowData<byte>(dataRow, "Status"); 
      		domain.DocumentSummary = GetRowData<string>(dataRow, "DocumentSummary"); 
      		domain.Document = GetRowData<byte[]>(dataRow, "Document"); 
      		domain.rowguid = GetRowData<Guid>(dataRow, "rowguid"); 
      		domain.ModifiedDate = GetRowData<DateTime>(dataRow, "ModifiedDate"); 
      			
			domain.IsDirty = false;
			domain.Loaded = true;
			return domain;
		}

		/// <summary>
		/// Add All the children to the query for the specified Microsoft.SqlServer.Types.SqlHierarchyId Id.
		/// </summary>
		/// <param name="results">IEntityReader<Microsoft.SqlServer.Types.SqlHierarchyId, ProductionDocument></param>
		/// <param name="id">Microsoft.SqlServer.Types.SqlHierarchyId</param>
        public override IEntityReader<Microsoft.SqlServer.Types.SqlHierarchyId, ProductionDocument> WithAllChildrenForExisting(ProductionDocument existing)
        {
			
            return this;
        }


        public override void SetAllChildrenForExisting(ProductionDocument entity)
        {
				
			entity.Loaded = true;
		}

		public override void SetAllChildrenForExisting(IList<ProductionDocument> entities)
        {
					
		}
    }
}
		