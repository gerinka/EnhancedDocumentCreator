insert into aspnetuserroles(UserId,RoleId)
SELECT user.id, role.id 
FROM urm.aspnetusers user, urm.aspnetroles role
Where user.email = 'dodstes@gmail.com'
and role.Name = 'Admin';