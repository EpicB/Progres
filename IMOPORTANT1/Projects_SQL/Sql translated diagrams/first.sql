/*a one to one relations ship is represented by putting all the table attributes that are connected in the same data base */


CREATE TABLE [IF NOT EXISTS] new (
   unames varchar(16) Primary key,
    age integer CHECK(age > 14),
   first varchar(64) NOT NULL,
   last varchar (64) NOT NULL
);


CREATE TABLE uuid_test (
user_uuid UUID primary key,
age integer CHECK(age > 14),
firsto varchar(64) NOT NULL,
lasto varchar (64) NOT NULL 
);


insert into uuid_test (user_uuid,age,firsto,lasto) VALUES (uuid_generate_v4(),15,'ahmad','ayyad');


CREATE EXTENSION IF NOT EXISTS "uuid-ossp";


CREATE FUNCTION sales_tax(subtotal real) RETURNS real AS $$
BEGIN
    RETURN subtotal * 0.06;
END;
$$ LANGUAGE plpgsql;



CREATE FUNCTION sales_tax(real) RETURNS real AS $$
DECLARE
    subtotal ALIAS FOR $1;
BEGIN
    RETURN subtotal * 0.06;
END;
$$ LANGUAGE plpgsql;





CREATE TABLE student(
    userid uuid primary key,
    uname citext not null,
    age integer not null
);


CREATE TABLE courses(
    coursesid bigserial primary key, 
    course_time integer,
    creation_time integer,
    userid uuid references student(userid)
);

create TABLE students_marks (
    marksid bigserial primary key,
    marks integer, 
    userid uuid references student(userid),
    coursesid integer references courses(coursesid)
);





---------------

create or replace function find_first(thename text) returns text as $$
declare 
useridvar student.userid%type;
unamevar student.uname%type;
agevar student.age%type;
begin
select userid,uname,age into useridvar,unamevar,agevar from student where uname = thename;
return 'the id is % the username is % the age is %',useridvar,unamevar,agevar;
end;
$$ language plpgsql



---------------

create or replace function getusernamess(thisname text) returns setof student as $$

BEGIN 
return query select * from student where uname = thisname;

END;


$$ language plpgsql

---------------

create or replace procedure insertshortcut(unamevar student.uname%type,agevar student.age%type )

language plpgsql
as $$
begin
insert into student(userid,uname,age)values(uuid_generate_v4(),unamevar,agevar);
end; $$



--------------- 

create or replace function get_name (unamevar student.uname%type ) 
returns table (
	unames student.uname%type,
	ages student.age%type
) 
language plpgsql
as $$
declare 
    var_r record;
begin
	for var_r in( select uname,age from student  where uname = unamevar) 
	loop  unames := upper(var_r.uname) ; 
		ages := var_r.age;
           return next;
	end loop;
end; $$ 


select getusernamess('ahmad');

select get_name('ahmad');

call insertshortcut('mosa',17); 

select find_first('ahmad');






create or replace function getusernames_v2(thisname citext) 
returns table(_userid uuid,_uname citext, _age integer DEFAULT 0::integer ) --- you cant assign a defualt value to the integer
language plpgsql
as $$
begin
return query select userid , uname from student where uname = thisname ;
end;
$$



CREATE OR REPLACE PROCEDURE public.insertshortcut(
	unamevar citext,
	agevar integer DEFAULT NULL::integer,
	INOUT _userid uuid DEFAULT NULL::uuid)
LANGUAGE 'plpgsql'
AS $BODY$
begin
insert into student(uname,age)values(unamevar,agevar)
returning userid into _userid;
end;
$BODY$;




--------------------------------------------------------


CREATE TABLE users(
    userid uuid primary key,
    user_type integer not null, --- 1 admin --- 2 teacher --- 3 student
    username citext not null,
    check(user_type > 0 and user_type < 4 )
);



create table courses(
    courseid bigserial primary key,
    creation_time integer not null ,  
    course_time integer not null,
    userid uuid references users((select userid from user where type = 3)) on delete set null
    
    
);

create table students_marks(
    mark_value integer not null check (mark_value > 0),
    courseid bigserial references courses(courseid),
    userid uuid references users(userid) 
)

create function or replace get_marks_from_type( _userid uuid,_type integer default 3::integer ) returns table (markid bigserial , mark_value integer ,courseid bigserial , userid uuid, user_type integer)
language plpgsql
as $$
begin

return query select * from students_marks where user_type = _type and userid = _userid;
 
end;
$$




create function or replace get_product(_orderid uuid,_offset integer ,_limit integer )returns table (orderid uuid , _username citext)
language plpgsql 

as $$
begin
return query select * from table_name OFFSET _offset limit _limit;





select 















create or replace function get_user_where_enrolled(thisuuid uuid) 
returns table (_userid uuid,user_type integer,username citext,courseid bigint,creation_time integer,course_time integer)
language plpgsql
as $$
begin
return query select users.userid,users.user_type,users.username,courses.courseid,courses.creation_time,courses.course_time
from users join courses on users.userid = courses.userid where courses.userid = thisuuid;
end;
$$

 select * from get_user_where_enrolled('7c20d46b-dfc6-4972-86e2-0cb83873126f');



 select users.userid,users.user_type,users.username,courses.courseid,courses.creation_time,courses.course_time,students_marks.mark_value 
 from users join courses on users.userid = courses.userid join students_marks on users.userid = students_marks.userid  where students_marks.userid = '7c20d46b-dfc6-4972-86e2-0cb83873126f';




insert into students_marks (mark_value,courseid,userid)values(20,3,'7c20d46b-dfc6-4972-86e2-0cb83873126f'); 

insert into students_marks (mark_value,courseid,userid)values(16,3,'7c20d46b-dfc6-4972-86e2-0cb83873126f'); 