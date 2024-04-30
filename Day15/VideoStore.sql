create database VideoStore
use VideoStore
--create table MovieFormat

create table MovieFormat
(
MovieFormatId int identity(1,1) constraint PK_FormatId primary key,
MovieFormatName char(20) constraint UC_FormatName unique
)

--creating table for Categories
create table Category
(
CategoryId int identity(1,1) constraint PK_MovieCategoryId primary key,
CategoryName char(50),
FavouriteCount int
)
--Creating movie table

create table Movies
(
MovieId int identity(1,1) constraint PK_MovieId primary key,
MovieName char(50),
CategoryId int constraint FK_CategoryId foreign key references Category(CategoryId),
MovieFormatId int constraint FK_FormatId foreign key references MovieFormat(MovieFormatId),
RentalStatus bit
)
--create table for member type
create table MemberType
(
MemberTypeId int identity(1,1) constraint PK_TypeId primary key,
MemberType char(20),
CrediCardUsed bit,
CountAllowed int
)

--create table for member details
create table Members
(
MemberId int identity(100,1) constraint PK_MemberId primary key,
MemberName char(50),
PhoneNumber varchar(20) constraint UC_MemberPhone unique,--unique phone number
MemberTypeId int constraint FK_MemberTypeId foreign key references MemberType(MemberTypeID),
)

