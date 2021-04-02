create procedure sp_GetAllStudent 
as 
begin 
	select * from dbo.StudentReg
end

ALTER procedure [dbo].[sp_GetAllStudent]
@id;
as
begin
	select * from dbo.StudentReg
	where S_Id = @id
end