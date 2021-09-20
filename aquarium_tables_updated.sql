--drop table role;
create table role (id int primary key identity(1,1), role varchar(10));
insert into role values('Admin');
insert into role values ('Customer');
select * from role;

--drop table gender
create table gender (id int primary key identity(1,1), gender varchar(10));
insert into gender values('Female');
insert into gender values ('Male');
GO

--drop table Users
create TABLE Users (
    id int PRIMARY KEY IDENTITY(1,1) , 
    roleId int foreign key references role(id),
    genderId int foreign key references gender(id),
    name varchar(50),
    email varchar(50) not null unique,
    password varchar(25),
    phone_Number varchar(10) unique, 
	
    );
go
-- insert into Users values (1,'Shivani Goswami',1,'shivani@gmail.com','9807654322','shivani123','shivPass');
-- insert into Users values (2,'xyz abc',2,'xyz@gmail.com','9888654322','xyz123','xyzPass');

insert into Users values(1,2,'Vishram','vishram@gmail.com','121212','7878567645');
insert into Users values(2,2,'Imam','imam@gmail.com','67755656','9876567645');
insert into Users values(2,1,'Shivani','shivani@gmail.com','125768742','7878566723');
insert into Users values(2,1,'Romila','romila@gmail.com','263876328763','6554567645');
insert into Users values(2,2,'Akshay','ak@gmail.com','1422434','8978567645');

select * from Users;


--drop table LocationTable;
create table LocationTable(
	Id int identity(1,1) primary key,
	Branch varchar(50) not null
);

insert into LocationTable(Branch) Values('Mumbai');
insert into LocationTable(Branch) Values('Delhi');
insert into LocationTable(Branch) Values('Bangalore');
select * from LocationTable;

--drop table ProductType;
create table ProductType(
	Id int identity(1,1) primary key,
	Category varchar(30) not null
);

insert into ProductType(Category) Values('Fish');
insert into ProductType(Category) Values('Food');
insert into ProductType(Category) Values('Tank');
select * from ProductType;

--drop table Product;
create table Product(
	Id int identity(1,1) primary key,
	Name varchar(30) not null,
	ProductTypeId int foreign key references ProductType(Id) ,
	Quantity int not null,
	Price decimal not null
);

insert into Product Values('GoldFish',1,4,120);
insert into Product Values('AngelFish',1,3,180);
insert into Product Values('JellyFish',1,2,200);

insert into Product Values('Flake Food',2,10,120);
insert into Product Values('FPellets',2,23,180);
insert into Product Values('Frozen',2,33,200);

insert into Product Values('Coldwater Aquarium',3,35,120);
insert into Product Values('Freshwater Tropical Aquarium',3,12,180);
insert into Product Values('Brackish Aquarium',3,20,200);

-- insert into Product(Name,Quantity,Price) Values('GoldFish',5,120);
-- insert into Product(Name,Quantity,Price) Values('AngelFish',15,180);
-- insert into Product(Name,Quantity,Price) Values('JellyFish',30,200);

-- insert into Product(Name,Quantity,Price) Values('Flake Food',25,120);
-- insert into Product(Name,Quantity,Price) Values('FPellets',45,180);
-- insert into Product(Name,Quantity,Price) Values('Frozen',70,200);

-- insert into Product(Name,Quantity,Price) Values('Coldwater Aquarium',35,120);
-- insert into Product(Name,Quantity,Price) Values('Freshwater Tropical Aquarium',85,180);
-- insert into Product(Name,Quantity,Price) Values('Brackish Aquarium',70,200);
select * from Product;


create table LocationJunction(
	Id int identity(1,1) primary key,
	LocationId int foreign key references LocationTable(Id) ,
	ProductId int foreign key references Product(Id),
);

insert into LocationJunction(LocationId,ProductId) Values(1,1);
insert into LocationJunction(LocationId,ProductId) Values(2,2);
insert into LocationJunction(LocationId,ProductId) Values(3,3);
insert into LocationJunction(LocationId,ProductId) Values(1,4);
insert into LocationJunction(LocationId,ProductId) Values(2,5);
insert into LocationJunction(LocationId,ProductId) Values(3,6);
insert into LocationJunction(LocationId,ProductId) Values(1,7);
insert into LocationJunction(LocationId,ProductId) Values(2,8);
insert into LocationJunction(LocationId,ProductId) Values(3,9);
select * from LocationJunction;



--drop table OrderTable;
create table OrderTable(
	Id int identity(1,1) primary key,
	LocationId int foreign key references LocationTable(Id) ,
	UserId int foreign key references Users(Id) ,
	ProductId int foreign key references Product(Id) ,
	Quantity int not null,
	TotalPrice decimal not null
);

insert into OrderTable Values(1,2,1,6,200);
insert into OrderTable Values(2,3,4,13,140);
select * from OrderTable;

--drop table cartStatus;
--create table cartStatus(
--	Id int identity(1,1) primary key,
--	cartStatus nvarchar(500)
--);
--drop table cart;
create table cart(
	Id int identity(1,1) primary key,
	LocationId int foreign key references LocationTable(Id) ,
	UserId int foreign key references Users(Id) ,
	ProductId int foreign key references Product(Id) ,
	Quantity int not null,
	TotalPrice decimal not null
);