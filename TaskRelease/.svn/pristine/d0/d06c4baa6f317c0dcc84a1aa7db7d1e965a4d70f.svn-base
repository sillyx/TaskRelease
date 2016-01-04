use master
go
if exists(select * from sysdatabases  where name='TaskRelease')
drop database TaskRelease
go
create database TaskRelease
go
use TaskRelease
go
if exists(select * from sysobjects where name='[Member]')
drop table  [Member]
go
create table [Member]--用户表
(
	Id char(32) primary key not null,--主键Id
	RealName nvarchar(20),--姓名
	PhoneNo char(11) not null,--手机号
	Category smallint not null,--类型（个人 or 老板）
	RegisterDate datetime  default(getdate()) not null,--注册日期
	HeadImageUrl varchar(200),--头像
	Completed bit not null,--资料完整度
	SertId char(18),--证件号码
	UserName nvarchar(20),--用户名
	QQNo char(15),--QQ
	Email varchar(30),--Emai
	Gender bit--性别
)
go
if exists(select * from sysobjects where name='PersonCategory')
drop table  PersonCategory
go
create table PersonCategory--人员分类表
(
	Id char(32) primary key,--编号
	Name nvarchar(10) not null--名称
)
go
if exists(select * from sysobjects where name='PersonalInfo')
drop table  PersonalInfo
go
create table PersonalInfo--人员表
(
	Id char(32) primary key,--编号
	MemberId char(32) foreign key references [Member](Id) not null,--用户编号
	CategoryId char(32) foreign key references PersonCategory(Id) not null,--人员分类
	City nvarchar(50) not null,--工作城市
	Salary nvarchar(20) not null,--薪资
	JobCategory bit not null,--工作性质（全职 or 兼职）
	Remark nvarchar(200) not null,--说明(eg:兼职时间是周一至周五 or 周末)
	CurrentState smallint not null,--当前状态（闲置 or 预约）
	IsDisplay bit ,--是否在首页显示
	CreateDate datetime  default(getdate()) not null,--创建日期
	AuditState bit not null,--审核状态
	Sort smallint--排序（权重）
)
go

if exists(select * from sysobjects where name='ProjectCategory')
drop table  ProjectCategory
go
create table ProjectCategory--项目分类表
(
	Id char(32) primary key,--项目编号
	Name nvarchar(10) not null--项目名称
)
go

if exists(select * from sysobjects where name='Project')
drop table  Project
go
create table Project--项目表
(
	Id char(32) primary key,--项目编号
	MemberId char(32) foreign key references [Member](Id) not null,--用户编号(发行者)
	Title nvarchar(50),--标题
	Requirement nvarchar(1000),--需求描述
	IssueDate datetime  default(getdate()) not null,--发布日期
	AuditState bit not null,--发布状态（中标or竞标)
	CategoryId char(32) not null,--项目分类
	IsDisplay bit ,--是否在首页显示
	Sort smallint--排序（权重）
)
go


if exists(select * from sysobjects where name='ProjectOrder')
drop table  ProjectOrder--项目订单表
go
create table ProjectOrder--项目订单表
(
	Id char(32) primary key not null,--项目订单编号
	AuditState bit not null,--订单状态
	CreateDate datetime  default(getdate()) not null,--订单生成日期
	Bidder char(32) foreign key references [Member](Id) not null,--中标者
	Tenderer char(32) foreign key references [Member](Id) not null,--招标者
	ProjectId char(32) foreign key references [Project](Id) not null --项目编号
)
go


if exists(select * from sysobjects where name='PersonalOrder')
drop table  PersonalOrder
go
create table PersonalOrder--人员订单表
(
	Id char(32) primary key not null,--项目订单编号
	AuditState bit not null,--订单状态
	CreateDate datetime  default(getdate()) not null,--订单生成日期
	Employer char(32) foreign key references [Member](Id) not null,--雇佣者
	Employee char(32) foreign key references [Member](Id) not null,--雇员
	PersonalId char(32) foreign key references [PersonalInfo](Id) not null --人员表主键
)
go

if exists(select * from sysobjects where name='Question')
drop table  Question
go
create table Question--问答表
(
	Id char(32) primary key not null,--主键
	Content nvarchar(500) not null,--问题描述
	Asker char(32) not null,--提问者
	AuditState int not null,--状态（未结帖，已结贴等状态）
	CreateDate datetime default(getdate()) not null--创建日期
)
go

if exists(select * from sysobjects where name='Comment')
drop table  Comment
go
create table Comment--人员订单表
(
	Id char(32) primary key not null,--主键
	ParentId char(32) not null,--父级编号
	Replayer char(32) not null,--评论者
	CommentDate datetime default(getdate()) not null,--评论时间
	Content nvarchar(500) not null,--评论内容
	QuestionId char(32) foreign key references [Question](Id) not null 
)
go











