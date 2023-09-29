CREATE TABLE Astitva_AccountHolderTable (
    AccountholderId INT IDENTITY(1,1) PRIMARY KEY,
    AccountholderName VARCHAR(50),
    AccountType VARCHAR(50),
	AccountNumber VARCHAR(50),
	IsActive bit default 1,
	IsDeleted bit default 0
);

CREATE TABLE Astitva_NomineeTable (
    NomineeId INT IDENTITY(1,1) PRIMARY KEY,
    NomineeName VARCHAR(50),
    NomineeAge INT,
    AddressType VARCHAR(50),
    Address VARCHAR(100),
    AccountHolderId INT FOREIGN KEY REFERENCES Astitva_AccountHolderTable(AccountholderId),
	IsActive bit default 1,
	IsDeleted bit default 0
);
------------------------------------------------------------------------------------------------------

Insert into Astitva_AccountHolderTable values('John Doe','Savings Account','123456789012345',1,0)
Insert into Astitva_NomineeTable values('ABC',45,'Home Address','Dehradun',1,1,0)
Insert into Astitva_NomineeTable values('XYZ',42,'Home Address','Dehradun',1,1,0)

------------------------------------------------------------------------------------------------------
SELECT * FROM Astitva_AccountHolderTable
SELECT * FROM Astitva_NomineeTable


------------------------------------------------------------------------------------------------------

update Astitva_AccountHolderTable Set IsActive=1 where AccountHolderId=2
update Astitva_AccountHolderTable Set IsDeleted=0 where AccountHolderId=2

update Astitva_NomineeTable Set IsActive=1 where AccountHolderId=2
update Astitva_NomineeTable Set IsDeleted=0 where AccountHolderId=2
------------------------------------------------------------------------------------------------------

Drop Table Astitva_AccountHolderTable
Drop Table Astitva_NomineeTable
Truncate Table Astitva_NomineeTable
Truncate Table Astitva_AccountHolderTable
------------------------------------------------------------------------------------------------------
