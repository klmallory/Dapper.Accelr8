
using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Text;

using Dapper.Accelr8.Sql.AW2008DAO;
using Dapper;
using Dapper.Accelr8.Repo;
using Dapper.Accelr8.Domain;
using System.Data.SqlTypes;

namespace Dapper.Accelr8.Sql.AW2008DAO
{
	public class ProductionDocument : Dapper.Accelr8.Repo.Domain.BaseEntity<Microsoft.SqlServer.Types.SqlHierarchyId>
	{
			public ProductionDocument()
		{
							
			IsDirty = false; 
			_modifiedDate = (DateTime)SqlDateTime.MinValue;
		_document = new byte[0];
		}


	
		
		protected short? _documentLevel;
		public short? DocumentLevel 
		{ 
			get { return _documentLevel; }
			set 
			{ 
				_documentLevel = value;  
				IsDirty = true;
			}
		} 
			
		protected string _title;
		public string Title 
		{ 
			get { return _title; }
			set 
			{ 
				_title = value;  
				IsDirty = true;
			}
		} 
			
		protected int _owner;
		public int Owner 
		{ 
			get { return _owner; }
			set 
			{ 
				_owner = value;  
				IsDirty = true;
			}
		} 
			
		protected bool _folderFlag;
		public bool FolderFlag 
		{ 
			get { return _folderFlag; }
			set 
			{ 
				_folderFlag = value;  
				IsDirty = true;
			}
		} 
			
		protected string _fileName;
		public string FileName 
		{ 
			get { return _fileName; }
			set 
			{ 
				_fileName = value;  
				IsDirty = true;
			}
		} 
			
		protected string _fileExtension;
		public string FileExtension 
		{ 
			get { return _fileExtension; }
			set 
			{ 
				_fileExtension = value;  
				IsDirty = true;
			}
		} 
			
		protected string _revision;
		public string Revision 
		{ 
			get { return _revision; }
			set 
			{ 
				_revision = value;  
				IsDirty = true;
			}
		} 
			
		protected int _changeNumber;
		public int ChangeNumber 
		{ 
			get { return _changeNumber; }
			set 
			{ 
				_changeNumber = value;  
				IsDirty = true;
			}
		} 
			
		protected byte _status;
		public byte Status 
		{ 
			get { return _status; }
			set 
			{ 
				_status = value;  
				IsDirty = true;
			}
		} 
			
		protected string _documentSummary;
		public string DocumentSummary 
		{ 
			get { return _documentSummary; }
			set 
			{ 
				_documentSummary = value;  
				IsDirty = true;
			}
		} 
			
		protected byte[] _document;
		public byte[] Document 
		{ 
			get { return _document; }
			set 
			{ 
				_document = value;  
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
		 
	//From Foreign Key FK_Document_Employee_Owner	
		protected HumanResourcesEmployee _humanResourcesEmployee;
		public virtual HumanResourcesEmployee HumanResourcesEmployee 
		{ 
			get { return _humanResourcesEmployee; }
			set 
			{ 
				_humanResourcesEmployee = value;  
				IsDirty = true;
			}
		} 
				}
}

		