
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

namespace Dapper.Accelr8.AW2008Writers
{
    public class SalesSalesTaxRateWriter : EntityWriter<int, SalesSalesTaxRate>
    {
        public SalesSalesTaxRateWriter
			(SalesSalesTaxRateTableInfo tableInfo
            , string connectionStringName
            , DapperExecuter executer
            , QueryBuilder queryBuilder
            , JoinBuilder joinBuilder
			, ILoc8 loc8r) 
            : base(tableInfo, connectionStringName, executer, queryBuilder, joinBuilder, loc8r)
		{

		}

		
		static IEntityWriter<int, PersonStateProvince> GetPersonStateProvinceWriter()
		{ return _locator.Resolve<IEntityWriter<int, PersonStateProvince>>(); }
		
		/// <summary>
		/// Gets the Sql Parameters from the Entity and names them according to column, action, and batch task, and array count.
		/// </summary>
		/// <param name="results">Parameters for sql writes</param>
		/// <param name="row"></param>
        protected override IDictionary<string, object> GetParams(ActionType actionType, SalesSalesTaxRate entity, int taskIndex, ref int count)
        {
            var parms = new Dictionary<string, object>();
			
			foreach (var f in ColumnNames)
            {
                switch ((SalesSalesTaxRateColumnNames)f.Key)
                {
                    
					case SalesSalesTaxRateColumnNames.StateProvinceID:
						parms.Add(GetParamName("StateProvinceID", actionType, taskIndex, ref count), entity.StateProvinceID);
						break;
					case SalesSalesTaxRateColumnNames.TaxType:
						parms.Add(GetParamName("TaxType", actionType, taskIndex, ref count), entity.TaxType);
						break;
					case SalesSalesTaxRateColumnNames.TaxRate:
						parms.Add(GetParamName("TaxRate", actionType, taskIndex, ref count), entity.TaxRate);
						break;
					case SalesSalesTaxRateColumnNames.Name:
						parms.Add(GetParamName("Name", actionType, taskIndex, ref count), entity.Name);
						break;
					case SalesSalesTaxRateColumnNames.rowguid:
						parms.Add(GetParamName("rowguid", actionType, taskIndex, ref count), entity.rowguid);
						break;
					case SalesSalesTaxRateColumnNames.ModifiedDate:
						parms.Add(GetParamName("ModifiedDate", actionType, taskIndex, ref count), entity.ModifiedDate);
						break;
				}
			}

			return parms;
        }


		protected override void CascadeRelations(SalesSalesTaxRate entity, ScriptContext context)
        {
            if (entity == null)
                return;

		
		
			//From Foreign Key FK_SalesTaxRate_StateProvince_StateProvinceID
			var personStateProvince345 = GetPersonStateProvinceWriter();
		if ((_cascades.Contains(SalesSalesTaxRateCascadeNames.personstateprovince.ToString()) || _cascades.Contains("all")) && entity.PersonStateProvince != null)
			if (Cascade(personStateProvince345, entity.PersonStateProvince, context))
				WithParent(personStateProvince345, entity);

				}

		protected override void UpdateIdsFromReferences(IList<string> cascades, SalesSalesTaxRate entity)
        {
            if (entity == null)
                return;

				
			//From Foreign Key FK_SalesTaxRate_StateProvince_StateProvinceID
			if (entity.PersonStateProvince != null)
				entity.SalesSalesTaxRate = entity.PersonStateProvince.Id;

		}

		protected override void RemoveRelations(SalesSalesTaxRate entity, ScriptContext context)
        {
				}
	}
}
		