CREATE PROCEDURE GetUserByPhoneNumber
@Number nvarchar(15)
as
begin

select top 1 u.* from Users as u
join UserPhones up on u.Id= up.User_Id
join Phones p on p.Id = up.Phone_Id

end