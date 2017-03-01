
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
	public enum PurchasingShipMethodColumnNames
	{	
		ShipMethodID, 	
		Name, 	
		ShipBase, 	
		ShipRate, 	
		rowguid, 	
		ModifiedDate, 	
	}

	public enum PurchasingShipMethodCascadeNames
	{	
		purchasingpurchaseorderheader, 	
		salessalesorderheader, 	
		}

	public class PurchasingShipMethodTableInfo : Dapper.Accelr8.Sql.TableInfo
	{
		public PurchasingShipMethodTableInfo(ILoc8 loc8r) : base(loc8r)
		{
			UniqueId = true;
			IdColumn = PurchasingShipMethodColumnNames.ShipMethodID.ToString();
			//Schema = "Purchasing.ShipMethod";
			TableName = "Purchasing.ShipMethod";
			TableAlias = "purchasingshipmethod";
			ColumnNames = typeof(PurchasingShipMethodColumnNames).ToDataList<Type, int>();

			Joins = new JoinInfo[] {
						};
		}
	}
}

		