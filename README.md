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

## Para atualizar o banco de dados
```
Ferramentas > Gerenciados de Pacotes do NuGet > Console do Gerenciador de Pacotes
Executar o comando `Update-Database`
```