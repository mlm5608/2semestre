--DML

--INSERIR DADOS NAS TABELAS


--INSERE NAS TABELAS BASICAS
INSERT INTO Empresa(Nome)
VALUES ('GETCAR'), ('ALUGAQUI');

INSERT INTO Marca(Nome)
VALUES ('FIAT'),('WOLKS'),('GM');

--INSERE NOS MODELOS 
INSERT INTO Modelo(IdMarca, Nome)
VALUES (3, 'Onix'), (2, 'Fiesta'), (1, 'Argo')

--INSERE NOS VEICULOS
INSERT INTO Veiculo(IdModelo, IdEmpresa, Placa)
VALUES (1,2,'JJJ2K34'), (3,1,'YTO3P56'), (2,1,'POU5I69')

--INSERE NOVOS ALUGUEIS
INSERT INTO Cliente(IdVeiculo,Nome,Cpf)
VALUES (2,'JONISCLAY','78960853890'), (3, 'Velma', '52489765708'), (1, 'Miguel', '5086670890') 

SELECT * FROM Empresa
SELECT * FROM Marca
SELECT * FROM Modelo
SELECT * FROM Veiculo
SELECT * FROM Cliente