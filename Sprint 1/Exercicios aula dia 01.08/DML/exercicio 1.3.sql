-- DML

INSERT INTO Clinica (Endereco)
VALUES ('Rao Jo�o da Cunha, 1180, bairro Herrera Mau�, SP')

INSERT INTO TipoDePet (Nome)
VALUES ('C�o'), ('Gato'), ('Peixe'), ('Papagaio')

INSERT INTO Raca (IdTipo, Nome)
VALUES (4,'verdadeiro'), (2,'Persa'), (1,'Pastor-Alem�o'), (3,'Colisa'), (3,'arco-�ris')

INSERT INTO Veterinario (IdClinica, Nome)
VALUES (3,'CARLOS'), (3,'Josu�'), (1,'Vagner')

INSERT INTO Pets (IdVeterinario, IdRaca, Dono, Nome, DataDeNascimento)
VALUES (3,3,'Robertson', 'myke', '2020-12-10')


SELECT * FROM Clinica
SELECT * FROM TipoDePet
SELECT * FROM Raca
SELECT * FROM Veterinario
SELECT * FROM Pets
