
use AirlineManagement
use org2
create database AirlineManagement
use AirlineManagement
drop database AirlineManagement
--FLIGHT-----------------------------------
insert into Flight values('BA2140','Mumbai','Delhi','08:30','12:30','04:00',10,20,8000,5000)
insert into Flight values('CB1230','Delhi','Mumbai','13:30','16:30','02:00',10,20,10000,7000)
insert into Flight values('DE2560','Bangalore','Hyderabad','12:00','18:30','06:30',10,20,9000,6500)
insert into Flight values('AR6780','Indore','Bhopal','08:30','12:30','04:00',10,20,8000,5000)
insert into Flight values('ZN9800','Dehradun','Lucknow','01:30','06:30','05:00',10,20,8000,7000)
insert into Flight values('CD4569','Mumbai','Bangalore','10:30','13:30','03:00',10,20,8000,5000)
insert into Flight values('BM4009','Mumbai','Delhi','15:30','17:30','02:00',10,20,9000,10000)

select * from Flight
delete from Flight where FlightNo='AB9999'
select convert(time(0),'12:30:00')
-------------------------------------------------------------------------------------
--USERS
insert into Users values('test123','John','Doe','abc@gmail.com','Pass@1234','01-01-1996',1234567890)
insert into Users values('test','peter','Do','ab@gmail.com','Pass@1234','01-01-1995',1234567891)
select * from Users
truncate table Users
------------------------------------------
--TICKET DETAILS
insert into TicketDetails values('X36Q9C','test123','BA2140','10/08/2021',2,1,'booked')
insert into TicketDetails values('X3Q89E','test','ZN9800','11/08/2021',0,1,'booked')
insert into TicketDetails values('R3Q89E','test','ZN9800','11/08/2022',1,1,'booked')
insert into TicketDetails values('X36Q9D','test','BA2140','10/08/2021',1,1,'booked')
insert into TicketDetails values('K36P9D','test','BA2140','11/08/2021',1,1,'booked')
select * from TicketDetails 
truncate table TicketDetails
select * from TicketDetails where F_dept_dt='10/08/2021'and Flight_No='BM4009'
-------------------------------------------------
--PASSENGERS
select * from Passenger
drop table Passenger
truncate table Passenger
select * from Passenger where ticketno='S3O0P3'
insert into Passenger values('X36Q9C','B1','sam',20,'M','business'),
							('X36Q9C','B3','peter',24,'M','business'),
							('X36Q9C','E5','lily',25,'f','economy')
insert into Passenger values('X36Q9C','E2','parker',22,'M','economy')
insert into Passenger values('X36Q9D','B4','james',26,'M','business'),
							('X36Q9D','E8','Nathan',32,'M','economy')
insert into Passenger values('K36P9D','B9','Anthony',26,'M','business')
delete from TicketDetails where TicketNo='T2M4R3'
delete from Passenger where TicketNo='T2M4R3'
---------------------------------------------------------------
--ADMIN
select * from Admin

insert into Admin values('admin1','admin')
insert into Admin values('admin2','admin')
-------------------------------------------------------------------
--USER
select * from Users
insert into Users values('nish1234','Viserion','911','abbb@gmail.com','password','02-02-1991',123458796)
delete from Users where userID='S3W7S9'
/////////////////
create table FlightDeptDate(
FlightNo varchar(15) ,  
DeptDate varchar(12)  ,
seatsB int not null,
seatsE int not null
primary key(FlightNo,DeptDate)
)
select * from FlightDeptDate