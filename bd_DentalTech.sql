create database bd_DentalTech;
use bd_DentalTech;

create table Paciente(
id_pac int primary key auto_increment not null,
cpf_pac varchar(15) not null,
status_pac varchar(15) not null,
rg_pac int not null,
expedidor_pac varchar(100) not null,
estadoCivil_pac varchar(100) not null,
genero_pac varchar(100) not null,
email_pac varchar(300) not null,
telefone_pac float not null,
dataDeNascimento_pac date not null,
cep_pac float not null,
cidade_pac varchar(300) not null,
bairro_pac varchar(300) not null,
rua_pac varchar(300) not null,
numero_pac int not null
);


create table Funcionario(
id_func int primary key auto_increment not null,
cpf_func varchar(15) not null,
status_func varchar(15) not null,
rg_func int not null,
expedidor_func varchar(100) not null,
estadoCivil_func varchar(100) not null,
genero_func varchar(100) not null,
cargo_func varchar(100) not null,
email_func varchar(300) not null,
telefone_func float not null,
dataDeNascimento_func date not null,
cep_func float not null,
cidade_func varchar(300) not null,
bairro_func varchar(300) not null,
rua_func varchar(300) not null,
numero_func int not null,
dataDeAdmissao_func date not null,
ctps_func varchar(15) not null,
cnh_func varchar(15) not null,
senha_func varchar(50) not null
);

create table Agendamento(
id_age int primary key auto_increment not null,
data_age date not null,
hora_age time not null,
id_pac_fk int,
id_func_fk int,
foreign key(id_pac_fk)references Paciente(id_pac),
foreign key(id_func_fk)references Funcionario(id_func)
);



create table Anamnese(
id_anam int primary key auto_increment not null,
data_anam date not null,
febre_anam bool not null,
tratamento_anam bool not null,
cicatrizacao_anam bool not null,
anestesia_anam bool not null,
drogas_anam bool not null,
diabetes_anam bool not null,
doencas_anam bool not null,
hipertensao_anam bool not null,
id_pac_fk int,
id_func_fk int,
foreign key(id_pac_fk)references Paciente (id_pac),
foreign key(id_func_fk)references Funcionario (id_func)
);



create table Consulta(
id_cons int primary key auto_increment not null,
data_cons date not null,
hora_cons time not null,
valor_cons double not null,
descricao_cons varchar(500) not null,
id_pac_fk int,
id_func_fk int,
id_anam_fk int,
foreign key(id_pac_fk)references Paciente (id_pac),
foreign key(id_func_fk)references Funcionario (id_func),
foreign key(id_anam_fk)references Anamnese (id_anam)
);



create table Orcamento(
id_orca int primary key auto_increment not null,
id_pac_fk int,
id_func_fk int,
foreign key(id_pac_fk)references Paciente (id_pac),
foreign key(id_func_fk)references Funcionario (id_func)
);


create table Fornecedor(
id_forn int primary key auto_increment not null,
razaosocial_forn varchar (200),
nomefantasial_forn varchar (100),
representante_forn varchar (100),
telefone_forn varchar (100)
);


create table Produto(
id_prod int primary key auto_increment not null,
nome_prod varchar(300) not null,
dataFabricacao_prod date not null,
dataValidade_prod date not null,
codigoBarras_prod int not null,
valor_prod float not null
);



create table Compra_Produto (
id_comp int not null primary key auto_increment,
data_comp date,
valor_total_comp double,
forma_pagamento_comp varchar (100),
id_func_fk int not null,
id_forn_fk int not null,
foreign key (id_func_fk) references Funcionario (id_func),
foreign key (id_forn_fk) references Fornecedor (id_forn)
);


create table Itens_Compra (
id_itc int not null primary key auto_increment,
quant_itc int not null,
valor_itc float not null,
id_prod_fk int not null,
id_comp_fk int not null,
foreign key (id_prod_fk) references Produto (id_prod),
foreign key (id_comp_fk) references Compra_Produto (id_comp)
);


create table Caixa (
id_cai int not null primary key auto_increment,
data_abertura_cai date not null,
data_fechamento_cai date,
saldo_inicial_cai double not null,
troco_cai double,
valor_creditos_cai double,
valor_debitos_cai double,
saldo_final_cai double,
status_cai varchar (100) not null
);

create table Servico(
id_serv int primary key auto_increment not null,
nome_serv varchar(200) not null,
descricao_serv varchar(500) not null,
id_func_fk int,
id_orca_fk int,
foreign key(id_func_fk)references Funcionario(id_func)
);

create table Venda (
id_vend int not null primary key auto_increment,
data_vend date,
valor_total_vend double not null,
desconto_vend double,
forma_recebimento_vend varchar (50),
parcelas_vend int,
id_func_fk int not null,
id_pac_fk int not null,
foreign key (id_func_fk) references Funcionario (id_func),
foreign key (id_pac_fk) references Paciente (id_pac)
);

create table Servico_Venda (
id_itv int not null primary key auto_increment,
quant_itv int not null,
id_serv_fk int not null,
id_vend_fk int not null,
id_orca_fk int not null,
foreign key (id_serv_fk) references Servico (id_serv),
foreign key (id_vend_fk) references Venda (id_vend),
foreign key (id_orca_fk) references Orcamento (id_orca)
);

create table Recebimentos (
id_rec int not null primary key auto_increment,
data_vencimento_rec date,
valor_rec double,
parcela_rec varchar(100),
status_rec varchar (100),
forma_recebimento_rec varchar (100),
data_recebimento_rec date,
id_func_fk int,
id_cai_fk int,
id_vend_fk int not null,
foreign key (id_func_fk) references Funcionario (id_func),
foreign key (id_cai_fk) references Caixa (id_cai),
foreign key (id_vend_fk) references Venda (id_vend)
);

create table Despesa(
id_desp int not null primary key auto_increment,
descricao_desp varchar (200),
valor_desp double,
numero_documento_desp int,
id_forn_fk int,
foreign key (id_forn_fk) references Fornecedor (id_forn)
);

create table Pagamentos (
id_pag int not null primary key auto_increment,
data_vencimento_pag date,
valor_pag float,
parcela_pag varchar (100),
status_pag varchar (100),
forma_pagamento_pag varchar (100),
data_pagamento_pag date,
id_func_fk int,
id_cai_fk int,
id_desp_fk int,
id_comp_fk int,
foreign key (id_func_fk) references Funcionario (id_func),
foreign key (id_cai_fk) references Caixa (id_cai),
foreign key (id_desp_fk) references Despesa (id_desp),
foreign key (id_comp_fk) references Compra_produto (id_comp)
);


#INSERTS
#Paciente
insert into Paciente values (null, '12345678901', 'Ativo', 1234567, 'SSP-SP', 'Solteiro', 'Masculino', 'joao.silva@gmail.com', 11987654321, '1990-05-15', 12345000, 'São Paulo', 'Centro', 'Rua A', 10);
insert into Paciente values (null, '98765432101', 'Ativo', 7654321, 'SSP-RJ', 'Casado', 'Feminino', 'maria.oliveira@gmail.com', 21965432109, '1985-10-22', 22041010, 'Rio de Janeiro', 'Copacabana', 'Avenida B', 200);
insert into Paciente values (null, '11122233344', 'Ativo', 5555555, 'SSP-MG', 'Viúvo', 'Masculino', 'carlos.mendes@gmail.com', 31999998888, '1970-03-30', 30130010, 'Belo Horizonte', 'Savassi', 'Rua C', 33);
insert into Paciente values (null, '22334455667', 'Ativo', 3344556, 'SSP-PR', 'Divorciado', 'Feminino', 'ana.pereira@gmail.com', 41999887766, '1988-04-11', 80020010, 'Curitiba', 'Batel', 'Rua D', 45);
insert into Paciente values (null, '99887766554', 'Ativo', 7654432, 'SSP-SP', 'Casado', 'Masculino', 'marcos.souza@gmail.com', 1122334455, '1992-08-19', 15000000, 'São Paulo', 'Liberdade', 'Rua E', 100);


#Funcionario
insert into Funcionario values (null, '12345678901', 'Ativo', 1234567, 'SSP-SP', 'Solteiro', 'Masculino', 'Dentista', 'eduardo.pereira@gmail.com', 11987654321, '1980-02-15', 12345000, 'São Paulo', 'Centro', 'Rua A', 10, '2010-05-20', '12345678901', '9876543210', 'senha123');
insert into Funcionario values (null, '98765432101', 'Ativo', 7654321, 'SSP-RJ', 'Casado', 'Feminino', 'Ortodontista', 'carolina.lima@gmail.com', 21965432109, '1985-07-22', 22041010, 'Rio de Janeiro', 'Copacabana', 'Avenida B', 200, '2015-10-12', '98765432101', '1234567890', 'senha456');
insert into Funcionario values (null, '11122233344', 'Inativo', 5555555, 'SSP-MG', 'Viúvo', 'Masculino', 'Recepcionista', 'roberto.mendes@gmail.com', 31999998888, '1970-01-30', 30130010, 'Belo Horizonte', 'Savassi', 'Rua C', 33, '2000-03-10', '11122233344', '0001112223', 'senha789');
insert into Funcionario values (null, '11223344556', 'Ativo', 6789012, 'SSP-SP', 'Casado', 'Masculino', 'Higienista', 'renato.garcia@gmail.com', 11999887766, '1982-09-30', 12345678, 'São Paulo', 'Zona Norte', 'Rua F', 55, '2018-08-15', '11223344556', '9876543211', 'senha1010');
insert into Funcionario values (null, '99887766553', 'Ativo', 5554432, 'SSP-PR', 'Solteiro', 'Feminino', 'Recepcionista', 'patricia.oliveira@gmail.com', 41999998888, '1995-12-25', 80015010, 'Curitiba', 'Centro', 'Avenida G', 80, '2020-03-05', '99887766553', '1122334455', 'senha2020');


#Agendamento
insert into Agendamento values (null, '2023-12-01', '09:00:00', 1, 1);
insert into Agendamento values (null, '2023-12-02', '10:30:00', 2, 2);
insert into Agendamento values (null, '2023-12-03', '14:00:00', 3, 1);
insert into Agendamento values (null, '2023-12-04', '11:00:00', 4, 3);
insert into Agendamento values (null, '2023-12-05', '15:30:00', 5, 2);


#Anamnese
insert into Anamnese values (null, '2023-10-01', TRUE, FALSE, FALSE, FALSE, FALSE, FALSE, TRUE, FALSE, 1, 1);
insert into Anamnese values (null, '2023-10-10', FALSE, TRUE, FALSE, TRUE, FALSE, FALSE, FALSE, TRUE, 2, 2);
insert into Anamnese values (null, '2023-10-15', TRUE, TRUE, TRUE, FALSE, TRUE, FALSE, TRUE, TRUE, 3, 1);
insert into Anamnese values (null, '2023-10-20', FALSE, FALSE, FALSE, FALSE, FALSE, TRUE, TRUE, FALSE, 4, 3);
insert into Anamnese values (null, '2023-10-25', TRUE, TRUE, FALSE, TRUE, FALSE, FALSE, FALSE, TRUE, 5, 2);


#Consulta
insert into Consulta values (null, '2024-11-01', '10:30:00', 200.00, 'Consulta de rotina para avaliação geral.', 1, 2, 1);
insert into Consulta values (null, '2024-11-02', '14:00:00', 300.00, 'Consulta odontológica para tratamento de cáries.', 2, 3, 2);
insert into Consulta values (null, '2024-11-03', '09:00:00', 250.00, 'Revisão ortodôntica e ajustes de aparelho.', 3, 1, 3);
insert into Consulta values (null, '2024-11-04', '13:30:00', 350.00, 'Exame clínico geral e revisão de anamnese.', 4, 2, 4);
insert into Consulta values (null, '2024-11-05', '11:00:00', 400.00, 'Tratamento periodontal e instrução de higiene oral.', 5, 3, 5);


#Orcamento
insert into Orcamento values (null, 1, 1);
insert into Orcamento values (null, 2, 2);
insert into Orcamento values (null, 3, 1);
insert into Orcamento values (null, 4, 3);
insert into Orcamento values (null, 5, 2);


#Fornecedor
insert into Fornecedor values (null, 'Fornecedor A Ltda', 'Fantasia A', 'João Silva', '11999999999');
insert into Fornecedor values (null, 'Fornecedor B Ltda', 'Fantasia B', 'Maria Oliveira', '21988888888');
insert into Fornecedor values (null, 'Fornecedor C Ltda', 'Fantasia C', 'Carlos Mendes', '31977777777');
insert into Fornecedor values (null, 'Fornecedor D Ltda', 'Fantasia D', 'Renato Souza', '41966666666');
insert into Fornecedor values (null, 'Fornecedor E Ltda', 'Fantasia E', 'Patricia Costa', '51955555555');


#Produto
insert into Produto values (null, 'Bisturi', '2023-01-15', '2025-01-15', '1234567890', 49.90);
insert into Produto values (null, 'Pinça clínica', '2023-06-10', '2024-06-10', '007654319', 29.99);
insert into Produto values (null,'Espelho clínico', '2022-12-05', '2023-12-05', '0178901234', 99.50);
insert into Produto values (null, 'Seringa', '2023-02-01', '2025-02-01', '1122334455', 10.99);
insert into Produto values (null, 'Luva cirúrgica', '2023-07-12', '2024-07-12', '1122334456', 12.00);

#Compra_Produto
select * from compra_produto;
insert into Compra_Produto values (null, '2023-12-01', 500.00, 'Cartão de Crédito', 1, 2);
insert into Compra_Produto values (null, '2023-12-05', 200.00, 'Dinheiro', 2, 3);
insert into Compra_Produto values (null, '2023-12-10', 290.00, 'Dinheiro', 3, 1);
insert into Compra_Produto values (null, '2023-11-25', 150.00, 'Boleto', 1, 2);
insert into Compra_Produto values (null, '2023-11-30', 400.00, 'Cartão de Crédito', 2, 3);

#Itens_Compra
insert into Itens_Compra values (null, 10, 50.00, 1, 1);
insert into Itens_Compra values (null, 5, 20.00, 2, 2);
insert into Itens_Compra values (null, 3, 30.00, 3, 3);
insert into Itens_Compra values (null, 7, 60.00, 1, 4);
insert into Itens_Compra values (null, 4, 25.00, 2, 5);

#Caixa
insert into Caixa values (null, '2023-12-01', '2023-12-05', 1000.00, 50.00, 200.00, 150.00, 1100.00, 'Fechado');
insert into Caixa values (null, '2023-12-02', '2023-12-06', 1500.00, 30.00, 300.00, 100.00, 1700.00, 'Fechado');
insert into Caixa values (null, '2023-12-03', null, 2000.00, 0.00, 400.00, 200.00, 2200.00, 'Aberto');
insert into Caixa values (null, '2023-12-04', '2023-12-07', 500.00, 20.00, 100.00, 50.00, 530.00, 'Fechado');
insert into Caixa values (null, '2023-12-05', null, 3000.00, 10.00, 500.00, 300.00, 3200.00, 'Aberto');

#Servico
insert into Servico values (null, 'Limpeza de Dente', 'Limpeza de dente para remoção de tártaro e placas bacterianas', 1, 1);
insert into Servico values (null, 'Restauração', 'Restauração odontológica para tratamento de cáries', 2, 2);
insert into Servico values (null, 'Ajuste de Aparelho', 'Ajuste de aparelho ortodôntico para alinhamento dentário', 3, 3);
insert into Servico values (null, 'Extração de Dente', 'Extração de dente com anestesia local', 1, 2);
insert into Servico values (null, 'Tratamento de Gengiva', 'Tratamento de gengiva para remoção de inflamação e infecção', 2, 1);

#Venda
insert into Venda values (null, '2023-12-01', 500.00, 50.00, 'Cartão de Crédito', 3, 1, 1);
insert into Venda values (null, '2023-12-02', 600.00, 60.00, 'Dinheiro', 2, 2, 2);
insert into Venda values (null, '2023-12-03', 400.00, 40.00, 'Boleto', 1, 3, 3);
insert into Venda values (null, '2023-12-04', 800.00, 80.00, 'Cartão de Débito', 5, 1, 2);
insert into Venda values (null, '2023-12-05', 700.00, 70.00, 'Pix', 1, 2, 1);

#Servico_Venda
insert into Servico_Venda values (null, 1, 1, 1, 1);
insert into Servico_Venda values (null, 2, 2, 2, 2);
insert into Servico_Venda values (null, 3, 3, 3, 3);
insert into Servico_Venda values (null, 1, 1, 4, 4);
insert into Servico_Venda values (null, 2, 2, 5, 5);

#Recebimentos
insert into Recebimentos values (null, '2024-12-10', 150.00, '1ª parcela', 'Pendente', 'Dinheiro', null, 1, 1, 1);
insert into Recebimentos values (null, '2024-12-20', 100.00, '2ª parcela', 'Pago', 'Cartão de Crédito', '2024-12-19', 2, 2, 2);
insert into Recebimentos values (null, '2024-12-25', 200.00, '1ª parcela', 'Pendente', 'Cheque', null, 3, 3, 3);
insert into Recebimentos values (null, '2024-12-30', 50.00, '1ª parcela', 'Pago', 'Transferência', '2024-12-28', 1, 3, 4);
insert into Recebimentos values (null, '2025-01-10', 120.00, '1ª parcela', 'Pendente', 'Dinheiro', null, 2, 1, 5);

#Despesa
insert into Despesa values (null, 'Compra de materiais de escritório', 150.00, 123456, 1);
insert into Despesa values (null, 'Pagamento de fornecedores de equipamentos', 300.00, 654321, 2);
insert into Despesa values (null, 'Serviços de limpeza', 200.00, 789012, 3);
insert into Despesa values (null, 'Consultoria jurídica', 500.00, 345678, 1);
insert into Despesa values (null, 'Manutenção de equipamentos', 350.00, 112233, 2);

#Pagamentos
insert into Pagamentos values (null, '2023-12-15', 150.00, '1ª parcela', 'Pago', 'Cartão de Crédito', '2023-12-10', 1, 1, 1, 1);
insert into Pagamentos values (null, '2023-12-20', 200.00, '2ª parcela', 'Pendente', 'Dinheiro', null, 2, 2, 2, 2);
insert into Pagamentos values (null, '2023-12-25', 300.00, '1ª parcela', 'Pago', 'Boleto', '2023-12-23', 3, 3, 3, 3);
insert into Pagamentos values (null, '2024-01-10', 400.00, '1ª parcela', 'Pendente', 'Transferência', null, 2, 1, 4, 4);
insert into Pagamentos values (null, '2024-01-15', 500.00, '1ª parcela', 'Pago', 'Pix', '2024-01-12', 1, 2, 5, 5);