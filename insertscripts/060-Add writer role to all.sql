insert into aspnetuserroles(UserId,RoleId)
SELECT user.id, role.id 
FROM urm.aspnetusers user, urm.aspnetroles role
WHERE role.Name = 'Writer';