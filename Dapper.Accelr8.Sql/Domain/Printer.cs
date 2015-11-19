

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
	public class Printer : Dapper.Accelr8.Repo.Domain.BaseEntity<int>
	{	
		public Printer()
		{
			IsDirty = false;
		}
				
		protected string _name;
		public string Name 
		{ 
			get { return _name; }
			set 
			{ 
				_name = value;  
				IsDirty = true;
			}
		} 
			
		protected PrinterGroup _printerGroups;
		public PrinterGroup PrinterGroups 
		{ 
			get { return _printerGroups; }
			set 
			{ 
				_printerGroups = value;  
				IsDirty = true;
			}
		} 
			
		}
}

		