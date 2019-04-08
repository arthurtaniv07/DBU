USE [Account]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

if(exists(select * from sysobjects where name='BU_AcBook'))
begin
	drop table [BU_AcBook]
end
go

/** 账簿 **/
CREATE TABLE [dbo].[BU_AcBook](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[UserID] [bigint] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[SetMoney] [decimal](10,2) NOT NULL,
	[PayMoney] [decimal](10,2) NOT NULL,
	[YuMoney] [decimal](10,2) NOT NULL,
	[Money_YuZhi] [decimal](10,2) NOT NULL,
	[YuMoney_YuZhi] [decimal](10,2) NOT NULL,
	[AddDate] [datetime] NOT NULL,
	primary key(ID)
) 

GO

SET ANSI_PADDING OFF
GO





ALTER TABLE [dbo].[BU_AcBook] ADD  CONSTRAINT [DF_BU_AcBook_UserID]  DEFAULT ((0)) FOR [UserID]
GO

ALTER TABLE [dbo].[BU_AcBook] ADD  CONSTRAINT [DF_BU_AcBook_Name]  DEFAULT ('') FOR [Name]
GO

ALTER TABLE [dbo].[BU_AcBook] ADD  CONSTRAINT [DF_BU_AcBook_SetMoney]  DEFAULT ((0)) FOR [SetMoney]
GO

ALTER TABLE [dbo].[BU_AcBook] ADD  CONSTRAINT [DF_BU_AcBook_PayMoney]  DEFAULT ((0)) FOR [PayMoney]
GO

ALTER TABLE [dbo].[BU_AcBook] ADD  CONSTRAINT [DF_BU_AcBook_YuMoney]  DEFAULT ((0)) FOR [YuMoney]
GO

ALTER TABLE [dbo].[BU_AcBook] ADD  CONSTRAINT [DF_BU_AcBook_Money_YuZhi]  DEFAULT ((0)) FOR [Money_YuZhi]
GO

ALTER TABLE [dbo].[BU_AcBook] ADD  CONSTRAINT [DF_BU_AcBook_YuMoney_YuZhi]  DEFAULT ((0)) FOR [YuMoney_YuZhi]
GO

ALTER TABLE [dbo].[BU_AcBook] ADD  CONSTRAINT [DF_BU_AcBook_AddDate]  DEFAULT (getdate()) FOR [AddDate]
GO



EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'账簿' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BU_AcBook'
GO


EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'账本所属的用户ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BU_AcBook', @level2type=N'COLUMN',@level2name=N'UserID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'账本名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BU_AcBook', @level2type=N'COLUMN',@level2name=N'Name'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'账本总收入' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BU_AcBook', @level2type=N'COLUMN',@level2name=N'SetMoney'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'账本总支出' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BU_AcBook', @level2type=N'COLUMN',@level2name=N'PayMoney'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'账本余额' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BU_AcBook', @level2type=N'COLUMN',@level2name=N'YuMoney'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'账本预支金额' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BU_AcBook', @level2type=N'COLUMN',@level2name=N'Money_YuZhi'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'账本剩余预支金额' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BU_AcBook', @level2type=N'COLUMN',@level2name=N'YuMoney_YuZhi'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'添加时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BU_AcBook', @level2type=N'COLUMN',@level2name=N'AddDate'
GO




if(exists(select * from sysobjects where name='BU_AcDebt'))
begin
	drop table [BU_AcDebt]
end
go

/**  **/
CREATE TABLE [dbo].[BU_AcDebt](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[UserID] [bigint] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Money_Yu] [decimal](18,2) NOT NULL,
	primary key(ID)
) 

GO

SET ANSI_PADDING OFF
GO





ALTER TABLE [dbo].[BU_AcDebt] ADD  CONSTRAINT [DF_BU_AcDebt_UserID]  DEFAULT ((0)) FOR [UserID]
GO

ALTER TABLE [dbo].[BU_AcDebt] ADD  CONSTRAINT [DF_BU_AcDebt_Name]  DEFAULT ('') FOR [Name]
GO




EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'关联的用户ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BU_AcDebt', @level2type=N'COLUMN',@level2name=N'UserID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'关联的债务人名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BU_AcDebt', @level2type=N'COLUMN',@level2name=N'Name'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'该债务人钱用户的未还金额' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BU_AcDebt', @level2type=N'COLUMN',@level2name=N'Money_Yu'
GO




if(exists(select * from sysobjects where name='BU_AcDebtInfo'))
begin
	drop table [BU_AcDebtInfo]
end
go

/**  **/
CREATE TABLE [dbo].[BU_AcDebtInfo](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[UserID] [bigint] NOT NULL,
	[DebtUserID] [bigint] NOT NULL,
	[SetMoney] [decimal](10,2) NOT NULL,
	[PayMoney] [decimal](10,2) NOT NULL,
	[Money_Old] [decimal](10,2) NOT NULL,
	[Money_Added] [decimal](10,2) NOT NULL,
	[Money_Result] [decimal](10,2) NOT NULL,
	[AddDate] [datetime] NOT NULL,
	primary key(ID)
) 

GO

SET ANSI_PADDING OFF
GO





ALTER TABLE [dbo].[BU_AcDebtInfo] ADD  CONSTRAINT [DF_BU_AcDebtInfo_UserID]  DEFAULT ((0)) FOR [UserID]
GO

ALTER TABLE [dbo].[BU_AcDebtInfo] ADD  CONSTRAINT [DF_BU_AcDebtInfo_DebtUserID]  DEFAULT ((0)) FOR [DebtUserID]
GO

ALTER TABLE [dbo].[BU_AcDebtInfo] ADD  CONSTRAINT [DF_BU_AcDebtInfo_SetMoney]  DEFAULT ((0)) FOR [SetMoney]
GO

ALTER TABLE [dbo].[BU_AcDebtInfo] ADD  CONSTRAINT [DF_BU_AcDebtInfo_PayMoney]  DEFAULT ((0)) FOR [PayMoney]
GO

ALTER TABLE [dbo].[BU_AcDebtInfo] ADD  CONSTRAINT [DF_BU_AcDebtInfo_Money_Old]  DEFAULT ((0)) FOR [Money_Old]
GO

ALTER TABLE [dbo].[BU_AcDebtInfo] ADD  CONSTRAINT [DF_BU_AcDebtInfo_Money_Added]  DEFAULT ((0)) FOR [Money_Added]
GO

ALTER TABLE [dbo].[BU_AcDebtInfo] ADD  CONSTRAINT [DF_BU_AcDebtInfo_Money_Result]  DEFAULT ((0)) FOR [Money_Result]
GO

ALTER TABLE [dbo].[BU_AcDebtInfo] ADD  CONSTRAINT [DF_BU_AcDebtInfo_AddDate]  DEFAULT (getdate()) FOR [AddDate]
GO




EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'关联的用户ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BU_AcDebtInfo', @level2type=N'COLUMN',@level2name=N'UserID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'关联的债务人ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BU_AcDebtInfo', @level2type=N'COLUMN',@level2name=N'DebtUserID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'收入的金额' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BU_AcDebtInfo', @level2type=N'COLUMN',@level2name=N'SetMoney'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'支出的金额' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BU_AcDebtInfo', @level2type=N'COLUMN',@level2name=N'PayMoney'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'利息' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BU_AcDebtInfo', @level2type=N'COLUMN',@level2name=N'Money_Old'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'原金额' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BU_AcDebtInfo', @level2type=N'COLUMN',@level2name=N'Money_Result'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'添加时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BU_AcDebtInfo', @level2type=N'COLUMN',@level2name=N'AddDate'
GO




if(exists(select * from sysobjects where name='BU_AcIO'))
begin
	drop table [BU_AcIO]
end
go

/** 流水账目表 **/
CREATE TABLE [dbo].[BU_AcIO](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[UserID] [bigint] NOT NULL,
	[AcBookID] [bigint] NOT NULL,
	[AcBookName] [nvarchar](50) NOT NULL,
	[OpWay] [int] NOT NULL,
	[PayType] [int] NOT NULL,
	[PayType2] [nvarchar](50) NOT NULL,
	[PayType3] [nvarchar](50) NOT NULL,
	[MediID] [bigint] NOT NULL,
	[MediName] [nvarchar](50) NOT NULL,
	[PayWayID] [bigint] NOT NULL,
	[PayWayName] [nvarchar](50) NOT NULL,
	[YouDebtID] [bigint] NOT NULL,
	[YouComName] [nvarchar](50) NOT NULL,
	[YouName] [nvarchar](50) NOT NULL,
	[YouWayID] [bigint] NOT NULL,
	[YouWayName] [nvarchar](50) NOT NULL,
	[YouWayIDNumber] [nvarchar](50) NOT NULL,
	[PayDate] [datetime] NOT NULL,
	[PayDateStr] [nvarchar](50) NOT NULL,
	[Money_Old] [decimal](10,2) NOT NULL,
	[Money_Added] [decimal](10,2) NOT NULL,
	[Money_Percent] [int] NOT NULL,
	[SetMoney] [decimal](10,2) NOT NULL,
	[PayMoney] [decimal](10,2) NOT NULL,
	[Money_Result] [decimal](10,2) NOT NULL,
	[Remark] [nvarchar](500) NOT NULL,
	[YuMoney] [decimal](10,2) NOT NULL,
	[IsBreakToLinkUser] [int] NOT NULL,
	[IsBreakToPayWay] [int] NOT NULL,
	[IsBaoXiao] [int] NOT NULL,
	[LinkUserID] [bigint] NOT NULL,
	[LinkUserName] [nvarchar](50) NOT NULL,
	[LinkTableID] [bigint] NOT NULL,
	[ApplyTableName] [nvarchar](50) NOT NULL,
	[ApplyTableID] [bigint] NOT NULL,
	[AddDate] [datetime] NOT NULL,
	primary key(ID)
) 

GO

SET ANSI_PADDING OFF
GO





ALTER TABLE [dbo].[BU_AcIO] ADD  CONSTRAINT [DF_BU_AcIO_UserID]  DEFAULT ((0)) FOR [UserID]
GO

ALTER TABLE [dbo].[BU_AcIO] ADD  CONSTRAINT [DF_BU_AcIO_AcBookID]  DEFAULT ((0)) FOR [AcBookID]
GO

ALTER TABLE [dbo].[BU_AcIO] ADD  CONSTRAINT [DF_BU_AcIO_AcBookName]  DEFAULT ('') FOR [AcBookName]
GO

ALTER TABLE [dbo].[BU_AcIO] ADD  CONSTRAINT [DF_BU_AcIO_OpWay]  DEFAULT ((-1)) FOR [OpWay]
GO

ALTER TABLE [dbo].[BU_AcIO] ADD  CONSTRAINT [DF_BU_AcIO_PayType]  DEFAULT ((-1)) FOR [PayType]
GO

ALTER TABLE [dbo].[BU_AcIO] ADD  CONSTRAINT [DF_BU_AcIO_PayType2]  DEFAULT ('') FOR [PayType2]
GO

ALTER TABLE [dbo].[BU_AcIO] ADD  CONSTRAINT [DF_BU_AcIO_PayType3]  DEFAULT ('') FOR [PayType3]
GO

ALTER TABLE [dbo].[BU_AcIO] ADD  CONSTRAINT [DF_BU_AcIO_MediID]  DEFAULT ((0)) FOR [MediID]
GO

ALTER TABLE [dbo].[BU_AcIO] ADD  CONSTRAINT [DF_BU_AcIO_MediName]  DEFAULT ('') FOR [MediName]
GO

ALTER TABLE [dbo].[BU_AcIO] ADD  CONSTRAINT [DF_BU_AcIO_PayWayID]  DEFAULT ((0)) FOR [PayWayID]
GO

ALTER TABLE [dbo].[BU_AcIO] ADD  CONSTRAINT [DF_BU_AcIO_PayWayName]  DEFAULT ('') FOR [PayWayName]
GO

ALTER TABLE [dbo].[BU_AcIO] ADD  CONSTRAINT [DF_BU_AcIO_YouDebtID]  DEFAULT ((0)) FOR [YouDebtID]
GO

ALTER TABLE [dbo].[BU_AcIO] ADD  CONSTRAINT [DF_BU_AcIO_YouComName]  DEFAULT ('') FOR [YouComName]
GO

ALTER TABLE [dbo].[BU_AcIO] ADD  CONSTRAINT [DF_BU_AcIO_YouName]  DEFAULT ('') FOR [YouName]
GO

ALTER TABLE [dbo].[BU_AcIO] ADD  CONSTRAINT [DF_BU_AcIO_YouWayID]  DEFAULT ((0)) FOR [YouWayID]
GO

ALTER TABLE [dbo].[BU_AcIO] ADD  CONSTRAINT [DF_BU_AcIO_YouWayName]  DEFAULT ('') FOR [YouWayName]
GO

ALTER TABLE [dbo].[BU_AcIO] ADD  CONSTRAINT [DF_BU_AcIO_YouWayIDNumber]  DEFAULT ('') FOR [YouWayIDNumber]
GO

ALTER TABLE [dbo].[BU_AcIO] ADD  CONSTRAINT [DF_BU_AcIO_PayDate]  DEFAULT (getdate()) FOR [PayDate]
GO

ALTER TABLE [dbo].[BU_AcIO] ADD  CONSTRAINT [DF_BU_AcIO_PayDateStr]  DEFAULT ('') FOR [PayDateStr]
GO

ALTER TABLE [dbo].[BU_AcIO] ADD  CONSTRAINT [DF_BU_AcIO_Money_Old]  DEFAULT ((0)) FOR [Money_Old]
GO

ALTER TABLE [dbo].[BU_AcIO] ADD  CONSTRAINT [DF_BU_AcIO_Money_Added]  DEFAULT ((0)) FOR [Money_Added]
GO

ALTER TABLE [dbo].[BU_AcIO] ADD  CONSTRAINT [DF_BU_AcIO_Money_Percent]  DEFAULT ((0)) FOR [Money_Percent]
GO

ALTER TABLE [dbo].[BU_AcIO] ADD  CONSTRAINT [DF_BU_AcIO_SetMoney]  DEFAULT ((0)) FOR [SetMoney]
GO

ALTER TABLE [dbo].[BU_AcIO] ADD  CONSTRAINT [DF_BU_AcIO_PayMoney]  DEFAULT ((0)) FOR [PayMoney]
GO

ALTER TABLE [dbo].[BU_AcIO] ADD  CONSTRAINT [DF_BU_AcIO_Money_Result]  DEFAULT ((0)) FOR [Money_Result]
GO

ALTER TABLE [dbo].[BU_AcIO] ADD  CONSTRAINT [DF_BU_AcIO_Remark]  DEFAULT ('') FOR [Remark]
GO

ALTER TABLE [dbo].[BU_AcIO] ADD  CONSTRAINT [DF_BU_AcIO_YuMoney]  DEFAULT ((0)) FOR [YuMoney]
GO

ALTER TABLE [dbo].[BU_AcIO] ADD  CONSTRAINT [DF_BU_AcIO_IsBreakToLinkUser]  DEFAULT ((0)) FOR [IsBreakToLinkUser]
GO

ALTER TABLE [dbo].[BU_AcIO] ADD  CONSTRAINT [DF_BU_AcIO_IsBreakToPayWay]  DEFAULT ((0)) FOR [IsBreakToPayWay]
GO

ALTER TABLE [dbo].[BU_AcIO] ADD  CONSTRAINT [DF_BU_AcIO_IsBaoXiao]  DEFAULT ((-1)) FOR [IsBaoXiao]
GO

ALTER TABLE [dbo].[BU_AcIO] ADD  CONSTRAINT [DF_BU_AcIO_LinkUserID]  DEFAULT ((0)) FOR [LinkUserID]
GO

ALTER TABLE [dbo].[BU_AcIO] ADD  CONSTRAINT [DF_BU_AcIO_LinkUserName]  DEFAULT ('') FOR [LinkUserName]
GO

ALTER TABLE [dbo].[BU_AcIO] ADD  CONSTRAINT [DF_BU_AcIO_LinkTableID]  DEFAULT ((0)) FOR [LinkTableID]
GO

ALTER TABLE [dbo].[BU_AcIO] ADD  CONSTRAINT [DF_BU_AcIO_ApplyTableName]  DEFAULT ('') FOR [ApplyTableName]
GO

ALTER TABLE [dbo].[BU_AcIO] ADD  CONSTRAINT [DF_BU_AcIO_ApplyTableID]  DEFAULT ((0)) FOR [ApplyTableID]
GO

ALTER TABLE [dbo].[BU_AcIO] ADD  CONSTRAINT [DF_BU_AcIO_AddDate]  DEFAULT (getdate()) FOR [AddDate]
GO



EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'流水账目表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BU_AcIO'
GO


EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BU_AcIO', @level2type=N'COLUMN',@level2name=N'UserID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'账本ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BU_AcIO', @level2type=N'COLUMN',@level2name=N'AcBookID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'账本名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BU_AcIO', @level2type=N'COLUMN',@level2name=N'AcBookName'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'操作类型 （-1支出 1收入 2转账 3借贷）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BU_AcIO', @level2type=N'COLUMN',@level2name=N'OpWay'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'支付类型 0未发生对外交易(如取款)  1收入  -1支出 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BU_AcIO', @level2type=N'COLUMN',@level2name=N'PayType'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'支付账目  如生活缴费(水费 电费 网费)  充值(流量 话费)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BU_AcIO', @level2type=N'COLUMN',@level2name=N'PayType2'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'支付类型 如水费 电费 工资' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BU_AcIO', @level2type=N'COLUMN',@level2name=N'PayType3'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'媒介ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BU_AcIO', @level2type=N'COLUMN',@level2name=N'MediID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'媒介名称，如支付宝 微信 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BU_AcIO', @level2type=N'COLUMN',@level2name=N'MediName'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'支付的账户' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BU_AcIO', @level2type=N'COLUMN',@level2name=N'PayWayID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'支付的账户名称  如花呗 现金 余额宝' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BU_AcIO', @level2type=N'COLUMN',@level2name=N'PayWayName'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'债务人ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BU_AcIO', @level2type=N'COLUMN',@level2name=N'YouDebtID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'对方所属单位名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BU_AcIO', @level2type=N'COLUMN',@level2name=N'YouComName'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'对方名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BU_AcIO', @level2type=N'COLUMN',@level2name=N'YouName'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'对方账户ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BU_AcIO', @level2type=N'COLUMN',@level2name=N'YouWayID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'对方账户名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BU_AcIO', @level2type=N'COLUMN',@level2name=N'YouWayName'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'对方账户号码  比如银行卡号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BU_AcIO', @level2type=N'COLUMN',@level2name=N'YouWayIDNumber'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'交易时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BU_AcIO', @level2type=N'COLUMN',@level2name=N'PayDate'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'交易时间 不确定的时间段（如2017春节期间）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BU_AcIO', @level2type=N'COLUMN',@level2name=N'PayDateStr'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'应付款' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BU_AcIO', @level2type=N'COLUMN',@level2name=N'Money_Old'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'增加的金额、优惠的金额' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BU_AcIO', @level2type=N'COLUMN',@level2name=N'Money_Added'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'(单位:%)  增加的百分比、减少的百分比' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BU_AcIO', @level2type=N'COLUMN',@level2name=N'Money_Percent'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'收入金额' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BU_AcIO', @level2type=N'COLUMN',@level2name=N'SetMoney'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'支出金额' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BU_AcIO', @level2type=N'COLUMN',@level2name=N'PayMoney'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'最终交易的金额' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BU_AcIO', @level2type=N'COLUMN',@level2name=N'Money_Result'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BU_AcIO', @level2type=N'COLUMN',@level2name=N'Remark'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'未还的金额（为付则是需要还给对方的金额）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BU_AcIO', @level2type=N'COLUMN',@level2name=N'YuMoney'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否需要还（0不需要  1需要）（针对制定的用户）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BU_AcIO', @level2type=N'COLUMN',@level2name=N'IsBreakToLinkUser'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否需要还（0不需要  1需要）(针对支付方式)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BU_AcIO', @level2type=N'COLUMN',@level2name=N'IsBreakToPayWay'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否已经报销（只有支出才有值  -1不报销   0待报销 1已经报销 2未报销）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BU_AcIO', @level2type=N'COLUMN',@level2name=N'IsBaoXiao'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'该记录制定的用户ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BU_AcIO', @level2type=N'COLUMN',@level2name=N'LinkUserID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'该记录制定的用户名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BU_AcIO', @level2type=N'COLUMN',@level2name=N'LinkUserName'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'关联的ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BU_AcIO', @level2type=N'COLUMN',@level2name=N'LinkTableID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'申请表表名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BU_AcIO', @level2type=N'COLUMN',@level2name=N'ApplyTableName'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'申请表ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BU_AcIO', @level2type=N'COLUMN',@level2name=N'ApplyTableID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'添加时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BU_AcIO', @level2type=N'COLUMN',@level2name=N'AddDate'
GO




if(exists(select * from sysobjects where name='BU_BankAccount'))
begin
	drop table [BU_BankAccount]
end
go

/**  **/
CREATE TABLE [dbo].[BU_BankAccount](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[UserID] [bigint] NOT NULL,
	[BankType] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[IDNumber] [nvarchar](50) NOT NULL,
	[MoneyType] [int] NOT NULL,
	[YuMoney] [decimal](14,2) NOT NULL,
	[IsBreak] [int] NOT NULL,
	[AddDate] [datetime] NOT NULL,
	primary key(ID)
) 

GO

SET ANSI_PADDING OFF
GO





ALTER TABLE [dbo].[BU_BankAccount] ADD  CONSTRAINT [DF_BU_BankAccount_UserID]  DEFAULT ((0)) FOR [UserID]
GO

ALTER TABLE [dbo].[BU_BankAccount] ADD  CONSTRAINT [DF_BU_BankAccount_BankType]  DEFAULT ((1)) FOR [BankType]
GO

ALTER TABLE [dbo].[BU_BankAccount] ADD  CONSTRAINT [DF_BU_BankAccount_Name]  DEFAULT ('') FOR [Name]
GO

ALTER TABLE [dbo].[BU_BankAccount] ADD  CONSTRAINT [DF_BU_BankAccount_IDNumber]  DEFAULT ('') FOR [IDNumber]
GO

ALTER TABLE [dbo].[BU_BankAccount] ADD  CONSTRAINT [DF_BU_BankAccount_MoneyType]  DEFAULT ((0)) FOR [MoneyType]
GO

ALTER TABLE [dbo].[BU_BankAccount] ADD  CONSTRAINT [DF_BU_BankAccount_YuMoney]  DEFAULT ((0)) FOR [YuMoney]
GO

ALTER TABLE [dbo].[BU_BankAccount] ADD  CONSTRAINT [DF_BU_BankAccount_IsBreak]  DEFAULT ((0)) FOR [IsBreak]
GO

ALTER TABLE [dbo].[BU_BankAccount] ADD  CONSTRAINT [DF_BU_BankAccount_AddDate]  DEFAULT (getdate()) FOR [AddDate]
GO




EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BU_BankAccount', @level2type=N'COLUMN',@level2name=N'UserID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'银行类型 （ 0债务人  1现金 2网络账户  3储蓄卡  4信用卡）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BU_BankAccount', @level2type=N'COLUMN',@level2name=N'BankType'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'账号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BU_BankAccount', @level2type=N'COLUMN',@level2name=N'IDNumber'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'币种类型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BU_BankAccount', @level2type=N'COLUMN',@level2name=N'MoneyType'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'账户余额' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BU_BankAccount', @level2type=N'COLUMN',@level2name=N'YuMoney'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'余额是否允许小于0（是否信用）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BU_BankAccount', @level2type=N'COLUMN',@level2name=N'IsBreak'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'添加日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BU_BankAccount', @level2type=N'COLUMN',@level2name=N'AddDate'
GO




if(exists(select * from sysobjects where name='BU_PayType2'))
begin
	drop table [BU_PayType2]
end
go

/** 常用支付方式 **/
CREATE TABLE [dbo].[BU_PayType2](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[UserID] [bigint] NOT NULL,
	[OpWay] [int] NOT NULL,
	[PayType] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[State] [int] NOT NULL,
	[Sort] [bigint] NOT NULL,
	[IsBreak] [bit] NOT NULL,
	[AddDate] [datetime] NOT NULL,
	primary key(ID)
) 

GO

SET ANSI_PADDING OFF
GO





ALTER TABLE [dbo].[BU_PayType2] ADD  CONSTRAINT [DF_BU_PayType2_UserID]  DEFAULT ((0)) FOR [UserID]
GO

ALTER TABLE [dbo].[BU_PayType2] ADD  CONSTRAINT [DF_BU_PayType2_OpWay]  DEFAULT ((-1)) FOR [OpWay]
GO

ALTER TABLE [dbo].[BU_PayType2] ADD  CONSTRAINT [DF_BU_PayType2_PayType]  DEFAULT ((0)) FOR [PayType]
GO

ALTER TABLE [dbo].[BU_PayType2] ADD  CONSTRAINT [DF_BU_PayType2_Name]  DEFAULT ('') FOR [Name]
GO

ALTER TABLE [dbo].[BU_PayType2] ADD  CONSTRAINT [DF_BU_PayType2_State]  DEFAULT ((1)) FOR [State]
GO

ALTER TABLE [dbo].[BU_PayType2] ADD  CONSTRAINT [DF_BU_PayType2_Sort]  DEFAULT ((0)) FOR [Sort]
GO

ALTER TABLE [dbo].[BU_PayType2] ADD  CONSTRAINT [DF_BU_PayType2_IsBreak]  DEFAULT ((0)) FOR [IsBreak]
GO

ALTER TABLE [dbo].[BU_PayType2] ADD  CONSTRAINT [DF_BU_PayType2_AddDate]  DEFAULT (getdate()) FOR [AddDate]
GO



EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'常用支付方式' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BU_PayType2'
GO


EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BU_PayType2', @level2type=N'COLUMN',@level2name=N'UserID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'操作类型 （-1支出 1收入 2转账 3借贷）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BU_PayType2', @level2type=N'COLUMN',@level2name=N'OpWay'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'收支类型 -1:支 1收' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BU_PayType2', @level2type=N'COLUMN',@level2name=N'PayType'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'支付账目  如生活缴费(水费 电费 网费)  充值(流量 话费)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BU_PayType2', @level2type=N'COLUMN',@level2name=N'Name'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'状态' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BU_PayType2', @level2type=N'COLUMN',@level2name=N'State'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'排序 越大越靠后' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BU_PayType2', @level2type=N'COLUMN',@level2name=N'Sort'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否需要还给该账号（0不需要  1需要）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BU_PayType2', @level2type=N'COLUMN',@level2name=N'IsBreak'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'添加时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BU_PayType2', @level2type=N'COLUMN',@level2name=N'AddDate'
GO




if(exists(select * from sysobjects where name='BU_PayType3'))
begin
	drop table [BU_PayType3]
end
go

/**  **/
CREATE TABLE [dbo].[BU_PayType3](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[PID] [bigint] NOT NULL,
	[UserID] [bigint] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[State] [int] NOT NULL,
	[Sort] [bigint] NOT NULL,
	[IsBreak] [bit] NOT NULL,
	[AddDate] [datetime] NOT NULL,
	primary key(ID)
) 

GO

SET ANSI_PADDING OFF
GO





ALTER TABLE [dbo].[BU_PayType3] ADD  CONSTRAINT [DF_BU_PayType3_PID]  DEFAULT ((0)) FOR [PID]
GO

ALTER TABLE [dbo].[BU_PayType3] ADD  CONSTRAINT [DF_BU_PayType3_UserID]  DEFAULT ((0)) FOR [UserID]
GO

ALTER TABLE [dbo].[BU_PayType3] ADD  CONSTRAINT [DF_BU_PayType3_Name]  DEFAULT ('') FOR [Name]
GO

ALTER TABLE [dbo].[BU_PayType3] ADD  CONSTRAINT [DF_BU_PayType3_State]  DEFAULT ((1)) FOR [State]
GO

ALTER TABLE [dbo].[BU_PayType3] ADD  CONSTRAINT [DF_BU_PayType3_Sort]  DEFAULT ((0)) FOR [Sort]
GO

ALTER TABLE [dbo].[BU_PayType3] ADD  CONSTRAINT [DF_BU_PayType3_IsBreak]  DEFAULT ((0)) FOR [IsBreak]
GO

ALTER TABLE [dbo].[BU_PayType3] ADD  CONSTRAINT [DF_BU_PayType3_AddDate]  DEFAULT (getdate()) FOR [AddDate]
GO




EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'父级ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BU_PayType3', @level2type=N'COLUMN',@level2name=N'PID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BU_PayType3', @level2type=N'COLUMN',@level2name=N'UserID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'支付账目  如生活缴费(水费 电费 网费)  充值(流量 话费)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BU_PayType3', @level2type=N'COLUMN',@level2name=N'Name'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'状态' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BU_PayType3', @level2type=N'COLUMN',@level2name=N'State'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'排序 越大越靠后' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BU_PayType3', @level2type=N'COLUMN',@level2name=N'Sort'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否需要还给该账号（0不需要  1需要）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BU_PayType3', @level2type=N'COLUMN',@level2name=N'IsBreak'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'添加时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BU_PayType3', @level2type=N'COLUMN',@level2name=N'AddDate'
GO




if(exists(select * from sysobjects where name='BU_UserInfo'))
begin
	drop table [BU_UserInfo]
end
go

/** 用户信息表 **/
CREATE TABLE [dbo].[BU_UserInfo](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[UserNO] [varchar](32) NOT NULL,
	[UserName] [nvarchar](50) NULL,
	[LoginName] [nvarchar](50) NOT NULL,
	[Pwd] [nvarchar](500) NOT NULL,
	[ToKen] [nvarchar](50) NOT NULL,
	[Gender] [varchar](2) NULL,
	[BirthDate] [datetime] NOT NULL,
	[Mobile] [nvarchar](50) NULL,
	[Telephone] [nvarchar](50) NULL,
	[Fax] [nvarchar](32) NULL,
	[QQ] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[CreateTime] [datetime] NOT NULL,
	[UpdateTime] [datetime] NULL,
	[ProvinceCode] [nvarchar](6) NOT NULL,
	[Province] [nvarchar](50) NOT NULL,
	[CityCode] [nvarchar](6) NOT NULL,
	[City] [nvarchar](50) NOT NULL,
	primary key(ID,UserNO)
) 

GO

SET ANSI_PADDING OFF
GO





ALTER TABLE [dbo].[BU_UserInfo] ADD  CONSTRAINT [DF_BU_UserInfo_UserName]  DEFAULT ('') FOR [UserName]
GO

ALTER TABLE [dbo].[BU_UserInfo] ADD  CONSTRAINT [DF_BU_UserInfo_LoginName]  DEFAULT ('') FOR [LoginName]
GO

ALTER TABLE [dbo].[BU_UserInfo] ADD  CONSTRAINT [DF_BU_UserInfo_Pwd]  DEFAULT ('') FOR [Pwd]
GO

ALTER TABLE [dbo].[BU_UserInfo] ADD  CONSTRAINT [DF_BU_UserInfo_ToKen]  DEFAULT ('') FOR [ToKen]
GO

ALTER TABLE [dbo].[BU_UserInfo] ADD  CONSTRAINT [DF_BU_UserInfo_Fax]  DEFAULT ('') FOR [Fax]
GO

ALTER TABLE [dbo].[BU_UserInfo] ADD  CONSTRAINT [DF_BU_UserInfo_CreateTime]  DEFAULT (getdate()) FOR [CreateTime]
GO

ALTER TABLE [dbo].[BU_UserInfo] ADD  CONSTRAINT [DF_BU_UserInfo_ProvinceCode]  DEFAULT ('') FOR [ProvinceCode]
GO

ALTER TABLE [dbo].[BU_UserInfo] ADD  CONSTRAINT [DF_BU_UserInfo_Province]  DEFAULT ('') FOR [Province]
GO

ALTER TABLE [dbo].[BU_UserInfo] ADD  CONSTRAINT [DF_BU_UserInfo_CityCode]  DEFAULT ('') FOR [CityCode]
GO

ALTER TABLE [dbo].[BU_UserInfo] ADD  CONSTRAINT [DF_BU_UserInfo_City]  DEFAULT ('') FOR [City]
GO



EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户信息表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BU_UserInfo'
GO


EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BU_UserInfo', @level2type=N'COLUMN',@level2name=N'UserNO'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户中文名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BU_UserInfo', @level2type=N'COLUMN',@level2name=N'UserName'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'登录名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BU_UserInfo', @level2type=N'COLUMN',@level2name=N'LoginName'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'密码 加密后' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BU_UserInfo', @level2type=N'COLUMN',@level2name=N'Pwd'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'登录令牌' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BU_UserInfo', @level2type=N'COLUMN',@level2name=N'ToKen'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'性别' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BU_UserInfo', @level2type=N'COLUMN',@level2name=N'Gender'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'出生日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BU_UserInfo', @level2type=N'COLUMN',@level2name=N'BirthDate'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'联系电话（手机）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BU_UserInfo', @level2type=N'COLUMN',@level2name=N'Mobile'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'联系电话（座机）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BU_UserInfo', @level2type=N'COLUMN',@level2name=N'Telephone'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'传真' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BU_UserInfo', @level2type=N'COLUMN',@level2name=N'Fax'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'QQ号码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BU_UserInfo', @level2type=N'COLUMN',@level2name=N'QQ'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'电子邮件' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BU_UserInfo', @level2type=N'COLUMN',@level2name=N'Email'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BU_UserInfo', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'省份' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BU_UserInfo', @level2type=N'COLUMN',@level2name=N'Province'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'城市' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BU_UserInfo', @level2type=N'COLUMN',@level2name=N'City'
GO




if(exists(select * from sysobjects where name='BU_UserLogin'))
begin
	drop table [BU_UserLogin]
end
go

/** 登录账号 **/
CREATE TABLE [dbo].[BU_UserLogin](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[LoginSource] [int] NOT NULL,
	[UID] [nvarchar](100) NOT NULL,
	[UserNO] [varchar](32) NOT NULL,
	[AddTime] [datetime] NOT NULL,
	[State] [int] NOT NULL,
	[OpUserID] [bigint] NOT NULL,
	[OpUserName] [nvarchar](50) NOT NULL,
	[OpTime] [datetime] NULL,
	primary key(ID)
) 

GO

SET ANSI_PADDING OFF
GO





ALTER TABLE [dbo].[BU_UserLogin] ADD  CONSTRAINT [DF_BU_UserLogin_UserNO]  DEFAULT ('') FOR [UserNO]
GO

ALTER TABLE [dbo].[BU_UserLogin] ADD  CONSTRAINT [DF_BU_UserLogin_AddTime]  DEFAULT (getdate()) FOR [AddTime]
GO

ALTER TABLE [dbo].[BU_UserLogin] ADD  CONSTRAINT [DF_BU_UserLogin_State]  DEFAULT ((0)) FOR [State]
GO

ALTER TABLE [dbo].[BU_UserLogin] ADD  CONSTRAINT [DF_BU_UserLogin_OpUserID]  DEFAULT ((0)) FOR [OpUserID]
GO

ALTER TABLE [dbo].[BU_UserLogin] ADD  CONSTRAINT [DF_BU_UserLogin_OpUserName]  DEFAULT ('') FOR [OpUserName]
GO



EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'登录账号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BU_UserLogin'
GO


EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'注册来源 （微信、QQ、新浪微博）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BU_UserLogin', @level2type=N'COLUMN',@level2name=N'LoginSource'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'第三方唯一索引' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BU_UserLogin', @level2type=N'COLUMN',@level2name=N'UID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'对应系统的用户编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BU_UserLogin', @level2type=N'COLUMN',@level2name=N'UserNO'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'注册时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BU_UserLogin', @level2type=N'COLUMN',@level2name=N'AddTime'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'状态 0未激活 1正常' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BU_UserLogin', @level2type=N'COLUMN',@level2name=N'State'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'操作用户ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BU_UserLogin', @level2type=N'COLUMN',@level2name=N'OpUserID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'操作时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BU_UserLogin', @level2type=N'COLUMN',@level2name=N'OpTime'
GO




