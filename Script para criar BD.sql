create database E21;

create table tb_servicos(
id int auto_increment primary key,
descricao varchar(40) not null,
contratanteNome varchar(40) not null,
estado varchar(40) not null,
cidade varchar(40) not null,
numero int not null,
bairro varchar(40) not null,
rua varchar(40) not null,
data datetime not null,
dia varchar(20) not null,
hora varchar(20) not null,
valor decimal not null);

create table tb_empregos(
id int auto_increment primary key,
descricao varchar(40) not null,
empresaNome varchar(40) not null,
horaInicio varchar(30) not null,
horaTermino varchar(30) not null,
estado varchar(40) not null,
cidade varchar(40) not null,
numero int not null,
bairro varchar(40) not null,
rua varchar(40) not null,
salario decimal not null,
diasTrabalhados int not null);