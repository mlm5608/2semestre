

--DQL SEM JOIN 
-- TRAGA O NOME (EM ORDEM ALFABETICA REVERSA), TELEFONE, EMAIL E CHN DAS PESSOAS CADASTRADAS.

select 
	Parca.Nome as TagDoPai, 
	Telefone.Numero as Telefone,
	CoisaDeVelho.Endereco as Email, 
	Parca.CNH
from 
	Pessoa as Parca,
	Email as CoisaDeVelho,
	Telefone
where 
	Parca.IdPessoa = CoisaDeVelho.IdPessoa 
	and 
	Parca.IdPessoa = Telefone.IdPessoa 
order by 
Nome desc

insert into Pessoa 
	values('Kauan','0985684765'),('gustavo','1988684361'), ('Bebeca','0965624759');

	select * from Pessoa



