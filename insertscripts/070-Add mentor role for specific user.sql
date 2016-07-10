insert into aspnetuserroles(UserId,RoleId)
SELECT user.id, role.id 
FROM urm.aspnetusers user, urm.aspnetroles role
Where user.email = 'gergana.e.georgieva@gmail.com' 
and role.Name = 'Mentor';