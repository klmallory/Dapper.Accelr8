
using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Configuration;
using Dapper;
using Dapper.Accelr8.Sql;
using Dapper.Accelr8.Domain;
using Dapper.Accelr8.Repo;
using Dapper.Accelr8.Repo.Extensions;
using Dapper.Accelr8.Repo.Parameters;
using Dapper.Accelr8.Repo.Contracts;

using Dapper.Accelr8.Sql.AW2008DAO;
using Dapper.Accelr8.AW2008TableInfos;
using Dapper.Accelr8.AW2008Readers;
using Dapper.Accelr8.AW2008Writers;
using Dapper.Accelr8.Repo.Dynamic;
using System.Reflection;

namespace Dapper.Accelr8.Sql
{
	public class Loc8AdventureWorks2008R2 : ILoc8
	{
		static ILoc8 _instance = new Loc8AdventureWorks2008R2();
        public static ILoc8 Current { get { return _instance; } set { _instance = value; } }

        DapperExecuter _executer;
        JoinBuilder _joinBuilder;
        QueryBuilder _queryBuilder;
        IDictionary<string, Func<IEntityReader>> _readers = new Dictionary<string, Func<IEntityReader>>();
        IDictionary<string, Func<IEntityWriter>> _writers= new Dictionary<string, Func<IEntityWriter>>();
        IDictionary<string, TableInfo> _tableInfos = new Dictionary<string, TableInfo>();
        IDictionary<string, IDynamicMapper> _mappers = new Dictionary<string, IDynamicMapper>();

        public IDictionary<Type, Type> ClassesToRegister { get; private set; }
        public string ConnectionStringName { get; set; }
        public IDictionary<string, string> ConnectionStringContainer { get; set; }

		public IUnitOfWork GetUnitOfWork(LockType type = LockType.Safe)
		{
			return new UnitOfWork(type);
		}

        public virtual IEntityReader<IdType, EntityType> GetReader<IdType, EntityType>()
            where EntityType : class, IHaveId<IdType>
            where IdType : IComparable
        {
            return _readers[typeof(EntityType).Name].Invoke() as IEntityReader<IdType, EntityType>;
        }

        public virtual IEntityWriter<IdType, EntityType> GetWriter<IdType, EntityType>()
            where EntityType : class, IHaveId<IdType>
            where IdType : IComparable
        {
            return _writers[typeof(EntityType).Name].Invoke() as IEntityWriter<IdType, EntityType>;
        }

        public virtual IEntityReader<IdType, EntityType> GetReader<IdType, EntityType>(string className)
            where EntityType : class, IHaveId<IdType>
            where IdType : IComparable
        {
            return _readers[className].Invoke() as IEntityReader<IdType, EntityType>;
        }

        public virtual IEntityWriter<IdType, EntityType> GetWriter<IdType, EntityType>(string className)
            where EntityType : class, IHaveId<IdType>
            where IdType : IComparable
        {
            return _writers[className].Invoke() as IEntityWriter<IdType, EntityType>;
        }

        public TableInfo GetTableInfo<IdType, EntityType>(string className)
        {
            return _tableInfos[className];
        }

        public IDynamicMapper<EntityType> GetMapper<EntityType>() where EntityType : class, IEntity
        {
            return _mappers[typeof(EntityType).Name] as IDynamicMapper<EntityType>;
        }

        public IDynamicMapper GetMapper(string className)
        {
            return _mappers[className] as IDynamicMapper;
        }

        protected Loc8AdventureWorks2008R2()
        {
			ConnectionStringName = "";	
            ConnectionStringContainer = new Dictionary<string, string>();

            if (ConfigurationManager.ConnectionStrings != null)
            {
                foreach (var c in ConfigurationManager.ConnectionStrings)
                {
                    var cs = (c as ConnectionStringSettings);

                    if (cs == null)
                        continue;

                    ConnectionStringContainer.Add(cs.Name, cs.ConnectionString);
                }
            }

            ClassesToRegister = new Dictionary<Type,Type>();
            _executer = new DapperExecuter(ConnectionStringContainer);
            _joinBuilder = new JoinBuilder();
            _queryBuilder = new QueryBuilder();

			ClassesToRegister.Add(typeof(IEntityReader<int, PersonAddress>), typeof(PersonAddressReader));
			ClassesToRegister.Add(typeof(IEntityWriter<int, PersonAddress>), typeof(PersonAddressWriter)); 
			ClassesToRegister.Add(typeof(PersonAddressTableInfo), typeof(PersonAddressTableInfo));
				ClassesToRegister.Add(typeof(IEntityReader<int, PersonAddressType>), typeof(PersonAddressTypeReader));
			ClassesToRegister.Add(typeof(IEntityWriter<int, PersonAddressType>), typeof(PersonAddressTypeWriter)); 
			ClassesToRegister.Add(typeof(PersonAddressTypeTableInfo), typeof(PersonAddressTypeTableInfo));
				ClassesToRegister.Add(typeof(IEntityReader<byte, AWBuildVersion>), typeof(AWBuildVersionReader));
			ClassesToRegister.Add(typeof(IEntityWriter<byte, AWBuildVersion>), typeof(AWBuildVersionWriter)); 
			ClassesToRegister.Add(typeof(AWBuildVersionTableInfo), typeof(AWBuildVersionTableInfo));
				ClassesToRegister.Add(typeof(IEntityReader<int, ProductionBillOfMaterial>), typeof(ProductionBillOfMaterialReader));
			ClassesToRegister.Add(typeof(IEntityWriter<int, ProductionBillOfMaterial>), typeof(ProductionBillOfMaterialWriter)); 
			ClassesToRegister.Add(typeof(ProductionBillOfMaterialTableInfo), typeof(ProductionBillOfMaterialTableInfo));
				ClassesToRegister.Add(typeof(IEntityReader<int, PersonBusinessEntity>), typeof(PersonBusinessEntityReader));
			ClassesToRegister.Add(typeof(IEntityWriter<int, PersonBusinessEntity>), typeof(PersonBusinessEntityWriter)); 
			ClassesToRegister.Add(typeof(PersonBusinessEntityTableInfo), typeof(PersonBusinessEntityTableInfo));
				ClassesToRegister.Add(typeof(IEntityReader<int, PersonBusinessEntityAddress>), typeof(PersonBusinessEntityAddressReader));
			ClassesToRegister.Add(typeof(IEntityWriter<int, PersonBusinessEntityAddress>), typeof(PersonBusinessEntityAddressWriter)); 
			ClassesToRegister.Add(typeof(PersonBusinessEntityAddressTableInfo), typeof(PersonBusinessEntityAddressTableInfo));
				ClassesToRegister.Add(typeof(IEntityReader<int, PersonBusinessEntityContact>), typeof(PersonBusinessEntityContactReader));
			ClassesToRegister.Add(typeof(IEntityWriter<int, PersonBusinessEntityContact>), typeof(PersonBusinessEntityContactWriter)); 
			ClassesToRegister.Add(typeof(PersonBusinessEntityContactTableInfo), typeof(PersonBusinessEntityContactTableInfo));
				ClassesToRegister.Add(typeof(IEntityReader<int, PersonContactType>), typeof(PersonContactTypeReader));
			ClassesToRegister.Add(typeof(IEntityWriter<int, PersonContactType>), typeof(PersonContactTypeWriter)); 
			ClassesToRegister.Add(typeof(PersonContactTypeTableInfo), typeof(PersonContactTypeTableInfo));
				ClassesToRegister.Add(typeof(IEntityReader<string, PersonCountryRegion>), typeof(PersonCountryRegionReader));
			ClassesToRegister.Add(typeof(IEntityWriter<string, PersonCountryRegion>), typeof(PersonCountryRegionWriter)); 
			ClassesToRegister.Add(typeof(PersonCountryRegionTableInfo), typeof(PersonCountryRegionTableInfo));
				ClassesToRegister.Add(typeof(IEntityReader<string, SalesCountryRegionCurrency>), typeof(SalesCountryRegionCurrencyReader));
			ClassesToRegister.Add(typeof(IEntityWriter<string, SalesCountryRegionCurrency>), typeof(SalesCountryRegionCurrencyWriter)); 
			ClassesToRegister.Add(typeof(SalesCountryRegionCurrencyTableInfo), typeof(SalesCountryRegionCurrencyTableInfo));
				ClassesToRegister.Add(typeof(IEntityReader<int, SalesCreditCard>), typeof(SalesCreditCardReader));
			ClassesToRegister.Add(typeof(IEntityWriter<int, SalesCreditCard>), typeof(SalesCreditCardWriter)); 
			ClassesToRegister.Add(typeof(SalesCreditCardTableInfo), typeof(SalesCreditCardTableInfo));
				ClassesToRegister.Add(typeof(IEntityReader<string, ProductionCulture>), typeof(ProductionCultureReader));
			ClassesToRegister.Add(typeof(IEntityWriter<string, ProductionCulture>), typeof(ProductionCultureWriter)); 
			ClassesToRegister.Add(typeof(ProductionCultureTableInfo), typeof(ProductionCultureTableInfo));
				ClassesToRegister.Add(typeof(IEntityReader<string, SalesCurrency>), typeof(SalesCurrencyReader));
			ClassesToRegister.Add(typeof(IEntityWriter<string, SalesCurrency>), typeof(SalesCurrencyWriter)); 
			ClassesToRegister.Add(typeof(SalesCurrencyTableInfo), typeof(SalesCurrencyTableInfo));
				ClassesToRegister.Add(typeof(IEntityReader<int, SalesCurrencyRate>), typeof(SalesCurrencyRateReader));
			ClassesToRegister.Add(typeof(IEntityWriter<int, SalesCurrencyRate>), typeof(SalesCurrencyRateWriter)); 
			ClassesToRegister.Add(typeof(SalesCurrencyRateTableInfo), typeof(SalesCurrencyRateTableInfo));
				ClassesToRegister.Add(typeof(IEntityReader<int, SalesCustomer>), typeof(SalesCustomerReader));
			ClassesToRegister.Add(typeof(IEntityWriter<int, SalesCustomer>), typeof(SalesCustomerWriter)); 
			ClassesToRegister.Add(typeof(SalesCustomerTableInfo), typeof(SalesCustomerTableInfo));
				ClassesToRegister.Add(typeof(IEntityReader<int, DatabaseLog>), typeof(DatabaseLogReader));
			ClassesToRegister.Add(typeof(IEntityWriter<int, DatabaseLog>), typeof(DatabaseLogWriter)); 
			ClassesToRegister.Add(typeof(DatabaseLogTableInfo), typeof(DatabaseLogTableInfo));
				ClassesToRegister.Add(typeof(IEntityReader<short, HumanResourcesDepartment>), typeof(HumanResourcesDepartmentReader));
			ClassesToRegister.Add(typeof(IEntityWriter<short, HumanResourcesDepartment>), typeof(HumanResourcesDepartmentWriter)); 
			ClassesToRegister.Add(typeof(HumanResourcesDepartmentTableInfo), typeof(HumanResourcesDepartmentTableInfo));
				ClassesToRegister.Add(typeof(IEntityReader<Microsoft.SqlServer.Types.SqlHierarchyId, ProductionDocument>), typeof(ProductionDocumentReader));
			ClassesToRegister.Add(typeof(IEntityWriter<Microsoft.SqlServer.Types.SqlHierarchyId, ProductionDocument>), typeof(ProductionDocumentWriter)); 
			ClassesToRegister.Add(typeof(ProductionDocumentTableInfo), typeof(ProductionDocumentTableInfo));
				ClassesToRegister.Add(typeof(IEntityReader<int, PersonEmailAddress>), typeof(PersonEmailAddressReader));
			ClassesToRegister.Add(typeof(IEntityWriter<int, PersonEmailAddress>), typeof(PersonEmailAddressWriter)); 
			ClassesToRegister.Add(typeof(PersonEmailAddressTableInfo), typeof(PersonEmailAddressTableInfo));
				ClassesToRegister.Add(typeof(IEntityReader<int, HumanResourcesEmployee>), typeof(HumanResourcesEmployeeReader));
			ClassesToRegister.Add(typeof(IEntityWriter<int, HumanResourcesEmployee>), typeof(HumanResourcesEmployeeWriter)); 
			ClassesToRegister.Add(typeof(HumanResourcesEmployeeTableInfo), typeof(HumanResourcesEmployeeTableInfo));
				ClassesToRegister.Add(typeof(IEntityReader<int, HumanResourcesEmployeeDepartmentHistory>), typeof(HumanResourcesEmployeeDepartmentHistoryReader));
			ClassesToRegister.Add(typeof(IEntityWriter<int, HumanResourcesEmployeeDepartmentHistory>), typeof(HumanResourcesEmployeeDepartmentHistoryWriter)); 
			ClassesToRegister.Add(typeof(HumanResourcesEmployeeDepartmentHistoryTableInfo), typeof(HumanResourcesEmployeeDepartmentHistoryTableInfo));
				ClassesToRegister.Add(typeof(IEntityReader<int, HumanResourcesEmployeePayHistory>), typeof(HumanResourcesEmployeePayHistoryReader));
			ClassesToRegister.Add(typeof(IEntityWriter<int, HumanResourcesEmployeePayHistory>), typeof(HumanResourcesEmployeePayHistoryWriter)); 
			ClassesToRegister.Add(typeof(HumanResourcesEmployeePayHistoryTableInfo), typeof(HumanResourcesEmployeePayHistoryTableInfo));
				ClassesToRegister.Add(typeof(IEntityReader<int, ErrorLog>), typeof(ErrorLogReader));
			ClassesToRegister.Add(typeof(IEntityWriter<int, ErrorLog>), typeof(ErrorLogWriter)); 
			ClassesToRegister.Add(typeof(ErrorLogTableInfo), typeof(ErrorLogTableInfo));
				ClassesToRegister.Add(typeof(IEntityReader<int, ProductionIllustration>), typeof(ProductionIllustrationReader));
			ClassesToRegister.Add(typeof(IEntityWriter<int, ProductionIllustration>), typeof(ProductionIllustrationWriter)); 
			ClassesToRegister.Add(typeof(ProductionIllustrationTableInfo), typeof(ProductionIllustrationTableInfo));
				ClassesToRegister.Add(typeof(IEntityReader<int, HumanResourcesJobCandidate>), typeof(HumanResourcesJobCandidateReader));
			ClassesToRegister.Add(typeof(IEntityWriter<int, HumanResourcesJobCandidate>), typeof(HumanResourcesJobCandidateWriter)); 
			ClassesToRegister.Add(typeof(HumanResourcesJobCandidateTableInfo), typeof(HumanResourcesJobCandidateTableInfo));
				ClassesToRegister.Add(typeof(IEntityReader<short, ProductionLocation>), typeof(ProductionLocationReader));
			ClassesToRegister.Add(typeof(IEntityWriter<short, ProductionLocation>), typeof(ProductionLocationWriter)); 
			ClassesToRegister.Add(typeof(ProductionLocationTableInfo), typeof(ProductionLocationTableInfo));
				ClassesToRegister.Add(typeof(IEntityReader<int, PersonPassword>), typeof(PersonPasswordReader));
			ClassesToRegister.Add(typeof(IEntityWriter<int, PersonPassword>), typeof(PersonPasswordWriter)); 
			ClassesToRegister.Add(typeof(PersonPasswordTableInfo), typeof(PersonPasswordTableInfo));
				ClassesToRegister.Add(typeof(IEntityReader<int, PersonPerson>), typeof(PersonPersonReader));
			ClassesToRegister.Add(typeof(IEntityWriter<int, PersonPerson>), typeof(PersonPersonWriter)); 
			ClassesToRegister.Add(typeof(PersonPersonTableInfo), typeof(PersonPersonTableInfo));
				ClassesToRegister.Add(typeof(IEntityReader<int, SalesPersonCreditCard>), typeof(SalesPersonCreditCardReader));
			ClassesToRegister.Add(typeof(IEntityWriter<int, SalesPersonCreditCard>), typeof(SalesPersonCreditCardWriter)); 
			ClassesToRegister.Add(typeof(SalesPersonCreditCardTableInfo), typeof(SalesPersonCreditCardTableInfo));
				ClassesToRegister.Add(typeof(IEntityReader<int, PersonPersonPhone>), typeof(PersonPersonPhoneReader));
			ClassesToRegister.Add(typeof(IEntityWriter<int, PersonPersonPhone>), typeof(PersonPersonPhoneWriter)); 
			ClassesToRegister.Add(typeof(PersonPersonPhoneTableInfo), typeof(PersonPersonPhoneTableInfo));
				ClassesToRegister.Add(typeof(IEntityReader<int, PersonPhoneNumberType>), typeof(PersonPhoneNumberTypeReader));
			ClassesToRegister.Add(typeof(IEntityWriter<int, PersonPhoneNumberType>), typeof(PersonPhoneNumberTypeWriter)); 
			ClassesToRegister.Add(typeof(PersonPhoneNumberTypeTableInfo), typeof(PersonPhoneNumberTypeTableInfo));
				ClassesToRegister.Add(typeof(IEntityReader<int, ProductionProduct>), typeof(ProductionProductReader));
			ClassesToRegister.Add(typeof(IEntityWriter<int, ProductionProduct>), typeof(ProductionProductWriter)); 
			ClassesToRegister.Add(typeof(ProductionProductTableInfo), typeof(ProductionProductTableInfo));
				ClassesToRegister.Add(typeof(IEntityReader<int, ProductionProductCategory>), typeof(ProductionProductCategoryReader));
			ClassesToRegister.Add(typeof(IEntityWriter<int, ProductionProductCategory>), typeof(ProductionProductCategoryWriter)); 
			ClassesToRegister.Add(typeof(ProductionProductCategoryTableInfo), typeof(ProductionProductCategoryTableInfo));
				ClassesToRegister.Add(typeof(IEntityReader<int, ProductionProductCostHistory>), typeof(ProductionProductCostHistoryReader));
			ClassesToRegister.Add(typeof(IEntityWriter<int, ProductionProductCostHistory>), typeof(ProductionProductCostHistoryWriter)); 
			ClassesToRegister.Add(typeof(ProductionProductCostHistoryTableInfo), typeof(ProductionProductCostHistoryTableInfo));
				ClassesToRegister.Add(typeof(IEntityReader<int, ProductionProductDescription>), typeof(ProductionProductDescriptionReader));
			ClassesToRegister.Add(typeof(IEntityWriter<int, ProductionProductDescription>), typeof(ProductionProductDescriptionWriter)); 
			ClassesToRegister.Add(typeof(ProductionProductDescriptionTableInfo), typeof(ProductionProductDescriptionTableInfo));
				ClassesToRegister.Add(typeof(IEntityReader<int, ProductionProductDocument>), typeof(ProductionProductDocumentReader));
			ClassesToRegister.Add(typeof(IEntityWriter<int, ProductionProductDocument>), typeof(ProductionProductDocumentWriter)); 
			ClassesToRegister.Add(typeof(ProductionProductDocumentTableInfo), typeof(ProductionProductDocumentTableInfo));
				ClassesToRegister.Add(typeof(IEntityReader<int, ProductionProductInventory>), typeof(ProductionProductInventoryReader));
			ClassesToRegister.Add(typeof(IEntityWriter<int, ProductionProductInventory>), typeof(ProductionProductInventoryWriter)); 
			ClassesToRegister.Add(typeof(ProductionProductInventoryTableInfo), typeof(ProductionProductInventoryTableInfo));
				ClassesToRegister.Add(typeof(IEntityReader<int, ProductionProductListPriceHistory>), typeof(ProductionProductListPriceHistoryReader));
			ClassesToRegister.Add(typeof(IEntityWriter<int, ProductionProductListPriceHistory>), typeof(ProductionProductListPriceHistoryWriter)); 
			ClassesToRegister.Add(typeof(ProductionProductListPriceHistoryTableInfo), typeof(ProductionProductListPriceHistoryTableInfo));
				ClassesToRegister.Add(typeof(IEntityReader<int, ProductionProductModel>), typeof(ProductionProductModelReader));
			ClassesToRegister.Add(typeof(IEntityWriter<int, ProductionProductModel>), typeof(ProductionProductModelWriter)); 
			ClassesToRegister.Add(typeof(ProductionProductModelTableInfo), typeof(ProductionProductModelTableInfo));
				ClassesToRegister.Add(typeof(IEntityReader<int, ProductionProductModelIllustration>), typeof(ProductionProductModelIllustrationReader));
			ClassesToRegister.Add(typeof(IEntityWriter<int, ProductionProductModelIllustration>), typeof(ProductionProductModelIllustrationWriter)); 
			ClassesToRegister.Add(typeof(ProductionProductModelIllustrationTableInfo), typeof(ProductionProductModelIllustrationTableInfo));
				ClassesToRegister.Add(typeof(IEntityReader<int, ProductionProductModelProductDescriptionCulture>), typeof(ProductionProductModelProductDescriptionCultureReader));
			ClassesToRegister.Add(typeof(IEntityWriter<int, ProductionProductModelProductDescriptionCulture>), typeof(ProductionProductModelProductDescriptionCultureWriter)); 
			ClassesToRegister.Add(typeof(ProductionProductModelProductDescriptionCultureTableInfo), typeof(ProductionProductModelProductDescriptionCultureTableInfo));
				ClassesToRegister.Add(typeof(IEntityReader<int, ProductionProductPhoto>), typeof(ProductionProductPhotoReader));
			ClassesToRegister.Add(typeof(IEntityWriter<int, ProductionProductPhoto>), typeof(ProductionProductPhotoWriter)); 
			ClassesToRegister.Add(typeof(ProductionProductPhotoTableInfo), typeof(ProductionProductPhotoTableInfo));
				ClassesToRegister.Add(typeof(IEntityReader<int, ProductionProductProductPhoto>), typeof(ProductionProductProductPhotoReader));
			ClassesToRegister.Add(typeof(IEntityWriter<int, ProductionProductProductPhoto>), typeof(ProductionProductProductPhotoWriter)); 
			ClassesToRegister.Add(typeof(ProductionProductProductPhotoTableInfo), typeof(ProductionProductProductPhotoTableInfo));
				ClassesToRegister.Add(typeof(IEntityReader<int, ProductionProductReview>), typeof(ProductionProductReviewReader));
			ClassesToRegister.Add(typeof(IEntityWriter<int, ProductionProductReview>), typeof(ProductionProductReviewWriter)); 
			ClassesToRegister.Add(typeof(ProductionProductReviewTableInfo), typeof(ProductionProductReviewTableInfo));
				ClassesToRegister.Add(typeof(IEntityReader<int, ProductionProductSubcategory>), typeof(ProductionProductSubcategoryReader));
			ClassesToRegister.Add(typeof(IEntityWriter<int, ProductionProductSubcategory>), typeof(ProductionProductSubcategoryWriter)); 
			ClassesToRegister.Add(typeof(ProductionProductSubcategoryTableInfo), typeof(ProductionProductSubcategoryTableInfo));
				ClassesToRegister.Add(typeof(IEntityReader<int, PurchasingProductVendor>), typeof(PurchasingProductVendorReader));
			ClassesToRegister.Add(typeof(IEntityWriter<int, PurchasingProductVendor>), typeof(PurchasingProductVendorWriter)); 
			ClassesToRegister.Add(typeof(PurchasingProductVendorTableInfo), typeof(PurchasingProductVendorTableInfo));
				ClassesToRegister.Add(typeof(IEntityReader<int, PurchasingPurchaseOrderDetail>), typeof(PurchasingPurchaseOrderDetailReader));
			ClassesToRegister.Add(typeof(IEntityWriter<int, PurchasingPurchaseOrderDetail>), typeof(PurchasingPurchaseOrderDetailWriter)); 
			ClassesToRegister.Add(typeof(PurchasingPurchaseOrderDetailTableInfo), typeof(PurchasingPurchaseOrderDetailTableInfo));
				ClassesToRegister.Add(typeof(IEntityReader<int, PurchasingPurchaseOrderHeader>), typeof(PurchasingPurchaseOrderHeaderReader));
			ClassesToRegister.Add(typeof(IEntityWriter<int, PurchasingPurchaseOrderHeader>), typeof(PurchasingPurchaseOrderHeaderWriter)); 
			ClassesToRegister.Add(typeof(PurchasingPurchaseOrderHeaderTableInfo), typeof(PurchasingPurchaseOrderHeaderTableInfo));
				ClassesToRegister.Add(typeof(IEntityReader<int, SalesSalesOrderDetail>), typeof(SalesSalesOrderDetailReader));
			ClassesToRegister.Add(typeof(IEntityWriter<int, SalesSalesOrderDetail>), typeof(SalesSalesOrderDetailWriter)); 
			ClassesToRegister.Add(typeof(SalesSalesOrderDetailTableInfo), typeof(SalesSalesOrderDetailTableInfo));
				ClassesToRegister.Add(typeof(IEntityReader<int, SalesSalesOrderHeader>), typeof(SalesSalesOrderHeaderReader));
			ClassesToRegister.Add(typeof(IEntityWriter<int, SalesSalesOrderHeader>), typeof(SalesSalesOrderHeaderWriter)); 
			ClassesToRegister.Add(typeof(SalesSalesOrderHeaderTableInfo), typeof(SalesSalesOrderHeaderTableInfo));
				ClassesToRegister.Add(typeof(IEntityReader<int, SalesSalesOrderHeaderSalesReason>), typeof(SalesSalesOrderHeaderSalesReasonReader));
			ClassesToRegister.Add(typeof(IEntityWriter<int, SalesSalesOrderHeaderSalesReason>), typeof(SalesSalesOrderHeaderSalesReasonWriter)); 
			ClassesToRegister.Add(typeof(SalesSalesOrderHeaderSalesReasonTableInfo), typeof(SalesSalesOrderHeaderSalesReasonTableInfo));
				ClassesToRegister.Add(typeof(IEntityReader<int, SalesSalesPerson>), typeof(SalesSalesPersonReader));
			ClassesToRegister.Add(typeof(IEntityWriter<int, SalesSalesPerson>), typeof(SalesSalesPersonWriter)); 
			ClassesToRegister.Add(typeof(SalesSalesPersonTableInfo), typeof(SalesSalesPersonTableInfo));
				ClassesToRegister.Add(typeof(IEntityReader<int, SalesSalesPersonQuotaHistory>), typeof(SalesSalesPersonQuotaHistoryReader));
			ClassesToRegister.Add(typeof(IEntityWriter<int, SalesSalesPersonQuotaHistory>), typeof(SalesSalesPersonQuotaHistoryWriter)); 
			ClassesToRegister.Add(typeof(SalesSalesPersonQuotaHistoryTableInfo), typeof(SalesSalesPersonQuotaHistoryTableInfo));
				ClassesToRegister.Add(typeof(IEntityReader<int, SalesSalesReason>), typeof(SalesSalesReasonReader));
			ClassesToRegister.Add(typeof(IEntityWriter<int, SalesSalesReason>), typeof(SalesSalesReasonWriter)); 
			ClassesToRegister.Add(typeof(SalesSalesReasonTableInfo), typeof(SalesSalesReasonTableInfo));
				ClassesToRegister.Add(typeof(IEntityReader<int, SalesSalesTaxRate>), typeof(SalesSalesTaxRateReader));
			ClassesToRegister.Add(typeof(IEntityWriter<int, SalesSalesTaxRate>), typeof(SalesSalesTaxRateWriter)); 
			ClassesToRegister.Add(typeof(SalesSalesTaxRateTableInfo), typeof(SalesSalesTaxRateTableInfo));
				ClassesToRegister.Add(typeof(IEntityReader<int, SalesSalesTerritory>), typeof(SalesSalesTerritoryReader));
			ClassesToRegister.Add(typeof(IEntityWriter<int, SalesSalesTerritory>), typeof(SalesSalesTerritoryWriter)); 
			ClassesToRegister.Add(typeof(SalesSalesTerritoryTableInfo), typeof(SalesSalesTerritoryTableInfo));
				ClassesToRegister.Add(typeof(IEntityReader<int, SalesSalesTerritoryHistory>), typeof(SalesSalesTerritoryHistoryReader));
			ClassesToRegister.Add(typeof(IEntityWriter<int, SalesSalesTerritoryHistory>), typeof(SalesSalesTerritoryHistoryWriter)); 
			ClassesToRegister.Add(typeof(SalesSalesTerritoryHistoryTableInfo), typeof(SalesSalesTerritoryHistoryTableInfo));
				ClassesToRegister.Add(typeof(IEntityReader<short, ProductionScrapReason>), typeof(ProductionScrapReasonReader));
			ClassesToRegister.Add(typeof(IEntityWriter<short, ProductionScrapReason>), typeof(ProductionScrapReasonWriter)); 
			ClassesToRegister.Add(typeof(ProductionScrapReasonTableInfo), typeof(ProductionScrapReasonTableInfo));
				ClassesToRegister.Add(typeof(IEntityReader<byte, HumanResourcesShift>), typeof(HumanResourcesShiftReader));
			ClassesToRegister.Add(typeof(IEntityWriter<byte, HumanResourcesShift>), typeof(HumanResourcesShiftWriter)); 
			ClassesToRegister.Add(typeof(HumanResourcesShiftTableInfo), typeof(HumanResourcesShiftTableInfo));
				ClassesToRegister.Add(typeof(IEntityReader<int, PurchasingShipMethod>), typeof(PurchasingShipMethodReader));
			ClassesToRegister.Add(typeof(IEntityWriter<int, PurchasingShipMethod>), typeof(PurchasingShipMethodWriter)); 
			ClassesToRegister.Add(typeof(PurchasingShipMethodTableInfo), typeof(PurchasingShipMethodTableInfo));
				ClassesToRegister.Add(typeof(IEntityReader<int, SalesShoppingCartItem>), typeof(SalesShoppingCartItemReader));
			ClassesToRegister.Add(typeof(IEntityWriter<int, SalesShoppingCartItem>), typeof(SalesShoppingCartItemWriter)); 
			ClassesToRegister.Add(typeof(SalesShoppingCartItemTableInfo), typeof(SalesShoppingCartItemTableInfo));
				ClassesToRegister.Add(typeof(IEntityReader<int, SalesSpecialOffer>), typeof(SalesSpecialOfferReader));
			ClassesToRegister.Add(typeof(IEntityWriter<int, SalesSpecialOffer>), typeof(SalesSpecialOfferWriter)); 
			ClassesToRegister.Add(typeof(SalesSpecialOfferTableInfo), typeof(SalesSpecialOfferTableInfo));
				ClassesToRegister.Add(typeof(IEntityReader<int, SalesSpecialOfferProduct>), typeof(SalesSpecialOfferProductReader));
			ClassesToRegister.Add(typeof(IEntityWriter<int, SalesSpecialOfferProduct>), typeof(SalesSpecialOfferProductWriter)); 
			ClassesToRegister.Add(typeof(SalesSpecialOfferProductTableInfo), typeof(SalesSpecialOfferProductTableInfo));
				ClassesToRegister.Add(typeof(IEntityReader<int, PersonStateProvince>), typeof(PersonStateProvinceReader));
			ClassesToRegister.Add(typeof(IEntityWriter<int, PersonStateProvince>), typeof(PersonStateProvinceWriter)); 
			ClassesToRegister.Add(typeof(PersonStateProvinceTableInfo), typeof(PersonStateProvinceTableInfo));
				ClassesToRegister.Add(typeof(IEntityReader<int, SalesStore>), typeof(SalesStoreReader));
			ClassesToRegister.Add(typeof(IEntityWriter<int, SalesStore>), typeof(SalesStoreWriter)); 
			ClassesToRegister.Add(typeof(SalesStoreTableInfo), typeof(SalesStoreTableInfo));
				ClassesToRegister.Add(typeof(IEntityReader<int, ProductionTransactionHistory>), typeof(ProductionTransactionHistoryReader));
			ClassesToRegister.Add(typeof(IEntityWriter<int, ProductionTransactionHistory>), typeof(ProductionTransactionHistoryWriter)); 
			ClassesToRegister.Add(typeof(ProductionTransactionHistoryTableInfo), typeof(ProductionTransactionHistoryTableInfo));
				ClassesToRegister.Add(typeof(IEntityReader<int, ProductionTransactionHistoryArchive>), typeof(ProductionTransactionHistoryArchiveReader));
			ClassesToRegister.Add(typeof(IEntityWriter<int, ProductionTransactionHistoryArchive>), typeof(ProductionTransactionHistoryArchiveWriter)); 
			ClassesToRegister.Add(typeof(ProductionTransactionHistoryArchiveTableInfo), typeof(ProductionTransactionHistoryArchiveTableInfo));
				ClassesToRegister.Add(typeof(IEntityReader<string, ProductionUnitMeasure>), typeof(ProductionUnitMeasureReader));
			ClassesToRegister.Add(typeof(IEntityWriter<string, ProductionUnitMeasure>), typeof(ProductionUnitMeasureWriter)); 
			ClassesToRegister.Add(typeof(ProductionUnitMeasureTableInfo), typeof(ProductionUnitMeasureTableInfo));
				ClassesToRegister.Add(typeof(IEntityReader<int, PersonvAdditionalContactInfo>), typeof(PersonvAdditionalContactInfoReader));

			ClassesToRegister.Add(typeof(PersonvAdditionalContactInfoTableInfo), typeof(PersonvAdditionalContactInfoTableInfo));
				ClassesToRegister.Add(typeof(IEntityReader<int, HumanResourcesvEmployee>), typeof(HumanResourcesvEmployeeReader));

			ClassesToRegister.Add(typeof(HumanResourcesvEmployeeTableInfo), typeof(HumanResourcesvEmployeeTableInfo));
				ClassesToRegister.Add(typeof(IEntityReader<int, HumanResourcesvEmployeeDepartment>), typeof(HumanResourcesvEmployeeDepartmentReader));

			ClassesToRegister.Add(typeof(HumanResourcesvEmployeeDepartmentTableInfo), typeof(HumanResourcesvEmployeeDepartmentTableInfo));
				ClassesToRegister.Add(typeof(IEntityReader<int, HumanResourcesvEmployeeDepartmentHistory>), typeof(HumanResourcesvEmployeeDepartmentHistoryReader));

			ClassesToRegister.Add(typeof(HumanResourcesvEmployeeDepartmentHistoryTableInfo), typeof(HumanResourcesvEmployeeDepartmentHistoryTableInfo));
				ClassesToRegister.Add(typeof(IEntityReader<int, PurchasingVendor>), typeof(PurchasingVendorReader));
			ClassesToRegister.Add(typeof(IEntityWriter<int, PurchasingVendor>), typeof(PurchasingVendorWriter)); 
			ClassesToRegister.Add(typeof(PurchasingVendorTableInfo), typeof(PurchasingVendorTableInfo));
				ClassesToRegister.Add(typeof(IEntityReader<int, SalesvIndividualCustomer>), typeof(SalesvIndividualCustomerReader));

			ClassesToRegister.Add(typeof(SalesvIndividualCustomerTableInfo), typeof(SalesvIndividualCustomerTableInfo));
				ClassesToRegister.Add(typeof(IEntityReader<int, HumanResourcesvJobCandidate>), typeof(HumanResourcesvJobCandidateReader));

			ClassesToRegister.Add(typeof(HumanResourcesvJobCandidateTableInfo), typeof(HumanResourcesvJobCandidateTableInfo));
				ClassesToRegister.Add(typeof(IEntityReader<int, HumanResourcesvJobCandidateEducation>), typeof(HumanResourcesvJobCandidateEducationReader));

			ClassesToRegister.Add(typeof(HumanResourcesvJobCandidateEducationTableInfo), typeof(HumanResourcesvJobCandidateEducationTableInfo));
				ClassesToRegister.Add(typeof(IEntityReader<int, HumanResourcesvJobCandidateEmployment>), typeof(HumanResourcesvJobCandidateEmploymentReader));

			ClassesToRegister.Add(typeof(HumanResourcesvJobCandidateEmploymentTableInfo), typeof(HumanResourcesvJobCandidateEmploymentTableInfo));
				ClassesToRegister.Add(typeof(IEntityReader<int, SalesvPersonDemographic>), typeof(SalesvPersonDemographicReader));

			ClassesToRegister.Add(typeof(SalesvPersonDemographicTableInfo), typeof(SalesvPersonDemographicTableInfo));
				ClassesToRegister.Add(typeof(IEntityReader<int, ProductionvProductAndDescription>), typeof(ProductionvProductAndDescriptionReader));

			ClassesToRegister.Add(typeof(ProductionvProductAndDescriptionTableInfo), typeof(ProductionvProductAndDescriptionTableInfo));
				ClassesToRegister.Add(typeof(IEntityReader<int, ProductionvProductModelCatalogDescription>), typeof(ProductionvProductModelCatalogDescriptionReader));

			ClassesToRegister.Add(typeof(ProductionvProductModelCatalogDescriptionTableInfo), typeof(ProductionvProductModelCatalogDescriptionTableInfo));
				ClassesToRegister.Add(typeof(IEntityReader<int, ProductionvProductModelInstruction>), typeof(ProductionvProductModelInstructionReader));

			ClassesToRegister.Add(typeof(ProductionvProductModelInstructionTableInfo), typeof(ProductionvProductModelInstructionTableInfo));
				ClassesToRegister.Add(typeof(IEntityReader<int, SalesvSalesPerson>), typeof(SalesvSalesPersonReader));

			ClassesToRegister.Add(typeof(SalesvSalesPersonTableInfo), typeof(SalesvSalesPersonTableInfo));
				ClassesToRegister.Add(typeof(IEntityReader<int, SalesvSalesPersonSalesByFiscalYear>), typeof(SalesvSalesPersonSalesByFiscalYearReader));

			ClassesToRegister.Add(typeof(SalesvSalesPersonSalesByFiscalYearTableInfo), typeof(SalesvSalesPersonSalesByFiscalYearTableInfo));
				ClassesToRegister.Add(typeof(IEntityReader<int, PersonvStateProvinceCountryRegion>), typeof(PersonvStateProvinceCountryRegionReader));

			ClassesToRegister.Add(typeof(PersonvStateProvinceCountryRegionTableInfo), typeof(PersonvStateProvinceCountryRegionTableInfo));
				ClassesToRegister.Add(typeof(IEntityReader<int, SalesvStoreWithAddress>), typeof(SalesvStoreWithAddressReader));

			ClassesToRegister.Add(typeof(SalesvStoreWithAddressTableInfo), typeof(SalesvStoreWithAddressTableInfo));
				ClassesToRegister.Add(typeof(IEntityReader<int, SalesvStoreWithContact>), typeof(SalesvStoreWithContactReader));

			ClassesToRegister.Add(typeof(SalesvStoreWithContactTableInfo), typeof(SalesvStoreWithContactTableInfo));
				ClassesToRegister.Add(typeof(IEntityReader<int, SalesvStoreWithDemographic>), typeof(SalesvStoreWithDemographicReader));

			ClassesToRegister.Add(typeof(SalesvStoreWithDemographicTableInfo), typeof(SalesvStoreWithDemographicTableInfo));
				ClassesToRegister.Add(typeof(IEntityReader<int, PurchasingvVendorWithAddress>), typeof(PurchasingvVendorWithAddressReader));

			ClassesToRegister.Add(typeof(PurchasingvVendorWithAddressTableInfo), typeof(PurchasingvVendorWithAddressTableInfo));
				ClassesToRegister.Add(typeof(IEntityReader<int, PurchasingvVendorWithContact>), typeof(PurchasingvVendorWithContactReader));

			ClassesToRegister.Add(typeof(PurchasingvVendorWithContactTableInfo), typeof(PurchasingvVendorWithContactTableInfo));
				ClassesToRegister.Add(typeof(IEntityReader<int, ProductionWorkOrder>), typeof(ProductionWorkOrderReader));
			ClassesToRegister.Add(typeof(IEntityWriter<int, ProductionWorkOrder>), typeof(ProductionWorkOrderWriter)); 
			ClassesToRegister.Add(typeof(ProductionWorkOrderTableInfo), typeof(ProductionWorkOrderTableInfo));
				ClassesToRegister.Add(typeof(IEntityReader<int, ProductionWorkOrderRouting>), typeof(ProductionWorkOrderRoutingReader));
			ClassesToRegister.Add(typeof(IEntityWriter<int, ProductionWorkOrderRouting>), typeof(ProductionWorkOrderRoutingWriter)); 
			ClassesToRegister.Add(typeof(ProductionWorkOrderRoutingTableInfo), typeof(ProductionWorkOrderRoutingTableInfo));
				
			 _readers.Add("PersonAddress", new Func<IEntityReader>(() => new PersonAddressReader
				(
					_tableInfos["PersonAddress"] as  PersonAddressTableInfo,
					ConnectionStringName,
					_executer,
					_queryBuilder,
					_joinBuilder,
					this
				)));  _readers.Add("PersonAddressType", new Func<IEntityReader>(() => new PersonAddressTypeReader
				(
					_tableInfos["PersonAddressType"] as  PersonAddressTypeTableInfo,
					ConnectionStringName,
					_executer,
					_queryBuilder,
					_joinBuilder,
					this
				)));  _readers.Add("AWBuildVersion", new Func<IEntityReader>(() => new AWBuildVersionReader
				(
					_tableInfos["AWBuildVersion"] as  AWBuildVersionTableInfo,
					ConnectionStringName,
					_executer,
					_queryBuilder,
					_joinBuilder,
					this
				)));  _readers.Add("ProductionBillOfMaterial", new Func<IEntityReader>(() => new ProductionBillOfMaterialReader
				(
					_tableInfos["ProductionBillOfMaterial"] as  ProductionBillOfMaterialTableInfo,
					ConnectionStringName,
					_executer,
					_queryBuilder,
					_joinBuilder,
					this
				)));  _readers.Add("PersonBusinessEntity", new Func<IEntityReader>(() => new PersonBusinessEntityReader
				(
					_tableInfos["PersonBusinessEntity"] as  PersonBusinessEntityTableInfo,
					ConnectionStringName,
					_executer,
					_queryBuilder,
					_joinBuilder,
					this
				)));  _readers.Add("PersonBusinessEntityAddress", new Func<IEntityReader>(() => new PersonBusinessEntityAddressReader
				(
					_tableInfos["PersonBusinessEntityAddress"] as  PersonBusinessEntityAddressTableInfo,
					ConnectionStringName,
					_executer,
					_queryBuilder,
					_joinBuilder,
					this
				)));  _readers.Add("PersonBusinessEntityContact", new Func<IEntityReader>(() => new PersonBusinessEntityContactReader
				(
					_tableInfos["PersonBusinessEntityContact"] as  PersonBusinessEntityContactTableInfo,
					ConnectionStringName,
					_executer,
					_queryBuilder,
					_joinBuilder,
					this
				)));  _readers.Add("PersonContactType", new Func<IEntityReader>(() => new PersonContactTypeReader
				(
					_tableInfos["PersonContactType"] as  PersonContactTypeTableInfo,
					ConnectionStringName,
					_executer,
					_queryBuilder,
					_joinBuilder,
					this
				)));  _readers.Add("PersonCountryRegion", new Func<IEntityReader>(() => new PersonCountryRegionReader
				(
					_tableInfos["PersonCountryRegion"] as  PersonCountryRegionTableInfo,
					ConnectionStringName,
					_executer,
					_queryBuilder,
					_joinBuilder,
					this
				)));  _readers.Add("SalesCountryRegionCurrency", new Func<IEntityReader>(() => new SalesCountryRegionCurrencyReader
				(
					_tableInfos["SalesCountryRegionCurrency"] as  SalesCountryRegionCurrencyTableInfo,
					ConnectionStringName,
					_executer,
					_queryBuilder,
					_joinBuilder,
					this
				)));  _readers.Add("SalesCreditCard", new Func<IEntityReader>(() => new SalesCreditCardReader
				(
					_tableInfos["SalesCreditCard"] as  SalesCreditCardTableInfo,
					ConnectionStringName,
					_executer,
					_queryBuilder,
					_joinBuilder,
					this
				)));  _readers.Add("ProductionCulture", new Func<IEntityReader>(() => new ProductionCultureReader
				(
					_tableInfos["ProductionCulture"] as  ProductionCultureTableInfo,
					ConnectionStringName,
					_executer,
					_queryBuilder,
					_joinBuilder,
					this
				)));  _readers.Add("SalesCurrency", new Func<IEntityReader>(() => new SalesCurrencyReader
				(
					_tableInfos["SalesCurrency"] as  SalesCurrencyTableInfo,
					ConnectionStringName,
					_executer,
					_queryBuilder,
					_joinBuilder,
					this
				)));  _readers.Add("SalesCurrencyRate", new Func<IEntityReader>(() => new SalesCurrencyRateReader
				(
					_tableInfos["SalesCurrencyRate"] as  SalesCurrencyRateTableInfo,
					ConnectionStringName,
					_executer,
					_queryBuilder,
					_joinBuilder,
					this
				)));  _readers.Add("SalesCustomer", new Func<IEntityReader>(() => new SalesCustomerReader
				(
					_tableInfos["SalesCustomer"] as  SalesCustomerTableInfo,
					ConnectionStringName,
					_executer,
					_queryBuilder,
					_joinBuilder,
					this
				)));  _readers.Add("DatabaseLog", new Func<IEntityReader>(() => new DatabaseLogReader
				(
					_tableInfos["DatabaseLog"] as  DatabaseLogTableInfo,
					ConnectionStringName,
					_executer,
					_queryBuilder,
					_joinBuilder,
					this
				)));  _readers.Add("HumanResourcesDepartment", new Func<IEntityReader>(() => new HumanResourcesDepartmentReader
				(
					_tableInfos["HumanResourcesDepartment"] as  HumanResourcesDepartmentTableInfo,
					ConnectionStringName,
					_executer,
					_queryBuilder,
					_joinBuilder,
					this
				)));  _readers.Add("ProductionDocument", new Func<IEntityReader>(() => new ProductionDocumentReader
				(
					_tableInfos["ProductionDocument"] as  ProductionDocumentTableInfo,
					ConnectionStringName,
					_executer,
					_queryBuilder,
					_joinBuilder,
					this
				)));  _readers.Add("PersonEmailAddress", new Func<IEntityReader>(() => new PersonEmailAddressReader
				(
					_tableInfos["PersonEmailAddress"] as  PersonEmailAddressTableInfo,
					ConnectionStringName,
					_executer,
					_queryBuilder,
					_joinBuilder,
					this
				)));  _readers.Add("HumanResourcesEmployee", new Func<IEntityReader>(() => new HumanResourcesEmployeeReader
				(
					_tableInfos["HumanResourcesEmployee"] as  HumanResourcesEmployeeTableInfo,
					ConnectionStringName,
					_executer,
					_queryBuilder,
					_joinBuilder,
					this
				)));  _readers.Add("HumanResourcesEmployeeDepartmentHistory", new Func<IEntityReader>(() => new HumanResourcesEmployeeDepartmentHistoryReader
				(
					_tableInfos["HumanResourcesEmployeeDepartmentHistory"] as  HumanResourcesEmployeeDepartmentHistoryTableInfo,
					ConnectionStringName,
					_executer,
					_queryBuilder,
					_joinBuilder,
					this
				)));  _readers.Add("HumanResourcesEmployeePayHistory", new Func<IEntityReader>(() => new HumanResourcesEmployeePayHistoryReader
				(
					_tableInfos["HumanResourcesEmployeePayHistory"] as  HumanResourcesEmployeePayHistoryTableInfo,
					ConnectionStringName,
					_executer,
					_queryBuilder,
					_joinBuilder,
					this
				)));  _readers.Add("ErrorLog", new Func<IEntityReader>(() => new ErrorLogReader
				(
					_tableInfos["ErrorLog"] as  ErrorLogTableInfo,
					ConnectionStringName,
					_executer,
					_queryBuilder,
					_joinBuilder,
					this
				)));  _readers.Add("ProductionIllustration", new Func<IEntityReader>(() => new ProductionIllustrationReader
				(
					_tableInfos["ProductionIllustration"] as  ProductionIllustrationTableInfo,
					ConnectionStringName,
					_executer,
					_queryBuilder,
					_joinBuilder,
					this
				)));  _readers.Add("HumanResourcesJobCandidate", new Func<IEntityReader>(() => new HumanResourcesJobCandidateReader
				(
					_tableInfos["HumanResourcesJobCandidate"] as  HumanResourcesJobCandidateTableInfo,
					ConnectionStringName,
					_executer,
					_queryBuilder,
					_joinBuilder,
					this
				)));  _readers.Add("ProductionLocation", new Func<IEntityReader>(() => new ProductionLocationReader
				(
					_tableInfos["ProductionLocation"] as  ProductionLocationTableInfo,
					ConnectionStringName,
					_executer,
					_queryBuilder,
					_joinBuilder,
					this
				)));  _readers.Add("PersonPassword", new Func<IEntityReader>(() => new PersonPasswordReader
				(
					_tableInfos["PersonPassword"] as  PersonPasswordTableInfo,
					ConnectionStringName,
					_executer,
					_queryBuilder,
					_joinBuilder,
					this
				)));  _readers.Add("PersonPerson", new Func<IEntityReader>(() => new PersonPersonReader
				(
					_tableInfos["PersonPerson"] as  PersonPersonTableInfo,
					ConnectionStringName,
					_executer,
					_queryBuilder,
					_joinBuilder,
					this
				)));  _readers.Add("SalesPersonCreditCard", new Func<IEntityReader>(() => new SalesPersonCreditCardReader
				(
					_tableInfos["SalesPersonCreditCard"] as  SalesPersonCreditCardTableInfo,
					ConnectionStringName,
					_executer,
					_queryBuilder,
					_joinBuilder,
					this
				)));  _readers.Add("PersonPersonPhone", new Func<IEntityReader>(() => new PersonPersonPhoneReader
				(
					_tableInfos["PersonPersonPhone"] as  PersonPersonPhoneTableInfo,
					ConnectionStringName,
					_executer,
					_queryBuilder,
					_joinBuilder,
					this
				)));  _readers.Add("PersonPhoneNumberType", new Func<IEntityReader>(() => new PersonPhoneNumberTypeReader
				(
					_tableInfos["PersonPhoneNumberType"] as  PersonPhoneNumberTypeTableInfo,
					ConnectionStringName,
					_executer,
					_queryBuilder,
					_joinBuilder,
					this
				)));  _readers.Add("ProductionProduct", new Func<IEntityReader>(() => new ProductionProductReader
				(
					_tableInfos["ProductionProduct"] as  ProductionProductTableInfo,
					ConnectionStringName,
					_executer,
					_queryBuilder,
					_joinBuilder,
					this
				)));  _readers.Add("ProductionProductCategory", new Func<IEntityReader>(() => new ProductionProductCategoryReader
				(
					_tableInfos["ProductionProductCategory"] as  ProductionProductCategoryTableInfo,
					ConnectionStringName,
					_executer,
					_queryBuilder,
					_joinBuilder,
					this
				)));  _readers.Add("ProductionProductCostHistory", new Func<IEntityReader>(() => new ProductionProductCostHistoryReader
				(
					_tableInfos["ProductionProductCostHistory"] as  ProductionProductCostHistoryTableInfo,
					ConnectionStringName,
					_executer,
					_queryBuilder,
					_joinBuilder,
					this
				)));  _readers.Add("ProductionProductDescription", new Func<IEntityReader>(() => new ProductionProductDescriptionReader
				(
					_tableInfos["ProductionProductDescription"] as  ProductionProductDescriptionTableInfo,
					ConnectionStringName,
					_executer,
					_queryBuilder,
					_joinBuilder,
					this
				)));  _readers.Add("ProductionProductDocument", new Func<IEntityReader>(() => new ProductionProductDocumentReader
				(
					_tableInfos["ProductionProductDocument"] as  ProductionProductDocumentTableInfo,
					ConnectionStringName,
					_executer,
					_queryBuilder,
					_joinBuilder,
					this
				)));  _readers.Add("ProductionProductInventory", new Func<IEntityReader>(() => new ProductionProductInventoryReader
				(
					_tableInfos["ProductionProductInventory"] as  ProductionProductInventoryTableInfo,
					ConnectionStringName,
					_executer,
					_queryBuilder,
					_joinBuilder,
					this
				)));  _readers.Add("ProductionProductListPriceHistory", new Func<IEntityReader>(() => new ProductionProductListPriceHistoryReader
				(
					_tableInfos["ProductionProductListPriceHistory"] as  ProductionProductListPriceHistoryTableInfo,
					ConnectionStringName,
					_executer,
					_queryBuilder,
					_joinBuilder,
					this
				)));  _readers.Add("ProductionProductModel", new Func<IEntityReader>(() => new ProductionProductModelReader
				(
					_tableInfos["ProductionProductModel"] as  ProductionProductModelTableInfo,
					ConnectionStringName,
					_executer,
					_queryBuilder,
					_joinBuilder,
					this
				)));  _readers.Add("ProductionProductModelIllustration", new Func<IEntityReader>(() => new ProductionProductModelIllustrationReader
				(
					_tableInfos["ProductionProductModelIllustration"] as  ProductionProductModelIllustrationTableInfo,
					ConnectionStringName,
					_executer,
					_queryBuilder,
					_joinBuilder,
					this
				)));  _readers.Add("ProductionProductModelProductDescriptionCulture", new Func<IEntityReader>(() => new ProductionProductModelProductDescriptionCultureReader
				(
					_tableInfos["ProductionProductModelProductDescriptionCulture"] as  ProductionProductModelProductDescriptionCultureTableInfo,
					ConnectionStringName,
					_executer,
					_queryBuilder,
					_joinBuilder,
					this
				)));  _readers.Add("ProductionProductPhoto", new Func<IEntityReader>(() => new ProductionProductPhotoReader
				(
					_tableInfos["ProductionProductPhoto"] as  ProductionProductPhotoTableInfo,
					ConnectionStringName,
					_executer,
					_queryBuilder,
					_joinBuilder,
					this
				)));  _readers.Add("ProductionProductProductPhoto", new Func<IEntityReader>(() => new ProductionProductProductPhotoReader
				(
					_tableInfos["ProductionProductProductPhoto"] as  ProductionProductProductPhotoTableInfo,
					ConnectionStringName,
					_executer,
					_queryBuilder,
					_joinBuilder,
					this
				)));  _readers.Add("ProductionProductReview", new Func<IEntityReader>(() => new ProductionProductReviewReader
				(
					_tableInfos["ProductionProductReview"] as  ProductionProductReviewTableInfo,
					ConnectionStringName,
					_executer,
					_queryBuilder,
					_joinBuilder,
					this
				)));  _readers.Add("ProductionProductSubcategory", new Func<IEntityReader>(() => new ProductionProductSubcategoryReader
				(
					_tableInfos["ProductionProductSubcategory"] as  ProductionProductSubcategoryTableInfo,
					ConnectionStringName,
					_executer,
					_queryBuilder,
					_joinBuilder,
					this
				)));  _readers.Add("PurchasingProductVendor", new Func<IEntityReader>(() => new PurchasingProductVendorReader
				(
					_tableInfos["PurchasingProductVendor"] as  PurchasingProductVendorTableInfo,
					ConnectionStringName,
					_executer,
					_queryBuilder,
					_joinBuilder,
					this
				)));  _readers.Add("PurchasingPurchaseOrderDetail", new Func<IEntityReader>(() => new PurchasingPurchaseOrderDetailReader
				(
					_tableInfos["PurchasingPurchaseOrderDetail"] as  PurchasingPurchaseOrderDetailTableInfo,
					ConnectionStringName,
					_executer,
					_queryBuilder,
					_joinBuilder,
					this
				)));  _readers.Add("PurchasingPurchaseOrderHeader", new Func<IEntityReader>(() => new PurchasingPurchaseOrderHeaderReader
				(
					_tableInfos["PurchasingPurchaseOrderHeader"] as  PurchasingPurchaseOrderHeaderTableInfo,
					ConnectionStringName,
					_executer,
					_queryBuilder,
					_joinBuilder,
					this
				)));  _readers.Add("SalesSalesOrderDetail", new Func<IEntityReader>(() => new SalesSalesOrderDetailReader
				(
					_tableInfos["SalesSalesOrderDetail"] as  SalesSalesOrderDetailTableInfo,
					ConnectionStringName,
					_executer,
					_queryBuilder,
					_joinBuilder,
					this
				)));  _readers.Add("SalesSalesOrderHeader", new Func<IEntityReader>(() => new SalesSalesOrderHeaderReader
				(
					_tableInfos["SalesSalesOrderHeader"] as  SalesSalesOrderHeaderTableInfo,
					ConnectionStringName,
					_executer,
					_queryBuilder,
					_joinBuilder,
					this
				)));  _readers.Add("SalesSalesOrderHeaderSalesReason", new Func<IEntityReader>(() => new SalesSalesOrderHeaderSalesReasonReader
				(
					_tableInfos["SalesSalesOrderHeaderSalesReason"] as  SalesSalesOrderHeaderSalesReasonTableInfo,
					ConnectionStringName,
					_executer,
					_queryBuilder,
					_joinBuilder,
					this
				)));  _readers.Add("SalesSalesPerson", new Func<IEntityReader>(() => new SalesSalesPersonReader
				(
					_tableInfos["SalesSalesPerson"] as  SalesSalesPersonTableInfo,
					ConnectionStringName,
					_executer,
					_queryBuilder,
					_joinBuilder,
					this
				)));  _readers.Add("SalesSalesPersonQuotaHistory", new Func<IEntityReader>(() => new SalesSalesPersonQuotaHistoryReader
				(
					_tableInfos["SalesSalesPersonQuotaHistory"] as  SalesSalesPersonQuotaHistoryTableInfo,
					ConnectionStringName,
					_executer,
					_queryBuilder,
					_joinBuilder,
					this
				)));  _readers.Add("SalesSalesReason", new Func<IEntityReader>(() => new SalesSalesReasonReader
				(
					_tableInfos["SalesSalesReason"] as  SalesSalesReasonTableInfo,
					ConnectionStringName,
					_executer,
					_queryBuilder,
					_joinBuilder,
					this
				)));  _readers.Add("SalesSalesTaxRate", new Func<IEntityReader>(() => new SalesSalesTaxRateReader
				(
					_tableInfos["SalesSalesTaxRate"] as  SalesSalesTaxRateTableInfo,
					ConnectionStringName,
					_executer,
					_queryBuilder,
					_joinBuilder,
					this
				)));  _readers.Add("SalesSalesTerritory", new Func<IEntityReader>(() => new SalesSalesTerritoryReader
				(
					_tableInfos["SalesSalesTerritory"] as  SalesSalesTerritoryTableInfo,
					ConnectionStringName,
					_executer,
					_queryBuilder,
					_joinBuilder,
					this
				)));  _readers.Add("SalesSalesTerritoryHistory", new Func<IEntityReader>(() => new SalesSalesTerritoryHistoryReader
				(
					_tableInfos["SalesSalesTerritoryHistory"] as  SalesSalesTerritoryHistoryTableInfo,
					ConnectionStringName,
					_executer,
					_queryBuilder,
					_joinBuilder,
					this
				)));  _readers.Add("ProductionScrapReason", new Func<IEntityReader>(() => new ProductionScrapReasonReader
				(
					_tableInfos["ProductionScrapReason"] as  ProductionScrapReasonTableInfo,
					ConnectionStringName,
					_executer,
					_queryBuilder,
					_joinBuilder,
					this
				)));  _readers.Add("HumanResourcesShift", new Func<IEntityReader>(() => new HumanResourcesShiftReader
				(
					_tableInfos["HumanResourcesShift"] as  HumanResourcesShiftTableInfo,
					ConnectionStringName,
					_executer,
					_queryBuilder,
					_joinBuilder,
					this
				)));  _readers.Add("PurchasingShipMethod", new Func<IEntityReader>(() => new PurchasingShipMethodReader
				(
					_tableInfos["PurchasingShipMethod"] as  PurchasingShipMethodTableInfo,
					ConnectionStringName,
					_executer,
					_queryBuilder,
					_joinBuilder,
					this
				)));  _readers.Add("SalesShoppingCartItem", new Func<IEntityReader>(() => new SalesShoppingCartItemReader
				(
					_tableInfos["SalesShoppingCartItem"] as  SalesShoppingCartItemTableInfo,
					ConnectionStringName,
					_executer,
					_queryBuilder,
					_joinBuilder,
					this
				)));  _readers.Add("SalesSpecialOffer", new Func<IEntityReader>(() => new SalesSpecialOfferReader
				(
					_tableInfos["SalesSpecialOffer"] as  SalesSpecialOfferTableInfo,
					ConnectionStringName,
					_executer,
					_queryBuilder,
					_joinBuilder,
					this
				)));  _readers.Add("SalesSpecialOfferProduct", new Func<IEntityReader>(() => new SalesSpecialOfferProductReader
				(
					_tableInfos["SalesSpecialOfferProduct"] as  SalesSpecialOfferProductTableInfo,
					ConnectionStringName,
					_executer,
					_queryBuilder,
					_joinBuilder,
					this
				)));  _readers.Add("PersonStateProvince", new Func<IEntityReader>(() => new PersonStateProvinceReader
				(
					_tableInfos["PersonStateProvince"] as  PersonStateProvinceTableInfo,
					ConnectionStringName,
					_executer,
					_queryBuilder,
					_joinBuilder,
					this
				)));  _readers.Add("SalesStore", new Func<IEntityReader>(() => new SalesStoreReader
				(
					_tableInfos["SalesStore"] as  SalesStoreTableInfo,
					ConnectionStringName,
					_executer,
					_queryBuilder,
					_joinBuilder,
					this
				)));  _readers.Add("ProductionTransactionHistory", new Func<IEntityReader>(() => new ProductionTransactionHistoryReader
				(
					_tableInfos["ProductionTransactionHistory"] as  ProductionTransactionHistoryTableInfo,
					ConnectionStringName,
					_executer,
					_queryBuilder,
					_joinBuilder,
					this
				)));  _readers.Add("ProductionTransactionHistoryArchive", new Func<IEntityReader>(() => new ProductionTransactionHistoryArchiveReader
				(
					_tableInfos["ProductionTransactionHistoryArchive"] as  ProductionTransactionHistoryArchiveTableInfo,
					ConnectionStringName,
					_executer,
					_queryBuilder,
					_joinBuilder,
					this
				)));  _readers.Add("ProductionUnitMeasure", new Func<IEntityReader>(() => new ProductionUnitMeasureReader
				(
					_tableInfos["ProductionUnitMeasure"] as  ProductionUnitMeasureTableInfo,
					ConnectionStringName,
					_executer,
					_queryBuilder,
					_joinBuilder,
					this
				)));  _readers.Add("PersonvAdditionalContactInfo", new Func<IEntityReader>(() => new PersonvAdditionalContactInfoReader
				(
					_tableInfos["PersonvAdditionalContactInfo"] as  PersonvAdditionalContactInfoTableInfo,
					ConnectionStringName,
					_executer,
					_queryBuilder,
					_joinBuilder,
					this
				)));  _readers.Add("HumanResourcesvEmployee", new Func<IEntityReader>(() => new HumanResourcesvEmployeeReader
				(
					_tableInfos["HumanResourcesvEmployee"] as  HumanResourcesvEmployeeTableInfo,
					ConnectionStringName,
					_executer,
					_queryBuilder,
					_joinBuilder,
					this
				)));  _readers.Add("HumanResourcesvEmployeeDepartment", new Func<IEntityReader>(() => new HumanResourcesvEmployeeDepartmentReader
				(
					_tableInfos["HumanResourcesvEmployeeDepartment"] as  HumanResourcesvEmployeeDepartmentTableInfo,
					ConnectionStringName,
					_executer,
					_queryBuilder,
					_joinBuilder,
					this
				)));  _readers.Add("HumanResourcesvEmployeeDepartmentHistory", new Func<IEntityReader>(() => new HumanResourcesvEmployeeDepartmentHistoryReader
				(
					_tableInfos["HumanResourcesvEmployeeDepartmentHistory"] as  HumanResourcesvEmployeeDepartmentHistoryTableInfo,
					ConnectionStringName,
					_executer,
					_queryBuilder,
					_joinBuilder,
					this
				)));  _readers.Add("PurchasingVendor", new Func<IEntityReader>(() => new PurchasingVendorReader
				(
					_tableInfos["PurchasingVendor"] as  PurchasingVendorTableInfo,
					ConnectionStringName,
					_executer,
					_queryBuilder,
					_joinBuilder,
					this
				)));  _readers.Add("SalesvIndividualCustomer", new Func<IEntityReader>(() => new SalesvIndividualCustomerReader
				(
					_tableInfos["SalesvIndividualCustomer"] as  SalesvIndividualCustomerTableInfo,
					ConnectionStringName,
					_executer,
					_queryBuilder,
					_joinBuilder,
					this
				)));  _readers.Add("HumanResourcesvJobCandidate", new Func<IEntityReader>(() => new HumanResourcesvJobCandidateReader
				(
					_tableInfos["HumanResourcesvJobCandidate"] as  HumanResourcesvJobCandidateTableInfo,
					ConnectionStringName,
					_executer,
					_queryBuilder,
					_joinBuilder,
					this
				)));  _readers.Add("HumanResourcesvJobCandidateEducation", new Func<IEntityReader>(() => new HumanResourcesvJobCandidateEducationReader
				(
					_tableInfos["HumanResourcesvJobCandidateEducation"] as  HumanResourcesvJobCandidateEducationTableInfo,
					ConnectionStringName,
					_executer,
					_queryBuilder,
					_joinBuilder,
					this
				)));  _readers.Add("HumanResourcesvJobCandidateEmployment", new Func<IEntityReader>(() => new HumanResourcesvJobCandidateEmploymentReader
				(
					_tableInfos["HumanResourcesvJobCandidateEmployment"] as  HumanResourcesvJobCandidateEmploymentTableInfo,
					ConnectionStringName,
					_executer,
					_queryBuilder,
					_joinBuilder,
					this
				)));  _readers.Add("SalesvPersonDemographic", new Func<IEntityReader>(() => new SalesvPersonDemographicReader
				(
					_tableInfos["SalesvPersonDemographic"] as  SalesvPersonDemographicTableInfo,
					ConnectionStringName,
					_executer,
					_queryBuilder,
					_joinBuilder,
					this
				)));  _readers.Add("ProductionvProductAndDescription", new Func<IEntityReader>(() => new ProductionvProductAndDescriptionReader
				(
					_tableInfos["ProductionvProductAndDescription"] as  ProductionvProductAndDescriptionTableInfo,
					ConnectionStringName,
					_executer,
					_queryBuilder,
					_joinBuilder,
					this
				)));  _readers.Add("ProductionvProductModelCatalogDescription", new Func<IEntityReader>(() => new ProductionvProductModelCatalogDescriptionReader
				(
					_tableInfos["ProductionvProductModelCatalogDescription"] as  ProductionvProductModelCatalogDescriptionTableInfo,
					ConnectionStringName,
					_executer,
					_queryBuilder,
					_joinBuilder,
					this
				)));  _readers.Add("ProductionvProductModelInstruction", new Func<IEntityReader>(() => new ProductionvProductModelInstructionReader
				(
					_tableInfos["ProductionvProductModelInstruction"] as  ProductionvProductModelInstructionTableInfo,
					ConnectionStringName,
					_executer,
					_queryBuilder,
					_joinBuilder,
					this
				)));  _readers.Add("SalesvSalesPerson", new Func<IEntityReader>(() => new SalesvSalesPersonReader
				(
					_tableInfos["SalesvSalesPerson"] as  SalesvSalesPersonTableInfo,
					ConnectionStringName,
					_executer,
					_queryBuilder,
					_joinBuilder,
					this
				)));  _readers.Add("SalesvSalesPersonSalesByFiscalYear", new Func<IEntityReader>(() => new SalesvSalesPersonSalesByFiscalYearReader
				(
					_tableInfos["SalesvSalesPersonSalesByFiscalYear"] as  SalesvSalesPersonSalesByFiscalYearTableInfo,
					ConnectionStringName,
					_executer,
					_queryBuilder,
					_joinBuilder,
					this
				)));  _readers.Add("PersonvStateProvinceCountryRegion", new Func<IEntityReader>(() => new PersonvStateProvinceCountryRegionReader
				(
					_tableInfos["PersonvStateProvinceCountryRegion"] as  PersonvStateProvinceCountryRegionTableInfo,
					ConnectionStringName,
					_executer,
					_queryBuilder,
					_joinBuilder,
					this
				)));  _readers.Add("SalesvStoreWithAddress", new Func<IEntityReader>(() => new SalesvStoreWithAddressReader
				(
					_tableInfos["SalesvStoreWithAddress"] as  SalesvStoreWithAddressTableInfo,
					ConnectionStringName,
					_executer,
					_queryBuilder,
					_joinBuilder,
					this
				)));  _readers.Add("SalesvStoreWithContact", new Func<IEntityReader>(() => new SalesvStoreWithContactReader
				(
					_tableInfos["SalesvStoreWithContact"] as  SalesvStoreWithContactTableInfo,
					ConnectionStringName,
					_executer,
					_queryBuilder,
					_joinBuilder,
					this
				)));  _readers.Add("SalesvStoreWithDemographic", new Func<IEntityReader>(() => new SalesvStoreWithDemographicReader
				(
					_tableInfos["SalesvStoreWithDemographic"] as  SalesvStoreWithDemographicTableInfo,
					ConnectionStringName,
					_executer,
					_queryBuilder,
					_joinBuilder,
					this
				)));  _readers.Add("PurchasingvVendorWithAddress", new Func<IEntityReader>(() => new PurchasingvVendorWithAddressReader
				(
					_tableInfos["PurchasingvVendorWithAddress"] as  PurchasingvVendorWithAddressTableInfo,
					ConnectionStringName,
					_executer,
					_queryBuilder,
					_joinBuilder,
					this
				)));  _readers.Add("PurchasingvVendorWithContact", new Func<IEntityReader>(() => new PurchasingvVendorWithContactReader
				(
					_tableInfos["PurchasingvVendorWithContact"] as  PurchasingvVendorWithContactTableInfo,
					ConnectionStringName,
					_executer,
					_queryBuilder,
					_joinBuilder,
					this
				)));  _readers.Add("ProductionWorkOrder", new Func<IEntityReader>(() => new ProductionWorkOrderReader
				(
					_tableInfos["ProductionWorkOrder"] as  ProductionWorkOrderTableInfo,
					ConnectionStringName,
					_executer,
					_queryBuilder,
					_joinBuilder,
					this
				)));  _readers.Add("ProductionWorkOrderRouting", new Func<IEntityReader>(() => new ProductionWorkOrderRoutingReader
				(
					_tableInfos["ProductionWorkOrderRouting"] as  ProductionWorkOrderRoutingTableInfo,
					ConnectionStringName,
					_executer,
					_queryBuilder,
					_joinBuilder,
					this
				))); 
			 _writers.Add("PersonAddress", new Func<IEntityWriter>(() => new PersonAddressWriter
				(
					_tableInfos["PersonAddress"] as  PersonAddressTableInfo,
					ConnectionStringName,
					_executer,
					_queryBuilder,
					_joinBuilder,
					this
				)));  _writers.Add("PersonAddressType", new Func<IEntityWriter>(() => new PersonAddressTypeWriter
				(
					_tableInfos["PersonAddressType"] as  PersonAddressTypeTableInfo,
					ConnectionStringName,
					_executer,
					_queryBuilder,
					_joinBuilder,
					this
				)));  _writers.Add("AWBuildVersion", new Func<IEntityWriter>(() => new AWBuildVersionWriter
				(
					_tableInfos["AWBuildVersion"] as  AWBuildVersionTableInfo,
					ConnectionStringName,
					_executer,
					_queryBuilder,
					_joinBuilder,
					this
				)));  _writers.Add("ProductionBillOfMaterial", new Func<IEntityWriter>(() => new ProductionBillOfMaterialWriter
				(
					_tableInfos["ProductionBillOfMaterial"] as  ProductionBillOfMaterialTableInfo,
					ConnectionStringName,
					_executer,
					_queryBuilder,
					_joinBuilder,
					this
				)));  _writers.Add("PersonBusinessEntity", new Func<IEntityWriter>(() => new PersonBusinessEntityWriter
				(
					_tableInfos["PersonBusinessEntity"] as  PersonBusinessEntityTableInfo,
					ConnectionStringName,
					_executer,
					_queryBuilder,
					_joinBuilder,
					this
				)));  _writers.Add("PersonBusinessEntityAddress", new Func<IEntityWriter>(() => new PersonBusinessEntityAddressWriter
				(
					_tableInfos["PersonBusinessEntityAddress"] as  PersonBusinessEntityAddressTableInfo,
					ConnectionStringName,
					_executer,
					_queryBuilder,
					_joinBuilder,
					this
				)));  _writers.Add("PersonBusinessEntityContact", new Func<IEntityWriter>(() => new PersonBusinessEntityContactWriter
				(
					_tableInfos["PersonBusinessEntityContact"] as  PersonBusinessEntityContactTableInfo,
					ConnectionStringName,
					_executer,
					_queryBuilder,
					_joinBuilder,
					this
				)));  _writers.Add("PersonContactType", new Func<IEntityWriter>(() => new PersonContactTypeWriter
				(
					_tableInfos["PersonContactType"] as  PersonContactTypeTableInfo,
					ConnectionStringName,
					_executer,
					_queryBuilder,
					_joinBuilder,
					this
				)));  _writers.Add("PersonCountryRegion", new Func<IEntityWriter>(() => new PersonCountryRegionWriter
				(
					_tableInfos["PersonCountryRegion"] as  PersonCountryRegionTableInfo,
					ConnectionStringName,
					_executer,
					_queryBuilder,
					_joinBuilder,
					this
				)));  _writers.Add("SalesCountryRegionCurrency", new Func<IEntityWriter>(() => new SalesCountryRegionCurrencyWriter
				(
					_tableInfos["SalesCountryRegionCurrency"] as  SalesCountryRegionCurrencyTableInfo,
					ConnectionStringName,
					_executer,
					_queryBuilder,
					_joinBuilder,
					this
				)));  _writers.Add("SalesCreditCard", new Func<IEntityWriter>(() => new SalesCreditCardWriter
				(
					_tableInfos["SalesCreditCard"] as  SalesCreditCardTableInfo,
					ConnectionStringName,
					_executer,
					_queryBuilder,
					_joinBuilder,
					this
				)));  _writers.Add("ProductionCulture", new Func<IEntityWriter>(() => new ProductionCultureWriter
				(
					_tableInfos["ProductionCulture"] as  ProductionCultureTableInfo,
					ConnectionStringName,
					_executer,
					_queryBuilder,
					_joinBuilder,
					this
				)));  _writers.Add("SalesCurrency", new Func<IEntityWriter>(() => new SalesCurrencyWriter
				(
					_tableInfos["SalesCurrency"] as  SalesCurrencyTableInfo,
					ConnectionStringName,
					_executer,
					_queryBuilder,
					_joinBuilder,
					this
				)));  _writers.Add("SalesCurrencyRate", new Func<IEntityWriter>(() => new SalesCurrencyRateWriter
				(
					_tableInfos["SalesCurrencyRate"] as  SalesCurrencyRateTableInfo,
					ConnectionStringName,
					_executer,
					_queryBuilder,
					_joinBuilder,
					this
				)));  _writers.Add("SalesCustomer", new Func<IEntityWriter>(() => new SalesCustomerWriter
				(
					_tableInfos["SalesCustomer"] as  SalesCustomerTableInfo,
					ConnectionStringName,
					_executer,
					_queryBuilder,
					_joinBuilder,
					this
				)));  _writers.Add("DatabaseLog", new Func<IEntityWriter>(() => new DatabaseLogWriter
				(
					_tableInfos["DatabaseLog"] as  DatabaseLogTableInfo,
					ConnectionStringName,
					_executer,
					_queryBuilder,
					_joinBuilder,
					this
				)));  _writers.Add("HumanResourcesDepartment", new Func<IEntityWriter>(() => new HumanResourcesDepartmentWriter
				(
					_tableInfos["HumanResourcesDepartment"] as  HumanResourcesDepartmentTableInfo,
					ConnectionStringName,
					_executer,
					_queryBuilder,
					_joinBuilder,
					this
				)));  _writers.Add("ProductionDocument", new Func<IEntityWriter>(() => new ProductionDocumentWriter
				(
					_tableInfos["ProductionDocument"] as  ProductionDocumentTableInfo,
					ConnectionStringName,
					_executer,
					_queryBuilder,
					_joinBuilder,
					this
				)));  _writers.Add("PersonEmailAddress", new Func<IEntityWriter>(() => new PersonEmailAddressWriter
				(
					_tableInfos["PersonEmailAddress"] as  PersonEmailAddressTableInfo,
					ConnectionStringName,
					_executer,
					_queryBuilder,
					_joinBuilder,
					this
				)));  _writers.Add("HumanResourcesEmployee", new Func<IEntityWriter>(() => new HumanResourcesEmployeeWriter
				(
					_tableInfos["HumanResourcesEmployee"] as  HumanResourcesEmployeeTableInfo,
					ConnectionStringName,
					_executer,
					_queryBuilder,
					_joinBuilder,
					this
				)));  _writers.Add("HumanResourcesEmployeeDepartmentHistory", new Func<IEntityWriter>(() => new HumanResourcesEmployeeDepartmentHistoryWriter
				(
					_tableInfos["HumanResourcesEmployeeDepartmentHistory"] as  HumanResourcesEmployeeDepartmentHistoryTableInfo,
					ConnectionStringName,
					_executer,
					_queryBuilder,
					_joinBuilder,
					this
				)));  _writers.Add("HumanResourcesEmployeePayHistory", new Func<IEntityWriter>(() => new HumanResourcesEmployeePayHistoryWriter
				(
					_tableInfos["HumanResourcesEmployeePayHistory"] as  HumanResourcesEmployeePayHistoryTableInfo,
					ConnectionStringName,
					_executer,
					_queryBuilder,
					_joinBuilder,
					this
				)));  _writers.Add("ErrorLog", new Func<IEntityWriter>(() => new ErrorLogWriter
				(
					_tableInfos["ErrorLog"] as  ErrorLogTableInfo,
					ConnectionStringName,
					_executer,
					_queryBuilder,
					_joinBuilder,
					this
				)));  _writers.Add("ProductionIllustration", new Func<IEntityWriter>(() => new ProductionIllustrationWriter
				(
					_tableInfos["ProductionIllustration"] as  ProductionIllustrationTableInfo,
					ConnectionStringName,
					_executer,
					_queryBuilder,
					_joinBuilder,
					this
				)));  _writers.Add("HumanResourcesJobCandidate", new Func<IEntityWriter>(() => new HumanResourcesJobCandidateWriter
				(
					_tableInfos["HumanResourcesJobCandidate"] as  HumanResourcesJobCandidateTableInfo,
					ConnectionStringName,
					_executer,
					_queryBuilder,
					_joinBuilder,
					this
				)));  _writers.Add("ProductionLocation", new Func<IEntityWriter>(() => new ProductionLocationWriter
				(
					_tableInfos["ProductionLocation"] as  ProductionLocationTableInfo,
					ConnectionStringName,
					_executer,
					_queryBuilder,
					_joinBuilder,
					this
				)));  _writers.Add("PersonPassword", new Func<IEntityWriter>(() => new PersonPasswordWriter
				(
					_tableInfos["PersonPassword"] as  PersonPasswordTableInfo,
					ConnectionStringName,
					_executer,
					_queryBuilder,
					_joinBuilder,
					this
				)));  _writers.Add("PersonPerson", new Func<IEntityWriter>(() => new PersonPersonWriter
				(
					_tableInfos["PersonPerson"] as  PersonPersonTableInfo,
					ConnectionStringName,
					_executer,
					_queryBuilder,
					_joinBuilder,
					this
				)));  _writers.Add("SalesPersonCreditCard", new Func<IEntityWriter>(() => new SalesPersonCreditCardWriter
				(
					_tableInfos["SalesPersonCreditCard"] as  SalesPersonCreditCardTableInfo,
					ConnectionStringName,
					_executer,
					_queryBuilder,
					_joinBuilder,
					this
				)));  _writers.Add("PersonPersonPhone", new Func<IEntityWriter>(() => new PersonPersonPhoneWriter
				(
					_tableInfos["PersonPersonPhone"] as  PersonPersonPhoneTableInfo,
					ConnectionStringName,
					_executer,
					_queryBuilder,
					_joinBuilder,
					this
				)));  _writers.Add("PersonPhoneNumberType", new Func<IEntityWriter>(() => new PersonPhoneNumberTypeWriter
				(
					_tableInfos["PersonPhoneNumberType"] as  PersonPhoneNumberTypeTableInfo,
					ConnectionStringName,
					_executer,
					_queryBuilder,
					_joinBuilder,
					this
				)));  _writers.Add("ProductionProduct", new Func<IEntityWriter>(() => new ProductionProductWriter
				(
					_tableInfos["ProductionProduct"] as  ProductionProductTableInfo,
					ConnectionStringName,
					_executer,
					_queryBuilder,
					_joinBuilder,
					this
				)));  _writers.Add("ProductionProductCategory", new Func<IEntityWriter>(() => new ProductionProductCategoryWriter
				(
					_tableInfos["ProductionProductCategory"] as  ProductionProductCategoryTableInfo,
					ConnectionStringName,
					_executer,
					_queryBuilder,
					_joinBuilder,
					this
				)));  _writers.Add("ProductionProductCostHistory", new Func<IEntityWriter>(() => new ProductionProductCostHistoryWriter
				(
					_tableInfos["ProductionProductCostHistory"] as  ProductionProductCostHistoryTableInfo,
					ConnectionStringName,
					_executer,
					_queryBuilder,
					_joinBuilder,
					this
				)));  _writers.Add("ProductionProductDescription", new Func<IEntityWriter>(() => new ProductionProductDescriptionWriter
				(
					_tableInfos["ProductionProductDescription"] as  ProductionProductDescriptionTableInfo,
					ConnectionStringName,
					_executer,
					_queryBuilder,
					_joinBuilder,
					this
				)));  _writers.Add("ProductionProductDocument", new Func<IEntityWriter>(() => new ProductionProductDocumentWriter
				(
					_tableInfos["ProductionProductDocument"] as  ProductionProductDocumentTableInfo,
					ConnectionStringName,
					_executer,
					_queryBuilder,
					_joinBuilder,
					this
				)));  _writers.Add("ProductionProductInventory", new Func<IEntityWriter>(() => new ProductionProductInventoryWriter
				(
					_tableInfos["ProductionProductInventory"] as  ProductionProductInventoryTableInfo,
					ConnectionStringName,
					_executer,
					_queryBuilder,
					_joinBuilder,
					this
				)));  _writers.Add("ProductionProductListPriceHistory", new Func<IEntityWriter>(() => new ProductionProductListPriceHistoryWriter
				(
					_tableInfos["ProductionProductListPriceHistory"] as  ProductionProductListPriceHistoryTableInfo,
					ConnectionStringName,
					_executer,
					_queryBuilder,
					_joinBuilder,
					this
				)));  _writers.Add("ProductionProductModel", new Func<IEntityWriter>(() => new ProductionProductModelWriter
				(
					_tableInfos["ProductionProductModel"] as  ProductionProductModelTableInfo,
					ConnectionStringName,
					_executer,
					_queryBuilder,
					_joinBuilder,
					this
				)));  _writers.Add("ProductionProductModelIllustration", new Func<IEntityWriter>(() => new ProductionProductModelIllustrationWriter
				(
					_tableInfos["ProductionProductModelIllustration"] as  ProductionProductModelIllustrationTableInfo,
					ConnectionStringName,
					_executer,
					_queryBuilder,
					_joinBuilder,
					this
				)));  _writers.Add("ProductionProductModelProductDescriptionCulture", new Func<IEntityWriter>(() => new ProductionProductModelProductDescriptionCultureWriter
				(
					_tableInfos["ProductionProductModelProductDescriptionCulture"] as  ProductionProductModelProductDescriptionCultureTableInfo,
					ConnectionStringName,
					_executer,
					_queryBuilder,
					_joinBuilder,
					this
				)));  _writers.Add("ProductionProductPhoto", new Func<IEntityWriter>(() => new ProductionProductPhotoWriter
				(
					_tableInfos["ProductionProductPhoto"] as  ProductionProductPhotoTableInfo,
					ConnectionStringName,
					_executer,
					_queryBuilder,
					_joinBuilder,
					this
				)));  _writers.Add("ProductionProductProductPhoto", new Func<IEntityWriter>(() => new ProductionProductProductPhotoWriter
				(
					_tableInfos["ProductionProductProductPhoto"] as  ProductionProductProductPhotoTableInfo,
					ConnectionStringName,
					_executer,
					_queryBuilder,
					_joinBuilder,
					this
				)));  _writers.Add("ProductionProductReview", new Func<IEntityWriter>(() => new ProductionProductReviewWriter
				(
					_tableInfos["ProductionProductReview"] as  ProductionProductReviewTableInfo,
					ConnectionStringName,
					_executer,
					_queryBuilder,
					_joinBuilder,
					this
				)));  _writers.Add("ProductionProductSubcategory", new Func<IEntityWriter>(() => new ProductionProductSubcategoryWriter
				(
					_tableInfos["ProductionProductSubcategory"] as  ProductionProductSubcategoryTableInfo,
					ConnectionStringName,
					_executer,
					_queryBuilder,
					_joinBuilder,
					this
				)));  _writers.Add("PurchasingProductVendor", new Func<IEntityWriter>(() => new PurchasingProductVendorWriter
				(
					_tableInfos["PurchasingProductVendor"] as  PurchasingProductVendorTableInfo,
					ConnectionStringName,
					_executer,
					_queryBuilder,
					_joinBuilder,
					this
				)));  _writers.Add("PurchasingPurchaseOrderDetail", new Func<IEntityWriter>(() => new PurchasingPurchaseOrderDetailWriter
				(
					_tableInfos["PurchasingPurchaseOrderDetail"] as  PurchasingPurchaseOrderDetailTableInfo,
					ConnectionStringName,
					_executer,
					_queryBuilder,
					_joinBuilder,
					this
				)));  _writers.Add("PurchasingPurchaseOrderHeader", new Func<IEntityWriter>(() => new PurchasingPurchaseOrderHeaderWriter
				(
					_tableInfos["PurchasingPurchaseOrderHeader"] as  PurchasingPurchaseOrderHeaderTableInfo,
					ConnectionStringName,
					_executer,
					_queryBuilder,
					_joinBuilder,
					this
				)));  _writers.Add("SalesSalesOrderDetail", new Func<IEntityWriter>(() => new SalesSalesOrderDetailWriter
				(
					_tableInfos["SalesSalesOrderDetail"] as  SalesSalesOrderDetailTableInfo,
					ConnectionStringName,
					_executer,
					_queryBuilder,
					_joinBuilder,
					this
				)));  _writers.Add("SalesSalesOrderHeader", new Func<IEntityWriter>(() => new SalesSalesOrderHeaderWriter
				(
					_tableInfos["SalesSalesOrderHeader"] as  SalesSalesOrderHeaderTableInfo,
					ConnectionStringName,
					_executer,
					_queryBuilder,
					_joinBuilder,
					this
				)));  _writers.Add("SalesSalesOrderHeaderSalesReason", new Func<IEntityWriter>(() => new SalesSalesOrderHeaderSalesReasonWriter
				(
					_tableInfos["SalesSalesOrderHeaderSalesReason"] as  SalesSalesOrderHeaderSalesReasonTableInfo,
					ConnectionStringName,
					_executer,
					_queryBuilder,
					_joinBuilder,
					this
				)));  _writers.Add("SalesSalesPerson", new Func<IEntityWriter>(() => new SalesSalesPersonWriter
				(
					_tableInfos["SalesSalesPerson"] as  SalesSalesPersonTableInfo,
					ConnectionStringName,
					_executer,
					_queryBuilder,
					_joinBuilder,
					this
				)));  _writers.Add("SalesSalesPersonQuotaHistory", new Func<IEntityWriter>(() => new SalesSalesPersonQuotaHistoryWriter
				(
					_tableInfos["SalesSalesPersonQuotaHistory"] as  SalesSalesPersonQuotaHistoryTableInfo,
					ConnectionStringName,
					_executer,
					_queryBuilder,
					_joinBuilder,
					this
				)));  _writers.Add("SalesSalesReason", new Func<IEntityWriter>(() => new SalesSalesReasonWriter
				(
					_tableInfos["SalesSalesReason"] as  SalesSalesReasonTableInfo,
					ConnectionStringName,
					_executer,
					_queryBuilder,
					_joinBuilder,
					this
				)));  _writers.Add("SalesSalesTaxRate", new Func<IEntityWriter>(() => new SalesSalesTaxRateWriter
				(
					_tableInfos["SalesSalesTaxRate"] as  SalesSalesTaxRateTableInfo,
					ConnectionStringName,
					_executer,
					_queryBuilder,
					_joinBuilder,
					this
				)));  _writers.Add("SalesSalesTerritory", new Func<IEntityWriter>(() => new SalesSalesTerritoryWriter
				(
					_tableInfos["SalesSalesTerritory"] as  SalesSalesTerritoryTableInfo,
					ConnectionStringName,
					_executer,
					_queryBuilder,
					_joinBuilder,
					this
				)));  _writers.Add("SalesSalesTerritoryHistory", new Func<IEntityWriter>(() => new SalesSalesTerritoryHistoryWriter
				(
					_tableInfos["SalesSalesTerritoryHistory"] as  SalesSalesTerritoryHistoryTableInfo,
					ConnectionStringName,
					_executer,
					_queryBuilder,
					_joinBuilder,
					this
				)));  _writers.Add("ProductionScrapReason", new Func<IEntityWriter>(() => new ProductionScrapReasonWriter
				(
					_tableInfos["ProductionScrapReason"] as  ProductionScrapReasonTableInfo,
					ConnectionStringName,
					_executer,
					_queryBuilder,
					_joinBuilder,
					this
				)));  _writers.Add("HumanResourcesShift", new Func<IEntityWriter>(() => new HumanResourcesShiftWriter
				(
					_tableInfos["HumanResourcesShift"] as  HumanResourcesShiftTableInfo,
					ConnectionStringName,
					_executer,
					_queryBuilder,
					_joinBuilder,
					this
				)));  _writers.Add("PurchasingShipMethod", new Func<IEntityWriter>(() => new PurchasingShipMethodWriter
				(
					_tableInfos["PurchasingShipMethod"] as  PurchasingShipMethodTableInfo,
					ConnectionStringName,
					_executer,
					_queryBuilder,
					_joinBuilder,
					this
				)));  _writers.Add("SalesShoppingCartItem", new Func<IEntityWriter>(() => new SalesShoppingCartItemWriter
				(
					_tableInfos["SalesShoppingCartItem"] as  SalesShoppingCartItemTableInfo,
					ConnectionStringName,
					_executer,
					_queryBuilder,
					_joinBuilder,
					this
				)));  _writers.Add("SalesSpecialOffer", new Func<IEntityWriter>(() => new SalesSpecialOfferWriter
				(
					_tableInfos["SalesSpecialOffer"] as  SalesSpecialOfferTableInfo,
					ConnectionStringName,
					_executer,
					_queryBuilder,
					_joinBuilder,
					this
				)));  _writers.Add("SalesSpecialOfferProduct", new Func<IEntityWriter>(() => new SalesSpecialOfferProductWriter
				(
					_tableInfos["SalesSpecialOfferProduct"] as  SalesSpecialOfferProductTableInfo,
					ConnectionStringName,
					_executer,
					_queryBuilder,
					_joinBuilder,
					this
				)));  _writers.Add("PersonStateProvince", new Func<IEntityWriter>(() => new PersonStateProvinceWriter
				(
					_tableInfos["PersonStateProvince"] as  PersonStateProvinceTableInfo,
					ConnectionStringName,
					_executer,
					_queryBuilder,
					_joinBuilder,
					this
				)));  _writers.Add("SalesStore", new Func<IEntityWriter>(() => new SalesStoreWriter
				(
					_tableInfos["SalesStore"] as  SalesStoreTableInfo,
					ConnectionStringName,
					_executer,
					_queryBuilder,
					_joinBuilder,
					this
				)));  _writers.Add("ProductionTransactionHistory", new Func<IEntityWriter>(() => new ProductionTransactionHistoryWriter
				(
					_tableInfos["ProductionTransactionHistory"] as  ProductionTransactionHistoryTableInfo,
					ConnectionStringName,
					_executer,
					_queryBuilder,
					_joinBuilder,
					this
				)));  _writers.Add("ProductionTransactionHistoryArchive", new Func<IEntityWriter>(() => new ProductionTransactionHistoryArchiveWriter
				(
					_tableInfos["ProductionTransactionHistoryArchive"] as  ProductionTransactionHistoryArchiveTableInfo,
					ConnectionStringName,
					_executer,
					_queryBuilder,
					_joinBuilder,
					this
				)));  _writers.Add("ProductionUnitMeasure", new Func<IEntityWriter>(() => new ProductionUnitMeasureWriter
				(
					_tableInfos["ProductionUnitMeasure"] as  ProductionUnitMeasureTableInfo,
					ConnectionStringName,
					_executer,
					_queryBuilder,
					_joinBuilder,
					this
				)));  _writers.Add("PurchasingVendor", new Func<IEntityWriter>(() => new PurchasingVendorWriter
				(
					_tableInfos["PurchasingVendor"] as  PurchasingVendorTableInfo,
					ConnectionStringName,
					_executer,
					_queryBuilder,
					_joinBuilder,
					this
				)));  _writers.Add("ProductionWorkOrder", new Func<IEntityWriter>(() => new ProductionWorkOrderWriter
				(
					_tableInfos["ProductionWorkOrder"] as  ProductionWorkOrderTableInfo,
					ConnectionStringName,
					_executer,
					_queryBuilder,
					_joinBuilder,
					this
				)));  _writers.Add("ProductionWorkOrderRouting", new Func<IEntityWriter>(() => new ProductionWorkOrderRoutingWriter
				(
					_tableInfos["ProductionWorkOrderRouting"] as  ProductionWorkOrderRoutingTableInfo,
					ConnectionStringName,
					_executer,
					_queryBuilder,
					_joinBuilder,
					this
				))); 
			 
				_tableInfos.Add("PersonAddress", new PersonAddressTableInfo(this));  
				_tableInfos.Add("PersonAddressType", new PersonAddressTypeTableInfo(this));  
				_tableInfos.Add("AWBuildVersion", new AWBuildVersionTableInfo(this));  
				_tableInfos.Add("ProductionBillOfMaterial", new ProductionBillOfMaterialTableInfo(this));  
				_tableInfos.Add("PersonBusinessEntity", new PersonBusinessEntityTableInfo(this));  
				_tableInfos.Add("PersonBusinessEntityAddress", new PersonBusinessEntityAddressTableInfo(this));  
				_tableInfos.Add("PersonBusinessEntityContact", new PersonBusinessEntityContactTableInfo(this));  
				_tableInfos.Add("PersonContactType", new PersonContactTypeTableInfo(this));  
				_tableInfos.Add("PersonCountryRegion", new PersonCountryRegionTableInfo(this));  
				_tableInfos.Add("SalesCountryRegionCurrency", new SalesCountryRegionCurrencyTableInfo(this));  
				_tableInfos.Add("SalesCreditCard", new SalesCreditCardTableInfo(this));  
				_tableInfos.Add("ProductionCulture", new ProductionCultureTableInfo(this));  
				_tableInfos.Add("SalesCurrency", new SalesCurrencyTableInfo(this));  
				_tableInfos.Add("SalesCurrencyRate", new SalesCurrencyRateTableInfo(this));  
				_tableInfos.Add("SalesCustomer", new SalesCustomerTableInfo(this));  
				_tableInfos.Add("DatabaseLog", new DatabaseLogTableInfo(this));  
				_tableInfos.Add("HumanResourcesDepartment", new HumanResourcesDepartmentTableInfo(this));  
				_tableInfos.Add("ProductionDocument", new ProductionDocumentTableInfo(this));  
				_tableInfos.Add("PersonEmailAddress", new PersonEmailAddressTableInfo(this));  
				_tableInfos.Add("HumanResourcesEmployee", new HumanResourcesEmployeeTableInfo(this));  
				_tableInfos.Add("HumanResourcesEmployeeDepartmentHistory", new HumanResourcesEmployeeDepartmentHistoryTableInfo(this));  
				_tableInfos.Add("HumanResourcesEmployeePayHistory", new HumanResourcesEmployeePayHistoryTableInfo(this));  
				_tableInfos.Add("ErrorLog", new ErrorLogTableInfo(this));  
				_tableInfos.Add("ProductionIllustration", new ProductionIllustrationTableInfo(this));  
				_tableInfos.Add("HumanResourcesJobCandidate", new HumanResourcesJobCandidateTableInfo(this));  
				_tableInfos.Add("ProductionLocation", new ProductionLocationTableInfo(this));  
				_tableInfos.Add("PersonPassword", new PersonPasswordTableInfo(this));  
				_tableInfos.Add("PersonPerson", new PersonPersonTableInfo(this));  
				_tableInfos.Add("SalesPersonCreditCard", new SalesPersonCreditCardTableInfo(this));  
				_tableInfos.Add("PersonPersonPhone", new PersonPersonPhoneTableInfo(this));  
				_tableInfos.Add("PersonPhoneNumberType", new PersonPhoneNumberTypeTableInfo(this));  
				_tableInfos.Add("ProductionProduct", new ProductionProductTableInfo(this));  
				_tableInfos.Add("ProductionProductCategory", new ProductionProductCategoryTableInfo(this));  
				_tableInfos.Add("ProductionProductCostHistory", new ProductionProductCostHistoryTableInfo(this));  
				_tableInfos.Add("ProductionProductDescription", new ProductionProductDescriptionTableInfo(this));  
				_tableInfos.Add("ProductionProductDocument", new ProductionProductDocumentTableInfo(this));  
				_tableInfos.Add("ProductionProductInventory", new ProductionProductInventoryTableInfo(this));  
				_tableInfos.Add("ProductionProductListPriceHistory", new ProductionProductListPriceHistoryTableInfo(this));  
				_tableInfos.Add("ProductionProductModel", new ProductionProductModelTableInfo(this));  
				_tableInfos.Add("ProductionProductModelIllustration", new ProductionProductModelIllustrationTableInfo(this));  
				_tableInfos.Add("ProductionProductModelProductDescriptionCulture", new ProductionProductModelProductDescriptionCultureTableInfo(this));  
				_tableInfos.Add("ProductionProductPhoto", new ProductionProductPhotoTableInfo(this));  
				_tableInfos.Add("ProductionProductProductPhoto", new ProductionProductProductPhotoTableInfo(this));  
				_tableInfos.Add("ProductionProductReview", new ProductionProductReviewTableInfo(this));  
				_tableInfos.Add("ProductionProductSubcategory", new ProductionProductSubcategoryTableInfo(this));  
				_tableInfos.Add("PurchasingProductVendor", new PurchasingProductVendorTableInfo(this));  
				_tableInfos.Add("PurchasingPurchaseOrderDetail", new PurchasingPurchaseOrderDetailTableInfo(this));  
				_tableInfos.Add("PurchasingPurchaseOrderHeader", new PurchasingPurchaseOrderHeaderTableInfo(this));  
				_tableInfos.Add("SalesSalesOrderDetail", new SalesSalesOrderDetailTableInfo(this));  
				_tableInfos.Add("SalesSalesOrderHeader", new SalesSalesOrderHeaderTableInfo(this));  
				_tableInfos.Add("SalesSalesOrderHeaderSalesReason", new SalesSalesOrderHeaderSalesReasonTableInfo(this));  
				_tableInfos.Add("SalesSalesPerson", new SalesSalesPersonTableInfo(this));  
				_tableInfos.Add("SalesSalesPersonQuotaHistory", new SalesSalesPersonQuotaHistoryTableInfo(this));  
				_tableInfos.Add("SalesSalesReason", new SalesSalesReasonTableInfo(this));  
				_tableInfos.Add("SalesSalesTaxRate", new SalesSalesTaxRateTableInfo(this));  
				_tableInfos.Add("SalesSalesTerritory", new SalesSalesTerritoryTableInfo(this));  
				_tableInfos.Add("SalesSalesTerritoryHistory", new SalesSalesTerritoryHistoryTableInfo(this));  
				_tableInfos.Add("ProductionScrapReason", new ProductionScrapReasonTableInfo(this));  
				_tableInfos.Add("HumanResourcesShift", new HumanResourcesShiftTableInfo(this));  
				_tableInfos.Add("PurchasingShipMethod", new PurchasingShipMethodTableInfo(this));  
				_tableInfos.Add("SalesShoppingCartItem", new SalesShoppingCartItemTableInfo(this));  
				_tableInfos.Add("SalesSpecialOffer", new SalesSpecialOfferTableInfo(this));  
				_tableInfos.Add("SalesSpecialOfferProduct", new SalesSpecialOfferProductTableInfo(this));  
				_tableInfos.Add("PersonStateProvince", new PersonStateProvinceTableInfo(this));  
				_tableInfos.Add("SalesStore", new SalesStoreTableInfo(this));  
				_tableInfos.Add("ProductionTransactionHistory", new ProductionTransactionHistoryTableInfo(this));  
				_tableInfos.Add("ProductionTransactionHistoryArchive", new ProductionTransactionHistoryArchiveTableInfo(this));  
				_tableInfos.Add("ProductionUnitMeasure", new ProductionUnitMeasureTableInfo(this));  
				_tableInfos.Add("PersonvAdditionalContactInfo", new PersonvAdditionalContactInfoTableInfo(this));  
				_tableInfos.Add("HumanResourcesvEmployee", new HumanResourcesvEmployeeTableInfo(this));  
				_tableInfos.Add("HumanResourcesvEmployeeDepartment", new HumanResourcesvEmployeeDepartmentTableInfo(this));  
				_tableInfos.Add("HumanResourcesvEmployeeDepartmentHistory", new HumanResourcesvEmployeeDepartmentHistoryTableInfo(this));  
				_tableInfos.Add("PurchasingVendor", new PurchasingVendorTableInfo(this));  
				_tableInfos.Add("SalesvIndividualCustomer", new SalesvIndividualCustomerTableInfo(this));  
				_tableInfos.Add("HumanResourcesvJobCandidate", new HumanResourcesvJobCandidateTableInfo(this));  
				_tableInfos.Add("HumanResourcesvJobCandidateEducation", new HumanResourcesvJobCandidateEducationTableInfo(this));  
				_tableInfos.Add("HumanResourcesvJobCandidateEmployment", new HumanResourcesvJobCandidateEmploymentTableInfo(this));  
				_tableInfos.Add("SalesvPersonDemographic", new SalesvPersonDemographicTableInfo(this));  
				_tableInfos.Add("ProductionvProductAndDescription", new ProductionvProductAndDescriptionTableInfo(this));  
				_tableInfos.Add("ProductionvProductModelCatalogDescription", new ProductionvProductModelCatalogDescriptionTableInfo(this));  
				_tableInfos.Add("ProductionvProductModelInstruction", new ProductionvProductModelInstructionTableInfo(this));  
				_tableInfos.Add("SalesvSalesPerson", new SalesvSalesPersonTableInfo(this));  
				_tableInfos.Add("SalesvSalesPersonSalesByFiscalYear", new SalesvSalesPersonSalesByFiscalYearTableInfo(this));  
				_tableInfos.Add("PersonvStateProvinceCountryRegion", new PersonvStateProvinceCountryRegionTableInfo(this));  
				_tableInfos.Add("SalesvStoreWithAddress", new SalesvStoreWithAddressTableInfo(this));  
				_tableInfos.Add("SalesvStoreWithContact", new SalesvStoreWithContactTableInfo(this));  
				_tableInfos.Add("SalesvStoreWithDemographic", new SalesvStoreWithDemographicTableInfo(this));  
				_tableInfos.Add("PurchasingvVendorWithAddress", new PurchasingvVendorWithAddressTableInfo(this));  
				_tableInfos.Add("PurchasingvVendorWithContact", new PurchasingvVendorWithContactTableInfo(this));  
				_tableInfos.Add("ProductionWorkOrder", new ProductionWorkOrderTableInfo(this));  
				_tableInfos.Add("ProductionWorkOrderRouting", new ProductionWorkOrderRoutingTableInfo(this));         }
	}
}

