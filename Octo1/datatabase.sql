create database dbDistribuidora;
use  dbDistribuidora;

create table tbCliente(
  codigo int identity  PRIMARY KEY NOT NULL,
  nome varchar(80) NOT NULL,
  tipo bit NOT NULL,
  cpf_cnpj varchar(14) NOT NULL,
  rg_ie varchar(14) NOT NULL,
  email varchar(80) NOT NULL,
  data_nasc_fund date,
  data_cadastro date
)

create table tbTelefone(
codigo int identity NOT NULL,
codPessoa int NOT NULL,
tipo tinyint NOT NULL,
ddd varchar(2) NOT NULL,
numero varchar(11) NOT NULL,
observacoes varchar(50),
 PRIMARY KEY (codigo,codPessoa),
 FOREIGN KEY (codPessoa) REFERENCES tbCliente(codigo)
)


create table tbEndereco(
codigo int  identity NOT NULL,
codPessoa int NOT NULL,
tipo tinyint NOT NULL,
logradouro varchar(80) NOT NULL,
numero varchar(6) NOT NULL,
complemento varchar(60),
bairro varchar(60) NOT NULL,
cidade varchar(50) NOT NULL,
uf varchar(2) NOT NULL,
cep varchar(8) NOT NULL
 PRIMARY KEY (codigo,codPessoa),
 FOREIGN KEY (codPessoa) REFERENCES tbCliente(codigo)
)


DECLARE @count INT;
DECLARE @cliente INT;
SET @count = 1;
    
WHILE @count<= 100
BEGIN
   
   INSERT INTO tbCliente Values ('Mario ' + CAST(@count as varchar(3)), 'true', '43102948593', '37908772','mario@hotmail.com', null,'2022-03-02')
  SET @cliente =  (select max(codigo) from tbCliente);
   INSERT INTO tbEndereco Values ( @cliente, 1, 'Rua' + CAST(@count as varchar(3)), 22, '','marilu','Mirassol','SP','15130000')
   INSERT INTO tbTelefone Values (@cliente, 1, '17','33334444','insert')

   SET @count = @count + 1;
END;