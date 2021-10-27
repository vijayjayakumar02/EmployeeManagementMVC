create database EmployeeManagement

CREATE TABLE Gender(
	Id INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	Gender VARCHAR(30) NOT NULL 
);

create table employee(
	ID int Identity(1,1) not null primary key Clustered,
	Code AS 'GS'+ right('0'+cast(ID as varchar(2)),2) persisted,
	FirstName VARCHAR(26) NOT NULL,
	LastName VARCHAR(26) NOT NULL,
	Email VARCHAR(50) NOT NULL, 
	DateOfJoining DATETIME NOT NULL,
	Aadhar VARCHAR(16) NOT NULL,
	PAN VARCHAR(20) NOT NULL,
	GenderId INT NOT NULL FOREIGN KEY REFERENCES Gender(Id) 
);



INSERT INTO Gender(Gender)
VALUES
	('Male'),
	('Female'),
	('Transgender'),
	('Prefer Not To Say');

insert into employee(FirstName,LastName,Email,DateOfJoining,Aadhar,PAN,GenderId)
values('vijay','jayakumar','vijayjayakumar5@gmail.com','2021-06-21','1234564789874','123456789',1)

select * from employee

go
create proc uspGetEmployeeByCode
@Code varchar(10)
as
begin	
	select 
	Code,
	LastName,
	FirstName,
	Email,
	g.Gender,
	DateOfJoining
	from employee 
	Join gender g on g.Id = employee.GenderId
	where Code = @Code
end

go
create proc uspInsertEmployee
@Firstname varchar(26),
@Lastname varchar(26),
@Email varchar(50),
@GenderId int,
@DateOfJoining date,
@Aadhar varchar(20),
@pan varchar(20)
as
begin
	insert into employee(FirstName,LastName,Email,GenderId,DateOfJoining,Aadhar,PAN)
	Values(@Firstname,@Lastname,@Email,@GenderId,@DateOfJoining,@Aadhar,@pan)
end


exec uspGetEmployeeByCode 'GS01'

go
CREATE PROCEDURE uspGetAllEmployee
AS
BEGIN
SELECT 
	empl.Id,
	empl.Code,
	empl.FirstName,
	empl.LastName,
	empl.Email,
	empl.DateOfJoining,
	empl.Aadhar,
	empl.PAN,
	g.Gender
FROM Employee empl
Join Gender g on empl.GenderId = g.Id
END


