/*DQL

- listar todos os veterin�rios (nome e CRMV) de uma cl�nica (raz�o social)
- listar todas as ra�as que come�am com a letra S
- listar todos os tipos de pet que terminam com a letra O
- listar todos os pets mostrando os nomes dos seus donos
- listar todos os atendimentos mostrando o nome do veterin�rio que atendeu, o nome, a ra�a e o tipo do pet que foi atendido, o nome do dono do pet e o nome da cl�nica onde o pet foi atendido */

SELECT 
	Veterinario.Nome,
	Veterinario.Crmv,
	Clinica.Nome
FROM
	Clinica
INNER JOIN Veterinario ON Clinica.IdClinica = Veterinario.IdClinica
WHERE
	Clinica.Nome = 'amigucho'
--===========================================================================

SELECT * FROM Raca WHERE Nome LIKE 'S%'

--===========================================================================

SELECT * FROM TipoDePet WHERE Nome LIKE '%O'

--===========================================================================

SELECT 
	Pets.Nome,
	Pets.Dono
FROM
	Pets

--============================================================================

SELECT
	Veterinario.Nome as 'Nome Veterinario',
	Pets.Nome as 'Nome do PET',
	Raca.Nome as 'Ra�a',
	TipoDePet.Nome as 'Tipo de PET',
	Pets.Dono,
	Clinica.Nome AS 'Cl�nica'
FROM
	Pets
INNER JOIN Raca ON Pets.IdRaca = Raca.IdRaca
INNER JOIN TipoDePet ON Raca.IdTipo = TipoDePet.IdTipo
INNER JOIN Veterinario ON Pets.IdVeterinario = Veterinario.IdVeterinario
INNER JOIN Clinica ON Veterinario.IdClinica = Clinica.IdClinica
