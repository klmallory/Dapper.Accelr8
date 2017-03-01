
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
    public class HumanResourcesEmployeeWriter : EntityWriter<int, HumanResourcesEmployee>
    {
        public HumanResourcesEmployeeWriter
			(HumanResourcesEmployeeTableInfo tableInfo
            , string connectionStringName
            , DapperExecuter executer
            , QueryBuilder queryBuilder
            , JoinBuilder joinBuilder
			, ILoc8 loc8r) 
            : base(tableInfo, connectionStringName, executer, queryBuilder, joinBuilder, loc8r)
		{

		}

		static IEntityWriter<int, PurchasingPurchaseOrderHeader> GetPurchasingPurchaseOrderHeaderWriter()
		{ return _locator.Resolve<IEntityWriter<int, PurchasingPurchaseOrderHeader>>(); }
		static IEntityWriter<int, ProductionDocument> GetProductionDocumentWriter()
		{ return _locator.Resolve<IEntityWriter<int, ProductionDocument>>(); }
		static IEntityWriter<int, HumanResourcesEmployeeDepartmentHistory> GetHumanResourcesEmployeeDepartmentHistoryWriter()
		{ return _locator.Resolve<IEntityWriter<int, HumanResourcesEmployeeDepartmentHistory>>(); }
		static IEntityWriter<int, HumanResourcesEmployeePayHistory> GetHumanResourcesEmployeePayHistoryWriter()
		{ return _locator.Resolve<IEntityWriter<int, HumanResourcesEmployeePayHistory>>(); }
		static IEntityWriter<int, SalesSalesPerson> GetSalesSalesPersonWriter()
		{ return _locator.Resolve<IEntityWriter<int, SalesSalesPerson>>(); }
		static IEntityWriter<int, HumanResourcesJobCandidate> GetHumanResourcesJobCandidateWriter()
		{ return _locator.Resolve<IEntityWriter<int, HumanResourcesJobCandidate>>(); }
		
		static IEntityWriter<int, PersonPerson> GetPersonPersonWriter()
		{ return _locator.Resolve<IEntityWriter<int, PersonPerson>>(); }
		
		/// <summary>
		/// Gets the Sql Parameters from the Entity and names them according to column, action, and batch task, and array count.
		/// </summary>
		/// <param name="results">Parameters for sql writes</param>
		/// <param name="row"></param>
        protected override IDictionary<string, object> GetParams(ActionType actionType, HumanResourcesEmployee entity, int taskIndex, ref int count)
        {
            var parms = new Dictionary<string, object>();
			
			foreach (var f in ColumnNames)
            {
                switch ((HumanResourcesEmployeeColumnNames)f.Key)
                {
                    
					case HumanResourcesEmployeeColumnNames.NationalIDNumber:
						parms.Add(GetParamName("NationalIDNumber", actionType, taskIndex, ref count), entity.NationalIDNumber);
						break;
					case HumanResourcesEmployeeColumnNames.LoginID:
						parms.Add(GetParamName("LoginID", actionType, taskIndex, ref count), entity.LoginID);
						break;
					case HumanResourcesEmployeeColumnNames.OrganizationNode:
						parms.Add(GetParamName("OrganizationNode", actionType, taskIndex, ref count), entity.OrganizationNode);
						break;
					case HumanResourcesEmployeeColumnNames.OrganizationLevel:
						parms.Add(GetParamName("OrganizationLevel", actionType, taskIndex, ref count), entity.OrganizationLevel);
						break;
					case HumanResourcesEmployeeColumnNames.JobTitle:
						parms.Add(GetParamName("JobTitle", actionType, taskIndex, ref count), entity.JobTitle);
						break;
					case HumanResourcesEmployeeColumnNames.BirthDate:
						parms.Add(GetParamName("BirthDate", actionType, taskIndex, ref count), entity.BirthDate);
						break;
					case HumanResourcesEmployeeColumnNames.MaritalStatus:
						parms.Add(GetParamName("MaritalStatus", actionType, taskIndex, ref count), entity.MaritalStatus);
						break;
					case HumanResourcesEmployeeColumnNames.Gender:
						parms.Add(GetParamName("Gender", actionType, taskIndex, ref count), entity.Gender);
						break;
					case HumanResourcesEmployeeColumnNames.HireDate:
						parms.Add(GetParamName("HireDate", actionType, taskIndex, ref count), entity.HireDate);
						break;
					case HumanResourcesEmployeeColumnNames.SalariedFlag:
						parms.Add(GetParamName("SalariedFlag", actionType, taskIndex, ref count), entity.SalariedFlag);
						break;
					case HumanResourcesEmployeeColumnNames.VacationHours:
						parms.Add(GetParamName("VacationHours", actionType, taskIndex, ref count), entity.VacationHours);
						break;
					case HumanResourcesEmployeeColumnNames.SickLeaveHours:
						parms.Add(GetParamName("SickLeaveHours", actionType, taskIndex, ref count), entity.SickLeaveHours);
						break;
					case HumanResourcesEmployeeColumnNames.CurrentFlag:
						parms.Add(GetParamName("CurrentFlag", actionType, taskIndex, ref count), entity.CurrentFlag);
						break;
					case HumanResourcesEmployeeColumnNames.rowguid:
						parms.Add(GetParamName("rowguid", actionType, taskIndex, ref count), entity.rowguid);
						break;
					case HumanResourcesEmployeeColumnNames.ModifiedDate:
						parms.Add(GetParamName("ModifiedDate", actionType, taskIndex, ref count), entity.ModifiedDate);
						break;
				}
			}

			return parms;
        }


		protected override void CascadeRelations(HumanResourcesEmployee entity, ScriptContext context)
        {
            if (entity == null)
                return;

			//From Foreign Key FK_PurchaseOrderHeader_Employee_EmployeeID
			var purchasingPurchaseOrderHeader105 = GetPurchasingPurchaseOrderHeaderWriter();
			if (_cascades.Contains(HumanResourcesEmployeeCascadeNames.purchasing.purchaseorderheader.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.PurchasingPurchaseOrderHeaders)
					Cascade(purchasingPurchaseOrderHeader105, item, context);

			if (purchasingPurchaseOrderHeader105.Count > 0)
				WithChild(purchasingPurchaseOrderHeader105, entity);

			//From Foreign Key FK_Document_Employee_Owner
			var productionDocument106 = GetProductionDocumentWriter();
			if (_cascades.Contains(HumanResourcesEmployeeCascadeNames.production.document.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.ProductionDocuments)
					Cascade(productionDocument106, item, context);

			if (productionDocument106.Count > 0)
				WithChild(productionDocument106, entity);

			//From Foreign Key FK_EmployeeDepartmentHistory_Employee_BusinessEntityID
			var humanResourcesEmployeeDepartmentHistory107 = GetHumanResourcesEmployeeDepartmentHistoryWriter();
			if (_cascades.Contains(HumanResourcesEmployeeCascadeNames.humanresources.employeedepartmenthistory.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.HumanResourcesEmployeeDepartmentHistories)
					Cascade(humanResourcesEmployeeDepartmentHistory107, item, context);

			if (humanResourcesEmployeeDepartmentHistory107.Count > 0)
				WithChild(humanResourcesEmployeeDepartmentHistory107, entity);

			//From Foreign Key FK_EmployeePayHistory_Employee_BusinessEntityID
			var humanResourcesEmployeePayHistory108 = GetHumanResourcesEmployeePayHistoryWriter();
			if (_cascades.Contains(HumanResourcesEmployeeCascadeNames.humanresources.employeepayhistory.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.HumanResourcesEmployeePayHistories)
					Cascade(humanResourcesEmployeePayHistory108, item, context);

			if (humanResourcesEmployeePayHistory108.Count > 0)
				WithChild(humanResourcesEmployeePayHistory108, entity);

			//From Foreign Key FK_SalesPerson_Employee_BusinessEntityID
			var salesSalesPerson109 = GetSalesSalesPersonWriter();
			if (_cascades.Contains(HumanResourcesEmployeeCascadeNames.sales.salesperson.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.SalesSalesPeople)
					Cascade(salesSalesPerson109, item, context);

			if (salesSalesPerson109.Count > 0)
				WithChild(salesSalesPerson109, entity);

			//From Foreign Key FK_JobCandidate_Employee_BusinessEntityID
			var humanResourcesJobCandidate110 = GetHumanResourcesJobCandidateWriter();
			if (_cascades.Contains(HumanResourcesEmployeeCascadeNames.humanresources.jobcandidate.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.HumanResourcesJobCandidates)
					Cascade(humanResourcesJobCandidate110, item, context);

			if (humanResourcesJobCandidate110.Count > 0)
				WithChild(humanResourcesJobCandidate110, entity);

		
		
			//From Foreign Key FK_Employee_Person_BusinessEntityID
			var personPerson111 = GetPersonPersonWriter();
		if ((_cascades.Contains(HumanResourcesEmployeeCascadeNames.personperson.ToString()) || _cascades.Contains("all")) && entity.PersonPerson != null)
			if (Cascade(personPerson111, entity.PersonPerson, context))
				WithParent(personPerson111, entity);

				}

		protected override void UpdateIdsFromReferences(IList<string> cascades, HumanResourcesEmployee entity)
        {
            if (entity == null)
                return;

			//From Foreign Key FK_PurchaseOrderHeader_Employee_EmployeeID
			if (entity.PurchasingPurchaseOrderHeaders != null && entity.PurchasingPurchaseOrderHeaders.Count > 0)
				foreach (var rel in entity.PurchasingPurchaseOrderHeaders)
					rel.PurchasingPurchaseOrderHeader = entity.Id;

			//From Foreign Key FK_Document_Employee_Owner
			if (entity.ProductionDocuments != null && entity.ProductionDocuments.Count > 0)
				foreach (var rel in entity.ProductionDocuments)
					rel.ProductionDocument = entity.Id;

			//From Foreign Key FK_EmployeeDepartmentHistory_Employee_BusinessEntityID
			if (entity.HumanResourcesEmployeeDepartmentHistories != null && entity.HumanResourcesEmployeeDepartmentHistories.Count > 0)
				foreach (var rel in entity.HumanResourcesEmployeeDepartmentHistories)
					rel.HumanResourcesEmployeeDepartmentHistory = entity.Id;

			//From Foreign Key FK_EmployeePayHistory_Employee_BusinessEntityID
			if (entity.HumanResourcesEmployeePayHistories != null && entity.HumanResourcesEmployeePayHistories.Count > 0)
				foreach (var rel in entity.HumanResourcesEmployeePayHistories)
					rel.HumanResourcesEmployeePayHistory = entity.Id;

			//From Foreign Key FK_SalesPerson_Employee_BusinessEntityID
			if (entity.SalesSalesPeople != null && entity.SalesSalesPeople.Count > 0)
				foreach (var rel in entity.SalesSalesPeople)
					rel.SalesSalesPerson = entity.Id;

			//From Foreign Key FK_JobCandidate_Employee_BusinessEntityID
			if (entity.HumanResourcesJobCandidates != null && entity.HumanResourcesJobCandidates.Count > 0)
				foreach (var rel in entity.HumanResourcesJobCandidates)
					rel.HumanResourcesJobCandidate = entity.Id;

				
			//From Foreign Key FK_Employee_Person_BusinessEntityID
			if (entity.PersonPerson != null)
				entity.HumanResourcesEmployee = entity.PersonPerson.Id;

		}

		protected override void RemoveRelations(HumanResourcesEmployee entity, ScriptContext context)
        {
					//From Foreign Key FK_PurchaseOrderHeader_Employee_EmployeeID
			var purchasingPurchaseOrderHeader119 = GetPurchasingPurchaseOrderHeaderWriter();
			if (_cascades.Contains(HumanResourcesEmployeeCascadeNames.purchasing.purchaseorderheader.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.PurchasingPurchaseOrderHeaders)
					CascadeDelete(purchasingPurchaseOrderHeader119, item, context);

			if (purchasingPurchaseOrderHeader119.Count > 0)
				WithChild(purchasingPurchaseOrderHeader119, entity);

					//From Foreign Key FK_Document_Employee_Owner
			var productionDocument120 = GetProductionDocumentWriter();
			if (_cascades.Contains(HumanResourcesEmployeeCascadeNames.production.document.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.ProductionDocuments)
					CascadeDelete(productionDocument120, item, context);

			if (productionDocument120.Count > 0)
				WithChild(productionDocument120, entity);

					//From Foreign Key FK_EmployeeDepartmentHistory_Employee_BusinessEntityID
			var humanResourcesEmployeeDepartmentHistory121 = GetHumanResourcesEmployeeDepartmentHistoryWriter();
			if (_cascades.Contains(HumanResourcesEmployeeCascadeNames.humanresources.employeedepartmenthistory.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.HumanResourcesEmployeeDepartmentHistories)
					CascadeDelete(humanResourcesEmployeeDepartmentHistory121, item, context);

			if (humanResourcesEmployeeDepartmentHistory121.Count > 0)
				WithChild(humanResourcesEmployeeDepartmentHistory121, entity);

					//From Foreign Key FK_EmployeePayHistory_Employee_BusinessEntityID
			var humanResourcesEmployeePayHistory122 = GetHumanResourcesEmployeePayHistoryWriter();
			if (_cascades.Contains(HumanResourcesEmployeeCascadeNames.humanresources.employeepayhistory.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.HumanResourcesEmployeePayHistories)
					CascadeDelete(humanResourcesEmployeePayHistory122, item, context);

			if (humanResourcesEmployeePayHistory122.Count > 0)
				WithChild(humanResourcesEmployeePayHistory122, entity);

					//From Foreign Key FK_SalesPerson_Employee_BusinessEntityID
			var salesSalesPerson123 = GetSalesSalesPersonWriter();
			if (_cascades.Contains(HumanResourcesEmployeeCascadeNames.sales.salesperson.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.SalesSalesPeople)
					CascadeDelete(salesSalesPerson123, item, context);

			if (salesSalesPerson123.Count > 0)
				WithChild(salesSalesPerson123, entity);

					//From Foreign Key FK_JobCandidate_Employee_BusinessEntityID
			var humanResourcesJobCandidate124 = GetHumanResourcesJobCandidateWriter();
			if (_cascades.Contains(HumanResourcesEmployeeCascadeNames.humanresources.jobcandidate.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.HumanResourcesJobCandidates)
					CascadeDelete(humanResourcesJobCandidate124, item, context);

			if (humanResourcesJobCandidate124.Count > 0)
				WithChild(humanResourcesJobCandidate124, entity);

				}
	}
}
		