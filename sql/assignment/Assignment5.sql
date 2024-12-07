--------------------- 1st question ---------------
 
CREATE OR ALTER PROCEDURE Generate_Pay_slip
    @EmployeeID INT
AS
BEGIN
    
    DECLARE @Salary DECIMAL(10, 2),
            @HRA DECIMAL(10, 2),
            @DA DECIMAL(10, 2),
            @PF DECIMAL(10, 2),
            @IT DECIMAL(10, 2),
            @Deductions DECIMAL(10, 2),
            @GrossSalary DECIMAL(10, 2),
            @NetSalary DECIMAL(10, 2),
            @EmployeeName VARCHAR(100),
            @Designation VARCHAR(50);

    
    SELECT @EmployeeName = ename,
           @Designation = job,
           @Salary = sal
    FROM EMP
    WHERE empno = @EmployeeID;

    
    SET @HRA = @Salary * 0.10;
    SET @DA = @Salary * 0.20;
    SET @PF = @Salary * 0.08;
    SET @IT = @Salary * 0.05;
    SET @Deductions = @PF + @IT;
    SET @GrossSalary = @Salary + @HRA + @DA;
    SET @NetSalary = @GrossSalary - @Deductions;

    
    PRINT '======================================';
    PRINT 'Payslip for ' + @EmployeeName;
    PRINT 'Designation: ' + @Designation;
    PRINT '--------------------------------------';
    PRINT 'Basic Salary: ' + CAST(@Salary AS VARCHAR(10));
    PRINT 'HRA (10%): ' + CAST(@HRA AS VARCHAR(10));
    PRINT 'DA (20%): ' + CAST(@DA AS VARCHAR(10));
    PRINT 'PF (8%): ' + CAST(@PF AS VARCHAR(10));
    PRINT 'IT (5%): ' + CAST(@IT AS VARCHAR(10));
    PRINT '--------------------------------------';
    PRINT 'Deductions (PF + IT): ' + CAST(@Deductions AS VARCHAR(10));
    PRINT 'Gross Salary: ' + CAST(@GrossSalary AS VARCHAR(10));
    PRINT 'Net Salary: ' + CAST(@NetSalary AS VARCHAR(10));
    PRINT '======================================';
END;
 
 
EXEC Generate_Pay_slip @EmployeeID = 7654;

 
-------------------- 2nd question ----------------------
 
CREATE TABLE Holidays (
    Holiday_Date DATE,
    Holiday_Name VARCHAR(100)
);
 
 
INSERT INTO Holidays (Holiday_Date, Holiday_Name)
VALUES 
    ('2024-08-15', 'Independence Day'),
    ('2024-10-02', 'Gandhi Jayanti'),
    ('2024-12-25', 'Christmas'),
    ('2024-11-12', 'Diwali');
 
GO
 
CREATE TRIGGER PreventDataManipulationOnHolidays
ON EMP
FOR INSERT, UPDATE, DELETE
AS
BEGIN
    DECLARE @CurrentDate DATE = GETDATE();
    DECLARE @HolidayName VARCHAR(100);
 
    
    SELECT @HolidayName = Holiday_Name
    FROM Holidays
    WHERE Holiday_Date = @CurrentDate;
 
    IF @HolidayName IS NOT NULL
    BEGIN
        PRINT 'Due to ' + @HolidayName + ', you cannot manipulate';
 
        
        ROLLBACK TRANSACTION;
    END
END;



