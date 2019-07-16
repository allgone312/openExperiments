create database DB_Student
use DB_Student

/*性别表*/
--create table T_Sex(sid int primary key not null,
--                   sex nchar(2) not null
--                   )
--insert into T_Sex values(0,'未知')
--insert into T_Sex values(1,'男')
--insert into T_Sex values(2,'女')                 
--select * from T_Sex
--drop table T_Sex 

/*学院表*/
create table T_Major(mid int primary key identity(1,1),
                     major nvarchar(20) not null
                     )
insert into T_Major values('理学院')
insert into T_Major values('光电工程学院') 
insert into T_Major values('机电工程学院')              
insert into T_Major values('电子信息工程学院')              
insert into T_Major values('计算机科学技术学院')              
insert into T_Major values('材料科学与工程学院')              
insert into T_Major values('化学与环境工程学院')              
insert into T_Major values('生命科学技术学院')           
select * from T_Major

/*专业表*/
create table T_Major_list(mlid int primary key not null,
                          mid int not null,
                          majorin nvarchar(20) not null,
                          foreign key(mid) references T_Major(mid)
                          )

insert into T_Major_list values(11,1,'电子科学与技术')
insert into T_Major_list values(12,1,'光电信息科学与工程')
insert into T_Major_list values(21,2,'测控技术与仪器')
insert into T_Major_list values(22,2,'光电信息科学与工程（光电）')
insert into T_Major_list values(31,3,'工程装备与控制工程')
insert into T_Major_list values(32,3,'机械电子工程')
insert into T_Major_list values(41,4,'电气工程及其自动化')
insert into T_Major_list values(42,4,'电子信息工程')
insert into T_Major_list values(51,5,'计算机科学与技术')
insert into T_Major_list values(52,5,'软件工程')
insert into T_Major_list values(53,5,'网络工程')
insert into T_Major_list values(61,6,'材料化学')
insert into T_Major_list values(62,6,'材料物理')
insert into T_Major_list values(71,7,'化学工程与工艺')
insert into T_Major_list values(72,7,'环境工程')
insert into T_Major_list values(81,8,'生物工程')
insert into T_Major_list values(82,8,'生物技术')                         
select * from T_Major_list

/*班级表*/
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
                      values(111111111111111111,'小明','2015-9-5','男','1997-8-8','汉族',
                      '吉林 长春',52,201505211,20150521101)                                                             
select * from T_Student

select top 1 classid from T_Class
              where mlid=52 and cyear=2015
              order by pnum
              
select * from T_Class where mlid=52 and cyear=2015

update T_Class set pnum=1 where classid=201505213

select * from T_Class

select studid as '学号',name as '姓名',classid as '班级',T_Student.mlid as '所选专业',idnumber as '身份证号',mainid as '编号'
from T_Student left join T_Major_list
on T_Student.mlid=T_Major_list.mlid
where majorin='软件工程'
order by studid
                      
select * from T_Student where mainid=1000006
select * from T_Major_list


create table T_role(rid int primary key identity(1000,1),
                    username nvarchar(20) not null,
                    password nvarchar(20) not null,
                    )
select * from T_role
insert into T_role values('admin','admin')      