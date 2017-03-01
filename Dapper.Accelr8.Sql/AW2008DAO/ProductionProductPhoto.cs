
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
	public partial class ProductionProductPhoto : Dapper.Accelr8.Repo.Domain.BaseEntity<int>
	{
			public ProductionProductPhoto()
		{			
			IsDirty = false; 
			_productionProductProductPhotos = new List<ProductionProductProductPhoto>();
		_modifiedDate = (DateTime)SqlDateTime.MinValue;
		_thumbNailPhoto = new byte[0];
		_largePhoto = new byte[0];
		}


		
		protected byte[] _thumbNailPhoto;
		public byte[] ThumbNailPhoto 
		{ 
			get { return _thumbNailPhoto; }
			set 
			{ 
				_thumbNailPhoto = value;  
				IsDirty = true;
			}
		} 
			
		protected string _thumbnailPhotoFileName;
		public string ThumbnailPhotoFileName 
		{ 
			get { return _thumbnailPhotoFileName; }
			set 
			{ 
				_thumbnailPhotoFileName = value;  
				IsDirty = true;
			}
		} 
			
		protected byte[] _largePhoto;
		public byte[] LargePhoto 
		{ 
			get { return _largePhoto; }
			set 
			{ 
				_largePhoto = value;  
				IsDirty = true;
			}
		} 
			
		protected string _largePhotoFileName;
		public string LargePhotoFileName 
		{ 
			get { return _largePhotoFileName; }
			set 
			{ 
				_largePhotoFileName = value;  
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
		 
	//From Foreign Key FK_ProductProductPhoto_ProductPhoto_ProductPhotoID	
		protected IList<ProductionProductProductPhoto> _productionProductProductPhotos;
		public virtual IList<ProductionProductProductPhoto> ProductionProductProductPhotos 
		{ 
			get { return _productionProductProductPhotos; }
			set 
			{ 
				_productionProductProductPhotos = value;  
				IsDirty = true;
			}
		} 
					}
}

		