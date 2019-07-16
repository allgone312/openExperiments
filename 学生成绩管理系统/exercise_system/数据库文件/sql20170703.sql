create database DB_Student
use DB_Student

/*�Ա��*/
--create table T_Sex(sid int primary key not null,
--                   sex nchar(2) not null
--                   )
--insert into T_Sex values(0,'δ֪')
--insert into T_Sex values(1,'��')
--insert into T_Sex values(2,'Ů')                 
--select * from T_Sex
--drop table T_Sex 

/*ѧԺ��*/
create table T_Major(mid int primary key identity(1,1),
                     major nvarchar(20) not null
                     )
insert into T_Major values('��ѧԺ')
insert into T_Major values('��繤��ѧԺ') 
insert into T_Major values('���繤��ѧԺ')              
insert into T_Major values('������Ϣ����ѧԺ')              
insert into T_Major values('�������ѧ����ѧԺ')              
insert into T_Major values('���Ͽ�ѧ�빤��ѧԺ')              
insert into T_Major values('��ѧ�뻷������ѧԺ')              
insert into T_Major values('������ѧ����ѧԺ')           
select * from T_Major

/*רҵ��*/
create table T_Major_list(mlid int primary key not null,
                          mid int not null,
                          majorin nvarchar(20) not null,
                          foreign key(mid) references T_Major(mid)
                          )

insert into T_Major_list values(11,1,'���ӿ�ѧ�뼼��')
insert into T_Major_list values(12,1,'�����Ϣ��ѧ�빤��')
insert into T_Major_list values(21,2,'��ؼ���������')
insert into T_Major_list values(22,2,'�����Ϣ��ѧ�빤�̣���磩')
insert into T_Major_list values(31,3,'����װ������ƹ���')
insert into T_Major_list values(32,3,'��е���ӹ���')
insert into T_Major_list values(41,4,'�������̼����Զ���')
insert into T_Major_list values(42,4,'������Ϣ����')
insert into T_Major_list values(51,5,'�������ѧ�뼼��')
insert into T_Major_list values(52,5,'�������')
insert into T_Major_list values(53,5,'���繤��')
insert into T_Major_list values(61,6,'���ϻ�ѧ')
insert into T_Major_list values(62,6,'��������')
insert into T_Major_list values(71,7,'��ѧ�����빤��')
insert into T_Major_list values(72,7,'��������')
insert into T_Major_list values(81,8,'���﹤��')
insert into T_Major_list values(82,8,'���＼��')                         
select * from T_Major_list

/*�༶��*/
create table T_Class(classid bigint primary key not null,
                     mlid int not null,
                     foreign key(mlid) references T_Major_list(mlid)
                     )
--drop table T_Class
alter table T_Class add cyear int not null
alter table T_Class add pnum int default 0 not null
exec sp_rename 'T_Class.year','cyear','column';
select * from T_Class                             
                     
create table T_Student(mainid bigint primary key identity(1000000,1),
                       idnumber bigint not null,
                       name nvarchar(20) not null,
                       time datetime not null,
                       sex nchar(2) not null,
                       birthdate datetime not null,
                       nation nchar(5) not null,
                       birthplace nvarchar(50) not null,
                       mlid int not null,
                       classid bigint not null,
                       studid bigint not null,
                       address nvarchar(200),
                       phone bigint,
                       foreign key(mlid) references T_Major_list(mlid),
                       foreign key(classid) references T_Class(classid)
                       )
create trigger trigger_insert_stu
on T_Student
after insert
as
  begin
    update T_Class set pnum=pnum+1 where classid=(select classid from inserted)
  end
  
create trigger trigger_delete_stu
on T_Student
after delete
as
  begin
    update T_Class set pnum=pnum-1 where classid=(select classid from deleted)
  end
    

insert into T_Student(idnumber,name,time,sex,birthdate,nation,birthplace,mlid,classid,studid)
                      values(111111111111111111,'С��','2015-9-5','��','1997-8-8','����',
                      '���� ����',52,201505211,20150521101)                                                             
select * from T_Student

select top 1 classid from T_Class
              where mlid=52 and cyear=2015
              order by pnum
              
select * from T_Class where mlid=52 and cyear=2015

update T_Class set pnum=1 where classid=201505213

select * from T_Class

select studid as 'ѧ��',name as '����',classid as '�༶',T_Student.mlid as '��ѡרҵ',idnumber as '���֤��',mainid as '���'
from T_Student left join T_Major_list
on T_Student.mlid=T_Major_list.mlid
where majorin='�������'
order by studid
                      
select * from T_Student where mainid=1000006
select * from T_Major_list


create table T_role(rid int primary key identity(1000,1),
                    username nvarchar(20) not null,
                    password nvarchar(20) not null,
                    )
select * from T_role
insert into T_role values('admin','admin')      