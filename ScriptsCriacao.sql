
CREATE DATABASE programacao_do_zero;

USE programacao_do_zero;

create table usuario(
id INT NOT NULL AUTO_INCREMENT ,
nome varchar(50)not null,
sobrenome varchar(150)not null,
telefone VARCHAR(15)  not null,
email varchar(100) not null unique,
genero varchar(50) not null,
senha VARCHAR(250) not null,
primary key(id)

);



CREATE TABLE endereco (
    id INT NOT NULL AUTO_INCREMENT,
    rua VARCHAR(250) NOT NULL,
    numero VARCHAR(250) NOT NULL,
    bairro VARCHAR(150) NOT NULL,
    cidade VARCHAR(250) NOT NULL,
    complemento VARCHAR(250) NOT NULL,
    cep VARCHAR(9) NOT NULL,
    estado VARCHAR(2) NOT NULL,
    PRIMARY KEY (id)
);

alter table endereco add usuario_id int not null;

 add constraint fk_usuario foreign key  (usuario_id) references usuario(id);

 ALTER TABLE usuario
MODIFY telefone VARCHAR(20);
--------insert into usuario
(nome,sobrenome,telefone,email,genero,senha) 
values
('Eliel','Fernando','(27)99581-4645','elielfernando851@gmail.com','masculino','123abc');

select*FROM usuario;