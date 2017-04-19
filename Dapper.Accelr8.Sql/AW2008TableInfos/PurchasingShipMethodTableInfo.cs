
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
	public enum PurchasingShipMethodFieldNames
	{	
		Id, 	
		Name, 	
		ShipBase, 	
		ShipRate, 	
		rowguid, 	
		ModifiedDate, 	
	}

	public enum PurchasingShipMethodCascadeNames
	{	
		purchasingpurchaseorderheaders, 	
		salessalesorderheaders, 	
		}

	public class PurchasingShipMethodTableInfo : Dapper.Accelr8.Sql.TableInfo
	{	
	
		public static readonly IDictionary<int, string> PurchasingShipMethodColumnNames 
		= new Dictionary<int, string>()
		{
					{ (int)PurchasingShipMethodFieldNames.Id, "ShipMethodID" }, 
						{ (int)PurchasingShipMethodFieldNames.Name, "Name" }, 
						{ (int)PurchasingShipMethodFieldNames.ShipBase, "ShipBase" }, 
						{ (int)PurchasingShipMethodFieldNames.ShipRate, "ShipRate" }, 
						{ (int)PurchasingShipMethodFieldNames.rowguid, "rowguid" }, 
						{ (int)PurchasingShipMethodFieldNames.ModifiedDate, "ModifiedDate" }, 
				};	

		public static readonly IDictionary<int, string> PurchasingShipMethodIdColumnNames
		= new Dictionary<int, string>()
		{
					{ (int)PurchasingShipMethodFieldNames.Id, "ShipMethodID" }, 
				};

		public PurchasingShipMethodTableInfo(ILoc8 loc8r) : base(loc8r)
		{
			int c = 0;
			UniqueId = true;
			Schema = "Purchasing";
			TableName = "Purchasing.ShipMethod";
			TableAlias = "purchasingshipmethod";
			Columns = PurchasingShipMethodColumnNames;
			IdColumns = PurchasingShipMethodIdColumnNames;

			Joins = new JoinInfo[] {
						};
		}
	}
}

		