-- 1. select employees with the job "MANAGER"
SELECT ename, job 
FROM EMP 
WHERE job = 'MANAGER';

-- 2. select employees with a salary greater than 1000
SELECT ename, sal 
FROM EMP 
WHERE sal > 1000;

-- 3. select employees except "JAMES"
SELECT ename, sal 
FROM EMP 
WHERE ename != 'JAMES';

-- 4. select employees whose name starts with 'S'
SELECT * 
FROM EMP 
WHERE ename LIKE 'S%';

-- 5. select employees whose name contains 'A'
SELECT * 
FROM EMP 
WHERE ename LIKE '%A%';

-- 6. select employees whose name is 3 characters long and ends with 'L'
SELECT * 
FROM EMP 
WHERE ename LIKE '__L%';

-- 7. select the daily salary of 'JONES'
SELECT ename, sal / 30 AS daily_salary 
FROM EMP 
WHERE ename = 'JONES';

-- 8. calculate the total monthly salary of all employees
SELECT SUM(sal) AS total_monthly_salary 
FROM EMP;

-- 9. calculate the average annual salary
SELECT AVG(sal * 12) AS average_annual_salary 
FROM EMP;

-- 10. select employees who are not 'SALESMAN' and work in department 30
SELECT ename, job, sal, deptno 
FROM EMP 
WHERE job != 'SALESMAN' AND deptno = 30;

-- 11. select distinct department numbers
SELECT DISTINCT deptno 
FROM EMP;

-- 12. select employees who have a salary greater than 1500 and work in departments 10 or 30
SELECT ename AS employees, sal AS monthly_salary 
FROM EMP 
WHERE sal > 1500 AND deptno IN (10, 30);

-- 13. select employees who are either 'MANAGER' or 'ANALYST' and whose salary is not in (1000, 3000, 5000)
SELECT ename, job, sal 
FROM EMP 
WHERE job IN ('MANAGER', 'ANALYST') AND sal NOT IN (1000, 3000, 5000);

-- 14. select employees whose commission is greater than 10% of their salary
SELECT ename, sal, comm 
FROM EMP 
WHERE comm > sal * 1.1;

-- 15. select employees whose name contains 'L' twice and work in department 30 or have manager with ID 7782
SELECT ename 
FROM EMP 
WHERE ename LIKE '%L%L' AND (deptno = 30 OR mgr_id = 7782);

-- 16. select employees whose experience is between 30 and 40 years
SELECT ename 
FROM EMP 
WHERE DATEDIFF(YEAR, hiredate, GETDATE()) BETWEEN 30 AND 40;

-- 17. select employees ordered by job ascending and name descending
SELECT ename, job 
FROM EMP 
ORDER BY job ASC, ename DESC;

-- 18. select experience (in years) of 'MILLER'
SELECT ename, DATEDIFF(YEAR, hiredate, GETDATE()) AS experience 
FROM EMP 
WHERE ename = 'MILLER';

