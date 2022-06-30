use master
create database TS;
use TS;
drop table Phone;
create table Phones(Id int identity(1,1), FIO nvarchar(50),Telephone nvarchar(50));
select * from Phones;


drop database asp2;
create database asp2;
use asp2;
drop table User;
create table User (Id int, Firstname nvarchar(50),Lastname nvarchar(50),Email nvarchar(50),
	Password nvarchar(50), Status nvarchar(50), Role nvarchar(50));
select * from User;
select * from asp2.dbo.[User];