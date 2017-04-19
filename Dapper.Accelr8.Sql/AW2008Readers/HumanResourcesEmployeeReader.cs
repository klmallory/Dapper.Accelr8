
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
    public class HumanResourcesEmployeeReader : EntityReader<int, HumanResourcesEmployee>
    {
        public HumanResourcesEmployeeReader(
            HumanResourcesEmployeeTableInfo tableInfo
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

		//Child Count 6
		//Parent Count 1
				//Is CompoundKey False
		protected static IEntityReader<Microsoft.SqlServer.Types.SqlHierarchyId , ProductionDocument> GetProductionDocumentReader()
		{
			return s_loc8r.GetReader<Microsoft.SqlServer.Types.SqlHierarchyId , ProductionDocument>();
		}

				//Is CompoundKey True
		protected static IEntityReader<CompoundKey , HumanResourcesEmployeeDepartmentHistory> GetHumanResourcesEmployeeDepartmentHistoryReader()
		{
			return s_loc8r.GetReader<CompoundKey , HumanResourcesEmployeeDepartmentHistory>();
		}

				//Is CompoundKey True
		protected static IEntityReader<CompoundKey , HumanResourcesEmployeePayHistory> GetHumanResourcesEmployeePayHistoryReader()
		{
			return s_loc8r.GetReader<CompoundKey , HumanResourcesEmployeePayHistory>();
		}

				//Is CompoundKey False
		protected static IEntityReader<int , HumanResourcesJobCandidate> GetHumanResourcesJobCandidateReader()
		{
			return s_loc8r.GetReader<int , HumanResourcesJobCandidate>();
		}

				//Is CompoundKey False
		protected static IEntityReader<int , PurchasingPurchaseOrderHeader> GetPurchasingPurchaseOrderHeaderReader()
		{
			return s_loc8r.GetReader<int , PurchasingPurchaseOrderHeader>();
		}

				//Is CompoundKey False
		protected static IEntityReader<int , SalesSalesPerson> GetSalesSalesPersonReader()
		{
			return s_loc8r.GetReader<int , SalesSalesPerson>();
		}

		
		/// <summary>
		/// Sets the children of type ProductionDocument on the parent on ProductionDocuments.
		/// From foriegn key FK_Document_Employee_Owner
		/// </summary>
		/// <param name="results"></param>
		/// <param name="children"></param>
		public void SetChildrenProductionDocuments(IList<HumanResourcesEmployee> results, IList<object> children)
		{
			//Child Id Type: Microsoft.SqlServer.Types.SqlHierarchyId
			//Child Type: ProductionDocument

			if (results == null || results.Count < 1 || children == null || children.Count < 1)
				return;

			var typedChildren = children.OfType<ProductionDocument>();

			foreach (var r in results)
			{
				if (r == null)
					continue;
				r.Loaded = false;
				

				r.ProductionDocuments = typedChildren.Where(b =>  b.Owner == r.Id ).ToList();
				r.ProductionDocuments.ToList().ForEach(b => { b.Loaded = false; b.HumanResourcesEmployee = r; b.Loaded = true; });
				
				r.Loaded = true;
			}
		}

		/// <summary>
		/// Sets the children of type HumanResourcesEmployeeDepartmentHistory on the parent on HumanResourcesEmployeeDepartmentHistories.
		/// From foriegn key FK_EmployeeDepartmentHistory_Employee_BusinessEntityID
		/// </summary>
		/// <param name="results"></param>
		/// <param name="children"></param>
		public void SetChildrenHumanResourcesEmployeeDepartmentHistories(IList<HumanResourcesEmployee> results, IList<object> children)
		{
			//Child Id Type: CompoundKey
			//Child Type: HumanResourcesEmployeeDepartmentHistory

			if (results == null || results.Count < 1 || children == null || children.Count < 1)
				return;

			var typedChildren = children.OfType<HumanResourcesEmployeeDepartmentHistory>();

			foreach (var r in results)
			{
				if (r == null)
					continue;
				r.Loaded = false;
				

				r.HumanResourcesEmployeeDepartmentHistories = typedChildren.Where(b =>  b.BusinessEntityID == r.Id ).ToList();
				r.HumanResourcesEmployeeDepartmentHistories.ToList().ForEach(b => { b.Loaded = false; b.HumanResourcesEmployee = r; b.Loaded = true; });
				
				r.Loaded = true;
			}
		}

		/// <summary>
		/// Sets the children of type HumanResourcesEmployeePayHistory on the parent on HumanResourcesEmployeePayHistories.
		/// From foriegn key FK_EmployeePayHistory_Employee_BusinessEntityID
		/// </summary>
		/// <param name="results"></param>
		/// <param name="children"></param>
		public void SetChildrenHumanResourcesEmployeePayHistories(IList<HumanResourcesEmployee> results, IList<object> children)
		{
			//Child Id Type: CompoundKey
			//Child Type: HumanResourcesEmployeePayHistory

			if (results == null || results.Count < 1 || children == null || children.Count < 1)
				return;

			var typedChildren = children.OfType<HumanResourcesEmployeePayHistory>();

			foreach (var r in results)
			{
				if (r == null)
					continue;
				r.Loaded = false;
				

				r.HumanResourcesEmployeePayHistories = typedChildren.Where(b =>  b.BusinessEntityID == r.Id ).ToList();
				r.HumanResourcesEmployeePayHistories.ToList().ForEach(b => { b.Loaded = false; b.HumanResourcesEmployee = r; b.Loaded = true; });
				
				r.Loaded = true;
			}
		}

		/// <summary>
		/// Sets the children of type HumanResourcesJobCandidate on the parent on HumanResourcesJobCandidates.
		/// From foriegn key FK_JobCandidate_Employee_BusinessEntityID
		/// </summary>
		/// <param name="results"></param>
		/// <param name="children"></param>
		public void SetChildrenHumanResourcesJobCandidates(IList<HumanResourcesEmployee> results, IList<object> children)
		{
			//Child Id Type: int
			//Child Type: HumanResourcesJobCandidate

			if (results == null || results.Count < 1 || children == null || children.Count < 1)
				return;

			var typedChildren = children.OfType<HumanResourcesJobCandidate>();

			foreach (var r in results)
			{
				if (r == null)
					continue;
				r.Loaded = false;
				

				r.HumanResourcesJobCandidates = typedChildren.Where(b =>  b.BusinessEntityID == r.Id ).ToList();
				r.HumanResourcesJobCandidates.ToList().ForEach(b => { b.Loaded = false; b.HumanResourcesEmployee = r; b.Loaded = true; });
				
				r.Loaded = true;
			}
		}

		/// <summary>
		/// Sets the children of type PurchasingPurchaseOrderHeader on the parent on PurchasingPurchaseOrderHeaders.
		/// From foriegn key FK_PurchaseOrderHeader_Employee_EmployeeID
		/// </summary>
		/// <param name="results"></param>
		/// <param name="children"></param>
		public void SetChildrenPurchasingPurchaseOrderHeaders(IList<HumanResourcesEmployee> results, IList<object> children)
		{
			//Child Id Type: int
			//Child Type: PurchasingPurchaseOrderHeader

			if (results == null || results.Count < 1 || children == null || children.Count < 1)
				return;

			var typedChildren = children.OfType<PurchasingPurchaseOrderHeader>();

			foreach (var r in results)
			{
				if (r == null)
					continue;
				r.Loaded = false;
				

				r.PurchasingPurchaseOrderHeaders = typedChildren.Where(b =>  b.EmployeeID == r.Id ).ToList();
				r.PurchasingPurchaseOrderHeaders.ToList().ForEach(b => { b.Loaded = false; b.HumanResourcesEmployee = r; b.Loaded = true; });
				
				r.Loaded = true;
			}
		}

		/// <summary>
		/// Sets the children of type SalesSalesPerson on the parent on SalesSalesPeople.
		/// From foriegn key FK_SalesPerson_Employee_BusinessEntityID
		/// </summary>
		/// <param name="results"></param>
		/// <param name="children"></param>
		public void SetChildrenSalesSalesPeople(IList<HumanResourcesEmployee> results, IList<object> children)
		{
			//Child Id Type: int
			//Child Type: SalesSalesPerson

			if (results == null || results.Count < 1 || children == null || children.Count < 1)
				return;

			var typedChildren = children.OfType<SalesSalesPerson>();

			foreach (var r in results)
			{
				if (r == null)
					continue;
				r.Loaded = false;
				

				r.SalesSalesPeople = typedChildren.Where(b =>  b.Id == r.Id ).ToList();
				r.SalesSalesPeople.ToList().ForEach(b => { b.Loaded = false; b.HumanResourcesEmployee = r; b.Loaded = true; });
				
				r.Loaded = true;
			}
		}

			/// <summary>
		/// Loads the table HumanResources.Employee into class HumanResourcesEmployee
		/// </summary>
		/// <param name="results">HumanResourcesEmployee</param>
		/// <param name="row"></param>
        public override HumanResourcesEmployee LoadEntity(dynamic row)
        {
            var dataRow = (IDictionary<string, object>)row;
            var domain = new HumanResourcesEmployee();
			domain.Loaded = false;

			domain.Id = GetRowData<int>(dataRow, "BusinessEntityID"); 
      		domain.NationalIDNumber = GetRowData<string>(dataRow, "NationalIDNumber"); 
      		domain.LoginID = GetRowData<string>(dataRow, "LoginID"); 
      		domain.OrganizationNode = GetRowData<Microsoft.SqlServer.Types.SqlHierarchyId?>(dataRow, "OrganizationNode"); 
      		domain.OrganizationLevel = GetRowData<short?>(dataRow, "OrganizationLevel"); 
      		domain.JobTitle = GetRowData<string>(dataRow, "JobTitle"); 
      		domain.BirthDate = GetRowData<DateTime>(dataRow, "BirthDate"); 
      		domain.MaritalStatus = GetRowData<string>(dataRow, "MaritalStatus"); 
      		domain.Gender = GetRowData<string>(dataRow, "Gender"); 
      		domain.HireDate = GetRowData<DateTime>(dataRow, "HireDate"); 
      		domain.SalariedFlag = GetRowData<object>(dataRow, "SalariedFlag"); 
      		domain.VacationHours = GetRowData<short>(dataRow, "VacationHours"); 
      		domain.SickLeaveHours = GetRowData<short>(dataRow, "SickLeaveHours"); 
      		domain.CurrentFlag = GetRowData<object>(dataRow, "CurrentFlag"); 
      		domain.rowguid = GetRowData<Guid>(dataRow, "rowguid"); 
      		domain.ModifiedDate = GetRowData<DateTime>(dataRow, "ModifiedDate"); 
      			
			domain.IsDirty = false;
			domain.Loaded = true;
			return domain;
		}

		/// <summary>
		/// Add All the children to the query for the specified int Id.
		/// </summary>
		/// <param name="results">IEntityReader<int, HumanResourcesEmployee></param>
		/// <param name="id">int</param>
        public override IEntityReader<int, HumanResourcesEmployee> WithAllChildrenForExisting(HumanResourcesEmployee existing)
        {
						WithChildForParentValues(GetProductionDocumentReader()
				, new object[] {  existing.Id,  } 
				, new string[] {  "Owner",  }
				, SetChildrenProductionDocuments);
						WithChildForParentValues(GetHumanResourcesEmployeeDepartmentHistoryReader()
				, new object[] {  existing.Id,  } 
				, new string[] {  "BusinessEntityID",  }
				, SetChildrenHumanResourcesEmployeeDepartmentHistories);
						WithChildForParentValues(GetHumanResourcesEmployeePayHistoryReader()
				, new object[] {  existing.Id,  } 
				, new string[] {  "BusinessEntityID",  }
				, SetChildrenHumanResourcesEmployeePayHistories);
						WithChildForParentValues(GetHumanResourcesJobCandidateReader()
				, new object[] {  existing.Id,  } 
				, new string[] {  "BusinessEntityID",  }
				, SetChildrenHumanResourcesJobCandidates);
						WithChildForParentValues(GetPurchasingPurchaseOrderHeaderReader()
				, new object[] {  existing.Id,  } 
				, new string[] {  "EmployeeID",  }
				, SetChildrenPurchasingPurchaseOrderHeaders);
						WithChildForParentValues(GetSalesSalesPersonReader()
				, new object[] {  existing.Id,  } 
				, new string[] {  "Id",  }
				, SetChildrenSalesSalesPeople);
			
            return this;
        }


        public override void SetAllChildrenForExisting(HumanResourcesEmployee entity)
        {
			ClearAllQueries();

            if (entity == null)
                return;

						WithChildForParentValues(GetProductionDocumentReader()
				, new object[] {  entity.Id,  } 
				, new string[] {  "Owner",  }
				, SetChildrenProductionDocuments);

						WithChildForParentValues(GetHumanResourcesEmployeeDepartmentHistoryReader()
				, new object[] {  entity.Id,  } 
				, new string[] {  "BusinessEntityID",  }
				, SetChildrenHumanResourcesEmployeeDepartmentHistories);

						WithChildForParentValues(GetHumanResourcesEmployeePayHistoryReader()
				, new object[] {  entity.Id,  } 
				, new string[] {  "BusinessEntityID",  }
				, SetChildrenHumanResourcesEmployeePayHistories);

						WithChildForParentValues(GetHumanResourcesJobCandidateReader()
				, new object[] {  entity.Id,  } 
				, new string[] {  "BusinessEntityID",  }
				, SetChildrenHumanResourcesJobCandidates);

						WithChildForParentValues(GetPurchasingPurchaseOrderHeaderReader()
				, new object[] {  entity.Id,  } 
				, new string[] {  "EmployeeID",  }
				, SetChildrenPurchasingPurchaseOrderHeaders);

						WithChildForParentValues(GetSalesSalesPersonReader()
				, new object[] {  entity.Id,  } 
				, new string[] {  "Id",  }
				, SetChildrenSalesSalesPeople);

			
QueryResultForChildrenOnly(new List<HumanResourcesEmployee>() { entity });
			entity.Loaded = false;
			GetProductionDocumentReader().SetAllChildrenForExisting(entity.ProductionDocuments);
			GetHumanResourcesEmployeeDepartmentHistoryReader().SetAllChildrenForExisting(entity.HumanResourcesEmployeeDepartmentHistories);
			GetHumanResourcesEmployeePayHistoryReader().SetAllChildrenForExisting(entity.HumanResourcesEmployeePayHistories);
			GetHumanResourcesJobCandidateReader().SetAllChildrenForExisting(entity.HumanResourcesJobCandidates);
			GetPurchasingPurchaseOrderHeaderReader().SetAllChildrenForExisting(entity.PurchasingPurchaseOrderHeaders);
			GetSalesSalesPersonReader().SetAllChildrenForExisting(entity.SalesSalesPeople);
				
			entity.Loaded = true;
		}

		public override void SetAllChildrenForExisting(IList<HumanResourcesEmployee> entities)
        {
			ClearAllQueries();

            if (entities == null || entities.Count < 1)
                return;

			entities = entities.Where(e => e != null).ToList();

            if (entities.Count < 1)
                return;

			WithChildForParentsValues(GetProductionDocumentReader()
				, entities.Select(s => new object[] {  s.Id,  }).ToList() 
				, new string[] {  "Owner",  }
				, SetChildrenProductionDocuments);

			WithChildForParentsValues(GetHumanResourcesEmployeeDepartmentHistoryReader()
				, entities.Select(s => new object[] {  s.Id,  }).ToList() 
				, new string[] {  "BusinessEntityID",  }
				, SetChildrenHumanResourcesEmployeeDepartmentHistories);

			WithChildForParentsValues(GetHumanResourcesEmployeePayHistoryReader()
				, entities.Select(s => new object[] {  s.Id,  }).ToList() 
				, new string[] {  "BusinessEntityID",  }
				, SetChildrenHumanResourcesEmployeePayHistories);

			WithChildForParentsValues(GetHumanResourcesJobCandidateReader()
				, entities.Select(s => new object[] {  s.Id,  }).ToList() 
				, new string[] {  "BusinessEntityID",  }
				, SetChildrenHumanResourcesJobCandidates);

			WithChildForParentsValues(GetPurchasingPurchaseOrderHeaderReader()
				, entities.Select(s => new object[] {  s.Id,  }).ToList() 
				, new string[] {  "EmployeeID",  }
				, SetChildrenPurchasingPurchaseOrderHeaders);

			WithChildForParentsValues(GetSalesSalesPersonReader()
				, entities.Select(s => new object[] {  s.Id,  }).ToList() 
				, new string[] {  "Id",  }
				, SetChildrenSalesSalesPeople);

					
			QueryResultForChildrenOnly(entities);

			GetProductionDocumentReader().SetAllChildrenForExisting(entities.SelectMany(e => e.ProductionDocuments).ToList());
			GetHumanResourcesEmployeeDepartmentHistoryReader().SetAllChildrenForExisting(entities.SelectMany(e => e.HumanResourcesEmployeeDepartmentHistories).ToList());
			GetHumanResourcesEmployeePayHistoryReader().SetAllChildrenForExisting(entities.SelectMany(e => e.HumanResourcesEmployeePayHistories).ToList());
			GetHumanResourcesJobCandidateReader().SetAllChildrenForExisting(entities.SelectMany(e => e.HumanResourcesJobCandidates).ToList());
			GetPurchasingPurchaseOrderHeaderReader().SetAllChildrenForExisting(entities.SelectMany(e => e.PurchasingPurchaseOrderHeaders).ToList());
			GetSalesSalesPersonReader().SetAllChildrenForExisting(entities.SelectMany(e => e.SalesSalesPeople).ToList());
					
		}
    }
}
		