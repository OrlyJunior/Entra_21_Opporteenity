create database E21;

create table tb_curriculos(
id int auto_increment primary key,
nome varchar(40) not null,
telefone varchar(40) not null,
email varchar(40) not null,
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
valor decimal not null,
empresaId int not null);

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

CREATE TABLE `tb_curriculos` (
  `id` int NOT NULL AUTO_INCREMENT,
  `nome` varchar(40) NOT NULL,
  `telefone` varchar(40) NOT NULL,
  `email` varchar(40) NOT NULL,
  `objetivo` varchar(400) NOT NULL,
  `rua` varchar(50) NOT NULL,
  `numero` int NOT NULL,
  `bairro` varchar(40) NOT NULL,
  `cidade` varchar(40) NOT NULL,
  `estado` varchar(40) NOT NULL,
  `escola` varchar(45) NOT NULL,
  `escolaCidade` varchar(45) NOT NULL,
  `situacao` varchar(45) NOT NULL,
  `ensino` varchar(45) NOT NULL,
  `dataInicio` varchar(45) NOT NULL,
  `idioma1` varchar(45) NOT NULL,
  `idioma1nivel` varchar(45) NOT NULL,
  `idioma1valor` int NOT NULL,
  `idioma2` varchar(45) DEFAULT NULL,
  `idioma2nivel` varchar(45) DEFAULT NULL,
  `idioma2valor` int DEFAULT NULL,
  `idioma3` varchar(45) DEFAULT NULL,
  `idioma3nivel` varchar(45) DEFAULT NULL,
  `idioma3valor` int DEFAULT NULL,
  `extraC1` varchar(45) DEFAULT NULL,
  `extraC2` varchar(45) DEFAULT NULL,
  `extraC3` varchar(45) DEFAULT NULL,
  `extraC4` varchar(45) DEFAULT NULL,
  `cursos` varchar(450) DEFAULT NULL,
  `jovemId` int NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

drop table tb_curriculos;

truncate table tb_curriculosenviados;

select * from tb_empresas;

select * from tb_curriculosEnviados;

select * from tb_curriculos;