use TrailGrantAndRevoke


create table sampletable
(
    id int primary key,
    name varchar(100),
)
create user UserTrail for login UserTrail

--Grant 
grant select on sampletable to UserTrail


execute as user = 'UserTrail'

--permission accepted
select * from sampletable


--permission denied
insert into sampletable (id, name) values (1, 'ramu')

drop table sampletable

REVERT
--REVOKE
revoke select on sampletable from usertrail


--again testing
execute as user = 'UserTrail'

select * from sampletable