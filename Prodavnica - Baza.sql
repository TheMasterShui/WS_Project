use master;
go
-- Kreiranje Baze
create database Prodavnica on primary
( 
	name = N'Prodavnica_data1',
	filename = N'D:\WS_Projekat\DATA\Prodavnica_data.mdf',
	size = 10MB,
	maxsize = unlimited,
	filegrowth = 10%	
)
log on
(
	name = N'Prodavnica_log',
	filename = N'D:\WS_Projekat\\LOG\Prodavnica_log.ldf',
	size = 5MB,
	maxsize = 70MB,
	filegrowth = 1MB
)

use Prodavnica;
go

-- Kreiranje tabele Proizvodi

create table Proizvodi
(
	ProizvodID int not null identity
	constraint PK_ProizvodID primary key(ProizvodID),

	Naziv nvarchar(50) not null,

	Opis nvarchar(400) not null,

	Kategorija nvarchar(50) not null,

	Proizvodjac nvarchar(50) not null,

	Dobavljac nvarchar(50) not null,

	Cena decimal not null
	
);