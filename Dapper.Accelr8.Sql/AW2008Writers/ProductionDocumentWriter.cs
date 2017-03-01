
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

namespace Dapper.Accelr8.AW2008Writers
{
    public class ProductionDocumentWriter : EntityWriter<Microsoft.SqlServer.Types.SqlHierarchyId, ProductionDocument>
    {
        public ProductionDocumentWriter
			(ProductionDocumentTableInfo tableInfo
            , string connectionStringName
            , DapperExecuter executer
            , QueryBuilder queryBuilder
            , JoinBuilder joinBuilder
			, ILoc8 loc8r) 
            : base(tableInfo, connectionStringName, executer, queryBuilder, joinBuilder, loc8r)
		{

		}

		
		static IEntityWriter<int, HumanResourcesEmployee> GetHumanResourcesEmployeeWriter()
		{ return _locator.Resolve<IEntityWriter<int, HumanResourcesEmployee>>(); }
		
		/// <summary>
		/// Gets the Sql Parameters from the Entity and names them according to column, action, and batch task, and array count.
		/// </summary>
		/// <param name="results">Parameters for sql writes</param>
		/// <param name="row"></param>
        protected override IDictionary<string, object> GetParams(ActionType actionType, ProductionDocument entity, int taskIndex, ref int count)
        {
            var parms = new Dictionary<string, object>();
			
			foreach (var f in ColumnNames)
            {
                switch ((ProductionDocumentColumnNames)f.Key)
                {
                    
					case ProductionDocumentColumnNames.DocumentLevel:
						parms.Add(GetParamName("DocumentLevel", actionType, taskIndex, ref count), entity.DocumentLevel);
						break;
					case ProductionDocumentColumnNames.Title:
						parms.Add(GetParamName("Title", actionType, taskIndex, ref count), entity.Title);
						break;
					case ProductionDocumentColumnNames.Owner:
						parms.Add(GetParamName("Owner", actionType, taskIndex, ref count), entity.Owner);
						break;
					case ProductionDocumentColumnNames.FolderFlag:
						parms.Add(GetParamName("FolderFlag", actionType, taskIndex, ref count), entity.FolderFlag);
						break;
					case ProductionDocumentColumnNames.FileName:
						parms.Add(GetParamName("FileName", actionType, taskIndex, ref count), entity.FileName);
						break;
					case ProductionDocumentColumnNames.FileExtension:
						parms.Add(GetParamName("FileExtension", actionType, taskIndex, ref count), entity.FileExtension);
						break;
					case ProductionDocumentColumnNames.Revision:
						parms.Add(GetParamName("Revision", actionType, taskIndex, ref count), entity.Revision);
						break;
					case ProductionDocumentColumnNames.ChangeNumber:
						parms.Add(GetParamName("ChangeNumber", actionType, taskIndex, ref count), entity.ChangeNumber);
						break;
					case ProductionDocumentColumnNames.Status:
						parms.Add(GetParamName("Status", actionType, taskIndex, ref count), entity.Status);
						break;
					case ProductionDocumentColumnNames.DocumentSummary:
						parms.Add(GetParamName("DocumentSummary", actionType, taskIndex, ref count), entity.DocumentSummary);
						break;
					case ProductionDocumentColumnNames.Document:
						parms.Add(GetParamName("Document", actionType, taskIndex, ref count), entity.Document);
						break;
					case ProductionDocumentColumnNames.rowguid:
						parms.Add(GetParamName("rowguid", actionType, taskIndex, ref count), entity.rowguid);
						break;
					case ProductionDocumentColumnNames.ModifiedDate:
						parms.Add(GetParamName("ModifiedDate", actionType, taskIndex, ref count), entity.ModifiedDate);
						break;
				}
			}

			return parms;
        }


		protected override void CascadeRelations(ProductionDocument entity, ScriptContext context)
        {
            if (entity == null)
                return;

		
		
			//From Foreign Key FK_Document_Employee_Owner
			var humanResourcesEmployee101 = GetHumanResourcesEmployeeWriter();
		if ((_cascades.Contains(ProductionDocumentCascadeNames.humanresourcesemployee.ToString()) || _cascades.Contains("all")) && entity.HumanResourcesEmployee != null)
			if (Cascade(humanResourcesEmployee101, entity.HumanResourcesEmployee, context))
				WithParent(humanResourcesEmployee101, entity);

				}

		protected override void UpdateIdsFromReferences(IList<string> cascades, ProductionDocument entity)
        {
            if (entity == null)
                return;

				
			//From Foreign Key FK_Document_Employee_Owner
			if (entity.HumanResourcesEmployee != null)
				entity.ProductionDocument = entity.HumanResourcesEmployee.Id;

		}

		protected override void RemoveRelations(ProductionDocument entity, ScriptContext context)
        {
				}
	}
}
		