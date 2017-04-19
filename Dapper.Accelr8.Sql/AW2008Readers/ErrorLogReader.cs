
using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Text;

using Dapper.Accelr8.Sql.AW2008DAO;
using Dapper.Accelr8.AW2008TableInfos;
using Dapper;
using Dapper.Accelr8.Sql;
using Dapper.Accelr8.Domain;
using Dapper.Accelr8.Repo;
using Dapper.Accelr8.Repo.Parameters;
using Dapper.Accelr8.Repo.Contracts;

namespace Dapper.Accelr8.AW2008Readers
{
    public class ErrorLogReader : EntityReader<int, ErrorLog>
    {
        public ErrorLogReader(
            ErrorLogTableInfo tableInfo
            , string connectionStringName
            , DapperExecuter executer
            , QueryBuilder queryBuilder
            , JoinBuilder joinBuilder
            , ILoc8 loc8r) 
            : base(tableInfo, connectionStringName, executer, queryBuilder, joinBuilder, loc8r)
        {
			if (s_loc8r == null)
				s_loc8r = loc8r;		 
		}

		static ILoc8 s_loc8r = null;

		//Child Count 0
		//Parent Count 0
		
			/// <summary>
		/// Loads the table ErrorLog into class ErrorLog
		/// </summary>
		/// <param name="results">ErrorLog</param>
		/// <param name="row"></param>
        public override ErrorLog LoadEntity(dynamic row)
        {
            var dataRow = (IDictionary<string, object>)row;
            var domain = new ErrorLog();
			domain.Loaded = false;

			domain.Id = GetRowData<int>(dataRow, "ErrorLogID"); 
      		domain.ErrorTime = GetRowData<DateTime>(dataRow, "ErrorTime"); 
      		domain.UserName = GetRowData<object>(dataRow, "UserName"); 
      		domain.ErrorNumber = GetRowData<int>(dataRow, "ErrorNumber"); 
      		domain.ErrorSeverity = GetRowData<int?>(dataRow, "ErrorSeverity"); 
      		domain.ErrorState = GetRowData<int?>(dataRow, "ErrorState"); 
      		domain.ErrorProcedure = GetRowData<string>(dataRow, "ErrorProcedure"); 
      		domain.ErrorLine = GetRowData<int?>(dataRow, "ErrorLine"); 
      		domain.ErrorMessage = GetRowData<string>(dataRow, "ErrorMessage"); 
      			
			domain.IsDirty = false;
			domain.Loaded = true;
			return domain;
		}

		/// <summary>
		/// Add All the children to the query for the specified int Id.
		/// </summary>
		/// <param name="results">IEntityReader<int, ErrorLog></param>
		/// <param name="id">int</param>
        public override IEntityReader<int, ErrorLog> WithAllChildrenForExisting(ErrorLog existing)
        {
			
            return this;
        }


        public override void SetAllChildrenForExisting(ErrorLog entity)
        {
				
			entity.Loaded = true;
		}

		public override void SetAllChildrenForExisting(IList<ErrorLog> entities)
        {
					
		}
    }
}
		