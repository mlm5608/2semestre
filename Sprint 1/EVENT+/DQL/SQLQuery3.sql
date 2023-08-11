/*NOME DE USUARIO, TIPO DO USUARIO, DATA DO EVENTO, LOCAL DO EVENTO, TITULO DO EVENTO, NOME DO EVENTO , DESCRI��O DE EVENTO, SITUA��O DO EVENTO, COMENTARIO DO EVENTO*/

SELECT
	Usuario.Nome AS Usu�rio,
	TiposDeUsuario.T�tulo AS [Tipo de usu�rio],
	Evento.DataEvento AS [Data do evento],
	Instituicao.NomeFantasia as [Local],
	TiposdeEvento.TituloTipoEvento AS [Tipo de evento],
	Evento.Nome AS [Nome do evento],
	Evento.Descricao AS [Descri��o do Evento],
	PresencaEvento.Situacao AS [Confirma��o do usuario],
	Comentario.Descricao AS [Comentario sobre o evento]
 FROM
	Comentario
	INNER JOIN Usuario 
	ON Comentario.IdUsuario = Usuario.IdUsuario

	INNER JOIN TiposDeUsuario 
	ON Usuario.IdTiposDeUsuario = TiposDeUsuario.IdTiposDeUsuario

	INNER JOIN Evento 
	ON Comentario.IdEvento = Evento.IdEvento

	INNER JOIN TiposdeEvento 
	ON Evento.IdTiposdeEvento = TiposdeEvento.IdTiposdeEvento

	INNER JOIN Instituicao 
	ON Evento.IdInstituicao = Instituicao.IdInstituicao

	INNER JOIN PresencaEvento 
	ON Usuario.IdUsuario = PresencaEvento.IdUsuario AND Evento.IdEvento = PresencaEvento.IdEvento
