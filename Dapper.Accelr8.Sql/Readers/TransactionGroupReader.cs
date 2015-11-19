

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
    public class TransactionGroupReader : EntityReader<int, TransactionGroup>
    {
        public TransactionGroupReader(
            TableInfo tableInfo
            , string connectionStringName
            , DapperExecuter executer
            , QueryBuilder queryBuilder
            , JoinBuilder joinBuilder
            , IServiceLocatorMarker serviceLocator) 
            : base(tableInfo, connectionStringName, executer, queryBuilder, joinBuilder, serviceLocator)
        { }

		//Child Count 0
		//Parent Count 2

			/// <summary>
		/// Loads the table TransactionGroups into class TransactionGroup
		/// </summary>
		/// <param name="results">TransactionGroup</param>
		/// <param name="row"></param>
        public override TransactionGroup LoadEntity(dynamic row)
        {
            var dataRow = (IDictionary<string, object>)row;
            var domain = new TransactionGroup();

			domain.Id = GetRowData<int>(dataRow, IdField);
			
			domain.TransactionId = GetRowData<int>(dataRow, TransactionGroupColumnNames.TransactionId.ToString()); 	
			domain.GroupId = GetRowData<int>(dataRow, TransactionGroupColumnNames.GroupId.ToString());             
			
			return domain;
        }

        public override IEntityReader<int, TransactionGroup> WithAllChildrenForId(int id)
        {
			base.WithAllChildrenForId(id);

			
            return this;
        }

        public override void SetAllChildrenForExisting(TransactionGroup entity)
        {
				
		}

		public override void SetAllChildrenForExisting(IList<TransactionGroup> entities)
        {
					
		}
    }
}
		