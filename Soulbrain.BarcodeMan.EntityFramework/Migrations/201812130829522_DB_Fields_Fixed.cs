namespace Soulbrain.BarcodeMan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DB_Fields_Fixed : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("QRP.MASProductVendor", "PrdVendorCode", "QRP.MASVendor");
            DropForeignKey("QRP.MASVendorP", "VendorCode", "QRP.MASVendor");
            DropIndex("QRP.MASProductVendor", new[] { "PrdVendorCode" });
            DropIndex("QRP.MASVendorP", new[] { "VendorCode" });
            DropPrimaryKey("QRP.MASVendorP");
            DropPrimaryKey("QRP.MASVendor");
            AlterColumn("QRP.MASMaterialGroup", "UseFlag", c => c.String(maxLength: 1));
            AlterColumn("QRP.MASProduct", "InspectFlag", c => c.String(maxLength: 1));
            AlterColumn("QRP.MASProduct", "SerialUseFlag", c => c.String(maxLength: 1));
            AlterColumn("QRP.MASProduct", "UseFlag", c => c.String(maxLength: 1));
            AlterColumn("QRP.MASMaterialType", "UseFlag", c => c.String(maxLength: 1));
            AlterColumn("QRP.MASProductVendor", "PrdVendorCode", c => c.String(maxLength: 10));
            AlterColumn("QRP.MASProductVendor", "SupVendorCode", c => c.String(maxLength: 10));
            AlterColumn("QRP.SYSWebBarCode", "ProductDate", c => c.String(maxLength: 10));
            AlterColumn("QRP.SYSWebBarCode", "SupplyDate", c => c.String(maxLength: 10));
            AlterColumn("QRP.MASVendorP", "VendorCode", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("QRP.MASVendorP", "UseFlag", c => c.String(maxLength: 1));
            AlterColumn("QRP.MASVendor", "VendorCode", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("QRP.MASVendor", "UseFlag", c => c.String(maxLength: 1));
            AlterColumn("QRP.SYSWebBoard", "VendorCode", c => c.String(maxLength: 10));
            AlterColumn("QRP.SYSWebBoard", "WriteDate", c => c.String(maxLength: 10));
            AlterColumn("QRP.SYSWebBoardSearchHistory", "VendorCode", c => c.String(maxLength: 10));
            AlterColumn("QRP.SYSWebNotice", "WriteDate", c => c.String(maxLength: 10));
            AlterColumn("QRP.SYSWebNotice", "CompleteFlag", c => c.String(maxLength: 1));
            AlterColumn("QRP.SYSWebNoticeSearchHistory", "VendorCode", c => c.String(maxLength: 10));
            AddPrimaryKey("QRP.MASVendorP", new[] { "VendorCode", "Seq" });
            AddPrimaryKey("QRP.MASVendor", "VendorCode");
            CreateIndex("QRP.MASProductVendor", "PrdVendorCode");
            CreateIndex("QRP.MASVendorP", "VendorCode");
            AddForeignKey("QRP.MASProductVendor", "PrdVendorCode", "QRP.MASVendor", "VendorCode");
            AddForeignKey("QRP.MASVendorP", "VendorCode", "QRP.MASVendor", "VendorCode", cascadeDelete: true);
            AlterStoredProcedure(
                "dbo.MaterialGroup_Insert",
                p => new
                    {
                        PlantCode = p.String(maxLength: 10),
                        MaterialGroupCode = p.String(maxLength: 10),
                        MaterialGroupName = p.String(maxLength: 100),
                        MaterialGroupNameCh = p.String(maxLength: 100),
                        MaterialGroupNameEn = p.String(maxLength: 100),
                        UseFlag = p.String(maxLength: 1),
                        CreateIP = p.String(maxLength: 15),
                        CreateID = p.String(maxLength: 20),
                        CreateDate = p.DateTime(),
                        ModifyIP = p.String(maxLength: 15),
                        ModifyID = p.String(maxLength: 20),
                        ModifyDate = p.DateTime(),
                    },
                body:
                    @"INSERT [QRP].[MASMaterialGroup]([PlantCode], [MaterialGroupCode], [MaterialGroupName], [MaterialGroupNameCh], [MaterialGroupNameEn], [UseFlag], [CreateIP], [CreateID], [CreateDate], [ModifyIP], [ModifyID], [ModifyDate])
                      VALUES (@PlantCode, @MaterialGroupCode, @MaterialGroupName, @MaterialGroupNameCh, @MaterialGroupNameEn, @UseFlag, @CreateIP, @CreateID, @CreateDate, @ModifyIP, @ModifyID, @ModifyDate)"
            );
            
            AlterStoredProcedure(
                "dbo.MaterialGroup_Update",
                p => new
                    {
                        PlantCode = p.String(maxLength: 10),
                        MaterialGroupCode = p.String(maxLength: 10),
                        MaterialGroupName = p.String(maxLength: 100),
                        MaterialGroupNameCh = p.String(maxLength: 100),
                        MaterialGroupNameEn = p.String(maxLength: 100),
                        UseFlag = p.String(maxLength: 1),
                        CreateIP = p.String(maxLength: 15),
                        CreateID = p.String(maxLength: 20),
                        CreateDate = p.DateTime(),
                        ModifyIP = p.String(maxLength: 15),
                        ModifyID = p.String(maxLength: 20),
                        ModifyDate = p.DateTime(),
                    },
                body:
                    @"UPDATE [QRP].[MASMaterialGroup]
                      SET [MaterialGroupName] = @MaterialGroupName, [MaterialGroupNameCh] = @MaterialGroupNameCh, [MaterialGroupNameEn] = @MaterialGroupNameEn, [UseFlag] = @UseFlag, [CreateIP] = @CreateIP, [CreateID] = @CreateID, [CreateDate] = @CreateDate, [ModifyIP] = @ModifyIP, [ModifyID] = @ModifyID, [ModifyDate] = @ModifyDate
                      WHERE (([PlantCode] = @PlantCode) AND ([MaterialGroupCode] = @MaterialGroupCode))"
            );
            
            AlterStoredProcedure(
                "dbo.Product_Insert",
                p => new
                    {
                        PlantCode = p.String(maxLength: 10),
                        ProductCode = p.String(maxLength: 20),
                        ProductName = p.String(maxLength: 300),
                        ProductNameCh = p.String(maxLength: 300),
                        ProductNameEn = p.String(maxLength: 300),
                        MaterialGroupCode = p.String(maxLength: 10),
                        MaterialTypeCode = p.String(maxLength: 10),
                        Spec = p.String(maxLength: 300),
                        DrawingNo = p.String(maxLength: 30),
                        CarTypeCode = p.String(maxLength: 10),
                        SecondNo = p.String(maxLength: 30),
                        MoldingEquipCode = p.String(maxLength: 10),
                        MeltingFurnaceCode = p.String(maxLength: 10),
                        ProductWeight = p.Decimal(precision: 10, scale: 2),
                        Cavity = p.Int(),
                        ProductQuality = p.String(maxLength: 10),
                        NetPrice = p.Decimal(precision: 15, scale: 4),
                        CoreType = p.String(maxLength: 1),
                        RealProductWeight = p.Decimal(precision: 10, scale: 2),
                        MarketType = p.String(maxLength: 1),
                        RecoverRate = p.Decimal(precision: 10, scale: 2),
                        PourWeight = p.Decimal(precision: 10, scale: 2),
                        attachCount1 = p.Int(),
                        attachCount2 = p.Int(),
                        BaseUnitCode = p.String(maxLength: 10),
                        WorkLotSize = p.Decimal(precision: 20, scale: 5),
                        InspectFlag = p.String(maxLength: 1),
                        InspectFaultInventoryCode = p.String(maxLength: 10),
                        AvailInventoryCode = p.String(maxLength: 10),
                        WorkInStandbyInventoryCode = p.String(maxLength: 10),
                        SizePerPack = p.Decimal(precision: 20, scale: 5),
                        PackUnitCode = p.String(maxLength: 10),
                        SerialUseFlag = p.String(maxLength: 1),
                        ProdQtyPerProduct = p.Decimal(precision: 18, scale: 2),
                        InspectStandbyInventoryCode = p.String(maxLength: 10),
                        ProdTypeCode = p.String(maxLength: 10),
                        UseFlag = p.String(maxLength: 1),
                        CreateIP = p.String(maxLength: 15),
                        CreateID = p.String(maxLength: 20),
                        CreateDate = p.DateTime(),
                        ModifyIP = p.String(maxLength: 15),
                        ModifyID = p.String(maxLength: 20),
                        ModifyDate = p.DateTime(),
                    },
                body:
                    @"INSERT [QRP].[MASProduct]([PlantCode], [ProductCode], [ProductName], [ProductNameCh], [ProductNameEn], [MaterialGroupCode], [MaterialTypeCode], [Spec], [DrawingNo], [CarTypeCode], [SecondNo], [MoldingEquipCode], [MeltingFurnaceCode], [ProductWeight], [Cavity], [ProductQuality], [NetPrice], [CoreType], [RealProductWeight], [MarketType], [RecoverRate], [PourWeight], [attachCount1], [attachCount2], [BaseUnitCode], [WorkLotSize], [InspectFlag], [InspectFaultInventoryCode], [AvailInventoryCode], [WorkInStandbyInventoryCode], [SizePerPack], [PackUnitCode], [SerialUseFlag], [ProdQtyPerProduct], [InspectStandbyInventoryCode], [ProdTypeCode], [UseFlag], [CreateIP], [CreateID], [CreateDate], [ModifyIP], [ModifyID], [ModifyDate])
                      VALUES (@PlantCode, @ProductCode, @ProductName, @ProductNameCh, @ProductNameEn, @MaterialGroupCode, @MaterialTypeCode, @Spec, @DrawingNo, @CarTypeCode, @SecondNo, @MoldingEquipCode, @MeltingFurnaceCode, @ProductWeight, @Cavity, @ProductQuality, @NetPrice, @CoreType, @RealProductWeight, @MarketType, @RecoverRate, @PourWeight, @attachCount1, @attachCount2, @BaseUnitCode, @WorkLotSize, @InspectFlag, @InspectFaultInventoryCode, @AvailInventoryCode, @WorkInStandbyInventoryCode, @SizePerPack, @PackUnitCode, @SerialUseFlag, @ProdQtyPerProduct, @InspectStandbyInventoryCode, @ProdTypeCode, @UseFlag, @CreateIP, @CreateID, @CreateDate, @ModifyIP, @ModifyID, @ModifyDate)"
            );
            
            AlterStoredProcedure(
                "dbo.Product_Update",
                p => new
                    {
                        PlantCode = p.String(maxLength: 10),
                        ProductCode = p.String(maxLength: 20),
                        ProductName = p.String(maxLength: 300),
                        ProductNameCh = p.String(maxLength: 300),
                        ProductNameEn = p.String(maxLength: 300),
                        MaterialGroupCode = p.String(maxLength: 10),
                        MaterialTypeCode = p.String(maxLength: 10),
                        Spec = p.String(maxLength: 300),
                        DrawingNo = p.String(maxLength: 30),
                        CarTypeCode = p.String(maxLength: 10),
                        SecondNo = p.String(maxLength: 30),
                        MoldingEquipCode = p.String(maxLength: 10),
                        MeltingFurnaceCode = p.String(maxLength: 10),
                        ProductWeight = p.Decimal(precision: 10, scale: 2),
                        Cavity = p.Int(),
                        ProductQuality = p.String(maxLength: 10),
                        NetPrice = p.Decimal(precision: 15, scale: 4),
                        CoreType = p.String(maxLength: 1),
                        RealProductWeight = p.Decimal(precision: 10, scale: 2),
                        MarketType = p.String(maxLength: 1),
                        RecoverRate = p.Decimal(precision: 10, scale: 2),
                        PourWeight = p.Decimal(precision: 10, scale: 2),
                        attachCount1 = p.Int(),
                        attachCount2 = p.Int(),
                        BaseUnitCode = p.String(maxLength: 10),
                        WorkLotSize = p.Decimal(precision: 20, scale: 5),
                        InspectFlag = p.String(maxLength: 1),
                        InspectFaultInventoryCode = p.String(maxLength: 10),
                        AvailInventoryCode = p.String(maxLength: 10),
                        WorkInStandbyInventoryCode = p.String(maxLength: 10),
                        SizePerPack = p.Decimal(precision: 20, scale: 5),
                        PackUnitCode = p.String(maxLength: 10),
                        SerialUseFlag = p.String(maxLength: 1),
                        ProdQtyPerProduct = p.Decimal(precision: 18, scale: 2),
                        InspectStandbyInventoryCode = p.String(maxLength: 10),
                        ProdTypeCode = p.String(maxLength: 10),
                        UseFlag = p.String(maxLength: 1),
                        CreateIP = p.String(maxLength: 15),
                        CreateID = p.String(maxLength: 20),
                        CreateDate = p.DateTime(),
                        ModifyIP = p.String(maxLength: 15),
                        ModifyID = p.String(maxLength: 20),
                        ModifyDate = p.DateTime(),
                    },
                body:
                    @"UPDATE [QRP].[MASProduct]
                      SET [ProductName] = @ProductName, [ProductNameCh] = @ProductNameCh, [ProductNameEn] = @ProductNameEn, [MaterialGroupCode] = @MaterialGroupCode, [MaterialTypeCode] = @MaterialTypeCode, [Spec] = @Spec, [DrawingNo] = @DrawingNo, [CarTypeCode] = @CarTypeCode, [SecondNo] = @SecondNo, [MoldingEquipCode] = @MoldingEquipCode, [MeltingFurnaceCode] = @MeltingFurnaceCode, [ProductWeight] = @ProductWeight, [Cavity] = @Cavity, [ProductQuality] = @ProductQuality, [NetPrice] = @NetPrice, [CoreType] = @CoreType, [RealProductWeight] = @RealProductWeight, [MarketType] = @MarketType, [RecoverRate] = @RecoverRate, [PourWeight] = @PourWeight, [attachCount1] = @attachCount1, [attachCount2] = @attachCount2, [BaseUnitCode] = @BaseUnitCode, [WorkLotSize] = @WorkLotSize, [InspectFlag] = @InspectFlag, [InspectFaultInventoryCode] = @InspectFaultInventoryCode, [AvailInventoryCode] = @AvailInventoryCode, [WorkInStandbyInventoryCode] = @WorkInStandbyInventoryCode, [SizePerPack] = @SizePerPack, [PackUnitCode] = @PackUnitCode, [SerialUseFlag] = @SerialUseFlag, [ProdQtyPerProduct] = @ProdQtyPerProduct, [InspectStandbyInventoryCode] = @InspectStandbyInventoryCode, [ProdTypeCode] = @ProdTypeCode, [UseFlag] = @UseFlag, [CreateIP] = @CreateIP, [CreateID] = @CreateID, [CreateDate] = @CreateDate, [ModifyIP] = @ModifyIP, [ModifyID] = @ModifyID, [ModifyDate] = @ModifyDate
                      WHERE (([PlantCode] = @PlantCode) AND ([ProductCode] = @ProductCode))"
            );
            
            AlterStoredProcedure(
                "dbo.MaterialType_Insert",
                p => new
                    {
                        PlantCode = p.String(maxLength: 10),
                        MaterialTypeCode = p.String(maxLength: 10),
                        MaterialTypeName = p.String(maxLength: 100),
                        MaterialTypeNameCh = p.String(maxLength: 100),
                        MaterialTypeNameEn = p.String(maxLength: 100),
                        UseFlag = p.String(maxLength: 1),
                        CreateIP = p.String(maxLength: 15),
                        CreateID = p.String(maxLength: 20),
                        CreateDate = p.DateTime(),
                        ModifyIP = p.String(maxLength: 15),
                        ModifyID = p.String(maxLength: 20),
                        ModifyDate = p.DateTime(),
                    },
                body:
                    @"INSERT [QRP].[MASMaterialType]([PlantCode], [MaterialTypeCode], [MaterialTypeName], [MaterialTypeNameCh], [MaterialTypeNameEn], [UseFlag], [CreateIP], [CreateID], [CreateDate], [ModifyIP], [ModifyID], [ModifyDate])
                      VALUES (@PlantCode, @MaterialTypeCode, @MaterialTypeName, @MaterialTypeNameCh, @MaterialTypeNameEn, @UseFlag, @CreateIP, @CreateID, @CreateDate, @ModifyIP, @ModifyID, @ModifyDate)"
            );
            
            AlterStoredProcedure(
                "dbo.MaterialType_Update",
                p => new
                    {
                        PlantCode = p.String(maxLength: 10),
                        MaterialTypeCode = p.String(maxLength: 10),
                        MaterialTypeName = p.String(maxLength: 100),
                        MaterialTypeNameCh = p.String(maxLength: 100),
                        MaterialTypeNameEn = p.String(maxLength: 100),
                        UseFlag = p.String(maxLength: 1),
                        CreateIP = p.String(maxLength: 15),
                        CreateID = p.String(maxLength: 20),
                        CreateDate = p.DateTime(),
                        ModifyIP = p.String(maxLength: 15),
                        ModifyID = p.String(maxLength: 20),
                        ModifyDate = p.DateTime(),
                    },
                body:
                    @"UPDATE [QRP].[MASMaterialType]
                      SET [MaterialTypeName] = @MaterialTypeName, [MaterialTypeNameCh] = @MaterialTypeNameCh, [MaterialTypeNameEn] = @MaterialTypeNameEn, [UseFlag] = @UseFlag, [CreateIP] = @CreateIP, [CreateID] = @CreateID, [CreateDate] = @CreateDate, [ModifyIP] = @ModifyIP, [ModifyID] = @ModifyID, [ModifyDate] = @ModifyDate
                      WHERE (([PlantCode] = @PlantCode) AND ([MaterialTypeCode] = @MaterialTypeCode))"
            );
            
            AlterStoredProcedure(
                "dbo.ProductVendor_Insert",
                p => new
                    {
                        PlantCode = p.String(maxLength: 10),
                        ProductCode = p.String(maxLength: 20),
                        Seq = p.Int(),
                        PrdVendorCode = p.String(maxLength: 10),
                        SupVendorCode = p.String(maxLength: 10),
                        PackingQty = p.Decimal(precision: 15, scale: 5),
                        PackingUnitCode = p.String(maxLength: 10),
                        EtcDesc = p.String(maxLength: 500),
                        CreateIP = p.String(maxLength: 15),
                        CreateID = p.String(maxLength: 20),
                        CreateDate = p.DateTime(),
                        ModifyIP = p.String(maxLength: 15),
                        ModifyID = p.String(maxLength: 20),
                        ModifyDate = p.DateTime(),
                    },
                body:
                    @"INSERT [QRP].[MASProductVendor]([PlantCode], [ProductCode], [Seq], [PrdVendorCode], [SupVendorCode], [PackingQty], [PackingUnitCode], [EtcDesc], [CreateIP], [CreateID], [CreateDate], [ModifyIP], [ModifyID], [ModifyDate])
                      VALUES (@PlantCode, @ProductCode, @Seq, @PrdVendorCode, @SupVendorCode, @PackingQty, @PackingUnitCode, @EtcDesc, @CreateIP, @CreateID, @CreateDate, @ModifyIP, @ModifyID, @ModifyDate)"
            );
            
            AlterStoredProcedure(
                "dbo.ProductVendor_Update",
                p => new
                    {
                        PlantCode = p.String(maxLength: 10),
                        ProductCode = p.String(maxLength: 20),
                        Seq = p.Int(),
                        PrdVendorCode = p.String(maxLength: 10),
                        SupVendorCode = p.String(maxLength: 10),
                        PackingQty = p.Decimal(precision: 15, scale: 5),
                        PackingUnitCode = p.String(maxLength: 10),
                        EtcDesc = p.String(maxLength: 500),
                        CreateIP = p.String(maxLength: 15),
                        CreateID = p.String(maxLength: 20),
                        CreateDate = p.DateTime(),
                        ModifyIP = p.String(maxLength: 15),
                        ModifyID = p.String(maxLength: 20),
                        ModifyDate = p.DateTime(),
                    },
                body:
                    @"UPDATE [QRP].[MASProductVendor]
                      SET [PrdVendorCode] = @PrdVendorCode, [SupVendorCode] = @SupVendorCode, [PackingQty] = @PackingQty, [PackingUnitCode] = @PackingUnitCode, [EtcDesc] = @EtcDesc, [CreateIP] = @CreateIP, [CreateID] = @CreateID, [CreateDate] = @CreateDate, [ModifyIP] = @ModifyIP, [ModifyID] = @ModifyID, [ModifyDate] = @ModifyDate
                      WHERE ((([PlantCode] = @PlantCode) AND ([ProductCode] = @ProductCode)) AND ([Seq] = @Seq))"
            );
            
            AlterStoredProcedure(
                "dbo.WebBarCode_Insert",
                p => new
                    {
                        PlantCode = p.String(maxLength: 10),
                        DocCode = p.String(maxLength: 20),
                        ProductCode = p.String(maxLength: 20),
                        SupplyQty = p.Decimal(precision: 15, scale: 5),
                        PackingUnitCode = p.String(maxLength: 10),
                        LotNo = p.String(maxLength: 100),
                        ProductDate = p.String(maxLength: 10),
                        ExpiryDate = p.String(maxLength: 10),
                        SupplyDate = p.String(maxLength: 10),
                        PrintQty = p.Int(),
                        PrintDatetime = p.DateTime(),
                        PrintType = p.String(maxLength: 10),
                        CreateIP = p.String(maxLength: 15),
                        CreateID = p.String(maxLength: 20),
                        CreateDate = p.DateTime(),
                        ModifyIP = p.String(maxLength: 15),
                        ModifyID = p.String(maxLength: 20),
                        ModifyDate = p.DateTime(),
                    },
                body:
                    @"INSERT [QRP].[SYSWebBarCode]([PlantCode], [DocCode], [ProductCode], [SupplyQty], [PackingUnitCode], [LotNo], [ProductDate], [ExpiryDate], [SupplyDate], [PrintQty], [PrintDatetime], [PrintType], [CreateIP], [CreateID], [CreateDate], [ModifyIP], [ModifyID], [ModifyDate])
                      VALUES (@PlantCode, @DocCode, @ProductCode, @SupplyQty, @PackingUnitCode, @LotNo, @ProductDate, @ExpiryDate, @SupplyDate, @PrintQty, @PrintDatetime, @PrintType, @CreateIP, @CreateID, @CreateDate, @ModifyIP, @ModifyID, @ModifyDate)"
            );
            
            AlterStoredProcedure(
                "dbo.WebBarCode_Update",
                p => new
                    {
                        PlantCode = p.String(maxLength: 10),
                        DocCode = p.String(maxLength: 20),
                        ProductCode = p.String(maxLength: 20),
                        SupplyQty = p.Decimal(precision: 15, scale: 5),
                        PackingUnitCode = p.String(maxLength: 10),
                        LotNo = p.String(maxLength: 100),
                        ProductDate = p.String(maxLength: 10),
                        ExpiryDate = p.String(maxLength: 10),
                        SupplyDate = p.String(maxLength: 10),
                        PrintQty = p.Int(),
                        PrintDatetime = p.DateTime(),
                        PrintType = p.String(maxLength: 10),
                        CreateIP = p.String(maxLength: 15),
                        CreateID = p.String(maxLength: 20),
                        CreateDate = p.DateTime(),
                        ModifyIP = p.String(maxLength: 15),
                        ModifyID = p.String(maxLength: 20),
                        ModifyDate = p.DateTime(),
                    },
                body:
                    @"UPDATE [QRP].[SYSWebBarCode]
                      SET [ProductCode] = @ProductCode, [SupplyQty] = @SupplyQty, [PackingUnitCode] = @PackingUnitCode, [LotNo] = @LotNo, [ProductDate] = @ProductDate, [ExpiryDate] = @ExpiryDate, [SupplyDate] = @SupplyDate, [PrintQty] = @PrintQty, [PrintDatetime] = @PrintDatetime, [PrintType] = @PrintType, [CreateIP] = @CreateIP, [CreateID] = @CreateID, [CreateDate] = @CreateDate, [ModifyIP] = @ModifyIP, [ModifyID] = @ModifyID, [ModifyDate] = @ModifyDate
                      WHERE (([PlantCode] = @PlantCode) AND ([DocCode] = @DocCode))"
            );
            
            AlterStoredProcedure(
                "dbo.VendorP_Insert",
                p => new
                    {
                        VendorCode = p.String(maxLength: 10),
                        Seq = p.Int(),
                        PersonID = p.String(maxLength: 20),
                        PersonPW = p.String(maxLength: 100),
                        PersonJob = p.String(maxLength: 100),
                        PersonDeptName = p.String(maxLength: 100),
                        PersonName = p.String(maxLength: 100),
                        PersonPosition = p.String(maxLength: 100),
                        PersonTel = p.String(maxLength: 20),
                        PersonHp = p.String(maxLength: 50),
                        PersonEMail = p.String(),
                        EtcDesc = p.String(maxLength: 1000),
                        UseFlag = p.String(maxLength: 1),
                        CreateIP = p.String(maxLength: 15),
                        CreateID = p.String(maxLength: 20),
                        CreateDate = p.DateTime(),
                        ModifyIP = p.String(maxLength: 15),
                        ModifyID = p.String(maxLength: 20),
                        ModifyDate = p.DateTime(),
                    },
                body:
                    @"INSERT [QRP].[MASVendorP]([VendorCode], [Seq], [PersonID], [PersonPW], [PersonJob], [PersonDeptName], [PersonName], [PersonPosition], [PersonTel], [PersonHp], [PersonEMail], [EtcDesc], [UseFlag], [CreateIP], [CreateID], [CreateDate], [ModifyIP], [ModifyID], [ModifyDate])
                      VALUES (@VendorCode, @Seq, @PersonID, @PersonPW, @PersonJob, @PersonDeptName, @PersonName, @PersonPosition, @PersonTel, @PersonHp, @PersonEMail, @EtcDesc, @UseFlag, @CreateIP, @CreateID, @CreateDate, @ModifyIP, @ModifyID, @ModifyDate)"
            );
            
            AlterStoredProcedure(
                "dbo.VendorP_Update",
                p => new
                    {
                        VendorCode = p.String(maxLength: 10),
                        Seq = p.Int(),
                        PersonID = p.String(maxLength: 20),
                        PersonPW = p.String(maxLength: 100),
                        PersonJob = p.String(maxLength: 100),
                        PersonDeptName = p.String(maxLength: 100),
                        PersonName = p.String(maxLength: 100),
                        PersonPosition = p.String(maxLength: 100),
                        PersonTel = p.String(maxLength: 20),
                        PersonHp = p.String(maxLength: 50),
                        PersonEMail = p.String(),
                        EtcDesc = p.String(maxLength: 1000),
                        UseFlag = p.String(maxLength: 1),
                        CreateIP = p.String(maxLength: 15),
                        CreateID = p.String(maxLength: 20),
                        CreateDate = p.DateTime(),
                        ModifyIP = p.String(maxLength: 15),
                        ModifyID = p.String(maxLength: 20),
                        ModifyDate = p.DateTime(),
                    },
                body:
                    @"UPDATE [QRP].[MASVendorP]
                      SET [PersonID] = @PersonID, [PersonPW] = @PersonPW, [PersonJob] = @PersonJob, [PersonDeptName] = @PersonDeptName, [PersonName] = @PersonName, [PersonPosition] = @PersonPosition, [PersonTel] = @PersonTel, [PersonHp] = @PersonHp, [PersonEMail] = @PersonEMail, [EtcDesc] = @EtcDesc, [UseFlag] = @UseFlag, [CreateIP] = @CreateIP, [CreateID] = @CreateID, [CreateDate] = @CreateDate, [ModifyIP] = @ModifyIP, [ModifyID] = @ModifyID, [ModifyDate] = @ModifyDate
                      WHERE (([VendorCode] = @VendorCode) AND ([Seq] = @Seq))"
            );
            
            AlterStoredProcedure(
                "dbo.VendorP_Delete",
                p => new
                    {
                        VendorCode = p.String(maxLength: 10),
                        Seq = p.Int(),
                    },
                body:
                    @"DELETE [QRP].[MASVendorP]
                      WHERE (([VendorCode] = @VendorCode) AND ([Seq] = @Seq))"
            );
            
            AlterStoredProcedure(
                "dbo.Vendor_Insert",
                p => new
                    {
                        VendorCode = p.String(maxLength: 10),
                        VendorName = p.String(maxLength: 100),
                        VendorNameCh = p.String(maxLength: 100),
                        VendorNameEn = p.String(maxLength: 100),
                        RegNo = p.String(maxLength: 100),
                        BossName = p.String(maxLength: 100),
                        Tel = p.String(maxLength: 20),
                        Fax = p.String(maxLength: 20),
                        Address = p.String(maxLength: 300),
                        UseFlag = p.String(maxLength: 1),
                        CreateIP = p.String(maxLength: 15),
                        CreateID = p.String(maxLength: 20),
                        CreateDate = p.DateTime(),
                        ModifyIP = p.String(maxLength: 15),
                        ModifyID = p.String(maxLength: 20),
                        ModifyDate = p.DateTime(),
                    },
                body:
                    @"INSERT [QRP].[MASVendor]([VendorCode], [VendorName], [VendorNameCh], [VendorNameEn], [RegNo], [BossName], [Tel], [Fax], [Address], [UseFlag], [CreateIP], [CreateID], [CreateDate], [ModifyIP], [ModifyID], [ModifyDate])
                      VALUES (@VendorCode, @VendorName, @VendorNameCh, @VendorNameEn, @RegNo, @BossName, @Tel, @Fax, @Address, @UseFlag, @CreateIP, @CreateID, @CreateDate, @ModifyIP, @ModifyID, @ModifyDate)"
            );
            
            AlterStoredProcedure(
                "dbo.Vendor_Update",
                p => new
                    {
                        VendorCode = p.String(maxLength: 10),
                        VendorName = p.String(maxLength: 100),
                        VendorNameCh = p.String(maxLength: 100),
                        VendorNameEn = p.String(maxLength: 100),
                        RegNo = p.String(maxLength: 100),
                        BossName = p.String(maxLength: 100),
                        Tel = p.String(maxLength: 20),
                        Fax = p.String(maxLength: 20),
                        Address = p.String(maxLength: 300),
                        UseFlag = p.String(maxLength: 1),
                        CreateIP = p.String(maxLength: 15),
                        CreateID = p.String(maxLength: 20),
                        CreateDate = p.DateTime(),
                        ModifyIP = p.String(maxLength: 15),
                        ModifyID = p.String(maxLength: 20),
                        ModifyDate = p.DateTime(),
                    },
                body:
                    @"UPDATE [QRP].[MASVendor]
                      SET [VendorName] = @VendorName, [VendorNameCh] = @VendorNameCh, [VendorNameEn] = @VendorNameEn, [RegNo] = @RegNo, [BossName] = @BossName, [Tel] = @Tel, [Fax] = @Fax, [Address] = @Address, [UseFlag] = @UseFlag, [CreateIP] = @CreateIP, [CreateID] = @CreateID, [CreateDate] = @CreateDate, [ModifyIP] = @ModifyIP, [ModifyID] = @ModifyID, [ModifyDate] = @ModifyDate
                      WHERE ([VendorCode] = @VendorCode)"
            );
            
            AlterStoredProcedure(
                "dbo.Vendor_Delete",
                p => new
                    {
                        VendorCode = p.String(maxLength: 10),
                    },
                body:
                    @"DELETE [QRP].[MASVendor]
                      WHERE ([VendorCode] = @VendorCode)"
            );
            
            AlterStoredProcedure(
                "dbo.WebBoard_Insert",
                p => new
                    {
                        PlantCode = p.String(maxLength: 10),
                        DocCode = p.String(maxLength: 20),
                        VendorCode = p.String(maxLength: 10),
                        TitleKor = p.String(maxLength: 1000),
                        TitleEng = p.String(maxLength: 1000),
                        WriteID = p.String(maxLength: 20),
                        WriteDate = p.String(maxLength: 10),
                        BoardType = p.String(maxLength: 10),
                        ContentsKor = p.String(maxLength: 4000),
                        ContentsEng = p.String(maxLength: 4000),
                        CreateIP = p.String(maxLength: 15),
                        CreateID = p.String(maxLength: 20),
                        CreateDate = p.DateTime(),
                        ModifyIP = p.String(maxLength: 15),
                        ModifyID = p.String(maxLength: 20),
                        ModifyDate = p.DateTime(),
                    },
                body:
                    @"INSERT [QRP].[SYSWebBoard]([PlantCode], [DocCode], [VendorCode], [TitleKor], [TitleEng], [WriteID], [WriteDate], [BoardType], [ContentsKor], [ContentsEng], [CreateIP], [CreateID], [CreateDate], [ModifyIP], [ModifyID], [ModifyDate])
                      VALUES (@PlantCode, @DocCode, @VendorCode, @TitleKor, @TitleEng, @WriteID, @WriteDate, @BoardType, @ContentsKor, @ContentsEng, @CreateIP, @CreateID, @CreateDate, @ModifyIP, @ModifyID, @ModifyDate)"
            );
            
            AlterStoredProcedure(
                "dbo.WebBoard_Update",
                p => new
                    {
                        PlantCode = p.String(maxLength: 10),
                        DocCode = p.String(maxLength: 20),
                        VendorCode = p.String(maxLength: 10),
                        TitleKor = p.String(maxLength: 1000),
                        TitleEng = p.String(maxLength: 1000),
                        WriteID = p.String(maxLength: 20),
                        WriteDate = p.String(maxLength: 10),
                        BoardType = p.String(maxLength: 10),
                        ContentsKor = p.String(maxLength: 4000),
                        ContentsEng = p.String(maxLength: 4000),
                        CreateIP = p.String(maxLength: 15),
                        CreateID = p.String(maxLength: 20),
                        CreateDate = p.DateTime(),
                        ModifyIP = p.String(maxLength: 15),
                        ModifyID = p.String(maxLength: 20),
                        ModifyDate = p.DateTime(),
                    },
                body:
                    @"UPDATE [QRP].[SYSWebBoard]
                      SET [VendorCode] = @VendorCode, [TitleKor] = @TitleKor, [TitleEng] = @TitleEng, [WriteID] = @WriteID, [WriteDate] = @WriteDate, [BoardType] = @BoardType, [ContentsKor] = @ContentsKor, [ContentsEng] = @ContentsEng, [CreateIP] = @CreateIP, [CreateID] = @CreateID, [CreateDate] = @CreateDate, [ModifyIP] = @ModifyIP, [ModifyID] = @ModifyID, [ModifyDate] = @ModifyDate
                      WHERE (([PlantCode] = @PlantCode) AND ([DocCode] = @DocCode))"
            );
            
            AlterStoredProcedure(
                "dbo.WebBoardSearchHistory_Insert",
                p => new
                    {
                        PlantCode = p.String(maxLength: 10),
                        DocCode = p.String(maxLength: 20),
                        Seq = p.Int(),
                        VendorCode = p.String(maxLength: 10),
                        PersonID = p.String(maxLength: 20),
                        SearchDatetime = p.DateTime(),
                        CreateIP = p.String(maxLength: 15),
                        CreateID = p.String(maxLength: 20),
                        CreateDate = p.DateTime(),
                        ModifyIP = p.String(maxLength: 15),
                        ModifyID = p.String(maxLength: 20),
                        ModifyDate = p.DateTime(),
                    },
                body:
                    @"INSERT [QRP].[SYSWebBoardSearchHistory]([PlantCode], [DocCode], [Seq], [VendorCode], [PersonID], [SearchDatetime], [CreateIP], [CreateID], [CreateDate], [ModifyIP], [ModifyID], [ModifyDate])
                      VALUES (@PlantCode, @DocCode, @Seq, @VendorCode, @PersonID, @SearchDatetime, @CreateIP, @CreateID, @CreateDate, @ModifyIP, @ModifyID, @ModifyDate)"
            );
            
            AlterStoredProcedure(
                "dbo.WebBoardSearchHistory_Update",
                p => new
                    {
                        PlantCode = p.String(maxLength: 10),
                        DocCode = p.String(maxLength: 20),
                        Seq = p.Int(),
                        VendorCode = p.String(maxLength: 10),
                        PersonID = p.String(maxLength: 20),
                        SearchDatetime = p.DateTime(),
                        CreateIP = p.String(maxLength: 15),
                        CreateID = p.String(maxLength: 20),
                        CreateDate = p.DateTime(),
                        ModifyIP = p.String(maxLength: 15),
                        ModifyID = p.String(maxLength: 20),
                        ModifyDate = p.DateTime(),
                    },
                body:
                    @"UPDATE [QRP].[SYSWebBoardSearchHistory]
                      SET [VendorCode] = @VendorCode, [PersonID] = @PersonID, [SearchDatetime] = @SearchDatetime, [CreateIP] = @CreateIP, [CreateID] = @CreateID, [CreateDate] = @CreateDate, [ModifyIP] = @ModifyIP, [ModifyID] = @ModifyID, [ModifyDate] = @ModifyDate
                      WHERE ((([PlantCode] = @PlantCode) AND ([DocCode] = @DocCode)) AND ([Seq] = @Seq))"
            );
            
            AlterStoredProcedure(
                "dbo.WebNotice_Insert",
                p => new
                    {
                        PlantCode = p.String(maxLength: 10),
                        DocCode = p.String(maxLength: 20),
                        TitleKor = p.String(maxLength: 1000),
                        TitleEng = p.String(maxLength: 1000),
                        WriteID = p.String(maxLength: 20),
                        WriteDate = p.String(maxLength: 10),
                        NoticeType = p.String(maxLength: 10),
                        CompleteFlag = p.String(maxLength: 1),
                        ContentsKor = p.String(maxLength: 4000),
                        ContentsEng = p.String(maxLength: 4000),
                        CreateIP = p.String(maxLength: 15),
                        CreateID = p.String(maxLength: 20),
                        CreateDate = p.DateTime(),
                        ModifyIP = p.String(maxLength: 15),
                        ModifyID = p.String(maxLength: 20),
                        ModifyDate = p.DateTime(),
                    },
                body:
                    @"INSERT [QRP].[SYSWebNotice]([PlantCode], [DocCode], [TitleKor], [TitleEng], [WriteID], [WriteDate], [NoticeType], [CompleteFlag], [ContentsKor], [ContentsEng], [CreateIP], [CreateID], [CreateDate], [ModifyIP], [ModifyID], [ModifyDate])
                      VALUES (@PlantCode, @DocCode, @TitleKor, @TitleEng, @WriteID, @WriteDate, @NoticeType, @CompleteFlag, @ContentsKor, @ContentsEng, @CreateIP, @CreateID, @CreateDate, @ModifyIP, @ModifyID, @ModifyDate)"
            );
            
            AlterStoredProcedure(
                "dbo.WebNotice_Update",
                p => new
                    {
                        PlantCode = p.String(maxLength: 10),
                        DocCode = p.String(maxLength: 20),
                        TitleKor = p.String(maxLength: 1000),
                        TitleEng = p.String(maxLength: 1000),
                        WriteID = p.String(maxLength: 20),
                        WriteDate = p.String(maxLength: 10),
                        NoticeType = p.String(maxLength: 10),
                        CompleteFlag = p.String(maxLength: 1),
                        ContentsKor = p.String(maxLength: 4000),
                        ContentsEng = p.String(maxLength: 4000),
                        CreateIP = p.String(maxLength: 15),
                        CreateID = p.String(maxLength: 20),
                        CreateDate = p.DateTime(),
                        ModifyIP = p.String(maxLength: 15),
                        ModifyID = p.String(maxLength: 20),
                        ModifyDate = p.DateTime(),
                    },
                body:
                    @"UPDATE [QRP].[SYSWebNotice]
                      SET [TitleKor] = @TitleKor, [TitleEng] = @TitleEng, [WriteID] = @WriteID, [WriteDate] = @WriteDate, [NoticeType] = @NoticeType, [CompleteFlag] = @CompleteFlag, [ContentsKor] = @ContentsKor, [ContentsEng] = @ContentsEng, [CreateIP] = @CreateIP, [CreateID] = @CreateID, [CreateDate] = @CreateDate, [ModifyIP] = @ModifyIP, [ModifyID] = @ModifyID, [ModifyDate] = @ModifyDate
                      WHERE (([PlantCode] = @PlantCode) AND ([DocCode] = @DocCode))"
            );
            
            AlterStoredProcedure(
                "dbo.WebNoticeSearchHistory_Insert",
                p => new
                    {
                        PlantCode = p.String(maxLength: 10),
                        DocCode = p.String(maxLength: 20),
                        Seq = p.Int(),
                        VendorCode = p.String(maxLength: 10),
                        PersonID = p.String(maxLength: 20),
                        SearchDatetime = p.DateTime(),
                        CreateIP = p.String(maxLength: 15),
                        CreateID = p.String(maxLength: 20),
                        CreateDate = p.DateTime(),
                        ModifyIP = p.String(maxLength: 15),
                        ModifyID = p.String(maxLength: 20),
                        ModifyDate = p.DateTime(),
                    },
                body:
                    @"INSERT [QRP].[SYSWebNoticeSearchHistory]([PlantCode], [DocCode], [Seq], [VendorCode], [PersonID], [SearchDatetime], [CreateIP], [CreateID], [CreateDate], [ModifyIP], [ModifyID], [ModifyDate])
                      VALUES (@PlantCode, @DocCode, @Seq, @VendorCode, @PersonID, @SearchDatetime, @CreateIP, @CreateID, @CreateDate, @ModifyIP, @ModifyID, @ModifyDate)"
            );
            
            AlterStoredProcedure(
                "dbo.WebNoticeSearchHistory_Update",
                p => new
                    {
                        PlantCode = p.String(maxLength: 10),
                        DocCode = p.String(maxLength: 20),
                        Seq = p.Int(),
                        VendorCode = p.String(maxLength: 10),
                        PersonID = p.String(maxLength: 20),
                        SearchDatetime = p.DateTime(),
                        CreateIP = p.String(maxLength: 15),
                        CreateID = p.String(maxLength: 20),
                        CreateDate = p.DateTime(),
                        ModifyIP = p.String(maxLength: 15),
                        ModifyID = p.String(maxLength: 20),
                        ModifyDate = p.DateTime(),
                    },
                body:
                    @"UPDATE [QRP].[SYSWebNoticeSearchHistory]
                      SET [VendorCode] = @VendorCode, [PersonID] = @PersonID, [SearchDatetime] = @SearchDatetime, [CreateIP] = @CreateIP, [CreateID] = @CreateID, [CreateDate] = @CreateDate, [ModifyIP] = @ModifyIP, [ModifyID] = @ModifyID, [ModifyDate] = @ModifyDate
                      WHERE ((([PlantCode] = @PlantCode) AND ([DocCode] = @DocCode)) AND ([Seq] = @Seq))"
            );
            
        }
        
        public override void Down()
        {
            DropForeignKey("QRP.MASVendorP", "VendorCode", "QRP.MASVendor");
            DropForeignKey("QRP.MASProductVendor", "PrdVendorCode", "QRP.MASVendor");
            DropIndex("QRP.MASVendorP", new[] { "VendorCode" });
            DropIndex("QRP.MASProductVendor", new[] { "PrdVendorCode" });
            DropPrimaryKey("QRP.MASVendor");
            DropPrimaryKey("QRP.MASVendorP");
            AlterColumn("QRP.SYSWebNoticeSearchHistory", "VendorCode", c => c.String(maxLength: 20));
            AlterColumn("QRP.SYSWebNotice", "CompleteFlag", c => c.Boolean(nullable: false));
            AlterColumn("QRP.SYSWebNotice", "WriteDate", c => c.DateTime());
            AlterColumn("QRP.SYSWebBoardSearchHistory", "VendorCode", c => c.String(maxLength: 20));
            AlterColumn("QRP.SYSWebBoard", "WriteDate", c => c.DateTime());
            AlterColumn("QRP.SYSWebBoard", "VendorCode", c => c.String(maxLength: 20));
            AlterColumn("QRP.MASVendor", "UseFlag", c => c.Boolean(nullable: false));
            AlterColumn("QRP.MASVendor", "VendorCode", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("QRP.MASVendorP", "UseFlag", c => c.Boolean(nullable: false));
            AlterColumn("QRP.MASVendorP", "VendorCode", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("QRP.SYSWebBarCode", "SupplyDate", c => c.DateTime());
            AlterColumn("QRP.SYSWebBarCode", "ProductDate", c => c.DateTime());
            AlterColumn("QRP.MASProductVendor", "SupVendorCode", c => c.String(maxLength: 20));
            AlterColumn("QRP.MASProductVendor", "PrdVendorCode", c => c.String(maxLength: 20));
            AlterColumn("QRP.MASMaterialType", "UseFlag", c => c.Boolean(nullable: false));
            AlterColumn("QRP.MASProduct", "UseFlag", c => c.Boolean(nullable: false));
            AlterColumn("QRP.MASProduct", "SerialUseFlag", c => c.Boolean(nullable: false));
            AlterColumn("QRP.MASProduct", "InspectFlag", c => c.Boolean(nullable: false));
            AlterColumn("QRP.MASMaterialGroup", "UseFlag", c => c.Boolean(nullable: false));
            AddPrimaryKey("QRP.MASVendor", "VendorCode");
            AddPrimaryKey("QRP.MASVendorP", new[] { "VendorCode", "Seq" });
            CreateIndex("QRP.MASVendorP", "VendorCode");
            CreateIndex("QRP.MASProductVendor", "PrdVendorCode");
            AddForeignKey("QRP.MASVendorP", "VendorCode", "QRP.MASVendor", "VendorCode", cascadeDelete: true);
            AddForeignKey("QRP.MASProductVendor", "PrdVendorCode", "QRP.MASVendor", "VendorCode");
            throw new NotSupportedException("Scaffolding create or alter procedure operations is not supported in down methods.");
        }
    }
}
