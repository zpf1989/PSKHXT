/*
Navicat SQL Server Data Transfer

Source Server         : mss-local
Source Server Version : 105000
Source Host           : localhost:1433
Source Database       : PSKHXT
Source Schema         : dbo

Target Server Type    : SQL Server
Target Server Version : 105000
File Encoding         : 65001

Date: 2016-06-09 09:49:01
*/


-- ----------------------------
-- Table structure for __MigrationHistory
-- ----------------------------
DROP TABLE [dbo].[__MigrationHistory]
GO
CREATE TABLE [dbo].[__MigrationHistory] (
[MigrationId] nvarchar(150) NOT NULL ,
[ContextKey] nvarchar(300) NOT NULL ,
[Model] varbinary(MAX) NOT NULL ,
[ProductVersion] nvarchar(32) NOT NULL 
)


GO

-- ----------------------------
-- Records of __MigrationHistory
-- ----------------------------
INSERT INTO [dbo].[__MigrationHistory] ([MigrationId], [ContextKey], [Model], [ProductVersion]) VALUES (N'201509090634017_InitialCreate', N'WY.RMS.Component.Data.Migrations.Configuration', 0x1F8B0800000000000400AD55CB6EDB3010BC17E83F08BC47B4D31CD2404EE0FA51E4E0B888DC143DD2D2CA21CA57C595617D5B0FFDA4FC4257B2FCAE1D37E891DCD570667648BDFCFA1DDD2DB40AE6907B694D87B5C3160BC024369566D661056617D7ECEEF6FDBB6890EA45F0B4EAFB50F5D197C677D833A2BBE1DC27CFA0850FB54C72EB6D8661623517A9E597ADD647DE6E732008465841103D1606A5867A41CB9E3509382C841AD914946FF6A912D7A8C183D0E09D48A0C3BE7D0F1F4771D8B3DA590306C3BE40C182AE9282C8C4A03216B8AB9BAF1E62CCAD99C54EA0146A523AA07A26948786FA8DBB3A977DEBB262CF85311609CE9A37A9676B5DA46C400E6049CA514803792DB1C306C3FEB4DA8305B2806F7CE04B235686F1238E4523E11C8D6ECBC166278897F6F52EE27FE7AE97183CF1A724AC4F429B8B19EC55E968623A94B9C76A625351CDA197EA83B6A31634F86B0FF6B446CDB9AF47E880C8B285055F723B976945222E3D82AEB315C63F554F498ADAA661248CCCC0E3C4FE00BA0EE4D3F55E04DF100FEE7DAACEC8C85F7C3C9194435722BE7DFDA23E783923F4ADCB6820A942BE015DF5DC9BCC92070E722C63C06DAEAB9655B9213B021429F1ECE6283391209513F09EE6C68227A18A2AF37A0AE9BD1917E80AEC7A0F7AAACA5D4DA7CFAFAFC32EE768ECAA95FF1F1288A6240930369F0AA9D235EFE1F22DE167405423FB0CB45F3F1EF43011DCAC5C233DD04B761E50635F1F1C9894223901ED1481F9B189C51C8E737BDDC35DC7A2BE14B35C68DF606CBEAFFE06BCFA1DDCFE01AEDF844240060000, N'6.1.3-40302')
GO
GO
INSERT INTO [dbo].[__MigrationHistory] ([MigrationId], [ContextKey], [Model], [ProductVersion]) VALUES (N'201509100747196_FirstMigration', N'WY.RMS.Component.Data.Migrations.Configuration', 0x1F8B0800000000000400CD58DB6EDB38107D5FA0FF20E8BDA693B64037905BA4765C04BB4E8228E9621F69696C13A5482D4965ED6FDB87FDA4FD851DEA6E49BEC831D0BE59A3993317928747FEEF9F7FBDCFEB883B2FA0349362E45E0C86AE0322902113CB919B98C5DB8FEEE74F6F7EF16EC268ED7C2BFCDE593F8C147AE4AE8C89AF08D1C10A22AA07110B94D4726106818C080D25B91C0E7F2517170410C2452CC7F11E13615804E9033E8EA508203609E5331902D7B91DDFF829AA734723D0310D60E4FEF1E7E071E60FC6328AA5006106136AA8EB5C7346B1181FF8C275E2F757CF1A7CA3A458FA31358CF2A74D0CF87E41B986BCF4ABF8FDB1D50F2F6DF5840A210DC2497152F76ED91776768313301B5B56DADDC8C58A55DD037D7E83CD96014D0F4AC6A0CCE6111679DC6DE83A643B8E3403CBB05A8C4D8DBF847977E93A7709E774CEA19C108ED03752C15710A0A881F0811A034AD858484B6F656DE4B0FDD85F45265C0EDC54AE33656B087F07B134AB32DB8CAE0BCB25EEAC67C1700B628C51097414B73FF103D5FA6FA9C29E89ED185E97F88E05DF7F48C7371165BC67D60FAF9FF30A0FE039B366CFFB935E87A102ADFBAEEDF0B5796FF50438E03928327F91920315BDA7F61C87789C90B4CAD1D9DF4F2C3AB4001EA928A34D2448A186323CABC596984EE6D6066BD32095CCDF07533BA738CF0A3C63D141CA479D1594B92A9E26195117844E7630BA37A3718C0B5663F8DCE2F819BD8FDFFAFDB935CA3048A03B28B6ACB6CC84BC4697D0788BA9B1D22953DAD81B654EEDFCC761D4723B62B245A6FA809B445ECDBBF0B6BFB388CE3B6ED0BE20EA039C624F11FAA6ED41594AD7BD9207FA01E55475DC0C63C99348ECBA5DF645579C5FC7A8ACC72355245E47AAACC72355AC5C47AAACC723E5345B87C94D3DFACA4873ABA9CC743C46C9817594D2783C4E8DD3B696BC32F758F91AAD6DAD7DCDDE46F34863F7364F09691D9386D2699EB97D74D57429B397B4D5A0272FA78AC3AAB4C51D998BEBE0985E586879C3DF6803517694FDBFF89833ECB7729851C116A0CD93FC0EC28A82E1C786AA3D417112AD43FE33CA4E665B3F2830FB5EAD0DC5295EA80A5654B5D4D62B0565276EA78AEEA717CF55EF961CEC04FD70C210EA6AEF08D013C45CF75C87BD615B5A6DCECC19749A7D36E7D6696DD17158ADED146B19E960A57389456715E6F2EE441DD726408FD43FDEBD0968B6AC20ECA7BC80C07E2257A085CFAD58C862CAD851BDA2C2A5B108333014C74EAF95610B1A187C1DE0864925FF37CA9374B3CF21BC15F789891373AD354473BEF56DEA91FDF953B1BA5DB3771FDB277D8E16B04C6677CEBDF892301E96754F3B76CE0E08BB47729AC4AAF09307E1969B12E9AE251F7601E5E39B400CC292EC13443147307D2F7CFA02BB6B3B3CC3ED89791346978A463AC7A8E2ED7F49C4FE99F4E97F8F71375D7E120000, N'6.1.3-40302')
GO
GO
INSERT INTO [dbo].[__MigrationHistory] ([MigrationId], [ContextKey], [Model], [ProductVersion]) VALUES (N'201606030058514_AutomaticMigration', N'WY.RMS.Component.Data.Migrations.Configuration', 0x1F8B0800000000000400ED1DDB6EE3B8F5BD40FF41D0535BCCDAC90C16D806F62EB24EB208763209E2CCB67D0A188B7184952857A2D30445BFAC0FFB49FB0BA5445D782725CBB69C06030C125ECE9D87E4D139CCEFFFFD6DF2C34B1C79CF30CDC2044DFDE3D191EF41B44882102DA7FE1A3F7EF39DFFC3F77FFCC3E43C885FBC5FAA719FF2716426CAA6FE13C6AB93F1385B3CC11864A3385CA449963CE2D12289C72048C61F8F8EFE3A3E3E1E4302C227B03C6F72BB46388C61F10BF97596A0055CE13588AE92004659D94E7AE60554EF0B8861B6020B38F5FFF68FD1EDD57C344BE2558220C2A33380C1E8FCC2F74EA310107AE6307AF43D8050820126D49E7CCDE01CA7095ACE57A4014477AF2B48C63D822883251727CD7057868E3EE60C8D9B8915A8C53AC349DC12E0F1A7524263717A2739FBB504890CCF89ACF16BCE7521C7A94F84BC8E08EB22AA935994E6C36A219F91DE108D0AA58CAE60FC00D3119DFCC1530CF9501B08B1A3FCDF076FB68EF03A855304D7380564C4CDFA210A173FC3D7BBE45788A6681D452CB1845CD2C73590A69B3459C114BFDEC2C79285CBC0F7C6FCBCB138B19EC6CCA1EC5D22FCE9A3EF7D21C8C143046B5B604431C7490A7F8208A600C3E006600C5394C380853425EC02AE1B9092811246F3A4FCFF6A02B158B2047DEF0ABC7C8668899FA6FE47B2E62EC21718540D25D55F5148162C9983D33554706546FA3944BF7E4D2303DE6FB782F732BB82685DA1FD31492208506B283342804DAB660867305BA4E18A2E35AD0C8E8FDC8460C6758E72C2824D99FEBA0A885112BF57B39EFF7C17C60E5AF8029EC36561E2A2249FC228A08B3BF3BD5B181583B2A770455D6AB9F0EFA965572EE4224DE2DB24AA9D0AD77D7F07D225C484C8443F669EACD3450B3A79FCFDD059D160A2B3E2C5994E98C661967B43B5389BFEFB582252EA9444298F500972326E9CBF714B68C075DC161A00EF5BC300BD3CEB271548C98F3DB8B70374A57471DBD5BF07871CEB5D5C4BDF21BA37BD7771A52D8763756BE5202565459F89303A404597B34FCB4174F466F9D4773F6636FA5C467BF16507E866AED300A6F324C503F4332D0E2AF6156D38A6F04BDE953A72794F7F4A93F54A4D5CDD2DD3267449A489FD5D28531395C3BB2FBB1B7A9A56C9EF315D1B79BC9AA58E6EAF9EFFEEFBCC0BB110D29B777E3D79AD21DF7AF50799169E455CCE3ACFB3B96769204BEE45E83210D593A3D9C0C7BCBB178BA91319EDC5BBDC802CFB57920606C439EBFD23BE2393F6C2F13931C0DD073F6F9E1264E2D511AB19C96910A430CB4CBA1CD21979C7FEDD7A4813CF8B8AF35BEF8758AB57D71F62F594E9BCFA6996258BB020868B86F0A1539EC57314780E71546A704D3496581D71E5E18A386F42C8D4FF8B243B33E09A6D1BE0A3D1E858824D1C3FCC8185209A11C193AD244458DE2542B4085720B293214C75DC627245D448C49E33B88228DF1DECD275C1DE7C7E9269A851091BA04D4A93316330663B92E3533A651B82558DAAD9E0B4BB1D1962E8362BEAC984B414ECC080B48275C1DD4445F7623EE2D15BA761ED39BCD12F732376B71C6DE4A0814B638B46909D18A61B809D30E18CDF1BC3C22EC3C3ED8F6166F3D5D1A40A97B492BF0EDAD6999302660E1E4A6BC01BFBBEAD98303D5090758EC92A87697510BC387BC8DBE00B565C0E8990CBFB61569E2B45EA739873883927444E43CDE94570DA12FB3C002EB0290161056B01541E222510548296C9ECD94F82C0AC5607303A08D264466BA23C85EFE2CC48C3E7737113703B05D62C30BA94F613B7739F1D1467AA64A08340145FD16471588E328E8719867ECE2A0DE2D01F5FB6220C29DC258BC2B82D3B6DCC0CE5ECB2304841B71533904A7A7B9440B9D64C1250EC5D4E3BF52612E0B72F01521F1260AFC432F3BA3DDBB66BDB5465DBA7B7C0A8FC49CBB8F06DE6AEDDC7375BF6BD597C1500A8F7EBBA6F32A609B665C364ACC9C49D5C81D52A444B2633B76CF1E6342D77F6CDBC7DA66A4C618C17992261B5A6B6C68493142CA1D04B735B2EC234C37926F003C8C343B3209686B1A713CD5E5B61E20F20B2B2AA3DB81A9FFF4CE7E8B29347EA9DB491E305612DCEAF6F45E85872F1F2442F4F8E0611481571EA5912AD63A4BF47EA6737810316863E9CA08744A3B92C14DAE20EA1CE4C6581D48DEE70AA4C534E2A659B3B149A41C5C2A02DEE10B84F772C20AEC31D5E1D776561D58DEE70D8C02B0B8A6D97A14DC682E54A9102699D08FE4A5C764E8B92F5A3BD2C4CE61ED07E719A266F67816EBEACDEAE2137612B16903E98A58774504B42773CE9B0188A1B6DFB65A09EB69D05D0A49DB1309AD6C3376326ED8285C434BF5143666E44BD5873135D696FD286B9DBB16B26A58805C234EFCFB2FBB4C8FFCB538BEEDADCD1A83BDAF3AE4CB9495FE11453B7B6B98E54F928FC75A46A7587D42498B0909AD616064C334638F3A54D2DF8A2F91F1C53B4C91D469DDEC142A91BDF1724EDE683229AFDA68A02B5D953AA39DA8D437528CA033DBADC103E76240BCA69A136D0D45F6F19FCED49D37EBD7622AD08EDB5A34A8C696DA0E13274D84AC3E51CAD86553ED528462E303A2C0D7331D70D48DBB586D998B5E30547A7D7BCCF51A572987B778BC246D0E1E9500EC7B78ADBE83C7133C2D115EBE2F81D45C980EB41C3BA0F0343F2C6D287067148BDDBD71F1C840F0B9332C86F7F07448AFAD321BE47687F0E833CE23F7FCD308CA9C5CCFF19CDA290185033E00AA0F0116698E692FB1F8F8EBE131E1119CE831EE32C0B22C54712F9550F5E653B48870F73995A13DE5B27A2F3EF671448A494924B14C097A9FFEF62D28977F9F7FB6ADE07AFB89C9E7847DE7F58E42EF9CCF44240F1A267902E9E402A65A26FF6CA8612ECB7EDC1F28F683C8478A3C2F042C89BD72329992B2A92DAE941C82BEFC29D9C539EFF8EED39E55D1E4E781B2B6F1BD6CF1A5905F34F3178F9735B9318B6B5898F09B83AAD6A9ECE690DC4D4E553D4C11AB958BBDE97A10FDB3EA57ACE2E0E7FFB76A609BD1FACB149C5C207606DBD98CA416CE0F28DFF600D4D2C1BEDCBCEC4AA5025DC0E85E162D1675FF472359D7D1DB5B9924D07A01D2A34D5727DA30767439CDC6D015A02A1F2044DC8C3BE6C794CEDCE76ECDC8DCE7735F5EDF097D35AA06EAFC1AE2EB4B50635C1C903D1604D7D7BFC5BD2A03AE2EDA63C7D00B147BDEDCCE80F415BA678B69BCE6C11E91E7DA680AA65148F9D7CD85EB38F22FBAE75EF221C1AD4EE509CBF4101FDEE8AE50BEE5CB01D4C71BCB3F64DAA6702945DEB4A07AE7E5312F6E08BDB95DF1855E55F6E55DEC7D267CE6B74062388A177BAA01FAF66205B0039E1BBF8EE67A58296BCAA2871ABC8EE644AA63CCEDEADC998BFD3E518BB0FA3527D1B16AAECACB5E06FD2949C95BA732B327C90DFA901E9B35A86EB956811BC8A1287971D0ECB2B69D27F07EE95F49949823AADCF72BC59531AAE15EDCF802C697603D9D1EA288A887F8B16B3AB7D4C971339C02DCC9202391047B30F63D9957B69652CFBF52C4EA99E9BDCA2B7643E420C504DCB16CFCF2DEFDABDDDEC9DFD9D35E9761FC635E0EBD8BE0D6A571B590753DAE57626E44D337973FCCB26A21A554FA6195E4CA339D2533F784888AA69305BF78694089CF5751202B65385E48679B6C186885A9B848236AB80ABDFC311C132B7530936D3A742A07FAA498945FB4C9B0E760BE235C211FA8D4CB414978123A6DF88D18DC7E614A4D4BD1E4FD5DBC68635721407986D592DC95DBFBEA778114EE1B3D41F83AC3387F0AE5E3736657F253ED9B239AB9A60BEFDF13C4D69913AC4A67C96C0C4BAD25B28AA53FB1740F55A995D00EAF225E95424BE323234B6B9E884FDC9C01DE99D75A38A9AD5FE05E0A2775379A2743B179F2E1806DB7240CAF850A25DDBED8D5CDC25F9D2D55E59D42BD5126BD9509FDB665177F9777805D2AED1D6DB8EF13AA62F67DD8218F4FA762C3EDDC8B0B7C17A8B972FE5C253729D63FE4C3DB95166E1B20191FFD17A0417DC45AE1E73891E93EA422950540D116B87200601B9E59DA6387C040B4CBA1790B09CFFC5965F40B486795AF3030C2ED1F51AAFD698B00CE38788FB5342F9BDD484BF78DE93A779725D940F647DB040C80CF32CE16BF4E33A8C829AEE0B45B69406447EE12D13E2735DE23C317EF95A43FA223D91A203548AAFBEA7DFC178151160D9359A8367D88536E27C3EC32558BC56F5C37A207645F0629F9C85609982382B6134F3C9AFC48683F8E5FBFF0166DFB5D4AD810000, N'6.1.3-40302')
GO
GO

-- ----------------------------
-- Table structure for Modules
-- ----------------------------
DROP TABLE [dbo].[Modules]
GO
CREATE TABLE [dbo].[Modules] (
[Id] int NOT NULL IDENTITY(1,1) ,
[ParentId] int NULL ,
[Name] nvarchar(20) NOT NULL ,
[LinkUrl] nvarchar(50) NOT NULL ,
[IsMenu] bit NOT NULL ,
[Code] int NOT NULL ,
[Description] nvarchar(100) NULL ,
[Enabled] bit NOT NULL ,
[UpdateDate] datetime NOT NULL 
)


GO
DBCC CHECKIDENT(N'[dbo].[Modules]', RESEED, 12)
GO

-- ----------------------------
-- Records of Modules
-- ----------------------------
SET IDENTITY_INSERT [dbo].[Modules] ON
GO
INSERT INTO [dbo].[Modules] ([Id], [ParentId], [Name], [LinkUrl], [IsMenu], [Code], [Description], [Enabled], [UpdateDate]) VALUES (N'1', null, N'授权管理', N'#', N'1', N'200', N'搜权管理', N'1', N'2016-06-08 10:04:29.723')
GO
GO
INSERT INTO [dbo].[Modules] ([Id], [ParentId], [Name], [LinkUrl], [IsMenu], [Code], [Description], [Enabled], [UpdateDate]) VALUES (N'2', N'1', N'角色管理', N'~/RBAC/Role/Index', N'1', N'201', null, N'1', N'2016-06-07 14:14:07.707')
GO
GO
INSERT INTO [dbo].[Modules] ([Id], [ParentId], [Name], [LinkUrl], [IsMenu], [Code], [Description], [Enabled], [UpdateDate]) VALUES (N'3', N'1', N'用户管理', N'~/RBAC/User/Index', N'1', N'202', null, N'1', N'2016-06-07 14:14:07.707')
GO
GO
INSERT INTO [dbo].[Modules] ([Id], [ParentId], [Name], [LinkUrl], [IsMenu], [Code], [Description], [Enabled], [UpdateDate]) VALUES (N'4', N'1', N'模块管理', N'~/RBAC/Module/Index', N'1', N'204', null, N'1', N'2016-06-07 14:14:07.707')
GO
GO
INSERT INTO [dbo].[Modules] ([Id], [ParentId], [Name], [LinkUrl], [IsMenu], [Code], [Description], [Enabled], [UpdateDate]) VALUES (N'5', N'1', N'权限管理', N'~/RBAC/Permission/Index', N'1', N'205', null, N'1', N'2016-06-07 14:14:07.707')
GO
GO
INSERT INTO [dbo].[Modules] ([Id], [ParentId], [Name], [LinkUrl], [IsMenu], [Code], [Description], [Enabled], [UpdateDate]) VALUES (N'6', null, N'系统应用', N'#', N'1', N'300', null, N'1', N'2016-06-07 14:14:07.707')
GO
GO
INSERT INTO [dbo].[Modules] ([Id], [ParentId], [Name], [LinkUrl], [IsMenu], [Code], [Description], [Enabled], [UpdateDate]) VALUES (N'7', N'6', N'操作日志管理', N'#', N'1', N'301', null, N'0', N'2016-06-07 14:14:07.707')
GO
GO
INSERT INTO [dbo].[Modules] ([Id], [ParentId], [Name], [LinkUrl], [IsMenu], [Code], [Description], [Enabled], [UpdateDate]) VALUES (N'8', N'1', N'用户组管理', N'~/RBAC/UserGroup/Index', N'1', N'203', null, N'1', N'2016-06-07 14:14:07.707')
GO
GO
INSERT INTO [dbo].[Modules] ([Id], [ParentId], [Name], [LinkUrl], [IsMenu], [Code], [Description], [Enabled], [UpdateDate]) VALUES (N'10', null, N'测试', N'#', N'1', N'400', null, N'1', N'2016-06-08 08:46:47.873')
GO
GO
INSERT INTO [dbo].[Modules] ([Id], [ParentId], [Name], [LinkUrl], [IsMenu], [Code], [Description], [Enabled], [UpdateDate]) VALUES (N'11', N'10', N'测试1', N'#', N'1', N'401', null, N'1', N'2016-06-08 10:09:21.450')
GO
GO
INSERT INTO [dbo].[Modules] ([Id], [ParentId], [Name], [LinkUrl], [IsMenu], [Code], [Description], [Enabled], [UpdateDate]) VALUES (N'12', N'10', N'测试2', N'#', N'1', N'402', null, N'1', N'2016-06-08 08:47:43.410')
GO
GO
SET IDENTITY_INSERT [dbo].[Modules] OFF
GO

-- ----------------------------
-- Table structure for PermissionRoles
-- ----------------------------
DROP TABLE [dbo].[PermissionRoles]
GO
CREATE TABLE [dbo].[PermissionRoles] (
[Permission_Id] int NOT NULL ,
[Role_Id] int NOT NULL 
)


GO

-- ----------------------------
-- Records of PermissionRoles
-- ----------------------------
INSERT INTO [dbo].[PermissionRoles] ([Permission_Id], [Role_Id]) VALUES (N'2', N'1')
GO
GO
INSERT INTO [dbo].[PermissionRoles] ([Permission_Id], [Role_Id]) VALUES (N'3', N'1')
GO
GO
INSERT INTO [dbo].[PermissionRoles] ([Permission_Id], [Role_Id]) VALUES (N'4', N'1')
GO
GO
INSERT INTO [dbo].[PermissionRoles] ([Permission_Id], [Role_Id]) VALUES (N'5', N'1')
GO
GO
INSERT INTO [dbo].[PermissionRoles] ([Permission_Id], [Role_Id]) VALUES (N'6', N'1')
GO
GO
INSERT INTO [dbo].[PermissionRoles] ([Permission_Id], [Role_Id]) VALUES (N'7', N'1')
GO
GO
INSERT INTO [dbo].[PermissionRoles] ([Permission_Id], [Role_Id]) VALUES (N'8', N'1')
GO
GO
INSERT INTO [dbo].[PermissionRoles] ([Permission_Id], [Role_Id]) VALUES (N'9', N'1')
GO
GO
INSERT INTO [dbo].[PermissionRoles] ([Permission_Id], [Role_Id]) VALUES (N'10', N'1')
GO
GO
INSERT INTO [dbo].[PermissionRoles] ([Permission_Id], [Role_Id]) VALUES (N'11', N'1')
GO
GO
INSERT INTO [dbo].[PermissionRoles] ([Permission_Id], [Role_Id]) VALUES (N'12', N'1')
GO
GO
INSERT INTO [dbo].[PermissionRoles] ([Permission_Id], [Role_Id]) VALUES (N'13', N'1')
GO
GO
INSERT INTO [dbo].[PermissionRoles] ([Permission_Id], [Role_Id]) VALUES (N'14', N'1')
GO
GO
INSERT INTO [dbo].[PermissionRoles] ([Permission_Id], [Role_Id]) VALUES (N'15', N'1')
GO
GO
INSERT INTO [dbo].[PermissionRoles] ([Permission_Id], [Role_Id]) VALUES (N'16', N'1')
GO
GO
INSERT INTO [dbo].[PermissionRoles] ([Permission_Id], [Role_Id]) VALUES (N'17', N'1')
GO
GO
INSERT INTO [dbo].[PermissionRoles] ([Permission_Id], [Role_Id]) VALUES (N'18', N'1')
GO
GO
INSERT INTO [dbo].[PermissionRoles] ([Permission_Id], [Role_Id]) VALUES (N'19', N'1')
GO
GO
INSERT INTO [dbo].[PermissionRoles] ([Permission_Id], [Role_Id]) VALUES (N'20', N'1')
GO
GO
INSERT INTO [dbo].[PermissionRoles] ([Permission_Id], [Role_Id]) VALUES (N'21', N'1')
GO
GO
INSERT INTO [dbo].[PermissionRoles] ([Permission_Id], [Role_Id]) VALUES (N'22', N'1')
GO
GO
INSERT INTO [dbo].[PermissionRoles] ([Permission_Id], [Role_Id]) VALUES (N'23', N'1')
GO
GO
INSERT INTO [dbo].[PermissionRoles] ([Permission_Id], [Role_Id]) VALUES (N'24', N'1')
GO
GO
INSERT INTO [dbo].[PermissionRoles] ([Permission_Id], [Role_Id]) VALUES (N'1', N'2')
GO
GO
INSERT INTO [dbo].[PermissionRoles] ([Permission_Id], [Role_Id]) VALUES (N'2', N'2')
GO
GO
INSERT INTO [dbo].[PermissionRoles] ([Permission_Id], [Role_Id]) VALUES (N'3', N'2')
GO
GO
INSERT INTO [dbo].[PermissionRoles] ([Permission_Id], [Role_Id]) VALUES (N'4', N'2')
GO
GO
INSERT INTO [dbo].[PermissionRoles] ([Permission_Id], [Role_Id]) VALUES (N'5', N'2')
GO
GO
INSERT INTO [dbo].[PermissionRoles] ([Permission_Id], [Role_Id]) VALUES (N'6', N'2')
GO
GO
INSERT INTO [dbo].[PermissionRoles] ([Permission_Id], [Role_Id]) VALUES (N'7', N'2')
GO
GO
INSERT INTO [dbo].[PermissionRoles] ([Permission_Id], [Role_Id]) VALUES (N'8', N'2')
GO
GO
INSERT INTO [dbo].[PermissionRoles] ([Permission_Id], [Role_Id]) VALUES (N'9', N'2')
GO
GO
INSERT INTO [dbo].[PermissionRoles] ([Permission_Id], [Role_Id]) VALUES (N'10', N'2')
GO
GO
INSERT INTO [dbo].[PermissionRoles] ([Permission_Id], [Role_Id]) VALUES (N'11', N'2')
GO
GO
INSERT INTO [dbo].[PermissionRoles] ([Permission_Id], [Role_Id]) VALUES (N'12', N'2')
GO
GO
INSERT INTO [dbo].[PermissionRoles] ([Permission_Id], [Role_Id]) VALUES (N'13', N'2')
GO
GO
INSERT INTO [dbo].[PermissionRoles] ([Permission_Id], [Role_Id]) VALUES (N'14', N'2')
GO
GO
INSERT INTO [dbo].[PermissionRoles] ([Permission_Id], [Role_Id]) VALUES (N'15', N'2')
GO
GO
INSERT INTO [dbo].[PermissionRoles] ([Permission_Id], [Role_Id]) VALUES (N'16', N'2')
GO
GO
INSERT INTO [dbo].[PermissionRoles] ([Permission_Id], [Role_Id]) VALUES (N'17', N'2')
GO
GO
INSERT INTO [dbo].[PermissionRoles] ([Permission_Id], [Role_Id]) VALUES (N'18', N'2')
GO
GO
INSERT INTO [dbo].[PermissionRoles] ([Permission_Id], [Role_Id]) VALUES (N'19', N'2')
GO
GO
INSERT INTO [dbo].[PermissionRoles] ([Permission_Id], [Role_Id]) VALUES (N'20', N'2')
GO
GO
INSERT INTO [dbo].[PermissionRoles] ([Permission_Id], [Role_Id]) VALUES (N'21', N'2')
GO
GO
INSERT INTO [dbo].[PermissionRoles] ([Permission_Id], [Role_Id]) VALUES (N'22', N'2')
GO
GO
INSERT INTO [dbo].[PermissionRoles] ([Permission_Id], [Role_Id]) VALUES (N'23', N'2')
GO
GO
INSERT INTO [dbo].[PermissionRoles] ([Permission_Id], [Role_Id]) VALUES (N'24', N'2')
GO
GO
INSERT INTO [dbo].[PermissionRoles] ([Permission_Id], [Role_Id]) VALUES (N'1', N'3')
GO
GO
INSERT INTO [dbo].[PermissionRoles] ([Permission_Id], [Role_Id]) VALUES (N'2', N'3')
GO
GO
INSERT INTO [dbo].[PermissionRoles] ([Permission_Id], [Role_Id]) VALUES (N'3', N'3')
GO
GO
INSERT INTO [dbo].[PermissionRoles] ([Permission_Id], [Role_Id]) VALUES (N'4', N'3')
GO
GO
INSERT INTO [dbo].[PermissionRoles] ([Permission_Id], [Role_Id]) VALUES (N'5', N'3')
GO
GO
INSERT INTO [dbo].[PermissionRoles] ([Permission_Id], [Role_Id]) VALUES (N'6', N'3')
GO
GO
INSERT INTO [dbo].[PermissionRoles] ([Permission_Id], [Role_Id]) VALUES (N'7', N'3')
GO
GO
INSERT INTO [dbo].[PermissionRoles] ([Permission_Id], [Role_Id]) VALUES (N'8', N'3')
GO
GO
INSERT INTO [dbo].[PermissionRoles] ([Permission_Id], [Role_Id]) VALUES (N'9', N'3')
GO
GO
INSERT INTO [dbo].[PermissionRoles] ([Permission_Id], [Role_Id]) VALUES (N'10', N'3')
GO
GO
INSERT INTO [dbo].[PermissionRoles] ([Permission_Id], [Role_Id]) VALUES (N'11', N'3')
GO
GO
INSERT INTO [dbo].[PermissionRoles] ([Permission_Id], [Role_Id]) VALUES (N'12', N'3')
GO
GO
INSERT INTO [dbo].[PermissionRoles] ([Permission_Id], [Role_Id]) VALUES (N'13', N'3')
GO
GO
INSERT INTO [dbo].[PermissionRoles] ([Permission_Id], [Role_Id]) VALUES (N'14', N'3')
GO
GO
INSERT INTO [dbo].[PermissionRoles] ([Permission_Id], [Role_Id]) VALUES (N'15', N'3')
GO
GO
INSERT INTO [dbo].[PermissionRoles] ([Permission_Id], [Role_Id]) VALUES (N'16', N'3')
GO
GO
INSERT INTO [dbo].[PermissionRoles] ([Permission_Id], [Role_Id]) VALUES (N'17', N'3')
GO
GO
INSERT INTO [dbo].[PermissionRoles] ([Permission_Id], [Role_Id]) VALUES (N'18', N'3')
GO
GO
INSERT INTO [dbo].[PermissionRoles] ([Permission_Id], [Role_Id]) VALUES (N'19', N'3')
GO
GO
INSERT INTO [dbo].[PermissionRoles] ([Permission_Id], [Role_Id]) VALUES (N'20', N'3')
GO
GO
INSERT INTO [dbo].[PermissionRoles] ([Permission_Id], [Role_Id]) VALUES (N'21', N'3')
GO
GO
INSERT INTO [dbo].[PermissionRoles] ([Permission_Id], [Role_Id]) VALUES (N'22', N'3')
GO
GO
INSERT INTO [dbo].[PermissionRoles] ([Permission_Id], [Role_Id]) VALUES (N'23', N'3')
GO
GO
INSERT INTO [dbo].[PermissionRoles] ([Permission_Id], [Role_Id]) VALUES (N'24', N'3')
GO
GO

-- ----------------------------
-- Table structure for Permissions
-- ----------------------------
DROP TABLE [dbo].[Permissions]
GO
CREATE TABLE [dbo].[Permissions] (
[Id] int NOT NULL IDENTITY(1,1) ,
[Name] nvarchar(20) NOT NULL ,
[Code] nvarchar(MAX) NULL ,
[Description] nvarchar(100) NULL ,
[Enabled] bit NOT NULL ,
[ModuleId] int NOT NULL ,
[UpdateDate] datetime NOT NULL 
)


GO
DBCC CHECKIDENT(N'[dbo].[Permissions]', RESEED, 24)
GO

-- ----------------------------
-- Records of Permissions
-- ----------------------------
SET IDENTITY_INSERT [dbo].[Permissions] ON
GO
INSERT INTO [dbo].[Permissions] ([Id], [Name], [Code], [Description], [Enabled], [ModuleId], [UpdateDate]) VALUES (N'1', N'查询', N'QueryRole', N'描述', N'1', N'2', N'2016-06-03 09:13:26.533')
GO
GO
INSERT INTO [dbo].[Permissions] ([Id], [Name], [Code], [Description], [Enabled], [ModuleId], [UpdateDate]) VALUES (N'2', N'新增', N'AddRole', N'描述', N'1', N'2', N'2016-06-03 09:13:26.533')
GO
GO
INSERT INTO [dbo].[Permissions] ([Id], [Name], [Code], [Description], [Enabled], [ModuleId], [UpdateDate]) VALUES (N'3', N'修改', N'EditRole', N'描述', N'1', N'2', N'2016-06-03 09:13:26.533')
GO
GO
INSERT INTO [dbo].[Permissions] ([Id], [Name], [Code], [Description], [Enabled], [ModuleId], [UpdateDate]) VALUES (N'4', N'删除', N'DeleteRole', N'描述', N'1', N'2', N'2016-06-03 09:13:26.533')
GO
GO
INSERT INTO [dbo].[Permissions] ([Id], [Name], [Code], [Description], [Enabled], [ModuleId], [UpdateDate]) VALUES (N'5', N'授权', N'AuthorizeRole', N'描述', N'1', N'2', N'2016-06-03 09:13:26.533')
GO
GO
INSERT INTO [dbo].[Permissions] ([Id], [Name], [Code], [Description], [Enabled], [ModuleId], [UpdateDate]) VALUES (N'6', N'查询', N'QueryUser', N'描述', N'1', N'3', N'2016-06-03 09:13:26.533')
GO
GO
INSERT INTO [dbo].[Permissions] ([Id], [Name], [Code], [Description], [Enabled], [ModuleId], [UpdateDate]) VALUES (N'7', N'新增', N'AddUser', N'描述', N'1', N'3', N'2016-06-03 09:13:26.533')
GO
GO
INSERT INTO [dbo].[Permissions] ([Id], [Name], [Code], [Description], [Enabled], [ModuleId], [UpdateDate]) VALUES (N'8', N'修改', N'EditUser', N'描述', N'1', N'3', N'2016-06-03 09:13:26.533')
GO
GO
INSERT INTO [dbo].[Permissions] ([Id], [Name], [Code], [Description], [Enabled], [ModuleId], [UpdateDate]) VALUES (N'9', N'删除', N'DeleteUser', N'描述', N'1', N'3', N'2016-06-03 09:13:26.533')
GO
GO
INSERT INTO [dbo].[Permissions] ([Id], [Name], [Code], [Description], [Enabled], [ModuleId], [UpdateDate]) VALUES (N'10', N'重置密码', N'ResetPwdUser', N'描述', N'1', N'3', N'2016-06-03 09:13:26.533')
GO
GO
INSERT INTO [dbo].[Permissions] ([Id], [Name], [Code], [Description], [Enabled], [ModuleId], [UpdateDate]) VALUES (N'11', N'设置用户组', N'SetGroupUser', N'描述', N'1', N'3', N'2016-06-03 09:13:26.533')
GO
GO
INSERT INTO [dbo].[Permissions] ([Id], [Name], [Code], [Description], [Enabled], [ModuleId], [UpdateDate]) VALUES (N'12', N'设置角色', N'SetRolesUser', N'描述', N'1', N'3', N'2016-06-03 09:13:26.533')
GO
GO
INSERT INTO [dbo].[Permissions] ([Id], [Name], [Code], [Description], [Enabled], [ModuleId], [UpdateDate]) VALUES (N'13', N'查询', N'QueryModule', N'描述', N'1', N'4', N'2016-06-03 09:13:26.533')
GO
GO
INSERT INTO [dbo].[Permissions] ([Id], [Name], [Code], [Description], [Enabled], [ModuleId], [UpdateDate]) VALUES (N'14', N'新增', N'AddModule', N'描述', N'1', N'4', N'2016-06-03 09:13:26.533')
GO
GO
INSERT INTO [dbo].[Permissions] ([Id], [Name], [Code], [Description], [Enabled], [ModuleId], [UpdateDate]) VALUES (N'15', N'修改', N'EditModule', N'描述', N'1', N'4', N'2016-06-03 09:13:26.533')
GO
GO
INSERT INTO [dbo].[Permissions] ([Id], [Name], [Code], [Description], [Enabled], [ModuleId], [UpdateDate]) VALUES (N'16', N'查询', N'QueryPermission', N'描述', N'1', N'5', N'2016-06-03 09:13:26.533')
GO
GO
INSERT INTO [dbo].[Permissions] ([Id], [Name], [Code], [Description], [Enabled], [ModuleId], [UpdateDate]) VALUES (N'17', N'新增', N'AddPermission', N'描述', N'1', N'5', N'2016-06-03 09:13:26.533')
GO
GO
INSERT INTO [dbo].[Permissions] ([Id], [Name], [Code], [Description], [Enabled], [ModuleId], [UpdateDate]) VALUES (N'18', N'修改', N'EditPermission', N'描述', N'1', N'5', N'2016-06-03 09:13:26.533')
GO
GO
INSERT INTO [dbo].[Permissions] ([Id], [Name], [Code], [Description], [Enabled], [ModuleId], [UpdateDate]) VALUES (N'19', N'查询', N'QuerySystemLog', N'描述', N'1', N'7', N'2016-06-03 09:13:26.533')
GO
GO
INSERT INTO [dbo].[Permissions] ([Id], [Name], [Code], [Description], [Enabled], [ModuleId], [UpdateDate]) VALUES (N'20', N'查询', N'QueryUserGroup', N'描述', N'1', N'8', N'2016-06-03 09:13:26.533')
GO
GO
INSERT INTO [dbo].[Permissions] ([Id], [Name], [Code], [Description], [Enabled], [ModuleId], [UpdateDate]) VALUES (N'21', N'新增', N'AddUserGroup', N'描述', N'1', N'8', N'2016-06-03 09:13:26.533')
GO
GO
INSERT INTO [dbo].[Permissions] ([Id], [Name], [Code], [Description], [Enabled], [ModuleId], [UpdateDate]) VALUES (N'22', N'修改', N'EditUserGroup', N'描述', N'1', N'8', N'2016-06-03 09:13:26.533')
GO
GO
INSERT INTO [dbo].[Permissions] ([Id], [Name], [Code], [Description], [Enabled], [ModuleId], [UpdateDate]) VALUES (N'23', N'删除', N'DeleteUserGroup', N'描述', N'1', N'8', N'2016-06-03 09:13:26.533')
GO
GO
INSERT INTO [dbo].[Permissions] ([Id], [Name], [Code], [Description], [Enabled], [ModuleId], [UpdateDate]) VALUES (N'24', N'设置角色', N'SetRolesUserGroup', N'描述', N'1', N'8', N'2016-06-03 09:13:26.533')
GO
GO
SET IDENTITY_INSERT [dbo].[Permissions] OFF
GO

-- ----------------------------
-- Table structure for Roles
-- ----------------------------
DROP TABLE [dbo].[Roles]
GO
CREATE TABLE [dbo].[Roles] (
[Id] int NOT NULL IDENTITY(1,1) ,
[RoleName] nvarchar(20) NOT NULL ,
[Description] nvarchar(100) NULL ,
[Enabled] bit NOT NULL ,
[OrderSort] int NOT NULL ,
[UpdateDate] datetime NOT NULL 
)


GO
DBCC CHECKIDENT(N'[dbo].[Roles]', RESEED, 12)
GO

-- ----------------------------
-- Records of Roles
-- ----------------------------
SET IDENTITY_INSERT [dbo].[Roles] ON
GO
INSERT INTO [dbo].[Roles] ([Id], [RoleName], [Description], [Enabled], [OrderSort], [UpdateDate]) VALUES (N'1', N'superadmin', N'超级管理员', N'1', N'1', N'2016-06-07 14:14:08.093')
GO
GO
INSERT INTO [dbo].[Roles] ([Id], [RoleName], [Description], [Enabled], [OrderSort], [UpdateDate]) VALUES (N'2', N'管理员', N'系统管理员', N'1', N'1', N'2016-06-07 14:14:08.093')
GO
GO
INSERT INTO [dbo].[Roles] ([Id], [RoleName], [Description], [Enabled], [OrderSort], [UpdateDate]) VALUES (N'3', N'普通角色1', N'普通角色1', N'1', N'1', N'2016-06-07 14:14:08.093')
GO
GO
INSERT INTO [dbo].[Roles] ([Id], [RoleName], [Description], [Enabled], [OrderSort], [UpdateDate]) VALUES (N'4', N'普通角色2', N'普通角色2', N'1', N'1', N'2016-06-07 14:14:08.093')
GO
GO
INSERT INTO [dbo].[Roles] ([Id], [RoleName], [Description], [Enabled], [OrderSort], [UpdateDate]) VALUES (N'5', N'普通角色3', N'普通角色3', N'1', N'1', N'2016-06-07 14:14:08.093')
GO
GO
INSERT INTO [dbo].[Roles] ([Id], [RoleName], [Description], [Enabled], [OrderSort], [UpdateDate]) VALUES (N'6', N'普通角色4', N'普通角色4', N'1', N'1', N'2016-06-07 14:14:08.093')
GO
GO
INSERT INTO [dbo].[Roles] ([Id], [RoleName], [Description], [Enabled], [OrderSort], [UpdateDate]) VALUES (N'7', N'普通角色5', N'普通角色5', N'1', N'1', N'2016-06-07 14:14:08.093')
GO
GO
INSERT INTO [dbo].[Roles] ([Id], [RoleName], [Description], [Enabled], [OrderSort], [UpdateDate]) VALUES (N'8', N'普通角色6', N'普通角色6', N'1', N'1', N'2016-06-07 14:14:08.093')
GO
GO
INSERT INTO [dbo].[Roles] ([Id], [RoleName], [Description], [Enabled], [OrderSort], [UpdateDate]) VALUES (N'9', N'普通角色7', N'普通角色7', N'1', N'1', N'2016-06-07 14:14:08.093')
GO
GO
INSERT INTO [dbo].[Roles] ([Id], [RoleName], [Description], [Enabled], [OrderSort], [UpdateDate]) VALUES (N'10', N'普通角色8', N'普通角色8', N'1', N'1', N'2016-06-07 14:14:08.093')
GO
GO
INSERT INTO [dbo].[Roles] ([Id], [RoleName], [Description], [Enabled], [OrderSort], [UpdateDate]) VALUES (N'11', N'普通角色9', N'普通角色9', N'1', N'1', N'2016-06-07 14:14:08.093')
GO
GO
INSERT INTO [dbo].[Roles] ([Id], [RoleName], [Description], [Enabled], [OrderSort], [UpdateDate]) VALUES (N'12', N'普通角色10', N'普通角色10', N'1', N'1', N'2016-06-07 14:14:08.093')
GO
GO
SET IDENTITY_INSERT [dbo].[Roles] OFF
GO

-- ----------------------------
-- Table structure for RoleUsers
-- ----------------------------
DROP TABLE [dbo].[RoleUsers]
GO
CREATE TABLE [dbo].[RoleUsers] (
[Role_Id] int NOT NULL ,
[User_Id] int NOT NULL 
)


GO

-- ----------------------------
-- Records of RoleUsers
-- ----------------------------
INSERT INTO [dbo].[RoleUsers] ([Role_Id], [User_Id]) VALUES (N'2', N'1')
GO
GO
INSERT INTO [dbo].[RoleUsers] ([Role_Id], [User_Id]) VALUES (N'2', N'2')
GO
GO

-- ----------------------------
-- Table structure for UserGroupRoles
-- ----------------------------
DROP TABLE [dbo].[UserGroupRoles]
GO
CREATE TABLE [dbo].[UserGroupRoles] (
[UserGroup_Id] int NOT NULL ,
[Role_Id] int NOT NULL 
)


GO

-- ----------------------------
-- Records of UserGroupRoles
-- ----------------------------
INSERT INTO [dbo].[UserGroupRoles] ([UserGroup_Id], [Role_Id]) VALUES (N'1', N'2')
GO
GO
INSERT INTO [dbo].[UserGroupRoles] ([UserGroup_Id], [Role_Id]) VALUES (N'2', N'2')
GO
GO

-- ----------------------------
-- Table structure for UserGroups
-- ----------------------------
DROP TABLE [dbo].[UserGroups]
GO
CREATE TABLE [dbo].[UserGroups] (
[Id] int NOT NULL IDENTITY(1,1) ,
[GroupName] nvarchar(20) NOT NULL ,
[Description] nvarchar(100) NULL ,
[OrderSort] int NOT NULL ,
[Enabled] bit NOT NULL ,
[UpdateDate] datetime NOT NULL 
)


GO
DBCC CHECKIDENT(N'[dbo].[UserGroups]', RESEED, 2)
GO

-- ----------------------------
-- Records of UserGroups
-- ----------------------------
SET IDENTITY_INSERT [dbo].[UserGroups] ON
GO
INSERT INTO [dbo].[UserGroups] ([Id], [GroupName], [Description], [OrderSort], [Enabled], [UpdateDate]) VALUES (N'1', N'开发组', N'开发人员组', N'1', N'1', N'2016-06-07 14:14:08.143')
GO
GO
INSERT INTO [dbo].[UserGroups] ([Id], [GroupName], [Description], [OrderSort], [Enabled], [UpdateDate]) VALUES (N'2', N'项目经理组', N'项目经理组', N'2', N'1', N'2016-06-07 14:14:08.143')
GO
GO
SET IDENTITY_INSERT [dbo].[UserGroups] OFF
GO

-- ----------------------------
-- Table structure for UserGroupUsers
-- ----------------------------
DROP TABLE [dbo].[UserGroupUsers]
GO
CREATE TABLE [dbo].[UserGroupUsers] (
[UserGroup_Id] int NOT NULL ,
[User_Id] int NOT NULL 
)


GO

-- ----------------------------
-- Records of UserGroupUsers
-- ----------------------------
INSERT INTO [dbo].[UserGroupUsers] ([UserGroup_Id], [User_Id]) VALUES (N'1', N'1')
GO
GO
INSERT INTO [dbo].[UserGroupUsers] ([UserGroup_Id], [User_Id]) VALUES (N'2', N'2')
GO
GO

-- ----------------------------
-- Table structure for Users
-- ----------------------------
DROP TABLE [dbo].[Users]
GO
CREATE TABLE [dbo].[Users] (
[Id] int NOT NULL IDENTITY(1,1) ,
[UserName] nvarchar(20) NOT NULL ,
[Password] nvarchar(32) NOT NULL ,
[Email] nvarchar(50) NOT NULL ,
[Phone] nvarchar(50) NULL ,
[Address] nvarchar(300) NULL ,
[UpdateDate] datetime NOT NULL ,
[TrueName] nvarchar(20) NOT NULL DEFAULT '' ,
[Enabled] bit NOT NULL DEFAULT ((0)) 
)


GO
DBCC CHECKIDENT(N'[dbo].[Users]', RESEED, 2)
GO

-- ----------------------------
-- Records of Users
-- ----------------------------
SET IDENTITY_INSERT [dbo].[Users] ON
GO
INSERT INTO [dbo].[Users] ([Id], [UserName], [Password], [Email], [Phone], [Address], [UpdateDate], [TrueName], [Enabled]) VALUES (N'1', N'admin', N'e10adc3949ba59abbe56e057f20f883e', N'375368093@qq.com', N'18181818181', N'广东广州市天河区科韵路XX街XX号XXX房X号', N'2016-06-07 14:14:08.123', N'管理员', N'1')
GO
GO
INSERT INTO [dbo].[Users] ([Id], [UserName], [Password], [Email], [Phone], [Address], [UpdateDate], [TrueName], [Enabled]) VALUES (N'2', N'xiaowu', N'e10adc3949ba59abbe56e057f20f883e', N'11111@1111.com', N'18181818181', N'广东广州市天河区科韵路XX街X广东广州市天河区科韵路XX街XX号XXX房X号', N'2016-06-07 14:14:08.123', N'小吴', N'1')
GO
GO
SET IDENTITY_INSERT [dbo].[Users] OFF
GO

-- ----------------------------
-- Indexes structure for table __MigrationHistory
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table __MigrationHistory
-- ----------------------------
ALTER TABLE [dbo].[__MigrationHistory] ADD PRIMARY KEY ([MigrationId], [ContextKey])
GO

-- ----------------------------
-- Indexes structure for table Modules
-- ----------------------------
CREATE INDEX [IX_ParentId] ON [dbo].[Modules]
([ParentId] ASC) 
GO

-- ----------------------------
-- Primary Key structure for table Modules
-- ----------------------------
ALTER TABLE [dbo].[Modules] ADD PRIMARY KEY ([Id])
GO

-- ----------------------------
-- Indexes structure for table PermissionRoles
-- ----------------------------
CREATE INDEX [IX_Permission_Id] ON [dbo].[PermissionRoles]
([Permission_Id] ASC) 
GO
CREATE INDEX [IX_Role_Id] ON [dbo].[PermissionRoles]
([Role_Id] ASC) 
GO

-- ----------------------------
-- Primary Key structure for table PermissionRoles
-- ----------------------------
ALTER TABLE [dbo].[PermissionRoles] ADD PRIMARY KEY ([Permission_Id], [Role_Id])
GO

-- ----------------------------
-- Indexes structure for table Permissions
-- ----------------------------
CREATE INDEX [IX_ModuleId] ON [dbo].[Permissions]
([ModuleId] ASC) 
GO

-- ----------------------------
-- Primary Key structure for table Permissions
-- ----------------------------
ALTER TABLE [dbo].[Permissions] ADD PRIMARY KEY ([Id])
GO

-- ----------------------------
-- Indexes structure for table Roles
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table Roles
-- ----------------------------
ALTER TABLE [dbo].[Roles] ADD PRIMARY KEY ([Id])
GO

-- ----------------------------
-- Indexes structure for table RoleUsers
-- ----------------------------
CREATE INDEX [IX_Role_Id] ON [dbo].[RoleUsers]
([Role_Id] ASC) 
GO
CREATE INDEX [IX_User_Id] ON [dbo].[RoleUsers]
([User_Id] ASC) 
GO

-- ----------------------------
-- Primary Key structure for table RoleUsers
-- ----------------------------
ALTER TABLE [dbo].[RoleUsers] ADD PRIMARY KEY ([Role_Id], [User_Id])
GO

-- ----------------------------
-- Indexes structure for table UserGroupRoles
-- ----------------------------
CREATE INDEX [IX_UserGroup_Id] ON [dbo].[UserGroupRoles]
([UserGroup_Id] ASC) 
GO
CREATE INDEX [IX_Role_Id] ON [dbo].[UserGroupRoles]
([Role_Id] ASC) 
GO

-- ----------------------------
-- Primary Key structure for table UserGroupRoles
-- ----------------------------
ALTER TABLE [dbo].[UserGroupRoles] ADD PRIMARY KEY ([UserGroup_Id], [Role_Id])
GO

-- ----------------------------
-- Indexes structure for table UserGroups
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table UserGroups
-- ----------------------------
ALTER TABLE [dbo].[UserGroups] ADD PRIMARY KEY ([Id])
GO

-- ----------------------------
-- Indexes structure for table UserGroupUsers
-- ----------------------------
CREATE INDEX [IX_UserGroup_Id] ON [dbo].[UserGroupUsers]
([UserGroup_Id] ASC) 
GO
CREATE INDEX [IX_User_Id] ON [dbo].[UserGroupUsers]
([User_Id] ASC) 
GO

-- ----------------------------
-- Primary Key structure for table UserGroupUsers
-- ----------------------------
ALTER TABLE [dbo].[UserGroupUsers] ADD PRIMARY KEY ([UserGroup_Id], [User_Id])
GO

-- ----------------------------
-- Indexes structure for table Users
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table Users
-- ----------------------------
ALTER TABLE [dbo].[Users] ADD PRIMARY KEY ([Id])
GO

-- ----------------------------
-- Foreign Key structure for table [dbo].[Modules]
-- ----------------------------
ALTER TABLE [dbo].[Modules] ADD FOREIGN KEY ([ParentId]) REFERENCES [dbo].[Modules] ([Id]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO

-- ----------------------------
-- Foreign Key structure for table [dbo].[PermissionRoles]
-- ----------------------------
ALTER TABLE [dbo].[PermissionRoles] ADD FOREIGN KEY ([Permission_Id]) REFERENCES [dbo].[Permissions] ([Id]) ON DELETE CASCADE ON UPDATE NO ACTION
GO
ALTER TABLE [dbo].[PermissionRoles] ADD FOREIGN KEY ([Role_Id]) REFERENCES [dbo].[Roles] ([Id]) ON DELETE CASCADE ON UPDATE NO ACTION
GO

-- ----------------------------
-- Foreign Key structure for table [dbo].[Permissions]
-- ----------------------------
ALTER TABLE [dbo].[Permissions] ADD FOREIGN KEY ([ModuleId]) REFERENCES [dbo].[Modules] ([Id]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO

-- ----------------------------
-- Foreign Key structure for table [dbo].[RoleUsers]
-- ----------------------------
ALTER TABLE [dbo].[RoleUsers] ADD FOREIGN KEY ([Role_Id]) REFERENCES [dbo].[Roles] ([Id]) ON DELETE CASCADE ON UPDATE NO ACTION
GO
ALTER TABLE [dbo].[RoleUsers] ADD FOREIGN KEY ([User_Id]) REFERENCES [dbo].[Users] ([Id]) ON DELETE CASCADE ON UPDATE NO ACTION
GO

-- ----------------------------
-- Foreign Key structure for table [dbo].[UserGroupRoles]
-- ----------------------------
ALTER TABLE [dbo].[UserGroupRoles] ADD FOREIGN KEY ([Role_Id]) REFERENCES [dbo].[Roles] ([Id]) ON DELETE CASCADE ON UPDATE NO ACTION
GO
ALTER TABLE [dbo].[UserGroupRoles] ADD FOREIGN KEY ([UserGroup_Id]) REFERENCES [dbo].[UserGroups] ([Id]) ON DELETE CASCADE ON UPDATE NO ACTION
GO

-- ----------------------------
-- Foreign Key structure for table [dbo].[UserGroupUsers]
-- ----------------------------
ALTER TABLE [dbo].[UserGroupUsers] ADD FOREIGN KEY ([User_Id]) REFERENCES [dbo].[Users] ([Id]) ON DELETE CASCADE ON UPDATE NO ACTION
GO
ALTER TABLE [dbo].[UserGroupUsers] ADD FOREIGN KEY ([UserGroup_Id]) REFERENCES [dbo].[UserGroups] ([Id]) ON DELETE CASCADE ON UPDATE NO ACTION
GO
