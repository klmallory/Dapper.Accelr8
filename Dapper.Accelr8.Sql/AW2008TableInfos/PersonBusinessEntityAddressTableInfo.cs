
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
using Dapper.Accelr8.Repo.Extensions;
using Dapper.Accelr8.Repo.Parameters;
using Dapper.Accelr8.Repo.Contracts;

namespace Dapper.Accelr8.AW2008TableInfos
{
	public enum PersonBusinessEntityAddressColumnNames
	{	
		BusinessEntityID, 	
		AddressID, 	
		AddressTypeID, 	
		rowguid, 	
		ModifiedDate, 	
	}

	public enum PersonBusinessEntityAddressCascadeNames
	{	
		
		personaddress_p, 	
		personaddresstype_p, 	
		personbusinessentity_p, 	}

	public class PersonBusinessEntityAddressTableInfo : Dapper.Accelr8.Sql.TableInfo
	{
		public PersonBusinessEntityAddressTableInfo(ILoc8 loc8r) : base(loc8r)
		{
			UniqueId = true;
			IdColumn = PersonBusinessEntityAddressColumnNames.BusinessEntityID.ToString();
			//Schema = "Person.BusinessEntityAddress";
			TableName = "Person.BusinessEntityAddress";
			TableAlias = "personbusinessentityaddress";
			ColumnNames = typeof(PersonBusinessEntityAddressColumnNames).ToDataList<Type, int>();

			Joins = new JoinInfo[] {
						//For Key FK_BusinessEntityAddress_Address_AddressID
			new JoinInfo() {
			Reader = new Func<IEntityReader>(() => Loc8r.GetReader<int, PersonAddress>("PersonAddress")),
			TableName = "Person.Address",
			Alias = TableAlias + "_" + "PersonAddress",
			Outer = false,
			Load = (entity, row) =>
				{ 
					var reader = Loc8r.GetReader<int, PersonAddress>("PersonAddress");
					var st = (entity as PersonBusinessEntityAddress);

					if (st == null || row == null)
						return st;

					if (row.AddressID == null || row.AddressID == default(int))
						return st;

					st.PersonAddress = reader.LoadEntityObject(row);

					return st;
				},
			JoinQuery = new JoinQueryElement[]
			{
				new JoinQueryElement() 
				{ 
					//PersonAddressColumnNames.   .ToString()
					//PersonBusinessEntityAddressColumnNames.      .ToString()
					JoinField = "AddressID",
					Operator = Operator.Equals,
					ParentField = "AddressID",
					ParentTableAlias = TableAlias
				}
			} },
						//For Key FK_BusinessEntityAddress_AddressType_AddressTypeID
			new JoinInfo() {
			Reader = new Func<IEntityReader>(() => Loc8r.GetReader<int, PersonAddressType>("PersonAddressType")),
			TableName = "Person.AddressType",
			Alias = TableAlias + "_" + "PersonAddressType",
			Outer = false,
			Load = (entity, row) =>
				{ 
					var reader = Loc8r.GetReader<int, PersonAddressType>("PersonAddressType");
					var st = (entity as PersonBusinessEntityAddress);

					if (st == null || row == null)
						return st;

					if (row.AddressTypeID == null || row.AddressTypeID == default(int))
						return st;

					st.PersonAddressType = reader.LoadEntityObject(row);

					return st;
				},
			JoinQuery = new JoinQueryElement[]
			{
				new JoinQueryElement() 
				{ 
					//PersonAddressTypeColumnNames.   .ToString()
					//PersonBusinessEntityAddressColumnNames.      .ToString()
					JoinField = "AddressTypeID",
					Operator = Operator.Equals,
					ParentField = "AddressTypeID",
					ParentTableAlias = TableAlias
				}
			} },
						//For Key FK_BusinessEntityAddress_BusinessEntity_BusinessEntityID
			new JoinInfo() {
			Reader = new Func<IEntityReader>(() => Loc8r.GetReader<int, PersonBusinessEntity>("PersonBusinessEntity")),
			TableName = "Person.BusinessEntity",
			Alias = TableAlias + "_" + "PersonBusinessEntity",
			Outer = false,
			Load = (entity, row) =>
				{ 
					var reader = Loc8r.GetReader<int, PersonBusinessEntity>("PersonBusinessEntity");
					var st = (entity as PersonBusinessEntityAddress);

					if (st == null || row == null)
						return st;

					if (row.BusinessEntityID == null || row.BusinessEntityID == default(int))
						return st;

					st.PersonBusinessEntity = reader.LoadEntityObject(row);

					return st;
				},
			JoinQuery = new JoinQueryElement[]
			{
				new JoinQueryElement() 
				{ 
					//PersonBusinessEntityColumnNames.   .ToString()
					//PersonBusinessEntityAddressColumnNames.      .ToString()
					JoinField = "BusinessEntityID",
					Operator = Operator.Equals,
					ParentField = "BusinessEntityID",
					ParentTableAlias = TableAlias
				}
			} },
						};
		}
	}
}

		