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

-- Ubacivanje podataka u tabelu Proizvodi

set identity_insert Proizvodi on;

insert into Proizvodi(ProizvodID, Naziv, Opis, Kategorija, Proizvodjac, Dobavljac, Cena)
values (1, N'Hleb', N'Hleb Dukan 500g', N'Prehrana', N'Dukan', N'Roda', 50 );
insert into Proizvodi(ProizvodID, Naziv, Opis, Kategorija, Proizvodjac, Dobavljac, Cena)
values (2, N'Mleko', N'Domace mleko 1l', N'Prehrana', N'Moja Kravica', N'Idea', 120 );
insert into Proizvodi(ProizvodID, Naziv, Opis, Kategorija, Proizvodjac, Dobavljac, Cena)
values (3, N'Jabuke', N'Zelene Jabuke 1kg', N'Voce', N'Delta', N'Roda', 140 );
insert into Proizvodi(ProizvodID, Naziv, Opis, Kategorija, Proizvodjac, Dobavljac, Cena)
values (4, N'Sapun', N'Sapun Lavanda', N'Higijena', N'Kosili', N'Maxi', 90 );
insert into Proizvodi(ProizvodID, Naziv, Opis, Kategorija, Proizvodjac, Dobavljac, Cena)
values (5, N'Pavlaka', N'Pavlaka 20%mm 500g', N'Prehrana', N'Moja Kravica', N'Roda', 180 );
insert into Proizvodi(ProizvodID, Naziv, Opis, Kategorija, Proizvodjac, Dobavljac, Cena)
values (6, N'Mala sveska', N'Mala sveska - linije', N'Skolski Pribor', N'Stabilo', N'Maxi', 160 );
insert into Proizvodi(ProizvodID, Naziv, Opis, Kategorija, Proizvodjac, Dobavljac, Cena)
values (7, N'Sampon', N'Sampon za kosu 750ml', N'Higijena', N'Kosili', N'Maxi', 450 );
insert into Proizvodi(ProizvodID, Naziv, Opis, Kategorija, Proizvodjac, Dobavljac, Cena)
values (8, N'Pasta za zube', N'Pasta za zube sa ukus mente', N'Higijena', N'Sensodyne', N'Roda', 330 );
insert into Proizvodi(ProizvodID, Naziv, Opis, Kategorija, Proizvodjac, Dobavljac, Cena)
values (9, N'Olovka', N'Hemijska olovka - plava', N'Skolski Pribor', N'Stabilo', N'Maxi', 75 );
insert into Proizvodi(ProizvodID, Naziv, Opis, Kategorija, Proizvodjac, Dobavljac, Cena)
values (10, N'Gumica', N'Gumica za brisanje', N'Skolski Pribor', N'Stabilo', N'Maxi', 85 );
insert into Proizvodi(ProizvodID, Naziv, Opis, Kategorija, Proizvodjac, Dobavljac, Cena)
values (11, N'Jogurt', N'Jogurt Balanas 1kg - poboljsava varenje', N'Prehrana', N'Balans', N'Roda', 175 );
insert into Proizvodi(ProizvodID, Naziv, Opis, Kategorija, Proizvodjac, Dobavljac, Cena)
values (12, N'Velika sveska', N'Velika sveska - kockice', N'Skolski Pribor', N'Stabilo', N'Maxi', 8900 );

set identity_insert Proizvodi off;