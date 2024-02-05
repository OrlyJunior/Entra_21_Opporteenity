create database E21;

create table tb_curriculos(
id int auto_increment primary key,
nome varchar(40) not null,
telefone varchar(40) not null,
email varchar(40) not null,
redesocial varchar(40) not null,
objetivo varchar(400) not null,
rua varchar(50) not null,
numero int not null,
bairro varchar(40) not null,
cidade varchar(40) not null,
estado varchar(40) not null,
escola varchar(45) not null,
idiomas varchar(45) not null,
cursos varchar(450) ,
experiencia varchar(8000) not null,
jovemId int not null);

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
empresaId int not null,
horaInicio varchar(30) not null,
horaTermino varchar(30) not null,
estado varchar(40) not null,
cidade varchar(40) not null,
numero int not null,
bairro varchar(40) not null,
rua varchar(40) not null,
salario decimal not null,
diasTrabalhados int not null);

create table tb_cadastros(
id int auto_increment primary key,
nome varchar(100) not null,
email varchar(50) not null,
fone varchar(15) not null,
nascimento datetime not null,
rua varchar(50) not null,
numero int not null,
bairro varchar(40) not null,
cidade varchar(40) not null,
estado varchar(40) not null,
responsavel varchar(100) not null,
foneResponsavel varchar(15) not null,
senha varchar(50) not null);

create table tb_empresas(
id int auto_increment primary key,
nome varchar(100) not null,
email varchar(50) not null,
fone varchar(15) not null,
rua varchar(50) not null,
numero int not null,
bairro varchar(40) not null,
cidade varchar(40) not null,
estado varchar(40) not null,
cnpj varchar(20) not null,
senha varchar(50) not null);

create table tb_favoritos(
id int auto_increment primary key,
idUser int not null,
idVaga int not null);

create table tb_curriculosEnviados(
id int auto_increment primary key,
idCurriculo int not null,
idEmprego int not null);

truncate table tb_curriculosenviados;

select * from tb_empresas;

select * from tb_curriculosEnviados;

select * from tb_curriculos;