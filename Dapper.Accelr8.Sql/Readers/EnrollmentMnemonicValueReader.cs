

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
    public class EnrollmentMnemonicValueReader : EntityReader<int, EnrollmentMnemonicValue>
    {
        public EnrollmentMnemonicValueReader(
            TableInfo tableInfo
            , string connectionStringName
            , DapperExecuter executer
            , QueryBuilder queryBuilder
            , JoinBuilder joinBuilder
            , IServiceLocatorMarker serviceLocator) 
            : base(tableInfo, connectionStringName, executer, queryBuilder, joinBuilder, serviceLocator)
        { }

		//Child Count 0
		//Parent Count 1

			/// <summary>
		/// Loads the table EnrollmentMnemonicValues into class EnrollmentMnemonicValue
		/// </summary>
		/// <param name="results">EnrollmentMnemonicValue</param>
		/// <param name="row"></param>
        public override EnrollmentMnemonicValue LoadEntity(dynamic row)
        {
            var dataRow = (IDictionary<string, object>)row;
            var domain = new EnrollmentMnemonicValue();

			domain.Id = GetRowData<int>(dataRow, IdField);
			
			domain.TransactionId = GetRowData<int>(dataRow, EnrollmentMnemonicValueColumnNames.TransactionId.ToString()); 	
			domain.EnrollmentMnemonicValueEntry = GetRowData<string>(dataRow, EnrollmentMnemonicValueColumnNames.EnrollmentMnemonicValueEntry.ToString()); 	
			domain.EnrollmentMnemonicType = GetRowData<string>(dataRow, EnrollmentMnemonicValueColumnNames.EnrollmentMnemonicType.ToString()); 	
			domain.EnrollmentMnemonicDescription = GetRowData<string>(dataRow, EnrollmentMnemonicValueColumnNames.EnrollmentMnemonicDescription.ToString()); 	
			domain.MnemonicCode = GetRowData<string>(dataRow, EnrollmentMnemonicValueColumnNames.MnemonicCode.ToString());             
			
			return domain;
        }

        public override IEntityReader<int, EnrollmentMnemonicValue> WithAllChildrenForId(int id)
        {
			base.WithAllChildrenForId(id);

			
            return this;
        }

        public override void SetAllChildrenForExisting(EnrollmentMnemonicValue entity)
        {
				
		}

		public override void SetAllChildrenForExisting(IList<EnrollmentMnemonicValue> entities)
        {
					
		}
    }
}
		