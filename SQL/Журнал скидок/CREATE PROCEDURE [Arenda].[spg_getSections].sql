SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Sporykhin G.Y.
-- Create date: 2020-06-23
-- Description:	Получение списка секций
-- =============================================
CREATE PROCEDURE [Arenda].[spg_getSections]		 
AS
BEGIN
	SET NOCOUNT ON;

select s.id,s.id_Building,s.id_ObjectLease,s.id_Floor,s.isActive,s.cName from Arenda.s_Sections s


END
