CREATE DATABASE EmployeeManagement;

CREATE TABLE Gender(
	Id INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	Gender VARCHAR(10) NOT NULL 
);

CREATE TABLE Employee(
	Id INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	Code INT NOT NULL,
	FirstName NVARCHAR(150) NOT NULL,
	LastName NVARCHAR(150) NOT NULL,
	Email NVARCHAR(50) NOT NULL, 
	DateOfJoining DATETIME NOT NULL,
	Aadhar VARCHAR(12) NOT NULL,
	PAN VARCHAR(10) NOT NULL,
	GenderId INT NOT NULL FOREIGN KEY REFERENCES Gender(Id) 
);


INSERT INTO Gender(
	Gender
)
VALUES
	('Male'),
	('Female'),
	('Others');

INSERT INTO Employee(
	Code,
	FirstName,
	LastName,
	Email,
	DateOfJoining,
	Aadhar,
	PAN,
	GenderId
	)
VALUES(
		011998,
		'Grey ',
		'matter',
		'greymatter@gmail.com',
		'1998-10-20',
		123456789123,
		'asdfg1234d',
		1
		),
		(
		011999,
		'Qwen ',
		'max',
		'qwenmax@gmail.com',
		'1999-11-30',
		123456789145,
		'asdfg4321d',
		2
		),
		(
		011998,
		'Ben ',
		'Tennyson',
		'bentennyson@gmail.com',
		'2000-01-04',
		123456756148,
		'asdfg7894d',
		1
		);

--store procedure for creating employee
CREATE PROCEDURE spCreate(
	@Code INT,
	@FirstName VARCHAR(150),
	@LastName NVARCHAR(150),
	@Email NVARCHAR(50), 
	@DateOfJoining DATETIME,
	@Aadhar VARCHAR(12),
	@PAN VARCHAR(10),
	@GenderId INT
	)
AS
BEGIN TRY
INSERT INTO Employee(
	Code,
	FirstName,
	LastName,
	Email,
	DateOfJoining,
	Aadhar,
	PAN,
	GenderId
	)
VALUES(
		@Code,
		@FirstName ,
		@LastName,
		@Email, 
		@DateOfJoining,
		@Aadhar,
		@PAN,
		@GenderId
		)
END TRY
BEGIN CATCH
	SELECT ERROR_MESSAGE()
END CATCH;

EXECUTE spCreate @Code = 122001,
		@FirstName = 'Rip',
		@LastName = 'Jaws',
		@Email = 'ripjaws@gmail.com',
		@DateOfJoining = '2001-02-20',
		@Aadhar = '987456123012',
		@PAN = '30124DGHF5',
		@GenderId = 1;


--store procedure for getting an employee
CREATE PROCEDURE spGet(
	@Id INT
)
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
	empl.GenderId
FROM Employee empl
WHERE empl.Id = @Id
END;

EXECUTE spGet @Id = 2;


--store procedure for getting all employees
CREATE PROCEDURE spGetAll
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
	empl.GenderId
FROM Employee empl
END;

EXECUTE spGetAll;

--store procedure for update an employee
CREATE PROCEDURE spUpdate(
	@Id INT,
	@Code INT,
	@FirstName VARCHAR(150),
	@LastName NVARCHAR(150),
	@Email NVARCHAR(50), 
	@DateOfJoining DATETIME,
	@Aadhar VARCHAR(12),
	@PAN VARCHAR(10),
	@GenderId INT
	)
AS
BEGIN
UPDATE Employee
SET
	Code = @Code,
	FirstName = @FirstName ,
	LastName = @LastName,
	Email = @Email, 
	DateOfJoining = @DateOfJoining,
	Aadhar = @Aadhar,
	PAN = @PAN,
	GenderId = @GenderId
WHERE Id = @Id
END;


EXECUTE spUpdate 
		@Id = 4,
		@Code = 122001,
		@FirstName = 'Rip',
		@LastName = 'Jaws',
		@Email = 'ripjaws@gmail.com',
		@DateOfJoining = '2001-02-20',
		@Aadhar = '987456123012',
		@PAN = '30124DGHG6',
		@GenderId = 1;


CREATE PROCEDURE spDelete(
	@Id INT
)
AS 
BEGIN
	DELETE FROM Employee WHERE Id = @Id
END;

EXECUTE spDelete @Id = 4;