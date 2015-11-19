

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
    public class AuditTrailReader : EntityReader<int, AuditTrail>
    {
        public AuditTrailReader(
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
		/// Loads the table AuditTrail into class AuditTrail
		/// </summary>
		/// <param name="results">AuditTrail</param>
		/// <param name="row"></param>
        public override AuditTrail LoadEntity(dynamic row)
        {
            var dataRow = (IDictionary<string, object>)row;
            var domain = new AuditTrail();

			domain.Id = GetRowData<int>(dataRow, IdField);
			
			domain.UserName = GetRowData<string>(dataRow, AuditTrailColumnNames.UserName.ToString()); 	
			domain.AuditDate = GetRowData<DateTime>(dataRow, AuditTrailColumnNames.AuditDate.ToString()); 	
			domain.Action = GetRowData<string>(dataRow, AuditTrailColumnNames.Action.ToString()); 	
			domain.Area = GetRowData<string>(dataRow, AuditTrailColumnNames.Area.ToString()); 	
			domain.Details = GetRowData<string>(dataRow, AuditTrailColumnNames.Details.ToString());             
			
			return domain;
        }

        public override IEntityReader<int, AuditTrail> WithAllChildrenForId(int id)
        {
			base.WithAllChildrenForId(id);

			
            return this;
        }

        public override void SetAllChildrenForExisting(AuditTrail entity)
        {
				
		}

		public override void SetAllChildrenForExisting(IList<AuditTrail> entities)
        {
					
		}
    }
}
		