
using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.Accelr8.Domain;
using Dapper.Accelr8.TableInfos;
using Dapper;
using Dapper.Accelr8.Sql;
using Dapper.Accelr8.Repo;
using Dapper.Accelr8.Repo.Parameters;
using Dapper.Accelr8.Repo.Contracts.Writers;

namespace Dapper.Accelr8.Writers
{
    public class DocumentWriter : EntityWriter<int, Document>
    {
        public DocumentWriter
			(TableInfo tableInfo
            , string connectionStringName
            , DapperExecuter executer
            , QueryBuilder queryBuilder
            , JoinBuilder joinBuilder
			, IServiceLocatorMarker locator) 
            : base(tableInfo, connectionStringName, executer, queryBuilder, joinBuilder, locator)
		{

		}

		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="results">Parameters for sql writes</param>
		/// <param name="row"></param>
        protected override IDictionary<string, object> GetParams(ActionType actionType, Document entity, int taskIndex, int count)
        {
            var parms = new Dictionary<string, object>();

			parms.Add(GetParamName(DocumentColumnNames.DocumentId.ToString(), actionType, taskIndex, count), entity.Id);
			parms.Add(GetParamName(DocumentColumnNames.TransactionID.ToString(), actionType, taskIndex, count), entity.TransactionId);
			parms.Add(GetParamName(DocumentColumnNames.Blob.ToString(), actionType, taskIndex, count), entity.Blob);
			parms.Add(GetParamName(DocumentColumnNames.FileType.ToString(), actionType, taskIndex, count), entity.FileType);
			parms.Add(GetParamName(DocumentColumnNames.DocumentTitle.ToString(), actionType, taskIndex, count), entity.DocumentTitle);
			parms.Add(GetParamName(DocumentColumnNames.IssuingAuthority.ToString(), actionType, taskIndex, count), entity.IssuingAuthority);
			parms.Add(GetParamName(DocumentColumnNames.DocumentNumber.ToString(), actionType, taskIndex, count), entity.DocumentNumber);
			parms.Add(GetParamName(DocumentColumnNames.ExpirationDate.ToString(), actionType, taskIndex, count), entity.ExpirationDate);
			parms.Add(GetParamName(DocumentColumnNames.DocumentGroup.ToString(), actionType, taskIndex, count), entity.DocumentGroup);
					
			return parms;
        }


		protected override void CascadeRelations(Document entity, ScriptContext context)
        {
            if (entity == null)
                return;

		
        }


	}
}
		