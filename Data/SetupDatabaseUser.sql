--create user imafanweb with password = 'testpassword2018'
--go

use master
go

drop login imafanweb
go

create login imafanweb with password = 'testpassword2018'
, DEFAULT_DATABASE=[Imafan]
go

use Imafan
go

drop user imafanweb
create user imafanweb from login imafanweb

exec sp_addrolemember 'aspnet_Membership_FullAccess', 'imafanweb'
exec sp_addrolemember 'aspnet_Personalization_FullAccess', 'imafanweb'
exec sp_addrolemember 'aspnet_Profile_FullAccess', 'imafanweb'
exec sp_addrolemember 'aspnet_Roles_FullAccess', 'imafanweb'
exec sp_addrolemember 'aspnet_WebEvent_FullAccess', 'imafanweb'

exec sp_addrolemember 'db_accessadmin', 'imafanweb'
exec sp_addrolemember 'db_ddladmin', 'imafanweb'
exec sp_addrolemember 'db_datareader', 'imafanweb'
exec sp_addrolemember 'db_datawriter', 'imafanweb'
exec sp_addrolemember 'db_owner', 'imafanweb'