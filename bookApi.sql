create database BooksDB;
use BooksDB

--CREATE 

create table Category(
CategoryId int primary key identity,
CategoryName varchar(50),
Description varchar(300),
Image varchar(300),
Status char(6),
Position int,
CreatedAt date
);

create table Book(
BookId int primary key identity,
CategoryId int foreign key references Category(CategoryId),
Title varchar(200),
Author varchar(50),
ISBN bigint,
[Year] char(4),
Price decimal,
Description varchar(300),
Position int,
Status char(6),
Image varchar(300),
);


create table Address(
AddressId int primary key identity,
Building varchar(50),
City varchar(20),
Country varchar(20),
Pincode int,
UserId int foreign key references Users(UserId)
);
create table Users(
UserId int primary key identity,
UserName varchar(20),
Email varchar(20) unique,
Mobile int,
[Password] varchar(30),
IsActive bit,
IsAdmin bit,
);

create table Orders(
OrderId int primary key identity,
OrderDate date,
Amount decimal,
UserId int foreign key references Users(UserId)
);

create table OrderItems(
ItemId int primary key identity,
OrderId int foreign key references Orders(OrderId),
BookId int foreign key references Book(BookId),
Qty int
);

create table Cart(
Id int primary key identity,
UserId int foreign key references Users(UserId),
BookId int foreign key references Book(BookId),
Qty int,
);

create table Wishlist(
Id int primary key identity,
UserId int foreign key references Users(UserId),
BookId int foreign key references Book(BookId)
);

create table Coupon(
CouponId int primary key identity,
Code char(15) unique,
Description varchar(100),
Discount int,
MinimumSpend int,
Expiry date);

--INSERT

insert into Category values('Action & Adventure',
'Adventure type books',
'https://images-platform.99static.com//OIpV9mUCUWHFmGbLuiK1qxs0KsA=/1139x0:3848x2709/fit-in/500x500/projects-files/29/2919/291915/4f971bfe-2ea6-4ff7-8c5a-7eba039fa15c.jpg', 
'true',
2,
'2015-02-01'
);

insert into Category values('Children''s Books',
'Children type books',
'https://images-na.ssl-images-amazon.com/images/I/81i5wG7p3sL.jpg',
'true',
1,
'2014-03-01'
);


insert into Category values('Fiction & Fantasy',
'Fiction & Fantasy type books',
'https://cdn.vox-cdn.com/thumbor/_MhMuebg-iHnUcTh0NS-BfoOEOY=/0x0:2040x1360/1400x1050/filters:focal(1020x749:1021x750)/cdn1.vox-cdn.com/uploads/chorus_asset/file/9120275/jbareham_170826_1888_0002.jpg',
'true',
4,
'2020-08-03'
);

insert into Category values('History',
'History type books',
'https://images-na.ssl-images-amazon.com/images/I/A14VAyvYsTL.jpg',
'true',
3,
'2016-05-01'
);


insert into Book values(
1,
'The Secret Garden',
'Frances Hodgson Burnett',
11111111111,
'2018',
175,
'A timeless collection of unabridged literary classic.',
2,
'true',
'https://m.media-amazon.com/images/I/81oZ2suDhdS._AC_UY327_FMwebp_QL65_.jpg'
);

insert into Book values(
1,
'The Complete Novels of Sherlock Holmes',
'Arthur Conan Doyle',
22222222222,
'2017',
500,
'The Complete Novels of Sherlock Holmes',
1,
'true',
'https://images-na.ssl-images-amazon.com/images/I/41OiDvq9pDS._SX460_BO1,204,203,200_.jpg'
);


insert into Book values(
2,
'Nursery Rhymes',
'David Ellwand',
33333333333,
'2014',
150,
'Illustrated Classic Nursery Rhymes.',
1,
'true',
'https://images-na.ssl-images-amazon.com/images/I/51iWlVw33lL._SX412_BO1,204,203,200_.jpg'
);


insert into Book values(
2,
'The Jungle Book',
'Rudyard Kipling',
44444444444,
'2020',
165,
'Illustrated Abridged Children Classics English Novel With Review Questions.',
2,
'true',
'https://images-na.ssl-images-amazon.com/images/I/71Gyh8gEj4L.jpg'
);


insert into Book values(
3,
'Harry Potter and the Chamber of Secrets',
'J.K. Rowling',
55555555555,
'2014',
900,
'Harry Potter''s summer has included the worst birthday ever, doomy warnings from a house-elf called Dobby, and rescue from the Dursleys by his friend Ron Weasley in a magical flying car!',
1,
'true',
'https://images-na.ssl-images-amazon.com/images/I/51F7MMxbhOL._SX324_BO1,204,203,200_.jpg'
);


insert into Book values(
3,
'That Night: Four Friends. Twenty Years. One Haunting Secret.',
'Nidhi Upadhyay',
66666666666,
'2021',
200,
'Natasha, Riya, Anjali and Katherine were best friends in college - each different from the other yet inseparable - until that night.',
2,
'true',
'https://images-na.ssl-images-amazon.com/images/I/41kRkqIt6aL._SX322_BO1,204,203,200_.jpg'
);


insert into Book values(
4,
'Sapiens: A Brief History of Humankind',
'Yuval Noah Harari',
77777777777,
'2015',
2000,
'What makes us brilliant? What makes us deadly? What makes us Sapiens? Yuval Noah Harari challenges everything we know about being human in the perfect read for these unprecedented times.',
1,
'true',
'https://images-na.ssl-images-amazon.com/images/I/41wIeh9EI-L._SX324_BO1,204,203,200_.jpg'
);

insert into Book values(
4,
'The Theory Of Everything',
'Stephen Hawking',
88888888888,
'2006',
1600,
'A timeless collection of unabridged literary classic.',
2,
'true',
'https://images-na.ssl-images-amazon.com/images/I/51oHUvYzbsL._SX327_BO1,204,203,200_.jpg'
);



insert into Users values('Mark', 'm@gmail.com', 11111, '123', 1, 1);
insert into Users values('John', 'j@gmail.com', 22222, '123', 1, 0);
insert into Users values('Watson', 'w@gmail.com', 33333, '123', 1, 0);
insert into Users values('Paul', 'p@gmail.com', 44444, '123', 1, 0);
insert into Users values('Stacy', 's@gmail.com', 55555, '123', 1, 0);


insert into Address values('64/1 Church Street', 'Bangalore', 'India', 560001, 1);
insert into Address values('Flatno 63, Aishwarya Apartment', 'Delhi', 'India', 110065, 3);
insert into Address values('3, Amrit Bhavan, Linking road', 'Mumbai', 'India', 400098, 2);
insert into Address values('23, 2nd floor, Somajiguda', 'Hyderabad', 'India', 500082, 4);
insert into Address values('137, Midc, Chakala', 'Bangalore', 'India', 400093, 5);
insert into Address values('Flatno 20, Aishwarya Apartment', 'Delhi', 'India', 110065, 8);



Insert into Orders(OrderDate, Amount, UserId) values('2022-02-25', 325, 1);
Insert into Orders(OrderDate, Amount, UserId) values('2022-05-20', 500, 3);
Insert into Orders(OrderDate, Amount, UserId) values('2021-05-10', 2330, 2);

Insert into OrderItems(OrderId, BookId, Qty) values(1, 1, 1);
Insert into OrderItems(OrderId, BookId, Qty) values(1, 3, 1);
Insert into OrderItems(OrderId, BookId, Qty) values(2, 2, 1);
Insert into OrderItems(OrderId, BookId, Qty) values(3, 7, 1);
Insert into OrderItems(OrderId, BookId, Qty) values(3, 4, 2);


insert into Coupon(Code, Description, Discount, MinimumSpend, Expiry) values('CODE200', '200 Rs discount on purchase worth 1500', 200, 1500, '2023-01-01');
insert into Coupon(Code, Description, Discount, MinimumSpend, Expiry) values('CODE300', '300 Rs discount on purchase worth 2000', 300, 2000, '2022-12-01');
insert into Coupon(Code, Description, Discount, MinimumSpend, Expiry) values('CODE400', '400 Rs discount on purchase worth 2500', 400, 2500, '2023-01-01');
insert into Coupon(Code, Description, Discount, MinimumSpend, Expiry) values('CODE500', '500 Rs discount on purchase worth 4000', 500, 4000, '2024-01-01');

Insert into Cart(UserId, BookId, Qty) values(1, 1, 2);
Insert into Cart(UserId, BookId, Qty) values(2, 2, 1);
Insert into Cart(UserId, BookId, Qty) values(2, 3, 2);
Insert into Cart(UserId, BookId, Qty) values(3, 1, 1);

Insert into Wishlist(UserId, BookId) values(4, 5);
Insert into Wishlist(UserId, BookId) values(1, 6);
Insert into Wishlist(UserId, BookId) values(5, 3);

