
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
        { }

		//Child Count 6
		//Parent Count 1
		static IEntityReader<int , PurchasingPurchaseOrderHeader> _purchasingPurchaseOrderHeaderReader;
		protected static IEntityReader<int , PurchasingPurchaseOrderHeader> GetPurchasingPurchaseOrderHeaderReader()
		{
			return _locator.Resolve<IEntityReader<int , PurchasingPurchaseOrderHeader>>();
		}

		static IEntityReader<int , ProductionDocument> _productionDocumentReader;
		protected static IEntityReader<int , ProductionDocument> GetProductionDocumentReader()
		{
			return _locator.Resolve<IEntityReader<int , ProductionDocument>>();
		}

		static IEntityReader<int , HumanResourcesEmployeeDepartmentHistory> _humanResourcesEmployeeDepartmentHistoryReader;
		protected static IEntityReader<int , HumanResourcesEmployeeDepartmentHistory> GetHumanResourcesEmployeeDepartmentHistoryReader()
		{
			return _locator.Resolve<IEntityReader<int , HumanResourcesEmployeeDepartmentHistory>>();
		}

		static IEntityReader<int , HumanResourcesEmployeePayHistory> _humanResourcesEmployeePayHistoryReader;
		protected static IEntityReader<int , HumanResourcesEmployeePayHistory> GetHumanResourcesEmployeePayHistoryReader()
		{
			return _locator.Resolve<IEntityReader<int , HumanResourcesEmployeePayHistory>>();
		}

		static IEntityReader<int , SalesSalesPerson> _salesSalesPersonReader;
		protected static IEntityReader<int , SalesSalesPerson> GetSalesSalesPersonReader()
		{
			return _locator.Resolve<IEntityReader<int , SalesSalesPerson>>();
		}

		static IEntityReader<int , HumanResourcesJobCandidate> _humanResourcesJobCandidateReader;
		protected static IEntityReader<int , HumanResourcesJobCandidate> GetHumanResourcesJobCandidateReader()
		{
			return _locator.Resolve<IEntityReader<int , HumanResourcesJobCandidate>>();
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
				r.PurchasingPurchaseOrderHeaders = typedChildren.Where(b => b.PurchasingPurchaseOrderHeader == r.Id).ToList();
				r.PurchasingPurchaseOrderHeaders.ToList().ForEach(b => { b.Loaded = false; b.HumanResourcesEmployee = r; b.Loaded = true; });
				r.Loaded = true;
			}
		}

		/// <summary>
		/// Sets the children of type ProductionDocument on the parent on ProductionDocuments.
		/// From foriegn key FK_Document_Employee_Owner
		/// </summary>
		/// <param name="results"></param>
		/// <param name="children"></param>
		public void SetChildrenProductionDocuments(IList<HumanResourcesEmployee> results, IList<object> children)
		{
			//Child Id Type: int
			//Child Type: ProductionDocument

			if (results == null || results.Count < 1 || children == null || children.Count < 1)
				return;

			var typedChildren = children.OfType<ProductionDocument>();

			foreach (var r in results)
			{
				if (r == null)
					continue;
				r.Loaded = false;
				r.ProductionDocuments = typedChildren.Where(b => b.ProductionDocument == r.Id).ToList();
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
			//Child Id Type: int
			//Child Type: HumanResourcesEmployeeDepartmentHistory

			if (results == null || results.Count < 1 || children == null || children.Count < 1)
				return;

			var typedChildren = children.OfType<HumanResourcesEmployeeDepartmentHistory>();

			foreach (var r in results)
			{
				if (r == null)
					continue;
				r.Loaded = false;
				r.HumanResourcesEmployeeDepartmentHistories = typedChildren.Where(b => b.HumanResourcesEmployeeDepartmentHistory == r.Id).ToList();
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
			//Child Id Type: int
			//Child Type: HumanResourcesEmployeePayHistory

			if (results == null || results.Count < 1 || children == null || children.Count < 1)
				return;

			var typedChildren = children.OfType<HumanResourcesEmployeePayHistory>();

			foreach (var r in results)
			{
				if (r == null)
					continue;
				r.Loaded = false;
				r.HumanResourcesEmployeePayHistories = typedChildren.Where(b => b.HumanResourcesEmployeePayHistory == r.Id).ToList();
				r.HumanResourcesEmployeePayHistories.ToList().ForEach(b => { b.Loaded = false; b.HumanResourcesEmployee = r; b.Loaded = true; });
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
				r.SalesSalesPeople = typedChildren.Where(b => b.SalesSalesPerson == r.Id).ToList();
				r.SalesSalesPeople.ToList().ForEach(b => { b.Loaded = false; b.HumanResourcesEmployee = r; b.Loaded = true; });
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
				r.HumanResourcesJobCandidates = typedChildren.Where(b => b.HumanResourcesJobCandidate == r.Id).ToList();
				r.HumanResourcesJobCandidates.ToList().ForEach(b => { b.Loaded = false; b.HumanResourcesEmployee = r; b.Loaded = true; });
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

			domain.Id = GetRowData<int>(dataRow, IdColumn);
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
        public override IEntityReader<int, HumanResourcesEmployee> WithAllChildrenForId(int id)
        {
			base.WithAllChildrenForId(id);

			
			WithChildForParentId(GetPurchasingPurchaseOrderHeaderReader(), id, IdColumn, SetChildrenPurchasingPurchaseOrderHeaders);
			
			WithChildForParentId(GetProductionDocumentReader(), id, IdColumn, SetChildrenProductionDocuments);
			
			WithChildForParentId(GetHumanResourcesEmployeeDepartmentHistoryReader(), id, IdColumn, SetChildrenHumanResourcesEmployeeDepartmentHistories);
			
			WithChildForParentId(GetHumanResourcesEmployeePayHistoryReader(), id, IdColumn, SetChildrenHumanResourcesEmployeePayHistories);
			
			WithChildForParentId(GetSalesSalesPersonReader(), id, IdColumn, SetChildrenSalesSalesPeople);
			
			WithChildForParentId(GetHumanResourcesJobCandidateReader(), id, IdColumn, SetChildrenHumanResourcesJobCandidates);
			
            return this;
        }

        public override void SetAllChildrenForExisting(HumanResourcesEmployee entity)
        {
			ClearAllQueries();

            if (entity == null)
                return;

			WithChildForParentId(GetPurchasingPurchaseOrderHeaderReader(), entity.Id
				, PurchasingPurchaseOrderHeaderColumnNames.EmployeeID.ToString()
				, SetChildrenPurchasingPurchaseOrderHeaders);

			WithChildForParentId(GetProductionDocumentReader(), entity.Id
				, ProductionDocumentColumnNames.Owner.ToString()
				, SetChildrenProductionDocuments);

			WithChildForParentId(GetHumanResourcesEmployeeDepartmentHistoryReader(), entity.Id
				, HumanResourcesEmployeeDepartmentHistoryColumnNames.BusinessEntityID.ToString()
				, SetChildrenHumanResourcesEmployeeDepartmentHistories);

			WithChildForParentId(GetHumanResourcesEmployeePayHistoryReader(), entity.Id
				, HumanResourcesEmployeePayHistoryColumnNames.BusinessEntityID.ToString()
				, SetChildrenHumanResourcesEmployeePayHistories);

			WithChildForParentId(GetSalesSalesPersonReader(), entity.Id
				, SalesSalesPersonColumnNames.BusinessEntityID.ToString()
				, SetChildrenSalesSalesPeople);

			WithChildForParentId(GetHumanResourcesJobCandidateReader(), entity.Id
				, HumanResourcesJobCandidateColumnNames.BusinessEntityID.ToString()
				, SetChildrenHumanResourcesJobCandidates);

			QueryResultForChildrenOnly(new List<HumanResourcesEmployee>() { entity });
			entity.Loaded = false;
			GetPurchasingPurchaseOrderHeaderReader().SetAllChildrenForExisting(entity.PurchasingPurchaseOrderHeaders);
			GetProductionDocumentReader().SetAllChildrenForExisting(entity.ProductionDocuments);
			GetHumanResourcesEmployeeDepartmentHistoryReader().SetAllChildrenForExisting(entity.HumanResourcesEmployeeDepartmentHistories);
			GetHumanResourcesEmployeePayHistoryReader().SetAllChildrenForExisting(entity.HumanResourcesEmployeePayHistories);
			GetSalesSalesPersonReader().SetAllChildrenForExisting(entity.SalesSalesPeople);
			GetHumanResourcesJobCandidateReader().SetAllChildrenForExisting(entity.HumanResourcesJobCandidates);
				
			entity.Loaded = true;
		}

		public override void SetAllChildrenForExisting(IList<HumanResourcesEmployee> entities)
        {
			ClearAllQueries();

			entities = entities.Where(e => e != null).ToList();

            if (entities == null || entities.Count < 1)
                return;

			WithChildForParentIds(GetPurchasingPurchaseOrderHeaderReader()
				, entities
				.Select(s => s.Id)
				.ToArray(), PurchasingPurchaseOrderHeaderColumnNames.EmployeeID.ToString()
				, SetChildrenPurchasingPurchaseOrderHeaders);

			WithChildForParentIds(GetProductionDocumentReader()
				, entities
				.Select(s => s.Id)
				.ToArray(), ProductionDocumentColumnNames.Owner.ToString()
				, SetChildrenProductionDocuments);

			WithChildForParentIds(GetHumanResourcesEmployeeDepartmentHistoryReader()
				, entities
				.Select(s => s.Id)
				.ToArray(), HumanResourcesEmployeeDepartmentHistoryColumnNames.BusinessEntityID.ToString()
				, SetChildrenHumanResourcesEmployeeDepartmentHistories);

			WithChildForParentIds(GetHumanResourcesEmployeePayHistoryReader()
				, entities
				.Select(s => s.Id)
				.ToArray(), HumanResourcesEmployeePayHistoryColumnNames.BusinessEntityID.ToString()
				, SetChildrenHumanResourcesEmployeePayHistories);

			WithChildForParentIds(GetSalesSalesPersonReader()
				, entities
				.Select(s => s.Id)
				.ToArray(), SalesSalesPersonColumnNames.BusinessEntityID.ToString()
				, SetChildrenSalesSalesPeople);

			WithChildForParentIds(GetHumanResourcesJobCandidateReader()
				, entities
				.Select(s => s.Id)
				.ToArray(), HumanResourcesJobCandidateColumnNames.BusinessEntityID.ToString()
				, SetChildrenHumanResourcesJobCandidates);

					
			QueryResultForChildrenOnly(entities);

			GetPurchasingPurchaseOrderHeaderReader().SetAllChildrenForExisting(entities.SelectMany(e => e.PurchasingPurchaseOrderHeaders).ToList());
			GetProductionDocumentReader().SetAllChildrenForExisting(entities.SelectMany(e => e.ProductionDocuments).ToList());
			GetHumanResourcesEmployeeDepartmentHistoryReader().SetAllChildrenForExisting(entities.SelectMany(e => e.HumanResourcesEmployeeDepartmentHistories).ToList());
			GetHumanResourcesEmployeePayHistoryReader().SetAllChildrenForExisting(entities.SelectMany(e => e.HumanResourcesEmployeePayHistories).ToList());
			GetSalesSalesPersonReader().SetAllChildrenForExisting(entities.SelectMany(e => e.SalesSalesPeople).ToList());
			GetHumanResourcesJobCandidateReader().SetAllChildrenForExisting(entities.SelectMany(e => e.HumanResourcesJobCandidates).ToList());
					
		}
    }
}
		