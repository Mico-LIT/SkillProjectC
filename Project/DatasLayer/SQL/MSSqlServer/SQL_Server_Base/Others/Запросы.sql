use[HomeDB]

begin --SELECT

--1
select * from [SUBJECT]

select * from EXAM_MARKS em where em.SubID=12 

select st.Kurs,st.Surname,st.Name,st.Stipend from STUDENT st

select sub.SubjName, sub.Hous from [SUBJECT] sub where sub.Semestr=4

select distinct ex.Mark from EXAM_MARKS ex

select st.Name from STUDENT st where st.Kurs > 2

select st.Name, st.Kurs, st.Surname from STUDENT st where st.Stipend > 140

Select * from [SUBJECT] s where s.Hous > 30

select * from STUDENT st 
inner join CITY c on c.CityID= st.CityID
where c.Name='Воронеж' and st.Stipend>100


-- Ответы на запросы 
SELECT * FROM STUDENT WHERE (STIPEND < 100 OR NOT (BIRTHDAY >= '10/03/1980' AND STODENT_ID > 1003));  

SELECT * FROM STUDENT WHERE NOT ((BIRTHDAY = '10/03/1980' OR STIPEND > 100) AND STUDENT_ID >= 1003);
--

-- 2


select em.Mark,em.[Date] from EXAM_MARKS em 
where em.Date between '19990101' and '19990115'

select * from SUBJECT s where s.SubjectID in(12,32)

select * from SUBJECT s where s.SubjName like('И%')

select * from STUDENT s 
where s.Surname like('И%') or s.Surname  like('f')

select * from EXAM_MARKS ex where ex.Mark is not null

--3

select concat(st.StudentID,';') + 
	   concat(st.BirthDay,';')  +
	   concat(st.CityID,';') +
	   concat(st.Kurs,';') +
	   concat(UPPER(st.Name),';') + 
	   concat(st.Stipend,';')+
	   concat(UPPER( st.Surname),';')+
	   concat(st.UnivID,';')
 from STUDENT st



end
