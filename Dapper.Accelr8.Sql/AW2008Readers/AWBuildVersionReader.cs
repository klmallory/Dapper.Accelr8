
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
    public class AWBuildVersionReader : EntityReader<byte, AWBuildVersion>
    {
        public AWBuildVersionReader(
            AWBuildVersionTableInfo tableInfo
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
		/// Loads the table AWBuildVersion into class AWBuildVersion
		/// </summary>
		/// <param name="results">AWBuildVersion</param>
		/// <param name="row"></param>
        public override AWBuildVersion LoadEntity(dynamic row)
        {
            var dataRow = (IDictionary<string, object>)row;
            var domain = new AWBuildVersion();
			domain.Loaded = false;

			domain.Id = GetRowData<byte>(dataRow, "SystemInformationID"); 
      		domain.Database_Spc_Version = GetRowData<string>(dataRow, "Database Version"); 
      		domain.VersionDate = GetRowData<DateTime>(dataRow, "VersionDate"); 
      		domain.ModifiedDate = GetRowData<DateTime>(dataRow, "ModifiedDate"); 
      			
			domain.IsDirty = false;
			domain.Loaded = true;
			return domain;
		}

		/// <summary>
		/// Add All the children to the query for the specified byte Id.
		/// </summary>
		/// <param name="results">IEntityReader<byte, AWBuildVersion></param>
		/// <param name="id">byte</param>
        public override IEntityReader<byte, AWBuildVersion> WithAllChildrenForExisting(AWBuildVersion existing)
        {
			
            return this;
        }


        public override void SetAllChildrenForExisting(AWBuildVersion entity)
        {
				
			entity.Loaded = true;
		}

		public override void SetAllChildrenForExisting(IList<AWBuildVersion> entities)
        {
					
		}
    }
}
		