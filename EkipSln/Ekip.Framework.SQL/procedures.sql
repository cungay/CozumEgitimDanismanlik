
USE [EkipDev]
GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_DropAllProcedures procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_DropAllProcedures') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_DropAllProcedures
GO

-- Drops all existing netTiers stored procedures

CREATE PROCEDURE dbo.sp_DropAllProcedures

AS


BEGIN
DECLARE @procedureName SYSNAME
DECLARE c CURSOR FOR
SELECT '[' + sc.name + '].[' + so.name + ']' FROM sysobjects so INNER JOIN sys.schemas sc ON sc.schema_id = so.uid WHERE type = 'P' AND objectproperty(id, 'IsMSShipped') = 0
AND so.name LIKE 'sp_%' 
AND so.name <> 'Seance_DeleteBySeanceID'
AND so.name <> 'Seance_DeleteByClientID'
AND so.name <> 'Town_GetByProvinceId'
AND so.name <> 'Session_Get'
AND so.name <> 'Street_GetByNeighborhoodId'
AND so.name <> 'ClientAddress_GetCurrentAddress'
AND so.name <> 'Client_FindByReason_FirstDate_BirthDate'
AND so.name <> 'Client_AdvisorReport'
AND so.name <> 'Client_GetAllFirstContactYears'
AND so.name <> 'Client_GetByFirstContactYears'
AND so.name <> 'Client_GetAllBirthDateYears'
AND so.name <> 'Client_GetFirst'
AND so.name <> 'Client_GetFileNumbers'
AND so.name <> 'Client_GetLast'
AND so.name <> 'ClientView_Find'
AND so.name <> 'WippsiView_GetByClientID'
AND so.name <> 'WiscrView_GetByClientID'
OPEN c
FETCH NEXT FROM c INTO @procedureName
WHILE @@FETCH_STATUS = 0
BEGIN
EXEC('DROP PROC ' + @procedureName)
FETCH NEXT FROM c INTO @procedureName
END
CLOSE c
DEALLOCATE c
END
GO

EXEC dbo.sp_DropAllProcedures
GO


GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_Advisor_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_Advisor_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_Advisor_Get_List
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Gets all records from the Advisor table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Advisor_Get_List

AS


				
				SELECT
					[AdvisorId],
					[Title],
					[FullName],
					[Email],
					[Active],
					[Deleted],
					[CreateDate],
					[UpdateDate]
				FROM
					[dbo].[Advisor]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_Advisor_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_Advisor_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_Advisor_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Gets records from the Advisor table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Advisor_GetPaged
(

	@WhereClause varchar (8000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy IS NULL OR LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[AdvisorId]'
				END

				-- SQL Server 2005 Paging
				DECLARE @SQL AS nvarchar(MAX)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [AdvisorId]'
				SET @SQL = @SQL + ', [Title]'
				SET @SQL = @SQL + ', [FullName]'
				SET @SQL = @SQL + ', [Email]'
				SET @SQL = @SQL + ', [Active]'
				SET @SQL = @SQL + ', [Deleted]'
				SET @SQL = @SQL + ', [CreateDate]'
				SET @SQL = @SQL + ', [UpdateDate]'
				SET @SQL = @SQL + ' FROM [dbo].[Advisor]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [AdvisorId],'
				SET @SQL = @SQL + ' [Title],'
				SET @SQL = @SQL + ' [FullName],'
				SET @SQL = @SQL + ' [Email],'
				SET @SQL = @SQL + ' [Active],'
				SET @SQL = @SQL + ' [Deleted],'
				SET @SQL = @SQL + ' [CreateDate],'
				SET @SQL = @SQL + ' [UpdateDate]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + CONVERT(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				EXEC sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(1) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[Advisor]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_Advisor_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_Advisor_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_Advisor_Insert
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Inserts a record into the Advisor table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Advisor_Insert
(

	@AdvisorId int    OUTPUT,

	@Title varchar (50)  ,

	@FullName varchar (50)  ,

	@Email varchar (50)  ,

	@Active bit   ,

	@Deleted bit   ,

	@CreateDate smalldatetime   ,

	@UpdateDate smalldatetime   
)
AS


				
				INSERT INTO [dbo].[Advisor]
					(
					[Title]
					,[FullName]
					,[Email]
					,[Active]
					,[Deleted]
					,[CreateDate]
					,[UpdateDate]
					)
				VALUES
					(
					@Title
					,@FullName
					,@Email
					,@Active
					,@Deleted
					,@CreateDate
					,@UpdateDate
					)
				-- Get the identity value
				SET @AdvisorId = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_Advisor_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_Advisor_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_Advisor_Update
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Updates a record in the Advisor table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Advisor_Update
(

	@AdvisorId int   ,

	@Title varchar (50)  ,

	@FullName varchar (50)  ,

	@Email varchar (50)  ,

	@Active bit   ,

	@Deleted bit   ,

	@CreateDate smalldatetime   ,

	@UpdateDate smalldatetime   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[Advisor]
				SET
					[Title] = @Title
					,[FullName] = @FullName
					,[Email] = @Email
					,[Active] = @Active
					,[Deleted] = @Deleted
					,[CreateDate] = @CreateDate
					,[UpdateDate] = @UpdateDate
				WHERE
[AdvisorId] = @AdvisorId 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_Advisor_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_Advisor_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_Advisor_Delete
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Deletes a record in the Advisor table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Advisor_Delete
(

	@AdvisorId int   
)
AS


				DELETE FROM [dbo].[Advisor] WITH (ROWLOCK) 
				WHERE
					[AdvisorId] = @AdvisorId
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_Advisor_GetByAdvisorId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_Advisor_GetByAdvisorId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_Advisor_GetByAdvisorId
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Select records from the Advisor table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Advisor_GetByAdvisorId
(

	@AdvisorId int   
)
AS


				SELECT
					[AdvisorId],
					[Title],
					[FullName],
					[Email],
					[Active],
					[Deleted],
					[CreateDate],
					[UpdateDate]
				FROM
					[dbo].[Advisor]
				WHERE
					[AdvisorId] = @AdvisorId
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_Advisor_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_Advisor_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_Advisor_Find
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Finds records in the Advisor table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Advisor_Find
(

	@SearchUsingOR bit   = null ,

	@AdvisorId int   = null ,

	@Title varchar (50)  = null ,

	@FullName varchar (50)  = null ,

	@Email varchar (50)  = null ,

	@Active bit   = null ,

	@Deleted bit   = null ,

	@CreateDate smalldatetime   = null ,

	@UpdateDate smalldatetime   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [AdvisorId]
	, [Title]
	, [FullName]
	, [Email]
	, [Active]
	, [Deleted]
	, [CreateDate]
	, [UpdateDate]
    FROM
	[dbo].[Advisor]
    WHERE 
	 ([AdvisorId] = @AdvisorId OR @AdvisorId IS NULL)
	AND ([Title] = @Title OR @Title IS NULL)
	AND ([FullName] = @FullName OR @FullName IS NULL)
	AND ([Email] = @Email OR @Email IS NULL)
	AND ([Active] = @Active OR @Active IS NULL)
	AND ([Deleted] = @Deleted OR @Deleted IS NULL)
	AND ([CreateDate] = @CreateDate OR @CreateDate IS NULL)
	AND ([UpdateDate] = @UpdateDate OR @UpdateDate IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [AdvisorId]
	, [Title]
	, [FullName]
	, [Email]
	, [Active]
	, [Deleted]
	, [CreateDate]
	, [UpdateDate]
    FROM
	[dbo].[Advisor]
    WHERE 
	 ([AdvisorId] = @AdvisorId AND @AdvisorId is not null)
	OR ([Title] = @Title AND @Title is not null)
	OR ([FullName] = @FullName AND @FullName is not null)
	OR ([Email] = @Email AND @Email is not null)
	OR ([Active] = @Active AND @Active is not null)
	OR ([Deleted] = @Deleted AND @Deleted is not null)
	OR ([CreateDate] = @CreateDate AND @CreateDate is not null)
	OR ([UpdateDate] = @UpdateDate AND @UpdateDate is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_Seance_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_Seance_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_Seance_Get_List
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Gets all records from the Seance table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Seance_Get_List

AS


				
				SELECT
					[SeanceId],
					[ClientId],
					[AdvisorId],
					[SeanceDate],
					[SeanceTime],
					[SeanceNotes],
					[SeanceStatusId],
					[WippsiId],
					[WiscrId],
					[Active],
					[Deleted],
					[CreateDate],
					[UpdateDate],
					[CreatedUserId],
					[UpdatedUserId]
				FROM
					[dbo].[Seance]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_Seance_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_Seance_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_Seance_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Gets records from the Seance table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Seance_GetPaged
(

	@WhereClause varchar (8000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy IS NULL OR LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[SeanceId]'
				END

				-- SQL Server 2005 Paging
				DECLARE @SQL AS nvarchar(MAX)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [SeanceId]'
				SET @SQL = @SQL + ', [ClientId]'
				SET @SQL = @SQL + ', [AdvisorId]'
				SET @SQL = @SQL + ', [SeanceDate]'
				SET @SQL = @SQL + ', [SeanceTime]'
				SET @SQL = @SQL + ', [SeanceNotes]'
				SET @SQL = @SQL + ', [SeanceStatusId]'
				SET @SQL = @SQL + ', [WippsiId]'
				SET @SQL = @SQL + ', [WiscrId]'
				SET @SQL = @SQL + ', [Active]'
				SET @SQL = @SQL + ', [Deleted]'
				SET @SQL = @SQL + ', [CreateDate]'
				SET @SQL = @SQL + ', [UpdateDate]'
				SET @SQL = @SQL + ', [CreatedUserId]'
				SET @SQL = @SQL + ', [UpdatedUserId]'
				SET @SQL = @SQL + ' FROM [dbo].[Seance]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [SeanceId],'
				SET @SQL = @SQL + ' [ClientId],'
				SET @SQL = @SQL + ' [AdvisorId],'
				SET @SQL = @SQL + ' [SeanceDate],'
				SET @SQL = @SQL + ' [SeanceTime],'
				SET @SQL = @SQL + ' [SeanceNotes],'
				SET @SQL = @SQL + ' [SeanceStatusId],'
				SET @SQL = @SQL + ' [WippsiId],'
				SET @SQL = @SQL + ' [WiscrId],'
				SET @SQL = @SQL + ' [Active],'
				SET @SQL = @SQL + ' [Deleted],'
				SET @SQL = @SQL + ' [CreateDate],'
				SET @SQL = @SQL + ' [UpdateDate],'
				SET @SQL = @SQL + ' [CreatedUserId],'
				SET @SQL = @SQL + ' [UpdatedUserId]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + CONVERT(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				EXEC sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(1) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[Seance]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_Seance_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_Seance_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_Seance_Insert
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Inserts a record into the Seance table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Seance_Insert
(

	@SeanceId int    OUTPUT,

	@ClientId int   ,

	@AdvisorId int   ,

	@SeanceDate date   ,

	@SeanceTime time   ,

	@SeanceNotes varchar (MAX)  ,

	@SeanceStatusId tinyint   ,

	@WippsiId int   ,

	@WiscrId int   ,

	@Active bit   ,

	@Deleted bit   ,

	@CreateDate smalldatetime   ,

	@UpdateDate smalldatetime   ,

	@CreatedUserId int   ,

	@UpdatedUserId int   
)
AS


				
				INSERT INTO [dbo].[Seance]
					(
					[ClientId]
					,[AdvisorId]
					,[SeanceDate]
					,[SeanceTime]
					,[SeanceNotes]
					,[SeanceStatusId]
					,[WippsiId]
					,[WiscrId]
					,[Active]
					,[Deleted]
					,[CreateDate]
					,[UpdateDate]
					,[CreatedUserId]
					,[UpdatedUserId]
					)
				VALUES
					(
					@ClientId
					,@AdvisorId
					,@SeanceDate
					,@SeanceTime
					,@SeanceNotes
					,@SeanceStatusId
					,@WippsiId
					,@WiscrId
					,@Active
					,@Deleted
					,@CreateDate
					,@UpdateDate
					,@CreatedUserId
					,@UpdatedUserId
					)
				-- Get the identity value
				SET @SeanceId = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_Seance_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_Seance_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_Seance_Update
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Updates a record in the Seance table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Seance_Update
(

	@SeanceId int   ,

	@ClientId int   ,

	@AdvisorId int   ,

	@SeanceDate date   ,

	@SeanceTime time   ,

	@SeanceNotes varchar (MAX)  ,

	@SeanceStatusId tinyint   ,

	@WippsiId int   ,

	@WiscrId int   ,

	@Active bit   ,

	@Deleted bit   ,

	@CreateDate smalldatetime   ,

	@UpdateDate smalldatetime   ,

	@CreatedUserId int   ,

	@UpdatedUserId int   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[Seance]
				SET
					[ClientId] = @ClientId
					,[AdvisorId] = @AdvisorId
					,[SeanceDate] = @SeanceDate
					,[SeanceTime] = @SeanceTime
					,[SeanceNotes] = @SeanceNotes
					,[SeanceStatusId] = @SeanceStatusId
					,[WippsiId] = @WippsiId
					,[WiscrId] = @WiscrId
					,[Active] = @Active
					,[Deleted] = @Deleted
					,[CreateDate] = @CreateDate
					,[UpdateDate] = @UpdateDate
					,[CreatedUserId] = @CreatedUserId
					,[UpdatedUserId] = @UpdatedUserId
				WHERE
[SeanceId] = @SeanceId 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_Seance_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_Seance_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_Seance_Delete
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Deletes a record in the Seance table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Seance_Delete
(

	@SeanceId int   
)
AS


				DELETE FROM [dbo].[Seance] WITH (ROWLOCK) 
				WHERE
					[SeanceId] = @SeanceId
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_Seance_GetByClientId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_Seance_GetByClientId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_Seance_GetByClientId
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Select records from the Seance table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Seance_GetByClientId
(

	@ClientId int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[SeanceId],
					[ClientId],
					[AdvisorId],
					[SeanceDate],
					[SeanceTime],
					[SeanceNotes],
					[SeanceStatusId],
					[WippsiId],
					[WiscrId],
					[Active],
					[Deleted],
					[CreateDate],
					[UpdateDate],
					[CreatedUserId],
					[UpdatedUserId]
				FROM
					[dbo].[Seance]
				WHERE
					[ClientId] = @ClientId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_Seance_GetByWippsiId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_Seance_GetByWippsiId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_Seance_GetByWippsiId
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Select records from the Seance table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Seance_GetByWippsiId
(

	@WippsiId int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[SeanceId],
					[ClientId],
					[AdvisorId],
					[SeanceDate],
					[SeanceTime],
					[SeanceNotes],
					[SeanceStatusId],
					[WippsiId],
					[WiscrId],
					[Active],
					[Deleted],
					[CreateDate],
					[UpdateDate],
					[CreatedUserId],
					[UpdatedUserId]
				FROM
					[dbo].[Seance]
				WHERE
					[WippsiId] = @WippsiId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_Seance_GetByWiscrId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_Seance_GetByWiscrId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_Seance_GetByWiscrId
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Select records from the Seance table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Seance_GetByWiscrId
(

	@WiscrId int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[SeanceId],
					[ClientId],
					[AdvisorId],
					[SeanceDate],
					[SeanceTime],
					[SeanceNotes],
					[SeanceStatusId],
					[WippsiId],
					[WiscrId],
					[Active],
					[Deleted],
					[CreateDate],
					[UpdateDate],
					[CreatedUserId],
					[UpdatedUserId]
				FROM
					[dbo].[Seance]
				WHERE
					[WiscrId] = @WiscrId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_Seance_GetBySeanceId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_Seance_GetBySeanceId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_Seance_GetBySeanceId
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Select records from the Seance table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Seance_GetBySeanceId
(

	@SeanceId int   
)
AS


				SELECT
					[SeanceId],
					[ClientId],
					[AdvisorId],
					[SeanceDate],
					[SeanceTime],
					[SeanceNotes],
					[SeanceStatusId],
					[WippsiId],
					[WiscrId],
					[Active],
					[Deleted],
					[CreateDate],
					[UpdateDate],
					[CreatedUserId],
					[UpdatedUserId]
				FROM
					[dbo].[Seance]
				WHERE
					[SeanceId] = @SeanceId
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_Seance_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_Seance_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_Seance_Find
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Finds records in the Seance table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Seance_Find
(

	@SearchUsingOR bit   = null ,

	@SeanceId int   = null ,

	@ClientId int   = null ,

	@AdvisorId int   = null ,

	@SeanceDate date   = null ,

	@SeanceTime time   = null ,

	@SeanceNotes varchar (MAX)  = null ,

	@SeanceStatusId tinyint   = null ,

	@WippsiId int   = null ,

	@WiscrId int   = null ,

	@Active bit   = null ,

	@Deleted bit   = null ,

	@CreateDate smalldatetime   = null ,

	@UpdateDate smalldatetime   = null ,

	@CreatedUserId int   = null ,

	@UpdatedUserId int   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [SeanceId]
	, [ClientId]
	, [AdvisorId]
	, [SeanceDate]
	, [SeanceTime]
	, [SeanceNotes]
	, [SeanceStatusId]
	, [WippsiId]
	, [WiscrId]
	, [Active]
	, [Deleted]
	, [CreateDate]
	, [UpdateDate]
	, [CreatedUserId]
	, [UpdatedUserId]
    FROM
	[dbo].[Seance]
    WHERE 
	 ([SeanceId] = @SeanceId OR @SeanceId IS NULL)
	AND ([ClientId] = @ClientId OR @ClientId IS NULL)
	AND ([AdvisorId] = @AdvisorId OR @AdvisorId IS NULL)
	AND ([SeanceDate] = @SeanceDate OR @SeanceDate IS NULL)
	AND ([SeanceTime] = @SeanceTime OR @SeanceTime IS NULL)
	AND ([SeanceNotes] = @SeanceNotes OR @SeanceNotes IS NULL)
	AND ([SeanceStatusId] = @SeanceStatusId OR @SeanceStatusId IS NULL)
	AND ([WippsiId] = @WippsiId OR @WippsiId IS NULL)
	AND ([WiscrId] = @WiscrId OR @WiscrId IS NULL)
	AND ([Active] = @Active OR @Active IS NULL)
	AND ([Deleted] = @Deleted OR @Deleted IS NULL)
	AND ([CreateDate] = @CreateDate OR @CreateDate IS NULL)
	AND ([UpdateDate] = @UpdateDate OR @UpdateDate IS NULL)
	AND ([CreatedUserId] = @CreatedUserId OR @CreatedUserId IS NULL)
	AND ([UpdatedUserId] = @UpdatedUserId OR @UpdatedUserId IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [SeanceId]
	, [ClientId]
	, [AdvisorId]
	, [SeanceDate]
	, [SeanceTime]
	, [SeanceNotes]
	, [SeanceStatusId]
	, [WippsiId]
	, [WiscrId]
	, [Active]
	, [Deleted]
	, [CreateDate]
	, [UpdateDate]
	, [CreatedUserId]
	, [UpdatedUserId]
    FROM
	[dbo].[Seance]
    WHERE 
	 ([SeanceId] = @SeanceId AND @SeanceId is not null)
	OR ([ClientId] = @ClientId AND @ClientId is not null)
	OR ([AdvisorId] = @AdvisorId AND @AdvisorId is not null)
	OR ([SeanceDate] = @SeanceDate AND @SeanceDate is not null)
	OR ([SeanceTime] = @SeanceTime AND @SeanceTime is not null)
	OR ([SeanceNotes] = @SeanceNotes AND @SeanceNotes is not null)
	OR ([SeanceStatusId] = @SeanceStatusId AND @SeanceStatusId is not null)
	OR ([WippsiId] = @WippsiId AND @WippsiId is not null)
	OR ([WiscrId] = @WiscrId AND @WiscrId is not null)
	OR ([Active] = @Active AND @Active is not null)
	OR ([Deleted] = @Deleted AND @Deleted is not null)
	OR ([CreateDate] = @CreateDate AND @CreateDate is not null)
	OR ([UpdateDate] = @UpdateDate AND @UpdateDate is not null)
	OR ([CreatedUserId] = @CreatedUserId AND @CreatedUserId is not null)
	OR ([UpdatedUserId] = @UpdatedUserId AND @UpdatedUserId is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_Seance_Reason_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_Seance_Reason_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_Seance_Reason_Get_List
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Gets all records from the Seance_Reason table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Seance_Reason_Get_List

AS


				
				SELECT
					[RowId],
					[SeanceId],
					[ReasonId]
				FROM
					[dbo].[Seance_Reason]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_Seance_Reason_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_Seance_Reason_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_Seance_Reason_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Gets records from the Seance_Reason table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Seance_Reason_GetPaged
(

	@WhereClause varchar (8000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy IS NULL OR LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[RowId]'
				END

				-- SQL Server 2005 Paging
				DECLARE @SQL AS nvarchar(MAX)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [RowId]'
				SET @SQL = @SQL + ', [SeanceId]'
				SET @SQL = @SQL + ', [ReasonId]'
				SET @SQL = @SQL + ' FROM [dbo].[Seance_Reason]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [RowId],'
				SET @SQL = @SQL + ' [SeanceId],'
				SET @SQL = @SQL + ' [ReasonId]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + CONVERT(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				EXEC sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(1) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[Seance_Reason]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_Seance_Reason_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_Seance_Reason_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_Seance_Reason_Insert
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Inserts a record into the Seance_Reason table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Seance_Reason_Insert
(

	@RowId int    OUTPUT,

	@SeanceId int   ,

	@ReasonId int   
)
AS


				
				INSERT INTO [dbo].[Seance_Reason]
					(
					[SeanceId]
					,[ReasonId]
					)
				VALUES
					(
					@SeanceId
					,@ReasonId
					)
				-- Get the identity value
				SET @RowId = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_Seance_Reason_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_Seance_Reason_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_Seance_Reason_Update
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Updates a record in the Seance_Reason table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Seance_Reason_Update
(

	@RowId int   ,

	@SeanceId int   ,

	@ReasonId int   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[Seance_Reason]
				SET
					[SeanceId] = @SeanceId
					,[ReasonId] = @ReasonId
				WHERE
[RowId] = @RowId 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_Seance_Reason_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_Seance_Reason_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_Seance_Reason_Delete
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Deletes a record in the Seance_Reason table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Seance_Reason_Delete
(

	@RowId int   
)
AS


				DELETE FROM [dbo].[Seance_Reason] WITH (ROWLOCK) 
				WHERE
					[RowId] = @RowId
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_Seance_Reason_GetByReasonId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_Seance_Reason_GetByReasonId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_Seance_Reason_GetByReasonId
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Select records from the Seance_Reason table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Seance_Reason_GetByReasonId
(

	@ReasonId int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[RowId],
					[SeanceId],
					[ReasonId]
				FROM
					[dbo].[Seance_Reason]
				WHERE
					[ReasonId] = @ReasonId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_Seance_Reason_GetBySeanceId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_Seance_Reason_GetBySeanceId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_Seance_Reason_GetBySeanceId
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Select records from the Seance_Reason table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Seance_Reason_GetBySeanceId
(

	@SeanceId int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[RowId],
					[SeanceId],
					[ReasonId]
				FROM
					[dbo].[Seance_Reason]
				WHERE
					[SeanceId] = @SeanceId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_Seance_Reason_GetByRowId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_Seance_Reason_GetByRowId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_Seance_Reason_GetByRowId
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Select records from the Seance_Reason table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Seance_Reason_GetByRowId
(

	@RowId int   
)
AS


				SELECT
					[RowId],
					[SeanceId],
					[ReasonId]
				FROM
					[dbo].[Seance_Reason]
				WHERE
					[RowId] = @RowId
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_Seance_Reason_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_Seance_Reason_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_Seance_Reason_Find
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Finds records in the Seance_Reason table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Seance_Reason_Find
(

	@SearchUsingOR bit   = null ,

	@RowId int   = null ,

	@SeanceId int   = null ,

	@ReasonId int   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [RowId]
	, [SeanceId]
	, [ReasonId]
    FROM
	[dbo].[Seance_Reason]
    WHERE 
	 ([RowId] = @RowId OR @RowId IS NULL)
	AND ([SeanceId] = @SeanceId OR @SeanceId IS NULL)
	AND ([ReasonId] = @ReasonId OR @ReasonId IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [RowId]
	, [SeanceId]
	, [ReasonId]
    FROM
	[dbo].[Seance_Reason]
    WHERE 
	 ([RowId] = @RowId AND @RowId is not null)
	OR ([SeanceId] = @SeanceId AND @SeanceId is not null)
	OR ([ReasonId] = @ReasonId AND @ReasonId is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_School_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_School_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_School_Get_List
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Gets all records from the School table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_School_Get_List

AS


				
				SELECT
					[SchoolId],
					[SchoolName],
					[InstitutionTypeId],
					[SchoolTypeId],
					[ProvinceId],
					[TownId],
					[Address],
					[Phone],
					[Fax],
					[WebAddress],
					[SchoolNotes],
					[CreateOn],
					[UpdateOn],
					[CreateUserId],
					[UpdateUserId]
				FROM
					[dbo].[School]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_School_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_School_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_School_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Gets records from the School table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_School_GetPaged
(

	@WhereClause varchar (8000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy IS NULL OR LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[SchoolId]'
				END

				-- SQL Server 2005 Paging
				DECLARE @SQL AS nvarchar(MAX)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [SchoolId]'
				SET @SQL = @SQL + ', [SchoolName]'
				SET @SQL = @SQL + ', [InstitutionTypeId]'
				SET @SQL = @SQL + ', [SchoolTypeId]'
				SET @SQL = @SQL + ', [ProvinceId]'
				SET @SQL = @SQL + ', [TownId]'
				SET @SQL = @SQL + ', [Address]'
				SET @SQL = @SQL + ', [Phone]'
				SET @SQL = @SQL + ', [Fax]'
				SET @SQL = @SQL + ', [WebAddress]'
				SET @SQL = @SQL + ', [SchoolNotes]'
				SET @SQL = @SQL + ', [CreateOn]'
				SET @SQL = @SQL + ', [UpdateOn]'
				SET @SQL = @SQL + ', [CreateUserId]'
				SET @SQL = @SQL + ', [UpdateUserId]'
				SET @SQL = @SQL + ' FROM [dbo].[School]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [SchoolId],'
				SET @SQL = @SQL + ' [SchoolName],'
				SET @SQL = @SQL + ' [InstitutionTypeId],'
				SET @SQL = @SQL + ' [SchoolTypeId],'
				SET @SQL = @SQL + ' [ProvinceId],'
				SET @SQL = @SQL + ' [TownId],'
				SET @SQL = @SQL + ' [Address],'
				SET @SQL = @SQL + ' [Phone],'
				SET @SQL = @SQL + ' [Fax],'
				SET @SQL = @SQL + ' [WebAddress],'
				SET @SQL = @SQL + ' [SchoolNotes],'
				SET @SQL = @SQL + ' [CreateOn],'
				SET @SQL = @SQL + ' [UpdateOn],'
				SET @SQL = @SQL + ' [CreateUserId],'
				SET @SQL = @SQL + ' [UpdateUserId]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + CONVERT(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				EXEC sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(1) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[School]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_School_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_School_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_School_Insert
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Inserts a record into the School table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_School_Insert
(

	@SchoolId int    OUTPUT,

	@SchoolName varchar (100)  ,

	@InstitutionTypeId tinyint   ,

	@SchoolTypeId tinyint   ,

	@ProvinceId int   ,

	@TownId int   ,

	@Address varchar (500)  ,

	@Phone varchar (15)  ,

	@Fax varchar (15)  ,

	@WebAddress varchar (100)  ,

	@SchoolNotes varchar (MAX)  ,

	@CreateOn smalldatetime   ,

	@UpdateOn smalldatetime   ,

	@CreateUserId int   ,

	@UpdateUserId int   
)
AS


				
				INSERT INTO [dbo].[School]
					(
					[SchoolName]
					,[InstitutionTypeId]
					,[SchoolTypeId]
					,[ProvinceId]
					,[TownId]
					,[Address]
					,[Phone]
					,[Fax]
					,[WebAddress]
					,[SchoolNotes]
					,[CreateOn]
					,[UpdateOn]
					,[CreateUserId]
					,[UpdateUserId]
					)
				VALUES
					(
					@SchoolName
					,@InstitutionTypeId
					,@SchoolTypeId
					,@ProvinceId
					,@TownId
					,@Address
					,@Phone
					,@Fax
					,@WebAddress
					,@SchoolNotes
					,@CreateOn
					,@UpdateOn
					,@CreateUserId
					,@UpdateUserId
					)
				-- Get the identity value
				SET @SchoolId = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_School_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_School_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_School_Update
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Updates a record in the School table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_School_Update
(

	@SchoolId int   ,

	@SchoolName varchar (100)  ,

	@InstitutionTypeId tinyint   ,

	@SchoolTypeId tinyint   ,

	@ProvinceId int   ,

	@TownId int   ,

	@Address varchar (500)  ,

	@Phone varchar (15)  ,

	@Fax varchar (15)  ,

	@WebAddress varchar (100)  ,

	@SchoolNotes varchar (MAX)  ,

	@CreateOn smalldatetime   ,

	@UpdateOn smalldatetime   ,

	@CreateUserId int   ,

	@UpdateUserId int   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[School]
				SET
					[SchoolName] = @SchoolName
					,[InstitutionTypeId] = @InstitutionTypeId
					,[SchoolTypeId] = @SchoolTypeId
					,[ProvinceId] = @ProvinceId
					,[TownId] = @TownId
					,[Address] = @Address
					,[Phone] = @Phone
					,[Fax] = @Fax
					,[WebAddress] = @WebAddress
					,[SchoolNotes] = @SchoolNotes
					,[CreateOn] = @CreateOn
					,[UpdateOn] = @UpdateOn
					,[CreateUserId] = @CreateUserId
					,[UpdateUserId] = @UpdateUserId
				WHERE
[SchoolId] = @SchoolId 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_School_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_School_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_School_Delete
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Deletes a record in the School table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_School_Delete
(

	@SchoolId int   
)
AS


				DELETE FROM [dbo].[School] WITH (ROWLOCK) 
				WHERE
					[SchoolId] = @SchoolId
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_School_GetBySchoolId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_School_GetBySchoolId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_School_GetBySchoolId
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Select records from the School table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_School_GetBySchoolId
(

	@SchoolId int   
)
AS


				SELECT
					[SchoolId],
					[SchoolName],
					[InstitutionTypeId],
					[SchoolTypeId],
					[ProvinceId],
					[TownId],
					[Address],
					[Phone],
					[Fax],
					[WebAddress],
					[SchoolNotes],
					[CreateOn],
					[UpdateOn],
					[CreateUserId],
					[UpdateUserId]
				FROM
					[dbo].[School]
				WHERE
					[SchoolId] = @SchoolId
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_School_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_School_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_School_Find
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Finds records in the School table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_School_Find
(

	@SearchUsingOR bit   = null ,

	@SchoolId int   = null ,

	@SchoolName varchar (100)  = null ,

	@InstitutionTypeId tinyint   = null ,

	@SchoolTypeId tinyint   = null ,

	@ProvinceId int   = null ,

	@TownId int   = null ,

	@Address varchar (500)  = null ,

	@Phone varchar (15)  = null ,

	@Fax varchar (15)  = null ,

	@WebAddress varchar (100)  = null ,

	@SchoolNotes varchar (MAX)  = null ,

	@CreateOn smalldatetime   = null ,

	@UpdateOn smalldatetime   = null ,

	@CreateUserId int   = null ,

	@UpdateUserId int   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [SchoolId]
	, [SchoolName]
	, [InstitutionTypeId]
	, [SchoolTypeId]
	, [ProvinceId]
	, [TownId]
	, [Address]
	, [Phone]
	, [Fax]
	, [WebAddress]
	, [SchoolNotes]
	, [CreateOn]
	, [UpdateOn]
	, [CreateUserId]
	, [UpdateUserId]
    FROM
	[dbo].[School]
    WHERE 
	 ([SchoolId] = @SchoolId OR @SchoolId IS NULL)
	AND ([SchoolName] = @SchoolName OR @SchoolName IS NULL)
	AND ([InstitutionTypeId] = @InstitutionTypeId OR @InstitutionTypeId IS NULL)
	AND ([SchoolTypeId] = @SchoolTypeId OR @SchoolTypeId IS NULL)
	AND ([ProvinceId] = @ProvinceId OR @ProvinceId IS NULL)
	AND ([TownId] = @TownId OR @TownId IS NULL)
	AND ([Address] = @Address OR @Address IS NULL)
	AND ([Phone] = @Phone OR @Phone IS NULL)
	AND ([Fax] = @Fax OR @Fax IS NULL)
	AND ([WebAddress] = @WebAddress OR @WebAddress IS NULL)
	AND ([SchoolNotes] = @SchoolNotes OR @SchoolNotes IS NULL)
	AND ([CreateOn] = @CreateOn OR @CreateOn IS NULL)
	AND ([UpdateOn] = @UpdateOn OR @UpdateOn IS NULL)
	AND ([CreateUserId] = @CreateUserId OR @CreateUserId IS NULL)
	AND ([UpdateUserId] = @UpdateUserId OR @UpdateUserId IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [SchoolId]
	, [SchoolName]
	, [InstitutionTypeId]
	, [SchoolTypeId]
	, [ProvinceId]
	, [TownId]
	, [Address]
	, [Phone]
	, [Fax]
	, [WebAddress]
	, [SchoolNotes]
	, [CreateOn]
	, [UpdateOn]
	, [CreateUserId]
	, [UpdateUserId]
    FROM
	[dbo].[School]
    WHERE 
	 ([SchoolId] = @SchoolId AND @SchoolId is not null)
	OR ([SchoolName] = @SchoolName AND @SchoolName is not null)
	OR ([InstitutionTypeId] = @InstitutionTypeId AND @InstitutionTypeId is not null)
	OR ([SchoolTypeId] = @SchoolTypeId AND @SchoolTypeId is not null)
	OR ([ProvinceId] = @ProvinceId AND @ProvinceId is not null)
	OR ([TownId] = @TownId AND @TownId is not null)
	OR ([Address] = @Address AND @Address is not null)
	OR ([Phone] = @Phone AND @Phone is not null)
	OR ([Fax] = @Fax AND @Fax is not null)
	OR ([WebAddress] = @WebAddress AND @WebAddress is not null)
	OR ([SchoolNotes] = @SchoolNotes AND @SchoolNotes is not null)
	OR ([CreateOn] = @CreateOn AND @CreateOn is not null)
	OR ([UpdateOn] = @UpdateOn AND @UpdateOn is not null)
	OR ([CreateUserId] = @CreateUserId AND @CreateUserId is not null)
	OR ([UpdateUserId] = @UpdateUserId AND @UpdateUserId is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_Reason_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_Reason_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_Reason_Get_List
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Gets all records from the Reason table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Reason_Get_List

AS


				
				SELECT
					[ReasonId],
					[ReasonKey],
					[ReasonValue]
				FROM
					[dbo].[Reason]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_Reason_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_Reason_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_Reason_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Gets records from the Reason table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Reason_GetPaged
(

	@WhereClause varchar (8000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy IS NULL OR LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[ReasonId]'
				END

				-- SQL Server 2005 Paging
				DECLARE @SQL AS nvarchar(MAX)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [ReasonId]'
				SET @SQL = @SQL + ', [ReasonKey]'
				SET @SQL = @SQL + ', [ReasonValue]'
				SET @SQL = @SQL + ' FROM [dbo].[Reason]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [ReasonId],'
				SET @SQL = @SQL + ' [ReasonKey],'
				SET @SQL = @SQL + ' [ReasonValue]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + CONVERT(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				EXEC sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(1) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[Reason]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_Reason_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_Reason_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_Reason_Insert
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Inserts a record into the Reason table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Reason_Insert
(

	@ReasonId int    OUTPUT,

	@ReasonKey int   ,

	@ReasonValue nvarchar (300)  
)
AS


				
				INSERT INTO [dbo].[Reason]
					(
					[ReasonKey]
					,[ReasonValue]
					)
				VALUES
					(
					@ReasonKey
					,@ReasonValue
					)
				-- Get the identity value
				SET @ReasonId = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_Reason_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_Reason_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_Reason_Update
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Updates a record in the Reason table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Reason_Update
(

	@ReasonId int   ,

	@ReasonKey int   ,

	@ReasonValue nvarchar (300)  
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[Reason]
				SET
					[ReasonKey] = @ReasonKey
					,[ReasonValue] = @ReasonValue
				WHERE
[ReasonId] = @ReasonId 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_Reason_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_Reason_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_Reason_Delete
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Deletes a record in the Reason table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Reason_Delete
(

	@ReasonId int   
)
AS


				DELETE FROM [dbo].[Reason] WITH (ROWLOCK) 
				WHERE
					[ReasonId] = @ReasonId
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_Reason_GetByReasonKey procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_Reason_GetByReasonKey') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_Reason_GetByReasonKey
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Select records from the Reason table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Reason_GetByReasonKey
(

	@ReasonKey int   
)
AS


				SELECT
					[ReasonId],
					[ReasonKey],
					[ReasonValue]
				FROM
					[dbo].[Reason]
				WHERE
					[ReasonKey] = @ReasonKey
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_Reason_GetByReasonId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_Reason_GetByReasonId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_Reason_GetByReasonId
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Select records from the Reason table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Reason_GetByReasonId
(

	@ReasonId int   
)
AS


				SELECT
					[ReasonId],
					[ReasonKey],
					[ReasonValue]
				FROM
					[dbo].[Reason]
				WHERE
					[ReasonId] = @ReasonId
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_Reason_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_Reason_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_Reason_Find
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Finds records in the Reason table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Reason_Find
(

	@SearchUsingOR bit   = null ,

	@ReasonId int   = null ,

	@ReasonKey int   = null ,

	@ReasonValue nvarchar (300)  = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [ReasonId]
	, [ReasonKey]
	, [ReasonValue]
    FROM
	[dbo].[Reason]
    WHERE 
	 ([ReasonId] = @ReasonId OR @ReasonId IS NULL)
	AND ([ReasonKey] = @ReasonKey OR @ReasonKey IS NULL)
	AND ([ReasonValue] = @ReasonValue OR @ReasonValue IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [ReasonId]
	, [ReasonKey]
	, [ReasonValue]
    FROM
	[dbo].[Reason]
    WHERE 
	 ([ReasonId] = @ReasonId AND @ReasonId is not null)
	OR ([ReasonKey] = @ReasonKey AND @ReasonKey is not null)
	OR ([ReasonValue] = @ReasonValue AND @ReasonValue is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_QuestionForm_Group_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_QuestionForm_Group_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_QuestionForm_Group_Get_List
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Gets all records from the QuestionForm_Group table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_QuestionForm_Group_Get_List

AS


				
				SELECT
					[GroupID],
					[GroupName],
					[LineNumber]
				FROM
					[dbo].[QuestionForm_Group]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_QuestionForm_Group_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_QuestionForm_Group_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_QuestionForm_Group_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Gets records from the QuestionForm_Group table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_QuestionForm_Group_GetPaged
(

	@WhereClause varchar (8000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy IS NULL OR LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[GroupID]'
				END

				-- SQL Server 2005 Paging
				DECLARE @SQL AS nvarchar(MAX)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [GroupID]'
				SET @SQL = @SQL + ', [GroupName]'
				SET @SQL = @SQL + ', [LineNumber]'
				SET @SQL = @SQL + ' FROM [dbo].[QuestionForm_Group]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [GroupID],'
				SET @SQL = @SQL + ' [GroupName],'
				SET @SQL = @SQL + ' [LineNumber]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + CONVERT(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				EXEC sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(1) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[QuestionForm_Group]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_QuestionForm_Group_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_QuestionForm_Group_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_QuestionForm_Group_Insert
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Inserts a record into the QuestionForm_Group table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_QuestionForm_Group_Insert
(

	@GroupId int    OUTPUT,

	@GroupName varchar (250)  ,

	@LineNumber int   
)
AS


				
				INSERT INTO [dbo].[QuestionForm_Group]
					(
					[GroupName]
					,[LineNumber]
					)
				VALUES
					(
					@GroupName
					,@LineNumber
					)
				-- Get the identity value
				SET @GroupId = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_QuestionForm_Group_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_QuestionForm_Group_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_QuestionForm_Group_Update
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Updates a record in the QuestionForm_Group table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_QuestionForm_Group_Update
(

	@GroupId int   ,

	@GroupName varchar (250)  ,

	@LineNumber int   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[QuestionForm_Group]
				SET
					[GroupName] = @GroupName
					,[LineNumber] = @LineNumber
				WHERE
[GroupID] = @GroupId 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_QuestionForm_Group_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_QuestionForm_Group_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_QuestionForm_Group_Delete
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Deletes a record in the QuestionForm_Group table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_QuestionForm_Group_Delete
(

	@GroupId int   
)
AS


				DELETE FROM [dbo].[QuestionForm_Group] WITH (ROWLOCK) 
				WHERE
					[GroupID] = @GroupId
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_QuestionForm_Group_GetByGroupId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_QuestionForm_Group_GetByGroupId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_QuestionForm_Group_GetByGroupId
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Select records from the QuestionForm_Group table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_QuestionForm_Group_GetByGroupId
(

	@GroupId int   
)
AS


				SELECT
					[GroupID],
					[GroupName],
					[LineNumber]
				FROM
					[dbo].[QuestionForm_Group]
				WHERE
					[GroupID] = @GroupId
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_QuestionForm_Group_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_QuestionForm_Group_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_QuestionForm_Group_Find
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Finds records in the QuestionForm_Group table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_QuestionForm_Group_Find
(

	@SearchUsingOR bit   = null ,

	@GroupId int   = null ,

	@GroupName varchar (250)  = null ,

	@LineNumber int   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [GroupID]
	, [GroupName]
	, [LineNumber]
    FROM
	[dbo].[QuestionForm_Group]
    WHERE 
	 ([GroupID] = @GroupId OR @GroupId IS NULL)
	AND ([GroupName] = @GroupName OR @GroupName IS NULL)
	AND ([LineNumber] = @LineNumber OR @LineNumber IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [GroupID]
	, [GroupName]
	, [LineNumber]
    FROM
	[dbo].[QuestionForm_Group]
    WHERE 
	 ([GroupID] = @GroupId AND @GroupId is not null)
	OR ([GroupName] = @GroupName AND @GroupName is not null)
	OR ([LineNumber] = @LineNumber AND @LineNumber is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_SeanceQuestion_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_SeanceQuestion_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_SeanceQuestion_Get_List
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Gets all records from the SeanceQuestion table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_SeanceQuestion_Get_List

AS


				
				SELECT
					[QuestionId],
					[QuestionRef],
					[QuestionName],
					[LineNumber],
					[Status]
				FROM
					[dbo].[SeanceQuestion]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_SeanceQuestion_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_SeanceQuestion_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_SeanceQuestion_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Gets records from the SeanceQuestion table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_SeanceQuestion_GetPaged
(

	@WhereClause varchar (8000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy IS NULL OR LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[QuestionId]'
				END

				-- SQL Server 2005 Paging
				DECLARE @SQL AS nvarchar(MAX)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [QuestionId]'
				SET @SQL = @SQL + ', [QuestionRef]'
				SET @SQL = @SQL + ', [QuestionName]'
				SET @SQL = @SQL + ', [LineNumber]'
				SET @SQL = @SQL + ', [Status]'
				SET @SQL = @SQL + ' FROM [dbo].[SeanceQuestion]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [QuestionId],'
				SET @SQL = @SQL + ' [QuestionRef],'
				SET @SQL = @SQL + ' [QuestionName],'
				SET @SQL = @SQL + ' [LineNumber],'
				SET @SQL = @SQL + ' [Status]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + CONVERT(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				EXEC sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(1) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[SeanceQuestion]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_SeanceQuestion_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_SeanceQuestion_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_SeanceQuestion_Insert
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Inserts a record into the SeanceQuestion table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_SeanceQuestion_Insert
(

	@QuestionId int    OUTPUT,

	@QuestionRef varchar (10)  ,

	@QuestionName varchar (500)  ,

	@LineNumber int   ,

	@Status bit   
)
AS


				
				INSERT INTO [dbo].[SeanceQuestion]
					(
					[QuestionRef]
					,[QuestionName]
					,[LineNumber]
					,[Status]
					)
				VALUES
					(
					@QuestionRef
					,@QuestionName
					,@LineNumber
					,@Status
					)
				-- Get the identity value
				SET @QuestionId = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_SeanceQuestion_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_SeanceQuestion_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_SeanceQuestion_Update
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Updates a record in the SeanceQuestion table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_SeanceQuestion_Update
(

	@QuestionId int   ,

	@QuestionRef varchar (10)  ,

	@QuestionName varchar (500)  ,

	@LineNumber int   ,

	@Status bit   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[SeanceQuestion]
				SET
					[QuestionRef] = @QuestionRef
					,[QuestionName] = @QuestionName
					,[LineNumber] = @LineNumber
					,[Status] = @Status
				WHERE
[QuestionId] = @QuestionId 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_SeanceQuestion_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_SeanceQuestion_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_SeanceQuestion_Delete
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Deletes a record in the SeanceQuestion table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_SeanceQuestion_Delete
(

	@QuestionId int   
)
AS


				DELETE FROM [dbo].[SeanceQuestion] WITH (ROWLOCK) 
				WHERE
					[QuestionId] = @QuestionId
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_SeanceQuestion_GetByQuestionId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_SeanceQuestion_GetByQuestionId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_SeanceQuestion_GetByQuestionId
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Select records from the SeanceQuestion table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_SeanceQuestion_GetByQuestionId
(

	@QuestionId int   
)
AS


				SELECT
					[QuestionId],
					[QuestionRef],
					[QuestionName],
					[LineNumber],
					[Status]
				FROM
					[dbo].[SeanceQuestion]
				WHERE
					[QuestionId] = @QuestionId
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_SeanceQuestion_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_SeanceQuestion_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_SeanceQuestion_Find
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Finds records in the SeanceQuestion table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_SeanceQuestion_Find
(

	@SearchUsingOR bit   = null ,

	@QuestionId int   = null ,

	@QuestionRef varchar (10)  = null ,

	@QuestionName varchar (500)  = null ,

	@LineNumber int   = null ,

	@Status bit   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [QuestionId]
	, [QuestionRef]
	, [QuestionName]
	, [LineNumber]
	, [Status]
    FROM
	[dbo].[SeanceQuestion]
    WHERE 
	 ([QuestionId] = @QuestionId OR @QuestionId IS NULL)
	AND ([QuestionRef] = @QuestionRef OR @QuestionRef IS NULL)
	AND ([QuestionName] = @QuestionName OR @QuestionName IS NULL)
	AND ([LineNumber] = @LineNumber OR @LineNumber IS NULL)
	AND ([Status] = @Status OR @Status IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [QuestionId]
	, [QuestionRef]
	, [QuestionName]
	, [LineNumber]
	, [Status]
    FROM
	[dbo].[SeanceQuestion]
    WHERE 
	 ([QuestionId] = @QuestionId AND @QuestionId is not null)
	OR ([QuestionRef] = @QuestionRef AND @QuestionRef is not null)
	OR ([QuestionName] = @QuestionName AND @QuestionName is not null)
	OR ([LineNumber] = @LineNumber AND @LineNumber is not null)
	OR ([Status] = @Status AND @Status is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_SeanceQuestion_Option_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_SeanceQuestion_Option_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_SeanceQuestion_Option_Get_List
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Gets all records from the SeanceQuestion_Option table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_SeanceQuestion_Option_Get_List

AS


				
				SELECT
					[OptionId],
					[QuestionId],
					[OptionName]
				FROM
					[dbo].[SeanceQuestion_Option]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_SeanceQuestion_Option_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_SeanceQuestion_Option_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_SeanceQuestion_Option_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Gets records from the SeanceQuestion_Option table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_SeanceQuestion_Option_GetPaged
(

	@WhereClause varchar (8000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy IS NULL OR LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[OptionId]'
				END

				-- SQL Server 2005 Paging
				DECLARE @SQL AS nvarchar(MAX)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [OptionId]'
				SET @SQL = @SQL + ', [QuestionId]'
				SET @SQL = @SQL + ', [OptionName]'
				SET @SQL = @SQL + ' FROM [dbo].[SeanceQuestion_Option]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [OptionId],'
				SET @SQL = @SQL + ' [QuestionId],'
				SET @SQL = @SQL + ' [OptionName]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + CONVERT(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				EXEC sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(1) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[SeanceQuestion_Option]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_SeanceQuestion_Option_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_SeanceQuestion_Option_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_SeanceQuestion_Option_Insert
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Inserts a record into the SeanceQuestion_Option table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_SeanceQuestion_Option_Insert
(

	@OptionId int    OUTPUT,

	@QuestionId int   ,

	@OptionName varchar (300)  
)
AS


				
				INSERT INTO [dbo].[SeanceQuestion_Option]
					(
					[QuestionId]
					,[OptionName]
					)
				VALUES
					(
					@QuestionId
					,@OptionName
					)
				-- Get the identity value
				SET @OptionId = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_SeanceQuestion_Option_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_SeanceQuestion_Option_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_SeanceQuestion_Option_Update
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Updates a record in the SeanceQuestion_Option table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_SeanceQuestion_Option_Update
(

	@OptionId int   ,

	@QuestionId int   ,

	@OptionName varchar (300)  
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[SeanceQuestion_Option]
				SET
					[QuestionId] = @QuestionId
					,[OptionName] = @OptionName
				WHERE
[OptionId] = @OptionId 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_SeanceQuestion_Option_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_SeanceQuestion_Option_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_SeanceQuestion_Option_Delete
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Deletes a record in the SeanceQuestion_Option table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_SeanceQuestion_Option_Delete
(

	@OptionId int   
)
AS


				DELETE FROM [dbo].[SeanceQuestion_Option] WITH (ROWLOCK) 
				WHERE
					[OptionId] = @OptionId
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_SeanceQuestion_Option_GetByQuestionId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_SeanceQuestion_Option_GetByQuestionId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_SeanceQuestion_Option_GetByQuestionId
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Select records from the SeanceQuestion_Option table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_SeanceQuestion_Option_GetByQuestionId
(

	@QuestionId int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[OptionId],
					[QuestionId],
					[OptionName]
				FROM
					[dbo].[SeanceQuestion_Option]
				WHERE
					[QuestionId] = @QuestionId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_SeanceQuestion_Option_GetByOptionId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_SeanceQuestion_Option_GetByOptionId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_SeanceQuestion_Option_GetByOptionId
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Select records from the SeanceQuestion_Option table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_SeanceQuestion_Option_GetByOptionId
(

	@OptionId int   
)
AS


				SELECT
					[OptionId],
					[QuestionId],
					[OptionName]
				FROM
					[dbo].[SeanceQuestion_Option]
				WHERE
					[OptionId] = @OptionId
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_SeanceQuestion_Option_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_SeanceQuestion_Option_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_SeanceQuestion_Option_Find
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Finds records in the SeanceQuestion_Option table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_SeanceQuestion_Option_Find
(

	@SearchUsingOR bit   = null ,

	@OptionId int   = null ,

	@QuestionId int   = null ,

	@OptionName varchar (300)  = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [OptionId]
	, [QuestionId]
	, [OptionName]
    FROM
	[dbo].[SeanceQuestion_Option]
    WHERE 
	 ([OptionId] = @OptionId OR @OptionId IS NULL)
	AND ([QuestionId] = @QuestionId OR @QuestionId IS NULL)
	AND ([OptionName] = @OptionName OR @OptionName IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [OptionId]
	, [QuestionId]
	, [OptionName]
    FROM
	[dbo].[SeanceQuestion_Option]
    WHERE 
	 ([OptionId] = @OptionId AND @OptionId is not null)
	OR ([QuestionId] = @QuestionId AND @QuestionId is not null)
	OR ([OptionName] = @OptionName AND @OptionName is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_Town_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_Town_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_Town_Get_List
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Gets all records from the Town table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Town_Get_List

AS


				
				SELECT
					[Id],
					[RowNumber],
					[AdminId],
					[ObjectId],
					[ParentId],
					[ProvinceId],
					[TownName],
					[Longitude],
					[Latitude],
					[Type],
					[CreateDate],
					[CreateTime],
					[UpdateDate],
					[UpdateTime]
				FROM
					[dbo].[Town]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_Town_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_Town_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_Town_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Gets records from the Town table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Town_GetPaged
(

	@WhereClause varchar (8000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy IS NULL OR LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[Id]'
				END

				-- SQL Server 2005 Paging
				DECLARE @SQL AS nvarchar(MAX)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [Id]'
				SET @SQL = @SQL + ', [RowNumber]'
				SET @SQL = @SQL + ', [AdminId]'
				SET @SQL = @SQL + ', [ObjectId]'
				SET @SQL = @SQL + ', [ParentId]'
				SET @SQL = @SQL + ', [ProvinceId]'
				SET @SQL = @SQL + ', [TownName]'
				SET @SQL = @SQL + ', [Longitude]'
				SET @SQL = @SQL + ', [Latitude]'
				SET @SQL = @SQL + ', [Type]'
				SET @SQL = @SQL + ', [CreateDate]'
				SET @SQL = @SQL + ', [CreateTime]'
				SET @SQL = @SQL + ', [UpdateDate]'
				SET @SQL = @SQL + ', [UpdateTime]'
				SET @SQL = @SQL + ' FROM [dbo].[Town]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [Id],'
				SET @SQL = @SQL + ' [RowNumber],'
				SET @SQL = @SQL + ' [AdminId],'
				SET @SQL = @SQL + ' [ObjectId],'
				SET @SQL = @SQL + ' [ParentId],'
				SET @SQL = @SQL + ' [ProvinceId],'
				SET @SQL = @SQL + ' [TownName],'
				SET @SQL = @SQL + ' [Longitude],'
				SET @SQL = @SQL + ' [Latitude],'
				SET @SQL = @SQL + ' [Type],'
				SET @SQL = @SQL + ' [CreateDate],'
				SET @SQL = @SQL + ' [CreateTime],'
				SET @SQL = @SQL + ' [UpdateDate],'
				SET @SQL = @SQL + ' [UpdateTime]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + CONVERT(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				EXEC sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(1) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[Town]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_Town_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_Town_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_Town_Insert
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Inserts a record into the Town table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Town_Insert
(

	@Id int    OUTPUT,

	@RowNumber int   ,

	@AdminId bigint   ,

	@ObjectId bigint   ,

	@ParentId bigint   ,

	@ProvinceId int   ,

	@TownName nvarchar (250)  ,

	@Longitude varchar (10)  ,

	@Latitude varchar (10)  ,

	@Type int   ,

	@CreateDate date   ,

	@CreateTime time   ,

	@UpdateDate date   ,

	@UpdateTime time   
)
AS


				
				INSERT INTO [dbo].[Town]
					(
					[RowNumber]
					,[AdminId]
					,[ObjectId]
					,[ParentId]
					,[ProvinceId]
					,[TownName]
					,[Longitude]
					,[Latitude]
					,[Type]
					,[CreateDate]
					,[CreateTime]
					,[UpdateDate]
					,[UpdateTime]
					)
				VALUES
					(
					@RowNumber
					,@AdminId
					,@ObjectId
					,@ParentId
					,@ProvinceId
					,@TownName
					,@Longitude
					,@Latitude
					,@Type
					,@CreateDate
					,@CreateTime
					,@UpdateDate
					,@UpdateTime
					)
				-- Get the identity value
				SET @Id = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_Town_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_Town_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_Town_Update
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Updates a record in the Town table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Town_Update
(

	@Id int   ,

	@RowNumber int   ,

	@AdminId bigint   ,

	@ObjectId bigint   ,

	@ParentId bigint   ,

	@ProvinceId int   ,

	@TownName nvarchar (250)  ,

	@Longitude varchar (10)  ,

	@Latitude varchar (10)  ,

	@Type int   ,

	@CreateDate date   ,

	@CreateTime time   ,

	@UpdateDate date   ,

	@UpdateTime time   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[Town]
				SET
					[RowNumber] = @RowNumber
					,[AdminId] = @AdminId
					,[ObjectId] = @ObjectId
					,[ParentId] = @ParentId
					,[ProvinceId] = @ProvinceId
					,[TownName] = @TownName
					,[Longitude] = @Longitude
					,[Latitude] = @Latitude
					,[Type] = @Type
					,[CreateDate] = @CreateDate
					,[CreateTime] = @CreateTime
					,[UpdateDate] = @UpdateDate
					,[UpdateTime] = @UpdateTime
				WHERE
[Id] = @Id 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_Town_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_Town_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_Town_Delete
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Deletes a record in the Town table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Town_Delete
(

	@Id int   
)
AS


				DELETE FROM [dbo].[Town] WITH (ROWLOCK) 
				WHERE
					[Id] = @Id
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_Town_GetByProvinceId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_Town_GetByProvinceId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_Town_GetByProvinceId
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Select records from the Town table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Town_GetByProvinceId
(

	@ProvinceId int   
)
AS


				SELECT
					[Id],
					[RowNumber],
					[AdminId],
					[ObjectId],
					[ParentId],
					[ProvinceId],
					[TownName],
					[Longitude],
					[Latitude],
					[Type],
					[CreateDate],
					[CreateTime],
					[UpdateDate],
					[UpdateTime]
				FROM
					[dbo].[Town]
				WHERE
					[ProvinceId] = @ProvinceId
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_Town_GetById procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_Town_GetById') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_Town_GetById
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Select records from the Town table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Town_GetById
(

	@Id int   
)
AS


				SELECT
					[Id],
					[RowNumber],
					[AdminId],
					[ObjectId],
					[ParentId],
					[ProvinceId],
					[TownName],
					[Longitude],
					[Latitude],
					[Type],
					[CreateDate],
					[CreateTime],
					[UpdateDate],
					[UpdateTime]
				FROM
					[dbo].[Town]
				WHERE
					[Id] = @Id
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_Town_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_Town_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_Town_Find
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Finds records in the Town table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Town_Find
(

	@SearchUsingOR bit   = null ,

	@Id int   = null ,

	@RowNumber int   = null ,

	@AdminId bigint   = null ,

	@ObjectId bigint   = null ,

	@ParentId bigint   = null ,

	@ProvinceId int   = null ,

	@TownName nvarchar (250)  = null ,

	@Longitude varchar (10)  = null ,

	@Latitude varchar (10)  = null ,

	@Type int   = null ,

	@CreateDate date   = null ,

	@CreateTime time   = null ,

	@UpdateDate date   = null ,

	@UpdateTime time   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [Id]
	, [RowNumber]
	, [AdminId]
	, [ObjectId]
	, [ParentId]
	, [ProvinceId]
	, [TownName]
	, [Longitude]
	, [Latitude]
	, [Type]
	, [CreateDate]
	, [CreateTime]
	, [UpdateDate]
	, [UpdateTime]
    FROM
	[dbo].[Town]
    WHERE 
	 ([Id] = @Id OR @Id IS NULL)
	AND ([RowNumber] = @RowNumber OR @RowNumber IS NULL)
	AND ([AdminId] = @AdminId OR @AdminId IS NULL)
	AND ([ObjectId] = @ObjectId OR @ObjectId IS NULL)
	AND ([ParentId] = @ParentId OR @ParentId IS NULL)
	AND ([ProvinceId] = @ProvinceId OR @ProvinceId IS NULL)
	AND ([TownName] = @TownName OR @TownName IS NULL)
	AND ([Longitude] = @Longitude OR @Longitude IS NULL)
	AND ([Latitude] = @Latitude OR @Latitude IS NULL)
	AND ([Type] = @Type OR @Type IS NULL)
	AND ([CreateDate] = @CreateDate OR @CreateDate IS NULL)
	AND ([CreateTime] = @CreateTime OR @CreateTime IS NULL)
	AND ([UpdateDate] = @UpdateDate OR @UpdateDate IS NULL)
	AND ([UpdateTime] = @UpdateTime OR @UpdateTime IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [Id]
	, [RowNumber]
	, [AdminId]
	, [ObjectId]
	, [ParentId]
	, [ProvinceId]
	, [TownName]
	, [Longitude]
	, [Latitude]
	, [Type]
	, [CreateDate]
	, [CreateTime]
	, [UpdateDate]
	, [UpdateTime]
    FROM
	[dbo].[Town]
    WHERE 
	 ([Id] = @Id AND @Id is not null)
	OR ([RowNumber] = @RowNumber AND @RowNumber is not null)
	OR ([AdminId] = @AdminId AND @AdminId is not null)
	OR ([ObjectId] = @ObjectId AND @ObjectId is not null)
	OR ([ParentId] = @ParentId AND @ParentId is not null)
	OR ([ProvinceId] = @ProvinceId AND @ProvinceId is not null)
	OR ([TownName] = @TownName AND @TownName is not null)
	OR ([Longitude] = @Longitude AND @Longitude is not null)
	OR ([Latitude] = @Latitude AND @Latitude is not null)
	OR ([Type] = @Type AND @Type is not null)
	OR ([CreateDate] = @CreateDate AND @CreateDate is not null)
	OR ([CreateTime] = @CreateTime AND @CreateTime is not null)
	OR ([UpdateDate] = @UpdateDate AND @UpdateDate is not null)
	OR ([UpdateTime] = @UpdateTime AND @UpdateTime is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_SeanceQuestion_Answer_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_SeanceQuestion_Answer_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_SeanceQuestion_Answer_Get_List
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Gets all records from the SeanceQuestion_Answer table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_SeanceQuestion_Answer_Get_List

AS


				
				SELECT
					[RowId],
					[ClientId],
					[QuestionId],
					[OptionId],
					[CreateOn],
					[UpdateOn]
				FROM
					[dbo].[SeanceQuestion_Answer]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_SeanceQuestion_Answer_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_SeanceQuestion_Answer_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_SeanceQuestion_Answer_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Gets records from the SeanceQuestion_Answer table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_SeanceQuestion_Answer_GetPaged
(

	@WhereClause varchar (8000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy IS NULL OR LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[RowId]'
				END

				-- SQL Server 2005 Paging
				DECLARE @SQL AS nvarchar(MAX)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [RowId]'
				SET @SQL = @SQL + ', [ClientId]'
				SET @SQL = @SQL + ', [QuestionId]'
				SET @SQL = @SQL + ', [OptionId]'
				SET @SQL = @SQL + ', [CreateOn]'
				SET @SQL = @SQL + ', [UpdateOn]'
				SET @SQL = @SQL + ' FROM [dbo].[SeanceQuestion_Answer]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [RowId],'
				SET @SQL = @SQL + ' [ClientId],'
				SET @SQL = @SQL + ' [QuestionId],'
				SET @SQL = @SQL + ' [OptionId],'
				SET @SQL = @SQL + ' [CreateOn],'
				SET @SQL = @SQL + ' [UpdateOn]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + CONVERT(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				EXEC sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(1) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[SeanceQuestion_Answer]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_SeanceQuestion_Answer_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_SeanceQuestion_Answer_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_SeanceQuestion_Answer_Insert
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Inserts a record into the SeanceQuestion_Answer table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_SeanceQuestion_Answer_Insert
(

	@RowId int    OUTPUT,

	@ClientId int   ,

	@QuestionId int   ,

	@OptionId int   ,

	@CreateOn smalldatetime   ,

	@UpdateOn smalldatetime   
)
AS


				
				INSERT INTO [dbo].[SeanceQuestion_Answer]
					(
					[ClientId]
					,[QuestionId]
					,[OptionId]
					,[CreateOn]
					,[UpdateOn]
					)
				VALUES
					(
					@ClientId
					,@QuestionId
					,@OptionId
					,@CreateOn
					,@UpdateOn
					)
				-- Get the identity value
				SET @RowId = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_SeanceQuestion_Answer_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_SeanceQuestion_Answer_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_SeanceQuestion_Answer_Update
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Updates a record in the SeanceQuestion_Answer table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_SeanceQuestion_Answer_Update
(

	@RowId int   ,

	@ClientId int   ,

	@QuestionId int   ,

	@OptionId int   ,

	@CreateOn smalldatetime   ,

	@UpdateOn smalldatetime   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[SeanceQuestion_Answer]
				SET
					[ClientId] = @ClientId
					,[QuestionId] = @QuestionId
					,[OptionId] = @OptionId
					,[CreateOn] = @CreateOn
					,[UpdateOn] = @UpdateOn
				WHERE
[RowId] = @RowId 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_SeanceQuestion_Answer_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_SeanceQuestion_Answer_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_SeanceQuestion_Answer_Delete
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Deletes a record in the SeanceQuestion_Answer table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_SeanceQuestion_Answer_Delete
(

	@RowId int   
)
AS


				DELETE FROM [dbo].[SeanceQuestion_Answer] WITH (ROWLOCK) 
				WHERE
					[RowId] = @RowId
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_SeanceQuestion_Answer_GetByClientId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_SeanceQuestion_Answer_GetByClientId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_SeanceQuestion_Answer_GetByClientId
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Select records from the SeanceQuestion_Answer table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_SeanceQuestion_Answer_GetByClientId
(

	@ClientId int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[RowId],
					[ClientId],
					[QuestionId],
					[OptionId],
					[CreateOn],
					[UpdateOn]
				FROM
					[dbo].[SeanceQuestion_Answer]
				WHERE
					[ClientId] = @ClientId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_SeanceQuestion_Answer_GetByQuestionId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_SeanceQuestion_Answer_GetByQuestionId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_SeanceQuestion_Answer_GetByQuestionId
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Select records from the SeanceQuestion_Answer table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_SeanceQuestion_Answer_GetByQuestionId
(

	@QuestionId int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[RowId],
					[ClientId],
					[QuestionId],
					[OptionId],
					[CreateOn],
					[UpdateOn]
				FROM
					[dbo].[SeanceQuestion_Answer]
				WHERE
					[QuestionId] = @QuestionId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_SeanceQuestion_Answer_GetByOptionId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_SeanceQuestion_Answer_GetByOptionId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_SeanceQuestion_Answer_GetByOptionId
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Select records from the SeanceQuestion_Answer table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_SeanceQuestion_Answer_GetByOptionId
(

	@OptionId int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[RowId],
					[ClientId],
					[QuestionId],
					[OptionId],
					[CreateOn],
					[UpdateOn]
				FROM
					[dbo].[SeanceQuestion_Answer]
				WHERE
					[OptionId] = @OptionId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_SeanceQuestion_Answer_GetByRowId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_SeanceQuestion_Answer_GetByRowId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_SeanceQuestion_Answer_GetByRowId
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Select records from the SeanceQuestion_Answer table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_SeanceQuestion_Answer_GetByRowId
(

	@RowId int   
)
AS


				SELECT
					[RowId],
					[ClientId],
					[QuestionId],
					[OptionId],
					[CreateOn],
					[UpdateOn]
				FROM
					[dbo].[SeanceQuestion_Answer]
				WHERE
					[RowId] = @RowId
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_SeanceQuestion_Answer_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_SeanceQuestion_Answer_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_SeanceQuestion_Answer_Find
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Finds records in the SeanceQuestion_Answer table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_SeanceQuestion_Answer_Find
(

	@SearchUsingOR bit   = null ,

	@RowId int   = null ,

	@ClientId int   = null ,

	@QuestionId int   = null ,

	@OptionId int   = null ,

	@CreateOn smalldatetime   = null ,

	@UpdateOn smalldatetime   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [RowId]
	, [ClientId]
	, [QuestionId]
	, [OptionId]
	, [CreateOn]
	, [UpdateOn]
    FROM
	[dbo].[SeanceQuestion_Answer]
    WHERE 
	 ([RowId] = @RowId OR @RowId IS NULL)
	AND ([ClientId] = @ClientId OR @ClientId IS NULL)
	AND ([QuestionId] = @QuestionId OR @QuestionId IS NULL)
	AND ([OptionId] = @OptionId OR @OptionId IS NULL)
	AND ([CreateOn] = @CreateOn OR @CreateOn IS NULL)
	AND ([UpdateOn] = @UpdateOn OR @UpdateOn IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [RowId]
	, [ClientId]
	, [QuestionId]
	, [OptionId]
	, [CreateOn]
	, [UpdateOn]
    FROM
	[dbo].[SeanceQuestion_Answer]
    WHERE 
	 ([RowId] = @RowId AND @RowId is not null)
	OR ([ClientId] = @ClientId AND @ClientId is not null)
	OR ([QuestionId] = @QuestionId AND @QuestionId is not null)
	OR ([OptionId] = @OptionId AND @OptionId is not null)
	OR ([CreateOn] = @CreateOn AND @CreateOn is not null)
	OR ([UpdateOn] = @UpdateOn AND @UpdateOn is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_Teacher_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_Teacher_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_Teacher_Get_List
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Gets all records from the Teacher table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Teacher_Get_List

AS


				
				SELECT
					[TeacherId],
					[SchoolId],
					[FirstName],
					[LastName],
					[Phone],
					[Gsm],
					[Email],
					[CreateOn],
					[UpdateOn],
					[CreateUserId],
					[UpdateUserId]
				FROM
					[dbo].[Teacher]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_Teacher_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_Teacher_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_Teacher_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Gets records from the Teacher table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Teacher_GetPaged
(

	@WhereClause varchar (8000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy IS NULL OR LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[TeacherId]'
				END

				-- SQL Server 2005 Paging
				DECLARE @SQL AS nvarchar(MAX)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [TeacherId]'
				SET @SQL = @SQL + ', [SchoolId]'
				SET @SQL = @SQL + ', [FirstName]'
				SET @SQL = @SQL + ', [LastName]'
				SET @SQL = @SQL + ', [Phone]'
				SET @SQL = @SQL + ', [Gsm]'
				SET @SQL = @SQL + ', [Email]'
				SET @SQL = @SQL + ', [CreateOn]'
				SET @SQL = @SQL + ', [UpdateOn]'
				SET @SQL = @SQL + ', [CreateUserId]'
				SET @SQL = @SQL + ', [UpdateUserId]'
				SET @SQL = @SQL + ' FROM [dbo].[Teacher]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [TeacherId],'
				SET @SQL = @SQL + ' [SchoolId],'
				SET @SQL = @SQL + ' [FirstName],'
				SET @SQL = @SQL + ' [LastName],'
				SET @SQL = @SQL + ' [Phone],'
				SET @SQL = @SQL + ' [Gsm],'
				SET @SQL = @SQL + ' [Email],'
				SET @SQL = @SQL + ' [CreateOn],'
				SET @SQL = @SQL + ' [UpdateOn],'
				SET @SQL = @SQL + ' [CreateUserId],'
				SET @SQL = @SQL + ' [UpdateUserId]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + CONVERT(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				EXEC sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(1) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[Teacher]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_Teacher_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_Teacher_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_Teacher_Insert
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Inserts a record into the Teacher table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Teacher_Insert
(

	@TeacherId int    OUTPUT,

	@SchoolId int   ,

	@FirstName varchar (100)  ,

	@LastName varchar (100)  ,

	@Phone varchar (15)  ,

	@Gsm varchar (15)  ,

	@Email varchar (50)  ,

	@CreateOn smalldatetime   ,

	@UpdateOn smalldatetime   ,

	@CreateUserId int   ,

	@UpdateUserId int   
)
AS


				
				INSERT INTO [dbo].[Teacher]
					(
					[SchoolId]
					,[FirstName]
					,[LastName]
					,[Phone]
					,[Gsm]
					,[Email]
					,[CreateOn]
					,[UpdateOn]
					,[CreateUserId]
					,[UpdateUserId]
					)
				VALUES
					(
					@SchoolId
					,@FirstName
					,@LastName
					,@Phone
					,@Gsm
					,@Email
					,@CreateOn
					,@UpdateOn
					,@CreateUserId
					,@UpdateUserId
					)
				-- Get the identity value
				SET @TeacherId = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_Teacher_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_Teacher_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_Teacher_Update
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Updates a record in the Teacher table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Teacher_Update
(

	@TeacherId int   ,

	@SchoolId int   ,

	@FirstName varchar (100)  ,

	@LastName varchar (100)  ,

	@Phone varchar (15)  ,

	@Gsm varchar (15)  ,

	@Email varchar (50)  ,

	@CreateOn smalldatetime   ,

	@UpdateOn smalldatetime   ,

	@CreateUserId int   ,

	@UpdateUserId int   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[Teacher]
				SET
					[SchoolId] = @SchoolId
					,[FirstName] = @FirstName
					,[LastName] = @LastName
					,[Phone] = @Phone
					,[Gsm] = @Gsm
					,[Email] = @Email
					,[CreateOn] = @CreateOn
					,[UpdateOn] = @UpdateOn
					,[CreateUserId] = @CreateUserId
					,[UpdateUserId] = @UpdateUserId
				WHERE
[TeacherId] = @TeacherId 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_Teacher_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_Teacher_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_Teacher_Delete
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Deletes a record in the Teacher table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Teacher_Delete
(

	@TeacherId int   
)
AS


				DELETE FROM [dbo].[Teacher] WITH (ROWLOCK) 
				WHERE
					[TeacherId] = @TeacherId
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_Teacher_GetBySchoolId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_Teacher_GetBySchoolId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_Teacher_GetBySchoolId
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Select records from the Teacher table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Teacher_GetBySchoolId
(

	@SchoolId int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[TeacherId],
					[SchoolId],
					[FirstName],
					[LastName],
					[Phone],
					[Gsm],
					[Email],
					[CreateOn],
					[UpdateOn],
					[CreateUserId],
					[UpdateUserId]
				FROM
					[dbo].[Teacher]
				WHERE
					[SchoolId] = @SchoolId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_Teacher_GetByTeacherId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_Teacher_GetByTeacherId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_Teacher_GetByTeacherId
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Select records from the Teacher table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Teacher_GetByTeacherId
(

	@TeacherId int   
)
AS


				SELECT
					[TeacherId],
					[SchoolId],
					[FirstName],
					[LastName],
					[Phone],
					[Gsm],
					[Email],
					[CreateOn],
					[UpdateOn],
					[CreateUserId],
					[UpdateUserId]
				FROM
					[dbo].[Teacher]
				WHERE
					[TeacherId] = @TeacherId
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_Teacher_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_Teacher_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_Teacher_Find
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Finds records in the Teacher table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Teacher_Find
(

	@SearchUsingOR bit   = null ,

	@TeacherId int   = null ,

	@SchoolId int   = null ,

	@FirstName varchar (100)  = null ,

	@LastName varchar (100)  = null ,

	@Phone varchar (15)  = null ,

	@Gsm varchar (15)  = null ,

	@Email varchar (50)  = null ,

	@CreateOn smalldatetime   = null ,

	@UpdateOn smalldatetime   = null ,

	@CreateUserId int   = null ,

	@UpdateUserId int   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [TeacherId]
	, [SchoolId]
	, [FirstName]
	, [LastName]
	, [Phone]
	, [Gsm]
	, [Email]
	, [CreateOn]
	, [UpdateOn]
	, [CreateUserId]
	, [UpdateUserId]
    FROM
	[dbo].[Teacher]
    WHERE 
	 ([TeacherId] = @TeacherId OR @TeacherId IS NULL)
	AND ([SchoolId] = @SchoolId OR @SchoolId IS NULL)
	AND ([FirstName] = @FirstName OR @FirstName IS NULL)
	AND ([LastName] = @LastName OR @LastName IS NULL)
	AND ([Phone] = @Phone OR @Phone IS NULL)
	AND ([Gsm] = @Gsm OR @Gsm IS NULL)
	AND ([Email] = @Email OR @Email IS NULL)
	AND ([CreateOn] = @CreateOn OR @CreateOn IS NULL)
	AND ([UpdateOn] = @UpdateOn OR @UpdateOn IS NULL)
	AND ([CreateUserId] = @CreateUserId OR @CreateUserId IS NULL)
	AND ([UpdateUserId] = @UpdateUserId OR @UpdateUserId IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [TeacherId]
	, [SchoolId]
	, [FirstName]
	, [LastName]
	, [Phone]
	, [Gsm]
	, [Email]
	, [CreateOn]
	, [UpdateOn]
	, [CreateUserId]
	, [UpdateUserId]
    FROM
	[dbo].[Teacher]
    WHERE 
	 ([TeacherId] = @TeacherId AND @TeacherId is not null)
	OR ([SchoolId] = @SchoolId AND @SchoolId is not null)
	OR ([FirstName] = @FirstName AND @FirstName is not null)
	OR ([LastName] = @LastName AND @LastName is not null)
	OR ([Phone] = @Phone AND @Phone is not null)
	OR ([Gsm] = @Gsm AND @Gsm is not null)
	OR ([Email] = @Email AND @Email is not null)
	OR ([CreateOn] = @CreateOn AND @CreateOn is not null)
	OR ([UpdateOn] = @UpdateOn AND @UpdateOn is not null)
	OR ([CreateUserId] = @CreateUserId AND @CreateUserId is not null)
	OR ([UpdateUserId] = @UpdateUserId AND @UpdateUserId is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_Wippsi_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_Wippsi_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_Wippsi_Get_List
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Gets all records from the Wippsi table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Wippsi_Get_List

AS


				
				SELECT
					[WippsiID],
					[GeneralRawScore],
					[GeneralStandartScore],
					[SimilarityRawScore],
					[SimilarityStandartScore],
					[ArithmeticRawScore],
					[ArithmeticStandartScore],
					[WordRawScore],
					[WordStandartScore],
					[UnderstandingRawScore],
					[UnderstandingStandartScore],
					[SentencesRawScore],
					[SentencesStandartScore],
					[ImageDefineRawScore],
					[ImageDefineStandartScore],
					[AnimalHomesRawScore],
					[AnimalHomesStandartScore],
					[GeometricShapeRawScore],
					[GeometricShapeStandartScore],
					[BlocksPatternRawScore],
					[BlocksPatternStandartScore],
					[AnimalHomesAgainRawScore],
					[AnimalHomesAgainStandartScore],
					[MazesRawScore],
					[MazesStandartScore],
					[TotalVerbalScore],
					[TotalPerformanceScore],
					[TotalScore],
					[TestDate],
					[CreateDate],
					[UpdateDate],
					[UserID],
					[AdvisorID]
				FROM
					[dbo].[Wippsi]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_Wippsi_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_Wippsi_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_Wippsi_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Gets records from the Wippsi table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Wippsi_GetPaged
(

	@WhereClause varchar (8000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy IS NULL OR LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[WippsiID]'
				END

				-- SQL Server 2005 Paging
				DECLARE @SQL AS nvarchar(MAX)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [WippsiID]'
				SET @SQL = @SQL + ', [GeneralRawScore]'
				SET @SQL = @SQL + ', [GeneralStandartScore]'
				SET @SQL = @SQL + ', [SimilarityRawScore]'
				SET @SQL = @SQL + ', [SimilarityStandartScore]'
				SET @SQL = @SQL + ', [ArithmeticRawScore]'
				SET @SQL = @SQL + ', [ArithmeticStandartScore]'
				SET @SQL = @SQL + ', [WordRawScore]'
				SET @SQL = @SQL + ', [WordStandartScore]'
				SET @SQL = @SQL + ', [UnderstandingRawScore]'
				SET @SQL = @SQL + ', [UnderstandingStandartScore]'
				SET @SQL = @SQL + ', [SentencesRawScore]'
				SET @SQL = @SQL + ', [SentencesStandartScore]'
				SET @SQL = @SQL + ', [ImageDefineRawScore]'
				SET @SQL = @SQL + ', [ImageDefineStandartScore]'
				SET @SQL = @SQL + ', [AnimalHomesRawScore]'
				SET @SQL = @SQL + ', [AnimalHomesStandartScore]'
				SET @SQL = @SQL + ', [GeometricShapeRawScore]'
				SET @SQL = @SQL + ', [GeometricShapeStandartScore]'
				SET @SQL = @SQL + ', [BlocksPatternRawScore]'
				SET @SQL = @SQL + ', [BlocksPatternStandartScore]'
				SET @SQL = @SQL + ', [AnimalHomesAgainRawScore]'
				SET @SQL = @SQL + ', [AnimalHomesAgainStandartScore]'
				SET @SQL = @SQL + ', [MazesRawScore]'
				SET @SQL = @SQL + ', [MazesStandartScore]'
				SET @SQL = @SQL + ', [TotalVerbalScore]'
				SET @SQL = @SQL + ', [TotalPerformanceScore]'
				SET @SQL = @SQL + ', [TotalScore]'
				SET @SQL = @SQL + ', [TestDate]'
				SET @SQL = @SQL + ', [CreateDate]'
				SET @SQL = @SQL + ', [UpdateDate]'
				SET @SQL = @SQL + ', [UserID]'
				SET @SQL = @SQL + ', [AdvisorID]'
				SET @SQL = @SQL + ' FROM [dbo].[Wippsi]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [WippsiID],'
				SET @SQL = @SQL + ' [GeneralRawScore],'
				SET @SQL = @SQL + ' [GeneralStandartScore],'
				SET @SQL = @SQL + ' [SimilarityRawScore],'
				SET @SQL = @SQL + ' [SimilarityStandartScore],'
				SET @SQL = @SQL + ' [ArithmeticRawScore],'
				SET @SQL = @SQL + ' [ArithmeticStandartScore],'
				SET @SQL = @SQL + ' [WordRawScore],'
				SET @SQL = @SQL + ' [WordStandartScore],'
				SET @SQL = @SQL + ' [UnderstandingRawScore],'
				SET @SQL = @SQL + ' [UnderstandingStandartScore],'
				SET @SQL = @SQL + ' [SentencesRawScore],'
				SET @SQL = @SQL + ' [SentencesStandartScore],'
				SET @SQL = @SQL + ' [ImageDefineRawScore],'
				SET @SQL = @SQL + ' [ImageDefineStandartScore],'
				SET @SQL = @SQL + ' [AnimalHomesRawScore],'
				SET @SQL = @SQL + ' [AnimalHomesStandartScore],'
				SET @SQL = @SQL + ' [GeometricShapeRawScore],'
				SET @SQL = @SQL + ' [GeometricShapeStandartScore],'
				SET @SQL = @SQL + ' [BlocksPatternRawScore],'
				SET @SQL = @SQL + ' [BlocksPatternStandartScore],'
				SET @SQL = @SQL + ' [AnimalHomesAgainRawScore],'
				SET @SQL = @SQL + ' [AnimalHomesAgainStandartScore],'
				SET @SQL = @SQL + ' [MazesRawScore],'
				SET @SQL = @SQL + ' [MazesStandartScore],'
				SET @SQL = @SQL + ' [TotalVerbalScore],'
				SET @SQL = @SQL + ' [TotalPerformanceScore],'
				SET @SQL = @SQL + ' [TotalScore],'
				SET @SQL = @SQL + ' [TestDate],'
				SET @SQL = @SQL + ' [CreateDate],'
				SET @SQL = @SQL + ' [UpdateDate],'
				SET @SQL = @SQL + ' [UserID],'
				SET @SQL = @SQL + ' [AdvisorID]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + CONVERT(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				EXEC sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(1) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[Wippsi]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_Wippsi_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_Wippsi_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_Wippsi_Insert
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Inserts a record into the Wippsi table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Wippsi_Insert
(

	@WippsiId int    OUTPUT,

	@GeneralRawScore int   ,

	@GeneralStandartScore int   ,

	@SimilarityRawScore int   ,

	@SimilarityStandartScore int   ,

	@ArithmeticRawScore int   ,

	@ArithmeticStandartScore int   ,

	@WordRawScore int   ,

	@WordStandartScore int   ,

	@UnderstandingRawScore int   ,

	@UnderstandingStandartScore int   ,

	@SentencesRawScore int   ,

	@SentencesStandartScore int   ,

	@ImageDefineRawScore int   ,

	@ImageDefineStandartScore int   ,

	@AnimalHomesRawScore int   ,

	@AnimalHomesStandartScore int   ,

	@GeometricShapeRawScore int   ,

	@GeometricShapeStandartScore int   ,

	@BlocksPatternRawScore int   ,

	@BlocksPatternStandartScore int   ,

	@AnimalHomesAgainRawScore int   ,

	@AnimalHomesAgainStandartScore int   ,

	@MazesRawScore int   ,

	@MazesStandartScore int   ,

	@TotalVerbalScore int   ,

	@TotalPerformanceScore int   ,

	@TotalScore int   ,

	@TestDate datetime   ,

	@CreateDate datetime   ,

	@UpdateDate datetime   ,

	@UserId int   ,

	@AdvisorId int   
)
AS


				
				INSERT INTO [dbo].[Wippsi]
					(
					[GeneralRawScore]
					,[GeneralStandartScore]
					,[SimilarityRawScore]
					,[SimilarityStandartScore]
					,[ArithmeticRawScore]
					,[ArithmeticStandartScore]
					,[WordRawScore]
					,[WordStandartScore]
					,[UnderstandingRawScore]
					,[UnderstandingStandartScore]
					,[SentencesRawScore]
					,[SentencesStandartScore]
					,[ImageDefineRawScore]
					,[ImageDefineStandartScore]
					,[AnimalHomesRawScore]
					,[AnimalHomesStandartScore]
					,[GeometricShapeRawScore]
					,[GeometricShapeStandartScore]
					,[BlocksPatternRawScore]
					,[BlocksPatternStandartScore]
					,[AnimalHomesAgainRawScore]
					,[AnimalHomesAgainStandartScore]
					,[MazesRawScore]
					,[MazesStandartScore]
					,[TotalVerbalScore]
					,[TotalPerformanceScore]
					,[TotalScore]
					,[TestDate]
					,[CreateDate]
					,[UpdateDate]
					,[UserID]
					,[AdvisorID]
					)
				VALUES
					(
					@GeneralRawScore
					,@GeneralStandartScore
					,@SimilarityRawScore
					,@SimilarityStandartScore
					,@ArithmeticRawScore
					,@ArithmeticStandartScore
					,@WordRawScore
					,@WordStandartScore
					,@UnderstandingRawScore
					,@UnderstandingStandartScore
					,@SentencesRawScore
					,@SentencesStandartScore
					,@ImageDefineRawScore
					,@ImageDefineStandartScore
					,@AnimalHomesRawScore
					,@AnimalHomesStandartScore
					,@GeometricShapeRawScore
					,@GeometricShapeStandartScore
					,@BlocksPatternRawScore
					,@BlocksPatternStandartScore
					,@AnimalHomesAgainRawScore
					,@AnimalHomesAgainStandartScore
					,@MazesRawScore
					,@MazesStandartScore
					,@TotalVerbalScore
					,@TotalPerformanceScore
					,@TotalScore
					,@TestDate
					,@CreateDate
					,@UpdateDate
					,@UserId
					,@AdvisorId
					)
				-- Get the identity value
				SET @WippsiId = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_Wippsi_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_Wippsi_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_Wippsi_Update
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Updates a record in the Wippsi table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Wippsi_Update
(

	@WippsiId int   ,

	@GeneralRawScore int   ,

	@GeneralStandartScore int   ,

	@SimilarityRawScore int   ,

	@SimilarityStandartScore int   ,

	@ArithmeticRawScore int   ,

	@ArithmeticStandartScore int   ,

	@WordRawScore int   ,

	@WordStandartScore int   ,

	@UnderstandingRawScore int   ,

	@UnderstandingStandartScore int   ,

	@SentencesRawScore int   ,

	@SentencesStandartScore int   ,

	@ImageDefineRawScore int   ,

	@ImageDefineStandartScore int   ,

	@AnimalHomesRawScore int   ,

	@AnimalHomesStandartScore int   ,

	@GeometricShapeRawScore int   ,

	@GeometricShapeStandartScore int   ,

	@BlocksPatternRawScore int   ,

	@BlocksPatternStandartScore int   ,

	@AnimalHomesAgainRawScore int   ,

	@AnimalHomesAgainStandartScore int   ,

	@MazesRawScore int   ,

	@MazesStandartScore int   ,

	@TotalVerbalScore int   ,

	@TotalPerformanceScore int   ,

	@TotalScore int   ,

	@TestDate datetime   ,

	@CreateDate datetime   ,

	@UpdateDate datetime   ,

	@UserId int   ,

	@AdvisorId int   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[Wippsi]
				SET
					[GeneralRawScore] = @GeneralRawScore
					,[GeneralStandartScore] = @GeneralStandartScore
					,[SimilarityRawScore] = @SimilarityRawScore
					,[SimilarityStandartScore] = @SimilarityStandartScore
					,[ArithmeticRawScore] = @ArithmeticRawScore
					,[ArithmeticStandartScore] = @ArithmeticStandartScore
					,[WordRawScore] = @WordRawScore
					,[WordStandartScore] = @WordStandartScore
					,[UnderstandingRawScore] = @UnderstandingRawScore
					,[UnderstandingStandartScore] = @UnderstandingStandartScore
					,[SentencesRawScore] = @SentencesRawScore
					,[SentencesStandartScore] = @SentencesStandartScore
					,[ImageDefineRawScore] = @ImageDefineRawScore
					,[ImageDefineStandartScore] = @ImageDefineStandartScore
					,[AnimalHomesRawScore] = @AnimalHomesRawScore
					,[AnimalHomesStandartScore] = @AnimalHomesStandartScore
					,[GeometricShapeRawScore] = @GeometricShapeRawScore
					,[GeometricShapeStandartScore] = @GeometricShapeStandartScore
					,[BlocksPatternRawScore] = @BlocksPatternRawScore
					,[BlocksPatternStandartScore] = @BlocksPatternStandartScore
					,[AnimalHomesAgainRawScore] = @AnimalHomesAgainRawScore
					,[AnimalHomesAgainStandartScore] = @AnimalHomesAgainStandartScore
					,[MazesRawScore] = @MazesRawScore
					,[MazesStandartScore] = @MazesStandartScore
					,[TotalVerbalScore] = @TotalVerbalScore
					,[TotalPerformanceScore] = @TotalPerformanceScore
					,[TotalScore] = @TotalScore
					,[TestDate] = @TestDate
					,[CreateDate] = @CreateDate
					,[UpdateDate] = @UpdateDate
					,[UserID] = @UserId
					,[AdvisorID] = @AdvisorId
				WHERE
[WippsiID] = @WippsiId 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_Wippsi_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_Wippsi_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_Wippsi_Delete
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Deletes a record in the Wippsi table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Wippsi_Delete
(

	@WippsiId int   
)
AS


				DELETE FROM [dbo].[Wippsi] WITH (ROWLOCK) 
				WHERE
					[WippsiID] = @WippsiId
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_Wippsi_GetByWippsiId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_Wippsi_GetByWippsiId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_Wippsi_GetByWippsiId
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Select records from the Wippsi table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Wippsi_GetByWippsiId
(

	@WippsiId int   
)
AS


				SELECT
					[WippsiID],
					[GeneralRawScore],
					[GeneralStandartScore],
					[SimilarityRawScore],
					[SimilarityStandartScore],
					[ArithmeticRawScore],
					[ArithmeticStandartScore],
					[WordRawScore],
					[WordStandartScore],
					[UnderstandingRawScore],
					[UnderstandingStandartScore],
					[SentencesRawScore],
					[SentencesStandartScore],
					[ImageDefineRawScore],
					[ImageDefineStandartScore],
					[AnimalHomesRawScore],
					[AnimalHomesStandartScore],
					[GeometricShapeRawScore],
					[GeometricShapeStandartScore],
					[BlocksPatternRawScore],
					[BlocksPatternStandartScore],
					[AnimalHomesAgainRawScore],
					[AnimalHomesAgainStandartScore],
					[MazesRawScore],
					[MazesStandartScore],
					[TotalVerbalScore],
					[TotalPerformanceScore],
					[TotalScore],
					[TestDate],
					[CreateDate],
					[UpdateDate],
					[UserID],
					[AdvisorID]
				FROM
					[dbo].[Wippsi]
				WHERE
					[WippsiID] = @WippsiId
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_Wippsi_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_Wippsi_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_Wippsi_Find
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Finds records in the Wippsi table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Wippsi_Find
(

	@SearchUsingOR bit   = null ,

	@WippsiId int   = null ,

	@GeneralRawScore int   = null ,

	@GeneralStandartScore int   = null ,

	@SimilarityRawScore int   = null ,

	@SimilarityStandartScore int   = null ,

	@ArithmeticRawScore int   = null ,

	@ArithmeticStandartScore int   = null ,

	@WordRawScore int   = null ,

	@WordStandartScore int   = null ,

	@UnderstandingRawScore int   = null ,

	@UnderstandingStandartScore int   = null ,

	@SentencesRawScore int   = null ,

	@SentencesStandartScore int   = null ,

	@ImageDefineRawScore int   = null ,

	@ImageDefineStandartScore int   = null ,

	@AnimalHomesRawScore int   = null ,

	@AnimalHomesStandartScore int   = null ,

	@GeometricShapeRawScore int   = null ,

	@GeometricShapeStandartScore int   = null ,

	@BlocksPatternRawScore int   = null ,

	@BlocksPatternStandartScore int   = null ,

	@AnimalHomesAgainRawScore int   = null ,

	@AnimalHomesAgainStandartScore int   = null ,

	@MazesRawScore int   = null ,

	@MazesStandartScore int   = null ,

	@TotalVerbalScore int   = null ,

	@TotalPerformanceScore int   = null ,

	@TotalScore int   = null ,

	@TestDate datetime   = null ,

	@CreateDate datetime   = null ,

	@UpdateDate datetime   = null ,

	@UserId int   = null ,

	@AdvisorId int   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [WippsiID]
	, [GeneralRawScore]
	, [GeneralStandartScore]
	, [SimilarityRawScore]
	, [SimilarityStandartScore]
	, [ArithmeticRawScore]
	, [ArithmeticStandartScore]
	, [WordRawScore]
	, [WordStandartScore]
	, [UnderstandingRawScore]
	, [UnderstandingStandartScore]
	, [SentencesRawScore]
	, [SentencesStandartScore]
	, [ImageDefineRawScore]
	, [ImageDefineStandartScore]
	, [AnimalHomesRawScore]
	, [AnimalHomesStandartScore]
	, [GeometricShapeRawScore]
	, [GeometricShapeStandartScore]
	, [BlocksPatternRawScore]
	, [BlocksPatternStandartScore]
	, [AnimalHomesAgainRawScore]
	, [AnimalHomesAgainStandartScore]
	, [MazesRawScore]
	, [MazesStandartScore]
	, [TotalVerbalScore]
	, [TotalPerformanceScore]
	, [TotalScore]
	, [TestDate]
	, [CreateDate]
	, [UpdateDate]
	, [UserID]
	, [AdvisorID]
    FROM
	[dbo].[Wippsi]
    WHERE 
	 ([WippsiID] = @WippsiId OR @WippsiId IS NULL)
	AND ([GeneralRawScore] = @GeneralRawScore OR @GeneralRawScore IS NULL)
	AND ([GeneralStandartScore] = @GeneralStandartScore OR @GeneralStandartScore IS NULL)
	AND ([SimilarityRawScore] = @SimilarityRawScore OR @SimilarityRawScore IS NULL)
	AND ([SimilarityStandartScore] = @SimilarityStandartScore OR @SimilarityStandartScore IS NULL)
	AND ([ArithmeticRawScore] = @ArithmeticRawScore OR @ArithmeticRawScore IS NULL)
	AND ([ArithmeticStandartScore] = @ArithmeticStandartScore OR @ArithmeticStandartScore IS NULL)
	AND ([WordRawScore] = @WordRawScore OR @WordRawScore IS NULL)
	AND ([WordStandartScore] = @WordStandartScore OR @WordStandartScore IS NULL)
	AND ([UnderstandingRawScore] = @UnderstandingRawScore OR @UnderstandingRawScore IS NULL)
	AND ([UnderstandingStandartScore] = @UnderstandingStandartScore OR @UnderstandingStandartScore IS NULL)
	AND ([SentencesRawScore] = @SentencesRawScore OR @SentencesRawScore IS NULL)
	AND ([SentencesStandartScore] = @SentencesStandartScore OR @SentencesStandartScore IS NULL)
	AND ([ImageDefineRawScore] = @ImageDefineRawScore OR @ImageDefineRawScore IS NULL)
	AND ([ImageDefineStandartScore] = @ImageDefineStandartScore OR @ImageDefineStandartScore IS NULL)
	AND ([AnimalHomesRawScore] = @AnimalHomesRawScore OR @AnimalHomesRawScore IS NULL)
	AND ([AnimalHomesStandartScore] = @AnimalHomesStandartScore OR @AnimalHomesStandartScore IS NULL)
	AND ([GeometricShapeRawScore] = @GeometricShapeRawScore OR @GeometricShapeRawScore IS NULL)
	AND ([GeometricShapeStandartScore] = @GeometricShapeStandartScore OR @GeometricShapeStandartScore IS NULL)
	AND ([BlocksPatternRawScore] = @BlocksPatternRawScore OR @BlocksPatternRawScore IS NULL)
	AND ([BlocksPatternStandartScore] = @BlocksPatternStandartScore OR @BlocksPatternStandartScore IS NULL)
	AND ([AnimalHomesAgainRawScore] = @AnimalHomesAgainRawScore OR @AnimalHomesAgainRawScore IS NULL)
	AND ([AnimalHomesAgainStandartScore] = @AnimalHomesAgainStandartScore OR @AnimalHomesAgainStandartScore IS NULL)
	AND ([MazesRawScore] = @MazesRawScore OR @MazesRawScore IS NULL)
	AND ([MazesStandartScore] = @MazesStandartScore OR @MazesStandartScore IS NULL)
	AND ([TotalVerbalScore] = @TotalVerbalScore OR @TotalVerbalScore IS NULL)
	AND ([TotalPerformanceScore] = @TotalPerformanceScore OR @TotalPerformanceScore IS NULL)
	AND ([TotalScore] = @TotalScore OR @TotalScore IS NULL)
	AND ([TestDate] = @TestDate OR @TestDate IS NULL)
	AND ([CreateDate] = @CreateDate OR @CreateDate IS NULL)
	AND ([UpdateDate] = @UpdateDate OR @UpdateDate IS NULL)
	AND ([UserID] = @UserId OR @UserId IS NULL)
	AND ([AdvisorID] = @AdvisorId OR @AdvisorId IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [WippsiID]
	, [GeneralRawScore]
	, [GeneralStandartScore]
	, [SimilarityRawScore]
	, [SimilarityStandartScore]
	, [ArithmeticRawScore]
	, [ArithmeticStandartScore]
	, [WordRawScore]
	, [WordStandartScore]
	, [UnderstandingRawScore]
	, [UnderstandingStandartScore]
	, [SentencesRawScore]
	, [SentencesStandartScore]
	, [ImageDefineRawScore]
	, [ImageDefineStandartScore]
	, [AnimalHomesRawScore]
	, [AnimalHomesStandartScore]
	, [GeometricShapeRawScore]
	, [GeometricShapeStandartScore]
	, [BlocksPatternRawScore]
	, [BlocksPatternStandartScore]
	, [AnimalHomesAgainRawScore]
	, [AnimalHomesAgainStandartScore]
	, [MazesRawScore]
	, [MazesStandartScore]
	, [TotalVerbalScore]
	, [TotalPerformanceScore]
	, [TotalScore]
	, [TestDate]
	, [CreateDate]
	, [UpdateDate]
	, [UserID]
	, [AdvisorID]
    FROM
	[dbo].[Wippsi]
    WHERE 
	 ([WippsiID] = @WippsiId AND @WippsiId is not null)
	OR ([GeneralRawScore] = @GeneralRawScore AND @GeneralRawScore is not null)
	OR ([GeneralStandartScore] = @GeneralStandartScore AND @GeneralStandartScore is not null)
	OR ([SimilarityRawScore] = @SimilarityRawScore AND @SimilarityRawScore is not null)
	OR ([SimilarityStandartScore] = @SimilarityStandartScore AND @SimilarityStandartScore is not null)
	OR ([ArithmeticRawScore] = @ArithmeticRawScore AND @ArithmeticRawScore is not null)
	OR ([ArithmeticStandartScore] = @ArithmeticStandartScore AND @ArithmeticStandartScore is not null)
	OR ([WordRawScore] = @WordRawScore AND @WordRawScore is not null)
	OR ([WordStandartScore] = @WordStandartScore AND @WordStandartScore is not null)
	OR ([UnderstandingRawScore] = @UnderstandingRawScore AND @UnderstandingRawScore is not null)
	OR ([UnderstandingStandartScore] = @UnderstandingStandartScore AND @UnderstandingStandartScore is not null)
	OR ([SentencesRawScore] = @SentencesRawScore AND @SentencesRawScore is not null)
	OR ([SentencesStandartScore] = @SentencesStandartScore AND @SentencesStandartScore is not null)
	OR ([ImageDefineRawScore] = @ImageDefineRawScore AND @ImageDefineRawScore is not null)
	OR ([ImageDefineStandartScore] = @ImageDefineStandartScore AND @ImageDefineStandartScore is not null)
	OR ([AnimalHomesRawScore] = @AnimalHomesRawScore AND @AnimalHomesRawScore is not null)
	OR ([AnimalHomesStandartScore] = @AnimalHomesStandartScore AND @AnimalHomesStandartScore is not null)
	OR ([GeometricShapeRawScore] = @GeometricShapeRawScore AND @GeometricShapeRawScore is not null)
	OR ([GeometricShapeStandartScore] = @GeometricShapeStandartScore AND @GeometricShapeStandartScore is not null)
	OR ([BlocksPatternRawScore] = @BlocksPatternRawScore AND @BlocksPatternRawScore is not null)
	OR ([BlocksPatternStandartScore] = @BlocksPatternStandartScore AND @BlocksPatternStandartScore is not null)
	OR ([AnimalHomesAgainRawScore] = @AnimalHomesAgainRawScore AND @AnimalHomesAgainRawScore is not null)
	OR ([AnimalHomesAgainStandartScore] = @AnimalHomesAgainStandartScore AND @AnimalHomesAgainStandartScore is not null)
	OR ([MazesRawScore] = @MazesRawScore AND @MazesRawScore is not null)
	OR ([MazesStandartScore] = @MazesStandartScore AND @MazesStandartScore is not null)
	OR ([TotalVerbalScore] = @TotalVerbalScore AND @TotalVerbalScore is not null)
	OR ([TotalPerformanceScore] = @TotalPerformanceScore AND @TotalPerformanceScore is not null)
	OR ([TotalScore] = @TotalScore AND @TotalScore is not null)
	OR ([TestDate] = @TestDate AND @TestDate is not null)
	OR ([CreateDate] = @CreateDate AND @CreateDate is not null)
	OR ([UpdateDate] = @UpdateDate AND @UpdateDate is not null)
	OR ([UserID] = @UserId AND @UserId is not null)
	OR ([AdvisorID] = @AdvisorId AND @AdvisorId is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_Session_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_Session_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_Session_Get_List
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Gets all records from the Session table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Session_Get_List

AS


				
				SELECT
					[SessionID],
					[UserName],
					[Password],
					[CreateOn],
					[UpdateOn]
				FROM
					[dbo].[Session]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_Session_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_Session_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_Session_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Gets records from the Session table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Session_GetPaged
(

	@WhereClause varchar (8000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy IS NULL OR LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[SessionID]'
				END

				-- SQL Server 2005 Paging
				DECLARE @SQL AS nvarchar(MAX)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [SessionID]'
				SET @SQL = @SQL + ', [UserName]'
				SET @SQL = @SQL + ', [Password]'
				SET @SQL = @SQL + ', [CreateOn]'
				SET @SQL = @SQL + ', [UpdateOn]'
				SET @SQL = @SQL + ' FROM [dbo].[Session]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [SessionID],'
				SET @SQL = @SQL + ' [UserName],'
				SET @SQL = @SQL + ' [Password],'
				SET @SQL = @SQL + ' [CreateOn],'
				SET @SQL = @SQL + ' [UpdateOn]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + CONVERT(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				EXEC sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(1) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[Session]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_Session_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_Session_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_Session_Insert
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Inserts a record into the Session table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Session_Insert
(

	@SessionId int    OUTPUT,

	@UserName nvarchar (50)  ,

	@Password nvarchar (50)  ,

	@CreateOn smalldatetime   ,

	@UpdateOn smalldatetime   
)
AS


				
				INSERT INTO [dbo].[Session]
					(
					[UserName]
					,[Password]
					,[CreateOn]
					,[UpdateOn]
					)
				VALUES
					(
					@UserName
					,@Password
					,@CreateOn
					,@UpdateOn
					)
				-- Get the identity value
				SET @SessionId = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_Session_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_Session_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_Session_Update
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Updates a record in the Session table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Session_Update
(

	@SessionId int   ,

	@UserName nvarchar (50)  ,

	@Password nvarchar (50)  ,

	@CreateOn smalldatetime   ,

	@UpdateOn smalldatetime   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[Session]
				SET
					[UserName] = @UserName
					,[Password] = @Password
					,[CreateOn] = @CreateOn
					,[UpdateOn] = @UpdateOn
				WHERE
[SessionID] = @SessionId 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_Session_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_Session_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_Session_Delete
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Deletes a record in the Session table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Session_Delete
(

	@SessionId int   
)
AS


				DELETE FROM [dbo].[Session] WITH (ROWLOCK) 
				WHERE
					[SessionID] = @SessionId
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_Session_GetByPassword procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_Session_GetByPassword') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_Session_GetByPassword
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Select records from the Session table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Session_GetByPassword
(

	@Password nvarchar (50)  
)
AS


				SELECT
					[SessionID],
					[UserName],
					[Password],
					[CreateOn],
					[UpdateOn]
				FROM
					[dbo].[Session]
				WHERE
					[Password] = @Password
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_Session_GetByUserName procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_Session_GetByUserName') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_Session_GetByUserName
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Select records from the Session table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Session_GetByUserName
(

	@UserName nvarchar (50)  
)
AS


				SELECT
					[SessionID],
					[UserName],
					[Password],
					[CreateOn],
					[UpdateOn]
				FROM
					[dbo].[Session]
				WHERE
					[UserName] = @UserName
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_Session_GetBySessionId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_Session_GetBySessionId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_Session_GetBySessionId
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Select records from the Session table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Session_GetBySessionId
(

	@SessionId int   
)
AS


				SELECT
					[SessionID],
					[UserName],
					[Password],
					[CreateOn],
					[UpdateOn]
				FROM
					[dbo].[Session]
				WHERE
					[SessionID] = @SessionId
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_Session_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_Session_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_Session_Find
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Finds records in the Session table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Session_Find
(

	@SearchUsingOR bit   = null ,

	@SessionId int   = null ,

	@UserName nvarchar (50)  = null ,

	@Password nvarchar (50)  = null ,

	@CreateOn smalldatetime   = null ,

	@UpdateOn smalldatetime   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [SessionID]
	, [UserName]
	, [Password]
	, [CreateOn]
	, [UpdateOn]
    FROM
	[dbo].[Session]
    WHERE 
	 ([SessionID] = @SessionId OR @SessionId IS NULL)
	AND ([UserName] = @UserName OR @UserName IS NULL)
	AND ([Password] = @Password OR @Password IS NULL)
	AND ([CreateOn] = @CreateOn OR @CreateOn IS NULL)
	AND ([UpdateOn] = @UpdateOn OR @UpdateOn IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [SessionID]
	, [UserName]
	, [Password]
	, [CreateOn]
	, [UpdateOn]
    FROM
	[dbo].[Session]
    WHERE 
	 ([SessionID] = @SessionId AND @SessionId is not null)
	OR ([UserName] = @UserName AND @UserName is not null)
	OR ([Password] = @Password AND @Password is not null)
	OR ([CreateOn] = @CreateOn AND @CreateOn is not null)
	OR ([UpdateOn] = @UpdateOn AND @UpdateOn is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_Street_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_Street_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_Street_Get_List
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Gets all records from the Street table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Street_Get_List

AS


				
				SELECT
					[Id],
					[AdminId],
					[ObjectId],
					[RowNumber],
					[NeighborhoodId],
					[StreetName],
					[Longitude],
					[Latitude],
					[ZipCode],
					[CreateDate],
					[CreateTime],
					[UpdateDate],
					[UpdateTime]
				FROM
					[dbo].[Street]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_Street_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_Street_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_Street_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Gets records from the Street table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Street_GetPaged
(

	@WhereClause varchar (8000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy IS NULL OR LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[Id]'
				END

				-- SQL Server 2005 Paging
				DECLARE @SQL AS nvarchar(MAX)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [Id]'
				SET @SQL = @SQL + ', [AdminId]'
				SET @SQL = @SQL + ', [ObjectId]'
				SET @SQL = @SQL + ', [RowNumber]'
				SET @SQL = @SQL + ', [NeighborhoodId]'
				SET @SQL = @SQL + ', [StreetName]'
				SET @SQL = @SQL + ', [Longitude]'
				SET @SQL = @SQL + ', [Latitude]'
				SET @SQL = @SQL + ', [ZipCode]'
				SET @SQL = @SQL + ', [CreateDate]'
				SET @SQL = @SQL + ', [CreateTime]'
				SET @SQL = @SQL + ', [UpdateDate]'
				SET @SQL = @SQL + ', [UpdateTime]'
				SET @SQL = @SQL + ' FROM [dbo].[Street]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [Id],'
				SET @SQL = @SQL + ' [AdminId],'
				SET @SQL = @SQL + ' [ObjectId],'
				SET @SQL = @SQL + ' [RowNumber],'
				SET @SQL = @SQL + ' [NeighborhoodId],'
				SET @SQL = @SQL + ' [StreetName],'
				SET @SQL = @SQL + ' [Longitude],'
				SET @SQL = @SQL + ' [Latitude],'
				SET @SQL = @SQL + ' [ZipCode],'
				SET @SQL = @SQL + ' [CreateDate],'
				SET @SQL = @SQL + ' [CreateTime],'
				SET @SQL = @SQL + ' [UpdateDate],'
				SET @SQL = @SQL + ' [UpdateTime]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + CONVERT(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				EXEC sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(1) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[Street]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_Street_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_Street_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_Street_Insert
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Inserts a record into the Street table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Street_Insert
(

	@Id int    OUTPUT,

	@AdminId bigint   ,

	@ObjectId bigint   ,

	@RowNumber int   ,

	@NeighborhoodId int   ,

	@StreetName nvarchar (250)  ,

	@Longitude varchar (20)  ,

	@Latitude varchar (20)  ,

	@ZipCode varchar (10)  ,

	@CreateDate date   ,

	@CreateTime time   ,

	@UpdateDate date   ,

	@UpdateTime time   
)
AS


				
				INSERT INTO [dbo].[Street]
					(
					[AdminId]
					,[ObjectId]
					,[RowNumber]
					,[NeighborhoodId]
					,[StreetName]
					,[Longitude]
					,[Latitude]
					,[ZipCode]
					,[CreateDate]
					,[CreateTime]
					,[UpdateDate]
					,[UpdateTime]
					)
				VALUES
					(
					@AdminId
					,@ObjectId
					,@RowNumber
					,@NeighborhoodId
					,@StreetName
					,@Longitude
					,@Latitude
					,@ZipCode
					,@CreateDate
					,@CreateTime
					,@UpdateDate
					,@UpdateTime
					)
				-- Get the identity value
				SET @Id = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_Street_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_Street_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_Street_Update
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Updates a record in the Street table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Street_Update
(

	@Id int   ,

	@AdminId bigint   ,

	@ObjectId bigint   ,

	@RowNumber int   ,

	@NeighborhoodId int   ,

	@StreetName nvarchar (250)  ,

	@Longitude varchar (20)  ,

	@Latitude varchar (20)  ,

	@ZipCode varchar (10)  ,

	@CreateDate date   ,

	@CreateTime time   ,

	@UpdateDate date   ,

	@UpdateTime time   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[Street]
				SET
					[AdminId] = @AdminId
					,[ObjectId] = @ObjectId
					,[RowNumber] = @RowNumber
					,[NeighborhoodId] = @NeighborhoodId
					,[StreetName] = @StreetName
					,[Longitude] = @Longitude
					,[Latitude] = @Latitude
					,[ZipCode] = @ZipCode
					,[CreateDate] = @CreateDate
					,[CreateTime] = @CreateTime
					,[UpdateDate] = @UpdateDate
					,[UpdateTime] = @UpdateTime
				WHERE
[Id] = @Id 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_Street_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_Street_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_Street_Delete
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Deletes a record in the Street table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Street_Delete
(

	@Id int   
)
AS


				DELETE FROM [dbo].[Street] WITH (ROWLOCK) 
				WHERE
					[Id] = @Id
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_Street_GetByNeighborhoodId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_Street_GetByNeighborhoodId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_Street_GetByNeighborhoodId
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Select records from the Street table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Street_GetByNeighborhoodId
(

	@NeighborhoodId int   
)
AS


				SELECT
					[Id],
					[AdminId],
					[ObjectId],
					[RowNumber],
					[NeighborhoodId],
					[StreetName],
					[Longitude],
					[Latitude],
					[ZipCode],
					[CreateDate],
					[CreateTime],
					[UpdateDate],
					[UpdateTime]
				FROM
					[dbo].[Street]
				WHERE
					[NeighborhoodId] = @NeighborhoodId
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_Street_GetById procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_Street_GetById') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_Street_GetById
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Select records from the Street table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Street_GetById
(

	@Id int   
)
AS


				SELECT
					[Id],
					[AdminId],
					[ObjectId],
					[RowNumber],
					[NeighborhoodId],
					[StreetName],
					[Longitude],
					[Latitude],
					[ZipCode],
					[CreateDate],
					[CreateTime],
					[UpdateDate],
					[UpdateTime]
				FROM
					[dbo].[Street]
				WHERE
					[Id] = @Id
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_Street_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_Street_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_Street_Find
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Finds records in the Street table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Street_Find
(

	@SearchUsingOR bit   = null ,

	@Id int   = null ,

	@AdminId bigint   = null ,

	@ObjectId bigint   = null ,

	@RowNumber int   = null ,

	@NeighborhoodId int   = null ,

	@StreetName nvarchar (250)  = null ,

	@Longitude varchar (20)  = null ,

	@Latitude varchar (20)  = null ,

	@ZipCode varchar (10)  = null ,

	@CreateDate date   = null ,

	@CreateTime time   = null ,

	@UpdateDate date   = null ,

	@UpdateTime time   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [Id]
	, [AdminId]
	, [ObjectId]
	, [RowNumber]
	, [NeighborhoodId]
	, [StreetName]
	, [Longitude]
	, [Latitude]
	, [ZipCode]
	, [CreateDate]
	, [CreateTime]
	, [UpdateDate]
	, [UpdateTime]
    FROM
	[dbo].[Street]
    WHERE 
	 ([Id] = @Id OR @Id IS NULL)
	AND ([AdminId] = @AdminId OR @AdminId IS NULL)
	AND ([ObjectId] = @ObjectId OR @ObjectId IS NULL)
	AND ([RowNumber] = @RowNumber OR @RowNumber IS NULL)
	AND ([NeighborhoodId] = @NeighborhoodId OR @NeighborhoodId IS NULL)
	AND ([StreetName] = @StreetName OR @StreetName IS NULL)
	AND ([Longitude] = @Longitude OR @Longitude IS NULL)
	AND ([Latitude] = @Latitude OR @Latitude IS NULL)
	AND ([ZipCode] = @ZipCode OR @ZipCode IS NULL)
	AND ([CreateDate] = @CreateDate OR @CreateDate IS NULL)
	AND ([CreateTime] = @CreateTime OR @CreateTime IS NULL)
	AND ([UpdateDate] = @UpdateDate OR @UpdateDate IS NULL)
	AND ([UpdateTime] = @UpdateTime OR @UpdateTime IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [Id]
	, [AdminId]
	, [ObjectId]
	, [RowNumber]
	, [NeighborhoodId]
	, [StreetName]
	, [Longitude]
	, [Latitude]
	, [ZipCode]
	, [CreateDate]
	, [CreateTime]
	, [UpdateDate]
	, [UpdateTime]
    FROM
	[dbo].[Street]
    WHERE 
	 ([Id] = @Id AND @Id is not null)
	OR ([AdminId] = @AdminId AND @AdminId is not null)
	OR ([ObjectId] = @ObjectId AND @ObjectId is not null)
	OR ([RowNumber] = @RowNumber AND @RowNumber is not null)
	OR ([NeighborhoodId] = @NeighborhoodId AND @NeighborhoodId is not null)
	OR ([StreetName] = @StreetName AND @StreetName is not null)
	OR ([Longitude] = @Longitude AND @Longitude is not null)
	OR ([Latitude] = @Latitude AND @Latitude is not null)
	OR ([ZipCode] = @ZipCode AND @ZipCode is not null)
	OR ([CreateDate] = @CreateDate AND @CreateDate is not null)
	OR ([CreateTime] = @CreateTime AND @CreateTime is not null)
	OR ([UpdateDate] = @UpdateDate AND @UpdateDate is not null)
	OR ([UpdateTime] = @UpdateTime AND @UpdateTime is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_QuestionForm_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_QuestionForm_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_QuestionForm_Get_List
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Gets all records from the QuestionForm table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_QuestionForm_Get_List

AS


				
				SELECT
					[QuestionID],
					[GroupID],
					[QuestionRef],
					[QuestionName],
					[LineNumber],
					[Status]
				FROM
					[dbo].[QuestionForm]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_QuestionForm_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_QuestionForm_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_QuestionForm_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Gets records from the QuestionForm table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_QuestionForm_GetPaged
(

	@WhereClause varchar (8000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy IS NULL OR LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[QuestionID]'
				END

				-- SQL Server 2005 Paging
				DECLARE @SQL AS nvarchar(MAX)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [QuestionID]'
				SET @SQL = @SQL + ', [GroupID]'
				SET @SQL = @SQL + ', [QuestionRef]'
				SET @SQL = @SQL + ', [QuestionName]'
				SET @SQL = @SQL + ', [LineNumber]'
				SET @SQL = @SQL + ', [Status]'
				SET @SQL = @SQL + ' FROM [dbo].[QuestionForm]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [QuestionID],'
				SET @SQL = @SQL + ' [GroupID],'
				SET @SQL = @SQL + ' [QuestionRef],'
				SET @SQL = @SQL + ' [QuestionName],'
				SET @SQL = @SQL + ' [LineNumber],'
				SET @SQL = @SQL + ' [Status]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + CONVERT(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				EXEC sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(1) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[QuestionForm]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_QuestionForm_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_QuestionForm_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_QuestionForm_Insert
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Inserts a record into the QuestionForm table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_QuestionForm_Insert
(

	@QuestionId int    OUTPUT,

	@GroupId int   ,

	@QuestionRef varchar (10)  ,

	@QuestionName varchar (500)  ,

	@LineNumber int   ,

	@Status bit   
)
AS


				
				INSERT INTO [dbo].[QuestionForm]
					(
					[GroupID]
					,[QuestionRef]
					,[QuestionName]
					,[LineNumber]
					,[Status]
					)
				VALUES
					(
					@GroupId
					,@QuestionRef
					,@QuestionName
					,@LineNumber
					,@Status
					)
				-- Get the identity value
				SET @QuestionId = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_QuestionForm_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_QuestionForm_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_QuestionForm_Update
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Updates a record in the QuestionForm table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_QuestionForm_Update
(

	@QuestionId int   ,

	@GroupId int   ,

	@QuestionRef varchar (10)  ,

	@QuestionName varchar (500)  ,

	@LineNumber int   ,

	@Status bit   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[QuestionForm]
				SET
					[GroupID] = @GroupId
					,[QuestionRef] = @QuestionRef
					,[QuestionName] = @QuestionName
					,[LineNumber] = @LineNumber
					,[Status] = @Status
				WHERE
[QuestionID] = @QuestionId 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_QuestionForm_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_QuestionForm_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_QuestionForm_Delete
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Deletes a record in the QuestionForm table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_QuestionForm_Delete
(

	@QuestionId int   
)
AS


				DELETE FROM [dbo].[QuestionForm] WITH (ROWLOCK) 
				WHERE
					[QuestionID] = @QuestionId
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_QuestionForm_GetByGroupId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_QuestionForm_GetByGroupId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_QuestionForm_GetByGroupId
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Select records from the QuestionForm table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_QuestionForm_GetByGroupId
(

	@GroupId int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[QuestionID],
					[GroupID],
					[QuestionRef],
					[QuestionName],
					[LineNumber],
					[Status]
				FROM
					[dbo].[QuestionForm]
				WHERE
					[GroupID] = @GroupId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_QuestionForm_GetByQuestionId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_QuestionForm_GetByQuestionId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_QuestionForm_GetByQuestionId
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Select records from the QuestionForm table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_QuestionForm_GetByQuestionId
(

	@QuestionId int   
)
AS


				SELECT
					[QuestionID],
					[GroupID],
					[QuestionRef],
					[QuestionName],
					[LineNumber],
					[Status]
				FROM
					[dbo].[QuestionForm]
				WHERE
					[QuestionID] = @QuestionId
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_QuestionForm_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_QuestionForm_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_QuestionForm_Find
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Finds records in the QuestionForm table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_QuestionForm_Find
(

	@SearchUsingOR bit   = null ,

	@QuestionId int   = null ,

	@GroupId int   = null ,

	@QuestionRef varchar (10)  = null ,

	@QuestionName varchar (500)  = null ,

	@LineNumber int   = null ,

	@Status bit   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [QuestionID]
	, [GroupID]
	, [QuestionRef]
	, [QuestionName]
	, [LineNumber]
	, [Status]
    FROM
	[dbo].[QuestionForm]
    WHERE 
	 ([QuestionID] = @QuestionId OR @QuestionId IS NULL)
	AND ([GroupID] = @GroupId OR @GroupId IS NULL)
	AND ([QuestionRef] = @QuestionRef OR @QuestionRef IS NULL)
	AND ([QuestionName] = @QuestionName OR @QuestionName IS NULL)
	AND ([LineNumber] = @LineNumber OR @LineNumber IS NULL)
	AND ([Status] = @Status OR @Status IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [QuestionID]
	, [GroupID]
	, [QuestionRef]
	, [QuestionName]
	, [LineNumber]
	, [Status]
    FROM
	[dbo].[QuestionForm]
    WHERE 
	 ([QuestionID] = @QuestionId AND @QuestionId is not null)
	OR ([GroupID] = @GroupId AND @GroupId is not null)
	OR ([QuestionRef] = @QuestionRef AND @QuestionRef is not null)
	OR ([QuestionName] = @QuestionName AND @QuestionName is not null)
	OR ([LineNumber] = @LineNumber AND @LineNumber is not null)
	OR ([Status] = @Status AND @Status is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_Sibling_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_Sibling_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_Sibling_Get_List
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Gets all records from the Sibling table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Sibling_Get_List

AS


				
				SELECT
					[SiblingId],
					[ClientId],
					[FullName],
					[BirthDate],
					[Gender],
					[Age],
					[School],
					[ClassRoom],
					[Note],
					[CreateOn],
					[UpdateOn],
					[UserId]
				FROM
					[dbo].[Sibling]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_Sibling_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_Sibling_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_Sibling_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Gets records from the Sibling table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Sibling_GetPaged
(

	@WhereClause varchar (8000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy IS NULL OR LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[SiblingId]'
				END

				-- SQL Server 2005 Paging
				DECLARE @SQL AS nvarchar(MAX)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [SiblingId]'
				SET @SQL = @SQL + ', [ClientId]'
				SET @SQL = @SQL + ', [FullName]'
				SET @SQL = @SQL + ', [BirthDate]'
				SET @SQL = @SQL + ', [Gender]'
				SET @SQL = @SQL + ', [Age]'
				SET @SQL = @SQL + ', [School]'
				SET @SQL = @SQL + ', [ClassRoom]'
				SET @SQL = @SQL + ', [Note]'
				SET @SQL = @SQL + ', [CreateOn]'
				SET @SQL = @SQL + ', [UpdateOn]'
				SET @SQL = @SQL + ', [UserId]'
				SET @SQL = @SQL + ' FROM [dbo].[Sibling]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [SiblingId],'
				SET @SQL = @SQL + ' [ClientId],'
				SET @SQL = @SQL + ' [FullName],'
				SET @SQL = @SQL + ' [BirthDate],'
				SET @SQL = @SQL + ' [Gender],'
				SET @SQL = @SQL + ' [Age],'
				SET @SQL = @SQL + ' [School],'
				SET @SQL = @SQL + ' [ClassRoom],'
				SET @SQL = @SQL + ' [Note],'
				SET @SQL = @SQL + ' [CreateOn],'
				SET @SQL = @SQL + ' [UpdateOn],'
				SET @SQL = @SQL + ' [UserId]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + CONVERT(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				EXEC sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(1) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[Sibling]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_Sibling_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_Sibling_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_Sibling_Insert
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Inserts a record into the Sibling table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Sibling_Insert
(

	@SiblingId int    OUTPUT,

	@ClientId int   ,

	@FullName varchar (100)  ,

	@BirthDate smalldatetime   ,

	@Gender tinyint   ,

	@Age int   ,

	@School varchar (100)  ,

	@ClassRoom tinyint   ,

	@Note varchar (MAX)  ,

	@CreateOn smalldatetime   ,

	@UpdateOn smalldatetime   ,

	@UserId int   
)
AS


				
				INSERT INTO [dbo].[Sibling]
					(
					[ClientId]
					,[FullName]
					,[BirthDate]
					,[Gender]
					,[Age]
					,[School]
					,[ClassRoom]
					,[Note]
					,[CreateOn]
					,[UpdateOn]
					,[UserId]
					)
				VALUES
					(
					@ClientId
					,@FullName
					,@BirthDate
					,@Gender
					,@Age
					,@School
					,@ClassRoom
					,@Note
					,@CreateOn
					,@UpdateOn
					,@UserId
					)
				-- Get the identity value
				SET @SiblingId = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_Sibling_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_Sibling_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_Sibling_Update
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Updates a record in the Sibling table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Sibling_Update
(

	@SiblingId int   ,

	@ClientId int   ,

	@FullName varchar (100)  ,

	@BirthDate smalldatetime   ,

	@Gender tinyint   ,

	@Age int   ,

	@School varchar (100)  ,

	@ClassRoom tinyint   ,

	@Note varchar (MAX)  ,

	@CreateOn smalldatetime   ,

	@UpdateOn smalldatetime   ,

	@UserId int   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[Sibling]
				SET
					[ClientId] = @ClientId
					,[FullName] = @FullName
					,[BirthDate] = @BirthDate
					,[Gender] = @Gender
					,[Age] = @Age
					,[School] = @School
					,[ClassRoom] = @ClassRoom
					,[Note] = @Note
					,[CreateOn] = @CreateOn
					,[UpdateOn] = @UpdateOn
					,[UserId] = @UserId
				WHERE
[SiblingId] = @SiblingId 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_Sibling_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_Sibling_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_Sibling_Delete
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Deletes a record in the Sibling table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Sibling_Delete
(

	@SiblingId int   
)
AS


				DELETE FROM [dbo].[Sibling] WITH (ROWLOCK) 
				WHERE
					[SiblingId] = @SiblingId
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_Sibling_GetByClientId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_Sibling_GetByClientId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_Sibling_GetByClientId
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Select records from the Sibling table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Sibling_GetByClientId
(

	@ClientId int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[SiblingId],
					[ClientId],
					[FullName],
					[BirthDate],
					[Gender],
					[Age],
					[School],
					[ClassRoom],
					[Note],
					[CreateOn],
					[UpdateOn],
					[UserId]
				FROM
					[dbo].[Sibling]
				WHERE
					[ClientId] = @ClientId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_Sibling_GetBySiblingId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_Sibling_GetBySiblingId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_Sibling_GetBySiblingId
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Select records from the Sibling table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Sibling_GetBySiblingId
(

	@SiblingId int   
)
AS


				SELECT
					[SiblingId],
					[ClientId],
					[FullName],
					[BirthDate],
					[Gender],
					[Age],
					[School],
					[ClassRoom],
					[Note],
					[CreateOn],
					[UpdateOn],
					[UserId]
				FROM
					[dbo].[Sibling]
				WHERE
					[SiblingId] = @SiblingId
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_Sibling_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_Sibling_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_Sibling_Find
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Finds records in the Sibling table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Sibling_Find
(

	@SearchUsingOR bit   = null ,

	@SiblingId int   = null ,

	@ClientId int   = null ,

	@FullName varchar (100)  = null ,

	@BirthDate smalldatetime   = null ,

	@Gender tinyint   = null ,

	@Age int   = null ,

	@School varchar (100)  = null ,

	@ClassRoom tinyint   = null ,

	@Note varchar (MAX)  = null ,

	@CreateOn smalldatetime   = null ,

	@UpdateOn smalldatetime   = null ,

	@UserId int   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [SiblingId]
	, [ClientId]
	, [FullName]
	, [BirthDate]
	, [Gender]
	, [Age]
	, [School]
	, [ClassRoom]
	, [Note]
	, [CreateOn]
	, [UpdateOn]
	, [UserId]
    FROM
	[dbo].[Sibling]
    WHERE 
	 ([SiblingId] = @SiblingId OR @SiblingId IS NULL)
	AND ([ClientId] = @ClientId OR @ClientId IS NULL)
	AND ([FullName] = @FullName OR @FullName IS NULL)
	AND ([BirthDate] = @BirthDate OR @BirthDate IS NULL)
	AND ([Gender] = @Gender OR @Gender IS NULL)
	AND ([Age] = @Age OR @Age IS NULL)
	AND ([School] = @School OR @School IS NULL)
	AND ([ClassRoom] = @ClassRoom OR @ClassRoom IS NULL)
	AND ([Note] = @Note OR @Note IS NULL)
	AND ([CreateOn] = @CreateOn OR @CreateOn IS NULL)
	AND ([UpdateOn] = @UpdateOn OR @UpdateOn IS NULL)
	AND ([UserId] = @UserId OR @UserId IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [SiblingId]
	, [ClientId]
	, [FullName]
	, [BirthDate]
	, [Gender]
	, [Age]
	, [School]
	, [ClassRoom]
	, [Note]
	, [CreateOn]
	, [UpdateOn]
	, [UserId]
    FROM
	[dbo].[Sibling]
    WHERE 
	 ([SiblingId] = @SiblingId AND @SiblingId is not null)
	OR ([ClientId] = @ClientId AND @ClientId is not null)
	OR ([FullName] = @FullName AND @FullName is not null)
	OR ([BirthDate] = @BirthDate AND @BirthDate is not null)
	OR ([Gender] = @Gender AND @Gender is not null)
	OR ([Age] = @Age AND @Age is not null)
	OR ([School] = @School AND @School is not null)
	OR ([ClassRoom] = @ClassRoom AND @ClassRoom is not null)
	OR ([Note] = @Note AND @Note is not null)
	OR ([CreateOn] = @CreateOn AND @CreateOn is not null)
	OR ([UpdateOn] = @UpdateOn AND @UpdateOn is not null)
	OR ([UserId] = @UserId AND @UserId is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_ClientMother_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_ClientMother_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_ClientMother_Get_List
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Gets all records from the ClientMother table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_ClientMother_Get_List

AS


				
				SELECT
					[MotherID],
					[FullName],
					[Title],
					[Email],
					[Fax],
					[HomePhone],
					[BusinessPhone],
					[MobilePhone],
					[JobId],
					[StatusId],
					[Notes],
					[CreateOn],
					[UpdateOn],
					[UserId]
				FROM
					[dbo].[ClientMother]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_ClientMother_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_ClientMother_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_ClientMother_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Gets records from the ClientMother table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_ClientMother_GetPaged
(

	@WhereClause varchar (8000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy IS NULL OR LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[MotherID]'
				END

				-- SQL Server 2005 Paging
				DECLARE @SQL AS nvarchar(MAX)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [MotherID]'
				SET @SQL = @SQL + ', [FullName]'
				SET @SQL = @SQL + ', [Title]'
				SET @SQL = @SQL + ', [Email]'
				SET @SQL = @SQL + ', [Fax]'
				SET @SQL = @SQL + ', [HomePhone]'
				SET @SQL = @SQL + ', [BusinessPhone]'
				SET @SQL = @SQL + ', [MobilePhone]'
				SET @SQL = @SQL + ', [JobId]'
				SET @SQL = @SQL + ', [StatusId]'
				SET @SQL = @SQL + ', [Notes]'
				SET @SQL = @SQL + ', [CreateOn]'
				SET @SQL = @SQL + ', [UpdateOn]'
				SET @SQL = @SQL + ', [UserId]'
				SET @SQL = @SQL + ' FROM [dbo].[ClientMother]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [MotherID],'
				SET @SQL = @SQL + ' [FullName],'
				SET @SQL = @SQL + ' [Title],'
				SET @SQL = @SQL + ' [Email],'
				SET @SQL = @SQL + ' [Fax],'
				SET @SQL = @SQL + ' [HomePhone],'
				SET @SQL = @SQL + ' [BusinessPhone],'
				SET @SQL = @SQL + ' [MobilePhone],'
				SET @SQL = @SQL + ' [JobId],'
				SET @SQL = @SQL + ' [StatusId],'
				SET @SQL = @SQL + ' [Notes],'
				SET @SQL = @SQL + ' [CreateOn],'
				SET @SQL = @SQL + ' [UpdateOn],'
				SET @SQL = @SQL + ' [UserId]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + CONVERT(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				EXEC sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(1) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[ClientMother]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_ClientMother_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_ClientMother_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_ClientMother_Insert
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Inserts a record into the ClientMother table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_ClientMother_Insert
(

	@MotherId int    OUTPUT,

	@FullName varchar (50)  ,

	@Title varchar (50)  ,

	@Email varchar (100)  ,

	@Fax varchar (50)  ,

	@HomePhone varchar (50)  ,

	@BusinessPhone varchar (50)  ,

	@MobilePhone varchar (50)  ,

	@JobId int   ,

	@StatusId int   ,

	@Notes nvarchar (500)  ,

	@CreateOn smalldatetime   ,

	@UpdateOn smalldatetime   ,

	@UserId int   
)
AS


				
				INSERT INTO [dbo].[ClientMother]
					(
					[FullName]
					,[Title]
					,[Email]
					,[Fax]
					,[HomePhone]
					,[BusinessPhone]
					,[MobilePhone]
					,[JobId]
					,[StatusId]
					,[Notes]
					,[CreateOn]
					,[UpdateOn]
					,[UserId]
					)
				VALUES
					(
					@FullName
					,@Title
					,@Email
					,@Fax
					,@HomePhone
					,@BusinessPhone
					,@MobilePhone
					,@JobId
					,@StatusId
					,@Notes
					,@CreateOn
					,@UpdateOn
					,@UserId
					)
				-- Get the identity value
				SET @MotherId = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_ClientMother_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_ClientMother_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_ClientMother_Update
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Updates a record in the ClientMother table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_ClientMother_Update
(

	@MotherId int   ,

	@FullName varchar (50)  ,

	@Title varchar (50)  ,

	@Email varchar (100)  ,

	@Fax varchar (50)  ,

	@HomePhone varchar (50)  ,

	@BusinessPhone varchar (50)  ,

	@MobilePhone varchar (50)  ,

	@JobId int   ,

	@StatusId int   ,

	@Notes nvarchar (500)  ,

	@CreateOn smalldatetime   ,

	@UpdateOn smalldatetime   ,

	@UserId int   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[ClientMother]
				SET
					[FullName] = @FullName
					,[Title] = @Title
					,[Email] = @Email
					,[Fax] = @Fax
					,[HomePhone] = @HomePhone
					,[BusinessPhone] = @BusinessPhone
					,[MobilePhone] = @MobilePhone
					,[JobId] = @JobId
					,[StatusId] = @StatusId
					,[Notes] = @Notes
					,[CreateOn] = @CreateOn
					,[UpdateOn] = @UpdateOn
					,[UserId] = @UserId
				WHERE
[MotherID] = @MotherId 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_ClientMother_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_ClientMother_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_ClientMother_Delete
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Deletes a record in the ClientMother table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_ClientMother_Delete
(

	@MotherId int   
)
AS


				DELETE FROM [dbo].[ClientMother] WITH (ROWLOCK) 
				WHERE
					[MotherID] = @MotherId
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_ClientMother_GetByMotherId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_ClientMother_GetByMotherId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_ClientMother_GetByMotherId
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Select records from the ClientMother table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_ClientMother_GetByMotherId
(

	@MotherId int   
)
AS


				SELECT
					[MotherID],
					[FullName],
					[Title],
					[Email],
					[Fax],
					[HomePhone],
					[BusinessPhone],
					[MobilePhone],
					[JobId],
					[StatusId],
					[Notes],
					[CreateOn],
					[UpdateOn],
					[UserId]
				FROM
					[dbo].[ClientMother]
				WHERE
					[MotherID] = @MotherId
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_ClientMother_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_ClientMother_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_ClientMother_Find
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Finds records in the ClientMother table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_ClientMother_Find
(

	@SearchUsingOR bit   = null ,

	@MotherId int   = null ,

	@FullName varchar (50)  = null ,

	@Title varchar (50)  = null ,

	@Email varchar (100)  = null ,

	@Fax varchar (50)  = null ,

	@HomePhone varchar (50)  = null ,

	@BusinessPhone varchar (50)  = null ,

	@MobilePhone varchar (50)  = null ,

	@JobId int   = null ,

	@StatusId int   = null ,

	@Notes nvarchar (500)  = null ,

	@CreateOn smalldatetime   = null ,

	@UpdateOn smalldatetime   = null ,

	@UserId int   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [MotherID]
	, [FullName]
	, [Title]
	, [Email]
	, [Fax]
	, [HomePhone]
	, [BusinessPhone]
	, [MobilePhone]
	, [JobId]
	, [StatusId]
	, [Notes]
	, [CreateOn]
	, [UpdateOn]
	, [UserId]
    FROM
	[dbo].[ClientMother]
    WHERE 
	 ([MotherID] = @MotherId OR @MotherId IS NULL)
	AND ([FullName] = @FullName OR @FullName IS NULL)
	AND ([Title] = @Title OR @Title IS NULL)
	AND ([Email] = @Email OR @Email IS NULL)
	AND ([Fax] = @Fax OR @Fax IS NULL)
	AND ([HomePhone] = @HomePhone OR @HomePhone IS NULL)
	AND ([BusinessPhone] = @BusinessPhone OR @BusinessPhone IS NULL)
	AND ([MobilePhone] = @MobilePhone OR @MobilePhone IS NULL)
	AND ([JobId] = @JobId OR @JobId IS NULL)
	AND ([StatusId] = @StatusId OR @StatusId IS NULL)
	AND ([Notes] = @Notes OR @Notes IS NULL)
	AND ([CreateOn] = @CreateOn OR @CreateOn IS NULL)
	AND ([UpdateOn] = @UpdateOn OR @UpdateOn IS NULL)
	AND ([UserId] = @UserId OR @UserId IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [MotherID]
	, [FullName]
	, [Title]
	, [Email]
	, [Fax]
	, [HomePhone]
	, [BusinessPhone]
	, [MobilePhone]
	, [JobId]
	, [StatusId]
	, [Notes]
	, [CreateOn]
	, [UpdateOn]
	, [UserId]
    FROM
	[dbo].[ClientMother]
    WHERE 
	 ([MotherID] = @MotherId AND @MotherId is not null)
	OR ([FullName] = @FullName AND @FullName is not null)
	OR ([Title] = @Title AND @Title is not null)
	OR ([Email] = @Email AND @Email is not null)
	OR ([Fax] = @Fax AND @Fax is not null)
	OR ([HomePhone] = @HomePhone AND @HomePhone is not null)
	OR ([BusinessPhone] = @BusinessPhone AND @BusinessPhone is not null)
	OR ([MobilePhone] = @MobilePhone AND @MobilePhone is not null)
	OR ([JobId] = @JobId AND @JobId is not null)
	OR ([StatusId] = @StatusId AND @StatusId is not null)
	OR ([Notes] = @Notes AND @Notes is not null)
	OR ([CreateOn] = @CreateOn AND @CreateOn is not null)
	OR ([UpdateOn] = @UpdateOn AND @UpdateOn is not null)
	OR ([UserId] = @UserId AND @UserId is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_ClientAddress_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_ClientAddress_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_ClientAddress_Get_List
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Gets all records from the ClientAddress table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_ClientAddress_Get_List

AS


				
				SELECT
					[AddressId],
					[TitleId],
					[AddressLine],
					[ProvinceId],
					[TownId],
					[NeighborhoodId],
					[StreetId],
					[Phone1],
					[Phone2],
					[Mobile],
					[IsUsed],
					[CreateOn],
					[UpdateOn],
					[UserId]
				FROM
					[dbo].[ClientAddress]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_ClientAddress_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_ClientAddress_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_ClientAddress_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Gets records from the ClientAddress table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_ClientAddress_GetPaged
(

	@WhereClause varchar (8000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy IS NULL OR LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[AddressId]'
				END

				-- SQL Server 2005 Paging
				DECLARE @SQL AS nvarchar(MAX)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [AddressId]'
				SET @SQL = @SQL + ', [TitleId]'
				SET @SQL = @SQL + ', [AddressLine]'
				SET @SQL = @SQL + ', [ProvinceId]'
				SET @SQL = @SQL + ', [TownId]'
				SET @SQL = @SQL + ', [NeighborhoodId]'
				SET @SQL = @SQL + ', [StreetId]'
				SET @SQL = @SQL + ', [Phone1]'
				SET @SQL = @SQL + ', [Phone2]'
				SET @SQL = @SQL + ', [Mobile]'
				SET @SQL = @SQL + ', [IsUsed]'
				SET @SQL = @SQL + ', [CreateOn]'
				SET @SQL = @SQL + ', [UpdateOn]'
				SET @SQL = @SQL + ', [UserId]'
				SET @SQL = @SQL + ' FROM [dbo].[ClientAddress]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [AddressId],'
				SET @SQL = @SQL + ' [TitleId],'
				SET @SQL = @SQL + ' [AddressLine],'
				SET @SQL = @SQL + ' [ProvinceId],'
				SET @SQL = @SQL + ' [TownId],'
				SET @SQL = @SQL + ' [NeighborhoodId],'
				SET @SQL = @SQL + ' [StreetId],'
				SET @SQL = @SQL + ' [Phone1],'
				SET @SQL = @SQL + ' [Phone2],'
				SET @SQL = @SQL + ' [Mobile],'
				SET @SQL = @SQL + ' [IsUsed],'
				SET @SQL = @SQL + ' [CreateOn],'
				SET @SQL = @SQL + ' [UpdateOn],'
				SET @SQL = @SQL + ' [UserId]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + CONVERT(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				EXEC sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(1) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[ClientAddress]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_ClientAddress_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_ClientAddress_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_ClientAddress_Insert
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Inserts a record into the ClientAddress table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_ClientAddress_Insert
(

	@AddressId int    OUTPUT,

	@TitleId tinyint   ,

	@AddressLine varchar (1000)  ,

	@ProvinceId int   ,

	@TownId int   ,

	@NeighborhoodId int   ,

	@StreetId int   ,

	@Phone1 varchar (50)  ,

	@Phone2 varchar (50)  ,

	@Mobile varchar (50)  ,

	@IsUsed bit   ,

	@CreateOn smalldatetime   ,

	@UpdateOn smalldatetime   ,

	@UserId int   
)
AS


				
				INSERT INTO [dbo].[ClientAddress]
					(
					[TitleId]
					,[AddressLine]
					,[ProvinceId]
					,[TownId]
					,[NeighborhoodId]
					,[StreetId]
					,[Phone1]
					,[Phone2]
					,[Mobile]
					,[IsUsed]
					,[CreateOn]
					,[UpdateOn]
					,[UserId]
					)
				VALUES
					(
					@TitleId
					,@AddressLine
					,@ProvinceId
					,@TownId
					,@NeighborhoodId
					,@StreetId
					,@Phone1
					,@Phone2
					,@Mobile
					,@IsUsed
					,@CreateOn
					,@UpdateOn
					,@UserId
					)
				-- Get the identity value
				SET @AddressId = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_ClientAddress_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_ClientAddress_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_ClientAddress_Update
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Updates a record in the ClientAddress table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_ClientAddress_Update
(

	@AddressId int   ,

	@TitleId tinyint   ,

	@AddressLine varchar (1000)  ,

	@ProvinceId int   ,

	@TownId int   ,

	@NeighborhoodId int   ,

	@StreetId int   ,

	@Phone1 varchar (50)  ,

	@Phone2 varchar (50)  ,

	@Mobile varchar (50)  ,

	@IsUsed bit   ,

	@CreateOn smalldatetime   ,

	@UpdateOn smalldatetime   ,

	@UserId int   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[ClientAddress]
				SET
					[TitleId] = @TitleId
					,[AddressLine] = @AddressLine
					,[ProvinceId] = @ProvinceId
					,[TownId] = @TownId
					,[NeighborhoodId] = @NeighborhoodId
					,[StreetId] = @StreetId
					,[Phone1] = @Phone1
					,[Phone2] = @Phone2
					,[Mobile] = @Mobile
					,[IsUsed] = @IsUsed
					,[CreateOn] = @CreateOn
					,[UpdateOn] = @UpdateOn
					,[UserId] = @UserId
				WHERE
[AddressId] = @AddressId 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_ClientAddress_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_ClientAddress_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_ClientAddress_Delete
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Deletes a record in the ClientAddress table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_ClientAddress_Delete
(

	@AddressId int   
)
AS


				DELETE FROM [dbo].[ClientAddress] WITH (ROWLOCK) 
				WHERE
					[AddressId] = @AddressId
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_ClientAddress_GetByAddressId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_ClientAddress_GetByAddressId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_ClientAddress_GetByAddressId
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Select records from the ClientAddress table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_ClientAddress_GetByAddressId
(

	@AddressId int   
)
AS


				SELECT
					[AddressId],
					[TitleId],
					[AddressLine],
					[ProvinceId],
					[TownId],
					[NeighborhoodId],
					[StreetId],
					[Phone1],
					[Phone2],
					[Mobile],
					[IsUsed],
					[CreateOn],
					[UpdateOn],
					[UserId]
				FROM
					[dbo].[ClientAddress]
				WHERE
					[AddressId] = @AddressId
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_ClientAddress_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_ClientAddress_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_ClientAddress_Find
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Finds records in the ClientAddress table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_ClientAddress_Find
(

	@SearchUsingOR bit   = null ,

	@AddressId int   = null ,

	@TitleId tinyint   = null ,

	@AddressLine varchar (1000)  = null ,

	@ProvinceId int   = null ,

	@TownId int   = null ,

	@NeighborhoodId int   = null ,

	@StreetId int   = null ,

	@Phone1 varchar (50)  = null ,

	@Phone2 varchar (50)  = null ,

	@Mobile varchar (50)  = null ,

	@IsUsed bit   = null ,

	@CreateOn smalldatetime   = null ,

	@UpdateOn smalldatetime   = null ,

	@UserId int   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [AddressId]
	, [TitleId]
	, [AddressLine]
	, [ProvinceId]
	, [TownId]
	, [NeighborhoodId]
	, [StreetId]
	, [Phone1]
	, [Phone2]
	, [Mobile]
	, [IsUsed]
	, [CreateOn]
	, [UpdateOn]
	, [UserId]
    FROM
	[dbo].[ClientAddress]
    WHERE 
	 ([AddressId] = @AddressId OR @AddressId IS NULL)
	AND ([TitleId] = @TitleId OR @TitleId IS NULL)
	AND ([AddressLine] = @AddressLine OR @AddressLine IS NULL)
	AND ([ProvinceId] = @ProvinceId OR @ProvinceId IS NULL)
	AND ([TownId] = @TownId OR @TownId IS NULL)
	AND ([NeighborhoodId] = @NeighborhoodId OR @NeighborhoodId IS NULL)
	AND ([StreetId] = @StreetId OR @StreetId IS NULL)
	AND ([Phone1] = @Phone1 OR @Phone1 IS NULL)
	AND ([Phone2] = @Phone2 OR @Phone2 IS NULL)
	AND ([Mobile] = @Mobile OR @Mobile IS NULL)
	AND ([IsUsed] = @IsUsed OR @IsUsed IS NULL)
	AND ([CreateOn] = @CreateOn OR @CreateOn IS NULL)
	AND ([UpdateOn] = @UpdateOn OR @UpdateOn IS NULL)
	AND ([UserId] = @UserId OR @UserId IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [AddressId]
	, [TitleId]
	, [AddressLine]
	, [ProvinceId]
	, [TownId]
	, [NeighborhoodId]
	, [StreetId]
	, [Phone1]
	, [Phone2]
	, [Mobile]
	, [IsUsed]
	, [CreateOn]
	, [UpdateOn]
	, [UserId]
    FROM
	[dbo].[ClientAddress]
    WHERE 
	 ([AddressId] = @AddressId AND @AddressId is not null)
	OR ([TitleId] = @TitleId AND @TitleId is not null)
	OR ([AddressLine] = @AddressLine AND @AddressLine is not null)
	OR ([ProvinceId] = @ProvinceId AND @ProvinceId is not null)
	OR ([TownId] = @TownId AND @TownId is not null)
	OR ([NeighborhoodId] = @NeighborhoodId AND @NeighborhoodId is not null)
	OR ([StreetId] = @StreetId AND @StreetId is not null)
	OR ([Phone1] = @Phone1 AND @Phone1 is not null)
	OR ([Phone2] = @Phone2 AND @Phone2 is not null)
	OR ([Mobile] = @Mobile AND @Mobile is not null)
	OR ([IsUsed] = @IsUsed AND @IsUsed is not null)
	OR ([CreateOn] = @CreateOn AND @CreateOn is not null)
	OR ([UpdateOn] = @UpdateOn AND @UpdateOn is not null)
	OR ([UserId] = @UserId AND @UserId is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_Province_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_Province_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_Province_Get_List
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Gets all records from the Province table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Province_Get_List

AS


				
				SELECT
					[Id],
					[RowNumber],
					[AdminId],
					[ObjectId],
					[ParentId],
					[PlateCode],
					[AreaId],
					[PhoneCode],
					[ProvinceName],
					[Longitude],
					[Latitude],
					[Type],
					[CreateDate],
					[CreateTime],
					[UpdateDate],
					[UpdateTime]
				FROM
					[dbo].[Province]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_Province_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_Province_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_Province_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Gets records from the Province table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Province_GetPaged
(

	@WhereClause varchar (8000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy IS NULL OR LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[Id]'
				END

				-- SQL Server 2005 Paging
				DECLARE @SQL AS nvarchar(MAX)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [Id]'
				SET @SQL = @SQL + ', [RowNumber]'
				SET @SQL = @SQL + ', [AdminId]'
				SET @SQL = @SQL + ', [ObjectId]'
				SET @SQL = @SQL + ', [ParentId]'
				SET @SQL = @SQL + ', [PlateCode]'
				SET @SQL = @SQL + ', [AreaId]'
				SET @SQL = @SQL + ', [PhoneCode]'
				SET @SQL = @SQL + ', [ProvinceName]'
				SET @SQL = @SQL + ', [Longitude]'
				SET @SQL = @SQL + ', [Latitude]'
				SET @SQL = @SQL + ', [Type]'
				SET @SQL = @SQL + ', [CreateDate]'
				SET @SQL = @SQL + ', [CreateTime]'
				SET @SQL = @SQL + ', [UpdateDate]'
				SET @SQL = @SQL + ', [UpdateTime]'
				SET @SQL = @SQL + ' FROM [dbo].[Province]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [Id],'
				SET @SQL = @SQL + ' [RowNumber],'
				SET @SQL = @SQL + ' [AdminId],'
				SET @SQL = @SQL + ' [ObjectId],'
				SET @SQL = @SQL + ' [ParentId],'
				SET @SQL = @SQL + ' [PlateCode],'
				SET @SQL = @SQL + ' [AreaId],'
				SET @SQL = @SQL + ' [PhoneCode],'
				SET @SQL = @SQL + ' [ProvinceName],'
				SET @SQL = @SQL + ' [Longitude],'
				SET @SQL = @SQL + ' [Latitude],'
				SET @SQL = @SQL + ' [Type],'
				SET @SQL = @SQL + ' [CreateDate],'
				SET @SQL = @SQL + ' [CreateTime],'
				SET @SQL = @SQL + ' [UpdateDate],'
				SET @SQL = @SQL + ' [UpdateTime]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + CONVERT(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				EXEC sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(1) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[Province]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_Province_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_Province_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_Province_Insert
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Inserts a record into the Province table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Province_Insert
(

	@Id int    OUTPUT,

	@RowNumber int   ,

	@AdminId bigint   ,

	@ObjectId bigint   ,

	@ParentId bigint   ,

	@PlateCode varchar (2)  ,

	@AreaId int   ,

	@PhoneCode varchar (3)  ,

	@ProvinceName nvarchar (250)  ,

	@Longitude varchar (10)  ,

	@Latitude varchar (10)  ,

	@Type int   ,

	@CreateDate date   ,

	@CreateTime time   ,

	@UpdateDate date   ,

	@UpdateTime time   
)
AS


				
				INSERT INTO [dbo].[Province]
					(
					[RowNumber]
					,[AdminId]
					,[ObjectId]
					,[ParentId]
					,[PlateCode]
					,[AreaId]
					,[PhoneCode]
					,[ProvinceName]
					,[Longitude]
					,[Latitude]
					,[Type]
					,[CreateDate]
					,[CreateTime]
					,[UpdateDate]
					,[UpdateTime]
					)
				VALUES
					(
					@RowNumber
					,@AdminId
					,@ObjectId
					,@ParentId
					,@PlateCode
					,@AreaId
					,@PhoneCode
					,@ProvinceName
					,@Longitude
					,@Latitude
					,@Type
					,@CreateDate
					,@CreateTime
					,@UpdateDate
					,@UpdateTime
					)
				-- Get the identity value
				SET @Id = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_Province_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_Province_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_Province_Update
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Updates a record in the Province table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Province_Update
(

	@Id int   ,

	@RowNumber int   ,

	@AdminId bigint   ,

	@ObjectId bigint   ,

	@ParentId bigint   ,

	@PlateCode varchar (2)  ,

	@AreaId int   ,

	@PhoneCode varchar (3)  ,

	@ProvinceName nvarchar (250)  ,

	@Longitude varchar (10)  ,

	@Latitude varchar (10)  ,

	@Type int   ,

	@CreateDate date   ,

	@CreateTime time   ,

	@UpdateDate date   ,

	@UpdateTime time   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[Province]
				SET
					[RowNumber] = @RowNumber
					,[AdminId] = @AdminId
					,[ObjectId] = @ObjectId
					,[ParentId] = @ParentId
					,[PlateCode] = @PlateCode
					,[AreaId] = @AreaId
					,[PhoneCode] = @PhoneCode
					,[ProvinceName] = @ProvinceName
					,[Longitude] = @Longitude
					,[Latitude] = @Latitude
					,[Type] = @Type
					,[CreateDate] = @CreateDate
					,[CreateTime] = @CreateTime
					,[UpdateDate] = @UpdateDate
					,[UpdateTime] = @UpdateTime
				WHERE
[Id] = @Id 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_Province_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_Province_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_Province_Delete
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Deletes a record in the Province table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Province_Delete
(

	@Id int   
)
AS


				DELETE FROM [dbo].[Province] WITH (ROWLOCK) 
				WHERE
					[Id] = @Id
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_Province_GetByProvinceName procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_Province_GetByProvinceName') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_Province_GetByProvinceName
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Select records from the Province table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Province_GetByProvinceName
(

	@ProvinceName nvarchar (250)  
)
AS


				SELECT
					[Id],
					[RowNumber],
					[AdminId],
					[ObjectId],
					[ParentId],
					[PlateCode],
					[AreaId],
					[PhoneCode],
					[ProvinceName],
					[Longitude],
					[Latitude],
					[Type],
					[CreateDate],
					[CreateTime],
					[UpdateDate],
					[UpdateTime]
				FROM
					[dbo].[Province]
				WHERE
					[ProvinceName] = @ProvinceName
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_Province_GetById procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_Province_GetById') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_Province_GetById
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Select records from the Province table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Province_GetById
(

	@Id int   
)
AS


				SELECT
					[Id],
					[RowNumber],
					[AdminId],
					[ObjectId],
					[ParentId],
					[PlateCode],
					[AreaId],
					[PhoneCode],
					[ProvinceName],
					[Longitude],
					[Latitude],
					[Type],
					[CreateDate],
					[CreateTime],
					[UpdateDate],
					[UpdateTime]
				FROM
					[dbo].[Province]
				WHERE
					[Id] = @Id
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_Province_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_Province_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_Province_Find
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Finds records in the Province table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Province_Find
(

	@SearchUsingOR bit   = null ,

	@Id int   = null ,

	@RowNumber int   = null ,

	@AdminId bigint   = null ,

	@ObjectId bigint   = null ,

	@ParentId bigint   = null ,

	@PlateCode varchar (2)  = null ,

	@AreaId int   = null ,

	@PhoneCode varchar (3)  = null ,

	@ProvinceName nvarchar (250)  = null ,

	@Longitude varchar (10)  = null ,

	@Latitude varchar (10)  = null ,

	@Type int   = null ,

	@CreateDate date   = null ,

	@CreateTime time   = null ,

	@UpdateDate date   = null ,

	@UpdateTime time   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [Id]
	, [RowNumber]
	, [AdminId]
	, [ObjectId]
	, [ParentId]
	, [PlateCode]
	, [AreaId]
	, [PhoneCode]
	, [ProvinceName]
	, [Longitude]
	, [Latitude]
	, [Type]
	, [CreateDate]
	, [CreateTime]
	, [UpdateDate]
	, [UpdateTime]
    FROM
	[dbo].[Province]
    WHERE 
	 ([Id] = @Id OR @Id IS NULL)
	AND ([RowNumber] = @RowNumber OR @RowNumber IS NULL)
	AND ([AdminId] = @AdminId OR @AdminId IS NULL)
	AND ([ObjectId] = @ObjectId OR @ObjectId IS NULL)
	AND ([ParentId] = @ParentId OR @ParentId IS NULL)
	AND ([PlateCode] = @PlateCode OR @PlateCode IS NULL)
	AND ([AreaId] = @AreaId OR @AreaId IS NULL)
	AND ([PhoneCode] = @PhoneCode OR @PhoneCode IS NULL)
	AND ([ProvinceName] = @ProvinceName OR @ProvinceName IS NULL)
	AND ([Longitude] = @Longitude OR @Longitude IS NULL)
	AND ([Latitude] = @Latitude OR @Latitude IS NULL)
	AND ([Type] = @Type OR @Type IS NULL)
	AND ([CreateDate] = @CreateDate OR @CreateDate IS NULL)
	AND ([CreateTime] = @CreateTime OR @CreateTime IS NULL)
	AND ([UpdateDate] = @UpdateDate OR @UpdateDate IS NULL)
	AND ([UpdateTime] = @UpdateTime OR @UpdateTime IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [Id]
	, [RowNumber]
	, [AdminId]
	, [ObjectId]
	, [ParentId]
	, [PlateCode]
	, [AreaId]
	, [PhoneCode]
	, [ProvinceName]
	, [Longitude]
	, [Latitude]
	, [Type]
	, [CreateDate]
	, [CreateTime]
	, [UpdateDate]
	, [UpdateTime]
    FROM
	[dbo].[Province]
    WHERE 
	 ([Id] = @Id AND @Id is not null)
	OR ([RowNumber] = @RowNumber AND @RowNumber is not null)
	OR ([AdminId] = @AdminId AND @AdminId is not null)
	OR ([ObjectId] = @ObjectId AND @ObjectId is not null)
	OR ([ParentId] = @ParentId AND @ParentId is not null)
	OR ([PlateCode] = @PlateCode AND @PlateCode is not null)
	OR ([AreaId] = @AreaId AND @AreaId is not null)
	OR ([PhoneCode] = @PhoneCode AND @PhoneCode is not null)
	OR ([ProvinceName] = @ProvinceName AND @ProvinceName is not null)
	OR ([Longitude] = @Longitude AND @Longitude is not null)
	OR ([Latitude] = @Latitude AND @Latitude is not null)
	OR ([Type] = @Type AND @Type is not null)
	OR ([CreateDate] = @CreateDate AND @CreateDate is not null)
	OR ([CreateTime] = @CreateTime AND @CreateTime is not null)
	OR ([UpdateDate] = @UpdateDate AND @UpdateDate is not null)
	OR ([UpdateTime] = @UpdateTime AND @UpdateTime is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_ClientFather_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_ClientFather_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_ClientFather_Get_List
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Gets all records from the ClientFather table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_ClientFather_Get_List

AS


				
				SELECT
					[FatherId],
					[FullName],
					[Title],
					[Email],
					[Fax],
					[HomePhone],
					[BusinessPhone],
					[MobilePhone],
					[JobId],
					[StatusId],
					[Notes],
					[CreateOn],
					[UpdateOn],
					[UserId]
				FROM
					[dbo].[ClientFather]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_ClientFather_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_ClientFather_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_ClientFather_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Gets records from the ClientFather table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_ClientFather_GetPaged
(

	@WhereClause varchar (8000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy IS NULL OR LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[FatherId]'
				END

				-- SQL Server 2005 Paging
				DECLARE @SQL AS nvarchar(MAX)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [FatherId]'
				SET @SQL = @SQL + ', [FullName]'
				SET @SQL = @SQL + ', [Title]'
				SET @SQL = @SQL + ', [Email]'
				SET @SQL = @SQL + ', [Fax]'
				SET @SQL = @SQL + ', [HomePhone]'
				SET @SQL = @SQL + ', [BusinessPhone]'
				SET @SQL = @SQL + ', [MobilePhone]'
				SET @SQL = @SQL + ', [JobId]'
				SET @SQL = @SQL + ', [StatusId]'
				SET @SQL = @SQL + ', [Notes]'
				SET @SQL = @SQL + ', [CreateOn]'
				SET @SQL = @SQL + ', [UpdateOn]'
				SET @SQL = @SQL + ', [UserId]'
				SET @SQL = @SQL + ' FROM [dbo].[ClientFather]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [FatherId],'
				SET @SQL = @SQL + ' [FullName],'
				SET @SQL = @SQL + ' [Title],'
				SET @SQL = @SQL + ' [Email],'
				SET @SQL = @SQL + ' [Fax],'
				SET @SQL = @SQL + ' [HomePhone],'
				SET @SQL = @SQL + ' [BusinessPhone],'
				SET @SQL = @SQL + ' [MobilePhone],'
				SET @SQL = @SQL + ' [JobId],'
				SET @SQL = @SQL + ' [StatusId],'
				SET @SQL = @SQL + ' [Notes],'
				SET @SQL = @SQL + ' [CreateOn],'
				SET @SQL = @SQL + ' [UpdateOn],'
				SET @SQL = @SQL + ' [UserId]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + CONVERT(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				EXEC sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(1) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[ClientFather]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_ClientFather_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_ClientFather_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_ClientFather_Insert
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Inserts a record into the ClientFather table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_ClientFather_Insert
(

	@FatherId int    OUTPUT,

	@FullName varchar (50)  ,

	@Title varchar (50)  ,

	@Email varchar (100)  ,

	@Fax varchar (50)  ,

	@HomePhone varchar (50)  ,

	@BusinessPhone varchar (50)  ,

	@MobilePhone varchar (50)  ,

	@JobId int   ,

	@StatusId tinyint   ,

	@Notes nvarchar (500)  ,

	@CreateOn smalldatetime   ,

	@UpdateOn smalldatetime   ,

	@UserId int   
)
AS


				
				INSERT INTO [dbo].[ClientFather]
					(
					[FullName]
					,[Title]
					,[Email]
					,[Fax]
					,[HomePhone]
					,[BusinessPhone]
					,[MobilePhone]
					,[JobId]
					,[StatusId]
					,[Notes]
					,[CreateOn]
					,[UpdateOn]
					,[UserId]
					)
				VALUES
					(
					@FullName
					,@Title
					,@Email
					,@Fax
					,@HomePhone
					,@BusinessPhone
					,@MobilePhone
					,@JobId
					,@StatusId
					,@Notes
					,@CreateOn
					,@UpdateOn
					,@UserId
					)
				-- Get the identity value
				SET @FatherId = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_ClientFather_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_ClientFather_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_ClientFather_Update
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Updates a record in the ClientFather table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_ClientFather_Update
(

	@FatherId int   ,

	@FullName varchar (50)  ,

	@Title varchar (50)  ,

	@Email varchar (100)  ,

	@Fax varchar (50)  ,

	@HomePhone varchar (50)  ,

	@BusinessPhone varchar (50)  ,

	@MobilePhone varchar (50)  ,

	@JobId int   ,

	@StatusId tinyint   ,

	@Notes nvarchar (500)  ,

	@CreateOn smalldatetime   ,

	@UpdateOn smalldatetime   ,

	@UserId int   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[ClientFather]
				SET
					[FullName] = @FullName
					,[Title] = @Title
					,[Email] = @Email
					,[Fax] = @Fax
					,[HomePhone] = @HomePhone
					,[BusinessPhone] = @BusinessPhone
					,[MobilePhone] = @MobilePhone
					,[JobId] = @JobId
					,[StatusId] = @StatusId
					,[Notes] = @Notes
					,[CreateOn] = @CreateOn
					,[UpdateOn] = @UpdateOn
					,[UserId] = @UserId
				WHERE
[FatherId] = @FatherId 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_ClientFather_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_ClientFather_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_ClientFather_Delete
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Deletes a record in the ClientFather table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_ClientFather_Delete
(

	@FatherId int   
)
AS


				DELETE FROM [dbo].[ClientFather] WITH (ROWLOCK) 
				WHERE
					[FatherId] = @FatherId
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_ClientFather_GetByFatherId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_ClientFather_GetByFatherId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_ClientFather_GetByFatherId
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Select records from the ClientFather table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_ClientFather_GetByFatherId
(

	@FatherId int   
)
AS


				SELECT
					[FatherId],
					[FullName],
					[Title],
					[Email],
					[Fax],
					[HomePhone],
					[BusinessPhone],
					[MobilePhone],
					[JobId],
					[StatusId],
					[Notes],
					[CreateOn],
					[UpdateOn],
					[UserId]
				FROM
					[dbo].[ClientFather]
				WHERE
					[FatherId] = @FatherId
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_ClientFather_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_ClientFather_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_ClientFather_Find
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Finds records in the ClientFather table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_ClientFather_Find
(

	@SearchUsingOR bit   = null ,

	@FatherId int   = null ,

	@FullName varchar (50)  = null ,

	@Title varchar (50)  = null ,

	@Email varchar (100)  = null ,

	@Fax varchar (50)  = null ,

	@HomePhone varchar (50)  = null ,

	@BusinessPhone varchar (50)  = null ,

	@MobilePhone varchar (50)  = null ,

	@JobId int   = null ,

	@StatusId tinyint   = null ,

	@Notes nvarchar (500)  = null ,

	@CreateOn smalldatetime   = null ,

	@UpdateOn smalldatetime   = null ,

	@UserId int   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [FatherId]
	, [FullName]
	, [Title]
	, [Email]
	, [Fax]
	, [HomePhone]
	, [BusinessPhone]
	, [MobilePhone]
	, [JobId]
	, [StatusId]
	, [Notes]
	, [CreateOn]
	, [UpdateOn]
	, [UserId]
    FROM
	[dbo].[ClientFather]
    WHERE 
	 ([FatherId] = @FatherId OR @FatherId IS NULL)
	AND ([FullName] = @FullName OR @FullName IS NULL)
	AND ([Title] = @Title OR @Title IS NULL)
	AND ([Email] = @Email OR @Email IS NULL)
	AND ([Fax] = @Fax OR @Fax IS NULL)
	AND ([HomePhone] = @HomePhone OR @HomePhone IS NULL)
	AND ([BusinessPhone] = @BusinessPhone OR @BusinessPhone IS NULL)
	AND ([MobilePhone] = @MobilePhone OR @MobilePhone IS NULL)
	AND ([JobId] = @JobId OR @JobId IS NULL)
	AND ([StatusId] = @StatusId OR @StatusId IS NULL)
	AND ([Notes] = @Notes OR @Notes IS NULL)
	AND ([CreateOn] = @CreateOn OR @CreateOn IS NULL)
	AND ([UpdateOn] = @UpdateOn OR @UpdateOn IS NULL)
	AND ([UserId] = @UserId OR @UserId IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [FatherId]
	, [FullName]
	, [Title]
	, [Email]
	, [Fax]
	, [HomePhone]
	, [BusinessPhone]
	, [MobilePhone]
	, [JobId]
	, [StatusId]
	, [Notes]
	, [CreateOn]
	, [UpdateOn]
	, [UserId]
    FROM
	[dbo].[ClientFather]
    WHERE 
	 ([FatherId] = @FatherId AND @FatherId is not null)
	OR ([FullName] = @FullName AND @FullName is not null)
	OR ([Title] = @Title AND @Title is not null)
	OR ([Email] = @Email AND @Email is not null)
	OR ([Fax] = @Fax AND @Fax is not null)
	OR ([HomePhone] = @HomePhone AND @HomePhone is not null)
	OR ([BusinessPhone] = @BusinessPhone AND @BusinessPhone is not null)
	OR ([MobilePhone] = @MobilePhone AND @MobilePhone is not null)
	OR ([JobId] = @JobId AND @JobId is not null)
	OR ([StatusId] = @StatusId AND @StatusId is not null)
	OR ([Notes] = @Notes AND @Notes is not null)
	OR ([CreateOn] = @CreateOn AND @CreateOn is not null)
	OR ([UpdateOn] = @UpdateOn AND @UpdateOn is not null)
	OR ([UserId] = @UserId AND @UserId is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_Client_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_Client_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_Client_Get_List
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Gets all records from the Client table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Client_Get_List

AS


				
				SELECT
					[ClientId],
					[FileNumber],
					[FirstContactDate],
					[FullName],
					[MiddleName],
					[Reference],
					[MotherId],
					[FatherId],
					[AddressId],
					[IdCard],
					[Gender],
					[Blood],
					[BirthDate],
					[Age],
					[Pediatrician],
					[CountOfChild],
					[FamilyStatus],
					[Notes],
					[CreateOn],
					[UpdateOn],
					[UserId]
				FROM
					[dbo].[Client]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_Client_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_Client_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_Client_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Gets records from the Client table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Client_GetPaged
(

	@WhereClause varchar (8000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy IS NULL OR LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[ClientId]'
				END

				-- SQL Server 2005 Paging
				DECLARE @SQL AS nvarchar(MAX)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [ClientId]'
				SET @SQL = @SQL + ', [FileNumber]'
				SET @SQL = @SQL + ', [FirstContactDate]'
				SET @SQL = @SQL + ', [FullName]'
				SET @SQL = @SQL + ', [MiddleName]'
				SET @SQL = @SQL + ', [Reference]'
				SET @SQL = @SQL + ', [MotherId]'
				SET @SQL = @SQL + ', [FatherId]'
				SET @SQL = @SQL + ', [AddressId]'
				SET @SQL = @SQL + ', [IdCard]'
				SET @SQL = @SQL + ', [Gender]'
				SET @SQL = @SQL + ', [Blood]'
				SET @SQL = @SQL + ', [BirthDate]'
				SET @SQL = @SQL + ', [Age]'
				SET @SQL = @SQL + ', [Pediatrician]'
				SET @SQL = @SQL + ', [CountOfChild]'
				SET @SQL = @SQL + ', [FamilyStatus]'
				SET @SQL = @SQL + ', [Notes]'
				SET @SQL = @SQL + ', [CreateOn]'
				SET @SQL = @SQL + ', [UpdateOn]'
				SET @SQL = @SQL + ', [UserId]'
				SET @SQL = @SQL + ' FROM [dbo].[Client]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [ClientId],'
				SET @SQL = @SQL + ' [FileNumber],'
				SET @SQL = @SQL + ' [FirstContactDate],'
				SET @SQL = @SQL + ' [FullName],'
				SET @SQL = @SQL + ' [MiddleName],'
				SET @SQL = @SQL + ' [Reference],'
				SET @SQL = @SQL + ' [MotherId],'
				SET @SQL = @SQL + ' [FatherId],'
				SET @SQL = @SQL + ' [AddressId],'
				SET @SQL = @SQL + ' [IdCard],'
				SET @SQL = @SQL + ' [Gender],'
				SET @SQL = @SQL + ' [Blood],'
				SET @SQL = @SQL + ' [BirthDate],'
				SET @SQL = @SQL + ' [Age],'
				SET @SQL = @SQL + ' [Pediatrician],'
				SET @SQL = @SQL + ' [CountOfChild],'
				SET @SQL = @SQL + ' [FamilyStatus],'
				SET @SQL = @SQL + ' [Notes],'
				SET @SQL = @SQL + ' [CreateOn],'
				SET @SQL = @SQL + ' [UpdateOn],'
				SET @SQL = @SQL + ' [UserId]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + CONVERT(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				EXEC sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(1) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[Client]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_Client_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_Client_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_Client_Insert
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Inserts a record into the Client table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Client_Insert
(

	@ClientId int    OUTPUT,

	@FileNumber int   ,

	@FirstContactDate smalldatetime   ,

	@FullName varchar (100)  ,

	@MiddleName varchar (100)  ,

	@Reference varchar (250)  ,

	@MotherId int   ,

	@FatherId int   ,

	@AddressId int   ,

	@IdCard varchar (11)  ,

	@Gender tinyint   ,

	@Blood tinyint   ,

	@BirthDate datetime   ,

	@Age int   ,

	@Pediatrician varchar (100)  ,

	@CountOfChild int   ,

	@FamilyStatus tinyint   ,

	@Notes varchar (MAX)  ,

	@CreateOn smalldatetime   ,

	@UpdateOn smalldatetime   ,

	@UserId int   
)
AS


				
				INSERT INTO [dbo].[Client]
					(
					[FileNumber]
					,[FirstContactDate]
					,[FullName]
					,[MiddleName]
					,[Reference]
					,[MotherId]
					,[FatherId]
					,[AddressId]
					,[IdCard]
					,[Gender]
					,[Blood]
					,[BirthDate]
					,[Age]
					,[Pediatrician]
					,[CountOfChild]
					,[FamilyStatus]
					,[Notes]
					,[CreateOn]
					,[UpdateOn]
					,[UserId]
					)
				VALUES
					(
					@FileNumber
					,@FirstContactDate
					,@FullName
					,@MiddleName
					,@Reference
					,@MotherId
					,@FatherId
					,@AddressId
					,@IdCard
					,@Gender
					,@Blood
					,@BirthDate
					,@Age
					,@Pediatrician
					,@CountOfChild
					,@FamilyStatus
					,@Notes
					,@CreateOn
					,@UpdateOn
					,@UserId
					)
				-- Get the identity value
				SET @ClientId = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_Client_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_Client_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_Client_Update
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Updates a record in the Client table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Client_Update
(

	@ClientId int   ,

	@FileNumber int   ,

	@FirstContactDate smalldatetime   ,

	@FullName varchar (100)  ,

	@MiddleName varchar (100)  ,

	@Reference varchar (250)  ,

	@MotherId int   ,

	@FatherId int   ,

	@AddressId int   ,

	@IdCard varchar (11)  ,

	@Gender tinyint   ,

	@Blood tinyint   ,

	@BirthDate datetime   ,

	@Age int   ,

	@Pediatrician varchar (100)  ,

	@CountOfChild int   ,

	@FamilyStatus tinyint   ,

	@Notes varchar (MAX)  ,

	@CreateOn smalldatetime   ,

	@UpdateOn smalldatetime   ,

	@UserId int   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[Client]
				SET
					[FileNumber] = @FileNumber
					,[FirstContactDate] = @FirstContactDate
					,[FullName] = @FullName
					,[MiddleName] = @MiddleName
					,[Reference] = @Reference
					,[MotherId] = @MotherId
					,[FatherId] = @FatherId
					,[AddressId] = @AddressId
					,[IdCard] = @IdCard
					,[Gender] = @Gender
					,[Blood] = @Blood
					,[BirthDate] = @BirthDate
					,[Age] = @Age
					,[Pediatrician] = @Pediatrician
					,[CountOfChild] = @CountOfChild
					,[FamilyStatus] = @FamilyStatus
					,[Notes] = @Notes
					,[CreateOn] = @CreateOn
					,[UpdateOn] = @UpdateOn
					,[UserId] = @UserId
				WHERE
[ClientId] = @ClientId 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_Client_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_Client_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_Client_Delete
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Deletes a record in the Client table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Client_Delete
(

	@ClientId int   
)
AS


				DELETE FROM [dbo].[Client] WITH (ROWLOCK) 
				WHERE
					[ClientId] = @ClientId
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_Client_GetByAddressId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_Client_GetByAddressId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_Client_GetByAddressId
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Select records from the Client table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Client_GetByAddressId
(

	@AddressId int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[ClientId],
					[FileNumber],
					[FirstContactDate],
					[FullName],
					[MiddleName],
					[Reference],
					[MotherId],
					[FatherId],
					[AddressId],
					[IdCard],
					[Gender],
					[Blood],
					[BirthDate],
					[Age],
					[Pediatrician],
					[CountOfChild],
					[FamilyStatus],
					[Notes],
					[CreateOn],
					[UpdateOn],
					[UserId]
				FROM
					[dbo].[Client]
				WHERE
					[AddressId] = @AddressId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_Client_GetByFatherId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_Client_GetByFatherId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_Client_GetByFatherId
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Select records from the Client table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Client_GetByFatherId
(

	@FatherId int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[ClientId],
					[FileNumber],
					[FirstContactDate],
					[FullName],
					[MiddleName],
					[Reference],
					[MotherId],
					[FatherId],
					[AddressId],
					[IdCard],
					[Gender],
					[Blood],
					[BirthDate],
					[Age],
					[Pediatrician],
					[CountOfChild],
					[FamilyStatus],
					[Notes],
					[CreateOn],
					[UpdateOn],
					[UserId]
				FROM
					[dbo].[Client]
				WHERE
					[FatherId] = @FatherId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_Client_GetByMotherId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_Client_GetByMotherId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_Client_GetByMotherId
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Select records from the Client table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Client_GetByMotherId
(

	@MotherId int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[ClientId],
					[FileNumber],
					[FirstContactDate],
					[FullName],
					[MiddleName],
					[Reference],
					[MotherId],
					[FatherId],
					[AddressId],
					[IdCard],
					[Gender],
					[Blood],
					[BirthDate],
					[Age],
					[Pediatrician],
					[CountOfChild],
					[FamilyStatus],
					[Notes],
					[CreateOn],
					[UpdateOn],
					[UserId]
				FROM
					[dbo].[Client]
				WHERE
					[MotherId] = @MotherId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_Client_GetByFileNumber procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_Client_GetByFileNumber') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_Client_GetByFileNumber
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Select records from the Client table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Client_GetByFileNumber
(

	@FileNumber int   
)
AS


				SELECT
					[ClientId],
					[FileNumber],
					[FirstContactDate],
					[FullName],
					[MiddleName],
					[Reference],
					[MotherId],
					[FatherId],
					[AddressId],
					[IdCard],
					[Gender],
					[Blood],
					[BirthDate],
					[Age],
					[Pediatrician],
					[CountOfChild],
					[FamilyStatus],
					[Notes],
					[CreateOn],
					[UpdateOn],
					[UserId]
				FROM
					[dbo].[Client]
				WHERE
					[FileNumber] = @FileNumber
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_Client_GetByClientId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_Client_GetByClientId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_Client_GetByClientId
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Select records from the Client table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Client_GetByClientId
(

	@ClientId int   
)
AS


				SELECT
					[ClientId],
					[FileNumber],
					[FirstContactDate],
					[FullName],
					[MiddleName],
					[Reference],
					[MotherId],
					[FatherId],
					[AddressId],
					[IdCard],
					[Gender],
					[Blood],
					[BirthDate],
					[Age],
					[Pediatrician],
					[CountOfChild],
					[FamilyStatus],
					[Notes],
					[CreateOn],
					[UpdateOn],
					[UserId]
				FROM
					[dbo].[Client]
				WHERE
					[ClientId] = @ClientId
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_Client_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_Client_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_Client_Find
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Finds records in the Client table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Client_Find
(

	@SearchUsingOR bit   = null ,

	@ClientId int   = null ,

	@FileNumber int   = null ,

	@FirstContactDate smalldatetime   = null ,

	@FullName varchar (100)  = null ,

	@MiddleName varchar (100)  = null ,

	@Reference varchar (250)  = null ,

	@MotherId int   = null ,

	@FatherId int   = null ,

	@AddressId int   = null ,

	@IdCard varchar (11)  = null ,

	@Gender tinyint   = null ,

	@Blood tinyint   = null ,

	@BirthDate datetime   = null ,

	@Age int   = null ,

	@Pediatrician varchar (100)  = null ,

	@CountOfChild int   = null ,

	@FamilyStatus tinyint   = null ,

	@Notes varchar (MAX)  = null ,

	@CreateOn smalldatetime   = null ,

	@UpdateOn smalldatetime   = null ,

	@UserId int   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [ClientId]
	, [FileNumber]
	, [FirstContactDate]
	, [FullName]
	, [MiddleName]
	, [Reference]
	, [MotherId]
	, [FatherId]
	, [AddressId]
	, [IdCard]
	, [Gender]
	, [Blood]
	, [BirthDate]
	, [Age]
	, [Pediatrician]
	, [CountOfChild]
	, [FamilyStatus]
	, [Notes]
	, [CreateOn]
	, [UpdateOn]
	, [UserId]
    FROM
	[dbo].[Client]
    WHERE 
	 ([ClientId] = @ClientId OR @ClientId IS NULL)
	AND ([FileNumber] = @FileNumber OR @FileNumber IS NULL)
	AND ([FirstContactDate] = @FirstContactDate OR @FirstContactDate IS NULL)
	AND ([FullName] = @FullName OR @FullName IS NULL)
	AND ([MiddleName] = @MiddleName OR @MiddleName IS NULL)
	AND ([Reference] = @Reference OR @Reference IS NULL)
	AND ([MotherId] = @MotherId OR @MotherId IS NULL)
	AND ([FatherId] = @FatherId OR @FatherId IS NULL)
	AND ([AddressId] = @AddressId OR @AddressId IS NULL)
	AND ([IdCard] = @IdCard OR @IdCard IS NULL)
	AND ([Gender] = @Gender OR @Gender IS NULL)
	AND ([Blood] = @Blood OR @Blood IS NULL)
	AND ([BirthDate] = @BirthDate OR @BirthDate IS NULL)
	AND ([Age] = @Age OR @Age IS NULL)
	AND ([Pediatrician] = @Pediatrician OR @Pediatrician IS NULL)
	AND ([CountOfChild] = @CountOfChild OR @CountOfChild IS NULL)
	AND ([FamilyStatus] = @FamilyStatus OR @FamilyStatus IS NULL)
	AND ([Notes] = @Notes OR @Notes IS NULL)
	AND ([CreateOn] = @CreateOn OR @CreateOn IS NULL)
	AND ([UpdateOn] = @UpdateOn OR @UpdateOn IS NULL)
	AND ([UserId] = @UserId OR @UserId IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [ClientId]
	, [FileNumber]
	, [FirstContactDate]
	, [FullName]
	, [MiddleName]
	, [Reference]
	, [MotherId]
	, [FatherId]
	, [AddressId]
	, [IdCard]
	, [Gender]
	, [Blood]
	, [BirthDate]
	, [Age]
	, [Pediatrician]
	, [CountOfChild]
	, [FamilyStatus]
	, [Notes]
	, [CreateOn]
	, [UpdateOn]
	, [UserId]
    FROM
	[dbo].[Client]
    WHERE 
	 ([ClientId] = @ClientId AND @ClientId is not null)
	OR ([FileNumber] = @FileNumber AND @FileNumber is not null)
	OR ([FirstContactDate] = @FirstContactDate AND @FirstContactDate is not null)
	OR ([FullName] = @FullName AND @FullName is not null)
	OR ([MiddleName] = @MiddleName AND @MiddleName is not null)
	OR ([Reference] = @Reference AND @Reference is not null)
	OR ([MotherId] = @MotherId AND @MotherId is not null)
	OR ([FatherId] = @FatherId AND @FatherId is not null)
	OR ([AddressId] = @AddressId AND @AddressId is not null)
	OR ([IdCard] = @IdCard AND @IdCard is not null)
	OR ([Gender] = @Gender AND @Gender is not null)
	OR ([Blood] = @Blood AND @Blood is not null)
	OR ([BirthDate] = @BirthDate AND @BirthDate is not null)
	OR ([Age] = @Age AND @Age is not null)
	OR ([Pediatrician] = @Pediatrician AND @Pediatrician is not null)
	OR ([CountOfChild] = @CountOfChild AND @CountOfChild is not null)
	OR ([FamilyStatus] = @FamilyStatus AND @FamilyStatus is not null)
	OR ([Notes] = @Notes AND @Notes is not null)
	OR ([CreateOn] = @CreateOn AND @CreateOn is not null)
	OR ([UpdateOn] = @UpdateOn AND @UpdateOn is not null)
	OR ([UserId] = @UserId AND @UserId is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_ClientDoc_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_ClientDoc_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_ClientDoc_Get_List
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Gets all records from the ClientDoc table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_ClientDoc_Get_List

AS


				
				SELECT
					[FileId],
					[ClientId],
					[FileName],
					[FullName],
					[FilePath],
					[CreationDate],
					[CreationTime],
					[FileExtension],
					[FileSize],
					[FileContent],
					[CreateOn],
					[UpdateOn],
					[CreateUserId]
				FROM
					[dbo].[ClientDoc]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_ClientDoc_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_ClientDoc_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_ClientDoc_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Gets records from the ClientDoc table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_ClientDoc_GetPaged
(

	@WhereClause varchar (8000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy IS NULL OR LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[FileId]'
				END

				-- SQL Server 2005 Paging
				DECLARE @SQL AS nvarchar(MAX)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [FileId]'
				SET @SQL = @SQL + ', [ClientId]'
				SET @SQL = @SQL + ', [FileName]'
				SET @SQL = @SQL + ', [FullName]'
				SET @SQL = @SQL + ', [FilePath]'
				SET @SQL = @SQL + ', [CreationDate]'
				SET @SQL = @SQL + ', [CreationTime]'
				SET @SQL = @SQL + ', [FileExtension]'
				SET @SQL = @SQL + ', [FileSize]'
				SET @SQL = @SQL + ', [FileContent]'
				SET @SQL = @SQL + ', [CreateOn]'
				SET @SQL = @SQL + ', [UpdateOn]'
				SET @SQL = @SQL + ', [CreateUserId]'
				SET @SQL = @SQL + ' FROM [dbo].[ClientDoc]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [FileId],'
				SET @SQL = @SQL + ' [ClientId],'
				SET @SQL = @SQL + ' [FileName],'
				SET @SQL = @SQL + ' [FullName],'
				SET @SQL = @SQL + ' [FilePath],'
				SET @SQL = @SQL + ' [CreationDate],'
				SET @SQL = @SQL + ' [CreationTime],'
				SET @SQL = @SQL + ' [FileExtension],'
				SET @SQL = @SQL + ' [FileSize],'
				SET @SQL = @SQL + ' [FileContent],'
				SET @SQL = @SQL + ' [CreateOn],'
				SET @SQL = @SQL + ' [UpdateOn],'
				SET @SQL = @SQL + ' [CreateUserId]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + CONVERT(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				EXEC sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(1) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[ClientDoc]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_ClientDoc_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_ClientDoc_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_ClientDoc_Insert
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Inserts a record into the ClientDoc table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_ClientDoc_Insert
(

	@FileId int   ,

	@ClientId int   ,

	@FileName varchar (100)  ,

	@FullName varchar (250)  ,

	@FilePath varchar (250)  ,

	@CreationDate date   ,

	@CreationTime time   ,

	@FileExtension char (5)  ,

	@FileSize float   ,

	@FileContent varbinary (MAX)  ,

	@CreateOn datetime   ,

	@UpdateOn datetime   ,

	@CreateUserId int   
)
AS


				
				INSERT INTO [dbo].[ClientDoc]
					(
					[FileId]
					,[ClientId]
					,[FileName]
					,[FullName]
					,[FilePath]
					,[CreationDate]
					,[CreationTime]
					,[FileExtension]
					,[FileSize]
					,[FileContent]
					,[CreateOn]
					,[UpdateOn]
					,[CreateUserId]
					)
				VALUES
					(
					@FileId
					,@ClientId
					,@FileName
					,@FullName
					,@FilePath
					,@CreationDate
					,@CreationTime
					,@FileExtension
					,@FileSize
					,@FileContent
					,@CreateOn
					,@UpdateOn
					,@CreateUserId
					)
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_ClientDoc_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_ClientDoc_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_ClientDoc_Update
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Updates a record in the ClientDoc table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_ClientDoc_Update
(

	@FileId int   ,

	@OriginalFileId int   ,

	@ClientId int   ,

	@FileName varchar (100)  ,

	@FullName varchar (250)  ,

	@FilePath varchar (250)  ,

	@CreationDate date   ,

	@CreationTime time   ,

	@FileExtension char (5)  ,

	@FileSize float   ,

	@FileContent varbinary (MAX)  ,

	@CreateOn datetime   ,

	@UpdateOn datetime   ,

	@CreateUserId int   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[ClientDoc]
				SET
					[FileId] = @FileId
					,[ClientId] = @ClientId
					,[FileName] = @FileName
					,[FullName] = @FullName
					,[FilePath] = @FilePath
					,[CreationDate] = @CreationDate
					,[CreationTime] = @CreationTime
					,[FileExtension] = @FileExtension
					,[FileSize] = @FileSize
					,[FileContent] = @FileContent
					,[CreateOn] = @CreateOn
					,[UpdateOn] = @UpdateOn
					,[CreateUserId] = @CreateUserId
				WHERE
[FileId] = @OriginalFileId 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_ClientDoc_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_ClientDoc_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_ClientDoc_Delete
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Deletes a record in the ClientDoc table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_ClientDoc_Delete
(

	@FileId int   
)
AS


				DELETE FROM [dbo].[ClientDoc] WITH (ROWLOCK) 
				WHERE
					[FileId] = @FileId
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_ClientDoc_GetByClientId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_ClientDoc_GetByClientId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_ClientDoc_GetByClientId
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Select records from the ClientDoc table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_ClientDoc_GetByClientId
(

	@ClientId int   
)
AS


				SELECT
					[FileId],
					[ClientId],
					[FileName],
					[FullName],
					[FilePath],
					[CreationDate],
					[CreationTime],
					[FileExtension],
					[FileSize],
					[FileContent],
					[CreateOn],
					[UpdateOn],
					[CreateUserId]
				FROM
					[dbo].[ClientDoc]
				WHERE
					[ClientId] = @ClientId
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_ClientDoc_GetByFileId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_ClientDoc_GetByFileId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_ClientDoc_GetByFileId
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Select records from the ClientDoc table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_ClientDoc_GetByFileId
(

	@FileId int   
)
AS


				SELECT
					[FileId],
					[ClientId],
					[FileName],
					[FullName],
					[FilePath],
					[CreationDate],
					[CreationTime],
					[FileExtension],
					[FileSize],
					[FileContent],
					[CreateOn],
					[UpdateOn],
					[CreateUserId]
				FROM
					[dbo].[ClientDoc]
				WHERE
					[FileId] = @FileId
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_ClientDoc_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_ClientDoc_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_ClientDoc_Find
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Finds records in the ClientDoc table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_ClientDoc_Find
(

	@SearchUsingOR bit   = null ,

	@FileId int   = null ,

	@ClientId int   = null ,

	@FileName varchar (100)  = null ,

	@FullName varchar (250)  = null ,

	@FilePath varchar (250)  = null ,

	@CreationDate date   = null ,

	@CreationTime time   = null ,

	@FileExtension char (5)  = null ,

	@FileSize float   = null ,

	@FileContent varbinary (MAX)  = null ,

	@CreateOn datetime   = null ,

	@UpdateOn datetime   = null ,

	@CreateUserId int   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [FileId]
	, [ClientId]
	, [FileName]
	, [FullName]
	, [FilePath]
	, [CreationDate]
	, [CreationTime]
	, [FileExtension]
	, [FileSize]
	, [FileContent]
	, [CreateOn]
	, [UpdateOn]
	, [CreateUserId]
    FROM
	[dbo].[ClientDoc]
    WHERE 
	 ([FileId] = @FileId OR @FileId IS NULL)
	AND ([ClientId] = @ClientId OR @ClientId IS NULL)
	AND ([FileName] = @FileName OR @FileName IS NULL)
	AND ([FullName] = @FullName OR @FullName IS NULL)
	AND ([FilePath] = @FilePath OR @FilePath IS NULL)
	AND ([CreationDate] = @CreationDate OR @CreationDate IS NULL)
	AND ([CreationTime] = @CreationTime OR @CreationTime IS NULL)
	AND ([FileExtension] = @FileExtension OR @FileExtension IS NULL)
	AND ([FileSize] = @FileSize OR @FileSize IS NULL)
	AND ([CreateOn] = @CreateOn OR @CreateOn IS NULL)
	AND ([UpdateOn] = @UpdateOn OR @UpdateOn IS NULL)
	AND ([CreateUserId] = @CreateUserId OR @CreateUserId IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [FileId]
	, [ClientId]
	, [FileName]
	, [FullName]
	, [FilePath]
	, [CreationDate]
	, [CreationTime]
	, [FileExtension]
	, [FileSize]
	, [FileContent]
	, [CreateOn]
	, [UpdateOn]
	, [CreateUserId]
    FROM
	[dbo].[ClientDoc]
    WHERE 
	 ([FileId] = @FileId AND @FileId is not null)
	OR ([ClientId] = @ClientId AND @ClientId is not null)
	OR ([FileName] = @FileName AND @FileName is not null)
	OR ([FullName] = @FullName AND @FullName is not null)
	OR ([FilePath] = @FilePath AND @FilePath is not null)
	OR ([CreationDate] = @CreationDate AND @CreationDate is not null)
	OR ([CreationTime] = @CreationTime AND @CreationTime is not null)
	OR ([FileExtension] = @FileExtension AND @FileExtension is not null)
	OR ([FileSize] = @FileSize AND @FileSize is not null)
	OR ([CreateOn] = @CreateOn AND @CreateOn is not null)
	OR ([UpdateOn] = @UpdateOn AND @UpdateOn is not null)
	OR ([CreateUserId] = @CreateUserId AND @CreateUserId is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_ClientSchool_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_ClientSchool_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_ClientSchool_Get_List
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Gets all records from the ClientSchool table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_ClientSchool_Get_List

AS


				
				SELECT
					[Id],
					[ClientId],
					[SchoolId],
					[ClassRoomId],
					[Notes],
					[CreateOn],
					[UpdateOn],
					[CreateUserId],
					[UpdateUserId]
				FROM
					[dbo].[ClientSchool]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_ClientSchool_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_ClientSchool_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_ClientSchool_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Gets records from the ClientSchool table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_ClientSchool_GetPaged
(

	@WhereClause varchar (8000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy IS NULL OR LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[Id]'
				END

				-- SQL Server 2005 Paging
				DECLARE @SQL AS nvarchar(MAX)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [Id]'
				SET @SQL = @SQL + ', [ClientId]'
				SET @SQL = @SQL + ', [SchoolId]'
				SET @SQL = @SQL + ', [ClassRoomId]'
				SET @SQL = @SQL + ', [Notes]'
				SET @SQL = @SQL + ', [CreateOn]'
				SET @SQL = @SQL + ', [UpdateOn]'
				SET @SQL = @SQL + ', [CreateUserId]'
				SET @SQL = @SQL + ', [UpdateUserId]'
				SET @SQL = @SQL + ' FROM [dbo].[ClientSchool]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [Id],'
				SET @SQL = @SQL + ' [ClientId],'
				SET @SQL = @SQL + ' [SchoolId],'
				SET @SQL = @SQL + ' [ClassRoomId],'
				SET @SQL = @SQL + ' [Notes],'
				SET @SQL = @SQL + ' [CreateOn],'
				SET @SQL = @SQL + ' [UpdateOn],'
				SET @SQL = @SQL + ' [CreateUserId],'
				SET @SQL = @SQL + ' [UpdateUserId]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + CONVERT(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				EXEC sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(1) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[ClientSchool]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_ClientSchool_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_ClientSchool_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_ClientSchool_Insert
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Inserts a record into the ClientSchool table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_ClientSchool_Insert
(

	@Id int    OUTPUT,

	@ClientId int   ,

	@SchoolId int   ,

	@ClassRoomId tinyint   ,

	@Notes varchar (500)  ,

	@CreateOn smalldatetime   ,

	@UpdateOn smalldatetime   ,

	@CreateUserId int   ,

	@UpdateUserId int   
)
AS


				
				INSERT INTO [dbo].[ClientSchool]
					(
					[ClientId]
					,[SchoolId]
					,[ClassRoomId]
					,[Notes]
					,[CreateOn]
					,[UpdateOn]
					,[CreateUserId]
					,[UpdateUserId]
					)
				VALUES
					(
					@ClientId
					,@SchoolId
					,@ClassRoomId
					,@Notes
					,@CreateOn
					,@UpdateOn
					,@CreateUserId
					,@UpdateUserId
					)
				-- Get the identity value
				SET @Id = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_ClientSchool_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_ClientSchool_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_ClientSchool_Update
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Updates a record in the ClientSchool table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_ClientSchool_Update
(

	@Id int   ,

	@ClientId int   ,

	@SchoolId int   ,

	@ClassRoomId tinyint   ,

	@Notes varchar (500)  ,

	@CreateOn smalldatetime   ,

	@UpdateOn smalldatetime   ,

	@CreateUserId int   ,

	@UpdateUserId int   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[ClientSchool]
				SET
					[ClientId] = @ClientId
					,[SchoolId] = @SchoolId
					,[ClassRoomId] = @ClassRoomId
					,[Notes] = @Notes
					,[CreateOn] = @CreateOn
					,[UpdateOn] = @UpdateOn
					,[CreateUserId] = @CreateUserId
					,[UpdateUserId] = @UpdateUserId
				WHERE
[Id] = @Id 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_ClientSchool_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_ClientSchool_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_ClientSchool_Delete
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Deletes a record in the ClientSchool table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_ClientSchool_Delete
(

	@Id int   
)
AS


				DELETE FROM [dbo].[ClientSchool] WITH (ROWLOCK) 
				WHERE
					[Id] = @Id
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_ClientSchool_GetByClientId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_ClientSchool_GetByClientId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_ClientSchool_GetByClientId
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Select records from the ClientSchool table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_ClientSchool_GetByClientId
(

	@ClientId int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[Id],
					[ClientId],
					[SchoolId],
					[ClassRoomId],
					[Notes],
					[CreateOn],
					[UpdateOn],
					[CreateUserId],
					[UpdateUserId]
				FROM
					[dbo].[ClientSchool]
				WHERE
					[ClientId] = @ClientId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_ClientSchool_GetBySchoolId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_ClientSchool_GetBySchoolId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_ClientSchool_GetBySchoolId
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Select records from the ClientSchool table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_ClientSchool_GetBySchoolId
(

	@SchoolId int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[Id],
					[ClientId],
					[SchoolId],
					[ClassRoomId],
					[Notes],
					[CreateOn],
					[UpdateOn],
					[CreateUserId],
					[UpdateUserId]
				FROM
					[dbo].[ClientSchool]
				WHERE
					[SchoolId] = @SchoolId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_ClientSchool_GetById procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_ClientSchool_GetById') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_ClientSchool_GetById
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Select records from the ClientSchool table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_ClientSchool_GetById
(

	@Id int   
)
AS


				SELECT
					[Id],
					[ClientId],
					[SchoolId],
					[ClassRoomId],
					[Notes],
					[CreateOn],
					[UpdateOn],
					[CreateUserId],
					[UpdateUserId]
				FROM
					[dbo].[ClientSchool]
				WHERE
					[Id] = @Id
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_ClientSchool_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_ClientSchool_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_ClientSchool_Find
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Finds records in the ClientSchool table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_ClientSchool_Find
(

	@SearchUsingOR bit   = null ,

	@Id int   = null ,

	@ClientId int   = null ,

	@SchoolId int   = null ,

	@ClassRoomId tinyint   = null ,

	@Notes varchar (500)  = null ,

	@CreateOn smalldatetime   = null ,

	@UpdateOn smalldatetime   = null ,

	@CreateUserId int   = null ,

	@UpdateUserId int   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [Id]
	, [ClientId]
	, [SchoolId]
	, [ClassRoomId]
	, [Notes]
	, [CreateOn]
	, [UpdateOn]
	, [CreateUserId]
	, [UpdateUserId]
    FROM
	[dbo].[ClientSchool]
    WHERE 
	 ([Id] = @Id OR @Id IS NULL)
	AND ([ClientId] = @ClientId OR @ClientId IS NULL)
	AND ([SchoolId] = @SchoolId OR @SchoolId IS NULL)
	AND ([ClassRoomId] = @ClassRoomId OR @ClassRoomId IS NULL)
	AND ([Notes] = @Notes OR @Notes IS NULL)
	AND ([CreateOn] = @CreateOn OR @CreateOn IS NULL)
	AND ([UpdateOn] = @UpdateOn OR @UpdateOn IS NULL)
	AND ([CreateUserId] = @CreateUserId OR @CreateUserId IS NULL)
	AND ([UpdateUserId] = @UpdateUserId OR @UpdateUserId IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [Id]
	, [ClientId]
	, [SchoolId]
	, [ClassRoomId]
	, [Notes]
	, [CreateOn]
	, [UpdateOn]
	, [CreateUserId]
	, [UpdateUserId]
    FROM
	[dbo].[ClientSchool]
    WHERE 
	 ([Id] = @Id AND @Id is not null)
	OR ([ClientId] = @ClientId AND @ClientId is not null)
	OR ([SchoolId] = @SchoolId AND @SchoolId is not null)
	OR ([ClassRoomId] = @ClassRoomId AND @ClassRoomId is not null)
	OR ([Notes] = @Notes AND @Notes is not null)
	OR ([CreateOn] = @CreateOn AND @CreateOn is not null)
	OR ([UpdateOn] = @UpdateOn AND @UpdateOn is not null)
	OR ([CreateUserId] = @CreateUserId AND @CreateUserId is not null)
	OR ([UpdateUserId] = @UpdateUserId AND @UpdateUserId is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_CalenderAge_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_CalenderAge_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_CalenderAge_Get_List
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Gets all records from the CalenderAge table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_CalenderAge_Get_List

AS


				
				SELECT
					[ID],
					[AgeValue]
				FROM
					[dbo].[CalenderAge]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_CalenderAge_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_CalenderAge_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_CalenderAge_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Gets records from the CalenderAge table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_CalenderAge_GetPaged
(

	@WhereClause varchar (8000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy IS NULL OR LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[ID]'
				END

				-- SQL Server 2005 Paging
				DECLARE @SQL AS nvarchar(MAX)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [ID]'
				SET @SQL = @SQL + ', [AgeValue]'
				SET @SQL = @SQL + ' FROM [dbo].[CalenderAge]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [ID],'
				SET @SQL = @SQL + ' [AgeValue]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + CONVERT(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				EXEC sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(1) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[CalenderAge]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_CalenderAge_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_CalenderAge_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_CalenderAge_Insert
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Inserts a record into the CalenderAge table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_CalenderAge_Insert
(

	@Id int    OUTPUT,

	@AgeValue varchar (50)  
)
AS


				
				INSERT INTO [dbo].[CalenderAge]
					(
					[AgeValue]
					)
				VALUES
					(
					@AgeValue
					)
				-- Get the identity value
				SET @Id = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_CalenderAge_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_CalenderAge_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_CalenderAge_Update
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Updates a record in the CalenderAge table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_CalenderAge_Update
(

	@Id int   ,

	@AgeValue varchar (50)  
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[CalenderAge]
				SET
					[AgeValue] = @AgeValue
				WHERE
[ID] = @Id 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_CalenderAge_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_CalenderAge_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_CalenderAge_Delete
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Deletes a record in the CalenderAge table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_CalenderAge_Delete
(

	@Id int   
)
AS


				DELETE FROM [dbo].[CalenderAge] WITH (ROWLOCK) 
				WHERE
					[ID] = @Id
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_CalenderAge_GetById procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_CalenderAge_GetById') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_CalenderAge_GetById
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Select records from the CalenderAge table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_CalenderAge_GetById
(

	@Id int   
)
AS


				SELECT
					[ID],
					[AgeValue]
				FROM
					[dbo].[CalenderAge]
				WHERE
					[ID] = @Id
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_CalenderAge_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_CalenderAge_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_CalenderAge_Find
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Finds records in the CalenderAge table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_CalenderAge_Find
(

	@SearchUsingOR bit   = null ,

	@Id int   = null ,

	@AgeValue varchar (50)  = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [ID]
	, [AgeValue]
    FROM
	[dbo].[CalenderAge]
    WHERE 
	 ([ID] = @Id OR @Id IS NULL)
	AND ([AgeValue] = @AgeValue OR @AgeValue IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [ID]
	, [AgeValue]
    FROM
	[dbo].[CalenderAge]
    WHERE 
	 ([ID] = @Id AND @Id is not null)
	OR ([AgeValue] = @AgeValue AND @AgeValue is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_Area_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_Area_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_Area_Get_List
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Gets all records from the Area table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Area_Get_List

AS


				
				SELECT
					[Id],
					[AreaName]
				FROM
					[dbo].[Area]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_Area_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_Area_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_Area_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Gets records from the Area table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Area_GetPaged
(

	@WhereClause varchar (8000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy IS NULL OR LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[Id]'
				END

				-- SQL Server 2005 Paging
				DECLARE @SQL AS nvarchar(MAX)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [Id]'
				SET @SQL = @SQL + ', [AreaName]'
				SET @SQL = @SQL + ' FROM [dbo].[Area]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [Id],'
				SET @SQL = @SQL + ' [AreaName]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + CONVERT(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				EXEC sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(1) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[Area]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_Area_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_Area_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_Area_Insert
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Inserts a record into the Area table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Area_Insert
(

	@Id int    OUTPUT,

	@AreaName nvarchar (50)  
)
AS


				
				INSERT INTO [dbo].[Area]
					(
					[AreaName]
					)
				VALUES
					(
					@AreaName
					)
				-- Get the identity value
				SET @Id = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_Area_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_Area_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_Area_Update
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Updates a record in the Area table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Area_Update
(

	@Id int   ,

	@AreaName nvarchar (50)  
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[Area]
				SET
					[AreaName] = @AreaName
				WHERE
[Id] = @Id 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_Area_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_Area_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_Area_Delete
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Deletes a record in the Area table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Area_Delete
(

	@Id int   
)
AS


				DELETE FROM [dbo].[Area] WITH (ROWLOCK) 
				WHERE
					[Id] = @Id
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_Area_GetById procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_Area_GetById') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_Area_GetById
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Select records from the Area table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Area_GetById
(

	@Id int   
)
AS


				SELECT
					[Id],
					[AreaName]
				FROM
					[dbo].[Area]
				WHERE
					[Id] = @Id
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_Area_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_Area_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_Area_Find
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Finds records in the Area table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Area_Find
(

	@SearchUsingOR bit   = null ,

	@Id int   = null ,

	@AreaName nvarchar (50)  = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [Id]
	, [AreaName]
    FROM
	[dbo].[Area]
    WHERE 
	 ([Id] = @Id OR @Id IS NULL)
	AND ([AreaName] = @AreaName OR @AreaName IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [Id]
	, [AreaName]
    FROM
	[dbo].[Area]
    WHERE 
	 ([Id] = @Id AND @Id is not null)
	OR ([AreaName] = @AreaName AND @AreaName is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_QuestionForm_Option_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_QuestionForm_Option_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_QuestionForm_Option_Get_List
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Gets all records from the QuestionForm_Option table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_QuestionForm_Option_Get_List

AS


				
				SELECT
					[OptionID],
					[QuestionID],
					[OptionName]
				FROM
					[dbo].[QuestionForm_Option]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_QuestionForm_Option_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_QuestionForm_Option_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_QuestionForm_Option_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Gets records from the QuestionForm_Option table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_QuestionForm_Option_GetPaged
(

	@WhereClause varchar (8000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy IS NULL OR LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[OptionID]'
				END

				-- SQL Server 2005 Paging
				DECLARE @SQL AS nvarchar(MAX)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [OptionID]'
				SET @SQL = @SQL + ', [QuestionID]'
				SET @SQL = @SQL + ', [OptionName]'
				SET @SQL = @SQL + ' FROM [dbo].[QuestionForm_Option]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [OptionID],'
				SET @SQL = @SQL + ' [QuestionID],'
				SET @SQL = @SQL + ' [OptionName]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + CONVERT(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				EXEC sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(1) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[QuestionForm_Option]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_QuestionForm_Option_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_QuestionForm_Option_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_QuestionForm_Option_Insert
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Inserts a record into the QuestionForm_Option table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_QuestionForm_Option_Insert
(

	@OptionId int    OUTPUT,

	@QuestionId int   ,

	@OptionName varchar (300)  
)
AS


				
				INSERT INTO [dbo].[QuestionForm_Option]
					(
					[QuestionID]
					,[OptionName]
					)
				VALUES
					(
					@QuestionId
					,@OptionName
					)
				-- Get the identity value
				SET @OptionId = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_QuestionForm_Option_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_QuestionForm_Option_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_QuestionForm_Option_Update
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Updates a record in the QuestionForm_Option table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_QuestionForm_Option_Update
(

	@OptionId int   ,

	@QuestionId int   ,

	@OptionName varchar (300)  
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[QuestionForm_Option]
				SET
					[QuestionID] = @QuestionId
					,[OptionName] = @OptionName
				WHERE
[OptionID] = @OptionId 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_QuestionForm_Option_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_QuestionForm_Option_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_QuestionForm_Option_Delete
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Deletes a record in the QuestionForm_Option table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_QuestionForm_Option_Delete
(

	@OptionId int   
)
AS


				DELETE FROM [dbo].[QuestionForm_Option] WITH (ROWLOCK) 
				WHERE
					[OptionID] = @OptionId
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_QuestionForm_Option_GetByQuestionId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_QuestionForm_Option_GetByQuestionId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_QuestionForm_Option_GetByQuestionId
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Select records from the QuestionForm_Option table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_QuestionForm_Option_GetByQuestionId
(

	@QuestionId int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[OptionID],
					[QuestionID],
					[OptionName]
				FROM
					[dbo].[QuestionForm_Option]
				WHERE
					[QuestionID] = @QuestionId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_QuestionForm_Option_GetByOptionId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_QuestionForm_Option_GetByOptionId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_QuestionForm_Option_GetByOptionId
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Select records from the QuestionForm_Option table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_QuestionForm_Option_GetByOptionId
(

	@OptionId int   
)
AS


				SELECT
					[OptionID],
					[QuestionID],
					[OptionName]
				FROM
					[dbo].[QuestionForm_Option]
				WHERE
					[OptionID] = @OptionId
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_QuestionForm_Option_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_QuestionForm_Option_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_QuestionForm_Option_Find
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Finds records in the QuestionForm_Option table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_QuestionForm_Option_Find
(

	@SearchUsingOR bit   = null ,

	@OptionId int   = null ,

	@QuestionId int   = null ,

	@OptionName varchar (300)  = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [OptionID]
	, [QuestionID]
	, [OptionName]
    FROM
	[dbo].[QuestionForm_Option]
    WHERE 
	 ([OptionID] = @OptionId OR @OptionId IS NULL)
	AND ([QuestionID] = @QuestionId OR @QuestionId IS NULL)
	AND ([OptionName] = @OptionName OR @OptionName IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [OptionID]
	, [QuestionID]
	, [OptionName]
    FROM
	[dbo].[QuestionForm_Option]
    WHERE 
	 ([OptionID] = @OptionId AND @OptionId is not null)
	OR ([QuestionID] = @QuestionId AND @QuestionId is not null)
	OR ([OptionName] = @OptionName AND @OptionName is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_Job_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_Job_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_Job_Get_List
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Gets all records from the Job table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Job_Get_List

AS


				
				SELECT
					[JobId],
					[JobCode],
					[JobName],
					[Active],
					[CreateDate]
				FROM
					[dbo].[Job]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_Job_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_Job_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_Job_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Gets records from the Job table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Job_GetPaged
(

	@WhereClause varchar (8000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy IS NULL OR LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[JobId]'
				END

				-- SQL Server 2005 Paging
				DECLARE @SQL AS nvarchar(MAX)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [JobId]'
				SET @SQL = @SQL + ', [JobCode]'
				SET @SQL = @SQL + ', [JobName]'
				SET @SQL = @SQL + ', [Active]'
				SET @SQL = @SQL + ', [CreateDate]'
				SET @SQL = @SQL + ' FROM [dbo].[Job]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [JobId],'
				SET @SQL = @SQL + ' [JobCode],'
				SET @SQL = @SQL + ' [JobName],'
				SET @SQL = @SQL + ' [Active],'
				SET @SQL = @SQL + ' [CreateDate]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + CONVERT(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				EXEC sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(1) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[Job]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_Job_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_Job_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_Job_Insert
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Inserts a record into the Job table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Job_Insert
(

	@JobId int    OUTPUT,

	@JobCode varchar (10)  ,

	@JobName nvarchar (255)  ,

	@Active bit   ,

	@CreateDate smalldatetime   
)
AS


				
				INSERT INTO [dbo].[Job]
					(
					[JobCode]
					,[JobName]
					,[Active]
					,[CreateDate]
					)
				VALUES
					(
					@JobCode
					,@JobName
					,@Active
					,@CreateDate
					)
				-- Get the identity value
				SET @JobId = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_Job_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_Job_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_Job_Update
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Updates a record in the Job table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Job_Update
(

	@JobId int   ,

	@JobCode varchar (10)  ,

	@JobName nvarchar (255)  ,

	@Active bit   ,

	@CreateDate smalldatetime   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[Job]
				SET
					[JobCode] = @JobCode
					,[JobName] = @JobName
					,[Active] = @Active
					,[CreateDate] = @CreateDate
				WHERE
[JobId] = @JobId 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_Job_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_Job_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_Job_Delete
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Deletes a record in the Job table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Job_Delete
(

	@JobId int   
)
AS


				DELETE FROM [dbo].[Job] WITH (ROWLOCK) 
				WHERE
					[JobId] = @JobId
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_Job_GetByJobName procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_Job_GetByJobName') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_Job_GetByJobName
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Select records from the Job table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Job_GetByJobName
(

	@JobName nvarchar (255)  
)
AS


				SELECT
					[JobId],
					[JobCode],
					[JobName],
					[Active],
					[CreateDate]
				FROM
					[dbo].[Job]
				WHERE
					[JobName] = @JobName
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_Job_GetByJobId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_Job_GetByJobId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_Job_GetByJobId
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Select records from the Job table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Job_GetByJobId
(

	@JobId int   
)
AS


				SELECT
					[JobId],
					[JobCode],
					[JobName],
					[Active],
					[CreateDate]
				FROM
					[dbo].[Job]
				WHERE
					[JobId] = @JobId
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_Job_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_Job_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_Job_Find
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Finds records in the Job table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Job_Find
(

	@SearchUsingOR bit   = null ,

	@JobId int   = null ,

	@JobCode varchar (10)  = null ,

	@JobName nvarchar (255)  = null ,

	@Active bit   = null ,

	@CreateDate smalldatetime   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [JobId]
	, [JobCode]
	, [JobName]
	, [Active]
	, [CreateDate]
    FROM
	[dbo].[Job]
    WHERE 
	 ([JobId] = @JobId OR @JobId IS NULL)
	AND ([JobCode] = @JobCode OR @JobCode IS NULL)
	AND ([JobName] = @JobName OR @JobName IS NULL)
	AND ([Active] = @Active OR @Active IS NULL)
	AND ([CreateDate] = @CreateDate OR @CreateDate IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [JobId]
	, [JobCode]
	, [JobName]
	, [Active]
	, [CreateDate]
    FROM
	[dbo].[Job]
    WHERE 
	 ([JobId] = @JobId AND @JobId is not null)
	OR ([JobCode] = @JobCode AND @JobCode is not null)
	OR ([JobName] = @JobName AND @JobName is not null)
	OR ([Active] = @Active AND @Active is not null)
	OR ([CreateDate] = @CreateDate AND @CreateDate is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_ObservationForm_Group_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_ObservationForm_Group_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_ObservationForm_Group_Get_List
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Gets all records from the ObservationForm_Group table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_ObservationForm_Group_Get_List

AS


				
				SELECT
					[GroupID],
					[GroupName],
					[LineNumber]
				FROM
					[dbo].[ObservationForm_Group]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_ObservationForm_Group_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_ObservationForm_Group_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_ObservationForm_Group_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Gets records from the ObservationForm_Group table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_ObservationForm_Group_GetPaged
(

	@WhereClause varchar (8000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy IS NULL OR LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[GroupID]'
				END

				-- SQL Server 2005 Paging
				DECLARE @SQL AS nvarchar(MAX)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [GroupID]'
				SET @SQL = @SQL + ', [GroupName]'
				SET @SQL = @SQL + ', [LineNumber]'
				SET @SQL = @SQL + ' FROM [dbo].[ObservationForm_Group]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [GroupID],'
				SET @SQL = @SQL + ' [GroupName],'
				SET @SQL = @SQL + ' [LineNumber]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + CONVERT(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				EXEC sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(1) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[ObservationForm_Group]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_ObservationForm_Group_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_ObservationForm_Group_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_ObservationForm_Group_Insert
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Inserts a record into the ObservationForm_Group table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_ObservationForm_Group_Insert
(

	@GroupId int    OUTPUT,

	@GroupName varchar (250)  ,

	@LineNumber int   
)
AS


				
				INSERT INTO [dbo].[ObservationForm_Group]
					(
					[GroupName]
					,[LineNumber]
					)
				VALUES
					(
					@GroupName
					,@LineNumber
					)
				-- Get the identity value
				SET @GroupId = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_ObservationForm_Group_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_ObservationForm_Group_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_ObservationForm_Group_Update
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Updates a record in the ObservationForm_Group table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_ObservationForm_Group_Update
(

	@GroupId int   ,

	@GroupName varchar (250)  ,

	@LineNumber int   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[ObservationForm_Group]
				SET
					[GroupName] = @GroupName
					,[LineNumber] = @LineNumber
				WHERE
[GroupID] = @GroupId 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_ObservationForm_Group_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_ObservationForm_Group_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_ObservationForm_Group_Delete
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Deletes a record in the ObservationForm_Group table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_ObservationForm_Group_Delete
(

	@GroupId int   
)
AS


				DELETE FROM [dbo].[ObservationForm_Group] WITH (ROWLOCK) 
				WHERE
					[GroupID] = @GroupId
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_ObservationForm_Group_GetByGroupId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_ObservationForm_Group_GetByGroupId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_ObservationForm_Group_GetByGroupId
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Select records from the ObservationForm_Group table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_ObservationForm_Group_GetByGroupId
(

	@GroupId int   
)
AS


				SELECT
					[GroupID],
					[GroupName],
					[LineNumber]
				FROM
					[dbo].[ObservationForm_Group]
				WHERE
					[GroupID] = @GroupId
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_ObservationForm_Group_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_ObservationForm_Group_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_ObservationForm_Group_Find
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Finds records in the ObservationForm_Group table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_ObservationForm_Group_Find
(

	@SearchUsingOR bit   = null ,

	@GroupId int   = null ,

	@GroupName varchar (250)  = null ,

	@LineNumber int   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [GroupID]
	, [GroupName]
	, [LineNumber]
    FROM
	[dbo].[ObservationForm_Group]
    WHERE 
	 ([GroupID] = @GroupId OR @GroupId IS NULL)
	AND ([GroupName] = @GroupName OR @GroupName IS NULL)
	AND ([LineNumber] = @LineNumber OR @LineNumber IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [GroupID]
	, [GroupName]
	, [LineNumber]
    FROM
	[dbo].[ObservationForm_Group]
    WHERE 
	 ([GroupID] = @GroupId AND @GroupId is not null)
	OR ([GroupName] = @GroupName AND @GroupName is not null)
	OR ([LineNumber] = @LineNumber AND @LineNumber is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_QuestionForm_Answer_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_QuestionForm_Answer_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_QuestionForm_Answer_Get_List
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Gets all records from the QuestionForm_Answer table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_QuestionForm_Answer_Get_List

AS


				
				SELECT
					[RowID],
					[ClientID],
					[QuestionID],
					[OptionID],
					[Description],
					[CreateOn],
					[UpdateOn]
				FROM
					[dbo].[QuestionForm_Answer]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_QuestionForm_Answer_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_QuestionForm_Answer_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_QuestionForm_Answer_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Gets records from the QuestionForm_Answer table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_QuestionForm_Answer_GetPaged
(

	@WhereClause varchar (8000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy IS NULL OR LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[RowID]'
				END

				-- SQL Server 2005 Paging
				DECLARE @SQL AS nvarchar(MAX)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [RowID]'
				SET @SQL = @SQL + ', [ClientID]'
				SET @SQL = @SQL + ', [QuestionID]'
				SET @SQL = @SQL + ', [OptionID]'
				SET @SQL = @SQL + ', [Description]'
				SET @SQL = @SQL + ', [CreateOn]'
				SET @SQL = @SQL + ', [UpdateOn]'
				SET @SQL = @SQL + ' FROM [dbo].[QuestionForm_Answer]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [RowID],'
				SET @SQL = @SQL + ' [ClientID],'
				SET @SQL = @SQL + ' [QuestionID],'
				SET @SQL = @SQL + ' [OptionID],'
				SET @SQL = @SQL + ' [Description],'
				SET @SQL = @SQL + ' [CreateOn],'
				SET @SQL = @SQL + ' [UpdateOn]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + CONVERT(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				EXEC sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(1) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[QuestionForm_Answer]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_QuestionForm_Answer_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_QuestionForm_Answer_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_QuestionForm_Answer_Insert
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Inserts a record into the QuestionForm_Answer table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_QuestionForm_Answer_Insert
(

	@RowId int    OUTPUT,

	@ClientId int   ,

	@QuestionId int   ,

	@OptionId int   ,

	@Description nvarchar (MAX)  ,

	@CreateOn smalldatetime   ,

	@UpdateOn smalldatetime   
)
AS


				
				INSERT INTO [dbo].[QuestionForm_Answer]
					(
					[ClientID]
					,[QuestionID]
					,[OptionID]
					,[Description]
					,[CreateOn]
					,[UpdateOn]
					)
				VALUES
					(
					@ClientId
					,@QuestionId
					,@OptionId
					,@Description
					,@CreateOn
					,@UpdateOn
					)
				-- Get the identity value
				SET @RowId = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_QuestionForm_Answer_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_QuestionForm_Answer_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_QuestionForm_Answer_Update
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Updates a record in the QuestionForm_Answer table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_QuestionForm_Answer_Update
(

	@RowId int   ,

	@ClientId int   ,

	@QuestionId int   ,

	@OptionId int   ,

	@Description nvarchar (MAX)  ,

	@CreateOn smalldatetime   ,

	@UpdateOn smalldatetime   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[QuestionForm_Answer]
				SET
					[ClientID] = @ClientId
					,[QuestionID] = @QuestionId
					,[OptionID] = @OptionId
					,[Description] = @Description
					,[CreateOn] = @CreateOn
					,[UpdateOn] = @UpdateOn
				WHERE
[RowID] = @RowId 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_QuestionForm_Answer_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_QuestionForm_Answer_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_QuestionForm_Answer_Delete
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Deletes a record in the QuestionForm_Answer table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_QuestionForm_Answer_Delete
(

	@RowId int   
)
AS


				DELETE FROM [dbo].[QuestionForm_Answer] WITH (ROWLOCK) 
				WHERE
					[RowID] = @RowId
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_QuestionForm_Answer_GetByClientId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_QuestionForm_Answer_GetByClientId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_QuestionForm_Answer_GetByClientId
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Select records from the QuestionForm_Answer table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_QuestionForm_Answer_GetByClientId
(

	@ClientId int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[RowID],
					[ClientID],
					[QuestionID],
					[OptionID],
					[Description],
					[CreateOn],
					[UpdateOn]
				FROM
					[dbo].[QuestionForm_Answer]
				WHERE
					[ClientID] = @ClientId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_QuestionForm_Answer_GetByQuestionId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_QuestionForm_Answer_GetByQuestionId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_QuestionForm_Answer_GetByQuestionId
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Select records from the QuestionForm_Answer table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_QuestionForm_Answer_GetByQuestionId
(

	@QuestionId int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[RowID],
					[ClientID],
					[QuestionID],
					[OptionID],
					[Description],
					[CreateOn],
					[UpdateOn]
				FROM
					[dbo].[QuestionForm_Answer]
				WHERE
					[QuestionID] = @QuestionId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_QuestionForm_Answer_GetByOptionId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_QuestionForm_Answer_GetByOptionId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_QuestionForm_Answer_GetByOptionId
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Select records from the QuestionForm_Answer table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_QuestionForm_Answer_GetByOptionId
(

	@OptionId int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[RowID],
					[ClientID],
					[QuestionID],
					[OptionID],
					[Description],
					[CreateOn],
					[UpdateOn]
				FROM
					[dbo].[QuestionForm_Answer]
				WHERE
					[OptionID] = @OptionId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_QuestionForm_Answer_GetByRowId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_QuestionForm_Answer_GetByRowId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_QuestionForm_Answer_GetByRowId
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Select records from the QuestionForm_Answer table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_QuestionForm_Answer_GetByRowId
(

	@RowId int   
)
AS


				SELECT
					[RowID],
					[ClientID],
					[QuestionID],
					[OptionID],
					[Description],
					[CreateOn],
					[UpdateOn]
				FROM
					[dbo].[QuestionForm_Answer]
				WHERE
					[RowID] = @RowId
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_QuestionForm_Answer_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_QuestionForm_Answer_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_QuestionForm_Answer_Find
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Finds records in the QuestionForm_Answer table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_QuestionForm_Answer_Find
(

	@SearchUsingOR bit   = null ,

	@RowId int   = null ,

	@ClientId int   = null ,

	@QuestionId int   = null ,

	@OptionId int   = null ,

	@Description nvarchar (MAX)  = null ,

	@CreateOn smalldatetime   = null ,

	@UpdateOn smalldatetime   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [RowID]
	, [ClientID]
	, [QuestionID]
	, [OptionID]
	, [Description]
	, [CreateOn]
	, [UpdateOn]
    FROM
	[dbo].[QuestionForm_Answer]
    WHERE 
	 ([RowID] = @RowId OR @RowId IS NULL)
	AND ([ClientID] = @ClientId OR @ClientId IS NULL)
	AND ([QuestionID] = @QuestionId OR @QuestionId IS NULL)
	AND ([OptionID] = @OptionId OR @OptionId IS NULL)
	AND ([Description] = @Description OR @Description IS NULL)
	AND ([CreateOn] = @CreateOn OR @CreateOn IS NULL)
	AND ([UpdateOn] = @UpdateOn OR @UpdateOn IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [RowID]
	, [ClientID]
	, [QuestionID]
	, [OptionID]
	, [Description]
	, [CreateOn]
	, [UpdateOn]
    FROM
	[dbo].[QuestionForm_Answer]
    WHERE 
	 ([RowID] = @RowId AND @RowId is not null)
	OR ([ClientID] = @ClientId AND @ClientId is not null)
	OR ([QuestionID] = @QuestionId AND @QuestionId is not null)
	OR ([OptionID] = @OptionId AND @OptionId is not null)
	OR ([Description] = @Description AND @Description is not null)
	OR ([CreateOn] = @CreateOn AND @CreateOn is not null)
	OR ([UpdateOn] = @UpdateOn AND @UpdateOn is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_ObservationForm_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_ObservationForm_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_ObservationForm_Get_List
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Gets all records from the ObservationForm table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_ObservationForm_Get_List

AS


				
				SELECT
					[QuestionID],
					[GroupID],
					[QuestionRef],
					[QuestionName],
					[LineNumber],
					[Status]
				FROM
					[dbo].[ObservationForm]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_ObservationForm_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_ObservationForm_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_ObservationForm_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Gets records from the ObservationForm table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_ObservationForm_GetPaged
(

	@WhereClause varchar (8000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy IS NULL OR LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[QuestionID]'
				END

				-- SQL Server 2005 Paging
				DECLARE @SQL AS nvarchar(MAX)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [QuestionID]'
				SET @SQL = @SQL + ', [GroupID]'
				SET @SQL = @SQL + ', [QuestionRef]'
				SET @SQL = @SQL + ', [QuestionName]'
				SET @SQL = @SQL + ', [LineNumber]'
				SET @SQL = @SQL + ', [Status]'
				SET @SQL = @SQL + ' FROM [dbo].[ObservationForm]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [QuestionID],'
				SET @SQL = @SQL + ' [GroupID],'
				SET @SQL = @SQL + ' [QuestionRef],'
				SET @SQL = @SQL + ' [QuestionName],'
				SET @SQL = @SQL + ' [LineNumber],'
				SET @SQL = @SQL + ' [Status]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + CONVERT(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				EXEC sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(1) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[ObservationForm]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_ObservationForm_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_ObservationForm_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_ObservationForm_Insert
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Inserts a record into the ObservationForm table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_ObservationForm_Insert
(

	@QuestionId int    OUTPUT,

	@GroupId int   ,

	@QuestionRef varchar (10)  ,

	@QuestionName varchar (500)  ,

	@LineNumber int   ,

	@Status bit   
)
AS


				
				INSERT INTO [dbo].[ObservationForm]
					(
					[GroupID]
					,[QuestionRef]
					,[QuestionName]
					,[LineNumber]
					,[Status]
					)
				VALUES
					(
					@GroupId
					,@QuestionRef
					,@QuestionName
					,@LineNumber
					,@Status
					)
				-- Get the identity value
				SET @QuestionId = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_ObservationForm_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_ObservationForm_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_ObservationForm_Update
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Updates a record in the ObservationForm table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_ObservationForm_Update
(

	@QuestionId int   ,

	@GroupId int   ,

	@QuestionRef varchar (10)  ,

	@QuestionName varchar (500)  ,

	@LineNumber int   ,

	@Status bit   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[ObservationForm]
				SET
					[GroupID] = @GroupId
					,[QuestionRef] = @QuestionRef
					,[QuestionName] = @QuestionName
					,[LineNumber] = @LineNumber
					,[Status] = @Status
				WHERE
[QuestionID] = @QuestionId 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_ObservationForm_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_ObservationForm_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_ObservationForm_Delete
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Deletes a record in the ObservationForm table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_ObservationForm_Delete
(

	@QuestionId int   
)
AS


				DELETE FROM [dbo].[ObservationForm] WITH (ROWLOCK) 
				WHERE
					[QuestionID] = @QuestionId
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_ObservationForm_GetByGroupId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_ObservationForm_GetByGroupId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_ObservationForm_GetByGroupId
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Select records from the ObservationForm table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_ObservationForm_GetByGroupId
(

	@GroupId int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[QuestionID],
					[GroupID],
					[QuestionRef],
					[QuestionName],
					[LineNumber],
					[Status]
				FROM
					[dbo].[ObservationForm]
				WHERE
					[GroupID] = @GroupId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_ObservationForm_GetByQuestionId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_ObservationForm_GetByQuestionId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_ObservationForm_GetByQuestionId
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Select records from the ObservationForm table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_ObservationForm_GetByQuestionId
(

	@QuestionId int   
)
AS


				SELECT
					[QuestionID],
					[GroupID],
					[QuestionRef],
					[QuestionName],
					[LineNumber],
					[Status]
				FROM
					[dbo].[ObservationForm]
				WHERE
					[QuestionID] = @QuestionId
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_ObservationForm_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_ObservationForm_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_ObservationForm_Find
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Finds records in the ObservationForm table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_ObservationForm_Find
(

	@SearchUsingOR bit   = null ,

	@QuestionId int   = null ,

	@GroupId int   = null ,

	@QuestionRef varchar (10)  = null ,

	@QuestionName varchar (500)  = null ,

	@LineNumber int   = null ,

	@Status bit   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [QuestionID]
	, [GroupID]
	, [QuestionRef]
	, [QuestionName]
	, [LineNumber]
	, [Status]
    FROM
	[dbo].[ObservationForm]
    WHERE 
	 ([QuestionID] = @QuestionId OR @QuestionId IS NULL)
	AND ([GroupID] = @GroupId OR @GroupId IS NULL)
	AND ([QuestionRef] = @QuestionRef OR @QuestionRef IS NULL)
	AND ([QuestionName] = @QuestionName OR @QuestionName IS NULL)
	AND ([LineNumber] = @LineNumber OR @LineNumber IS NULL)
	AND ([Status] = @Status OR @Status IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [QuestionID]
	, [GroupID]
	, [QuestionRef]
	, [QuestionName]
	, [LineNumber]
	, [Status]
    FROM
	[dbo].[ObservationForm]
    WHERE 
	 ([QuestionID] = @QuestionId AND @QuestionId is not null)
	OR ([GroupID] = @GroupId AND @GroupId is not null)
	OR ([QuestionRef] = @QuestionRef AND @QuestionRef is not null)
	OR ([QuestionName] = @QuestionName AND @QuestionName is not null)
	OR ([LineNumber] = @LineNumber AND @LineNumber is not null)
	OR ([Status] = @Status AND @Status is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_Neighborhood_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_Neighborhood_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_Neighborhood_Get_List
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Gets all records from the Neighborhood table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Neighborhood_Get_List

AS


				
				SELECT
					[Id],
					[AdminId],
					[ObjectId],
					[ParentId],
					[RowNumber],
					[TownId],
					[NeighborhoodName],
					[Longitude],
					[Latitude],
					[Type],
					[CreateDate],
					[CreateTime],
					[UpdateDate],
					[UpdateTime]
				FROM
					[dbo].[Neighborhood]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_Neighborhood_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_Neighborhood_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_Neighborhood_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Gets records from the Neighborhood table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Neighborhood_GetPaged
(

	@WhereClause varchar (8000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy IS NULL OR LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[Id]'
				END

				-- SQL Server 2005 Paging
				DECLARE @SQL AS nvarchar(MAX)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [Id]'
				SET @SQL = @SQL + ', [AdminId]'
				SET @SQL = @SQL + ', [ObjectId]'
				SET @SQL = @SQL + ', [ParentId]'
				SET @SQL = @SQL + ', [RowNumber]'
				SET @SQL = @SQL + ', [TownId]'
				SET @SQL = @SQL + ', [NeighborhoodName]'
				SET @SQL = @SQL + ', [Longitude]'
				SET @SQL = @SQL + ', [Latitude]'
				SET @SQL = @SQL + ', [Type]'
				SET @SQL = @SQL + ', [CreateDate]'
				SET @SQL = @SQL + ', [CreateTime]'
				SET @SQL = @SQL + ', [UpdateDate]'
				SET @SQL = @SQL + ', [UpdateTime]'
				SET @SQL = @SQL + ' FROM [dbo].[Neighborhood]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [Id],'
				SET @SQL = @SQL + ' [AdminId],'
				SET @SQL = @SQL + ' [ObjectId],'
				SET @SQL = @SQL + ' [ParentId],'
				SET @SQL = @SQL + ' [RowNumber],'
				SET @SQL = @SQL + ' [TownId],'
				SET @SQL = @SQL + ' [NeighborhoodName],'
				SET @SQL = @SQL + ' [Longitude],'
				SET @SQL = @SQL + ' [Latitude],'
				SET @SQL = @SQL + ' [Type],'
				SET @SQL = @SQL + ' [CreateDate],'
				SET @SQL = @SQL + ' [CreateTime],'
				SET @SQL = @SQL + ' [UpdateDate],'
				SET @SQL = @SQL + ' [UpdateTime]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + CONVERT(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				EXEC sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(1) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[Neighborhood]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_Neighborhood_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_Neighborhood_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_Neighborhood_Insert
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Inserts a record into the Neighborhood table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Neighborhood_Insert
(

	@Id int    OUTPUT,

	@AdminId bigint   ,

	@ObjectId bigint   ,

	@ParentId bigint   ,

	@RowNumber int   ,

	@TownId int   ,

	@NeighborhoodName nvarchar (250)  ,

	@Longitude varchar (10)  ,

	@Latitude varchar (10)  ,

	@Type int   ,

	@CreateDate date   ,

	@CreateTime time   ,

	@UpdateDate date   ,

	@UpdateTime time   
)
AS


				
				INSERT INTO [dbo].[Neighborhood]
					(
					[AdminId]
					,[ObjectId]
					,[ParentId]
					,[RowNumber]
					,[TownId]
					,[NeighborhoodName]
					,[Longitude]
					,[Latitude]
					,[Type]
					,[CreateDate]
					,[CreateTime]
					,[UpdateDate]
					,[UpdateTime]
					)
				VALUES
					(
					@AdminId
					,@ObjectId
					,@ParentId
					,@RowNumber
					,@TownId
					,@NeighborhoodName
					,@Longitude
					,@Latitude
					,@Type
					,@CreateDate
					,@CreateTime
					,@UpdateDate
					,@UpdateTime
					)
				-- Get the identity value
				SET @Id = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_Neighborhood_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_Neighborhood_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_Neighborhood_Update
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Updates a record in the Neighborhood table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Neighborhood_Update
(

	@Id int   ,

	@AdminId bigint   ,

	@ObjectId bigint   ,

	@ParentId bigint   ,

	@RowNumber int   ,

	@TownId int   ,

	@NeighborhoodName nvarchar (250)  ,

	@Longitude varchar (10)  ,

	@Latitude varchar (10)  ,

	@Type int   ,

	@CreateDate date   ,

	@CreateTime time   ,

	@UpdateDate date   ,

	@UpdateTime time   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[Neighborhood]
				SET
					[AdminId] = @AdminId
					,[ObjectId] = @ObjectId
					,[ParentId] = @ParentId
					,[RowNumber] = @RowNumber
					,[TownId] = @TownId
					,[NeighborhoodName] = @NeighborhoodName
					,[Longitude] = @Longitude
					,[Latitude] = @Latitude
					,[Type] = @Type
					,[CreateDate] = @CreateDate
					,[CreateTime] = @CreateTime
					,[UpdateDate] = @UpdateDate
					,[UpdateTime] = @UpdateTime
				WHERE
[Id] = @Id 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_Neighborhood_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_Neighborhood_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_Neighborhood_Delete
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Deletes a record in the Neighborhood table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Neighborhood_Delete
(

	@Id int   
)
AS


				DELETE FROM [dbo].[Neighborhood] WITH (ROWLOCK) 
				WHERE
					[Id] = @Id
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_Neighborhood_GetByTownId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_Neighborhood_GetByTownId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_Neighborhood_GetByTownId
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Select records from the Neighborhood table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Neighborhood_GetByTownId
(

	@TownId int   
)
AS


				SELECT
					[Id],
					[AdminId],
					[ObjectId],
					[ParentId],
					[RowNumber],
					[TownId],
					[NeighborhoodName],
					[Longitude],
					[Latitude],
					[Type],
					[CreateDate],
					[CreateTime],
					[UpdateDate],
					[UpdateTime]
				FROM
					[dbo].[Neighborhood]
				WHERE
					[TownId] = @TownId
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_Neighborhood_GetById procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_Neighborhood_GetById') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_Neighborhood_GetById
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Select records from the Neighborhood table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Neighborhood_GetById
(

	@Id int   
)
AS


				SELECT
					[Id],
					[AdminId],
					[ObjectId],
					[ParentId],
					[RowNumber],
					[TownId],
					[NeighborhoodName],
					[Longitude],
					[Latitude],
					[Type],
					[CreateDate],
					[CreateTime],
					[UpdateDate],
					[UpdateTime]
				FROM
					[dbo].[Neighborhood]
				WHERE
					[Id] = @Id
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_Neighborhood_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_Neighborhood_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_Neighborhood_Find
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Finds records in the Neighborhood table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Neighborhood_Find
(

	@SearchUsingOR bit   = null ,

	@Id int   = null ,

	@AdminId bigint   = null ,

	@ObjectId bigint   = null ,

	@ParentId bigint   = null ,

	@RowNumber int   = null ,

	@TownId int   = null ,

	@NeighborhoodName nvarchar (250)  = null ,

	@Longitude varchar (10)  = null ,

	@Latitude varchar (10)  = null ,

	@Type int   = null ,

	@CreateDate date   = null ,

	@CreateTime time   = null ,

	@UpdateDate date   = null ,

	@UpdateTime time   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [Id]
	, [AdminId]
	, [ObjectId]
	, [ParentId]
	, [RowNumber]
	, [TownId]
	, [NeighborhoodName]
	, [Longitude]
	, [Latitude]
	, [Type]
	, [CreateDate]
	, [CreateTime]
	, [UpdateDate]
	, [UpdateTime]
    FROM
	[dbo].[Neighborhood]
    WHERE 
	 ([Id] = @Id OR @Id IS NULL)
	AND ([AdminId] = @AdminId OR @AdminId IS NULL)
	AND ([ObjectId] = @ObjectId OR @ObjectId IS NULL)
	AND ([ParentId] = @ParentId OR @ParentId IS NULL)
	AND ([RowNumber] = @RowNumber OR @RowNumber IS NULL)
	AND ([TownId] = @TownId OR @TownId IS NULL)
	AND ([NeighborhoodName] = @NeighborhoodName OR @NeighborhoodName IS NULL)
	AND ([Longitude] = @Longitude OR @Longitude IS NULL)
	AND ([Latitude] = @Latitude OR @Latitude IS NULL)
	AND ([Type] = @Type OR @Type IS NULL)
	AND ([CreateDate] = @CreateDate OR @CreateDate IS NULL)
	AND ([CreateTime] = @CreateTime OR @CreateTime IS NULL)
	AND ([UpdateDate] = @UpdateDate OR @UpdateDate IS NULL)
	AND ([UpdateTime] = @UpdateTime OR @UpdateTime IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [Id]
	, [AdminId]
	, [ObjectId]
	, [ParentId]
	, [RowNumber]
	, [TownId]
	, [NeighborhoodName]
	, [Longitude]
	, [Latitude]
	, [Type]
	, [CreateDate]
	, [CreateTime]
	, [UpdateDate]
	, [UpdateTime]
    FROM
	[dbo].[Neighborhood]
    WHERE 
	 ([Id] = @Id AND @Id is not null)
	OR ([AdminId] = @AdminId AND @AdminId is not null)
	OR ([ObjectId] = @ObjectId AND @ObjectId is not null)
	OR ([ParentId] = @ParentId AND @ParentId is not null)
	OR ([RowNumber] = @RowNumber AND @RowNumber is not null)
	OR ([TownId] = @TownId AND @TownId is not null)
	OR ([NeighborhoodName] = @NeighborhoodName AND @NeighborhoodName is not null)
	OR ([Longitude] = @Longitude AND @Longitude is not null)
	OR ([Latitude] = @Latitude AND @Latitude is not null)
	OR ([Type] = @Type AND @Type is not null)
	OR ([CreateDate] = @CreateDate AND @CreateDate is not null)
	OR ([CreateTime] = @CreateTime AND @CreateTime is not null)
	OR ([UpdateDate] = @UpdateDate AND @UpdateDate is not null)
	OR ([UpdateTime] = @UpdateTime AND @UpdateTime is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_ObservationForm_Option_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_ObservationForm_Option_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_ObservationForm_Option_Get_List
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Gets all records from the ObservationForm_Option table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_ObservationForm_Option_Get_List

AS


				
				SELECT
					[OptionID],
					[QuestionID],
					[OptionName]
				FROM
					[dbo].[ObservationForm_Option]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_ObservationForm_Option_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_ObservationForm_Option_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_ObservationForm_Option_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Gets records from the ObservationForm_Option table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_ObservationForm_Option_GetPaged
(

	@WhereClause varchar (8000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy IS NULL OR LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[OptionID]'
				END

				-- SQL Server 2005 Paging
				DECLARE @SQL AS nvarchar(MAX)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [OptionID]'
				SET @SQL = @SQL + ', [QuestionID]'
				SET @SQL = @SQL + ', [OptionName]'
				SET @SQL = @SQL + ' FROM [dbo].[ObservationForm_Option]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [OptionID],'
				SET @SQL = @SQL + ' [QuestionID],'
				SET @SQL = @SQL + ' [OptionName]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + CONVERT(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				EXEC sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(1) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[ObservationForm_Option]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_ObservationForm_Option_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_ObservationForm_Option_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_ObservationForm_Option_Insert
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Inserts a record into the ObservationForm_Option table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_ObservationForm_Option_Insert
(

	@OptionId int    OUTPUT,

	@QuestionId int   ,

	@OptionName varchar (300)  
)
AS


				
				INSERT INTO [dbo].[ObservationForm_Option]
					(
					[QuestionID]
					,[OptionName]
					)
				VALUES
					(
					@QuestionId
					,@OptionName
					)
				-- Get the identity value
				SET @OptionId = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_ObservationForm_Option_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_ObservationForm_Option_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_ObservationForm_Option_Update
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Updates a record in the ObservationForm_Option table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_ObservationForm_Option_Update
(

	@OptionId int   ,

	@QuestionId int   ,

	@OptionName varchar (300)  
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[ObservationForm_Option]
				SET
					[QuestionID] = @QuestionId
					,[OptionName] = @OptionName
				WHERE
[OptionID] = @OptionId 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_ObservationForm_Option_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_ObservationForm_Option_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_ObservationForm_Option_Delete
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Deletes a record in the ObservationForm_Option table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_ObservationForm_Option_Delete
(

	@OptionId int   
)
AS


				DELETE FROM [dbo].[ObservationForm_Option] WITH (ROWLOCK) 
				WHERE
					[OptionID] = @OptionId
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_ObservationForm_Option_GetByQuestionId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_ObservationForm_Option_GetByQuestionId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_ObservationForm_Option_GetByQuestionId
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Select records from the ObservationForm_Option table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_ObservationForm_Option_GetByQuestionId
(

	@QuestionId int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[OptionID],
					[QuestionID],
					[OptionName]
				FROM
					[dbo].[ObservationForm_Option]
				WHERE
					[QuestionID] = @QuestionId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_ObservationForm_Option_GetByOptionId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_ObservationForm_Option_GetByOptionId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_ObservationForm_Option_GetByOptionId
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Select records from the ObservationForm_Option table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_ObservationForm_Option_GetByOptionId
(

	@OptionId int   
)
AS


				SELECT
					[OptionID],
					[QuestionID],
					[OptionName]
				FROM
					[dbo].[ObservationForm_Option]
				WHERE
					[OptionID] = @OptionId
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_ObservationForm_Option_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_ObservationForm_Option_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_ObservationForm_Option_Find
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Finds records in the ObservationForm_Option table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_ObservationForm_Option_Find
(

	@SearchUsingOR bit   = null ,

	@OptionId int   = null ,

	@QuestionId int   = null ,

	@OptionName varchar (300)  = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [OptionID]
	, [QuestionID]
	, [OptionName]
    FROM
	[dbo].[ObservationForm_Option]
    WHERE 
	 ([OptionID] = @OptionId OR @OptionId IS NULL)
	AND ([QuestionID] = @QuestionId OR @QuestionId IS NULL)
	AND ([OptionName] = @OptionName OR @OptionName IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [OptionID]
	, [QuestionID]
	, [OptionName]
    FROM
	[dbo].[ObservationForm_Option]
    WHERE 
	 ([OptionID] = @OptionId AND @OptionId is not null)
	OR ([QuestionID] = @QuestionId AND @QuestionId is not null)
	OR ([OptionName] = @OptionName AND @OptionName is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_ObservationForm_Answer_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_ObservationForm_Answer_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_ObservationForm_Answer_Get_List
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Gets all records from the ObservationForm_Answer table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_ObservationForm_Answer_Get_List

AS


				
				SELECT
					[RowID],
					[ClientID],
					[QuestionID],
					[OptionID],
					[Description],
					[CreateOn],
					[UpdateOn]
				FROM
					[dbo].[ObservationForm_Answer]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_ObservationForm_Answer_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_ObservationForm_Answer_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_ObservationForm_Answer_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Gets records from the ObservationForm_Answer table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_ObservationForm_Answer_GetPaged
(

	@WhereClause varchar (8000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy IS NULL OR LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[RowID]'
				END

				-- SQL Server 2005 Paging
				DECLARE @SQL AS nvarchar(MAX)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [RowID]'
				SET @SQL = @SQL + ', [ClientID]'
				SET @SQL = @SQL + ', [QuestionID]'
				SET @SQL = @SQL + ', [OptionID]'
				SET @SQL = @SQL + ', [Description]'
				SET @SQL = @SQL + ', [CreateOn]'
				SET @SQL = @SQL + ', [UpdateOn]'
				SET @SQL = @SQL + ' FROM [dbo].[ObservationForm_Answer]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [RowID],'
				SET @SQL = @SQL + ' [ClientID],'
				SET @SQL = @SQL + ' [QuestionID],'
				SET @SQL = @SQL + ' [OptionID],'
				SET @SQL = @SQL + ' [Description],'
				SET @SQL = @SQL + ' [CreateOn],'
				SET @SQL = @SQL + ' [UpdateOn]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + CONVERT(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				EXEC sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(1) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[ObservationForm_Answer]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_ObservationForm_Answer_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_ObservationForm_Answer_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_ObservationForm_Answer_Insert
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Inserts a record into the ObservationForm_Answer table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_ObservationForm_Answer_Insert
(

	@RowId int    OUTPUT,

	@ClientId int   ,

	@QuestionId int   ,

	@OptionId int   ,

	@Description nvarchar (MAX)  ,

	@CreateOn smalldatetime   ,

	@UpdateOn smalldatetime   
)
AS


				
				INSERT INTO [dbo].[ObservationForm_Answer]
					(
					[ClientID]
					,[QuestionID]
					,[OptionID]
					,[Description]
					,[CreateOn]
					,[UpdateOn]
					)
				VALUES
					(
					@ClientId
					,@QuestionId
					,@OptionId
					,@Description
					,@CreateOn
					,@UpdateOn
					)
				-- Get the identity value
				SET @RowId = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_ObservationForm_Answer_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_ObservationForm_Answer_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_ObservationForm_Answer_Update
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Updates a record in the ObservationForm_Answer table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_ObservationForm_Answer_Update
(

	@RowId int   ,

	@ClientId int   ,

	@QuestionId int   ,

	@OptionId int   ,

	@Description nvarchar (MAX)  ,

	@CreateOn smalldatetime   ,

	@UpdateOn smalldatetime   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[ObservationForm_Answer]
				SET
					[ClientID] = @ClientId
					,[QuestionID] = @QuestionId
					,[OptionID] = @OptionId
					,[Description] = @Description
					,[CreateOn] = @CreateOn
					,[UpdateOn] = @UpdateOn
				WHERE
[RowID] = @RowId 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_ObservationForm_Answer_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_ObservationForm_Answer_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_ObservationForm_Answer_Delete
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Deletes a record in the ObservationForm_Answer table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_ObservationForm_Answer_Delete
(

	@RowId int   
)
AS


				DELETE FROM [dbo].[ObservationForm_Answer] WITH (ROWLOCK) 
				WHERE
					[RowID] = @RowId
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_ObservationForm_Answer_GetByClientId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_ObservationForm_Answer_GetByClientId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_ObservationForm_Answer_GetByClientId
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Select records from the ObservationForm_Answer table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_ObservationForm_Answer_GetByClientId
(

	@ClientId int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[RowID],
					[ClientID],
					[QuestionID],
					[OptionID],
					[Description],
					[CreateOn],
					[UpdateOn]
				FROM
					[dbo].[ObservationForm_Answer]
				WHERE
					[ClientID] = @ClientId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_ObservationForm_Answer_GetByQuestionId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_ObservationForm_Answer_GetByQuestionId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_ObservationForm_Answer_GetByQuestionId
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Select records from the ObservationForm_Answer table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_ObservationForm_Answer_GetByQuestionId
(

	@QuestionId int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[RowID],
					[ClientID],
					[QuestionID],
					[OptionID],
					[Description],
					[CreateOn],
					[UpdateOn]
				FROM
					[dbo].[ObservationForm_Answer]
				WHERE
					[QuestionID] = @QuestionId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_ObservationForm_Answer_GetByOptionId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_ObservationForm_Answer_GetByOptionId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_ObservationForm_Answer_GetByOptionId
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Select records from the ObservationForm_Answer table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_ObservationForm_Answer_GetByOptionId
(

	@OptionId int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[RowID],
					[ClientID],
					[QuestionID],
					[OptionID],
					[Description],
					[CreateOn],
					[UpdateOn]
				FROM
					[dbo].[ObservationForm_Answer]
				WHERE
					[OptionID] = @OptionId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_ObservationForm_Answer_GetByRowId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_ObservationForm_Answer_GetByRowId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_ObservationForm_Answer_GetByRowId
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Select records from the ObservationForm_Answer table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_ObservationForm_Answer_GetByRowId
(

	@RowId int   
)
AS


				SELECT
					[RowID],
					[ClientID],
					[QuestionID],
					[OptionID],
					[Description],
					[CreateOn],
					[UpdateOn]
				FROM
					[dbo].[ObservationForm_Answer]
				WHERE
					[RowID] = @RowId
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_ObservationForm_Answer_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_ObservationForm_Answer_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_ObservationForm_Answer_Find
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Finds records in the ObservationForm_Answer table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_ObservationForm_Answer_Find
(

	@SearchUsingOR bit   = null ,

	@RowId int   = null ,

	@ClientId int   = null ,

	@QuestionId int   = null ,

	@OptionId int   = null ,

	@Description nvarchar (MAX)  = null ,

	@CreateOn smalldatetime   = null ,

	@UpdateOn smalldatetime   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [RowID]
	, [ClientID]
	, [QuestionID]
	, [OptionID]
	, [Description]
	, [CreateOn]
	, [UpdateOn]
    FROM
	[dbo].[ObservationForm_Answer]
    WHERE 
	 ([RowID] = @RowId OR @RowId IS NULL)
	AND ([ClientID] = @ClientId OR @ClientId IS NULL)
	AND ([QuestionID] = @QuestionId OR @QuestionId IS NULL)
	AND ([OptionID] = @OptionId OR @OptionId IS NULL)
	AND ([Description] = @Description OR @Description IS NULL)
	AND ([CreateOn] = @CreateOn OR @CreateOn IS NULL)
	AND ([UpdateOn] = @UpdateOn OR @UpdateOn IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [RowID]
	, [ClientID]
	, [QuestionID]
	, [OptionID]
	, [Description]
	, [CreateOn]
	, [UpdateOn]
    FROM
	[dbo].[ObservationForm_Answer]
    WHERE 
	 ([RowID] = @RowId AND @RowId is not null)
	OR ([ClientID] = @ClientId AND @ClientId is not null)
	OR ([QuestionID] = @QuestionId AND @QuestionId is not null)
	OR ([OptionID] = @OptionId AND @OptionId is not null)
	OR ([Description] = @Description AND @Description is not null)
	OR ([CreateOn] = @CreateOn AND @CreateOn is not null)
	OR ([UpdateOn] = @UpdateOn AND @UpdateOn is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_Wiscr_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_Wiscr_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_Wiscr_Get_List
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Gets all records from the Wiscr table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Wiscr_Get_List

AS


				
				SELECT
					[WiscrID],
					[GeneralRawScore],
					[GeneralStandartScore],
					[SimilarityRawScore],
					[SimilarityStandartScore],
					[ArithmeticRawScore],
					[ArithmeticStandartScore],
					[WordRawScore],
					[WordStandartScore],
					[JudgingRawScore],
					[JudgingStandartScore],
					[SetOfNumbersRawScore],
					[SetOfNumbersStandartScore],
					[ImageDefineRawScore],
					[ImageDefineStandartScore],
					[ImageEditingRawScore],
					[ImageEditingStandartScore],
					[CubesPatternRawScore],
					[CubesPatternStandartScore],
					[PartsMergeRawScore],
					[PartsMergeStandartScore],
					[PasswordRawScore],
					[PasswordStandartScore],
					[MazesRawScore],
					[MazesStandartScore],
					[TotalVerbalScore],
					[TotalPerformanceScore],
					[TotalScore],
					[TestDate],
					[CreateDate],
					[UpdateDate],
					[UserID],
					[AdvisorID]
				FROM
					[dbo].[Wiscr]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_Wiscr_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_Wiscr_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_Wiscr_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Gets records from the Wiscr table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Wiscr_GetPaged
(

	@WhereClause varchar (8000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy IS NULL OR LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[WiscrID]'
				END

				-- SQL Server 2005 Paging
				DECLARE @SQL AS nvarchar(MAX)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [WiscrID]'
				SET @SQL = @SQL + ', [GeneralRawScore]'
				SET @SQL = @SQL + ', [GeneralStandartScore]'
				SET @SQL = @SQL + ', [SimilarityRawScore]'
				SET @SQL = @SQL + ', [SimilarityStandartScore]'
				SET @SQL = @SQL + ', [ArithmeticRawScore]'
				SET @SQL = @SQL + ', [ArithmeticStandartScore]'
				SET @SQL = @SQL + ', [WordRawScore]'
				SET @SQL = @SQL + ', [WordStandartScore]'
				SET @SQL = @SQL + ', [JudgingRawScore]'
				SET @SQL = @SQL + ', [JudgingStandartScore]'
				SET @SQL = @SQL + ', [SetOfNumbersRawScore]'
				SET @SQL = @SQL + ', [SetOfNumbersStandartScore]'
				SET @SQL = @SQL + ', [ImageDefineRawScore]'
				SET @SQL = @SQL + ', [ImageDefineStandartScore]'
				SET @SQL = @SQL + ', [ImageEditingRawScore]'
				SET @SQL = @SQL + ', [ImageEditingStandartScore]'
				SET @SQL = @SQL + ', [CubesPatternRawScore]'
				SET @SQL = @SQL + ', [CubesPatternStandartScore]'
				SET @SQL = @SQL + ', [PartsMergeRawScore]'
				SET @SQL = @SQL + ', [PartsMergeStandartScore]'
				SET @SQL = @SQL + ', [PasswordRawScore]'
				SET @SQL = @SQL + ', [PasswordStandartScore]'
				SET @SQL = @SQL + ', [MazesRawScore]'
				SET @SQL = @SQL + ', [MazesStandartScore]'
				SET @SQL = @SQL + ', [TotalVerbalScore]'
				SET @SQL = @SQL + ', [TotalPerformanceScore]'
				SET @SQL = @SQL + ', [TotalScore]'
				SET @SQL = @SQL + ', [TestDate]'
				SET @SQL = @SQL + ', [CreateDate]'
				SET @SQL = @SQL + ', [UpdateDate]'
				SET @SQL = @SQL + ', [UserID]'
				SET @SQL = @SQL + ', [AdvisorID]'
				SET @SQL = @SQL + ' FROM [dbo].[Wiscr]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [WiscrID],'
				SET @SQL = @SQL + ' [GeneralRawScore],'
				SET @SQL = @SQL + ' [GeneralStandartScore],'
				SET @SQL = @SQL + ' [SimilarityRawScore],'
				SET @SQL = @SQL + ' [SimilarityStandartScore],'
				SET @SQL = @SQL + ' [ArithmeticRawScore],'
				SET @SQL = @SQL + ' [ArithmeticStandartScore],'
				SET @SQL = @SQL + ' [WordRawScore],'
				SET @SQL = @SQL + ' [WordStandartScore],'
				SET @SQL = @SQL + ' [JudgingRawScore],'
				SET @SQL = @SQL + ' [JudgingStandartScore],'
				SET @SQL = @SQL + ' [SetOfNumbersRawScore],'
				SET @SQL = @SQL + ' [SetOfNumbersStandartScore],'
				SET @SQL = @SQL + ' [ImageDefineRawScore],'
				SET @SQL = @SQL + ' [ImageDefineStandartScore],'
				SET @SQL = @SQL + ' [ImageEditingRawScore],'
				SET @SQL = @SQL + ' [ImageEditingStandartScore],'
				SET @SQL = @SQL + ' [CubesPatternRawScore],'
				SET @SQL = @SQL + ' [CubesPatternStandartScore],'
				SET @SQL = @SQL + ' [PartsMergeRawScore],'
				SET @SQL = @SQL + ' [PartsMergeStandartScore],'
				SET @SQL = @SQL + ' [PasswordRawScore],'
				SET @SQL = @SQL + ' [PasswordStandartScore],'
				SET @SQL = @SQL + ' [MazesRawScore],'
				SET @SQL = @SQL + ' [MazesStandartScore],'
				SET @SQL = @SQL + ' [TotalVerbalScore],'
				SET @SQL = @SQL + ' [TotalPerformanceScore],'
				SET @SQL = @SQL + ' [TotalScore],'
				SET @SQL = @SQL + ' [TestDate],'
				SET @SQL = @SQL + ' [CreateDate],'
				SET @SQL = @SQL + ' [UpdateDate],'
				SET @SQL = @SQL + ' [UserID],'
				SET @SQL = @SQL + ' [AdvisorID]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + CONVERT(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				EXEC sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(1) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[Wiscr]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_Wiscr_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_Wiscr_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_Wiscr_Insert
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Inserts a record into the Wiscr table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Wiscr_Insert
(

	@WiscrId int    OUTPUT,

	@GeneralRawScore int   ,

	@GeneralStandartScore int   ,

	@SimilarityRawScore int   ,

	@SimilarityStandartScore int   ,

	@ArithmeticRawScore int   ,

	@ArithmeticStandartScore int   ,

	@WordRawScore int   ,

	@WordStandartScore int   ,

	@JudgingRawScore int   ,

	@JudgingStandartScore int   ,

	@SetOfNumbersRawScore int   ,

	@SetOfNumbersStandartScore int   ,

	@ImageDefineRawScore int   ,

	@ImageDefineStandartScore int   ,

	@ImageEditingRawScore int   ,

	@ImageEditingStandartScore int   ,

	@CubesPatternRawScore nchar (10)  ,

	@CubesPatternStandartScore int   ,

	@PartsMergeRawScore int   ,

	@PartsMergeStandartScore int   ,

	@PasswordRawScore int   ,

	@PasswordStandartScore int   ,

	@MazesRawScore int   ,

	@MazesStandartScore int   ,

	@TotalVerbalScore int   ,

	@TotalPerformanceScore int   ,

	@TotalScore int   ,

	@TestDate datetime   ,

	@CreateDate datetime   ,

	@UpdateDate datetime   ,

	@UserId int   ,

	@AdvisorId int   
)
AS


				
				INSERT INTO [dbo].[Wiscr]
					(
					[GeneralRawScore]
					,[GeneralStandartScore]
					,[SimilarityRawScore]
					,[SimilarityStandartScore]
					,[ArithmeticRawScore]
					,[ArithmeticStandartScore]
					,[WordRawScore]
					,[WordStandartScore]
					,[JudgingRawScore]
					,[JudgingStandartScore]
					,[SetOfNumbersRawScore]
					,[SetOfNumbersStandartScore]
					,[ImageDefineRawScore]
					,[ImageDefineStandartScore]
					,[ImageEditingRawScore]
					,[ImageEditingStandartScore]
					,[CubesPatternRawScore]
					,[CubesPatternStandartScore]
					,[PartsMergeRawScore]
					,[PartsMergeStandartScore]
					,[PasswordRawScore]
					,[PasswordStandartScore]
					,[MazesRawScore]
					,[MazesStandartScore]
					,[TotalVerbalScore]
					,[TotalPerformanceScore]
					,[TotalScore]
					,[TestDate]
					,[CreateDate]
					,[UpdateDate]
					,[UserID]
					,[AdvisorID]
					)
				VALUES
					(
					@GeneralRawScore
					,@GeneralStandartScore
					,@SimilarityRawScore
					,@SimilarityStandartScore
					,@ArithmeticRawScore
					,@ArithmeticStandartScore
					,@WordRawScore
					,@WordStandartScore
					,@JudgingRawScore
					,@JudgingStandartScore
					,@SetOfNumbersRawScore
					,@SetOfNumbersStandartScore
					,@ImageDefineRawScore
					,@ImageDefineStandartScore
					,@ImageEditingRawScore
					,@ImageEditingStandartScore
					,@CubesPatternRawScore
					,@CubesPatternStandartScore
					,@PartsMergeRawScore
					,@PartsMergeStandartScore
					,@PasswordRawScore
					,@PasswordStandartScore
					,@MazesRawScore
					,@MazesStandartScore
					,@TotalVerbalScore
					,@TotalPerformanceScore
					,@TotalScore
					,@TestDate
					,@CreateDate
					,@UpdateDate
					,@UserId
					,@AdvisorId
					)
				-- Get the identity value
				SET @WiscrId = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_Wiscr_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_Wiscr_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_Wiscr_Update
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Updates a record in the Wiscr table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Wiscr_Update
(

	@WiscrId int   ,

	@GeneralRawScore int   ,

	@GeneralStandartScore int   ,

	@SimilarityRawScore int   ,

	@SimilarityStandartScore int   ,

	@ArithmeticRawScore int   ,

	@ArithmeticStandartScore int   ,

	@WordRawScore int   ,

	@WordStandartScore int   ,

	@JudgingRawScore int   ,

	@JudgingStandartScore int   ,

	@SetOfNumbersRawScore int   ,

	@SetOfNumbersStandartScore int   ,

	@ImageDefineRawScore int   ,

	@ImageDefineStandartScore int   ,

	@ImageEditingRawScore int   ,

	@ImageEditingStandartScore int   ,

	@CubesPatternRawScore nchar (10)  ,

	@CubesPatternStandartScore int   ,

	@PartsMergeRawScore int   ,

	@PartsMergeStandartScore int   ,

	@PasswordRawScore int   ,

	@PasswordStandartScore int   ,

	@MazesRawScore int   ,

	@MazesStandartScore int   ,

	@TotalVerbalScore int   ,

	@TotalPerformanceScore int   ,

	@TotalScore int   ,

	@TestDate datetime   ,

	@CreateDate datetime   ,

	@UpdateDate datetime   ,

	@UserId int   ,

	@AdvisorId int   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[Wiscr]
				SET
					[GeneralRawScore] = @GeneralRawScore
					,[GeneralStandartScore] = @GeneralStandartScore
					,[SimilarityRawScore] = @SimilarityRawScore
					,[SimilarityStandartScore] = @SimilarityStandartScore
					,[ArithmeticRawScore] = @ArithmeticRawScore
					,[ArithmeticStandartScore] = @ArithmeticStandartScore
					,[WordRawScore] = @WordRawScore
					,[WordStandartScore] = @WordStandartScore
					,[JudgingRawScore] = @JudgingRawScore
					,[JudgingStandartScore] = @JudgingStandartScore
					,[SetOfNumbersRawScore] = @SetOfNumbersRawScore
					,[SetOfNumbersStandartScore] = @SetOfNumbersStandartScore
					,[ImageDefineRawScore] = @ImageDefineRawScore
					,[ImageDefineStandartScore] = @ImageDefineStandartScore
					,[ImageEditingRawScore] = @ImageEditingRawScore
					,[ImageEditingStandartScore] = @ImageEditingStandartScore
					,[CubesPatternRawScore] = @CubesPatternRawScore
					,[CubesPatternStandartScore] = @CubesPatternStandartScore
					,[PartsMergeRawScore] = @PartsMergeRawScore
					,[PartsMergeStandartScore] = @PartsMergeStandartScore
					,[PasswordRawScore] = @PasswordRawScore
					,[PasswordStandartScore] = @PasswordStandartScore
					,[MazesRawScore] = @MazesRawScore
					,[MazesStandartScore] = @MazesStandartScore
					,[TotalVerbalScore] = @TotalVerbalScore
					,[TotalPerformanceScore] = @TotalPerformanceScore
					,[TotalScore] = @TotalScore
					,[TestDate] = @TestDate
					,[CreateDate] = @CreateDate
					,[UpdateDate] = @UpdateDate
					,[UserID] = @UserId
					,[AdvisorID] = @AdvisorId
				WHERE
[WiscrID] = @WiscrId 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_Wiscr_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_Wiscr_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_Wiscr_Delete
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Deletes a record in the Wiscr table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Wiscr_Delete
(

	@WiscrId int   
)
AS


				DELETE FROM [dbo].[Wiscr] WITH (ROWLOCK) 
				WHERE
					[WiscrID] = @WiscrId
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_Wiscr_GetByWiscrId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_Wiscr_GetByWiscrId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_Wiscr_GetByWiscrId
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Select records from the Wiscr table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Wiscr_GetByWiscrId
(

	@WiscrId int   
)
AS


				SELECT
					[WiscrID],
					[GeneralRawScore],
					[GeneralStandartScore],
					[SimilarityRawScore],
					[SimilarityStandartScore],
					[ArithmeticRawScore],
					[ArithmeticStandartScore],
					[WordRawScore],
					[WordStandartScore],
					[JudgingRawScore],
					[JudgingStandartScore],
					[SetOfNumbersRawScore],
					[SetOfNumbersStandartScore],
					[ImageDefineRawScore],
					[ImageDefineStandartScore],
					[ImageEditingRawScore],
					[ImageEditingStandartScore],
					[CubesPatternRawScore],
					[CubesPatternStandartScore],
					[PartsMergeRawScore],
					[PartsMergeStandartScore],
					[PasswordRawScore],
					[PasswordStandartScore],
					[MazesRawScore],
					[MazesStandartScore],
					[TotalVerbalScore],
					[TotalPerformanceScore],
					[TotalScore],
					[TestDate],
					[CreateDate],
					[UpdateDate],
					[UserID],
					[AdvisorID]
				FROM
					[dbo].[Wiscr]
				WHERE
					[WiscrID] = @WiscrId
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_Wiscr_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_Wiscr_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_Wiscr_Find
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Finds records in the Wiscr table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Wiscr_Find
(

	@SearchUsingOR bit   = null ,

	@WiscrId int   = null ,

	@GeneralRawScore int   = null ,

	@GeneralStandartScore int   = null ,

	@SimilarityRawScore int   = null ,

	@SimilarityStandartScore int   = null ,

	@ArithmeticRawScore int   = null ,

	@ArithmeticStandartScore int   = null ,

	@WordRawScore int   = null ,

	@WordStandartScore int   = null ,

	@JudgingRawScore int   = null ,

	@JudgingStandartScore int   = null ,

	@SetOfNumbersRawScore int   = null ,

	@SetOfNumbersStandartScore int   = null ,

	@ImageDefineRawScore int   = null ,

	@ImageDefineStandartScore int   = null ,

	@ImageEditingRawScore int   = null ,

	@ImageEditingStandartScore int   = null ,

	@CubesPatternRawScore nchar (10)  = null ,

	@CubesPatternStandartScore int   = null ,

	@PartsMergeRawScore int   = null ,

	@PartsMergeStandartScore int   = null ,

	@PasswordRawScore int   = null ,

	@PasswordStandartScore int   = null ,

	@MazesRawScore int   = null ,

	@MazesStandartScore int   = null ,

	@TotalVerbalScore int   = null ,

	@TotalPerformanceScore int   = null ,

	@TotalScore int   = null ,

	@TestDate datetime   = null ,

	@CreateDate datetime   = null ,

	@UpdateDate datetime   = null ,

	@UserId int   = null ,

	@AdvisorId int   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [WiscrID]
	, [GeneralRawScore]
	, [GeneralStandartScore]
	, [SimilarityRawScore]
	, [SimilarityStandartScore]
	, [ArithmeticRawScore]
	, [ArithmeticStandartScore]
	, [WordRawScore]
	, [WordStandartScore]
	, [JudgingRawScore]
	, [JudgingStandartScore]
	, [SetOfNumbersRawScore]
	, [SetOfNumbersStandartScore]
	, [ImageDefineRawScore]
	, [ImageDefineStandartScore]
	, [ImageEditingRawScore]
	, [ImageEditingStandartScore]
	, [CubesPatternRawScore]
	, [CubesPatternStandartScore]
	, [PartsMergeRawScore]
	, [PartsMergeStandartScore]
	, [PasswordRawScore]
	, [PasswordStandartScore]
	, [MazesRawScore]
	, [MazesStandartScore]
	, [TotalVerbalScore]
	, [TotalPerformanceScore]
	, [TotalScore]
	, [TestDate]
	, [CreateDate]
	, [UpdateDate]
	, [UserID]
	, [AdvisorID]
    FROM
	[dbo].[Wiscr]
    WHERE 
	 ([WiscrID] = @WiscrId OR @WiscrId IS NULL)
	AND ([GeneralRawScore] = @GeneralRawScore OR @GeneralRawScore IS NULL)
	AND ([GeneralStandartScore] = @GeneralStandartScore OR @GeneralStandartScore IS NULL)
	AND ([SimilarityRawScore] = @SimilarityRawScore OR @SimilarityRawScore IS NULL)
	AND ([SimilarityStandartScore] = @SimilarityStandartScore OR @SimilarityStandartScore IS NULL)
	AND ([ArithmeticRawScore] = @ArithmeticRawScore OR @ArithmeticRawScore IS NULL)
	AND ([ArithmeticStandartScore] = @ArithmeticStandartScore OR @ArithmeticStandartScore IS NULL)
	AND ([WordRawScore] = @WordRawScore OR @WordRawScore IS NULL)
	AND ([WordStandartScore] = @WordStandartScore OR @WordStandartScore IS NULL)
	AND ([JudgingRawScore] = @JudgingRawScore OR @JudgingRawScore IS NULL)
	AND ([JudgingStandartScore] = @JudgingStandartScore OR @JudgingStandartScore IS NULL)
	AND ([SetOfNumbersRawScore] = @SetOfNumbersRawScore OR @SetOfNumbersRawScore IS NULL)
	AND ([SetOfNumbersStandartScore] = @SetOfNumbersStandartScore OR @SetOfNumbersStandartScore IS NULL)
	AND ([ImageDefineRawScore] = @ImageDefineRawScore OR @ImageDefineRawScore IS NULL)
	AND ([ImageDefineStandartScore] = @ImageDefineStandartScore OR @ImageDefineStandartScore IS NULL)
	AND ([ImageEditingRawScore] = @ImageEditingRawScore OR @ImageEditingRawScore IS NULL)
	AND ([ImageEditingStandartScore] = @ImageEditingStandartScore OR @ImageEditingStandartScore IS NULL)
	AND ([CubesPatternRawScore] = @CubesPatternRawScore OR @CubesPatternRawScore IS NULL)
	AND ([CubesPatternStandartScore] = @CubesPatternStandartScore OR @CubesPatternStandartScore IS NULL)
	AND ([PartsMergeRawScore] = @PartsMergeRawScore OR @PartsMergeRawScore IS NULL)
	AND ([PartsMergeStandartScore] = @PartsMergeStandartScore OR @PartsMergeStandartScore IS NULL)
	AND ([PasswordRawScore] = @PasswordRawScore OR @PasswordRawScore IS NULL)
	AND ([PasswordStandartScore] = @PasswordStandartScore OR @PasswordStandartScore IS NULL)
	AND ([MazesRawScore] = @MazesRawScore OR @MazesRawScore IS NULL)
	AND ([MazesStandartScore] = @MazesStandartScore OR @MazesStandartScore IS NULL)
	AND ([TotalVerbalScore] = @TotalVerbalScore OR @TotalVerbalScore IS NULL)
	AND ([TotalPerformanceScore] = @TotalPerformanceScore OR @TotalPerformanceScore IS NULL)
	AND ([TotalScore] = @TotalScore OR @TotalScore IS NULL)
	AND ([TestDate] = @TestDate OR @TestDate IS NULL)
	AND ([CreateDate] = @CreateDate OR @CreateDate IS NULL)
	AND ([UpdateDate] = @UpdateDate OR @UpdateDate IS NULL)
	AND ([UserID] = @UserId OR @UserId IS NULL)
	AND ([AdvisorID] = @AdvisorId OR @AdvisorId IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [WiscrID]
	, [GeneralRawScore]
	, [GeneralStandartScore]
	, [SimilarityRawScore]
	, [SimilarityStandartScore]
	, [ArithmeticRawScore]
	, [ArithmeticStandartScore]
	, [WordRawScore]
	, [WordStandartScore]
	, [JudgingRawScore]
	, [JudgingStandartScore]
	, [SetOfNumbersRawScore]
	, [SetOfNumbersStandartScore]
	, [ImageDefineRawScore]
	, [ImageDefineStandartScore]
	, [ImageEditingRawScore]
	, [ImageEditingStandartScore]
	, [CubesPatternRawScore]
	, [CubesPatternStandartScore]
	, [PartsMergeRawScore]
	, [PartsMergeStandartScore]
	, [PasswordRawScore]
	, [PasswordStandartScore]
	, [MazesRawScore]
	, [MazesStandartScore]
	, [TotalVerbalScore]
	, [TotalPerformanceScore]
	, [TotalScore]
	, [TestDate]
	, [CreateDate]
	, [UpdateDate]
	, [UserID]
	, [AdvisorID]
    FROM
	[dbo].[Wiscr]
    WHERE 
	 ([WiscrID] = @WiscrId AND @WiscrId is not null)
	OR ([GeneralRawScore] = @GeneralRawScore AND @GeneralRawScore is not null)
	OR ([GeneralStandartScore] = @GeneralStandartScore AND @GeneralStandartScore is not null)
	OR ([SimilarityRawScore] = @SimilarityRawScore AND @SimilarityRawScore is not null)
	OR ([SimilarityStandartScore] = @SimilarityStandartScore AND @SimilarityStandartScore is not null)
	OR ([ArithmeticRawScore] = @ArithmeticRawScore AND @ArithmeticRawScore is not null)
	OR ([ArithmeticStandartScore] = @ArithmeticStandartScore AND @ArithmeticStandartScore is not null)
	OR ([WordRawScore] = @WordRawScore AND @WordRawScore is not null)
	OR ([WordStandartScore] = @WordStandartScore AND @WordStandartScore is not null)
	OR ([JudgingRawScore] = @JudgingRawScore AND @JudgingRawScore is not null)
	OR ([JudgingStandartScore] = @JudgingStandartScore AND @JudgingStandartScore is not null)
	OR ([SetOfNumbersRawScore] = @SetOfNumbersRawScore AND @SetOfNumbersRawScore is not null)
	OR ([SetOfNumbersStandartScore] = @SetOfNumbersStandartScore AND @SetOfNumbersStandartScore is not null)
	OR ([ImageDefineRawScore] = @ImageDefineRawScore AND @ImageDefineRawScore is not null)
	OR ([ImageDefineStandartScore] = @ImageDefineStandartScore AND @ImageDefineStandartScore is not null)
	OR ([ImageEditingRawScore] = @ImageEditingRawScore AND @ImageEditingRawScore is not null)
	OR ([ImageEditingStandartScore] = @ImageEditingStandartScore AND @ImageEditingStandartScore is not null)
	OR ([CubesPatternRawScore] = @CubesPatternRawScore AND @CubesPatternRawScore is not null)
	OR ([CubesPatternStandartScore] = @CubesPatternStandartScore AND @CubesPatternStandartScore is not null)
	OR ([PartsMergeRawScore] = @PartsMergeRawScore AND @PartsMergeRawScore is not null)
	OR ([PartsMergeStandartScore] = @PartsMergeStandartScore AND @PartsMergeStandartScore is not null)
	OR ([PasswordRawScore] = @PasswordRawScore AND @PasswordRawScore is not null)
	OR ([PasswordStandartScore] = @PasswordStandartScore AND @PasswordStandartScore is not null)
	OR ([MazesRawScore] = @MazesRawScore AND @MazesRawScore is not null)
	OR ([MazesStandartScore] = @MazesStandartScore AND @MazesStandartScore is not null)
	OR ([TotalVerbalScore] = @TotalVerbalScore AND @TotalVerbalScore is not null)
	OR ([TotalPerformanceScore] = @TotalPerformanceScore AND @TotalPerformanceScore is not null)
	OR ([TotalScore] = @TotalScore AND @TotalScore is not null)
	OR ([TestDate] = @TestDate AND @TestDate is not null)
	OR ([CreateDate] = @CreateDate AND @CreateDate is not null)
	OR ([UpdateDate] = @UpdateDate AND @UpdateDate is not null)
	OR ([UserID] = @UserId AND @UserId is not null)
	OR ([AdvisorID] = @AdvisorId AND @AdvisorId is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_ClientView_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_ClientView_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_ClientView_Get_List
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Gets all records from the ClientView view
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_ClientView_Get_List

AS


                    
                    SELECT
                        [ClientID],
                        [FileNumber],
                        [FullName],
                        [MiddleName],
                        [Reference],
                        [Pediatrician],
                        [Blood],
                        [BirthDate],
                        [FirstContactDate],
                        [Gender],
                        [IdCard],
                        [Age],
                        [Mother],
                        [MotherBusiness],
                        [MotherEmail],
                        [MotherMobile],
                        [Father],
                        [FatherBusiness],
                        [FatherEmail],
                        [FatherMobile],
                        [AddressLine],
                        [TitleId],
                        [CityName],
                        [DistrictName],
                        [Region],
                        [CityID],
                        [RegionID],
                        [DistrictID],
                        [AdvisorID],
                        [AdvisorName]
                    FROM
                        [dbo].[ClientView]
                        
                    SELECT @@ROWCOUNT			
                

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_ClientView_Get procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_ClientView_Get') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_ClientView_Get
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Gets records from the ClientView view passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_ClientView_Get
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


                    
                    BEGIN
    
                    DECLARE @PageLowerBound int
                    DECLARE @PageUpperBound int
                    
                    -- Set the page bounds
                    SET @PageLowerBound = @PageSize * @PageIndex
                    SET @PageUpperBound = @PageLowerBound + @PageSize
    
                    IF (@OrderBy IS NULL OR LEN(@OrderBy) < 1)
                    BEGIN
                        -- default order by to first column
                        SET @OrderBy = '[ClientID]'
                    END
    
                    -- SQL Server 2005 Paging
                    DECLARE @SQL AS nvarchar(MAX)
                    SET @SQL = 'WITH PageIndex AS ('
                    SET @SQL = @SQL + ' SELECT'
                    IF @PageSize > 0
                    BEGIN
                        SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
                    END
                    SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
                    SET @SQL = @SQL + ', [ClientID]'
                    SET @SQL = @SQL + ', [FileNumber]'
                    SET @SQL = @SQL + ', [FullName]'
                    SET @SQL = @SQL + ', [MiddleName]'
                    SET @SQL = @SQL + ', [Reference]'
                    SET @SQL = @SQL + ', [Pediatrician]'
                    SET @SQL = @SQL + ', [Blood]'
                    SET @SQL = @SQL + ', [BirthDate]'
                    SET @SQL = @SQL + ', [FirstContactDate]'
                    SET @SQL = @SQL + ', [Gender]'
                    SET @SQL = @SQL + ', [IdCard]'
                    SET @SQL = @SQL + ', [Age]'
                    SET @SQL = @SQL + ', [Mother]'
                    SET @SQL = @SQL + ', [MotherBusiness]'
                    SET @SQL = @SQL + ', [MotherEmail]'
                    SET @SQL = @SQL + ', [MotherMobile]'
                    SET @SQL = @SQL + ', [Father]'
                    SET @SQL = @SQL + ', [FatherBusiness]'
                    SET @SQL = @SQL + ', [FatherEmail]'
                    SET @SQL = @SQL + ', [FatherMobile]'
                    SET @SQL = @SQL + ', [AddressLine]'
                    SET @SQL = @SQL + ', [TitleId]'
                    SET @SQL = @SQL + ', [CityName]'
                    SET @SQL = @SQL + ', [DistrictName]'
                    SET @SQL = @SQL + ', [Region]'
                    SET @SQL = @SQL + ', [CityID]'
                    SET @SQL = @SQL + ', [RegionID]'
                    SET @SQL = @SQL + ', [DistrictID]'
                    SET @SQL = @SQL + ', [AdvisorID]'
                    SET @SQL = @SQL + ', [AdvisorName]'
                    SET @SQL = @SQL + ' FROM [dbo].[ClientView]'
                    IF LEN(@WhereClause) > 0
                    BEGIN
                        SET @SQL = @SQL + ' WHERE ' + @WhereClause
                    END
                    SET @SQL = @SQL + ' ) SELECT'
                    SET @SQL = @SQL + ' [ClientID],'
                    SET @SQL = @SQL + ' [FileNumber],'
                    SET @SQL = @SQL + ' [FullName],'
                    SET @SQL = @SQL + ' [MiddleName],'
                    SET @SQL = @SQL + ' [Reference],'
                    SET @SQL = @SQL + ' [Pediatrician],'
                    SET @SQL = @SQL + ' [Blood],'
                    SET @SQL = @SQL + ' [BirthDate],'
                    SET @SQL = @SQL + ' [FirstContactDate],'
                    SET @SQL = @SQL + ' [Gender],'
                    SET @SQL = @SQL + ' [IdCard],'
                    SET @SQL = @SQL + ' [Age],'
                    SET @SQL = @SQL + ' [Mother],'
                    SET @SQL = @SQL + ' [MotherBusiness],'
                    SET @SQL = @SQL + ' [MotherEmail],'
                    SET @SQL = @SQL + ' [MotherMobile],'
                    SET @SQL = @SQL + ' [Father],'
                    SET @SQL = @SQL + ' [FatherBusiness],'
                    SET @SQL = @SQL + ' [FatherEmail],'
                    SET @SQL = @SQL + ' [FatherMobile],'
                    SET @SQL = @SQL + ' [AddressLine],'
                    SET @SQL = @SQL + ' [TitleId],'
                    SET @SQL = @SQL + ' [CityName],'
                    SET @SQL = @SQL + ' [DistrictName],'
                    SET @SQL = @SQL + ' [Region],'
                    SET @SQL = @SQL + ' [CityID],'
                    SET @SQL = @SQL + ' [RegionID],'
                    SET @SQL = @SQL + ' [DistrictID],'
                    SET @SQL = @SQL + ' [AdvisorID],'
                    SET @SQL = @SQL + ' [AdvisorName]'
                    SET @SQL = @SQL + ' FROM PageIndex'
                    SET @SQL = @SQL + ' WHERE RowIndex > ' + CONVERT(nvarchar, @PageLowerBound)
                    IF @PageSize > 0
                    BEGIN
                        SET @SQL = @SQL + ' AND RowIndex <= ' + CONVERT(nvarchar, @PageUpperBound)
                    END
                    IF LEN(@OrderBy) > 0
                    BEGIN
                        SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
                    END
                    EXEC sp_executesql @SQL
    
                    -- get row count
                    SET @SQL = 'SELECT COUNT(*) AS TotalRowCount'
                    SET @SQL = @SQL + ' FROM [dbo].[ClientView]'
                    IF LEN(@WhereClause) > 0
                    BEGIN
                        SET @SQL = @SQL + ' WHERE ' + @WhereClause
                    END
                    EXEC sp_executesql @SQL
                    
                    END
                

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_ProvinceView_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_ProvinceView_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_ProvinceView_Get_List
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Gets all records from the ProvinceView view
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_ProvinceView_Get_List

AS


                    
                    SELECT
                        [Id],
                        [RowNumber],
                        [AdminId],
                        [ObjectId],
                        [ParentId],
                        [PlateCode],
                        [AreaId],
                        [PhoneCode],
                        [ProvinceName],
                        [Longitude],
                        [Latitude],
                        [Type],
                        [CreateDate],
                        [CreateTime],
                        [UpdateDate],
                        [UpdateTime],
                        [AreaName]
                    FROM
                        [dbo].[ProvinceView]
                        
                    SELECT @@ROWCOUNT			
                

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_ProvinceView_Get procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_ProvinceView_Get') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_ProvinceView_Get
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Gets records from the ProvinceView view passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_ProvinceView_Get
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


                    
                    BEGIN
    
                    DECLARE @PageLowerBound int
                    DECLARE @PageUpperBound int
                    
                    -- Set the page bounds
                    SET @PageLowerBound = @PageSize * @PageIndex
                    SET @PageUpperBound = @PageLowerBound + @PageSize
    
                    IF (@OrderBy IS NULL OR LEN(@OrderBy) < 1)
                    BEGIN
                        -- default order by to first column
                        SET @OrderBy = '[Id]'
                    END
    
                    -- SQL Server 2005 Paging
                    DECLARE @SQL AS nvarchar(MAX)
                    SET @SQL = 'WITH PageIndex AS ('
                    SET @SQL = @SQL + ' SELECT'
                    IF @PageSize > 0
                    BEGIN
                        SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
                    END
                    SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
                    SET @SQL = @SQL + ', [Id]'
                    SET @SQL = @SQL + ', [RowNumber]'
                    SET @SQL = @SQL + ', [AdminId]'
                    SET @SQL = @SQL + ', [ObjectId]'
                    SET @SQL = @SQL + ', [ParentId]'
                    SET @SQL = @SQL + ', [PlateCode]'
                    SET @SQL = @SQL + ', [AreaId]'
                    SET @SQL = @SQL + ', [PhoneCode]'
                    SET @SQL = @SQL + ', [ProvinceName]'
                    SET @SQL = @SQL + ', [Longitude]'
                    SET @SQL = @SQL + ', [Latitude]'
                    SET @SQL = @SQL + ', [Type]'
                    SET @SQL = @SQL + ', [CreateDate]'
                    SET @SQL = @SQL + ', [CreateTime]'
                    SET @SQL = @SQL + ', [UpdateDate]'
                    SET @SQL = @SQL + ', [UpdateTime]'
                    SET @SQL = @SQL + ', [AreaName]'
                    SET @SQL = @SQL + ' FROM [dbo].[ProvinceView]'
                    IF LEN(@WhereClause) > 0
                    BEGIN
                        SET @SQL = @SQL + ' WHERE ' + @WhereClause
                    END
                    SET @SQL = @SQL + ' ) SELECT'
                    SET @SQL = @SQL + ' [Id],'
                    SET @SQL = @SQL + ' [RowNumber],'
                    SET @SQL = @SQL + ' [AdminId],'
                    SET @SQL = @SQL + ' [ObjectId],'
                    SET @SQL = @SQL + ' [ParentId],'
                    SET @SQL = @SQL + ' [PlateCode],'
                    SET @SQL = @SQL + ' [AreaId],'
                    SET @SQL = @SQL + ' [PhoneCode],'
                    SET @SQL = @SQL + ' [ProvinceName],'
                    SET @SQL = @SQL + ' [Longitude],'
                    SET @SQL = @SQL + ' [Latitude],'
                    SET @SQL = @SQL + ' [Type],'
                    SET @SQL = @SQL + ' [CreateDate],'
                    SET @SQL = @SQL + ' [CreateTime],'
                    SET @SQL = @SQL + ' [UpdateDate],'
                    SET @SQL = @SQL + ' [UpdateTime],'
                    SET @SQL = @SQL + ' [AreaName]'
                    SET @SQL = @SQL + ' FROM PageIndex'
                    SET @SQL = @SQL + ' WHERE RowIndex > ' + CONVERT(nvarchar, @PageLowerBound)
                    IF @PageSize > 0
                    BEGIN
                        SET @SQL = @SQL + ' AND RowIndex <= ' + CONVERT(nvarchar, @PageUpperBound)
                    END
                    IF LEN(@OrderBy) > 0
                    BEGIN
                        SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
                    END
                    EXEC sp_executesql @SQL
    
                    -- get row count
                    SET @SQL = 'SELECT COUNT(*) AS TotalRowCount'
                    SET @SQL = @SQL + ' FROM [dbo].[ProvinceView]'
                    IF LEN(@WhereClause) > 0
                    BEGIN
                        SET @SQL = @SQL + ' WHERE ' + @WhereClause
                    END
                    EXEC sp_executesql @SQL
                    
                    END
                

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_WippsiView_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_WippsiView_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_WippsiView_Get_List
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Gets all records from the WippsiView view
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_WippsiView_Get_List

AS


                    
                    SELECT
                        [SeanceID],
                        [ClientID],
                        [CreateDate],
                        [SeanceDate],
                        [SeanceTime],
                        [SeanceStatusId],
                        [SeanceAdvisorID],
                        [SeanceAdvisorName],
                        [TestDate],
                        [TestAdvisorID],
                        [TestAdvisorName],
                        [TotalVerbalScore],
                        [TotalPerformanceScore],
                        [TotalScore]
                    FROM
                        [dbo].[WippsiView]
                        
                    SELECT @@ROWCOUNT			
                

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_WippsiView_Get procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_WippsiView_Get') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_WippsiView_Get
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Gets records from the WippsiView view passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_WippsiView_Get
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


                    
                    BEGIN
    
                    DECLARE @PageLowerBound int
                    DECLARE @PageUpperBound int
                    
                    -- Set the page bounds
                    SET @PageLowerBound = @PageSize * @PageIndex
                    SET @PageUpperBound = @PageLowerBound + @PageSize
    
                    IF (@OrderBy IS NULL OR LEN(@OrderBy) < 1)
                    BEGIN
                        -- default order by to first column
                        SET @OrderBy = '[SeanceID]'
                    END
    
                    -- SQL Server 2005 Paging
                    DECLARE @SQL AS nvarchar(MAX)
                    SET @SQL = 'WITH PageIndex AS ('
                    SET @SQL = @SQL + ' SELECT'
                    IF @PageSize > 0
                    BEGIN
                        SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
                    END
                    SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
                    SET @SQL = @SQL + ', [SeanceID]'
                    SET @SQL = @SQL + ', [ClientID]'
                    SET @SQL = @SQL + ', [CreateDate]'
                    SET @SQL = @SQL + ', [SeanceDate]'
                    SET @SQL = @SQL + ', [SeanceTime]'
                    SET @SQL = @SQL + ', [SeanceStatusId]'
                    SET @SQL = @SQL + ', [SeanceAdvisorID]'
                    SET @SQL = @SQL + ', [SeanceAdvisorName]'
                    SET @SQL = @SQL + ', [TestDate]'
                    SET @SQL = @SQL + ', [TestAdvisorID]'
                    SET @SQL = @SQL + ', [TestAdvisorName]'
                    SET @SQL = @SQL + ', [TotalVerbalScore]'
                    SET @SQL = @SQL + ', [TotalPerformanceScore]'
                    SET @SQL = @SQL + ', [TotalScore]'
                    SET @SQL = @SQL + ' FROM [dbo].[WippsiView]'
                    IF LEN(@WhereClause) > 0
                    BEGIN
                        SET @SQL = @SQL + ' WHERE ' + @WhereClause
                    END
                    SET @SQL = @SQL + ' ) SELECT'
                    SET @SQL = @SQL + ' [SeanceID],'
                    SET @SQL = @SQL + ' [ClientID],'
                    SET @SQL = @SQL + ' [CreateDate],'
                    SET @SQL = @SQL + ' [SeanceDate],'
                    SET @SQL = @SQL + ' [SeanceTime],'
                    SET @SQL = @SQL + ' [SeanceStatusId],'
                    SET @SQL = @SQL + ' [SeanceAdvisorID],'
                    SET @SQL = @SQL + ' [SeanceAdvisorName],'
                    SET @SQL = @SQL + ' [TestDate],'
                    SET @SQL = @SQL + ' [TestAdvisorID],'
                    SET @SQL = @SQL + ' [TestAdvisorName],'
                    SET @SQL = @SQL + ' [TotalVerbalScore],'
                    SET @SQL = @SQL + ' [TotalPerformanceScore],'
                    SET @SQL = @SQL + ' [TotalScore]'
                    SET @SQL = @SQL + ' FROM PageIndex'
                    SET @SQL = @SQL + ' WHERE RowIndex > ' + CONVERT(nvarchar, @PageLowerBound)
                    IF @PageSize > 0
                    BEGIN
                        SET @SQL = @SQL + ' AND RowIndex <= ' + CONVERT(nvarchar, @PageUpperBound)
                    END
                    IF LEN(@OrderBy) > 0
                    BEGIN
                        SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
                    END
                    EXEC sp_executesql @SQL
    
                    -- get row count
                    SET @SQL = 'SELECT COUNT(*) AS TotalRowCount'
                    SET @SQL = @SQL + ' FROM [dbo].[WippsiView]'
                    IF LEN(@WhereClause) > 0
                    BEGIN
                        SET @SQL = @SQL + ' WHERE ' + @WhereClause
                    END
                    EXEC sp_executesql @SQL
                    
                    END
                

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_WiscrView_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_WiscrView_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_WiscrView_Get_List
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Gets all records from the WiscrView view
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_WiscrView_Get_List

AS


                    
                    SELECT
                        [SeanceID],
                        [ClientID],
                        [CreateDate],
                        [SeanceDate],
                        [SeanceTime],
                        [SeanceStatusId],
                        [SeanceAdvisorID],
                        [SeanceAdvisorName],
                        [TestDate],
                        [TestAdvisorID],
                        [TestAdvisorName],
                        [TotalVerbalScore],
                        [TotalPerformanceScore],
                        [TotalScore]
                    FROM
                        [dbo].[WiscrView]
                        
                    SELECT @@ROWCOUNT			
                

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_WiscrView_Get procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_WiscrView_Get') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_WiscrView_Get
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 18 Aralık 2018 Salı

-- Created By:  ()
-- Purpose: Gets records from the WiscrView view passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_WiscrView_Get
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


                    
                    BEGIN
    
                    DECLARE @PageLowerBound int
                    DECLARE @PageUpperBound int
                    
                    -- Set the page bounds
                    SET @PageLowerBound = @PageSize * @PageIndex
                    SET @PageUpperBound = @PageLowerBound + @PageSize
    
                    IF (@OrderBy IS NULL OR LEN(@OrderBy) < 1)
                    BEGIN
                        -- default order by to first column
                        SET @OrderBy = '[SeanceID]'
                    END
    
                    -- SQL Server 2005 Paging
                    DECLARE @SQL AS nvarchar(MAX)
                    SET @SQL = 'WITH PageIndex AS ('
                    SET @SQL = @SQL + ' SELECT'
                    IF @PageSize > 0
                    BEGIN
                        SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
                    END
                    SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
                    SET @SQL = @SQL + ', [SeanceID]'
                    SET @SQL = @SQL + ', [ClientID]'
                    SET @SQL = @SQL + ', [CreateDate]'
                    SET @SQL = @SQL + ', [SeanceDate]'
                    SET @SQL = @SQL + ', [SeanceTime]'
                    SET @SQL = @SQL + ', [SeanceStatusId]'
                    SET @SQL = @SQL + ', [SeanceAdvisorID]'
                    SET @SQL = @SQL + ', [SeanceAdvisorName]'
                    SET @SQL = @SQL + ', [TestDate]'
                    SET @SQL = @SQL + ', [TestAdvisorID]'
                    SET @SQL = @SQL + ', [TestAdvisorName]'
                    SET @SQL = @SQL + ', [TotalVerbalScore]'
                    SET @SQL = @SQL + ', [TotalPerformanceScore]'
                    SET @SQL = @SQL + ', [TotalScore]'
                    SET @SQL = @SQL + ' FROM [dbo].[WiscrView]'
                    IF LEN(@WhereClause) > 0
                    BEGIN
                        SET @SQL = @SQL + ' WHERE ' + @WhereClause
                    END
                    SET @SQL = @SQL + ' ) SELECT'
                    SET @SQL = @SQL + ' [SeanceID],'
                    SET @SQL = @SQL + ' [ClientID],'
                    SET @SQL = @SQL + ' [CreateDate],'
                    SET @SQL = @SQL + ' [SeanceDate],'
                    SET @SQL = @SQL + ' [SeanceTime],'
                    SET @SQL = @SQL + ' [SeanceStatusId],'
                    SET @SQL = @SQL + ' [SeanceAdvisorID],'
                    SET @SQL = @SQL + ' [SeanceAdvisorName],'
                    SET @SQL = @SQL + ' [TestDate],'
                    SET @SQL = @SQL + ' [TestAdvisorID],'
                    SET @SQL = @SQL + ' [TestAdvisorName],'
                    SET @SQL = @SQL + ' [TotalVerbalScore],'
                    SET @SQL = @SQL + ' [TotalPerformanceScore],'
                    SET @SQL = @SQL + ' [TotalScore]'
                    SET @SQL = @SQL + ' FROM PageIndex'
                    SET @SQL = @SQL + ' WHERE RowIndex > ' + CONVERT(nvarchar, @PageLowerBound)
                    IF @PageSize > 0
                    BEGIN
                        SET @SQL = @SQL + ' AND RowIndex <= ' + CONVERT(nvarchar, @PageUpperBound)
                    END
                    IF LEN(@OrderBy) > 0
                    BEGIN
                        SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
                    END
                    EXEC sp_executesql @SQL
    
                    -- get row count
                    SET @SQL = 'SELECT COUNT(*) AS TotalRowCount'
                    SET @SQL = @SQL + ' FROM [dbo].[WiscrView]'
                    IF LEN(@WhereClause) > 0
                    BEGIN
                        SET @SQL = @SQL + ' WHERE ' + @WhereClause
                    END
                    EXEC sp_executesql @SQL
                    
                    END
                

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

