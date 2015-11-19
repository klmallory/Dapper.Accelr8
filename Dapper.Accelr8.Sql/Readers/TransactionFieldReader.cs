

using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.Accelr8.Domain;
using Dapper.Accelr8.TableInfo;
using Dapper;
using Dapper.Accelr8.Sql;
using Dapper.Accelr8.Repo;
using Dapper.Accelr8.Repo.Parameters;
using Dapper.Accelr8.Repo.Contracts.Readers;

namespace Dapper.Accelr8.Readers
{
    public class TransactionFieldReader : EntityReader<int, TransactionField>
    {
        public TransactionFieldReader(
            TableInfo tableInfo
            , string connectionStringName
            , DapperExecuter executer
            , QueryBuilder queryBuilder
            , JoinBuilder joinBuilder
            , IServiceLocatorMarker serviceLocator) 
            : base(tableInfo, connectionStringName, executer, queryBuilder, joinBuilder, serviceLocator)
        { }

		//Child Count 1
		//Parent Count 0

		/// <summary>
		/// Sets the children of type TransactionFieldValue on the parent on TransactionFieldValues.
		/// From foriegn key FK_TransactionFields_Fields
		/// </summary>
		/// <param name="results"></param>
		/// <param name="children"></param>
		protected void SetChildrenTransactionFieldValues(IList<TransactionField> results, IList<object> children)
		{
			//Child Id Type: int
			//Child Type: TransactionFieldValue

			if (results == null || results.Count < 1 || children == null || children.Count < 1)
				return;

			var typedChildren = children.OfType<TransactionFieldValue>();

			foreach (var r in results)
			{
				r.TransactionFieldValues = typedChildren.Where(b => b.TransactionFieldValueId == r.Id).ToList();
				r.TransactionFieldValues.ToList().ForEach(b => b.TransactionField = r);
			}
		}

			/// <summary>
		/// Loads the table TransactionFields into class TransactionField
		/// </summary>
		/// <param name="results">TransactionField</param>
		/// <param name="row"></param>
        public override TransactionField LoadEntity(dynamic row)
        {
            var dataRow = (IDictionary<string, object>)row;
            var domain = new TransactionField();

			domain.Id = GetRowData<int>(dataRow, IdField);
			
			domain.FieldDescriptor = GetRowData<string>(dataRow, TransactionFieldColumnNames.FieldDescriptor.ToString()); 	
			domain.Description = GetRowData<string>(dataRow, TransactionFieldColumnNames.Description.ToString()); 	
			domain.IsVisible = GetRowData<bool>(dataRow, TransactionFieldColumnNames.IsVisible.ToString()); 	
			domain.IsStandardField = GetRowData<bool?>(dataRow, TransactionFieldColumnNames.IsStandardField.ToString()); 	
			domain.DataType = GetRowData<string>(dataRow, TransactionFieldColumnNames.DataType.ToString());             
			
			return domain;
        }

        public override IEntityReader<int, TransactionField> WithAllChildrenForId(int id)
        {
			base.WithAllChildrenForId(id);

			
			WithChildForParentId(_locator.Resolve<IEntityReader<int , TransactionFieldValues>(), id, IdField, SetChildren);
			
            return this;
        }

        public override void SetAllChildrenForExisting(TransactionField entity)
        {
			ClearAllQueries();

            if (entity == null)
                return;

			WithChildForParentId(_locator.Resolve<IEntityReader<int , TransactionFieldValues>(), id, IdField, SetChildrenTransactionFieldValues);
			QueryResultForChildrenOnly(new List<TransactionField>() { entity });

			_locator.Resolve<IEntityReader<int , TransactionFieldValues>().SetAllChildrenForExisting(entity.TransactionFieldValues);
				
		}

		public override void SetAllChildrenForExisting(IList<TransactionField> entities)
        {
			ClearAllQueries();

            if (entities == null || entities.Count < 1)
                return;

			WithChildForParentId(_locator.Resolve<IEntityReader<int , TransactionFieldValues>(), id, IdField, SetChildrenTransactionFieldValues);
					
			QueryResultForChildrenOnly(entities);

			_locator.Resolve<IEntityReader<int, TransactionFieldValues>().SetAllChildrenForExisting(entities.SelectMany(e => e.TransactionFieldValues));
					
		}
    }
}
		