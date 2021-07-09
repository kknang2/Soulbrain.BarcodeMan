namespace Soulbrain.BarcodeMan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial_Create : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "QRP.MASMaterialGroup",
                c => new
                    {
                        PlantCode = c.String(nullable: false, maxLength: 10),
                        MaterialGroupCode = c.String(nullable: false, maxLength: 10),
                        MaterialGroupName = c.String(maxLength: 100),
                        MaterialGroupNameCh = c.String(maxLength: 100),
                        MaterialGroupNameEn = c.String(maxLength: 100),
                        UseFlag = c.Boolean(nullable: false),
                        CreateIP = c.String(maxLength: 15),
                        CreateID = c.String(maxLength: 20),
                        CreateDate = c.DateTime(),
                        ModifyIP = c.String(maxLength: 15),
                        ModifyID = c.String(maxLength: 20),
                        ModifyDate = c.DateTime(),
                    })
                .PrimaryKey(t => new { t.PlantCode, t.MaterialGroupCode });
            
            CreateTable(
                "QRP.MASProduct",
                c => new
                    {
                        PlantCode = c.String(nullable: false, maxLength: 10),
                        ProductCode = c.String(nullable: false, maxLength: 20),
                        ProductName = c.String(maxLength: 300),
                        ProductNameCh = c.String(maxLength: 300),
                        ProductNameEn = c.String(maxLength: 300),
                        MaterialGroupCode = c.String(maxLength: 10),
                        MaterialTypeCode = c.String(maxLength: 10),
                        Spec = c.String(maxLength: 300),
                        DrawingNo = c.String(maxLength: 30),
                        CarTypeCode = c.String(maxLength: 10),
                        SecondNo = c.String(maxLength: 30),
                        MoldingEquipCode = c.String(maxLength: 10),
                        MeltingFurnaceCode = c.String(maxLength: 10),
                        ProductWeight = c.Decimal(precision: 10, scale: 2),
                        Cavity = c.Int(nullable: false),
                        ProductQuality = c.String(maxLength: 10),
                        NetPrice = c.Decimal(precision: 15, scale: 4),
                        CoreType = c.String(maxLength: 1),
                        RealProductWeight = c.Decimal(precision: 10, scale: 2),
                        MarketType = c.String(maxLength: 1),
                        RecoverRate = c.Decimal(precision: 10, scale: 2),
                        PourWeight = c.Decimal(precision: 10, scale: 2),
                        AttachCount1 = c.Int(),
                        AttachCount2 = c.Int(),
                        BaseUnitCode = c.String(maxLength: 10),
                        WorkLotSize = c.Decimal(precision: 20, scale: 5),
                        InspectFlag = c.Boolean(nullable: false),
                        InspectFaultInventoryCode = c.String(maxLength: 10),
                        AvailInventoryCode = c.String(maxLength: 10),
                        WorkInStandbyInventoryCode = c.String(maxLength: 10),
                        SizePerPack = c.Decimal(precision: 20, scale: 5),
                        PackUnitCode = c.String(maxLength: 10),
                        SerialUseFlag = c.Boolean(nullable: false),
                        ProdQtyPerProduct = c.Decimal(precision: 18, scale: 2),
                        InspectStandbyInventoryCode = c.String(maxLength: 10),
                        ProdTypeCode = c.String(maxLength: 10),
                        UseFlag = c.Boolean(nullable: false),
                        CreateIP = c.String(maxLength: 15),
                        CreateID = c.String(maxLength: 20),
                        CreateDate = c.DateTime(),
                        ModifyIP = c.String(maxLength: 15),
                        ModifyID = c.String(maxLength: 20),
                        ModifyDate = c.DateTime(),
                    })
                .PrimaryKey(t => new { t.PlantCode, t.ProductCode })
                .ForeignKey("QRP.MASMaterialGroup", t => new { t.PlantCode, t.MaterialGroupCode })
                .ForeignKey("QRP.MASMaterialType", t => new { t.PlantCode, t.MaterialTypeCode })
                .Index(t => new { t.PlantCode, t.MaterialGroupCode })
                .Index(t => new { t.PlantCode, t.MaterialTypeCode });
            
            CreateTable(
                "QRP.MASMaterialType",
                c => new
                    {
                        PlantCode = c.String(nullable: false, maxLength: 10),
                        MaterialTypeCode = c.String(nullable: false, maxLength: 10),
                        MaterialTypeName = c.String(maxLength: 100),
                        MaterialTypeNameCh = c.String(maxLength: 100),
                        MaterialTypeNameEn = c.String(maxLength: 100),
                        UseFlag = c.Boolean(nullable: false),
                        CreateIP = c.String(maxLength: 15),
                        CreateID = c.String(maxLength: 20),
                        CreateDate = c.DateTime(),
                        ModifyIP = c.String(maxLength: 15),
                        ModifyID = c.String(maxLength: 20),
                        ModifyDate = c.DateTime(),
                    })
                .PrimaryKey(t => new { t.PlantCode, t.MaterialTypeCode });
            
            CreateTable(
                "QRP.MASProductVendor",
                c => new
                    {
                        PlantCode = c.String(nullable: false, maxLength: 10),
                        ProductCode = c.String(nullable: false, maxLength: 20),
                        Seq = c.Int(nullable: false),
                        PrdVendorCode = c.String(maxLength: 20),
                        SupVendorCode = c.String(maxLength: 20),
                        PackingQty = c.Decimal(precision: 15, scale: 5),
                        PackingUnitCode = c.String(maxLength: 10),
                        EtcDesc = c.String(maxLength: 500),
                        CreateIP = c.String(maxLength: 15),
                        CreateID = c.String(maxLength: 20),
                        CreateDate = c.DateTime(),
                        ModifyIP = c.String(maxLength: 15),
                        ModifyID = c.String(maxLength: 20),
                        ModifyDate = c.DateTime(),
                    })
                .PrimaryKey(t => new { t.PlantCode, t.ProductCode, t.Seq })
                .ForeignKey("QRP.MASProduct", t => new { t.PlantCode, t.ProductCode }, cascadeDelete: true)
                .ForeignKey("QRP.MASVendor", t => t.PrdVendorCode)
                .Index(t => new { t.PlantCode, t.ProductCode })
                .Index(t => t.PrdVendorCode);
            
            CreateTable(
                "QRP.SYSWebBarCode",
                c => new
                    {
                        PlantCode = c.String(nullable: false, maxLength: 10),
                        DocCode = c.String(nullable: false, maxLength: 20),
                        ProductCode = c.String(maxLength: 20),
                        SupplyQty = c.Decimal(precision: 15, scale: 5),
                        PackingUnitCode = c.String(maxLength: 10),
                        LotNo = c.String(maxLength: 100),
                        ProductDate = c.DateTime(),
                        ExpiryDate = c.String(maxLength: 10),
                        SupplyDate = c.DateTime(),
                        PrintQty = c.Int(),
                        PrintDatetime = c.DateTime(),
                        PrintType = c.String(maxLength: 10),
                        CreateIP = c.String(maxLength: 15),
                        CreateID = c.String(maxLength: 20),
                        CreateDate = c.DateTime(),
                        ModifyIP = c.String(maxLength: 15),
                        ModifyID = c.String(maxLength: 20),
                        ModifyDate = c.DateTime(),
                    })
                .PrimaryKey(t => new { t.PlantCode, t.DocCode })
                .ForeignKey("QRP.MASProduct", t => new { t.PlantCode, t.ProductCode })
                .Index(t => new { t.PlantCode, t.ProductCode });
            
            CreateTable(
                "QRP.MASVendorP",
                c => new
                    {
                        VendorCode = c.String(nullable: false, maxLength: 20),
                        Seq = c.Int(nullable: false),
                        PersonID = c.String(maxLength: 20),
                        PersonPW = c.String(maxLength: 100),
                        PersonJob = c.String(maxLength: 100),
                        PersonDeptName = c.String(maxLength: 100),
                        PersonName = c.String(maxLength: 100),
                        PersonPosition = c.String(maxLength: 100),
                        PersonTel = c.String(maxLength: 20),
                        PersonHp = c.String(maxLength: 50),
                        PersonEMail = c.String(),
                        EtcDesc = c.String(maxLength: 1000),
                        UseFlag = c.Boolean(nullable: false),
                        CreateIP = c.String(maxLength: 15),
                        CreateID = c.String(maxLength: 20),
                        CreateDate = c.DateTime(),
                        ModifyIP = c.String(maxLength: 15),
                        ModifyID = c.String(maxLength: 20),
                        ModifyDate = c.DateTime(),
                    })
                .PrimaryKey(t => new { t.VendorCode, t.Seq })
                .ForeignKey("QRP.MASVendor", t => t.VendorCode, cascadeDelete: true)
                .Index(t => t.VendorCode);
            
            CreateTable(
                "QRP.MASVendor",
                c => new
                    {
                        VendorCode = c.String(nullable: false, maxLength: 20),
                        VendorName = c.String(maxLength: 100),
                        VendorNameCh = c.String(maxLength: 100),
                        VendorNameEn = c.String(maxLength: 100),
                        RegNo = c.String(maxLength: 100),
                        BossName = c.String(maxLength: 100),
                        Tel = c.String(maxLength: 20),
                        Fax = c.String(maxLength: 20),
                        Address = c.String(maxLength: 300),
                        UseFlag = c.Boolean(nullable: false),
                        CreateIP = c.String(maxLength: 15),
                        CreateID = c.String(maxLength: 20),
                        CreateDate = c.DateTime(),
                        ModifyIP = c.String(maxLength: 15),
                        ModifyID = c.String(maxLength: 20),
                        ModifyDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.VendorCode);
            
            CreateTable(
                "QRP.SYSWebBoardComment",
                c => new
                    {
                        PlantCode = c.String(nullable: false, maxLength: 10),
                        DocCode = c.String(nullable: false, maxLength: 20),
                        Seq = c.Int(nullable: false),
                        Comment = c.String(maxLength: 1000),
                        WriteID = c.String(maxLength: 20),
                        WriteDatetime = c.DateTime(),
                        CreateIP = c.String(maxLength: 15),
                        CreateID = c.String(maxLength: 20),
                        CreateDate = c.DateTime(),
                        ModifyIP = c.String(maxLength: 15),
                        ModifyID = c.String(maxLength: 20),
                        ModifyDate = c.DateTime(),
                    })
                .PrimaryKey(t => new { t.PlantCode, t.DocCode, t.Seq })
                .ForeignKey("QRP.SYSWebBoard", t => new { t.PlantCode, t.DocCode }, cascadeDelete: true)
                .Index(t => new { t.PlantCode, t.DocCode });
            
            CreateTable(
                "QRP.SYSWebBoard",
                c => new
                    {
                        PlantCode = c.String(nullable: false, maxLength: 10),
                        DocCode = c.String(nullable: false, maxLength: 20),
                        VendorCode = c.String(maxLength: 20),
                        TitleKor = c.String(maxLength: 1000),
                        TitleEng = c.String(maxLength: 1000),
                        WriteID = c.String(maxLength: 20),
                        WriteDate = c.DateTime(),
                        BoardType = c.String(maxLength: 10),
                        ContentsKor = c.String(maxLength: 4000),
                        ContentsEng = c.String(maxLength: 4000),
                        CreateIP = c.String(maxLength: 15),
                        CreateID = c.String(maxLength: 20),
                        CreateDate = c.DateTime(),
                        ModifyIP = c.String(maxLength: 15),
                        ModifyID = c.String(maxLength: 20),
                        ModifyDate = c.DateTime(),
                    })
                .PrimaryKey(t => new { t.PlantCode, t.DocCode });
            
            CreateTable(
                "QRP.SYSWebBoardFile",
                c => new
                    {
                        PlantCode = c.String(nullable: false, maxLength: 10),
                        DocCode = c.String(nullable: false, maxLength: 20),
                        Seq = c.Int(nullable: false),
                        EtcDescKor = c.String(maxLength: 1000),
                        EtcDescEng = c.String(maxLength: 1000),
                        FileName = c.String(maxLength: 4000),
                        FileGUID = c.String(maxLength: 4000),
                        CreateIP = c.String(maxLength: 15),
                        CreateID = c.String(maxLength: 20),
                        CreateDate = c.DateTime(),
                        ModifyIP = c.String(maxLength: 15),
                        ModifyID = c.String(maxLength: 20),
                        ModifyDate = c.DateTime(),
                    })
                .PrimaryKey(t => new { t.PlantCode, t.DocCode, t.Seq })
                .ForeignKey("QRP.SYSWebBoard", t => new { t.PlantCode, t.DocCode }, cascadeDelete: true)
                .Index(t => new { t.PlantCode, t.DocCode });
            
            CreateTable(
                "QRP.SYSWebBoardSearchHistory",
                c => new
                    {
                        PlantCode = c.String(nullable: false, maxLength: 10),
                        DocCode = c.String(nullable: false, maxLength: 20),
                        Seq = c.Int(nullable: false),
                        VendorCode = c.String(maxLength: 20),
                        PersonID = c.String(maxLength: 20),
                        SearchDatetime = c.DateTime(),
                        CreateIP = c.String(maxLength: 15),
                        CreateID = c.String(maxLength: 20),
                        CreateDate = c.DateTime(),
                        ModifyIP = c.String(maxLength: 15),
                        ModifyID = c.String(maxLength: 20),
                        ModifyDate = c.DateTime(),
                    })
                .PrimaryKey(t => new { t.PlantCode, t.DocCode, t.Seq })
                .ForeignKey("QRP.SYSWebBoard", t => new { t.PlantCode, t.DocCode }, cascadeDelete: true)
                .Index(t => new { t.PlantCode, t.DocCode });
            
            CreateTable(
                "QRP.SYSWebNoticeFile",
                c => new
                    {
                        PlantCode = c.String(nullable: false, maxLength: 10),
                        DocCode = c.String(nullable: false, maxLength: 20),
                        Seq = c.Int(nullable: false),
                        EtcDescKor = c.String(maxLength: 1000),
                        EtcDescEng = c.String(maxLength: 1000),
                        FileName = c.String(maxLength: 4000),
                        FileGUID = c.String(maxLength: 4000),
                        CreateIP = c.String(maxLength: 15),
                        CreateID = c.String(maxLength: 20),
                        CreateDate = c.DateTime(),
                        ModifyIP = c.String(maxLength: 15),
                        ModifyID = c.String(maxLength: 20),
                        ModifyDate = c.DateTime(),
                    })
                .PrimaryKey(t => new { t.PlantCode, t.DocCode, t.Seq })
                .ForeignKey("QRP.SYSWebNotice", t => new { t.PlantCode, t.DocCode }, cascadeDelete: true)
                .Index(t => new { t.PlantCode, t.DocCode });
            
            CreateTable(
                "QRP.SYSWebNotice",
                c => new
                    {
                        PlantCode = c.String(nullable: false, maxLength: 10),
                        DocCode = c.String(nullable: false, maxLength: 20),
                        TitleKor = c.String(maxLength: 1000),
                        TitleEng = c.String(maxLength: 1000),
                        WriteID = c.String(maxLength: 20),
                        WriteDate = c.DateTime(),
                        NoticeType = c.String(maxLength: 10),
                        CompleteFlag = c.Boolean(nullable: false),
                        ContentsKor = c.String(maxLength: 4000),
                        ContentsEng = c.String(maxLength: 4000),
                        CreateIP = c.String(maxLength: 15),
                        CreateID = c.String(maxLength: 20),
                        CreateDate = c.DateTime(),
                        ModifyIP = c.String(maxLength: 15),
                        ModifyID = c.String(maxLength: 20),
                        ModifyDate = c.DateTime(),
                    })
                .PrimaryKey(t => new { t.PlantCode, t.DocCode });
            
            CreateTable(
                "QRP.SYSWebNoticeSearchHistory",
                c => new
                    {
                        PlantCode = c.String(nullable: false, maxLength: 10),
                        DocCode = c.String(nullable: false, maxLength: 20),
                        Seq = c.Int(nullable: false),
                        VendorCode = c.String(maxLength: 20),
                        PersonID = c.String(maxLength: 20),
                        SearchDatetime = c.DateTime(),
                        CreateIP = c.String(maxLength: 15),
                        CreateID = c.String(maxLength: 20),
                        CreateDate = c.DateTime(),
                        ModifyIP = c.String(maxLength: 15),
                        ModifyID = c.String(maxLength: 20),
                        ModifyDate = c.DateTime(),
                    })
                .PrimaryKey(t => new { t.PlantCode, t.DocCode, t.Seq })
                .ForeignKey("QRP.SYSWebNotice", t => new { t.PlantCode, t.DocCode }, cascadeDelete: true)
                .Index(t => new { t.PlantCode, t.DocCode });
            
            CreateStoredProcedure(
                "dbo.MaterialGroup_Insert",
                p => new
                    {
                        PlantCode = p.String(maxLength: 10),
                        MaterialGroupCode = p.String(maxLength: 10),
                        MaterialGroupName = p.String(maxLength: 100),
                        MaterialGroupNameCh = p.String(maxLength: 100),
                        MaterialGroupNameEn = p.String(maxLength: 100),
                        UseFlag = p.Boolean(),
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
            
            CreateStoredProcedure(
                "dbo.MaterialGroup_Update",
                p => new
                    {
                        PlantCode = p.String(maxLength: 10),
                        MaterialGroupCode = p.String(maxLength: 10),
                        MaterialGroupName = p.String(maxLength: 100),
                        MaterialGroupNameCh = p.String(maxLength: 100),
                        MaterialGroupNameEn = p.String(maxLength: 100),
                        UseFlag = p.Boolean(),
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
            
            CreateStoredProcedure(
                "dbo.MaterialGroup_Delete",
                p => new
                    {
                        PlantCode = p.String(maxLength: 10),
                        MaterialGroupCode = p.String(maxLength: 10),
                    },
                body:
                    @"DELETE [QRP].[MASMaterialGroup]
                      WHERE (([PlantCode] = @PlantCode) AND ([MaterialGroupCode] = @MaterialGroupCode))"
            );
            
            CreateStoredProcedure(
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
                        AttachCount1 = p.Int(),
                        AttachCount2 = p.Int(),
                        BaseUnitCode = p.String(maxLength: 10),
                        WorkLotSize = p.Decimal(precision: 20, scale: 5),
                        InspectFlag = p.Boolean(),
                        InspectFaultInventoryCode = p.String(maxLength: 10),
                        AvailInventoryCode = p.String(maxLength: 10),
                        WorkInStandbyInventoryCode = p.String(maxLength: 10),
                        SizePerPack = p.Decimal(precision: 20, scale: 5),
                        PackUnitCode = p.String(maxLength: 10),
                        SerialUseFlag = p.Boolean(),
                        ProdQtyPerProduct = p.Decimal(precision: 18, scale: 2),
                        InspectStandbyInventoryCode = p.String(maxLength: 10),
                        ProdTypeCode = p.String(maxLength: 10),
                        UseFlag = p.Boolean(),
                        CreateIP = p.String(maxLength: 15),
                        CreateID = p.String(maxLength: 20),
                        CreateDate = p.DateTime(),
                        ModifyIP = p.String(maxLength: 15),
                        ModifyID = p.String(maxLength: 20),
                        ModifyDate = p.DateTime(),
                    },
                body:
                    @"INSERT [QRP].[MASProduct]([PlantCode], [ProductCode], [ProductName], [ProductNameCh], [ProductNameEn], [MaterialGroupCode], [MaterialTypeCode], [Spec], [DrawingNo], [CarTypeCode], [SecondNo], [MoldingEquipCode], [MeltingFurnaceCode], [ProductWeight], [Cavity], [ProductQuality], [NetPrice], [CoreType], [RealProductWeight], [MarketType], [RecoverRate], [PourWeight], [AttachCount1], [AttachCount2], [BaseUnitCode], [WorkLotSize], [InspectFlag], [InspectFaultInventoryCode], [AvailInventoryCode], [WorkInStandbyInventoryCode], [SizePerPack], [PackUnitCode], [SerialUseFlag], [ProdQtyPerProduct], [InspectStandbyInventoryCode], [ProdTypeCode], [UseFlag], [CreateIP], [CreateID], [CreateDate], [ModifyIP], [ModifyID], [ModifyDate])
                      VALUES (@PlantCode, @ProductCode, @ProductName, @ProductNameCh, @ProductNameEn, @MaterialGroupCode, @MaterialTypeCode, @Spec, @DrawingNo, @CarTypeCode, @SecondNo, @MoldingEquipCode, @MeltingFurnaceCode, @ProductWeight, @Cavity, @ProductQuality, @NetPrice, @CoreType, @RealProductWeight, @MarketType, @RecoverRate, @PourWeight, @AttachCount1, @AttachCount2, @BaseUnitCode, @WorkLotSize, @InspectFlag, @InspectFaultInventoryCode, @AvailInventoryCode, @WorkInStandbyInventoryCode, @SizePerPack, @PackUnitCode, @SerialUseFlag, @ProdQtyPerProduct, @InspectStandbyInventoryCode, @ProdTypeCode, @UseFlag, @CreateIP, @CreateID, @CreateDate, @ModifyIP, @ModifyID, @ModifyDate)"
            );
            
            CreateStoredProcedure(
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
                        AttachCount1 = p.Int(),
                        AttachCount2 = p.Int(),
                        BaseUnitCode = p.String(maxLength: 10),
                        WorkLotSize = p.Decimal(precision: 20, scale: 5),
                        InspectFlag = p.Boolean(),
                        InspectFaultInventoryCode = p.String(maxLength: 10),
                        AvailInventoryCode = p.String(maxLength: 10),
                        WorkInStandbyInventoryCode = p.String(maxLength: 10),
                        SizePerPack = p.Decimal(precision: 20, scale: 5),
                        PackUnitCode = p.String(maxLength: 10),
                        SerialUseFlag = p.Boolean(),
                        ProdQtyPerProduct = p.Decimal(precision: 18, scale: 2),
                        InspectStandbyInventoryCode = p.String(maxLength: 10),
                        ProdTypeCode = p.String(maxLength: 10),
                        UseFlag = p.Boolean(),
                        CreateIP = p.String(maxLength: 15),
                        CreateID = p.String(maxLength: 20),
                        CreateDate = p.DateTime(),
                        ModifyIP = p.String(maxLength: 15),
                        ModifyID = p.String(maxLength: 20),
                        ModifyDate = p.DateTime(),
                    },
                body:
                    @"UPDATE [QRP].[MASProduct]
                      SET [ProductName] = @ProductName, [ProductNameCh] = @ProductNameCh, [ProductNameEn] = @ProductNameEn, [MaterialGroupCode] = @MaterialGroupCode, [MaterialTypeCode] = @MaterialTypeCode, [Spec] = @Spec, [DrawingNo] = @DrawingNo, [CarTypeCode] = @CarTypeCode, [SecondNo] = @SecondNo, [MoldingEquipCode] = @MoldingEquipCode, [MeltingFurnaceCode] = @MeltingFurnaceCode, [ProductWeight] = @ProductWeight, [Cavity] = @Cavity, [ProductQuality] = @ProductQuality, [NetPrice] = @NetPrice, [CoreType] = @CoreType, [RealProductWeight] = @RealProductWeight, [MarketType] = @MarketType, [RecoverRate] = @RecoverRate, [PourWeight] = @PourWeight, [AttachCount1] = @AttachCount1, [AttachCount2] = @AttachCount2, [BaseUnitCode] = @BaseUnitCode, [WorkLotSize] = @WorkLotSize, [InspectFlag] = @InspectFlag, [InspectFaultInventoryCode] = @InspectFaultInventoryCode, [AvailInventoryCode] = @AvailInventoryCode, [WorkInStandbyInventoryCode] = @WorkInStandbyInventoryCode, [SizePerPack] = @SizePerPack, [PackUnitCode] = @PackUnitCode, [SerialUseFlag] = @SerialUseFlag, [ProdQtyPerProduct] = @ProdQtyPerProduct, [InspectStandbyInventoryCode] = @InspectStandbyInventoryCode, [ProdTypeCode] = @ProdTypeCode, [UseFlag] = @UseFlag, [CreateIP] = @CreateIP, [CreateID] = @CreateID, [CreateDate] = @CreateDate, [ModifyIP] = @ModifyIP, [ModifyID] = @ModifyID, [ModifyDate] = @ModifyDate
                      WHERE (([PlantCode] = @PlantCode) AND ([ProductCode] = @ProductCode))"
            );
            
            CreateStoredProcedure(
                "dbo.Product_Delete",
                p => new
                    {
                        PlantCode = p.String(maxLength: 10),
                        ProductCode = p.String(maxLength: 20),
                    },
                body:
                    @"DELETE [QRP].[MASProduct]
                      WHERE (([PlantCode] = @PlantCode) AND ([ProductCode] = @ProductCode))"
            );
            
            CreateStoredProcedure(
                "dbo.MaterialType_Insert",
                p => new
                    {
                        PlantCode = p.String(maxLength: 10),
                        MaterialTypeCode = p.String(maxLength: 10),
                        MaterialTypeName = p.String(maxLength: 100),
                        MaterialTypeNameCh = p.String(maxLength: 100),
                        MaterialTypeNameEn = p.String(maxLength: 100),
                        UseFlag = p.Boolean(),
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
            
            CreateStoredProcedure(
                "dbo.MaterialType_Update",
                p => new
                    {
                        PlantCode = p.String(maxLength: 10),
                        MaterialTypeCode = p.String(maxLength: 10),
                        MaterialTypeName = p.String(maxLength: 100),
                        MaterialTypeNameCh = p.String(maxLength: 100),
                        MaterialTypeNameEn = p.String(maxLength: 100),
                        UseFlag = p.Boolean(),
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
            
            CreateStoredProcedure(
                "dbo.MaterialType_Delete",
                p => new
                    {
                        PlantCode = p.String(maxLength: 10),
                        MaterialTypeCode = p.String(maxLength: 10),
                    },
                body:
                    @"DELETE [QRP].[MASMaterialType]
                      WHERE (([PlantCode] = @PlantCode) AND ([MaterialTypeCode] = @MaterialTypeCode))"
            );
            
            CreateStoredProcedure(
                "dbo.ProductVendor_Insert",
                p => new
                    {
                        PlantCode = p.String(maxLength: 10),
                        ProductCode = p.String(maxLength: 20),
                        Seq = p.Int(),
                        PrdVendorCode = p.String(maxLength: 20),
                        SupVendorCode = p.String(maxLength: 20),
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
            
            CreateStoredProcedure(
                "dbo.ProductVendor_Update",
                p => new
                    {
                        PlantCode = p.String(maxLength: 10),
                        ProductCode = p.String(maxLength: 20),
                        Seq = p.Int(),
                        PrdVendorCode = p.String(maxLength: 20),
                        SupVendorCode = p.String(maxLength: 20),
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
            
            CreateStoredProcedure(
                "dbo.ProductVendor_Delete",
                p => new
                    {
                        PlantCode = p.String(maxLength: 10),
                        ProductCode = p.String(maxLength: 20),
                        Seq = p.Int(),
                    },
                body:
                    @"DELETE [QRP].[MASProductVendor]
                      WHERE ((([PlantCode] = @PlantCode) AND ([ProductCode] = @ProductCode)) AND ([Seq] = @Seq))"
            );
            
            CreateStoredProcedure(
                "dbo.WebBarCode_Insert",
                p => new
                    {
                        PlantCode = p.String(maxLength: 10),
                        DocCode = p.String(maxLength: 20),
                        ProductCode = p.String(maxLength: 20),
                        SupplyQty = p.Decimal(precision: 15, scale: 5),
                        PackingUnitCode = p.String(maxLength: 10),
                        LotNo = p.String(maxLength: 100),
                        ProductDate = p.DateTime(),
                        ExpiryDate = p.String(maxLength: 10),
                        SupplyDate = p.DateTime(),
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
            
            CreateStoredProcedure(
                "dbo.WebBarCode_Update",
                p => new
                    {
                        PlantCode = p.String(maxLength: 10),
                        DocCode = p.String(maxLength: 20),
                        ProductCode = p.String(maxLength: 20),
                        SupplyQty = p.Decimal(precision: 15, scale: 5),
                        PackingUnitCode = p.String(maxLength: 10),
                        LotNo = p.String(maxLength: 100),
                        ProductDate = p.DateTime(),
                        ExpiryDate = p.String(maxLength: 10),
                        SupplyDate = p.DateTime(),
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
            
            CreateStoredProcedure(
                "dbo.WebBarCode_Delete",
                p => new
                    {
                        PlantCode = p.String(maxLength: 10),
                        DocCode = p.String(maxLength: 20),
                    },
                body:
                    @"DELETE [QRP].[SYSWebBarCode]
                      WHERE (([PlantCode] = @PlantCode) AND ([DocCode] = @DocCode))"
            );
            
            CreateStoredProcedure(
                "dbo.VendorP_Insert",
                p => new
                    {
                        VendorCode = p.String(maxLength: 20),
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
                        UseFlag = p.Boolean(),
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
            
            CreateStoredProcedure(
                "dbo.VendorP_Update",
                p => new
                    {
                        VendorCode = p.String(maxLength: 20),
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
                        UseFlag = p.Boolean(),
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
            
            CreateStoredProcedure(
                "dbo.VendorP_Delete",
                p => new
                    {
                        VendorCode = p.String(maxLength: 20),
                        Seq = p.Int(),
                    },
                body:
                    @"DELETE [QRP].[MASVendorP]
                      WHERE (([VendorCode] = @VendorCode) AND ([Seq] = @Seq))"
            );
            
            CreateStoredProcedure(
                "dbo.Vendor_Insert",
                p => new
                    {
                        VendorCode = p.String(maxLength: 20),
                        VendorName = p.String(maxLength: 100),
                        VendorNameCh = p.String(maxLength: 100),
                        VendorNameEn = p.String(maxLength: 100),
                        RegNo = p.String(maxLength: 100),
                        BossName = p.String(maxLength: 100),
                        Tel = p.String(maxLength: 20),
                        Fax = p.String(maxLength: 20),
                        Address = p.String(maxLength: 300),
                        UseFlag = p.Boolean(),
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
            
            CreateStoredProcedure(
                "dbo.Vendor_Update",
                p => new
                    {
                        VendorCode = p.String(maxLength: 20),
                        VendorName = p.String(maxLength: 100),
                        VendorNameCh = p.String(maxLength: 100),
                        VendorNameEn = p.String(maxLength: 100),
                        RegNo = p.String(maxLength: 100),
                        BossName = p.String(maxLength: 100),
                        Tel = p.String(maxLength: 20),
                        Fax = p.String(maxLength: 20),
                        Address = p.String(maxLength: 300),
                        UseFlag = p.Boolean(),
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
            
            CreateStoredProcedure(
                "dbo.Vendor_Delete",
                p => new
                    {
                        VendorCode = p.String(maxLength: 20),
                    },
                body:
                    @"DELETE [QRP].[MASVendor]
                      WHERE ([VendorCode] = @VendorCode)"
            );
            
            CreateStoredProcedure(
                "dbo.WebBoardComment_Insert",
                p => new
                    {
                        PlantCode = p.String(maxLength: 10),
                        DocCode = p.String(maxLength: 20),
                        Seq = p.Int(),
                        Comment = p.String(maxLength: 1000),
                        WriteID = p.String(maxLength: 20),
                        WriteDatetime = p.DateTime(),
                        CreateIP = p.String(maxLength: 15),
                        CreateID = p.String(maxLength: 20),
                        CreateDate = p.DateTime(),
                        ModifyIP = p.String(maxLength: 15),
                        ModifyID = p.String(maxLength: 20),
                        ModifyDate = p.DateTime(),
                    },
                body:
                    @"INSERT [QRP].[SYSWebBoardComment]([PlantCode], [DocCode], [Seq], [Comment], [WriteID], [WriteDatetime], [CreateIP], [CreateID], [CreateDate], [ModifyIP], [ModifyID], [ModifyDate])
                      VALUES (@PlantCode, @DocCode, @Seq, @Comment, @WriteID, @WriteDatetime, @CreateIP, @CreateID, @CreateDate, @ModifyIP, @ModifyID, @ModifyDate)"
            );
            
            CreateStoredProcedure(
                "dbo.WebBoardComment_Update",
                p => new
                    {
                        PlantCode = p.String(maxLength: 10),
                        DocCode = p.String(maxLength: 20),
                        Seq = p.Int(),
                        Comment = p.String(maxLength: 1000),
                        WriteID = p.String(maxLength: 20),
                        WriteDatetime = p.DateTime(),
                        CreateIP = p.String(maxLength: 15),
                        CreateID = p.String(maxLength: 20),
                        CreateDate = p.DateTime(),
                        ModifyIP = p.String(maxLength: 15),
                        ModifyID = p.String(maxLength: 20),
                        ModifyDate = p.DateTime(),
                    },
                body:
                    @"UPDATE [QRP].[SYSWebBoardComment]
                      SET [Comment] = @Comment, [WriteID] = @WriteID, [WriteDatetime] = @WriteDatetime, [CreateIP] = @CreateIP, [CreateID] = @CreateID, [CreateDate] = @CreateDate, [ModifyIP] = @ModifyIP, [ModifyID] = @ModifyID, [ModifyDate] = @ModifyDate
                      WHERE ((([PlantCode] = @PlantCode) AND ([DocCode] = @DocCode)) AND ([Seq] = @Seq))"
            );
            
            CreateStoredProcedure(
                "dbo.WebBoardComment_Delete",
                p => new
                    {
                        PlantCode = p.String(maxLength: 10),
                        DocCode = p.String(maxLength: 20),
                        Seq = p.Int(),
                    },
                body:
                    @"DELETE [QRP].[SYSWebBoardComment]
                      WHERE ((([PlantCode] = @PlantCode) AND ([DocCode] = @DocCode)) AND ([Seq] = @Seq))"
            );
            
            CreateStoredProcedure(
                "dbo.WebBoard_Insert",
                p => new
                    {
                        PlantCode = p.String(maxLength: 10),
                        DocCode = p.String(maxLength: 20),
                        VendorCode = p.String(maxLength: 20),
                        TitleKor = p.String(maxLength: 1000),
                        TitleEng = p.String(maxLength: 1000),
                        WriteID = p.String(maxLength: 20),
                        WriteDate = p.DateTime(),
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
            
            CreateStoredProcedure(
                "dbo.WebBoard_Update",
                p => new
                    {
                        PlantCode = p.String(maxLength: 10),
                        DocCode = p.String(maxLength: 20),
                        VendorCode = p.String(maxLength: 20),
                        TitleKor = p.String(maxLength: 1000),
                        TitleEng = p.String(maxLength: 1000),
                        WriteID = p.String(maxLength: 20),
                        WriteDate = p.DateTime(),
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
            
            CreateStoredProcedure(
                "dbo.WebBoard_Delete",
                p => new
                    {
                        PlantCode = p.String(maxLength: 10),
                        DocCode = p.String(maxLength: 20),
                    },
                body:
                    @"DELETE [QRP].[SYSWebBoard]
                      WHERE (([PlantCode] = @PlantCode) AND ([DocCode] = @DocCode))"
            );
            
            CreateStoredProcedure(
                "dbo.WebBoardFile_Insert",
                p => new
                    {
                        PlantCode = p.String(maxLength: 10),
                        DocCode = p.String(maxLength: 20),
                        Seq = p.Int(),
                        EtcDescKor = p.String(maxLength: 1000),
                        EtcDescEng = p.String(maxLength: 1000),
                        FileName = p.String(maxLength: 4000),
                        FileGUID = p.String(maxLength: 4000),
                        CreateIP = p.String(maxLength: 15),
                        CreateID = p.String(maxLength: 20),
                        CreateDate = p.DateTime(),
                        ModifyIP = p.String(maxLength: 15),
                        ModifyID = p.String(maxLength: 20),
                        ModifyDate = p.DateTime(),
                    },
                body:
                    @"INSERT [QRP].[SYSWebBoardFile]([PlantCode], [DocCode], [Seq], [EtcDescKor], [EtcDescEng], [FileName], [FileGUID], [CreateIP], [CreateID], [CreateDate], [ModifyIP], [ModifyID], [ModifyDate])
                      VALUES (@PlantCode, @DocCode, @Seq, @EtcDescKor, @EtcDescEng, @FileName, @FileGUID, @CreateIP, @CreateID, @CreateDate, @ModifyIP, @ModifyID, @ModifyDate)"
            );
            
            CreateStoredProcedure(
                "dbo.WebBoardFile_Update",
                p => new
                    {
                        PlantCode = p.String(maxLength: 10),
                        DocCode = p.String(maxLength: 20),
                        Seq = p.Int(),
                        EtcDescKor = p.String(maxLength: 1000),
                        EtcDescEng = p.String(maxLength: 1000),
                        FileName = p.String(maxLength: 4000),
                        FileGUID = p.String(maxLength: 4000),
                        CreateIP = p.String(maxLength: 15),
                        CreateID = p.String(maxLength: 20),
                        CreateDate = p.DateTime(),
                        ModifyIP = p.String(maxLength: 15),
                        ModifyID = p.String(maxLength: 20),
                        ModifyDate = p.DateTime(),
                    },
                body:
                    @"UPDATE [QRP].[SYSWebBoardFile]
                      SET [EtcDescKor] = @EtcDescKor, [EtcDescEng] = @EtcDescEng, [FileName] = @FileName, [FileGUID] = @FileGUID, [CreateIP] = @CreateIP, [CreateID] = @CreateID, [CreateDate] = @CreateDate, [ModifyIP] = @ModifyIP, [ModifyID] = @ModifyID, [ModifyDate] = @ModifyDate
                      WHERE ((([PlantCode] = @PlantCode) AND ([DocCode] = @DocCode)) AND ([Seq] = @Seq))"
            );
            
            CreateStoredProcedure(
                "dbo.WebBoardFile_Delete",
                p => new
                    {
                        PlantCode = p.String(maxLength: 10),
                        DocCode = p.String(maxLength: 20),
                        Seq = p.Int(),
                    },
                body:
                    @"DELETE [QRP].[SYSWebBoardFile]
                      WHERE ((([PlantCode] = @PlantCode) AND ([DocCode] = @DocCode)) AND ([Seq] = @Seq))"
            );
            
            CreateStoredProcedure(
                "dbo.WebBoardSearchHistory_Insert",
                p => new
                    {
                        PlantCode = p.String(maxLength: 10),
                        DocCode = p.String(maxLength: 20),
                        Seq = p.Int(),
                        VendorCode = p.String(maxLength: 20),
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
            
            CreateStoredProcedure(
                "dbo.WebBoardSearchHistory_Update",
                p => new
                    {
                        PlantCode = p.String(maxLength: 10),
                        DocCode = p.String(maxLength: 20),
                        Seq = p.Int(),
                        VendorCode = p.String(maxLength: 20),
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
            
            CreateStoredProcedure(
                "dbo.WebBoardSearchHistory_Delete",
                p => new
                    {
                        PlantCode = p.String(maxLength: 10),
                        DocCode = p.String(maxLength: 20),
                        Seq = p.Int(),
                    },
                body:
                    @"DELETE [QRP].[SYSWebBoardSearchHistory]
                      WHERE ((([PlantCode] = @PlantCode) AND ([DocCode] = @DocCode)) AND ([Seq] = @Seq))"
            );
            
            CreateStoredProcedure(
                "dbo.WebNoticeFile_Insert",
                p => new
                    {
                        PlantCode = p.String(maxLength: 10),
                        DocCode = p.String(maxLength: 20),
                        Seq = p.Int(),
                        EtcDescKor = p.String(maxLength: 1000),
                        EtcDescEng = p.String(maxLength: 1000),
                        FileName = p.String(maxLength: 4000),
                        FileGUID = p.String(maxLength: 4000),
                        CreateIP = p.String(maxLength: 15),
                        CreateID = p.String(maxLength: 20),
                        CreateDate = p.DateTime(),
                        ModifyIP = p.String(maxLength: 15),
                        ModifyID = p.String(maxLength: 20),
                        ModifyDate = p.DateTime(),
                    },
                body:
                    @"INSERT [QRP].[SYSWebNoticeFile]([PlantCode], [DocCode], [Seq], [EtcDescKor], [EtcDescEng], [FileName], [FileGUID], [CreateIP], [CreateID], [CreateDate], [ModifyIP], [ModifyID], [ModifyDate])
                      VALUES (@PlantCode, @DocCode, @Seq, @EtcDescKor, @EtcDescEng, @FileName, @FileGUID, @CreateIP, @CreateID, @CreateDate, @ModifyIP, @ModifyID, @ModifyDate)"
            );
            
            CreateStoredProcedure(
                "dbo.WebNoticeFile_Update",
                p => new
                    {
                        PlantCode = p.String(maxLength: 10),
                        DocCode = p.String(maxLength: 20),
                        Seq = p.Int(),
                        EtcDescKor = p.String(maxLength: 1000),
                        EtcDescEng = p.String(maxLength: 1000),
                        FileName = p.String(maxLength: 4000),
                        FileGUID = p.String(maxLength: 4000),
                        CreateIP = p.String(maxLength: 15),
                        CreateID = p.String(maxLength: 20),
                        CreateDate = p.DateTime(),
                        ModifyIP = p.String(maxLength: 15),
                        ModifyID = p.String(maxLength: 20),
                        ModifyDate = p.DateTime(),
                    },
                body:
                    @"UPDATE [QRP].[SYSWebNoticeFile]
                      SET [EtcDescKor] = @EtcDescKor, [EtcDescEng] = @EtcDescEng, [FileName] = @FileName, [FileGUID] = @FileGUID, [CreateIP] = @CreateIP, [CreateID] = @CreateID, [CreateDate] = @CreateDate, [ModifyIP] = @ModifyIP, [ModifyID] = @ModifyID, [ModifyDate] = @ModifyDate
                      WHERE ((([PlantCode] = @PlantCode) AND ([DocCode] = @DocCode)) AND ([Seq] = @Seq))"
            );
            
            CreateStoredProcedure(
                "dbo.WebNoticeFile_Delete",
                p => new
                    {
                        PlantCode = p.String(maxLength: 10),
                        DocCode = p.String(maxLength: 20),
                        Seq = p.Int(),
                    },
                body:
                    @"DELETE [QRP].[SYSWebNoticeFile]
                      WHERE ((([PlantCode] = @PlantCode) AND ([DocCode] = @DocCode)) AND ([Seq] = @Seq))"
            );
            
            CreateStoredProcedure(
                "dbo.WebNotice_Insert",
                p => new
                    {
                        PlantCode = p.String(maxLength: 10),
                        DocCode = p.String(maxLength: 20),
                        TitleKor = p.String(maxLength: 1000),
                        TitleEng = p.String(maxLength: 1000),
                        WriteID = p.String(maxLength: 20),
                        WriteDate = p.DateTime(),
                        NoticeType = p.String(maxLength: 10),
                        CompleteFlag = p.Boolean(),
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
            
            CreateStoredProcedure(
                "dbo.WebNotice_Update",
                p => new
                    {
                        PlantCode = p.String(maxLength: 10),
                        DocCode = p.String(maxLength: 20),
                        TitleKor = p.String(maxLength: 1000),
                        TitleEng = p.String(maxLength: 1000),
                        WriteID = p.String(maxLength: 20),
                        WriteDate = p.DateTime(),
                        NoticeType = p.String(maxLength: 10),
                        CompleteFlag = p.Boolean(),
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
            
            CreateStoredProcedure(
                "dbo.WebNotice_Delete",
                p => new
                    {
                        PlantCode = p.String(maxLength: 10),
                        DocCode = p.String(maxLength: 20),
                    },
                body:
                    @"DELETE [QRP].[SYSWebNotice]
                      WHERE (([PlantCode] = @PlantCode) AND ([DocCode] = @DocCode))"
            );
            
            CreateStoredProcedure(
                "dbo.WebNoticeSearchHistory_Insert",
                p => new
                    {
                        PlantCode = p.String(maxLength: 10),
                        DocCode = p.String(maxLength: 20),
                        Seq = p.Int(),
                        VendorCode = p.String(maxLength: 20),
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
            
            CreateStoredProcedure(
                "dbo.WebNoticeSearchHistory_Update",
                p => new
                    {
                        PlantCode = p.String(maxLength: 10),
                        DocCode = p.String(maxLength: 20),
                        Seq = p.Int(),
                        VendorCode = p.String(maxLength: 20),
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
            
            CreateStoredProcedure(
                "dbo.WebNoticeSearchHistory_Delete",
                p => new
                    {
                        PlantCode = p.String(maxLength: 10),
                        DocCode = p.String(maxLength: 20),
                        Seq = p.Int(),
                    },
                body:
                    @"DELETE [QRP].[SYSWebNoticeSearchHistory]
                      WHERE ((([PlantCode] = @PlantCode) AND ([DocCode] = @DocCode)) AND ([Seq] = @Seq))"
            );
            
        }
        
        public override void Down()
        {
            DropStoredProcedure("dbo.WebNoticeSearchHistory_Delete");
            DropStoredProcedure("dbo.WebNoticeSearchHistory_Update");
            DropStoredProcedure("dbo.WebNoticeSearchHistory_Insert");
            DropStoredProcedure("dbo.WebNotice_Delete");
            DropStoredProcedure("dbo.WebNotice_Update");
            DropStoredProcedure("dbo.WebNotice_Insert");
            DropStoredProcedure("dbo.WebNoticeFile_Delete");
            DropStoredProcedure("dbo.WebNoticeFile_Update");
            DropStoredProcedure("dbo.WebNoticeFile_Insert");
            DropStoredProcedure("dbo.WebBoardSearchHistory_Delete");
            DropStoredProcedure("dbo.WebBoardSearchHistory_Update");
            DropStoredProcedure("dbo.WebBoardSearchHistory_Insert");
            DropStoredProcedure("dbo.WebBoardFile_Delete");
            DropStoredProcedure("dbo.WebBoardFile_Update");
            DropStoredProcedure("dbo.WebBoardFile_Insert");
            DropStoredProcedure("dbo.WebBoard_Delete");
            DropStoredProcedure("dbo.WebBoard_Update");
            DropStoredProcedure("dbo.WebBoard_Insert");
            DropStoredProcedure("dbo.WebBoardComment_Delete");
            DropStoredProcedure("dbo.WebBoardComment_Update");
            DropStoredProcedure("dbo.WebBoardComment_Insert");
            DropStoredProcedure("dbo.Vendor_Delete");
            DropStoredProcedure("dbo.Vendor_Update");
            DropStoredProcedure("dbo.Vendor_Insert");
            DropStoredProcedure("dbo.VendorP_Delete");
            DropStoredProcedure("dbo.VendorP_Update");
            DropStoredProcedure("dbo.VendorP_Insert");
            DropStoredProcedure("dbo.WebBarCode_Delete");
            DropStoredProcedure("dbo.WebBarCode_Update");
            DropStoredProcedure("dbo.WebBarCode_Insert");
            DropStoredProcedure("dbo.ProductVendor_Delete");
            DropStoredProcedure("dbo.ProductVendor_Update");
            DropStoredProcedure("dbo.ProductVendor_Insert");
            DropStoredProcedure("dbo.MaterialType_Delete");
            DropStoredProcedure("dbo.MaterialType_Update");
            DropStoredProcedure("dbo.MaterialType_Insert");
            DropStoredProcedure("dbo.Product_Delete");
            DropStoredProcedure("dbo.Product_Update");
            DropStoredProcedure("dbo.Product_Insert");
            DropStoredProcedure("dbo.MaterialGroup_Delete");
            DropStoredProcedure("dbo.MaterialGroup_Update");
            DropStoredProcedure("dbo.MaterialGroup_Insert");
            DropForeignKey("QRP.SYSWebNoticeSearchHistory", new[] { "PlantCode", "DocCode" }, "QRP.SYSWebNotice");
            DropForeignKey("QRP.SYSWebNoticeFile", new[] { "PlantCode", "DocCode" }, "QRP.SYSWebNotice");
            DropForeignKey("QRP.SYSWebBoardSearchHistory", new[] { "PlantCode", "DocCode" }, "QRP.SYSWebBoard");
            DropForeignKey("QRP.SYSWebBoardComment", new[] { "PlantCode", "DocCode" }, "QRP.SYSWebBoard");
            DropForeignKey("QRP.SYSWebBoardFile", new[] { "PlantCode", "DocCode" }, "QRP.SYSWebBoard");
            DropForeignKey("QRP.MASVendorP", "VendorCode", "QRP.MASVendor");
            DropForeignKey("QRP.MASProductVendor", "PrdVendorCode", "QRP.MASVendor");
            DropForeignKey("QRP.SYSWebBarCode", new[] { "PlantCode", "ProductCode" }, "QRP.MASProduct");
            DropForeignKey("QRP.MASProductVendor", new[] { "PlantCode", "ProductCode" }, "QRP.MASProduct");
            DropForeignKey("QRP.MASProduct", new[] { "PlantCode", "MaterialTypeCode" }, "QRP.MASMaterialType");
            DropForeignKey("QRP.MASProduct", new[] { "PlantCode", "MaterialGroupCode" }, "QRP.MASMaterialGroup");
            DropIndex("QRP.SYSWebNoticeSearchHistory", new[] { "PlantCode", "DocCode" });
            DropIndex("QRP.SYSWebNoticeFile", new[] { "PlantCode", "DocCode" });
            DropIndex("QRP.SYSWebBoardSearchHistory", new[] { "PlantCode", "DocCode" });
            DropIndex("QRP.SYSWebBoardFile", new[] { "PlantCode", "DocCode" });
            DropIndex("QRP.SYSWebBoardComment", new[] { "PlantCode", "DocCode" });
            DropIndex("QRP.MASVendorP", new[] { "VendorCode" });
            DropIndex("QRP.SYSWebBarCode", new[] { "PlantCode", "ProductCode" });
            DropIndex("QRP.MASProductVendor", new[] { "PrdVendorCode" });
            DropIndex("QRP.MASProductVendor", new[] { "PlantCode", "ProductCode" });
            DropIndex("QRP.MASProduct", new[] { "PlantCode", "MaterialTypeCode" });
            DropIndex("QRP.MASProduct", new[] { "PlantCode", "MaterialGroupCode" });
            DropTable("QRP.SYSWebNoticeSearchHistory");
            DropTable("QRP.SYSWebNotice");
            DropTable("QRP.SYSWebNoticeFile");
            DropTable("QRP.SYSWebBoardSearchHistory");
            DropTable("QRP.SYSWebBoardFile");
            DropTable("QRP.SYSWebBoard");
            DropTable("QRP.SYSWebBoardComment");
            DropTable("QRP.MASVendor");
            DropTable("QRP.MASVendorP");
            DropTable("QRP.SYSWebBarCode");
            DropTable("QRP.MASProductVendor");
            DropTable("QRP.MASMaterialType");
            DropTable("QRP.MASProduct");
            DropTable("QRP.MASMaterialGroup");
        }
    }
}
