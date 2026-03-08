USE master;
GO
IF EXISTS (SELECT * FROM sys.databases WHERE name = 'RefundSystemDB')
    DROP DATABASE RefundSystemDB;
GO

CREATE DATABASE RefundSystemDB;
GO

USE RefundSystemDB;
GO

CREATE TABLE Citizens (
    CitizenId INT PRIMARY KEY IDENTITY(1,1),
    IdentityCitizen NVARCHAR(9) NOT NULL UNIQUE,
    FullName NVARCHAR(100) NOT NULL
);

CREATE TABLE Incomes (
    IncomesId INT PRIMARY KEY IDENTITY(1,1),
    CitizenId INT NOT NULL,
    Amount DECIMAL(18, 2) NOT NULL,
    [Month] INT NOT NULL CHECK ([Month] BETWEEN 1 AND 12),
    [Year] INT NOT NULL,
    CONSTRAINT FK_Incomes_Citizens FOREIGN KEY (CitizenId) REFERENCES Citizens(CitizenId)
);

CREATE TABLE RefundRequests (
    RequestId INT PRIMARY KEY IDENTITY(1,1),
    CitizenId INT NOT NULL,
    RefundAmount DECIMAL(18, 2) DEFAULT 0,
    [Year] INT NOT NULL,
    [Status] NVARCHAR(20) DEFAULT 'Pending', -- 'Pending', 'Approved', 'Rejected'
    CreatedAt DATETIME DEFAULT GETDATE(),
    CONSTRAINT FK_RefundRequests_Citizens FOREIGN KEY (CitizenId) REFERENCES Citizens(CitizenId)
);

CREATE TABLE Budget (
    BudgetId INT PRIMARY KEY IDENTITY(1,1),
    RequestId INT NULL, 
    AmountChange DECIMAL(18, 2) NOT NULL,
    NewBudget DECIMAL(18, 2) NOT NULL, 
    CreatedAt DATETIME DEFAULT GETDATE(),
    CONSTRAINT FK_Budget_Requests FOREIGN KEY (RequestId) REFERENCES RefundRequests(RequestId)
);

CREATE TABLE SystemBudget (
    Id INT PRIMARY KEY,
    CurrentAmount DECIMAL(18,2) NOT NULL
);
GO


INSERT INTO Citizens (IdentityCitizen, FullName) VALUES ('123456789', 'ישראל ישראלי');
INSERT INTO Citizens (IdentityCitizen, FullName) VALUES ('987654321', 'שרה לוי');


INSERT INTO Incomes (CitizenId, Amount, [Month], [Year]) VALUES 
(1, 7700, 1, 2025),
(1, 7700, 2, 2025),
(1, 7700, 3, 2025),
(1, 7700, 4, 2025),
(1, 7700, 5, 2025),
(1, 7700, 6, 2025)



INSERT INTO Budget (AmountChange, NewBudget) VALUES (0, 100000);


INSERT INTO RefundRequests (CitizenId, [Year], [Status]) VALUES (1, 2025, 'Pending');

INSERT INTO SystemBudget (Id, CurrentAmount)
VALUES (1, 100000);
GO




CREATE OR ALTER PROCEDURE sp_CalculateRefundAmount
    @CitizenId INT,
    @Year INT
AS
BEGIN
    SET NOCOUNT ON;

    IF (
        SELECT COUNT(DISTINCT [Month])
        FROM Incomes
        WHERE CitizenId = @CitizenId
          AND [Year] = @Year
    ) < 6
    BEGIN
        RAISERROR('Not enough income months (minimum 6 required)',16,1);
        RETURN;
    END

    IF EXISTS (
        SELECT 1
        FROM RefundRequests
        WHERE CitizenId = @CitizenId
          AND [Year] = @Year
          AND Status = 'Approved'
    )
    BEGIN
        RAISERROR('Refund already approved for this year',16,1);
        RETURN;
    END

    DECLARE @AvgIncome DECIMAL(18,2);

    SELECT @AvgIncome = SUM(Amount) / 12.0
    FROM Incomes
    WHERE CitizenId = @CitizenId
      AND [Year] = @Year;

    DECLARE @RefundAmount DECIMAL(18,2) = 0;

    IF @AvgIncome <= 5000
        SET @RefundAmount = @AvgIncome * 0.15;

    ELSE IF @AvgIncome <= 8000
        SET @RefundAmount = (5000 * 0.15)
                           + ((@AvgIncome - 5000) * 0.10);

    ELSE IF @AvgIncome <= 9000
        SET @RefundAmount = (5000 * 0.15)
                           + (3000 * 0.10)
                           + ((@AvgIncome - 8000) * 0.05);

    ELSE
        SET @RefundAmount = 0;

    SET @RefundAmount = @RefundAmount * 12;

    SELECT @RefundAmount AS RefundAmount;

END
GO



CREATE OR ALTER PROCEDURE sp_ProcessRefundRequest
    @RequestId INT,
    @ClerkDecision BIT
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        BEGIN TRANSACTION;


        DECLARE @CitizenId INT;
        DECLARE @Year INT;

        SELECT 
            @CitizenId = CitizenId,
            @Year = [Year]
        FROM RefundRequests
        WHERE RequestId = @RequestId;

        IF @CitizenId IS NULL
        BEGIN
            RAISERROR('Request not found',16,1);
            RETURN;
        END


        DECLARE @RefundAmount DECIMAL(18,2);

        CREATE TABLE #RefundResult (
            RefundAmount DECIMAL(18,2)
        );

        INSERT INTO #RefundResult
        EXEC sp_CalculateRefundAmount @CitizenId, @Year;

        SELECT @RefundAmount = RefundAmount FROM #RefundResult;


        DECLARE @CurrentBudget DECIMAL(18,2);

        SELECT @CurrentBudget = CurrentAmount
        FROM SystemBudget WITH (UPDLOCK, HOLDLOCK)
        WHERE Id = 1;

        IF @CurrentBudget IS NULL
        BEGIN
            RAISERROR('System budget not found',16,1);
            RETURN;
        END


        IF @ClerkDecision = 1
        BEGIN

            IF @CurrentBudget < @RefundAmount
            BEGIN
                RAISERROR('Not enough budget available',16,1);
                RETURN;
            END

            UPDATE SystemBudget
            SET CurrentAmount = CurrentAmount - @RefundAmount
            WHERE Id = 1;

            UPDATE RefundRequests
            SET Status = 'Approved',
                RefundAmount = @RefundAmount
            WHERE RequestId = @RequestId;

        END
        ELSE IF @ClerkDecision = 0
        BEGIN

            UPDATE RefundRequests
            SET Status = 'Rejected',
                RefundAmount = 0
            WHERE RequestId = @RequestId;

        END

		
        SELECT 
            @RefundAmount AS RefundAmount,
            @CurrentBudget AS BudgetBefore,
            (SELECT CurrentAmount FROM SystemBudget WHERE Id = 1) AS BudgetAfter;

        COMMIT TRANSACTION;

    END TRY
    BEGIN CATCH

        ROLLBACK TRANSACTION;
        THROW;

    END CATCH
END
GO