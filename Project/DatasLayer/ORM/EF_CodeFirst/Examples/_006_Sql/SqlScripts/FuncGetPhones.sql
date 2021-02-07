Create function GetPhones
(
 @Id int
)
returns @returnTable Table
(
	Id int,
	Number nvarchar(50)
) 
as
begin

insert @returnTable select p.Id, p.Number from Phones as p where p.Id=@Id

return
end