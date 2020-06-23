SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Sporykhin G.Y.
-- Create date: 2020-06-23
-- Description:	Получение списка секций
-- =============================================
ALTER PROCEDURE [Arenda].[spg_getTDiscount]		 
AS
BEGIN
	SET NOCOUNT ON;

select 
	d.id,d.DateStart,d.DateEnd, d.id_TypeAgreements,d.id_TypeDiscount,d.id_TypeTenant,d.id_StatusDiscount
from 
	[Arenda].[j_tDiscount] d


END
