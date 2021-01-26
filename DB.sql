CREATE DATABASE PhoneBook;

create table Persons
(
	  PersonId int IDENTITY(1,1) primary key,
	  [Name] nvarchar(64) not null,
	  Surname nvarchar(64) not null,
	  Patronymic nvarchar(64) not null,
    	  [State] nvarchar(64) not null,
  	  City nvarchar(64) not null,
  	  Street  nvarchar(64) not null,
  	  Department int not null
    
)

create table Phones
(
	PhoneId int IDENTITY(1,1) primary key,
	PersonPhone int not null foreign key references Persons(PersonId),
	PhoneNumber varchar(64) not null
)
create table Emails
(
	EmailId int IDENTITY(1,1) primary key,
	PersonEmile int not null foreign key references Persons(PersonId),
	EmailAddress varchar(64) not null
)


insert into Persons values ( 'Lia', 'Ulukhanyan', 'Vruyri', 'Yerevan','a','b',22)
insert into Persons values ( 'Tanya', 'Azarova', 'Danilovna', 'Vanadzor','c','d',40)
insert into Persons values ( 'Eduard', 'Raskalov', 'Vladimirovich', 'Moscow','e','f',3)


insert into Phones values (3,'+34-782-689-4113')
insert into Phones values (2,'+63-507-787-0964')
insert into Phones values (1,'+62-463-222-3779')
insert into Phones values (2,'+886-921-941-9909')
insert into Phones values (1,'+52-129-377-0307')
insert into Phones values (3,'+380-837-181-9391')
insert into Phones values (1,'+998-719-929-5076')
insert into Phones values (2,'+31-675-209-1121')
insert into Phones values (3,'+63-684-315-1487')
insert into Phones values (1,'+7-147-531-2363')
insert into Phones values (1,'+86-205-398-5024')
insert into Phones values (2,'+46-348-194-9347')
insert into Phones values (3,'+504-741-897-9000')
insert into Phones values (3,'+47-244-127-8731')
insert into Phones values (1,'+57-890-741-6822')



insert into Emails values (2,'lcalcut0@blinklist.com')
insert into Emails values (3,'rbranthwaite1@newyorker.com')
insert into Emails values (3,'cbogies2@omniture.com')
insert into Emails values (1,'tpigdon3@chicagotribune.com')
insert into Emails values (3,'barrighini4@howstuffworks.com')
insert into Emails values (2,'gpethick5@about.com')
insert into Emails values (1,'bmetterick6@digg.com')
insert into Emails values (2,'pvongrollmann7@usa.gov')
insert into Emails values (3,'lmarusik8@blogspot.com')
insert into Emails values (3,'gharfleet9@posterous.com')
insert into Emails values (3,'gpervoea@technorati.com')
insert into Emails values (1,'rrainsdonb@twitpic.com')

