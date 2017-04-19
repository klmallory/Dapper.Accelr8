
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
    public class PersonStateProvinceReader : EntityReader<int, PersonStateProvince>
    {
        public PersonStateProvinceReader(
            PersonStateProvinceTableInfo tableInfo
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

		//Child Count 2
		//Parent Count 2
				//Is CompoundKey False
		protected static IEntityReader<int , PersonAddress> GetPersonAddressReader()
		{
			return s_loc8r.GetReader<int , PersonAddress>();
		}

				//Is CompoundKey False
		protected static IEntityReader<int , SalesSalesTaxRate> GetSalesSalesTaxRateReader()
		{
			return s_loc8r.GetReader<int , SalesSalesTaxRate>();
		}

		
		/// <summary>
		/// Sets the children of type PersonAddress on the parent on PersonAddresses.
		/// From foriegn key FK_Address_StateProvince_StateProvinceID
		/// </summary>
		/// <param name="results"></param>
		/// <param name="children"></param>
		public void SetChildrenPersonAddresses(IList<PersonStateProvince> results, IList<object> children)
		{
			//Child Id Type: int
			//Child Type: PersonAddress

			if (results == null || results.Count < 1 || children == null || children.Count < 1)
				return;

			var typedChildren = children.OfType<PersonAddress>();

			foreach (var r in results)
			{
				if (r == null)
					continue;
				r.Loaded = false;
				

				r.PersonAddresses = typedChildren.Where(b =>  b.StateProvinceID == r.Id ).ToList();
				r.PersonAddresses.ToList().ForEach(b => { b.Loaded = false; b.PersonStateProvince = r; b.Loaded = true; });
				
				r.Loaded = true;
			}
		}

		/// <summary>
		/// Sets the children of type SalesSalesTaxRate on the parent on SalesSalesTaxRates.
		/// From foriegn key FK_SalesTaxRate_StateProvince_StateProvinceID
		/// </summary>
		/// <param name="results"></param>
		/// <param name="children"></param>
		public void SetChildrenSalesSalesTaxRates(IList<PersonStateProvince> results, IList<object> children)
		{
			//Child Id Type: int
			//Child Type: SalesSalesTaxRate

			if (results == null || results.Count < 1 || children == null || children.Count < 1)
				return;

			var typedChildren = children.OfType<SalesSalesTaxRate>();

			foreach (var r in results)
			{
				if (r == null)
					continue;
				r.Loaded = false;
				

				r.SalesSalesTaxRates = typedChildren.Where(b =>  b.StateProvinceID == r.Id ).ToList();
				r.SalesSalesTaxRates.ToList().ForEach(b => { b.Loaded = false; b.PersonStateProvince = r; b.Loaded = true; });
				
				r.Loaded = true;
			}
		}

			/// <summary>
		/// Loads the table Person.StateProvince into class PersonStateProvince
		/// </summary>
		/// <param name="results">PersonStateProvince</param>
		/// <param name="row"></param>
        public override PersonStateProvince LoadEntity(dynamic row)
        {
            var dataRow = (IDictionary<string, object>)row;
            var domain = new PersonStateProvince();
			domain.Loaded = false;

			domain.Id = GetRowData<int>(dataRow, "StateProvinceID"); 
      		domain.StateProvinceCode = GetRowData<string>(dataRow, "StateProvinceCode"); 
      		domain.CountryRegionCode = GetRowData<string>(dataRow, "CountryRegionCode"); 
      		domain.IsOnlyStateProvinceFlag = GetRowData<object>(dataRow, "IsOnlyStateProvinceFlag"); 
      		domain.Name = GetRowData<object>(dataRow, "Name"); 
      		domain.TerritoryID = GetRowData<int>(dataRow, "TerritoryID"); 
      		domain.rowguid = GetRowData<Guid>(dataRow, "rowguid"); 
      		domain.ModifiedDate = GetRowData<DateTime>(dataRow, "ModifiedDate"); 
      			
			domain.IsDirty = false;
			domain.Loaded = true;
			return domain;
		}

		/// <summary>
		/// Add All the children to the query for the specified int Id.
		/// </summary>
		/// <param name="results">IEntityReader<int, PersonStateProvince></param>
		/// <param name="id">int</param>
        public override IEntityReader<int, PersonStateProvince> WithAllChildrenForExisting(PersonStateProvince existing)
        {
						WithChildForParentValues(GetPersonAddressReader()
				, new object[] {  existing.Id,  } 
				, new string[] {  "StateProvinceID",  }
				, SetChildrenPersonAddresses);
						WithChildForParentValues(GetSalesSalesTaxRateReader()
				, new object[] {  existing.Id,  } 
				, new string[] {  "StateProvinceID",  }
				, SetChildrenSalesSalesTaxRates);
			
            return this;
        }


        public override void SetAllChildrenForExisting(PersonStateProvince entity)
        {
			ClearAllQueries();

            if (entity == null)
                return;

						WithChildForParentValues(GetPersonAddressReader()
				, new object[] {  entity.Id,  } 
				, new string[] {  "StateProvinceID",  }
				, SetChildrenPersonAddresses);

						WithChildForParentValues(GetSalesSalesTaxRateReader()
				, new object[] {  entity.Id,  } 
				, new string[] {  "StateProvinceID",  }
				, SetChildrenSalesSalesTaxRates);

			
QueryResultForChildrenOnly(new List<PersonStateProvince>() { entity });
			entity.Loaded = false;
			GetPersonAddressReader().SetAllChildrenForExisting(entity.PersonAddresses);
			GetSalesSalesTaxRateReader().SetAllChildrenForExisting(entity.SalesSalesTaxRates);
				
			entity.Loaded = true;
		}

		public override void SetAllChildrenForExisting(IList<PersonStateProvince> entities)
        {
			ClearAllQueries();

            if (entities == null || entities.Count < 1)
                return;

			entities = entities.Where(e => e != null).ToList();

            if (entities.Count < 1)
                return;

			WithChildForParentsValues(GetPersonAddressReader()
				, entities.Select(s => new object[] {  s.Id,  }).ToList() 
				, new string[] {  "StateProvinceID",  }
				, SetChildrenPersonAddresses);

			WithChildForParentsValues(GetSalesSalesTaxRateReader()
				, entities.Select(s => new object[] {  s.Id,  }).ToList() 
				, new string[] {  "StateProvinceID",  }
				, SetChildrenSalesSalesTaxRates);

					
			QueryResultForChildrenOnly(entities);

			GetPersonAddressReader().SetAllChildrenForExisting(entities.SelectMany(e => e.PersonAddresses).ToList());
			GetSalesSalesTaxRateReader().SetAllChildrenForExisting(entities.SelectMany(e => e.SalesSalesTaxRates).ToList());
					
		}
    }
}
		