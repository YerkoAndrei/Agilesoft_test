-- MySQL
create database agilesoft_test

create table user(
id int auto_increment primary key, 
username varchar(30) not null, 
pass varchar(300)not null,
name varchar(30) not null
);
create table task(
id int auto_increment primary key,
name varchar(30) not null,
completed boolean not null,
id_user int not null,
foreign key (id_user) references user(id)
);