
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
    public class TransactionFieldWriter : EntityWriter<int, TransactionField>
    {
        public TransactionFieldWriter
			(TableInfo tableInfo
            , string connectionStringName
            , DapperExecuter executer
            , QueryBuilder queryBuilder
            , JoinBuilder joinBuilder
			, IServiceLocatorMarker locator) 
            : base(tableInfo, connectionStringName, executer, queryBuilder, joinBuilder, locator)
		{

		}

		static IEntityWriter<int , TransactionFieldValue> GetTransactionFieldValueWriter()
		{ return _locator.Resolve<IEntityWriter<int , TransactionFieldValue>>(); }
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="results">Parameters for sql writes</param>
		/// <param name="row"></param>
        protected override IDictionary<string, object> GetParams(ActionType actionType, TransactionField entity, int taskIndex, int count)
        {
            var parms = new Dictionary<string, object>();

			parms.Add(GetParamName(TransactionFieldColumnNames.FieldId.ToString(), actionType, taskIndex, count), entity.Id);
			parms.Add(GetParamName(TransactionFieldColumnNames.FieldDescriptor.ToString(), actionType, taskIndex, count), entity.FieldDescriptor);
			parms.Add(GetParamName(TransactionFieldColumnNames.Description.ToString(), actionType, taskIndex, count), entity.Description);
			parms.Add(GetParamName(TransactionFieldColumnNames.IsVisible.ToString(), actionType, taskIndex, count), entity.IsVisible);
			parms.Add(GetParamName(TransactionFieldColumnNames.IsStandardField.ToString(), actionType, taskIndex, count), entity.IsStandardField);
			parms.Add(GetParamName(TransactionFieldColumnNames.DataType.ToString(), actionType, taskIndex, count), entity.DataType);
					
			return parms;
        }


		protected override void CascadeRelations(TransactionField entity, ScriptContext context)
        {
            if (entity == null)
                return;

			//From Foreign Key FK_TransactionFields_Fields
			var transactionFieldValue = GetTransactionFieldValueWriter();
			if (_cascades.Contains(TransactionFieldCascadeNames.transactionfieldvalue.ToString()))
				foreach (var item in entity.TransactionFieldValues)
					Cascade(transactionFieldValue, item, context);

			if (transactionFieldValue.Count > 0)
				WithChild(transactionFieldValue, entity);

		
        }


	}
}
		