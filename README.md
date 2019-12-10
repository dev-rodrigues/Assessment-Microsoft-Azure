## ASSESSMENT DESENVOLVIMENTO DE SERVIÇOS WCF E MICROSOFT AZURE 

## SCRIPT STORED PROCEDURE `STATE`

``` script
CREATE PROCEDURE [dbo].[State_Select]
@id_state as int
AS
SELECT				*
FROM				dbo.States		as	s
		inner join	dbo.Countries		as	c
			on	c.Id = s.Country_Id
WHERE				(1=1)
			and	s.Id = @id_state
return 0
```

## SCRIPT STORED PROCEDURE `COUNTRY`
``` script
CREATE PROCEDURE [dbo].[Country_Select]
@city as nvarchar(max)
AS
select				distinct*
from				dbo.Countries		as	c
		left join	dbo.States		as	s
			on	c.Id = s.Country_Id
where				(1=1)
			and	s.Name like @city
return 0
```

## SCRIPT STORED PROCEDURE `BUSCA SOMATORIO`
```
CREATE PROCEDURE [dbo].[Busca_Somatorio]

@pais		as int = 0,
@estado		as int = 0,
@amigos		as int = 0

AS
	select	@pais = 
		COUNT(c.Id) 
	from	dbo.Countries	as c

	select	@estado =
		COUNT(e.Id)
	from	dbo.States	as e

	select	@amigos =
		COUNT(f.Id)
	from	dbo.Friends	as f

	select @pais as SUM_PAIS, @estado AS SUM_ESTADO, @amigos AS SUM_AMIGOS
```

## SCRIPT STORED PROCEDURE `APAGAR AMIZADE`
```
CREATE PROCEDURE [dbo].[Delete_Amizade]
	@id_user as int
AS
delete
from		dbo.Friendships		
where		Id in	(
				select		fs.Id
				from		dbo.Friendships		fs
				where		(1=1)
					and	fs.Follower_Id = @id_user
					or	fs.Followed_Id = @id_user		
			)
RETURN 0
```

## SCRIPT STORED PROCEDURE `APAGAR FRIEND`
```
CREATE PROCEDURE [dbo].[Delete_friend]
	@id_friend int
AS
delete
from		dbo.Friends	
where		Id = @id_friend
RETURN 0
```

## Para atualizar o banco de dados
```
Ferramentas > Gerenciados de Pacotes do NuGet > Console do Gerenciador de Pacotes
Executar o comando `Update-Database`
```