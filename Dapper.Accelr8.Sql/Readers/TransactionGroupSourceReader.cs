

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
    public class TransactionGroupSourceReader : EntityReader<int, TransactionGroupSource>
    {
        public TransactionGroupSourceReader(
            TableInfo tableInfo
            , string connectionStringName
            , DapperExecuter executer
            , QueryBuilder queryBuilder
            , JoinBuilder joinBuilder
            , IServiceLocatorMarker serviceLocator) 
            : base(tableInfo, connectionStringName, executer, queryBuilder, joinBuilder, serviceLocator)
        { }

		//Child Count 0
		//Parent Count 0

			/// <summary>
		/// Loads the table TransactionGroupSource into class TransactionGroupSource
		/// </summary>
		/// <param name="results">TransactionGroupSource</param>
		/// <param name="row"></param>
        public override TransactionGroupSource LoadEntity(dynamic row)
        {
            var dataRow = (IDictionary<string, object>)row;
            var domain = new TransactionGroupSource();

			
			domain.TransactionId = GetRowData<int>(dataRow, TransactionGroupSourceColumnNames.TransactionId.ToString()); 	
			domain.TCN = GetRowData<string>(dataRow, TransactionGroupSourceColumnNames.TCN.ToString()); 	
			domain.CreatedDate = GetRowData<DateTime>(dataRow, TransactionGroupSourceColumnNames.CreatedDate.ToString()); 	
			domain.Name = GetRowData<string>(dataRow, TransactionGroupSourceColumnNames.Name.ToString()); 	
			domain.TransactionType = GetRowData<string>(dataRow, TransactionGroupSourceColumnNames.TransactionType.ToString()); 	
			domain.TransactionStatus = GetRowData<string>(dataRow, TransactionGroupSourceColumnNames.TransactionStatus.ToString()); 	
			domain.Value = GetRowData<string>(dataRow, TransactionGroupSourceColumnNames.Value.ToString()); 	
			domain.TransactionFieldId = GetRowData<int?>(dataRow, TransactionGroupSourceColumnNames.TransactionFieldId.ToString()); 	
			domain.FieldDescriptor = GetRowData<string>(dataRow, TransactionGroupSourceColumnNames.FieldDescriptor.ToString()); 	
			domain.Username = GetRowData<string>(dataRow, TransactionGroupSourceColumnNames.Username.ToString()); 	
			domain.SourceKey = GetRowData<string>(dataRow, TransactionGroupSourceColumnNames.SourceKey.ToString()); 	
			domain.AgencyName = GetRowData<string>(dataRow, TransactionGroupSourceColumnNames.AgencyName.ToString());             
			
			return domain;
        }

        public override IEntityReader<int, TransactionGroupSource> WithAllChildrenForId(int id)
        {
			base.WithAllChildrenForId(id);

			
            return this;
        }

        public override void SetAllChildrenForExisting(TransactionGroupSource entity)
        {
				
		}

		public override void SetAllChildrenForExisting(IList<TransactionGroupSource> entities)
        {
					
		}
    }
}
		