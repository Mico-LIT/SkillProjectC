CREATE TABLE STUDENT(
StudentID int identity(1,1) primary key NOT null ,
Surname varchar(100) NOT null,
[Name] varchar(100) NOT null,
Stipend int ,
Kurs tinyint,
CityID int references CITY(CityID) not null,
BirthDay date,
UnivID int NOT NULL REFERENCES University(UnivID)

)

create table LECTORER(
LectorerID int identity(1,1) primary key not null ,
Surname varchar(100),
Name varchar(100),
CityID int references CITY(CityID) not null,
UniverID int references University(UnivID)
)

create table [SUBJECT](
[SubjectID] int identity(1,1) primary key not null,
SubjName varchar(100),
Hous int,
Semestr int
)

create table UNIVERSITY(
UnivID int identity(1,1) primary key not null,
Name varchar(100) ,
Rating smallint not null,
CityID int references CITY(CityID) not null
)

create table EXAM_MARKS(
ExamID int identity(1,1) primary key not null,
StudentID int references STUDENT(StudentID) not null,
SubID int references SUBJECT(SUBJECTID) not null,
Mark tinyint null,
Date date null
)

create table SUBJLECT(
LectorID int references LECTORER(LectorerID) not null,
SubjectID int references SUBJECT(SubjectID) not null
)

create table CITY(
CityID int identity(1,1) primary key not null,
Name varchar(100) not null
)
