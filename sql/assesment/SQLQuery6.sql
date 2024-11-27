use sql_training


------- Creating Books Table---------

CREATE TABLE books (
   id INT IDENTITY(1,1) PRIMARY KEY, -- Identity column for auto-incrementing id
   title VARCHAR(100) NOT NULL,
   author VARCHAR(50) NOT NULL,
   isbn CHAR(13) UNIQUE NOT NULL, -- Ensure ISBN is unique
   published_date DATETIME
)

INSERT INTO books (title, author, isbn, published_date)
VALUES
('My First SQL book', 'Mary Parker', '981483029127', '2012-02-22 12:08:17'),
('My Second SQL book', 'John Mayer', '857300923713', '1972-07-03 09:22:45'),
('My Third SQL book', 'Cary Flint', '523120967812', '2015-10-18 14:05:44');


-------- Creating Reviews Table ---------
CREATE TABLE reviews (
   id INT PRIMARY KEY IDENTITY(1,1),
   book_id INT FOREIGN KEY REFERENCES books(id),
   reviewer_name VARCHAR(50),
   content TEXT,
   rating INT,
   published_date DATETIME
);

INSERT INTO reviews (book_id, reviewer_name, content, rating, published_date)
VALUES
   (1 ,'John Smith', 'My first review', 4, '2017-12-10 05:50:11'),
   (2,'John Smith', 'My second review', 5, '2017-10-13 15:05:12.6'),
   (3 ,'Alice Walker', 'Another review', 1, '2017-10-22 23:47:10');


-- --------- 1st querry --------

select * from books 
where author LIKE '%er';

-- ---------- 2nd querry --------

select title , author , reviewer_name 
from books bk inner join reviews re on bk.id = re.book_id;

-- ----------3d querry--------

SELECT reviewer_name
FROM reviews
GROUP BY reviewer_name
HAVING COUNT(*) > 1;


-----------Creating Customer Table------------

CREATE TABLE Customer (
   ID INT PRIMARY KEY,
   NAME VARCHAR(50),
   AGE INT,
   ADDRESS VARCHAR(50),
   SALARY DECIMAL(10,2)
);

INSERT INTO Customer (ID, NAME, AGE, ADDRESS, SALARY)
VALUES
   (1, 'Ramesh', 32, 'Ahmedabad', 2000.00),
   (2, 'Khilan', 25, 'Delhi', 1500.00),
   (3, 'Kaushik', 23, 'Kota', 2000.00),
   (4, 'Chaitali', 25, 'Mumbai', 6500.00),
   (5, 'Hardik', 27, 'Bhopal', 8500.00),
   (6, 'Komal', 22, 'MP', 4500.00),
   (7, 'Muffy', 24, 'Indore', 10000.00);

   select NAME FROM Customer
   WHERE ADDRESS LIKE '%o%';


----------Creating Orders Table----------------------------


CREATE TABLE ORDERS (
   OID INT ,
   DATE DATETIME,
   CUSTOMER_ID INT,
   AMOUNT int
);
INSERT INTO ORDERS (OID, DATE, CUSTOMER_ID, AMOUNT)
VALUES
   (102, '2009-10-08 00:00:00', 3, 3000),
   (100, '2009-10-08 00:00:00', 3, 1500),
   (101, '2009-11-20 00:00:00', 2, 1560),
   (103, '2008-05-20 00:00:00', 4, 2060);


SELECT DATE, COUNT(CUSTOMER_ID) AS Total_Customers
FROM ORDERS
GROUP BY DATE;

----------Creating Employee Table--------

CREATE TABLE Employee (
   ID INT PRIMARY KEY,
   NAME VARCHAR(50),
   AGE INT,
   ADDRESS VARCHAR(50),
   SALARY DECIMAL(10,2)
);

INSERT INTO Employee(ID, NAME, AGE, ADDRESS, SALARY)
VALUES
   (1, 'Ramesh', 32, 'Ahmedabad', 2000.00),
   (2, 'Khilan', 25, 'Delhi', 1500.00),
   (3, 'Kaushik', 23, 'Kota', 2000.00),
   (4, 'Chaitali', 25, 'Mumbai', 6500.00),
   (5, 'Hardik', 27, 'Bhopal', 8500.00),
   (6, 'Komal', 22, 'MP', NULL),
   (7, 'Muffy', 24, 'Indore', NULL);


SELECT LOWER(NAME) from Employee
WHERE SALARY is NULL;



CREATE TABLE StudentDetails (
   RegisterNo INT PRIMARY KEY,
   Name VARCHAR(50),
   Age INT,
   Qualification VARCHAR(50),
   MobileNo VARCHAR(10),
   Mail_Id VARCHAR(50),
   Location VARCHAR(50),
   Gender CHAR(1)
);
INSERT INTO StudentDetails (RegisterNo, Name, Age, Qualification, MobileNo, Mail_Id, Location, Gender)
VALUES
   (2, 'Sai', 22, 'B.E', '9952836777', 'Sai@gmail.com', 'Chennai', 'M'),
   (3, 'Kumar', 20, 'BSc', '7890125648', 'Kumar@gmail.com', 'Madurai', 'M'),
   (4, 'Selvi', 22, 'B.Tech', '8904567342', 'selvi@gmail.com', 'Selam', 'F'),
   (5, 'Nisha', 25, 'M.E', '7834672310', 'Nisha@gmail.com', 'Theni', 'F'),
   (6, 'SaiSaran', 21, 'B.A', '7890345678', 'saran@gmail.com', 'Madurai', 'F'),
   (7, 'Tom', 23, 'BCA', '8901234675', 'Tom@gmail.com', 'Pune', 'M');

SELECT Gender, COUNT(*) AS Total_Count
FROM StudentDetails
GROUP BY Gender;

-----------------------------x---------------------------------------------------





