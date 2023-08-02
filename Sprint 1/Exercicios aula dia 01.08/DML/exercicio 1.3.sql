-- DML

INSERT INTO Clinica (Endereco)
VALUES ('Rao João da Cunha, 1180, bairro Herrera Mauá, SP')

INSERT INTO TipoDePet (Nome)
VALUES ('Cão'), ('Gato'), ('Peixe'), ('Papagaio')

INSERT INTO Raca (IdTipo, Nome)
VALUES (4,'verdadeiro'), (2,'Persa'), (1,'Pastor-Alemão'), (3,'Colisa'), (3,'arco-íris')

INSERT INTO Veterinario (IdClinica, Nome)
VALUES (3,'CARLOS'), (3,'Josué'), (1,'Vagner')

INSERT INTO Pets (IdVeterinario, IdRaca, Dono, Nome, DataDeNascimento)
VALUES (3,3,'Robertson', 'myke', '2020-12-10')


SELECT * FROM Clinica
SELECT * FROM TipoDePet
SELECT * FROM Raca
SELECT * FROM Veterinario
SELECT * FROM Pets
