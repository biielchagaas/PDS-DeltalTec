create database bd_DentalTech;
use bd_DentalTech;

create table Paciente(
id_pac int primary key auto_increment not null,
nome_pac varchar(300),
cpf_pac varchar(15),
status_pac varchar(15),
rg_pac varchar(15),
expedidor_pac varchar(100),
estadoCivil_pac varchar(100),
genero_pac varchar(100),
email_pac varchar(300),
telefone_pac varchar(100),
dataDeNascimento_pac date,
cep_pac varchar(15),
cidade_pac varchar(300),
bairro_pac varchar(300),
rua_pac varchar(300),
numero_pac varchar(15)
);

create table Funcionario(
id_func int primary key auto_increment,
nome_func varchar(300),
cpf_func varchar(15),
status_func varchar(15),
rg_func varchar(15),
expedidor_func varchar(100),
estadoCivil_func varchar(100),
genero_func varchar(100),
cargo_func varchar(100),
email_func varchar(300),
telefone_func varchar(300),
dataDeNascimento_func date,
cep_func varchar(15),
cidade_func varchar(300),
bairro_func varchar(300),
rua_func varchar(300),
numero_func int,
dataDeAdmissao_func date,
ctps_func varchar(15),
senha_func varchar(50)
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
paciente_cons varchar(300),
funcionario_cons varchar(300),
id_pac_fk int,
id_func_fk int,
id_anam_fk int,
foreign key(id_pac_fk)references Paciente (id_pac),
foreign key(id_func_fk)references Funcionario (id_func),
foreign key(id_anam_fk)references Anamnese (id_anam)
);

create table Orcamento(
id_orca int primary key auto_increment not null,
valor_orca double,
paciente_orca varchar(300),
funcionario_orca varchar(300),
descricao_orca varchar(300),
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
codigoBarras_prod varchar (100) not null,
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
valor_serv double,
descricao_serv varchar(500) not null,
funcionario_serv varchar (300),
id_func_fk int,
foreign key (id_func_fk) references Funcionario(id_func)
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



INSERT INTO Paciente (nome_pac, cpf_pac, status_pac, rg_pac, expedidor_pac, estadoCivil_pac, genero_pac, email_pac, telefone_pac, dataDeNascimento_pac, cep_pac, cidade_pac, bairro_pac, rua_pac, numero_pac)
VALUES 
('João Silva', '123.456.789-00', 'Ativo', 'MG-123456', 'SSP-MG', 'Solteiro', 'Masculino', 'joao@email.com', '31999999999', '1990-05-10', '30110-040', 'Belo Horizonte', 'Centro', 'Rua A', '100'),
('Ana Oliveira', '987.654.321-00', 'Ativo', 'SP-987654', 'SSP-SP', 'Casada', 'Feminino', 'ana@email.com', '11988888888', '1985-08-15', '01010-000', 'São Paulo', 'Jardins', 'Rua B', '200'),
('Carlos Santos', '555.666.777-00', 'Ativo', 'RJ-555666', 'SSP-RJ', 'Casado', 'Masculino', 'carlos@email.com', '21977777777', '1982-12-20', '22010-030', 'Rio de Janeiro', 'Copacabana', 'Rua C', '300'),
('Mariana Costa', '222.333.444-00', 'Ativo', 'PR-222333', 'SSP-PR', 'Solteira', 'Feminino', 'mariana@email.com', '41966666666', '1995-03-25', '80040-040', 'Curitiba', 'Centro', 'Rua D', '400'),
('Lucas Rocha', '999.888.777-00', 'Ativo', 'SC-999888', 'SSP-SC', 'Divorciado', 'Masculino', 'lucas@email.com', '48955555555', '1993-06-05', '88010-030', 'Florianópolis', 'Centro', 'Rua E', '500');

INSERT INTO Funcionario (nome_func, cpf_func, status_func, rg_func, expedidor_func, estadoCivil_func, genero_func, cargo_func, email_func, telefone_func, dataDeNascimento_func, cep_func, cidade_func, bairro_func, rua_func, numero_func, dataDeAdmissao_func, ctps_func, senha_func)
VALUES 
('Dra. Maria Souza', '111.222.333-44', 'Ativo', 123456, 'SSP-SP', 'Casada', 'Feminino', 'Dentista', 'maria@email.com', 11999999999, '1980-07-12', '01020-030', 'São Paulo', 'Bela Vista', 'Av. Paulista', 100, '2015-03-10', '12345678', 'senha123'),
('Dr. Ricardo Mendes', '222.333.444-55', 'Ativo', 234567, 'SSP-RJ', 'Solteiro', 'Masculino', 'Dentista', 'ricardo@email.com', 21988888888, '1978-09-22', '22040-050', 'Rio de Janeiro', 'Copacabana', 'Rua Atlântica', 200, '2012-06-15', '23456789', 'senha456'),
('Dra. Fernanda Lima', '333.444.555-66', 'Ativo', 345678, 'SSP-MG', 'Casada', 'Feminino', 'Ortodontista', 'fernanda@email.com', 31977777777, '1985-02-18', '30150-060', 'Belo Horizonte', 'Savassi', 'Av. Afonso Pena', 300, '2018-02-20', '34567890', 'senha789'),
('Dr. João Pedro', '444.555.666-77', 'Ativo', 456789, 'SSP-PR', 'Solteiro', 'Masculino', 'Cirurgião Dentista', 'joao@email.com', 41966666666, '1982-11-30', '80030-070', 'Curitiba', 'Centro', 'Rua XV de Novembro', 400, '2010-10-05', '45678901', 'senha321'),
('Dra. Juliana Alves', '555.666.777-88', 'Ativo', 567890, 'SSP-SC', 'Divorciada', 'Feminino', 'Implantodontista', 'juliana@email.com', 48955555555, '1990-01-14', '88020-080', 'Florianópolis', 'Trindade', 'Rua das Flores', 500, '2019-07-01', '56789012', 'senha654');

INSERT INTO Orcamento (valor_orca, paciente_orca, funcionario_orca, descricao_orca, id_pac_fk, id_func_fk)
VALUES 
(1200.50, 'João Silva', 'Dra. Maria Souza', 'Tratamento ortodôntico - Aparelho fixo', 1, 1),
(800.00, 'Ana Oliveira', 'Dr. Ricardo Mendes', 'Extração de dente do siso', 2, 2),
(2500.75, 'Carlos Santos', 'Dra. Fernanda Lima', 'Clareamento dental completo', 3, 3),
(600.30, 'Mariana Costa', 'Dr. João Pedro', 'Consulta de rotina e limpeza', 4, 4),
(1500.00, 'Lucas Rocha', 'Dra. Juliana Alves', 'Implante dentário - Etapa inicial', 5, 5);

INSERT INTO Servico (nome_serv, valor_serv, descricao_serv, funcionario_serv, id_func_fk)
VALUES 
('Consulta Inicial', 150.00, 'Avaliação e diagnóstico inicial do paciente', 'Dra. Maria Souza', 1),
('Extração Dentária', 300.00, 'Remoção segura e eficiente de dentes comprometidos', 'Dr. Ricardo Mendes', 2),
('Ortodontia', 5000.00, 'Aparelho fixo para correção dentária', 'Dra. Fernanda Lima', 3),
('Limpeza e Profilaxia', 200.00, 'Higienização profunda para prevenção de cáries', 'Dr. João Pedro', 4),
('Implante Dentário', 7000.00, 'Substituição de dentes perdidos com implantes modernos', 'Dra. Juliana Alves', 5);

INSERT INTO Produto (nome_prod, dataFabricacao_prod, dataValidade_prod, codigoBarras_prod, valor_prod)
VALUES 
('Fio Dental Super Floss', '2023-01-10', '2025-01-10', 7891234567890, 25.90),
('Creme Dental Branqueador', '2023-02-15', '2025-02-15', 7896541239870, 15.75),
('Anestésico Bucal', '2023-05-01', '2024-05-01', 7893214567890, 45.00),
('Enxaguante Bucal Antisséptico', '2023-03-10', '2025-03-10', 7899876543210, 30.50),
('Escova Dental Profissional', '2023-06-20', '2026-06-20', 7896549873210, 12.90),
('Kit Aparelho Ortodôntico', '2023-07-05', '2026-07-05', 7896543219870, 250.00),
('Implante Dentário Titânio', '2023-04-25', '2033-04-25', 7891237894560, 5000.00),
('Resina Fotopolimerizável', '2023-08-30', '2025-08-30', 7894561237890, 180.00),
('Broca Dentária de Diamante', '2023-09-15', '2027-09-15', 7897891234560, 350.00),
('Luva Cirúrgica Estéril', '2023-10-05', '2024-10-05', 7893219876540, 20.00);

INSERT INTO Anamnese (data_anam, febre_anam, tratamento_anam, cicatrizacao_anam, anestesia_anam, drogas_anam, diabetes_anam, doencas_anam, hipertensao_anam, id_pac_fk, id_func_fk)
VALUES 
('2024-01-15', TRUE, FALSE, TRUE, FALSE, FALSE, FALSE, TRUE, FALSE, 1, 1),
('2024-02-10', FALSE, FALSE, FALSE, TRUE, FALSE, TRUE, FALSE, FALSE, 2, 2),
('2024-03-05', TRUE, TRUE, FALSE, FALSE, TRUE, FALSE, TRUE, FALSE, 3, 3),
('2024-03-20', FALSE, FALSE, TRUE, FALSE, FALSE, FALSE, FALSE, FALSE, 4, 4),
('2024-04-10', TRUE, FALSE, FALSE, TRUE, TRUE, TRUE, FALSE, TRUE, 5, 5);

INSERT INTO Consulta (data_cons, hora_cons, valor_cons, descricao_cons, paciente_cons, funcionario_cons, id_pac_fk, id_func_fk, id_anam_fk)
VALUES 
('2024-01-16', '09:00:00', 150.00, 'Consulta inicial e avaliação clínica', 'João Silva', 'Dra. Maria Souza', 1, 1, 1),
('2024-02-11', '10:30:00', 300.00, 'Extração de dente do siso', 'Ana Oliveira', 'Dr. Ricardo Mendes', 2, 2, 2),
('2024-03-06', '14:00:00', 5000.00, 'Instalação de aparelho ortodôntico', 'Carlos Santos', 'Dra. Fernanda Lima', 3, 3, 3),
('2024-03-21', '15:45:00', 200.00, 'Limpeza e profilaxia dentária', 'Mariana Costa', 'Dr. João Pedro', 4, 4, 4),
('2024-04-11', '08:30:00', 7000.00, 'Implante dentário - primeira etapa', 'Lucas Rocha', 'Dra. Juliana Alves', 5, 5, 5);

















