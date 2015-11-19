

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
    public class LicenseReader : EntityReader<int, License>
    {
        public LicenseReader(
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
		/// Loads the table Licenses into class License
		/// </summary>
		/// <param name="results">License</param>
		/// <param name="row"></param>
        public override License LoadEntity(dynamic row)
        {
            var dataRow = (IDictionary<string, object>)row;
            var domain = new License();

			domain.Id = GetRowData<int>(dataRow, IdField);
			
			domain.LicenseType = GetRowData<string>(dataRow, LicenseColumnNames.LicenseType.ToString()); 	
			domain.ComputerName = GetRowData<string>(dataRow, LicenseColumnNames.ComputerName.ToString()); 	
			domain.MACAddress = GetRowData<string>(dataRow, LicenseColumnNames.MACAddress.ToString()); 	
			domain.DeviceSerialNum = GetRowData<string>(dataRow, LicenseColumnNames.DeviceSerialNum.ToString()); 	
			domain.UserId = GetRowData<int?>(dataRow, LicenseColumnNames.UserId.ToString()); 	
			domain.WorkstationId = GetRowData<string>(dataRow, LicenseColumnNames.WorkstationId.ToString());             
			
			return domain;
        }

        public override IEntityReader<int, License> WithAllChildrenForId(int id)
        {
			base.WithAllChildrenForId(id);

			
            return this;
        }

        public override void SetAllChildrenForExisting(License entity)
        {
				
		}

		public override void SetAllChildrenForExisting(IList<License> entities)
        {
					
		}
    }
}
		