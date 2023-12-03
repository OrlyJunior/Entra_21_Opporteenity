create database projeto;

create table tb_produtos(
Id int primary key not null auto_increment,
Nome varchar(40) not null,
ValorUnitario decimal(5,2) not null,
Estoque int not null,
CategoriaId int not null, 
foreign key(CategoriaId) references tb_categorias(IdCategoria));

create table tb_categorias(
IdCategoria int not null primary key auto_increment,
NomeCategoria varchar(30) not null);