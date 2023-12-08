create database E21;

create table tb_servicos(
id int auto_increment primary key,
descricao varchar(40) not null,
contratanteNome varchar(40) not null,
data datetime not null,
dia varchar(20) not null,
hora varchar(20) not null,
valor decimal not null);