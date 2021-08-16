
create database AirlineManagement
use AirlineManagement
--drop database AirlineManagement
--USERS
create table Users(
userID varchar(15) primary key, 
FirstName varchar(20) not null,
LastName varchar(20) not null,
Email varchar(40) not null unique,
Password varchar(56) not null,
DOB varchar(16) not null,
PhoneNo decimal(10,0) not null unique,
--type varchar(5) not null--Admin/User(Or Admin would need only Username and pwd) 
)

--Admin
create table Admin(
adminID varchar(15) primary key,
adminPassword varchar(56) not null 
)

--admin (Add-Delete Flight)
create table Flight(
FlightNo varchar(15) primary key,
From_loc varchar(16) not null,--city,state
To_loc varchar(16) not null,
Depart_time varchar(15) not null,
Arrival_time varchar(15) not null,
Duration varchar(15) not null,
Business int not null,--seats
Economy int not null,--seats
price_B money not null,
price_E money not null
)
--drop table Flight
--alter table Flight alter column Depart_time varchar(25) not null
--alter table Flight alter column Arrival_time varchar(25) not null
--alter table Flight alter column duration varchar(25) not null

create table TicketDetails(
TicketNo varchar(20),--(PNR)
UserID varchar(15) not null foreign key references Users(userID) ,
Flight_No varchar(15) not null foreign key references Flight(FlightNo) ,
F_dept_dt varchar(12) not null ,--(on the basis of f_dept_dt and flight No, we can get data from flight details to display to ticket PNR)
seats_booked_B int not null,--Business
seats_booked_E int not null,--Economy
status varchar(12) not null--Cancelled/Booked
primary key(TicketNo)
)

--Passenger Table
create table Passenger(
TicketNo varchar(20) not null foreign key references TicketDetails(TicketNo),
seatno varchar(5) not null,
Name varchar(15) not null,
age int not null,
gender varchar(8) not null,
classT varchar(10) not null
primary key(TicketNo,seatno)
)
--alter table 

--drop table Passenger
--Passenger Card Details
--create table Card(
--UserID varchar(15) primary key foreign key references Users(userID) ,
--card_No varchar(16) not null unique,
--card_type varchar(10) not null,
--expiration_date datetime not null
--)

--drop table Card
--------------------------


