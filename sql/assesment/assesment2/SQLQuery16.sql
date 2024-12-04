------------- 1st querry -------------

select DATENAME(WEEKDAY , '2003-01-10') AS DayOfWeek;


------------ 2nd querry ------------

select DATEDIFF(DAY , '2003-01-10' , GETDATE()) AS AgeInDays;


------------- 3rd querry -----------


SELECT * FROM EMP
WHERE DATEDIFF(YEAR , hiredate , GETDATE()) >= 5 AND MONTH(hiredate) = MONTH(GETDATE());


-------- 4th querry ---------


CREATE TABLE Employeee 
( empno int primary key ,empname varchar(20), sal FLOAT , doj DATE);


BEGIN TRANSACTION;


INSERT INTO Employeee
VALUES
(1, 'Devanshu Bhargava', 10000, '2024-10-15'),
(2, 'Abhay Bhargava', 20000, '2020-01-01'),
(3, 'Alok Bhargava', 30000, '2022-01-01');
SAVE TRANSACTION InsertRows;

select * from Employeee


UPDATE Employeee
SET sal = sal * 1.15
WHERE empno = 2;
SAVE TRANSACTION Updaterow;


DELETE FROM Employeee
WHERE empno = 1;


ROLLBACK TRANSACTION Updaterow;


COMMIT TRANSACTION;



------------- 5th querry  ---------------
GO

CREATE FUNCTION calculateBonus(@deptno INT, @sal FLOAT)
RETURNS FLOAT
AS
BEGIN
   DECLARE @bonus FLOAT;
   IF @deptno = 10
       SET @bonus = @sal * 0.15;
   ELSE IF @deptno = 20
       SET @bonus = @sal * 0.20;
   ELSE
       SET @bonus = @sal * 0.05;
   RETURN @bonus;
END;

GO

select empno, ename, sal , deptNo, dbo.calculateBonus(deptNo , sal) as Bonus from EMP

----------- 6th querry ---------
GO

CREATE PROCEDURE UpdateSalaryForSales
AS
BEGIN
   
   UPDATE emp
   SET sal = sal + 500
   WHERE deptno = (SELECT deptno FROM DEPT WHERE dname = 'SALES')
     AND sal < 1500;
END;
GO

EXEC UpdateSalaryForSales;





