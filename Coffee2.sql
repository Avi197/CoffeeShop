
use master
alter database [Coffee2] set single_user with rollback immediate


drop database [Coffee2]
create database [Coffee2]

use [Coffee2]
go
drop table if exists drinktype -- loai do uong
create table drinktype (
code varchar(20) not null primary key,
nameof nvarchar(20),
)

drop table if exists drink -- do uong
create table drink (
code varchar(20) not null primary key,
nameof nvarchar(40),
drinktypecode varchar(20) not null foreign key references drinktype(code),
urlpic varchar(100),
)

drop table if exists whatsup -- tin tuc moi/ su kien
create table whatsup (
code varchar(20) not null primary key,
nameof nvarchar(20),
descriptions nvarchar(1000),
)


drop table if exists adminaccount --tai khoan admin--
create table adminaccount (
code varchar(20) not null primary key,
pass varchar(20),
roles varchar(20)
)

insert into drinktype
values('dt1','coffee1')
insert into drinktype
values('dt2','coffee2')
insert into drinktype
values('dt3','coffee3')
insert into drinktype
values('dt4','coffee4')
insert into drinktype
values('dt5','coffee5')

insert into drink
values('d1','smt1','dt1','url1')
insert into drink
values('d2','smt2','dt2','url2')
insert into drink
values('d3','smt3','dt3','url3')
insert into drink
values('d4','smt4','dt4','url4')
insert into drink
values('d5','smt5','dt5','url5')

insert into whatsup
values('w1','whatsup1','bunch of lorem ispum 1')
insert into whatsup
values('w2','whatsup2','bunch of lorem ispum 2')
insert into whatsup
values('w3','whatsup3','bunch of lorem ispum 3')
insert into whatsup
values('w4','whatsup4','bunch of lorem ispum 4')
insert into whatsup
values('w5','whatsup5','bunch of lorem ispum 5')

insert into adminaccount
values('admin','admin','admin')