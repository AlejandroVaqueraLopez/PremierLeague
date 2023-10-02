--Create Database PremierLeague;

--Use PremierLeague;

Create Table Cities(
	Id Int Primary Key Identity(1,1),
	Name Varchar(50) Not Null Unique,
	Status bit Not Null Default 1
);

Select * From Cities

Create Table Teams(
	Id Int Primary Key Identity(1,1),
	Name Varchar(50) Not Null Unique,
	CityId Int Not Null References Cities(Id),
	Status bit Not Null Default 1
)

Insert Into Teams (Name, CityId) Values ('Atlas', 4),
('Rayados de monterrey', 5), ('Chivas rayadas del guadalajara', 4),
('Club Tijuana', 1)

Select * From Cities
Select * From Teams

Create Table Players(
	Id Int Primary Key Identity(1,1),
	Name Varchar(50) Not Null,
	Lastname Varchar(50) Not Null,
	DOB Date Not Null,
	TeamId Int Not Null References Teams(Id),
	Number Int Not Null,
	Position Varchar(30) Not Null,
	Status bit Not Null Default 1
)

Insert Into Players (Name, Lastname, DOB, TeamId, Number, Position) Values 
('Lionel', 'Messi', '1989-12-23', 1, 10, 'Delantero'),
('Cristiano', 'Ronaldo', '1987-11-20', 3, 7, 'Delantero');

Select * From Players Where DOB = '11/20/1987'

Create Table Games(
	Id Int Primary Key Identity(1,1),
	Datetime Datetime Not Null,
	LocalId Int Not Null References Teams(Id),
	VisitorId Int Not Null References Teams(Id),
	Status Bit Not Null Default 1
)

Insert Into Games (Datetime, LocalId, VisitorId) Values 
('09-23-2023 19:00:00', 1, 4), ('09-23-2023 21:00:00', 2, 3);

Select * From Games