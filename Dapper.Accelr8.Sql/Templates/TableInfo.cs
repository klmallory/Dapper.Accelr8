


using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Text;

using Dapper.Accelr8.Domain;
using Dapper.Accelr8.TableInfos;
using Dapper;
using Dapper.Accelr8.Sql;
using Dapper.Accelr8.Repo;
using Dapper.Accelr8.Repo.Parameters;
using Dapper.Accelr8.Repo.Contracts.Readers;

namespace Dapper.Accelr8.TableInfos
{
	public enum AdminSettingColumnNames
	{	
		AdminSettingsId, 	
		Name, 	
		Type, 	
		Description, 	
		Value, 	
	}

	public enum AdminSettingCascadeNames
	{	
		
	}

	public class AdminSettingTableInfo : Dapper.Accelr8.Sql.TableInfo
	{
		public AdminSettingTableInfo(IAccelr8Locator locator) : base(locator)
		{
			UniqueId = true;
			IdColumn = AdminSettingColumnNames.AdminSettingsId.ToString();
			TableName = "AdminSettings";
			TableAlias = "adminsetting";
			ColumnNames = Enum.GetNames(typeof(AdminSettingColumnNames));

			Joins = new JoinInfo[] {
						};
		}
	}
}
		
using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Text;

using Dapper.Accelr8.Domain;
using Dapper.Accelr8.TableInfos;
using Dapper;
using Dapper.Accelr8.Sql;
using Dapper.Accelr8.Repo;
using Dapper.Accelr8.Repo.Parameters;
using Dapper.Accelr8.Repo.Contracts.Readers;

namespace Dapper.Accelr8.TableInfos
{
	public enum AgencyColumnNames
	{	
		AgencyId, 	
		Name, 	
		ORI, 	
		CMABIS, 	
		AgencySpecId, 	
	}

	public enum AgencyCascadeNames
	{	
		workspace, 	
		submission, 	
		agencyendpoint, 	
		
		agencyspec, 	
	}

	public class AgencyTableInfo : Dapper.Accelr8.Sql.TableInfo
	{
		public AgencyTableInfo(IAccelr8Locator locator) : base(locator)
		{
			UniqueId = true;
			IdColumn = AgencyColumnNames.AgencyId.ToString();
			TableName = "Agencies";
			TableAlias = "agency";
			ColumnNames = Enum.GetNames(typeof(AgencyColumnNames));

			Joins = new JoinInfo[] {
						//For Key FK_Agencies_AgencySpecs_AgencySpecId
			new JoinInfo() {
			Reader = new Func<IEntityReader>(() => GetReader(typeof(int), typeof(AgencySpec))),
			TableName = "AgencySpecs",
			Alias = TableAlias + "_" + "agencyspec",
			Outer = false,
			Load = (entity, row) =>
				{ 
					var reader = GetReader(typeof(int), typeof(AgencySpec));
					var st = (entity as Agency);

					if (st == null || row == null)
						return st;

					if (row.Id == default(int))
						return st;

					st.AgencySpec = reader.LoadEntityObject(row);

					return st;
				},
			JoinQuery = new JoinQueryElement[]
			{
				new JoinQueryElement() 
				{ 
					JoinField = AgencySpecColumnNames.AgencySpecId.ToString(),
					Operator = Operator.Equals,
					ParentField = AgencyColumnNames.AgencySpecId.ToString(),
					ParentTableAlias = TableAlias
				}
			} },
						};
		}
	}
}
		
using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Text;

using Dapper.Accelr8.Domain;
using Dapper.Accelr8.TableInfos;
using Dapper;
using Dapper.Accelr8.Sql;
using Dapper.Accelr8.Repo;
using Dapper.Accelr8.Repo.Parameters;
using Dapper.Accelr8.Repo.Contracts.Readers;

namespace Dapper.Accelr8.TableInfos
{
	public enum AgencyEndpointColumnNames
	{	
		AgencyEndpointId, 	
		AgencyId, 	
		EndpointId, 	
	}

	public enum AgencyEndpointCascadeNames
	{	
		
		agency, 	
		endpoint, 	
	}

	public class AgencyEndpointTableInfo : Dapper.Accelr8.Sql.TableInfo
	{
		public AgencyEndpointTableInfo(IAccelr8Locator locator) : base(locator)
		{
			UniqueId = true;
			IdColumn = AgencyEndpointColumnNames.AgencyEndpointId.ToString();
			TableName = "AgencyEndpoints";
			TableAlias = "agencyendpoint";
			ColumnNames = Enum.GetNames(typeof(AgencyEndpointColumnNames));

			Joins = new JoinInfo[] {
						//For Key FK_AgencyEndpoints_Agencies
			new JoinInfo() {
			Reader = new Func<IEntityReader>(() => GetReader(typeof(int), typeof(Agency))),
			TableName = "Agencies",
			Alias = TableAlias + "_" + "agency",
			Outer = false,
			Load = (entity, row) =>
				{ 
					var reader = GetReader(typeof(int), typeof(Agency));
					var st = (entity as AgencyEndpoint);

					if (st == null || row == null)
						return st;

					if (row.Id == default(int))
						return st;

					st.Agency = reader.LoadEntityObject(row);

					return st;
				},
			JoinQuery = new JoinQueryElement[]
			{
				new JoinQueryElement() 
				{ 
					JoinField = AgencyColumnNames.AgencyId.ToString(),
					Operator = Operator.Equals,
					ParentField = AgencyEndpointColumnNames.AgencyId.ToString(),
					ParentTableAlias = TableAlias
				}
			} },
						//For Key FK_AgencyEndpoints_Endpoints
			new JoinInfo() {
			Reader = new Func<IEntityReader>(() => GetReader(typeof(int), typeof(Endpoint))),
			TableName = "Endpoints",
			Alias = TableAlias + "_" + "endpoint",
			Outer = false,
			Load = (entity, row) =>
				{ 
					var reader = GetReader(typeof(int), typeof(Endpoint));
					var st = (entity as AgencyEndpoint);

					if (st == null || row == null)
						return st;

					if (row.Id == default(int))
						return st;

					st.Endpoint = reader.LoadEntityObject(row);

					return st;
				},
			JoinQuery = new JoinQueryElement[]
			{
				new JoinQueryElement() 
				{ 
					JoinField = EndpointColumnNames.EndpointId.ToString(),
					Operator = Operator.Equals,
					ParentField = AgencyEndpointColumnNames.EndpointId.ToString(),
					ParentTableAlias = TableAlias
				}
			} },
						};
		}
	}
}
		
using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Text;

using Dapper.Accelr8.Domain;
using Dapper.Accelr8.TableInfos;
using Dapper;
using Dapper.Accelr8.Sql;
using Dapper.Accelr8.Repo;
using Dapper.Accelr8.Repo.Parameters;
using Dapper.Accelr8.Repo.Contracts.Readers;

namespace Dapper.Accelr8.TableInfos
{
	public enum AgencySpecColumnNames
	{	
		AgencySpecId, 	
		SpecKey, 	
		Name, 	
		FileDefinitionPath, 	
	}

	public enum AgencySpecCascadeNames
	{	
		agency, 	
		transaction, 	
		
	}

	public class AgencySpecTableInfo : Dapper.Accelr8.Sql.TableInfo
	{
		public AgencySpecTableInfo(IAccelr8Locator locator) : base(locator)
		{
			UniqueId = true;
			IdColumn = AgencySpecColumnNames.AgencySpecId.ToString();
			TableName = "AgencySpecs";
			TableAlias = "agencyspec";
			ColumnNames = Enum.GetNames(typeof(AgencySpecColumnNames));

			Joins = new JoinInfo[] {
						};
		}
	}
}
		
using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Text;

using Dapper.Accelr8.Domain;
using Dapper.Accelr8.TableInfos;
using Dapper;
using Dapper.Accelr8.Sql;
using Dapper.Accelr8.Repo;
using Dapper.Accelr8.Repo.Parameters;
using Dapper.Accelr8.Repo.Contracts.Readers;

namespace Dapper.Accelr8.TableInfos
{
	public enum ApplicationColumnNames
	{	
		ApplicationId, 	
		Name, 	
		ApplicationKey, 	
		Description, 	
	}

	public enum ApplicationCascadeNames
	{	
		user, 	
		
	}

	public class ApplicationTableInfo : Dapper.Accelr8.Sql.TableInfo
	{
		public ApplicationTableInfo(IAccelr8Locator locator) : base(locator)
		{
			UniqueId = true;
			IdColumn = ApplicationColumnNames.ApplicationId.ToString();
			TableName = "Applications";
			TableAlias = "application";
			ColumnNames = Enum.GetNames(typeof(ApplicationColumnNames));

			Joins = new JoinInfo[] {
						};
		}
	}
}
		
using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Text;

using Dapper.Accelr8.Domain;
using Dapper.Accelr8.TableInfos;
using Dapper;
using Dapper.Accelr8.Sql;
using Dapper.Accelr8.Repo;
using Dapper.Accelr8.Repo.Parameters;
using Dapper.Accelr8.Repo.Contracts.Readers;

namespace Dapper.Accelr8.TableInfos
{
	public enum AuditTrailColumnNames
	{	
		AuditTrailId, 	
		UserName, 	
		AuditDate, 	
		Action, 	
		Area, 	
		Details, 	
	}

	public enum AuditTrailCascadeNames
	{	
		
	}

	public class AuditTrailTableInfo : Dapper.Accelr8.Sql.TableInfo
	{
		public AuditTrailTableInfo(IAccelr8Locator locator) : base(locator)
		{
			UniqueId = true;
			IdColumn = AuditTrailColumnNames.AuditTrailId.ToString();
			TableName = "AuditTrail";
			TableAlias = "audittrail";
			ColumnNames = Enum.GetNames(typeof(AuditTrailColumnNames));

			Joins = new JoinInfo[] {
						};
		}
	}
}
		
using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Text;

using Dapper.Accelr8.Domain;
using Dapper.Accelr8.TableInfos;
using Dapper;
using Dapper.Accelr8.Sql;
using Dapper.Accelr8.Repo;
using Dapper.Accelr8.Repo.Parameters;
using Dapper.Accelr8.Repo.Contracts.Readers;

namespace Dapper.Accelr8.TableInfos
{
	public enum BiographicGroupColumnNames
	{	
		BiographicGroupId, 	
		Name, 	
		WorkspaceId, 	
	}

	public enum BiographicGroupCascadeNames
	{	
		
		workspace, 	
	}

	public class BiographicGroupTableInfo : Dapper.Accelr8.Sql.TableInfo
	{
		public BiographicGroupTableInfo(IAccelr8Locator locator) : base(locator)
		{
			UniqueId = true;
			IdColumn = BiographicGroupColumnNames.BiographicGroupId.ToString();
			TableName = "BiographicGroups";
			TableAlias = "biographicgroup";
			ColumnNames = Enum.GetNames(typeof(BiographicGroupColumnNames));

			Joins = new JoinInfo[] {
						//For Key FK_BiographicGroups_Workspaces
			new JoinInfo() {
			Reader = new Func<IEntityReader>(() => GetReader(typeof(int), typeof(Workspace))),
			TableName = "Workspaces",
			Alias = TableAlias + "_" + "workspace",
			Outer = false,
			Load = (entity, row) =>
				{ 
					var reader = GetReader(typeof(int), typeof(Workspace));
					var st = (entity as BiographicGroup);

					if (st == null || row == null)
						return st;

					if (row.Id == default(int))
						return st;

					st.Workspace = reader.LoadEntityObject(row);

					return st;
				},
			JoinQuery = new JoinQueryElement[]
			{
				new JoinQueryElement() 
				{ 
					JoinField = WorkspaceColumnNames.WorkspaceId.ToString(),
					Operator = Operator.Equals,
					ParentField = BiographicGroupColumnNames.WorkspaceId.ToString(),
					ParentTableAlias = TableAlias
				}
			} },
						};
		}
	}
}
		
using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Text;

using Dapper.Accelr8.Domain;
using Dapper.Accelr8.TableInfos;
using Dapper;
using Dapper.Accelr8.Sql;
using Dapper.Accelr8.Repo;
using Dapper.Accelr8.Repo.Parameters;
using Dapper.Accelr8.Repo.Contracts.Readers;

namespace Dapper.Accelr8.TableInfos
{
	public enum BiometricColumnNames
	{	
		BiometricId, 	
		TransactionId, 	
		FingerPosition, 	
		Quality, 	
		Modality, 	
	}

	public enum BiometricCascadeNames
	{	
		
		transaction, 	
	}

	public class BiometricTableInfo : Dapper.Accelr8.Sql.TableInfo
	{
		public BiometricTableInfo(IAccelr8Locator locator) : base(locator)
		{
			UniqueId = true;
			IdColumn = BiometricColumnNames.BiometricId.ToString();
			TableName = "Biometrics";
			TableAlias = "biometric";
			ColumnNames = Enum.GetNames(typeof(BiometricColumnNames));

			Joins = new JoinInfo[] {
						//For Key FK_Biometrics_Transactions
			new JoinInfo() {
			Reader = new Func<IEntityReader>(() => GetReader(typeof(int), typeof(Transaction))),
			TableName = "Transactions",
			Alias = TableAlias + "_" + "transaction",
			Outer = false,
			Load = (entity, row) =>
				{ 
					var reader = GetReader(typeof(int), typeof(Transaction));
					var st = (entity as Biometric);

					if (st == null || row == null)
						return st;

					if (row.Id == default(int))
						return st;

					st.Transaction = reader.LoadEntityObject(row);

					return st;
				},
			JoinQuery = new JoinQueryElement[]
			{
				new JoinQueryElement() 
				{ 
					JoinField = TransactionColumnNames.TransactionId.ToString(),
					Operator = Operator.Equals,
					ParentField = BiometricColumnNames.TransactionId.ToString(),
					ParentTableAlias = TableAlias
				}
			} },
						};
		}
	}
}
		
using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Text;

using Dapper.Accelr8.Domain;
using Dapper.Accelr8.TableInfos;
using Dapper;
using Dapper.Accelr8.Sql;
using Dapper.Accelr8.Repo;
using Dapper.Accelr8.Repo.Parameters;
using Dapper.Accelr8.Repo.Contracts.Readers;

namespace Dapper.Accelr8.TableInfos
{
	public enum ClientColumnNames
	{	
		ClientId, 	
		Name, 	
		Description, 	
		IsActive, 	
		EmailAddress, 	
		Address1, 	
		Address2, 	
		City, 	
		State, 	
		Zip, 	
		Country, 	
		Phone, 	
		GroupId, 	
		OriginatingAgencyId, 	
		EndpointId, 	
		ContactName, 	
	}

	public enum ClientCascadeNames
	{	
		transaction, 	
		
		group, 	
		endpoint, 	
	}

	public class ClientTableInfo : Dapper.Accelr8.Sql.TableInfo
	{
		public ClientTableInfo(IAccelr8Locator locator) : base(locator)
		{
			UniqueId = true;
			IdColumn = ClientColumnNames.ClientId.ToString();
			TableName = "Clients";
			TableAlias = "client";
			ColumnNames = Enum.GetNames(typeof(ClientColumnNames));

			Joins = new JoinInfo[] {
						//For Key FK_Clients_Groups
			new JoinInfo() {
			Reader = new Func<IEntityReader>(() => GetReader(typeof(int), typeof(Group))),
			TableName = "Groups",
			Alias = TableAlias + "_" + "group",
			Outer = false,
			Load = (entity, row) =>
				{ 
					var reader = GetReader(typeof(int), typeof(Group));
					var st = (entity as Client);

					if (st == null || row == null)
						return st;

					if (row.Id == default(int))
						return st;

					st.Group = reader.LoadEntityObject(row);

					return st;
				},
			JoinQuery = new JoinQueryElement[]
			{
				new JoinQueryElement() 
				{ 
					JoinField = GroupColumnNames.GroupId.ToString(),
					Operator = Operator.Equals,
					ParentField = ClientColumnNames.GroupId.ToString(),
					ParentTableAlias = TableAlias
				}
			} },
						//For Key FK_Clients_Endpoint
			new JoinInfo() {
			Reader = new Func<IEntityReader>(() => GetReader(typeof(int), typeof(Endpoint))),
			TableName = "Endpoints",
			Alias = TableAlias + "_" + "endpoint",
			Outer = false,
			Load = (entity, row) =>
				{ 
					var reader = GetReader(typeof(int), typeof(Endpoint));
					var st = (entity as Client);

					if (st == null || row == null)
						return st;

					if (row.Id == default(int))
						return st;

					st.Endpoint = reader.LoadEntityObject(row);

					return st;
				},
			JoinQuery = new JoinQueryElement[]
			{
				new JoinQueryElement() 
				{ 
					JoinField = EndpointColumnNames.EndpointId.ToString(),
					Operator = Operator.Equals,
					ParentField = ClientColumnNames.EndpointId.ToString(),
					ParentTableAlias = TableAlias
				}
			} },
						};
		}
	}
}
		
using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Text;

using Dapper.Accelr8.Domain;
using Dapper.Accelr8.TableInfos;
using Dapper;
using Dapper.Accelr8.Sql;
using Dapper.Accelr8.Repo;
using Dapper.Accelr8.Repo.Parameters;
using Dapper.Accelr8.Repo.Contracts.Readers;

namespace Dapper.Accelr8.TableInfos
{
	public enum CmtTransactionEnrollmentMnemonicValueColumnNames
	{	
		TransactionId, 	
		PersonId, 	
		WorkspaceId, 	
		TCN, 	
		OriginatingAgencyId, 	
		DestinationAgencyId, 	
		DestinationAgencyName, 	
		Filepath, 	
		CreatedDate, 	
		TransactionType, 	
		Name, 	
		UserId, 	
		Username, 	
		TransactionStatus, 	
		StatusDate, 	
		CaptureWorkflowName, 	
		PhotoCaptureWorkflowName, 	
		DocumentCaptureWorkflowName, 	
		EnrollmentMnemonicValueEntry, 	
		EnrollmentMnemonicDescription, 	
		MnemonicCode, 	
		SubmissionId, 	
		Submission_spc_Status, 	
		TCR, 	
	}

	public enum CmtTransactionEnrollmentMnemonicValueCascadeNames
	{	
		
	}

	public class CmtTransactionEnrollmentMnemonicValueTableInfo : Dapper.Accelr8.Sql.TableInfo
	{
		public CmtTransactionEnrollmentMnemonicValueTableInfo(IAccelr8Locator locator) : base(locator)
		{
			UniqueId = false;
			IdColumn = CmtTransactionEnrollmentMnemonicValueColumnNames.TransactionId.ToString();
			TableName = "CMT_TransactionEnrollmentMnemonicValues";
			TableAlias = "cmt_transactionenrollmentmnemonicvalue";
			ColumnNames = Enum.GetNames(typeof(CmtTransactionEnrollmentMnemonicValueColumnNames));

			Joins = new JoinInfo[] {
						};
		}
	}
}
		
using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Text;

using Dapper.Accelr8.Domain;
using Dapper.Accelr8.TableInfos;
using Dapper;
using Dapper.Accelr8.Sql;
using Dapper.Accelr8.Repo;
using Dapper.Accelr8.Repo.Parameters;
using Dapper.Accelr8.Repo.Contracts.Readers;

namespace Dapper.Accelr8.TableInfos
{
	public enum DefaultValueColumnNames
	{	
		DefaultValueId, 	
		WorkspaceId, 	
		Value, 	
		Mnemonic, 	
	}

	public enum DefaultValueCascadeNames
	{	
		
		workspace, 	
	}

	public class DefaultValueTableInfo : Dapper.Accelr8.Sql.TableInfo
	{
		public DefaultValueTableInfo(IAccelr8Locator locator) : base(locator)
		{
			UniqueId = true;
			IdColumn = DefaultValueColumnNames.DefaultValueId.ToString();
			TableName = "DefaultValues";
			TableAlias = "defaultvalue";
			ColumnNames = Enum.GetNames(typeof(DefaultValueColumnNames));

			Joins = new JoinInfo[] {
						//For Key FK_DefaultValues_Workspaces
			new JoinInfo() {
			Reader = new Func<IEntityReader>(() => GetReader(typeof(int), typeof(Workspace))),
			TableName = "Workspaces",
			Alias = TableAlias + "_" + "workspace",
			Outer = false,
			Load = (entity, row) =>
				{ 
					var reader = GetReader(typeof(int), typeof(Workspace));
					var st = (entity as DefaultValue);

					if (st == null || row == null)
						return st;

					if (row.Id == default(int))
						return st;

					st.Workspace = reader.LoadEntityObject(row);

					return st;
				},
			JoinQuery = new JoinQueryElement[]
			{
				new JoinQueryElement() 
				{ 
					JoinField = WorkspaceColumnNames.WorkspaceId.ToString(),
					Operator = Operator.Equals,
					ParentField = DefaultValueColumnNames.WorkspaceId.ToString(),
					ParentTableAlias = TableAlias
				}
			} },
						};
		}
	}
}
		
using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Text;

using Dapper.Accelr8.Domain;
using Dapper.Accelr8.TableInfos;
using Dapper;
using Dapper.Accelr8.Sql;
using Dapper.Accelr8.Repo;
using Dapper.Accelr8.Repo.Parameters;
using Dapper.Accelr8.Repo.Contracts.Readers;

namespace Dapper.Accelr8.TableInfos
{
	public enum DocumentColumnNames
	{	
		DocumentId, 	
		TransactionID, 	
		Blob, 	
		FileType, 	
		DocumentTitle, 	
		IssuingAuthority, 	
		DocumentNumber, 	
		ExpirationDate, 	
		DocumentGroup, 	
	}

	public enum DocumentCascadeNames
	{	
		
		transaction, 	
	}

	public class DocumentTableInfo : Dapper.Accelr8.Sql.TableInfo
	{
		public DocumentTableInfo(IAccelr8Locator locator) : base(locator)
		{
			UniqueId = true;
			IdColumn = DocumentColumnNames.DocumentId.ToString();
			TableName = "Documents";
			TableAlias = "document";
			ColumnNames = Enum.GetNames(typeof(DocumentColumnNames));

			Joins = new JoinInfo[] {
						//For Key FK_Documents_Transactions
			new JoinInfo() {
			Reader = new Func<IEntityReader>(() => GetReader(typeof(int), typeof(Transaction))),
			TableName = "Transactions",
			Alias = TableAlias + "_" + "transaction",
			Outer = false,
			Load = (entity, row) =>
				{ 
					var reader = GetReader(typeof(int), typeof(Transaction));
					var st = (entity as Document);

					if (st == null || row == null)
						return st;

					if (row.Id == default(int))
						return st;

					st.Transaction = reader.LoadEntityObject(row);

					return st;
				},
			JoinQuery = new JoinQueryElement[]
			{
				new JoinQueryElement() 
				{ 
					JoinField = TransactionColumnNames.TransactionId.ToString(),
					Operator = Operator.Equals,
					ParentField = DocumentColumnNames.TransactionID.ToString(),
					ParentTableAlias = TableAlias
				}
			} },
						};
		}
	}
}
		
using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Text;

using Dapper.Accelr8.Domain;
using Dapper.Accelr8.TableInfos;
using Dapper;
using Dapper.Accelr8.Sql;
using Dapper.Accelr8.Repo;
using Dapper.Accelr8.Repo.Parameters;
using Dapper.Accelr8.Repo.Contracts.Readers;

namespace Dapper.Accelr8.TableInfos
{
	public enum EndpointColumnNames
	{	
		EndpointId, 	
		ServerId, 	
		Name, 	
		Configuration, 	
	}

	public enum EndpointCascadeNames
	{	
		submission, 	
		client, 	
		routedresponse, 	
		agencyendpoint, 	
		
		server, 	
	}

	public class EndpointTableInfo : Dapper.Accelr8.Sql.TableInfo
	{
		public EndpointTableInfo(IAccelr8Locator locator) : base(locator)
		{
			UniqueId = true;
			IdColumn = EndpointColumnNames.EndpointId.ToString();
			TableName = "Endpoints";
			TableAlias = "endpoint";
			ColumnNames = Enum.GetNames(typeof(EndpointColumnNames));

			Joins = new JoinInfo[] {
						//For Key FK_Endpoints_Servers
			new JoinInfo() {
			Reader = new Func<IEntityReader>(() => GetReader(typeof(int), typeof(Server))),
			TableName = "Servers",
			Alias = TableAlias + "_" + "server",
			Outer = false,
			Load = (entity, row) =>
				{ 
					var reader = GetReader(typeof(int), typeof(Server));
					var st = (entity as Endpoint);

					if (st == null || row == null)
						return st;

					if (row.Id == default(int))
						return st;

					st.Server = reader.LoadEntityObject(row);

					return st;
				},
			JoinQuery = new JoinQueryElement[]
			{
				new JoinQueryElement() 
				{ 
					JoinField = ServerColumnNames.ServerId.ToString(),
					Operator = Operator.Equals,
					ParentField = EndpointColumnNames.ServerId.ToString(),
					ParentTableAlias = TableAlias
				}
			} },
						};
		}
	}
}
		
using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Text;

using Dapper.Accelr8.Domain;
using Dapper.Accelr8.TableInfos;
using Dapper;
using Dapper.Accelr8.Sql;
using Dapper.Accelr8.Repo;
using Dapper.Accelr8.Repo.Parameters;
using Dapper.Accelr8.Repo.Contracts.Readers;

namespace Dapper.Accelr8.TableInfos
{
	public enum EnrollmentMnemonicValueColumnNames
	{	
		EnrollmentMnemonicValueId, 	
		TransactionId, 	
		EnrollmentMnemonicValueEntry, 	
		EnrollmentMnemonicType, 	
		EnrollmentMnemonicDescription, 	
		MnemonicCode, 	
	}

	public enum EnrollmentMnemonicValueCascadeNames
	{	
		
		transaction, 	
	}

	public class EnrollmentMnemonicValueTableInfo : Dapper.Accelr8.Sql.TableInfo
	{
		public EnrollmentMnemonicValueTableInfo(IAccelr8Locator locator) : base(locator)
		{
			UniqueId = true;
			IdColumn = EnrollmentMnemonicValueColumnNames.EnrollmentMnemonicValueId.ToString();
			TableName = "EnrollmentMnemonicValues";
			TableAlias = "enrollmentmnemonicvalue";
			ColumnNames = Enum.GetNames(typeof(EnrollmentMnemonicValueColumnNames));

			Joins = new JoinInfo[] {
						//For Key FK_EnrollmentMnemonicValues_Transactions
			new JoinInfo() {
			Reader = new Func<IEntityReader>(() => GetReader(typeof(int), typeof(Transaction))),
			TableName = "Transactions",
			Alias = TableAlias + "_" + "transaction",
			Outer = false,
			Load = (entity, row) =>
				{ 
					var reader = GetReader(typeof(int), typeof(Transaction));
					var st = (entity as EnrollmentMnemonicValue);

					if (st == null || row == null)
						return st;

					if (row.Id == default(int))
						return st;

					st.Transaction = reader.LoadEntityObject(row);

					return st;
				},
			JoinQuery = new JoinQueryElement[]
			{
				new JoinQueryElement() 
				{ 
					JoinField = TransactionColumnNames.TransactionId.ToString(),
					Operator = Operator.Equals,
					ParentField = EnrollmentMnemonicValueColumnNames.TransactionId.ToString(),
					ParentTableAlias = TableAlias
				}
			} },
						};
		}
	}
}
		
using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Text;

using Dapper.Accelr8.Domain;
using Dapper.Accelr8.TableInfos;
using Dapper;
using Dapper.Accelr8.Sql;
using Dapper.Accelr8.Repo;
using Dapper.Accelr8.Repo.Parameters;
using Dapper.Accelr8.Repo.Contracts.Readers;

namespace Dapper.Accelr8.TableInfos
{
	public enum GroupColumnNames
	{	
		GroupId, 	
		Name, 	
		Description, 	
		IsDefault, 	
	}

	public enum GroupCascadeNames
	{	
		usersgroup, 	
		workspacegroup, 	
		printergroup, 	
		client, 	
		transactiongroup, 	
		
	}

	public class GroupTableInfo : Dapper.Accelr8.Sql.TableInfo
	{
		public GroupTableInfo(IAccelr8Locator locator) : base(locator)
		{
			UniqueId = true;
			IdColumn = GroupColumnNames.GroupId.ToString();
			TableName = "Groups";
			TableAlias = "group";
			ColumnNames = Enum.GetNames(typeof(GroupColumnNames));

			Joins = new JoinInfo[] {
						};
		}
	}
}
		
using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Text;

using Dapper.Accelr8.Domain;
using Dapper.Accelr8.TableInfos;
using Dapper;
using Dapper.Accelr8.Sql;
using Dapper.Accelr8.Repo;
using Dapper.Accelr8.Repo.Parameters;
using Dapper.Accelr8.Repo.Contracts.Readers;

namespace Dapper.Accelr8.TableInfos
{
	public enum InformationColumnNames
	{	
		InformationID, 	
		DBVersion, 	
	}

	public enum InformationCascadeNames
	{	
		
	}

	public class InformationTableInfo : Dapper.Accelr8.Sql.TableInfo
	{
		public InformationTableInfo(IAccelr8Locator locator) : base(locator)
		{
			UniqueId = true;
			IdColumn = InformationColumnNames.InformationID.ToString();
			TableName = "Information";
			TableAlias = "information";
			ColumnNames = Enum.GetNames(typeof(InformationColumnNames));

			Joins = new JoinInfo[] {
						};
		}
	}
}
		
using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Text;

using Dapper.Accelr8.Domain;
using Dapper.Accelr8.TableInfos;
using Dapper;
using Dapper.Accelr8.Sql;
using Dapper.Accelr8.Repo;
using Dapper.Accelr8.Repo.Parameters;
using Dapper.Accelr8.Repo.Contracts.Readers;

namespace Dapper.Accelr8.TableInfos
{
	public enum LicenseColumnNames
	{	
		LicenseId, 	
		LicenseType, 	
		ComputerName, 	
		MACAddress, 	
		DeviceSerialNum, 	
		UserId, 	
		WorkstationId, 	
	}

	public enum LicenseCascadeNames
	{	
		
		user, 	
	}

	public class LicenseTableInfo : Dapper.Accelr8.Sql.TableInfo
	{
		public LicenseTableInfo(IAccelr8Locator locator) : base(locator)
		{
			UniqueId = true;
			IdColumn = LicenseColumnNames.LicenseId.ToString();
			TableName = "Licenses";
			TableAlias = "license";
			ColumnNames = Enum.GetNames(typeof(LicenseColumnNames));

			Joins = new JoinInfo[] {
						//For Key FK_Licenses_Users
			new JoinInfo() {
			Reader = new Func<IEntityReader>(() => GetReader(typeof(int), typeof(User))),
			TableName = "Users",
			Alias = TableAlias + "_" + "user",
			Outer = false,
			Load = (entity, row) =>
				{ 
					var reader = GetReader(typeof(int), typeof(User));
					var st = (entity as License);

					if (st == null || row == null)
						return st;

					if (row.Id == default(int))
						return st;

					st.User = reader.LoadEntityObject(row);

					return st;
				},
			JoinQuery = new JoinQueryElement[]
			{
				new JoinQueryElement() 
				{ 
					JoinField = UserColumnNames.UserId.ToString(),
					Operator = Operator.Equals,
					ParentField = LicenseColumnNames.UserId.ToString(),
					ParentTableAlias = TableAlias
				}
			} },
						};
		}
	}
}
		
using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Text;

using Dapper.Accelr8.Domain;
using Dapper.Accelr8.TableInfos;
using Dapper;
using Dapper.Accelr8.Sql;
using Dapper.Accelr8.Repo;
using Dapper.Accelr8.Repo.Parameters;
using Dapper.Accelr8.Repo.Contracts.Readers;

namespace Dapper.Accelr8.TableInfos
{
	public enum MatchRequestColumnNames
	{	
		MatchRequestId, 	
		SubmissionId, 	
		AbisRequestId, 	
		AbisOperation, 	
		Status, 	
		PersonId, 	
	}

	public enum MatchRequestCascadeNames
	{	
		
		submission, 	
	}

	public class MatchRequestTableInfo : Dapper.Accelr8.Sql.TableInfo
	{
		public MatchRequestTableInfo(IAccelr8Locator locator) : base(locator)
		{
			UniqueId = true;
			IdColumn = MatchRequestColumnNames.MatchRequestId.ToString();
			TableName = "MatchRequests";
			TableAlias = "matchrequest";
			ColumnNames = Enum.GetNames(typeof(MatchRequestColumnNames));

			Joins = new JoinInfo[] {
						//For Key FK_MatchRequest_Submission_SubmissionId
			new JoinInfo() {
			Reader = new Func<IEntityReader>(() => GetReader(typeof(int), typeof(Submission))),
			TableName = "Submissions",
			Alias = TableAlias + "_" + "submission",
			Outer = false,
			Load = (entity, row) =>
				{ 
					var reader = GetReader(typeof(int), typeof(Submission));
					var st = (entity as MatchRequest);

					if (st == null || row == null)
						return st;

					if (row.Id == default(int))
						return st;

					st.Submission = reader.LoadEntityObject(row);

					return st;
				},
			JoinQuery = new JoinQueryElement[]
			{
				new JoinQueryElement() 
				{ 
					JoinField = SubmissionColumnNames.SubmissionId.ToString(),
					Operator = Operator.Equals,
					ParentField = MatchRequestColumnNames.SubmissionId.ToString(),
					ParentTableAlias = TableAlias
				}
			} },
						};
		}
	}
}
		
using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Text;

using Dapper.Accelr8.Domain;
using Dapper.Accelr8.TableInfos;
using Dapper;
using Dapper.Accelr8.Sql;
using Dapper.Accelr8.Repo;
using Dapper.Accelr8.Repo.Parameters;
using Dapper.Accelr8.Repo.Contracts.Readers;

namespace Dapper.Accelr8.TableInfos
{
	public enum PersonColumnNames
	{	
		PersonId, 	
		LastName, 	
		FirstName, 	
		MatcherPersonId, 	
	}

	public enum PersonCascadeNames
	{	
		transaction, 	
		
	}

	public class PersonTableInfo : Dapper.Accelr8.Sql.TableInfo
	{
		public PersonTableInfo(IAccelr8Locator locator) : base(locator)
		{
			UniqueId = true;
			IdColumn = PersonColumnNames.PersonId.ToString();
			TableName = "People";
			TableAlias = "person";
			ColumnNames = Enum.GetNames(typeof(PersonColumnNames));

			Joins = new JoinInfo[] {
						};
		}
	}
}
		
using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Text;

using Dapper.Accelr8.Domain;
using Dapper.Accelr8.TableInfos;
using Dapper;
using Dapper.Accelr8.Sql;
using Dapper.Accelr8.Repo;
using Dapper.Accelr8.Repo.Parameters;
using Dapper.Accelr8.Repo.Contracts.Readers;

namespace Dapper.Accelr8.TableInfos
{
	public enum PrinterGroupColumnNames
	{	
		PrinterGroupsId, 	
		PrinterId, 	
		GroupId, 	
	}

	public enum PrinterGroupCascadeNames
	{	
		
		group, 	
		printer, 	
	}

	public class PrinterGroupTableInfo : Dapper.Accelr8.Sql.TableInfo
	{
		public PrinterGroupTableInfo(IAccelr8Locator locator) : base(locator)
		{
			UniqueId = true;
			IdColumn = PrinterGroupColumnNames.PrinterGroupsId.ToString();
			TableName = "PrinterGroups";
			TableAlias = "printergroup";
			ColumnNames = Enum.GetNames(typeof(PrinterGroupColumnNames));

			Joins = new JoinInfo[] {
						//For Key FK_PrinterGroups_Groups
			new JoinInfo() {
			Reader = new Func<IEntityReader>(() => GetReader(typeof(int), typeof(Group))),
			TableName = "Groups",
			Alias = TableAlias + "_" + "group",
			Outer = false,
			Load = (entity, row) =>
				{ 
					var reader = GetReader(typeof(int), typeof(Group));
					var st = (entity as PrinterGroup);

					if (st == null || row == null)
						return st;

					if (row.Id == default(int))
						return st;

					st.Group = reader.LoadEntityObject(row);

					return st;
				},
			JoinQuery = new JoinQueryElement[]
			{
				new JoinQueryElement() 
				{ 
					JoinField = GroupColumnNames.GroupId.ToString(),
					Operator = Operator.Equals,
					ParentField = PrinterGroupColumnNames.GroupId.ToString(),
					ParentTableAlias = TableAlias
				}
			} },
						//For Key FK_PrinterGroups_Printers
			new JoinInfo() {
			Reader = new Func<IEntityReader>(() => GetReader(typeof(int), typeof(Printer))),
			TableName = "Printers",
			Alias = TableAlias + "_" + "printer",
			Outer = false,
			Load = (entity, row) =>
				{ 
					var reader = GetReader(typeof(int), typeof(Printer));
					var st = (entity as PrinterGroup);

					if (st == null || row == null)
						return st;

					if (row.Id == default(int))
						return st;

					st.Printer = reader.LoadEntityObject(row);

					return st;
				},
			JoinQuery = new JoinQueryElement[]
			{
				new JoinQueryElement() 
				{ 
					JoinField = PrinterColumnNames.PrinterId.ToString(),
					Operator = Operator.Equals,
					ParentField = PrinterGroupColumnNames.PrinterId.ToString(),
					ParentTableAlias = TableAlias
				}
			} },
						};
		}
	}
}
		
using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Text;

using Dapper.Accelr8.Domain;
using Dapper.Accelr8.TableInfos;
using Dapper;
using Dapper.Accelr8.Sql;
using Dapper.Accelr8.Repo;
using Dapper.Accelr8.Repo.Parameters;
using Dapper.Accelr8.Repo.Contracts.Readers;

namespace Dapper.Accelr8.TableInfos
{
	public enum PrinterColumnNames
	{	
		PrinterId, 	
		Name, 	
	}

	public enum PrinterCascadeNames
	{	
		printergroup, 	
		
	}

	public class PrinterTableInfo : Dapper.Accelr8.Sql.TableInfo
	{
		public PrinterTableInfo(IAccelr8Locator locator) : base(locator)
		{
			UniqueId = true;
			IdColumn = PrinterColumnNames.PrinterId.ToString();
			TableName = "Printers";
			TableAlias = "printer";
			ColumnNames = Enum.GetNames(typeof(PrinterColumnNames));

			Joins = new JoinInfo[] {
						};
		}
	}
}
		
using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Text;

using Dapper.Accelr8.Domain;
using Dapper.Accelr8.TableInfos;
using Dapper;
using Dapper.Accelr8.Sql;
using Dapper.Accelr8.Repo;
using Dapper.Accelr8.Repo.Parameters;
using Dapper.Accelr8.Repo.Contracts.Readers;

namespace Dapper.Accelr8.TableInfos
{
	public enum ResponseColumnNames
	{	
		ResponseId, 	
		SubmissionId, 	
		DateReceived, 	
		FilePath, 	
		ResponseType, 	
		TCR, 	
		TCN, 	
		AgencyId, 	
	}

	public enum ResponseCascadeNames
	{	
		routedresponse, 	
		
		submission, 	
	}

	public class ResponseTableInfo : Dapper.Accelr8.Sql.TableInfo
	{
		public ResponseTableInfo(IAccelr8Locator locator) : base(locator)
		{
			UniqueId = true;
			IdColumn = ResponseColumnNames.ResponseId.ToString();
			TableName = "Responses";
			TableAlias = "response";
			ColumnNames = Enum.GetNames(typeof(ResponseColumnNames));

			Joins = new JoinInfo[] {
						//For Key FK_Responses_Submissions
			new JoinInfo() {
			Reader = new Func<IEntityReader>(() => GetReader(typeof(int), typeof(Submission))),
			TableName = "Submissions",
			Alias = TableAlias + "_" + "submission",
			Outer = false,
			Load = (entity, row) =>
				{ 
					var reader = GetReader(typeof(int), typeof(Submission));
					var st = (entity as Response);

					if (st == null || row == null)
						return st;

					if (row.Id == default(int))
						return st;

					st.Submission = reader.LoadEntityObject(row);

					return st;
				},
			JoinQuery = new JoinQueryElement[]
			{
				new JoinQueryElement() 
				{ 
					JoinField = SubmissionColumnNames.SubmissionId.ToString(),
					Operator = Operator.Equals,
					ParentField = ResponseColumnNames.SubmissionId.ToString(),
					ParentTableAlias = TableAlias
				}
			} },
						};
		}
	}
}
		
using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Text;

using Dapper.Accelr8.Domain;
using Dapper.Accelr8.TableInfos;
using Dapper;
using Dapper.Accelr8.Sql;
using Dapper.Accelr8.Repo;
using Dapper.Accelr8.Repo.Parameters;
using Dapper.Accelr8.Repo.Contracts.Readers;

namespace Dapper.Accelr8.TableInfos
{
	public enum RoutedResponseColumnNames
	{	
		RoutedResponseId, 	
		ResponseId, 	
		EndpointId, 	
		Status, 	
	}

	public enum RoutedResponseCascadeNames
	{	
		routedresponsestatushistory, 	
		
		response, 	
		endpoint, 	
	}

	public class RoutedResponseTableInfo : Dapper.Accelr8.Sql.TableInfo
	{
		public RoutedResponseTableInfo(IAccelr8Locator locator) : base(locator)
		{
			UniqueId = true;
			IdColumn = RoutedResponseColumnNames.RoutedResponseId.ToString();
			TableName = "RoutedResponses";
			TableAlias = "routedresponse";
			ColumnNames = Enum.GetNames(typeof(RoutedResponseColumnNames));

			Joins = new JoinInfo[] {
						//For Key FK_RoutedResponses_Responses
			new JoinInfo() {
			Reader = new Func<IEntityReader>(() => GetReader(typeof(int), typeof(Response))),
			TableName = "Responses",
			Alias = TableAlias + "_" + "response",
			Outer = false,
			Load = (entity, row) =>
				{ 
					var reader = GetReader(typeof(int), typeof(Response));
					var st = (entity as RoutedResponse);

					if (st == null || row == null)
						return st;

					if (row.Id == default(int))
						return st;

					st.Response = reader.LoadEntityObject(row);

					return st;
				},
			JoinQuery = new JoinQueryElement[]
			{
				new JoinQueryElement() 
				{ 
					JoinField = ResponseColumnNames.ResponseId.ToString(),
					Operator = Operator.Equals,
					ParentField = RoutedResponseColumnNames.ResponseId.ToString(),
					ParentTableAlias = TableAlias
				}
			} },
						//For Key FK__RoutedRes__Endpo__6477ECF3
			new JoinInfo() {
			Reader = new Func<IEntityReader>(() => GetReader(typeof(int), typeof(Endpoint))),
			TableName = "Endpoints",
			Alias = TableAlias + "_" + "endpoint",
			Outer = false,
			Load = (entity, row) =>
				{ 
					var reader = GetReader(typeof(int), typeof(Endpoint));
					var st = (entity as RoutedResponse);

					if (st == null || row == null)
						return st;

					if (row.Id == default(int))
						return st;

					st.Endpoint = reader.LoadEntityObject(row);

					return st;
				},
			JoinQuery = new JoinQueryElement[]
			{
				new JoinQueryElement() 
				{ 
					JoinField = EndpointColumnNames.EndpointId.ToString(),
					Operator = Operator.Equals,
					ParentField = RoutedResponseColumnNames.EndpointId.ToString(),
					ParentTableAlias = TableAlias
				}
			} },
						};
		}
	}
}
		
using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Text;

using Dapper.Accelr8.Domain;
using Dapper.Accelr8.TableInfos;
using Dapper;
using Dapper.Accelr8.Sql;
using Dapper.Accelr8.Repo;
using Dapper.Accelr8.Repo.Parameters;
using Dapper.Accelr8.Repo.Contracts.Readers;

namespace Dapper.Accelr8.TableInfos
{
	public enum RoutedResponseStatusHistoryColumnNames
	{	
		RoutedResponseStatusId, 	
		RoutedResponseId, 	
		RoutedResponseStatus, 	
		StatusDate, 	
	}

	public enum RoutedResponseStatusHistoryCascadeNames
	{	
		
		routedresponse, 	
	}

	public class RoutedResponseStatusHistoryTableInfo : Dapper.Accelr8.Sql.TableInfo
	{
		public RoutedResponseStatusHistoryTableInfo(IAccelr8Locator locator) : base(locator)
		{
			UniqueId = true;
			IdColumn = RoutedResponseStatusHistoryColumnNames.RoutedResponseStatusId.ToString();
			TableName = "RoutedResponseStatusHistory";
			TableAlias = "routedresponsestatushistory";
			ColumnNames = Enum.GetNames(typeof(RoutedResponseStatusHistoryColumnNames));

			Joins = new JoinInfo[] {
						//For Key FK_RoutedResponseStatusHistory_RoutedResponse_RoutedResponseId
			new JoinInfo() {
			Reader = new Func<IEntityReader>(() => GetReader(typeof(int), typeof(RoutedResponse))),
			TableName = "RoutedResponses",
			Alias = TableAlias + "_" + "routedresponse",
			Outer = false,
			Load = (entity, row) =>
				{ 
					var reader = GetReader(typeof(int), typeof(RoutedResponse));
					var st = (entity as RoutedResponseStatusHistory);

					if (st == null || row == null)
						return st;

					if (row.Id == default(int))
						return st;

					st.RoutedResponse = reader.LoadEntityObject(row);

					return st;
				},
			JoinQuery = new JoinQueryElement[]
			{
				new JoinQueryElement() 
				{ 
					JoinField = RoutedResponseColumnNames.RoutedResponseId.ToString(),
					Operator = Operator.Equals,
					ParentField = RoutedResponseStatusHistoryColumnNames.RoutedResponseId.ToString(),
					ParentTableAlias = TableAlias
				}
			} },
						};
		}
	}
}
		
using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Text;

using Dapper.Accelr8.Domain;
using Dapper.Accelr8.TableInfos;
using Dapper;
using Dapper.Accelr8.Sql;
using Dapper.Accelr8.Repo;
using Dapper.Accelr8.Repo.Parameters;
using Dapper.Accelr8.Repo.Contracts.Readers;

namespace Dapper.Accelr8.TableInfos
{
	public enum ServerColumnNames
	{	
		ServerId, 	
		Name, 	
		Direction, 	
		Description, 	
		Protocol, 	
		Configuration, 	
	}

	public enum ServerCascadeNames
	{	
		endpoint, 	
		
	}

	public class ServerTableInfo : Dapper.Accelr8.Sql.TableInfo
	{
		public ServerTableInfo(IAccelr8Locator locator) : base(locator)
		{
			UniqueId = true;
			IdColumn = ServerColumnNames.ServerId.ToString();
			TableName = "Servers";
			TableAlias = "server";
			ColumnNames = Enum.GetNames(typeof(ServerColumnNames));

			Joins = new JoinInfo[] {
						};
		}
	}
}
		
using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Text;

using Dapper.Accelr8.Domain;
using Dapper.Accelr8.TableInfos;
using Dapper;
using Dapper.Accelr8.Sql;
using Dapper.Accelr8.Repo;
using Dapper.Accelr8.Repo.Parameters;
using Dapper.Accelr8.Repo.Contracts.Readers;

namespace Dapper.Accelr8.TableInfos
{
	public enum SettingColumnNames
	{	
		AuditAgeDays, 	
	}

	public enum SettingCascadeNames
	{	
		
	}

	public class SettingTableInfo : Dapper.Accelr8.Sql.TableInfo
	{
		public SettingTableInfo(IAccelr8Locator locator) : base(locator)
		{
			UniqueId = false;
			IdColumn = SettingColumnNames.AuditAgeDays.ToString();
			TableName = "Settings";
			TableAlias = "setting";
			ColumnNames = Enum.GetNames(typeof(SettingColumnNames));

			Joins = new JoinInfo[] {
						};
		}
	}
}
		
using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Text;

using Dapper.Accelr8.Domain;
using Dapper.Accelr8.TableInfos;
using Dapper;
using Dapper.Accelr8.Sql;
using Dapper.Accelr8.Repo;
using Dapper.Accelr8.Repo.Parameters;
using Dapper.Accelr8.Repo.Contracts.Readers;

namespace Dapper.Accelr8.TableInfos
{
	public enum SourceColumnNames
	{	
		SourceId, 	
		Name, 	
		SourceKey, 	
		Description, 	
	}

	public enum SourceCascadeNames
	{	
		transaction, 	
		
	}

	public class SourceTableInfo : Dapper.Accelr8.Sql.TableInfo
	{
		public SourceTableInfo(IAccelr8Locator locator) : base(locator)
		{
			UniqueId = true;
			IdColumn = SourceColumnNames.SourceId.ToString();
			TableName = "Source";
			TableAlias = "source";
			ColumnNames = Enum.GetNames(typeof(SourceColumnNames));

			Joins = new JoinInfo[] {
						};
		}
	}
}
		
using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Text;

using Dapper.Accelr8.Domain;
using Dapper.Accelr8.TableInfos;
using Dapper;
using Dapper.Accelr8.Sql;
using Dapper.Accelr8.Repo;
using Dapper.Accelr8.Repo.Parameters;
using Dapper.Accelr8.Repo.Contracts.Readers;

namespace Dapper.Accelr8.TableInfos
{
	public enum SubmissionColumnNames
	{	
		SubmissionId, 	
		TransactionId, 	
		EndpointId, 	
		AgencyId, 	
		Status, 	
	}

	public enum SubmissionCascadeNames
	{	
		submissionstatushistory, 	
		response, 	
		matchrequest, 	
		
		agency, 	
		transaction, 	
		endpoint, 	
	}

	public class SubmissionTableInfo : Dapper.Accelr8.Sql.TableInfo
	{
		public SubmissionTableInfo(IAccelr8Locator locator) : base(locator)
		{
			UniqueId = true;
			IdColumn = SubmissionColumnNames.SubmissionId.ToString();
			TableName = "Submissions";
			TableAlias = "submission";
			ColumnNames = Enum.GetNames(typeof(SubmissionColumnNames));

			Joins = new JoinInfo[] {
						//For Key FK_Submission_Agency
			new JoinInfo() {
			Reader = new Func<IEntityReader>(() => GetReader(typeof(int), typeof(Agency))),
			TableName = "Agencies",
			Alias = TableAlias + "_" + "agency",
			Outer = false,
			Load = (entity, row) =>
				{ 
					var reader = GetReader(typeof(int), typeof(Agency));
					var st = (entity as Submission);

					if (st == null || row == null)
						return st;

					if (row.Id == default(int))
						return st;

					st.Agency = reader.LoadEntityObject(row);

					return st;
				},
			JoinQuery = new JoinQueryElement[]
			{
				new JoinQueryElement() 
				{ 
					JoinField = AgencyColumnNames.AgencyId.ToString(),
					Operator = Operator.Equals,
					ParentField = SubmissionColumnNames.AgencyId.ToString(),
					ParentTableAlias = TableAlias
				}
			} },
						//For Key FK_Submissions_Transactions
			new JoinInfo() {
			Reader = new Func<IEntityReader>(() => GetReader(typeof(int), typeof(Transaction))),
			TableName = "Transactions",
			Alias = TableAlias + "_" + "transaction",
			Outer = false,
			Load = (entity, row) =>
				{ 
					var reader = GetReader(typeof(int), typeof(Transaction));
					var st = (entity as Submission);

					if (st == null || row == null)
						return st;

					if (row.Id == default(int))
						return st;

					st.Transaction = reader.LoadEntityObject(row);

					return st;
				},
			JoinQuery = new JoinQueryElement[]
			{
				new JoinQueryElement() 
				{ 
					JoinField = TransactionColumnNames.TransactionId.ToString(),
					Operator = Operator.Equals,
					ParentField = SubmissionColumnNames.TransactionId.ToString(),
					ParentTableAlias = TableAlias
				}
			} },
						//For Key FK_Submissions_Endpoints
			new JoinInfo() {
			Reader = new Func<IEntityReader>(() => GetReader(typeof(int), typeof(Endpoint))),
			TableName = "Endpoints",
			Alias = TableAlias + "_" + "endpoint",
			Outer = false,
			Load = (entity, row) =>
				{ 
					var reader = GetReader(typeof(int), typeof(Endpoint));
					var st = (entity as Submission);

					if (st == null || row == null)
						return st;

					if (row.Id == default(int))
						return st;

					st.Endpoint = reader.LoadEntityObject(row);

					return st;
				},
			JoinQuery = new JoinQueryElement[]
			{
				new JoinQueryElement() 
				{ 
					JoinField = EndpointColumnNames.EndpointId.ToString(),
					Operator = Operator.Equals,
					ParentField = SubmissionColumnNames.EndpointId.ToString(),
					ParentTableAlias = TableAlias
				}
			} },
						};
		}
	}
}
		
using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Text;

using Dapper.Accelr8.Domain;
using Dapper.Accelr8.TableInfos;
using Dapper;
using Dapper.Accelr8.Sql;
using Dapper.Accelr8.Repo;
using Dapper.Accelr8.Repo.Parameters;
using Dapper.Accelr8.Repo.Contracts.Readers;

namespace Dapper.Accelr8.TableInfos
{
	public enum SubmissionViewColumnNames
	{	
		SubmissionId, 	
		TransactionId, 	
		EndpointId, 	
		AgencyId, 	
		Status, 	
		ResponseCount, 	
		TCN, 	
		StatusDate, 	
		Destination, 	
	}

	public enum SubmissionViewCascadeNames
	{	
		
	}

	public class SubmissionViewTableInfo : Dapper.Accelr8.Sql.TableInfo
	{
		public SubmissionViewTableInfo(IAccelr8Locator locator) : base(locator)
		{
			UniqueId = false;
			IdColumn = SubmissionViewColumnNames.SubmissionId.ToString();
			TableName = "Submissions_VW";
			TableAlias = "submissions_vw";
			ColumnNames = Enum.GetNames(typeof(SubmissionViewColumnNames));

			Joins = new JoinInfo[] {
						};
		}
	}
}
		
using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Text;

using Dapper.Accelr8.Domain;
using Dapper.Accelr8.TableInfos;
using Dapper;
using Dapper.Accelr8.Sql;
using Dapper.Accelr8.Repo;
using Dapper.Accelr8.Repo.Parameters;
using Dapper.Accelr8.Repo.Contracts.Readers;

namespace Dapper.Accelr8.TableInfos
{
	public enum SubmissionStatusHistoryColumnNames
	{	
		SubmissionStatusHistoryId, 	
		SubmissionId, 	
		TransmissionStatus, 	
		StatusDate, 	
	}

	public enum SubmissionStatusHistoryCascadeNames
	{	
		
		submission, 	
	}

	public class SubmissionStatusHistoryTableInfo : Dapper.Accelr8.Sql.TableInfo
	{
		public SubmissionStatusHistoryTableInfo(IAccelr8Locator locator) : base(locator)
		{
			UniqueId = true;
			IdColumn = SubmissionStatusHistoryColumnNames.SubmissionStatusHistoryId.ToString();
			TableName = "SubmissionStatusHistory";
			TableAlias = "submissionstatushistory";
			ColumnNames = Enum.GetNames(typeof(SubmissionStatusHistoryColumnNames));

			Joins = new JoinInfo[] {
						//For Key FK_SubmissionStatusHistory_Submissions
			new JoinInfo() {
			Reader = new Func<IEntityReader>(() => GetReader(typeof(int), typeof(Submission))),
			TableName = "Submissions",
			Alias = TableAlias + "_" + "submission",
			Outer = false,
			Load = (entity, row) =>
				{ 
					var reader = GetReader(typeof(int), typeof(Submission));
					var st = (entity as SubmissionStatusHistory);

					if (st == null || row == null)
						return st;

					if (row.Id == default(int))
						return st;

					st.Submission = reader.LoadEntityObject(row);

					return st;
				},
			JoinQuery = new JoinQueryElement[]
			{
				new JoinQueryElement() 
				{ 
					JoinField = SubmissionColumnNames.SubmissionId.ToString(),
					Operator = Operator.Equals,
					ParentField = SubmissionStatusHistoryColumnNames.SubmissionId.ToString(),
					ParentTableAlias = TableAlias
				}
			} },
						};
		}
	}
}
		
using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Text;

using Dapper.Accelr8.Domain;
using Dapper.Accelr8.TableInfos;
using Dapper;
using Dapper.Accelr8.Sql;
using Dapper.Accelr8.Repo;
using Dapper.Accelr8.Repo.Parameters;
using Dapper.Accelr8.Repo.Contracts.Readers;

namespace Dapper.Accelr8.TableInfos
{
	public enum TransactionClientSourceColumnNames
	{	
		TransactionId, 	
		SubmissionCnt, 	
		ClientId, 	
		TCN, 	
		CreatedDate, 	
		Name, 	
		SourceId, 	
		SourceClient, 	
		SourceName, 	
		Filepath, 	
	}

	public enum TransactionClientSourceCascadeNames
	{	
		
	}

	public class TransactionClientSourceTableInfo : Dapper.Accelr8.Sql.TableInfo
	{
		public TransactionClientSourceTableInfo(IAccelr8Locator locator) : base(locator)
		{
			UniqueId = false;
			IdColumn = TransactionClientSourceColumnNames.TransactionId.ToString();
			TableName = "TransactionClientSource";
			TableAlias = "transactionclientsource";
			ColumnNames = Enum.GetNames(typeof(TransactionClientSourceColumnNames));

			Joins = new JoinInfo[] {
						};
		}
	}
}
		
using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Text;

using Dapper.Accelr8.Domain;
using Dapper.Accelr8.TableInfos;
using Dapper;
using Dapper.Accelr8.Sql;
using Dapper.Accelr8.Repo;
using Dapper.Accelr8.Repo.Parameters;
using Dapper.Accelr8.Repo.Contracts.Readers;

namespace Dapper.Accelr8.TableInfos
{
	public enum TransactionFieldColumnNames
	{	
		FieldId, 	
		FieldDescriptor, 	
		Description, 	
		IsVisible, 	
		IsStandardField, 	
		DataType, 	
	}

	public enum TransactionFieldCascadeNames
	{	
		transactionfieldvalue, 	
		
	}

	public class TransactionFieldTableInfo : Dapper.Accelr8.Sql.TableInfo
	{
		public TransactionFieldTableInfo(IAccelr8Locator locator) : base(locator)
		{
			UniqueId = true;
			IdColumn = TransactionFieldColumnNames.FieldId.ToString();
			TableName = "TransactionFields";
			TableAlias = "transactionfield";
			ColumnNames = Enum.GetNames(typeof(TransactionFieldColumnNames));

			Joins = new JoinInfo[] {
						};
		}
	}
}
		
using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Text;

using Dapper.Accelr8.Domain;
using Dapper.Accelr8.TableInfos;
using Dapper;
using Dapper.Accelr8.Sql;
using Dapper.Accelr8.Repo;
using Dapper.Accelr8.Repo.Parameters;
using Dapper.Accelr8.Repo.Contracts.Readers;

namespace Dapper.Accelr8.TableInfos
{
	public enum TransactionFieldValueColumnNames
	{	
		TransactionFieldValueId, 	
		TransactionId, 	
		TransactionFieldId, 	
		Value, 	
	}

	public enum TransactionFieldValueCascadeNames
	{	
		
		transactionfield, 	
		transaction, 	
	}

	public class TransactionFieldValueTableInfo : Dapper.Accelr8.Sql.TableInfo
	{
		public TransactionFieldValueTableInfo(IAccelr8Locator locator) : base(locator)
		{
			UniqueId = true;
			IdColumn = TransactionFieldValueColumnNames.TransactionFieldValueId.ToString();
			TableName = "TransactionFieldValues";
			TableAlias = "transactionfieldvalue";
			ColumnNames = Enum.GetNames(typeof(TransactionFieldValueColumnNames));

			Joins = new JoinInfo[] {
						//For Key FK_TransactionFields_Fields
			new JoinInfo() {
			Reader = new Func<IEntityReader>(() => GetReader(typeof(int), typeof(TransactionField))),
			TableName = "TransactionFields",
			Alias = TableAlias + "_" + "transactionfield",
			Outer = false,
			Load = (entity, row) =>
				{ 
					var reader = GetReader(typeof(int), typeof(TransactionField));
					var st = (entity as TransactionFieldValue);

					if (st == null || row == null)
						return st;

					if (row.Id == default(int))
						return st;

					st.TransactionField = reader.LoadEntityObject(row);

					return st;
				},
			JoinQuery = new JoinQueryElement[]
			{
				new JoinQueryElement() 
				{ 
					JoinField = TransactionFieldColumnNames.FieldId.ToString(),
					Operator = Operator.Equals,
					ParentField = TransactionFieldValueColumnNames.TransactionFieldId.ToString(),
					ParentTableAlias = TableAlias
				}
			} },
						//For Key FK_TransactionFieldValues_Transactions
			new JoinInfo() {
			Reader = new Func<IEntityReader>(() => GetReader(typeof(int), typeof(Transaction))),
			TableName = "Transactions",
			Alias = TableAlias + "_" + "transaction",
			Outer = false,
			Load = (entity, row) =>
				{ 
					var reader = GetReader(typeof(int), typeof(Transaction));
					var st = (entity as TransactionFieldValue);

					if (st == null || row == null)
						return st;

					if (row.Id == default(int))
						return st;

					st.Transaction = reader.LoadEntityObject(row);

					return st;
				},
			JoinQuery = new JoinQueryElement[]
			{
				new JoinQueryElement() 
				{ 
					JoinField = TransactionColumnNames.TransactionId.ToString(),
					Operator = Operator.Equals,
					ParentField = TransactionFieldValueColumnNames.TransactionId.ToString(),
					ParentTableAlias = TableAlias
				}
			} },
						};
		}
	}
}
		
using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Text;

using Dapper.Accelr8.Domain;
using Dapper.Accelr8.TableInfos;
using Dapper;
using Dapper.Accelr8.Sql;
using Dapper.Accelr8.Repo;
using Dapper.Accelr8.Repo.Parameters;
using Dapper.Accelr8.Repo.Contracts.Readers;

namespace Dapper.Accelr8.TableInfos
{
	public enum TransactionFilePathColumnNames
	{	
		TransactionFilePathId, 	
		TransactionId, 	
		FilePath, 	
	}

	public enum TransactionFilePathCascadeNames
	{	
		
		transaction, 	
	}

	public class TransactionFilePathTableInfo : Dapper.Accelr8.Sql.TableInfo
	{
		public TransactionFilePathTableInfo(IAccelr8Locator locator) : base(locator)
		{
			UniqueId = true;
			IdColumn = TransactionFilePathColumnNames.TransactionFilePathId.ToString();
			TableName = "TransactionFilePaths";
			TableAlias = "transactionfilepath";
			ColumnNames = Enum.GetNames(typeof(TransactionFilePathColumnNames));

			Joins = new JoinInfo[] {
						//For Key FK_TransactionFilePaths_Transactions
			new JoinInfo() {
			Reader = new Func<IEntityReader>(() => GetReader(typeof(int), typeof(Transaction))),
			TableName = "Transactions",
			Alias = TableAlias + "_" + "transaction",
			Outer = false,
			Load = (entity, row) =>
				{ 
					var reader = GetReader(typeof(int), typeof(Transaction));
					var st = (entity as TransactionFilePath);

					if (st == null || row == null)
						return st;

					if (row.Id == default(int))
						return st;

					st.Transaction = reader.LoadEntityObject(row);

					return st;
				},
			JoinQuery = new JoinQueryElement[]
			{
				new JoinQueryElement() 
				{ 
					JoinField = TransactionColumnNames.TransactionId.ToString(),
					Operator = Operator.Equals,
					ParentField = TransactionFilePathColumnNames.TransactionId.ToString(),
					ParentTableAlias = TableAlias
				}
			} },
						};
		}
	}
}
		
using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Text;

using Dapper.Accelr8.Domain;
using Dapper.Accelr8.TableInfos;
using Dapper;
using Dapper.Accelr8.Sql;
using Dapper.Accelr8.Repo;
using Dapper.Accelr8.Repo.Parameters;
using Dapper.Accelr8.Repo.Contracts.Readers;

namespace Dapper.Accelr8.TableInfos
{
	public enum TransactionGroupColumnNames
	{	
		TransactionGroupId, 	
		TransactionId, 	
		GroupId, 	
	}

	public enum TransactionGroupCascadeNames
	{	
		
		group, 	
		transaction, 	
	}

	public class TransactionGroupTableInfo : Dapper.Accelr8.Sql.TableInfo
	{
		public TransactionGroupTableInfo(IAccelr8Locator locator) : base(locator)
		{
			UniqueId = true;
			IdColumn = TransactionGroupColumnNames.TransactionGroupId.ToString();
			TableName = "TransactionGroups";
			TableAlias = "transactiongroup";
			ColumnNames = Enum.GetNames(typeof(TransactionGroupColumnNames));

			Joins = new JoinInfo[] {
						//For Key FK_TransactionGroups_Groups
			new JoinInfo() {
			Reader = new Func<IEntityReader>(() => GetReader(typeof(int), typeof(Group))),
			TableName = "Groups",
			Alias = TableAlias + "_" + "group",
			Outer = false,
			Load = (entity, row) =>
				{ 
					var reader = GetReader(typeof(int), typeof(Group));
					var st = (entity as TransactionGroup);

					if (st == null || row == null)
						return st;

					if (row.Id == default(int))
						return st;

					st.Group = reader.LoadEntityObject(row);

					return st;
				},
			JoinQuery = new JoinQueryElement[]
			{
				new JoinQueryElement() 
				{ 
					JoinField = GroupColumnNames.GroupId.ToString(),
					Operator = Operator.Equals,
					ParentField = TransactionGroupColumnNames.GroupId.ToString(),
					ParentTableAlias = TableAlias
				}
			} },
						//For Key FK_TransactionGroups_Transactions
			new JoinInfo() {
			Reader = new Func<IEntityReader>(() => GetReader(typeof(int), typeof(Transaction))),
			TableName = "Transactions",
			Alias = TableAlias + "_" + "transaction",
			Outer = false,
			Load = (entity, row) =>
				{ 
					var reader = GetReader(typeof(int), typeof(Transaction));
					var st = (entity as TransactionGroup);

					if (st == null || row == null)
						return st;

					if (row.Id == default(int))
						return st;

					st.Transaction = reader.LoadEntityObject(row);

					return st;
				},
			JoinQuery = new JoinQueryElement[]
			{
				new JoinQueryElement() 
				{ 
					JoinField = TransactionColumnNames.TransactionId.ToString(),
					Operator = Operator.Equals,
					ParentField = TransactionGroupColumnNames.TransactionId.ToString(),
					ParentTableAlias = TableAlias
				}
			} },
						};
		}
	}
}
		
using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Text;

using Dapper.Accelr8.Domain;
using Dapper.Accelr8.TableInfos;
using Dapper;
using Dapper.Accelr8.Sql;
using Dapper.Accelr8.Repo;
using Dapper.Accelr8.Repo.Parameters;
using Dapper.Accelr8.Repo.Contracts.Readers;

namespace Dapper.Accelr8.TableInfos
{
	public enum TransactionGroupSourceColumnNames
	{	
		TransactionId, 	
		TCN, 	
		CreatedDate, 	
		Name, 	
		TransactionType, 	
		TransactionStatus, 	
		Value, 	
		TransactionFieldId, 	
		FieldDescriptor, 	
		Username, 	
		SourceKey, 	
		AgencyName, 	
	}

	public enum TransactionGroupSourceCascadeNames
	{	
		
	}

	public class TransactionGroupSourceTableInfo : Dapper.Accelr8.Sql.TableInfo
	{
		public TransactionGroupSourceTableInfo(IAccelr8Locator locator) : base(locator)
		{
			UniqueId = false;
			IdColumn = TransactionGroupSourceColumnNames.TransactionId.ToString();
			TableName = "TransactionGroupSource";
			TableAlias = "transactiongroupsource";
			ColumnNames = Enum.GetNames(typeof(TransactionGroupSourceColumnNames));

			Joins = new JoinInfo[] {
						};
		}
	}
}
		
using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Text;

using Dapper.Accelr8.Domain;
using Dapper.Accelr8.TableInfos;
using Dapper;
using Dapper.Accelr8.Sql;
using Dapper.Accelr8.Repo;
using Dapper.Accelr8.Repo.Parameters;
using Dapper.Accelr8.Repo.Contracts.Readers;

namespace Dapper.Accelr8.TableInfos
{
	public enum TransactionOperationDetailColumnNames
	{	
		TransactionOperationDetailsId, 	
		TransactionOperationHistoryId, 	
		OperationFileName, 	
		Status, 	
		ReasonFailed, 	
	}

	public enum TransactionOperationDetailCascadeNames
	{	
		
		transactionoperationhistory, 	
	}

	public class TransactionOperationDetailTableInfo : Dapper.Accelr8.Sql.TableInfo
	{
		public TransactionOperationDetailTableInfo(IAccelr8Locator locator) : base(locator)
		{
			UniqueId = true;
			IdColumn = TransactionOperationDetailColumnNames.TransactionOperationDetailsId.ToString();
			TableName = "TransactionOperationDetails";
			TableAlias = "transactionoperationdetail";
			ColumnNames = Enum.GetNames(typeof(TransactionOperationDetailColumnNames));

			Joins = new JoinInfo[] {
						//For Key FK_TransactionOperationDetails_History
			new JoinInfo() {
			Reader = new Func<IEntityReader>(() => GetReader(typeof(int), typeof(TransactionOperationHistory))),
			TableName = "TransactionOperationHistory",
			Alias = TableAlias + "_" + "transactionoperationhistory",
			Outer = false,
			Load = (entity, row) =>
				{ 
					var reader = GetReader(typeof(int), typeof(TransactionOperationHistory));
					var st = (entity as TransactionOperationDetail);

					if (st == null || row == null)
						return st;

					if (row.Id == default(int))
						return st;

					st.TransactionOperationHistory = reader.LoadEntityObject(row);

					return st;
				},
			JoinQuery = new JoinQueryElement[]
			{
				new JoinQueryElement() 
				{ 
					JoinField = TransactionOperationHistoryColumnNames.TransactionOperationHistoryId.ToString(),
					Operator = Operator.Equals,
					ParentField = TransactionOperationDetailColumnNames.TransactionOperationHistoryId.ToString(),
					ParentTableAlias = TableAlias
				}
			} },
						};
		}
	}
}
		
using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Text;

using Dapper.Accelr8.Domain;
using Dapper.Accelr8.TableInfos;
using Dapper;
using Dapper.Accelr8.Sql;
using Dapper.Accelr8.Repo;
using Dapper.Accelr8.Repo.Parameters;
using Dapper.Accelr8.Repo.Contracts.Readers;

namespace Dapper.Accelr8.TableInfos
{
	public enum TransactionOperationHistoryColumnNames
	{	
		TransactionOperationHistoryId, 	
		Name, 	
		Timestamp, 	
		Username, 	
		TransactionCount, 	
		TransactionSuccessCount, 	
		Status, 	
		OperationType, 	
	}

	public enum TransactionOperationHistoryCascadeNames
	{	
		transactionoperationdetail, 	
		
	}

	public class TransactionOperationHistoryTableInfo : Dapper.Accelr8.Sql.TableInfo
	{
		public TransactionOperationHistoryTableInfo(IAccelr8Locator locator) : base(locator)
		{
			UniqueId = true;
			IdColumn = TransactionOperationHistoryColumnNames.TransactionOperationHistoryId.ToString();
			TableName = "TransactionOperationHistory";
			TableAlias = "transactionoperationhistory";
			ColumnNames = Enum.GetNames(typeof(TransactionOperationHistoryColumnNames));

			Joins = new JoinInfo[] {
						};
		}
	}
}
		
using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Text;

using Dapper.Accelr8.Domain;
using Dapper.Accelr8.TableInfos;
using Dapper;
using Dapper.Accelr8.Sql;
using Dapper.Accelr8.Repo;
using Dapper.Accelr8.Repo.Parameters;
using Dapper.Accelr8.Repo.Contracts.Readers;

namespace Dapper.Accelr8.TableInfos
{
	public enum TransactionColumnNames
	{	
		TransactionId, 	
		PersonId, 	
		WorkspaceId, 	
		ClientId, 	
		TCN, 	
		OriginatingAgencyId, 	
		DestinationAgencyId, 	
		Filepath, 	
		CreatedDate, 	
		TransactionType, 	
		Name, 	
		AgencySpecId, 	
		UserId, 	
		TransactionStatus, 	
		SourceId, 	
		CaptureWorkflowName, 	
		PhotoCaptureWorkflowName, 	
		DocumentCaptureWorkflowName, 	
		WorkstationId, 	
	}

	public enum TransactionCascadeNames
	{	
		transactionfieldvalue, 	
		document, 	
		enrollmentmnemonicvalue, 	
		submission, 	
		transactionfilepath, 	
		biometric, 	
		transactionstatushistory, 	
		transactiongroup, 	
		
		person, 	
		user, 	
		client, 	
		workspace, 	
		agencyspec, 	
		source, 	
	}

	public class TransactionTableInfo : Dapper.Accelr8.Sql.TableInfo
	{
		public TransactionTableInfo(IAccelr8Locator locator) : base(locator)
		{
			UniqueId = true;
			IdColumn = TransactionColumnNames.TransactionId.ToString();
			TableName = "Transactions";
			TableAlias = "transaction";
			ColumnNames = Enum.GetNames(typeof(TransactionColumnNames));

			Joins = new JoinInfo[] {
						//For Key FK_Transactions_People
			new JoinInfo() {
			Reader = new Func<IEntityReader>(() => GetReader(typeof(int), typeof(Person))),
			TableName = "People",
			Alias = TableAlias + "_" + "person",
			Outer = false,
			Load = (entity, row) =>
				{ 
					var reader = GetReader(typeof(int), typeof(Person));
					var st = (entity as Transaction);

					if (st == null || row == null)
						return st;

					if (row.Id == default(int))
						return st;

					st.Person = reader.LoadEntityObject(row);

					return st;
				},
			JoinQuery = new JoinQueryElement[]
			{
				new JoinQueryElement() 
				{ 
					JoinField = PersonColumnNames.PersonId.ToString(),
					Operator = Operator.Equals,
					ParentField = TransactionColumnNames.PersonId.ToString(),
					ParentTableAlias = TableAlias
				}
			} },
						//For Key FK_Transactions_Users
			new JoinInfo() {
			Reader = new Func<IEntityReader>(() => GetReader(typeof(int), typeof(User))),
			TableName = "Users",
			Alias = TableAlias + "_" + "user",
			Outer = false,
			Load = (entity, row) =>
				{ 
					var reader = GetReader(typeof(int), typeof(User));
					var st = (entity as Transaction);

					if (st == null || row == null)
						return st;

					if (row.Id == default(int))
						return st;

					st.User = reader.LoadEntityObject(row);

					return st;
				},
			JoinQuery = new JoinQueryElement[]
			{
				new JoinQueryElement() 
				{ 
					JoinField = UserColumnNames.UserId.ToString(),
					Operator = Operator.Equals,
					ParentField = TransactionColumnNames.UserId.ToString(),
					ParentTableAlias = TableAlias
				}
			} },
						//For Key FK_Transactions_Clients
			new JoinInfo() {
			Reader = new Func<IEntityReader>(() => GetReader(typeof(int), typeof(Client))),
			TableName = "Clients",
			Alias = TableAlias + "_" + "client",
			Outer = false,
			Load = (entity, row) =>
				{ 
					var reader = GetReader(typeof(int), typeof(Client));
					var st = (entity as Transaction);

					if (st == null || row == null)
						return st;

					if (row.Id == default(int))
						return st;

					st.Client = reader.LoadEntityObject(row);

					return st;
				},
			JoinQuery = new JoinQueryElement[]
			{
				new JoinQueryElement() 
				{ 
					JoinField = ClientColumnNames.ClientId.ToString(),
					Operator = Operator.Equals,
					ParentField = TransactionColumnNames.ClientId.ToString(),
					ParentTableAlias = TableAlias
				}
			} },
						//For Key FK_Transactions_Workspaces
			new JoinInfo() {
			Reader = new Func<IEntityReader>(() => GetReader(typeof(int), typeof(Workspace))),
			TableName = "Workspaces",
			Alias = TableAlias + "_" + "workspace",
			Outer = false,
			Load = (entity, row) =>
				{ 
					var reader = GetReader(typeof(int), typeof(Workspace));
					var st = (entity as Transaction);

					if (st == null || row == null)
						return st;

					if (row.Id == default(int))
						return st;

					st.Workspace = reader.LoadEntityObject(row);

					return st;
				},
			JoinQuery = new JoinQueryElement[]
			{
				new JoinQueryElement() 
				{ 
					JoinField = WorkspaceColumnNames.WorkspaceId.ToString(),
					Operator = Operator.Equals,
					ParentField = TransactionColumnNames.WorkspaceId.ToString(),
					ParentTableAlias = TableAlias
				}
			} },
						//For Key FK_Transactions_AgencySpecs
			new JoinInfo() {
			Reader = new Func<IEntityReader>(() => GetReader(typeof(int), typeof(AgencySpec))),
			TableName = "AgencySpecs",
			Alias = TableAlias + "_" + "agencyspec",
			Outer = false,
			Load = (entity, row) =>
				{ 
					var reader = GetReader(typeof(int), typeof(AgencySpec));
					var st = (entity as Transaction);

					if (st == null || row == null)
						return st;

					if (row.Id == default(int))
						return st;

					st.AgencySpec = reader.LoadEntityObject(row);

					return st;
				},
			JoinQuery = new JoinQueryElement[]
			{
				new JoinQueryElement() 
				{ 
					JoinField = AgencySpecColumnNames.AgencySpecId.ToString(),
					Operator = Operator.Equals,
					ParentField = TransactionColumnNames.AgencySpecId.ToString(),
					ParentTableAlias = TableAlias
				}
			} },
						//For Key FK_Transactions_Source
			new JoinInfo() {
			Reader = new Func<IEntityReader>(() => GetReader(typeof(int), typeof(Source))),
			TableName = "Source",
			Alias = TableAlias + "_" + "source",
			Outer = false,
			Load = (entity, row) =>
				{ 
					var reader = GetReader(typeof(int), typeof(Source));
					var st = (entity as Transaction);

					if (st == null || row == null)
						return st;

					if (row.Id == default(int))
						return st;

					st.Source = reader.LoadEntityObject(row);

					return st;
				},
			JoinQuery = new JoinQueryElement[]
			{
				new JoinQueryElement() 
				{ 
					JoinField = SourceColumnNames.SourceId.ToString(),
					Operator = Operator.Equals,
					ParentField = TransactionColumnNames.SourceId.ToString(),
					ParentTableAlias = TableAlias
				}
			} },
						};
		}
	}
}
		
using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Text;

using Dapper.Accelr8.Domain;
using Dapper.Accelr8.TableInfos;
using Dapper;
using Dapper.Accelr8.Sql;
using Dapper.Accelr8.Repo;
using Dapper.Accelr8.Repo.Parameters;
using Dapper.Accelr8.Repo.Contracts.Readers;

namespace Dapper.Accelr8.TableInfos
{
	public enum TransactionStatusHistoryColumnNames
	{	
		TransactionStatusHistoryID, 	
		TransactionId, 	
		TransactionStatus, 	
		StatusDate, 	
	}

	public enum TransactionStatusHistoryCascadeNames
	{	
		
		transaction, 	
	}

	public class TransactionStatusHistoryTableInfo : Dapper.Accelr8.Sql.TableInfo
	{
		public TransactionStatusHistoryTableInfo(IAccelr8Locator locator) : base(locator)
		{
			UniqueId = true;
			IdColumn = TransactionStatusHistoryColumnNames.TransactionStatusHistoryID.ToString();
			TableName = "TransactionStatusHistory";
			TableAlias = "transactionstatushistory";
			ColumnNames = Enum.GetNames(typeof(TransactionStatusHistoryColumnNames));

			Joins = new JoinInfo[] {
						//For Key FK_TransactionStatusHistory_Transactions
			new JoinInfo() {
			Reader = new Func<IEntityReader>(() => GetReader(typeof(int), typeof(Transaction))),
			TableName = "Transactions",
			Alias = TableAlias + "_" + "transaction",
			Outer = false,
			Load = (entity, row) =>
				{ 
					var reader = GetReader(typeof(int), typeof(Transaction));
					var st = (entity as TransactionStatusHistory);

					if (st == null || row == null)
						return st;

					if (row.Id == default(int))
						return st;

					st.Transaction = reader.LoadEntityObject(row);

					return st;
				},
			JoinQuery = new JoinQueryElement[]
			{
				new JoinQueryElement() 
				{ 
					JoinField = TransactionColumnNames.TransactionId.ToString(),
					Operator = Operator.Equals,
					ParentField = TransactionStatusHistoryColumnNames.TransactionId.ToString(),
					ParentTableAlias = TableAlias
				}
			} },
						};
		}
	}
}
		
using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Text;

using Dapper.Accelr8.Domain;
using Dapper.Accelr8.TableInfos;
using Dapper;
using Dapper.Accelr8.Sql;
using Dapper.Accelr8.Repo;
using Dapper.Accelr8.Repo.Parameters;
using Dapper.Accelr8.Repo.Contracts.Readers;

namespace Dapper.Accelr8.TableInfos
{
	public enum UserColumnNames
	{	
		UserId, 	
		Username, 	
		ApplicationId, 	
		DisplayLanguage, 	
		IsDisabled, 	
	}

	public enum UserCascadeNames
	{	
		license, 	
		usersgroup, 	
		transaction, 	
		
		application, 	
	}

	public class UserTableInfo : Dapper.Accelr8.Sql.TableInfo
	{
		public UserTableInfo(IAccelr8Locator locator) : base(locator)
		{
			UniqueId = true;
			IdColumn = UserColumnNames.UserId.ToString();
			TableName = "Users";
			TableAlias = "user";
			ColumnNames = Enum.GetNames(typeof(UserColumnNames));

			Joins = new JoinInfo[] {
						//For Key FK_Users_Applications
			new JoinInfo() {
			Reader = new Func<IEntityReader>(() => GetReader(typeof(int), typeof(Application))),
			TableName = "Applications",
			Alias = TableAlias + "_" + "application",
			Outer = false,
			Load = (entity, row) =>
				{ 
					var reader = GetReader(typeof(int), typeof(Application));
					var st = (entity as User);

					if (st == null || row == null)
						return st;

					if (row.Id == default(int))
						return st;

					st.Application = reader.LoadEntityObject(row);

					return st;
				},
			JoinQuery = new JoinQueryElement[]
			{
				new JoinQueryElement() 
				{ 
					JoinField = ApplicationColumnNames.ApplicationId.ToString(),
					Operator = Operator.Equals,
					ParentField = UserColumnNames.ApplicationId.ToString(),
					ParentTableAlias = TableAlias
				}
			} },
						};
		}
	}
}
		
using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Text;

using Dapper.Accelr8.Domain;
using Dapper.Accelr8.TableInfos;
using Dapper;
using Dapper.Accelr8.Sql;
using Dapper.Accelr8.Repo;
using Dapper.Accelr8.Repo.Parameters;
using Dapper.Accelr8.Repo.Contracts.Readers;

namespace Dapper.Accelr8.TableInfos
{
	public enum UsersGroupColumnNames
	{	
		UsersGroupsId, 	
		UserId, 	
		GroupId, 	
	}

	public enum UsersGroupCascadeNames
	{	
		
		group, 	
		user, 	
	}

	public class UsersGroupTableInfo : Dapper.Accelr8.Sql.TableInfo
	{
		public UsersGroupTableInfo(IAccelr8Locator locator) : base(locator)
		{
			UniqueId = true;
			IdColumn = UsersGroupColumnNames.UsersGroupsId.ToString();
			TableName = "UsersGroups";
			TableAlias = "usersgroup";
			ColumnNames = Enum.GetNames(typeof(UsersGroupColumnNames));

			Joins = new JoinInfo[] {
						//For Key FK_UsersGroups_Groups
			new JoinInfo() {
			Reader = new Func<IEntityReader>(() => GetReader(typeof(int), typeof(Group))),
			TableName = "Groups",
			Alias = TableAlias + "_" + "group",
			Outer = false,
			Load = (entity, row) =>
				{ 
					var reader = GetReader(typeof(int), typeof(Group));
					var st = (entity as UsersGroup);

					if (st == null || row == null)
						return st;

					if (row.Id == default(int))
						return st;

					st.Group = reader.LoadEntityObject(row);

					return st;
				},
			JoinQuery = new JoinQueryElement[]
			{
				new JoinQueryElement() 
				{ 
					JoinField = GroupColumnNames.GroupId.ToString(),
					Operator = Operator.Equals,
					ParentField = UsersGroupColumnNames.GroupId.ToString(),
					ParentTableAlias = TableAlias
				}
			} },
						//For Key FK_UsersGroups_Users
			new JoinInfo() {
			Reader = new Func<IEntityReader>(() => GetReader(typeof(int), typeof(User))),
			TableName = "Users",
			Alias = TableAlias + "_" + "user",
			Outer = false,
			Load = (entity, row) =>
				{ 
					var reader = GetReader(typeof(int), typeof(User));
					var st = (entity as UsersGroup);

					if (st == null || row == null)
						return st;

					if (row.Id == default(int))
						return st;

					st.User = reader.LoadEntityObject(row);

					return st;
				},
			JoinQuery = new JoinQueryElement[]
			{
				new JoinQueryElement() 
				{ 
					JoinField = UserColumnNames.UserId.ToString(),
					Operator = Operator.Equals,
					ParentField = UsersGroupColumnNames.UserId.ToString(),
					ParentTableAlias = TableAlias
				}
			} },
						};
		}
	}
}
		
using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Text;

using Dapper.Accelr8.Domain;
using Dapper.Accelr8.TableInfos;
using Dapper;
using Dapper.Accelr8.Sql;
using Dapper.Accelr8.Repo;
using Dapper.Accelr8.Repo.Parameters;
using Dapper.Accelr8.Repo.Contracts.Readers;

namespace Dapper.Accelr8.TableInfos
{
	public enum WorkspaceGroupColumnNames
	{	
		WorkspaceGroupId, 	
		WorkspaceId, 	
		GroupId, 	
	}

	public enum WorkspaceGroupCascadeNames
	{	
		
		group, 	
		workspace, 	
	}

	public class WorkspaceGroupTableInfo : Dapper.Accelr8.Sql.TableInfo
	{
		public WorkspaceGroupTableInfo(IAccelr8Locator locator) : base(locator)
		{
			UniqueId = true;
			IdColumn = WorkspaceGroupColumnNames.WorkspaceGroupId.ToString();
			TableName = "WorkspaceGroups";
			TableAlias = "workspacegroup";
			ColumnNames = Enum.GetNames(typeof(WorkspaceGroupColumnNames));

			Joins = new JoinInfo[] {
						//For Key FK_WorkspaceGroups_Groups
			new JoinInfo() {
			Reader = new Func<IEntityReader>(() => GetReader(typeof(int), typeof(Group))),
			TableName = "Groups",
			Alias = TableAlias + "_" + "group",
			Outer = false,
			Load = (entity, row) =>
				{ 
					var reader = GetReader(typeof(int), typeof(Group));
					var st = (entity as WorkspaceGroup);

					if (st == null || row == null)
						return st;

					if (row.Id == default(int))
						return st;

					st.Group = reader.LoadEntityObject(row);

					return st;
				},
			JoinQuery = new JoinQueryElement[]
			{
				new JoinQueryElement() 
				{ 
					JoinField = GroupColumnNames.GroupId.ToString(),
					Operator = Operator.Equals,
					ParentField = WorkspaceGroupColumnNames.GroupId.ToString(),
					ParentTableAlias = TableAlias
				}
			} },
						//For Key FK_WorkspaceGroups_Workspaces
			new JoinInfo() {
			Reader = new Func<IEntityReader>(() => GetReader(typeof(int), typeof(Workspace))),
			TableName = "Workspaces",
			Alias = TableAlias + "_" + "workspace",
			Outer = false,
			Load = (entity, row) =>
				{ 
					var reader = GetReader(typeof(int), typeof(Workspace));
					var st = (entity as WorkspaceGroup);

					if (st == null || row == null)
						return st;

					if (row.Id == default(int))
						return st;

					st.Workspace = reader.LoadEntityObject(row);

					return st;
				},
			JoinQuery = new JoinQueryElement[]
			{
				new JoinQueryElement() 
				{ 
					JoinField = WorkspaceColumnNames.WorkspaceId.ToString(),
					Operator = Operator.Equals,
					ParentField = WorkspaceGroupColumnNames.WorkspaceId.ToString(),
					ParentTableAlias = TableAlias
				}
			} },
						};
		}
	}
}
		
using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Text;

using Dapper.Accelr8.Domain;
using Dapper.Accelr8.TableInfos;
using Dapper;
using Dapper.Accelr8.Sql;
using Dapper.Accelr8.Repo;
using Dapper.Accelr8.Repo.Parameters;
using Dapper.Accelr8.Repo.Contracts.Readers;

namespace Dapper.Accelr8.TableInfos
{
	public enum WorkspaceColumnNames
	{	
		WorkspaceId, 	
		Name, 	
		Description, 	
		TransactionType, 	
		CaptureProfile, 	
		ORI, 	
		DAI, 	
		AgencyId, 	
		TCNFormat, 	
		Incrementor, 	
		AllowCopyTo, 	
		PhotoCaptureProfile, 	
		ReuseTCN, 	
		ShowPhotoProfile, 	
		ShowDocumentProfile, 	
		DocumentCaptureProfile, 	
		AgencyConfigKey, 	
		ReuseTCNText, 	
		ReuseTCNYesAction, 	
		AllowBioImport, 	
		UsePreface, 	
		EnforceCompliance, 	
	}

	public enum WorkspaceCascadeNames
	{	
		defaultvalue, 	
		workspacegroup, 	
		transaction, 	
		biographicgroup, 	
		
		agency, 	
	}

	public class WorkspaceTableInfo : Dapper.Accelr8.Sql.TableInfo
	{
		public WorkspaceTableInfo(IAccelr8Locator locator) : base(locator)
		{
			UniqueId = true;
			IdColumn = WorkspaceColumnNames.WorkspaceId.ToString();
			TableName = "Workspaces";
			TableAlias = "workspace";
			ColumnNames = Enum.GetNames(typeof(WorkspaceColumnNames));

			Joins = new JoinInfo[] {
						//For Key FK_Workspaces_Agencies
			new JoinInfo() {
			Reader = new Func<IEntityReader>(() => GetReader(typeof(int), typeof(Agency))),
			TableName = "Agencies",
			Alias = TableAlias + "_" + "agency",
			Outer = false,
			Load = (entity, row) =>
				{ 
					var reader = GetReader(typeof(int), typeof(Agency));
					var st = (entity as Workspace);

					if (st == null || row == null)
						return st;

					if (row.Id == default(int))
						return st;

					st.Agency = reader.LoadEntityObject(row);

					return st;
				},
			JoinQuery = new JoinQueryElement[]
			{
				new JoinQueryElement() 
				{ 
					JoinField = AgencyColumnNames.AgencyId.ToString(),
					Operator = Operator.Equals,
					ParentField = WorkspaceColumnNames.AgencyId.ToString(),
					ParentTableAlias = TableAlias
				}
			} },
						};
		}
	}
}
		