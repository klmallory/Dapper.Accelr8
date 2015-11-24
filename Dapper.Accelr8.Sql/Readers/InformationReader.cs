

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
    public class InformationReader : EntityReader<int, Information>
    {
        public InformationReader(
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
		/// Loads the table Information into class Information
		/// </summary>
		/// <param name="results">Information</param>
		/// <param name="row"></param>
        public override Information LoadEntity(dynamic row)
        {
            var dataRow = (IDictionary<string, object>)row;
            var domain = new Information();

			domain.Id = GetRowData<int>(dataRow, IdColumn);
			
			domain.DbVersion = GetRowData<string>(dataRow, InformationColumnNames.DBVersion.ToString());             
			
			return domain;
        }

		/// <summary>
		/// Add All the children to the query for the specified int Id.
		/// </summary>
		/// <param name="results">IEntityReader<int, Information></param>
		/// <param name="id">int</param>
        public override IEntityReader<int, Information> WithAllChildrenForId(int id)
        {
			base.WithAllChildrenForId(id);

			
            return this;
        }

        public override void SetAllChildrenForExisting(Information entity)
        {
				
		}

		public override void SetAllChildrenForExisting(IList<Information> entities)
        {
					
		}
    }
}
		