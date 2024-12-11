use sql_training

CREATE TABLE CourseDetails (
   C_id VARCHAR(255) PRIMARY KEY,
   C_Name VARCHAR(255),
   Start_date DATE,
   End_date DATE,
   Fee INT
);

INSERT INTO CourseDetails (C_id, C_Name, Start_date, End_date, Fee) VALUES
('DN003', 'DotNet', '2018-02-01', '2018-02-28', 15000),
('DV004', 'DataVisualization', '2018-03-01', '2018-04-15', 15000),
('JA002', 'AdvancedJava', '2018-01-02', '2018-01-20', 10000),
('JC001', 'CoreJava', '2018-01-02', '2018-01-12', 3000);



--------------- 1st question -------------------------------

GO

CREATE OR ALTER FUNCTION Courses_Duration(
    @StartDate DATE,
    @EndDate DATE
)
RETURNS INT
AS
BEGIN
    RETURN DATEDIFF(DAY, @StartDate, @EndDate)
END;


SELECT C_id,C_Name,Start_date,End_date,Fee, dbo.Courses_Duration(Start_date, End_date) AS Duration_Days 
FROM CourseDetails;


------------- 2nd question ----------------------

------- Creating table to add or reflect the values-------

CREATE TABLE T_CourseInfo (
   CourseName VARCHAR(100),
   StartDate DATE
);

-----------STARTING NEW BATCH-------------------
GO

CREATE TRIGGER after_course_insert
ON CourseDetails
AFTER INSERT
AS
BEGIN
   
   INSERT INTO T_CourseInfo (CourseName, StartDate)
   SELECT C_Name, Start_date
   FROM inserted;
END;


INSERT INTO CourseDetails (C_id, C_Name, Start_date, End_date, Fee)
VALUES ('SQ005', 'SQL_TRAINING', '2023-01-01', '2023-02-01', 12000);

SELECT * FROM T_CourseInfo;


-------------------- 3rd question -----------------

CREATE TABLE ProductsDetails (
   ProductId INT IDENTITY(1,1) PRIMARY KEY, 
   ProductName NVARCHAR(100),
   Price DECIMAL(10, 2),
   DiscountedPrice AS (Price - (Price * 0.10)) 
);

GO

-----------creating procedure---------------

CREATE PROCEDURE Product_id_generationes
   @Product_name VARCHAR(20),
   @Price FLOAT
AS
BEGIN
   DECLARE @NewProductId INT;
   
   INSERT INTO ProductsDetails (ProductName, Price)
   VALUES (@Product_name, @Price);
   
   SET @NewProductId = SCOPE_IDENTITY();
   
   SELECT @NewProductId AS GeneratedId,
          ProductName,
          Price,
          Price * 0.9 AS DiscountedPrice  
   FROM ProductsDetails
   WHERE ProductId = @NewProductId;
END;


