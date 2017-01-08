IF EXISTS(SELECT * from sys.databases WHERE name='FromDatabaseToBrowser')  
BEGIN  
    DROP DATABASE FromDatabaseToBrowser;  
END  
 
CREATE DATABASE FromDatabaseToBrowser;

CREATE TABLE FromDatabaseToBrowser.dbo.CoolPersons
(	
	Id int IDENTITY(1,1) PRIMARY KEY,
	FirstName nvarchar(255),
	LastName nvarchar(255),
	Coolness decimal(3,1),
	CHECK (Coolness >= 0 AND Coolness <= 10)
);

INSERT INTO FromDatabaseToBrowser.dbo.CoolPersons (FirstName, LastName, Coolness)
VALUES ('Pieter', 'Kempenaers', 10),
('Willis', 'Reno', CAST(CAST(RAND()*9.5 as decimal(3,1)) as decimal(3,1))),
('Nicholas', 'Piscopo', CAST(RAND()*9.5 as decimal(3,1))),
('Ben', 'Mazer', CAST(RAND()*9.5 as decimal(3,1))),
('Isiah', 'Yokley', CAST(RAND()*9.5 as decimal(3,1))),
('Stan', 'MagWood', CAST(RAND()*9.5 as decimal(3,1))),
('Joelle', 'Vidales', CAST(RAND()*9.5 as decimal(3,1))),
('Pricilla', 'Ing', CAST(RAND()*9.5 as decimal(3,1))),
('Thu', 'Nghiem', CAST(RAND()*9.5 as decimal(3,1))),
('Lellissa', 'Mckie', CAST(RAND()*9.5 as decimal(3,1))),
('Johnsie', 'Appling', CAST(RAND()*9.5 as decimal(3,1)));