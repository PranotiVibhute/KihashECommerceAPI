--Database Creation
Create Database KihashDBCommerce;
use KihashDBCommerce;
--Table Creation
--Customer Table
create table Customers(
CustomerId int Primary Key Identity(1,1),
Name nvarchar(255) Not null,
Email nvarchar(255) Not null UNIQUE,
Address nvarchar(500)Not null,
IsDeleted Bit NOT NULL DEFAULT 0);


create table Products(
ProductId int primary key Identity(1,1),
Name nvarchar(255) Not Null UNIQUE,
Price Decimal(10,2) Not Null,
Quantity int Not Null,
Description nvarchar(Max),
IsDeleted BIT NOT NULL DEFAULT 0);

--Create table Orders
create table Orders(
OrderId int Primary key Identity(1,1),
CustomerId int Not Null,
TotalAmount Decimal(10,2) Not Null,
Status nvarchar(50) Not Null Default 'Pending', 
OrderDate DateTime Not Null,
Constraint FromCustomer Foreign key(CustomerId) 
References Customers(CustomerId));
Create Index Idx_Customerid on Orders(CustomerId);

--Create table payment
Create table Payments(
PaymentId Int Primary Key Identity(1,1),
OrderId Int Not Null,
Amount Decimal(10,2) Not Null,
Status nvarchar(50) Not Null Default 'Pending',
PaymentType nvarchar(50) Not Null,
PaymentDate DATETIME Not Null,
Constraint FromOrder Foreign Key(OrderId) References Orders(OrderId)); 

--Create Table OrderItems
Create table OrderItems(
OrderItemId Int Primary key Identity(1,1),
OrderId Int Not Null,
ProductId Int Not Null,
Quantity int Not Null,
PriceAtOrder Decimal(10,2) Not Null,
Constraint FromOrderTable Foreign key(OrderId) 
References Orders(OrderId),
Constraint FromProductTable Foreign Key(Productid) 
References Products(ProductId));
Create Index Idx_Order on OrderItems(OrderId); 



--Create table Contact
Create table ContactUs(
ContactId int Primary Key Identity(1,1),
ContactName varchar(50) Not Null,
Mobile nvarchar(15),
Gender char(7),
Email nvarchar(50)NOt NULL,
Amount money,
City nvarchar(15),
Address nvarchar(50));
truncate table ContactUs;
--Insert Data

delete from ContactUs Where ContactUsId=7;
select * from ContactUs;
Insert Into ContactUs(ContactName,Mobile,Gender,Email,Amount,City,Address)
values('Jesika','9076543567','FeMale','Jesika@example.com','7000','Mumbai',
' Maharashtra, 411046'),
('Peter','8876543567','Male','Peter@example.com','10000','Pune',
'Katraj Road,Pune , Maharashtra, 411046');
--Insert data
INSERT INTO Customers (Name, Email, Address)
VALUES     
('Mark', 'Mark@example.com', 'Ambegaoun Road,Pune , Maharashtra, 411046'),
('John', 'John@example.com', 'Katraj road, Pune, Maharashtra, 411037'),

('Peter', 'Peter@example.com', 'Hinjawadi, Pune, Maharashtra, 13579');

--Insert data Into products
select * from Products;
INSERT INTO Products (Name, Price, Quantity, Description)
VALUES
('Laptop', 1200.00, 10, 'High-performance laptop suitable for gaming and professional work'),
('Smartphone', 800.00, 15, 'Latest model smartphone with high-resolution camera'),
('Headphones', 150.00, 30, 'Noise-cancelling headphones with over 20 hours of battery life');

select * from Customers;
INSERT INTO Orders (CustomerId, TotalAmount, OrderDate)
VALUES
(1,670,GETDATE()),
(2, 800, GETDATE()), 
(1, 300, GETDATE()); 


INSERT INTO OrderItems (OrderId, ProductId, Quantity, PriceAtOrder)
VALUES
(1, 1, 2, 1200.00), 
(2, 2, 1, 800.00),
(3, 3, 2, 150.00);
select * from OrderItems;

INSERT INTO Payments (OrderId, Amount, PaymentType, 
PaymentDate)VALUES
(1, 2500.00, 'CC', GETDATE()),
(2, 5000.00, 'DC', GETDATE()), 
(3, 450.00, 'COD', GETDATE()); 

Select * from Customers;
Select * from Products;
Select * from Orders;
select * from Payments;
select * from OrderItems;

ALTER DATABASE [OldDatabaseName] 
MODIFY NAME = [NewDatabaseName];

use DbProject;
select c.CustomerId,o.Order;

select * from Orders;

select c.CustomerId,o.OrderId,o.ProductId from Customers c


select * from Customers;
select * from Orders;
select * from Products;

Alter table Orders
Add  ProductId int;
Alter table Orders
Add Constraint Fk_ProductId FOREIGN KEY (ProductId) REFERENCES Products(ProductId);



DECLARE @CustomerId int=2;
DECLARE @FromDate Date='2025-02-01';
DECLARE @ToDate Date='2025-02-28';
select c.Name,o.orderDate,p.Name  from Customers c
inner join Orders o
on c.CustomerId = o.CustomerId
inner join Products p
on o.ProductId =p.ProductId
Where c.Customerid=@CustomerId AND (o.orderDate BETWEEN @FromDate AND @ToDate);

--By Using StoredProcedure

Alter Procedure sp_GetCustomerOrder
 @CustomerID int,
 @FromDate date,
 @ToDate Date,
 @AvgSalary Decimal(10,2) OUTPUT
 As
BEGIN
select c.Name As C_Name,o.OrderDate,p.Name As P_NameAs ,
@AvgSalary=Avg(py.Amount)avgAmount
 from Customers c
inner join Orders o
on c.CustomerId=o.CustomerId
inner join Products p
on p.ProductId=o.ProductId
inner join Payments py
on o.OrderId=py.OrderId
Where o.CustomerId=@CustomerId And 
(o.OrderDate BETWEEN @FromDate AND @ToDate);
END; 
EXEC sp_GetCustomerOrder @CustomerId=1,@FromDate='2025-02-01',@ToDate='2025-02-28',@Name='Mark';

select c.*,py.Amount,o.orderDate,o.OrderId from Customers c
Right Join Orders o
on c.CustomerId=o.CustomerId
Left Join Products p
on o.ProductId=p.ProductId
Left join Payments py
on o.OrderId=py.OrderId;

select * from Orders;
select * from Employees;

select * from Employees where FullName like '%a';

update Employees set DepartID=2 where DepartID Is Null;

select * from Employees where FullName Like '_______' AND (FullName Like
'%A' AND FullName Like 'A%');

Select * from Employees;