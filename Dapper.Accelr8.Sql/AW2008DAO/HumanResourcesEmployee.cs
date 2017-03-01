
using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Text;

using Dapper.Accelr8.Sql.AW2008DAO;
using Dapper;
using Dapper.Accelr8.Domain;
using System.Data.SqlTypes;

namespace Dapper.Accelr8.Sql.AW2008DAO
{
	public partial class HumanResourcesEmployee : Dapper.Accelr8.Repo.Domain.BaseEntity<int>
	{
			public HumanResourcesEmployee()
		{			
			IsDirty = false; 
			_purchasingPurchaseOrderHeaders = new List<PurchasingPurchaseOrderHeader>();
		_productionDocuments = new List<ProductionDocument>();
		_humanResourcesEmployeeDepartmentHistories = new List<HumanResourcesEmployeeDepartmentHistory>();
		_humanResourcesEmployeePayHistories = new List<HumanResourcesEmployeePayHistory>();
		_salesSalesPeople = new List<SalesSalesPerson>();
		_humanResourcesJobCandidates = new List<HumanResourcesJobCandidate>();
		_birthDate = (DateTime)SqlDateTime.MinValue;
		_hireDate = (DateTime)SqlDateTime.MinValue;
		_modifiedDate = (DateTime)SqlDateTime.MinValue;
		}


		
		protected string _nationalIDNumber;
		public string NationalIDNumber 
		{ 
			get { return _nationalIDNumber; }
			set 
			{ 
				_nationalIDNumber = value;  
				IsDirty = true;
			}
		} 
			
		protected string _loginID;
		public string LoginID 
		{ 
			get { return _loginID; }
			set 
			{ 
				_loginID = value;  
				IsDirty = true;
			}
		} 
			
		protected Microsoft.SqlServer.Types.SqlHierarchyId? _organizationNode;
		public Microsoft.SqlServer.Types.SqlHierarchyId? OrganizationNode 
		{ 
			get { return _organizationNode; }
			set 
			{ 
				_organizationNode = value;  
				IsDirty = true;
			}
		} 
			
		protected short? _organizationLevel;
		public short? OrganizationLevel 
		{ 
			get { return _organizationLevel; }
			set 
			{ 
				_organizationLevel = value;  
				IsDirty = true;
			}
		} 
			
		protected string _jobTitle;
		public string JobTitle 
		{ 
			get { return _jobTitle; }
			set 
			{ 
				_jobTitle = value;  
				IsDirty = true;
			}
		} 
			
		protected DateTime _birthDate;
		public DateTime BirthDate 
		{ 
			get { return _birthDate; }
			set 
			{ 
				_birthDate = value;  
				IsDirty = true;
			}
		} 
			
		protected string _maritalStatus;
		public string MaritalStatus 
		{ 
			get { return _maritalStatus; }
			set 
			{ 
				_maritalStatus = value;  
				IsDirty = true;
			}
		} 
			
		protected string _gender;
		public string Gender 
		{ 
			get { return _gender; }
			set 
			{ 
				_gender = value;  
				IsDirty = true;
			}
		} 
			
		protected DateTime _hireDate;
		public DateTime HireDate 
		{ 
			get { return _hireDate; }
			set 
			{ 
				_hireDate = value;  
				IsDirty = true;
			}
		} 
			
		protected object _salariedFlag;
		public object SalariedFlag 
		{ 
			get { return _salariedFlag; }
			set 
			{ 
				_salariedFlag = value;  
				IsDirty = true;
			}
		} 
			
		protected short _vacationHours;
		public short VacationHours 
		{ 
			get { return _vacationHours; }
			set 
			{ 
				_vacationHours = value;  
				IsDirty = true;
			}
		} 
			
		protected short _sickLeaveHours;
		public short SickLeaveHours 
		{ 
			get { return _sickLeaveHours; }
			set 
			{ 
				_sickLeaveHours = value;  
				IsDirty = true;
			}
		} 
			
		protected object _currentFlag;
		public object CurrentFlag 
		{ 
			get { return _currentFlag; }
			set 
			{ 
				_currentFlag = value;  
				IsDirty = true;
			}
		} 
			
		protected Guid _rowguid;
		public Guid rowguid 
		{ 
			get { return _rowguid; }
			set 
			{ 
				_rowguid = value;  
				IsDirty = true;
			}
		} 
			
		protected DateTime _modifiedDate;
		public DateTime ModifiedDate 
		{ 
			get { return _modifiedDate; }
			set 
			{ 
				_modifiedDate = value;  
				IsDirty = true;
			}
		} 
		 
	//From Foreign Key FK_Employee_Person_BusinessEntityID	
		protected PersonPerson _personPerson;
		public virtual PersonPerson PersonPerson 
		{ 
			get { return _personPerson; }
			set 
			{ 
				_personPerson = value;  
				IsDirty = true;
			}
		} 
		 
	//From Foreign Key FK_PurchaseOrderHeader_Employee_EmployeeID	
		protected IList<PurchasingPurchaseOrderHeader> _purchasingPurchaseOrderHeaders;
		public virtual IList<PurchasingPurchaseOrderHeader> PurchasingPurchaseOrderHeaders 
		{ 
			get { return _purchasingPurchaseOrderHeaders; }
			set 
			{ 
				_purchasingPurchaseOrderHeaders = value;  
				IsDirty = true;
			}
		} 
			 
	//From Foreign Key FK_Document_Employee_Owner	
		protected IList<ProductionDocument> _productionDocuments;
		public virtual IList<ProductionDocument> ProductionDocuments 
		{ 
			get { return _productionDocuments; }
			set 
			{ 
				_productionDocuments = value;  
				IsDirty = true;
			}
		} 
			 
	//From Foreign Key FK_EmployeeDepartmentHistory_Employee_BusinessEntityID	
		protected IList<HumanResourcesEmployeeDepartmentHistory> _humanResourcesEmployeeDepartmentHistories;
		public virtual IList<HumanResourcesEmployeeDepartmentHistory> HumanResourcesEmployeeDepartmentHistories 
		{ 
			get { return _humanResourcesEmployeeDepartmentHistories; }
			set 
			{ 
				_humanResourcesEmployeeDepartmentHistories = value;  
				IsDirty = true;
			}
		} 
			 
	//From Foreign Key FK_EmployeePayHistory_Employee_BusinessEntityID	
		protected IList<HumanResourcesEmployeePayHistory> _humanResourcesEmployeePayHistories;
		public virtual IList<HumanResourcesEmployeePayHistory> HumanResourcesEmployeePayHistories 
		{ 
			get { return _humanResourcesEmployeePayHistories; }
			set 
			{ 
				_humanResourcesEmployeePayHistories = value;  
				IsDirty = true;
			}
		} 
			 
	//From Foreign Key FK_SalesPerson_Employee_BusinessEntityID	
		protected IList<SalesSalesPerson> _salesSalesPeople;
		public virtual IList<SalesSalesPerson> SalesSalesPeople 
		{ 
			get { return _salesSalesPeople; }
			set 
			{ 
				_salesSalesPeople = value;  
				IsDirty = true;
			}
		} 
			 
	//From Foreign Key FK_JobCandidate_Employee_BusinessEntityID	
		protected IList<HumanResourcesJobCandidate> _humanResourcesJobCandidates;
		public virtual IList<HumanResourcesJobCandidate> HumanResourcesJobCandidates 
		{ 
			get { return _humanResourcesJobCandidates; }
			set 
			{ 
				_humanResourcesJobCandidates = value;  
				IsDirty = true;
			}
		} 
					}
}

		