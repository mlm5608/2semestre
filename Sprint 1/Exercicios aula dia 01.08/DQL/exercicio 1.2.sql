--DQL

-- listar todos os alugueis mostrando as datas de início e fim, o nome do cliente que alugou e nome do modelo do carro
-- listar os alugueis de um determinado cliente mostrando seu nome, as datas de início e fim e o nome do modelo do carro

SELECT
	Aluguel.DataDeInicio,
	Aluguel.DataDeFim,
	Cliente.Nome AS cliente,
	Modelo.Nome AS modelo
FROM
	Aluguel
INNER JOIN Cliente ON Aluguel.IdCliente = Cliente.IdCliente
INNER JOIN Veiculo ON Aluguel.IdVeiculo = Veiculo.IdVeiculo
INNER JOIN Modelo ON Veiculo.IdModelo = Modelo.IdModelo
-----------------------------------------------------------------------------
SELECT 
	Cliente.Nome,
	Aluguel.DataDeInicio,
	Aluguel.DataDeFim,
	Modelo.Nome
FROM
	Cliente
INNER JOIN Aluguel ON Cliente.IdCliente = Aluguel.IdCliente
INNER JOIN Veiculo ON Aluguel.IdVeiculo = Veiculo.IdVeiculo
INNER JOIN Modelo ON Veiculo.IdModelo = Modelo.IdModelo