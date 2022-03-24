CREATE DATABASE oneUp_Db;

USE oneUp_Db;

CREATE TABLE representantes(
idRepresentante int primary key identity,
nome varchar(150),
email varchar(150),
senha varchar(50),
marca varchar(100),
produto varchar(100),
contato varchar(20),
);

GO

CREATE TABLE varejista(
idVarejista int primary key identity,
nome varchar(150),
email varchar(150),
senha varchar(50),
);

GO

CREATE TABLE arquivo(
idArquivo int primary key identity,
caminhoArquivo varchar(200));

GO

CREATE TABLE agendamento(
idAgendamento int primary key identity,
idRepresentante int foreign key references representantes(idRepresentante),
idVarejista int foreign key references varejista(idVarejista),
idArquivo int foreign key references arquivo(idArquivo),
[data] date,
hora time,
descricao varchar(250),
link varchar(200),
marca varchar(100));

GO

CREATE TABLE presenca(
idPresenca int primary key identity,
idAgendamento int foreign key references agendamento(idAgendamento),
idRepresentante int foreign key references representantes(idRepresentante),
idVarejista int foreign key references varejista(idVarejista),
situacao varchar(50));

ALTER TABLE varejista
ADD permissao int

ALTER TABLE representantes
ADD permissao int

select * from varejista
