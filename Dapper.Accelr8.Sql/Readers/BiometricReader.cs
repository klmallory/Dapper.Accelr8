

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
using Dapper.Accelr8.Repo.Contracts.Readers;

namespace Dapper.Accelr8.Readers
{
    public class BiometricReader : EntityReader<int, Biometric>
    {
        public BiometricReader(
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
		/// Loads the table Biometrics into class Biometric
		/// </summary>
		/// <param name="results">Biometric</param>
		/// <param name="row"></param>
        public override Biometric LoadEntity(dynamic row)
        {
            var dataRow = (IDictionary<string, object>)row;
            var domain = new Biometric();

			domain.Id = GetRowData<int>(dataRow, IdColumn);
			
			domain.TransactionId = GetRowData<int>(dataRow, BiometricColumnNames.TransactionId.ToString()); 	
			domain.FingerPosition = GetRowData<string>(dataRow, BiometricColumnNames.FingerPosition.ToString()); 	
			domain.Quality = GetRowData<int>(dataRow, BiometricColumnNames.Quality.ToString()); 	
			domain.Modality = GetRowData<string>(dataRow, BiometricColumnNames.Modality.ToString());             
			
			return domain;
        }

		/// <summary>
		/// Add All the children to the query for the specified int Id.
		/// </summary>
		/// <param name="results">IEntityReader<int, Biometric></param>
		/// <param name="id">int</param>
        public override IEntityReader<int, Biometric> WithAllChildrenForId(int id)
        {
			base.WithAllChildrenForId(id);

			
            return this;
        }

        public override void SetAllChildrenForExisting(Biometric entity)
        {
				
		}

		public override void SetAllChildrenForExisting(IList<Biometric> entities)
        {
					
		}
    }
}
		