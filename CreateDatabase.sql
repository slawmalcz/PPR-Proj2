CREATE TABLE Artists (
	ID INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	Name VARCHAR(255),
	Surname VARCHAR(255),
	Nick VARCHAR(255) DEFAULT NULL,
	Date_of_birth DATE NOT NULL,
	Date_od_death DATE,
	Description NTEXT,
	
	CONSTRAINT A_Dates CHECK (Date_of_birth<Date_od_death),
	CONSTRAINT A_Names CHECK ((Name IS NOT NULL) OR (Surname IS NOT NULL) OR (Nick IS NOT NULL))
)
GO

INSERT INTO Artists (Name,Surname,Nick,Date_of_birth,Date_od_death,Description) VALUES
	('Antonio','Riviera','Buffalo','1970-02-03',NULL,'To nawet nie jest artusta tylko dadany przykladowt rekord bazy danych pomagający w tworzeniu następnych rekordow');
GO

CREATE TABLE Bands (
	ID INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	Name VARCHAR(255) NOT NULL,
	Date_of_creation DATE NOT NULL,
	Date_of_dismantle DATE,
	Description NTEXT,

	CONSTRAINT B_Dates CHECK (Date_of_creation<Date_of_dismantle)
)
GO

INSERT INTO Bands (Name,Date_of_creation,Date_of_dismantle,Description) VALUES
	('FSHUT','2000-11-02',NULL,'To nawet nie jest zespol dodana przykladowa dana do bazy aby nie byla pusta');
GO

CREATE TABLE Artist_to_Bands (
	ID INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	ID_Artist INT NOT NULL FOREIGN KEY REFERENCES Artists(ID),
	ID_Band INT NOT NULL FOREIGN KEY REFERENCES Bands(ID)
)
GO

INSERT INTO Artist_to_Bands(ID_Artist,ID_Band) VALUES
	(1,1);
GO

CREATE TABLE Albums (
	ID INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	Name VARCHAR(255) NOT NULL,
	Date_of_creation Date NOT NULL,
	Band INT NOT NULL FOREIGN KEY REFERENCES Bands(ID),
	Description NTEXT
)
GO

INSERT INTO Albums(Name,Date_of_creation,Band,Description) VALUES
	('Pyrki','1999-03-04',1,'Kolejne przykladowe dane nie majace zadnego znaczenia');
GO

CREATE TABLE Tracks (
	ID INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	Name VARCHAR(255) NOT NULL,
	Length INT NOT NULL,
)
GO

INSERT INTO Tracks(Name,Length) VALUES
	('Jazgot',123),
	('Szumu',143);
GO

CREATE TABLE Tracks_to_Albums (
	ID INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	ID_Track INT NOT NULL FOREIGN KEY REFERENCES Tracks(ID),
	ID_Album INT NOT NULL FOREIGN KEY REFERENCES Albums(ID)
)
GO

INSERT INTO Tracks_to_Albums (ID_Track,ID_Album) VALUES
	(1,1),
	(2,1);
GO