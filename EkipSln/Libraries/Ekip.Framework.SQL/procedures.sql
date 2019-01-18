
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
-- Date Created: 15 Ocak 2019 Salı

-- Created By:  ()
-- Purpose: Gets all records from the Advisor table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Advisor_Get_List

AS


				
				SELECT
					[AdvisorId],
					[TitleId],
					[FullName],
					[Email],
					[Phone],
					[Gsm],
					[Notes],
					[CreateDate],
					[UpdateDate],
					[CreateUserId],
					[UpdateUserId],
					[Active],
					[Deleted]
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
-- Date Created: 15 Ocak 2019 Salı

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
				SET @SQL = @SQL + ', [TitleId]'
				SET @SQL = @SQL + ', [FullName]'
				SET @SQL = @SQL + ', [Email]'
				SET @SQL = @SQL + ', [Phone]'
				SET @SQL = @SQL + ', [Gsm]'
				SET @SQL = @SQL + ', [Notes]'
				SET @SQL = @SQL + ', [CreateDate]'
				SET @SQL = @SQL + ', [UpdateDate]'
				SET @SQL = @SQL + ', [CreateUserId]'
				SET @SQL = @SQL + ', [UpdateUserId]'
				SET @SQL = @SQL + ', [Active]'
				SET @SQL = @SQL + ', [Deleted]'
				SET @SQL = @SQL + ' FROM [dbo].[Advisor]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [AdvisorId],'
				SET @SQL = @SQL + ' [TitleId],'
				SET @SQL = @SQL + ' [FullName],'
				SET @SQL = @SQL + ' [Email],'
				SET @SQL = @SQL + ' [Phone],'
				SET @SQL = @SQL + ' [Gsm],'
				SET @SQL = @SQL + ' [Notes],'
				SET @SQL = @SQL + ' [CreateDate],'
				SET @SQL = @SQL + ' [UpdateDate],'
				SET @SQL = @SQL + ' [CreateUserId],'
				SET @SQL = @SQL + ' [UpdateUserId],'
				SET @SQL = @SQL + ' [Active],'
				SET @SQL = @SQL + ' [Deleted]'
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
-- Date Created: 15 Ocak 2019 Salı

-- Created By:  ()
-- Purpose: Inserts a record into the Advisor table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Advisor_Insert
(

	@AdvisorId int    OUTPUT,

	@TitleId tinyint   ,

	@FullName varchar (50)  ,

	@Email varchar (50)  ,

	@Phone varchar (50)  ,

	@Gsm varchar (50)  ,

	@Notes nvarchar (MAX)  ,

	@CreateDate datetime   ,

	@UpdateDate datetime   ,

	@CreateUserId int   ,

	@UpdateUserId int   ,

	@Active bit   ,

	@Deleted bit   
)
AS


				
				INSERT INTO [dbo].[Advisor]
					(
					[TitleId]
					,[FullName]
					,[Email]
					,[Phone]
					,[Gsm]
					,[Notes]
					,[CreateDate]
					,[UpdateDate]
					,[CreateUserId]
					,[UpdateUserId]
					,[Active]
					,[Deleted]
					)
				VALUES
					(
					@TitleId
					,@FullName
					,@Email
					,@Phone
					,@Gsm
					,@Notes
					,@CreateDate
					,@UpdateDate
					,@CreateUserId
					,@UpdateUserId
					,@Active
					,@Deleted
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
-- Date Created: 15 Ocak 2019 Salı

-- Created By:  ()
-- Purpose: Updates a record in the Advisor table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Advisor_Update
(

	@AdvisorId int   ,

	@TitleId tinyint   ,

	@FullName varchar (50)  ,

	@Email varchar (50)  ,

	@Phone varchar (50)  ,

	@Gsm varchar (50)  ,

	@Notes nvarchar (MAX)  ,

	@CreateDate datetime   ,

	@UpdateDate datetime   ,

	@CreateUserId int   ,

	@UpdateUserId int   ,

	@Active bit   ,

	@Deleted bit   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[Advisor]
				SET
					[TitleId] = @TitleId
					,[FullName] = @FullName
					,[Email] = @Email
					,[Phone] = @Phone
					,[Gsm] = @Gsm
					,[Notes] = @Notes
					,[CreateDate] = @CreateDate
					,[UpdateDate] = @UpdateDate
					,[CreateUserId] = @CreateUserId
					,[UpdateUserId] = @UpdateUserId
					,[Active] = @Active
					,[Deleted] = @Deleted
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
-- Date Created: 15 Ocak 2019 Salı

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
-- Date Created: 15 Ocak 2019 Salı

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
					[TitleId],
					[FullName],
					[Email],
					[Phone],
					[Gsm],
					[Notes],
					[CreateDate],
					[UpdateDate],
					[CreateUserId],
					[UpdateUserId],
					[Active],
					[Deleted]
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
-- Date Created: 15 Ocak 2019 Salı

-- Created By:  ()
-- Purpose: Finds records in the Advisor table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Advisor_Find
(

	@SearchUsingOR bit   = null ,

	@AdvisorId int   = null ,

	@TitleId tinyint   = null ,

	@FullName varchar (50)  = null ,

	@Email varchar (50)  = null ,

	@Phone varchar (50)  = null ,

	@Gsm varchar (50)  = null ,

	@Notes nvarchar (MAX)  = null ,

	@CreateDate datetime   = null ,

	@UpdateDate datetime   = null ,

	@CreateUserId int   = null ,

	@UpdateUserId int   = null ,

	@Active bit   = null ,

	@Deleted bit   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [AdvisorId]
	, [TitleId]
	, [FullName]
	, [Email]
	, [Phone]
	, [Gsm]
	, [Notes]
	, [CreateDate]
	, [UpdateDate]
	, [CreateUserId]
	, [UpdateUserId]
	, [Active]
	, [Deleted]
    FROM
	[dbo].[Advisor]
    WHERE 
	 ([AdvisorId] = @AdvisorId OR @AdvisorId IS NULL)
	AND ([TitleId] = @TitleId OR @TitleId IS NULL)
	AND ([FullName] = @FullName OR @FullName IS NULL)
	AND ([Email] = @Email OR @Email IS NULL)
	AND ([Phone] = @Phone OR @Phone IS NULL)
	AND ([Gsm] = @Gsm OR @Gsm IS NULL)
	AND ([Notes] = @Notes OR @Notes IS NULL)
	AND ([CreateDate] = @CreateDate OR @CreateDate IS NULL)
	AND ([UpdateDate] = @UpdateDate OR @UpdateDate IS NULL)
	AND ([CreateUserId] = @CreateUserId OR @CreateUserId IS NULL)
	AND ([UpdateUserId] = @UpdateUserId OR @UpdateUserId IS NULL)
	AND ([Active] = @Active OR @Active IS NULL)
	AND ([Deleted] = @Deleted OR @Deleted IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [AdvisorId]
	, [TitleId]
	, [FullName]
	, [Email]
	, [Phone]
	, [Gsm]
	, [Notes]
	, [CreateDate]
	, [UpdateDate]
	, [CreateUserId]
	, [UpdateUserId]
	, [Active]
	, [Deleted]
    FROM
	[dbo].[Advisor]
    WHERE 
	 ([AdvisorId] = @AdvisorId AND @AdvisorId is not null)
	OR ([TitleId] = @TitleId AND @TitleId is not null)
	OR ([FullName] = @FullName AND @FullName is not null)
	OR ([Email] = @Email AND @Email is not null)
	OR ([Phone] = @Phone AND @Phone is not null)
	OR ([Gsm] = @Gsm AND @Gsm is not null)
	OR ([Notes] = @Notes AND @Notes is not null)
	OR ([CreateDate] = @CreateDate AND @CreateDate is not null)
	OR ([UpdateDate] = @UpdateDate AND @UpdateDate is not null)
	OR ([CreateUserId] = @CreateUserId AND @CreateUserId is not null)
	OR ([UpdateUserId] = @UpdateUserId AND @UpdateUserId is not null)
	OR ([Active] = @Active AND @Active is not null)
	OR ([Deleted] = @Deleted AND @Deleted is not null)
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
-- Date Created: 15 Ocak 2019 Salı

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
-- Date Created: 15 Ocak 2019 Salı

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
-- Date Created: 15 Ocak 2019 Salı

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
-- Date Created: 15 Ocak 2019 Salı

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
-- Date Created: 15 Ocak 2019 Salı

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
-- Date Created: 15 Ocak 2019 Salı

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
-- Date Created: 15 Ocak 2019 Salı

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

	

-- Drop the dbo.sp_Seance_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_Seance_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_Seance_Get_List
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 15 Ocak 2019 Salı

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
					[Notes],
					[SeanceStatusId],
					[CreateDate],
					[UpdateDate],
					[CreatedUserId],
					[UpdatedUserId],
					[Active],
					[Deleted]
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
-- Date Created: 15 Ocak 2019 Salı

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
				SET @SQL = @SQL + ', [Notes]'
				SET @SQL = @SQL + ', [SeanceStatusId]'
				SET @SQL = @SQL + ', [CreateDate]'
				SET @SQL = @SQL + ', [UpdateDate]'
				SET @SQL = @SQL + ', [CreatedUserId]'
				SET @SQL = @SQL + ', [UpdatedUserId]'
				SET @SQL = @SQL + ', [Active]'
				SET @SQL = @SQL + ', [Deleted]'
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
				SET @SQL = @SQL + ' [Notes],'
				SET @SQL = @SQL + ' [SeanceStatusId],'
				SET @SQL = @SQL + ' [CreateDate],'
				SET @SQL = @SQL + ' [UpdateDate],'
				SET @SQL = @SQL + ' [CreatedUserId],'
				SET @SQL = @SQL + ' [UpdatedUserId],'
				SET @SQL = @SQL + ' [Active],'
				SET @SQL = @SQL + ' [Deleted]'
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
-- Date Created: 15 Ocak 2019 Salı

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

	@Notes varchar (MAX)  ,

	@SeanceStatusId tinyint   ,

	@CreateDate datetime   ,

	@UpdateDate datetime   ,

	@CreatedUserId int   ,

	@UpdatedUserId int   ,

	@Active bit   ,

	@Deleted bit   
)
AS


				
				INSERT INTO [dbo].[Seance]
					(
					[ClientId]
					,[AdvisorId]
					,[SeanceDate]
					,[SeanceTime]
					,[Notes]
					,[SeanceStatusId]
					,[CreateDate]
					,[UpdateDate]
					,[CreatedUserId]
					,[UpdatedUserId]
					,[Active]
					,[Deleted]
					)
				VALUES
					(
					@ClientId
					,@AdvisorId
					,@SeanceDate
					,@SeanceTime
					,@Notes
					,@SeanceStatusId
					,@CreateDate
					,@UpdateDate
					,@CreatedUserId
					,@UpdatedUserId
					,@Active
					,@Deleted
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
-- Date Created: 15 Ocak 2019 Salı

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

	@Notes varchar (MAX)  ,

	@SeanceStatusId tinyint   ,

	@CreateDate datetime   ,

	@UpdateDate datetime   ,

	@CreatedUserId int   ,

	@UpdatedUserId int   ,

	@Active bit   ,

	@Deleted bit   
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
					,[Notes] = @Notes
					,[SeanceStatusId] = @SeanceStatusId
					,[CreateDate] = @CreateDate
					,[UpdateDate] = @UpdateDate
					,[CreatedUserId] = @CreatedUserId
					,[UpdatedUserId] = @UpdatedUserId
					,[Active] = @Active
					,[Deleted] = @Deleted
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
-- Date Created: 15 Ocak 2019 Salı

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
-- Date Created: 15 Ocak 2019 Salı

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
					[Notes],
					[SeanceStatusId],
					[CreateDate],
					[UpdateDate],
					[CreatedUserId],
					[UpdatedUserId],
					[Active],
					[Deleted]
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

	

-- Drop the dbo.sp_Seance_GetBySeanceId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_Seance_GetBySeanceId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_Seance_GetBySeanceId
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 15 Ocak 2019 Salı

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
					[Notes],
					[SeanceStatusId],
					[CreateDate],
					[UpdateDate],
					[CreatedUserId],
					[UpdatedUserId],
					[Active],
					[Deleted]
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
-- Date Created: 15 Ocak 2019 Salı

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

	@Notes varchar (MAX)  = null ,

	@SeanceStatusId tinyint   = null ,

	@CreateDate datetime   = null ,

	@UpdateDate datetime   = null ,

	@CreatedUserId int   = null ,

	@UpdatedUserId int   = null ,

	@Active bit   = null ,

	@Deleted bit   = null 
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
	, [Notes]
	, [SeanceStatusId]
	, [CreateDate]
	, [UpdateDate]
	, [CreatedUserId]
	, [UpdatedUserId]
	, [Active]
	, [Deleted]
    FROM
	[dbo].[Seance]
    WHERE 
	 ([SeanceId] = @SeanceId OR @SeanceId IS NULL)
	AND ([ClientId] = @ClientId OR @ClientId IS NULL)
	AND ([AdvisorId] = @AdvisorId OR @AdvisorId IS NULL)
	AND ([SeanceDate] = @SeanceDate OR @SeanceDate IS NULL)
	AND ([SeanceTime] = @SeanceTime OR @SeanceTime IS NULL)
	AND ([Notes] = @Notes OR @Notes IS NULL)
	AND ([SeanceStatusId] = @SeanceStatusId OR @SeanceStatusId IS NULL)
	AND ([CreateDate] = @CreateDate OR @CreateDate IS NULL)
	AND ([UpdateDate] = @UpdateDate OR @UpdateDate IS NULL)
	AND ([CreatedUserId] = @CreatedUserId OR @CreatedUserId IS NULL)
	AND ([UpdatedUserId] = @UpdatedUserId OR @UpdatedUserId IS NULL)
	AND ([Active] = @Active OR @Active IS NULL)
	AND ([Deleted] = @Deleted OR @Deleted IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [SeanceId]
	, [ClientId]
	, [AdvisorId]
	, [SeanceDate]
	, [SeanceTime]
	, [Notes]
	, [SeanceStatusId]
	, [CreateDate]
	, [UpdateDate]
	, [CreatedUserId]
	, [UpdatedUserId]
	, [Active]
	, [Deleted]
    FROM
	[dbo].[Seance]
    WHERE 
	 ([SeanceId] = @SeanceId AND @SeanceId is not null)
	OR ([ClientId] = @ClientId AND @ClientId is not null)
	OR ([AdvisorId] = @AdvisorId AND @AdvisorId is not null)
	OR ([SeanceDate] = @SeanceDate AND @SeanceDate is not null)
	OR ([SeanceTime] = @SeanceTime AND @SeanceTime is not null)
	OR ([Notes] = @Notes AND @Notes is not null)
	OR ([SeanceStatusId] = @SeanceStatusId AND @SeanceStatusId is not null)
	OR ([CreateDate] = @CreateDate AND @CreateDate is not null)
	OR ([UpdateDate] = @UpdateDate AND @UpdateDate is not null)
	OR ([CreatedUserId] = @CreatedUserId AND @CreatedUserId is not null)
	OR ([UpdatedUserId] = @UpdatedUserId AND @UpdatedUserId is not null)
	OR ([Active] = @Active AND @Active is not null)
	OR ([Deleted] = @Deleted AND @Deleted is not null)
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
-- Date Created: 15 Ocak 2019 Salı

-- Created By:  ()
-- Purpose: Gets all records from the School table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_School_Get_List

AS


				
				SELECT
					[SchoolId],
					[SchoolName],
					[CorparationTypeId],
					[SchoolTypeId],
					[ProvinceId],
					[TownId],
					[Address],
					[Phone],
					[Fax],
					[WebAddress],
					[Notes],
					[CreateDate],
					[UpdateDate],
					[CreateUserId],
					[UpdateUserId],
					[Active],
					[Deleted]
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
-- Date Created: 15 Ocak 2019 Salı

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
				SET @SQL = @SQL + ', [CorparationTypeId]'
				SET @SQL = @SQL + ', [SchoolTypeId]'
				SET @SQL = @SQL + ', [ProvinceId]'
				SET @SQL = @SQL + ', [TownId]'
				SET @SQL = @SQL + ', [Address]'
				SET @SQL = @SQL + ', [Phone]'
				SET @SQL = @SQL + ', [Fax]'
				SET @SQL = @SQL + ', [WebAddress]'
				SET @SQL = @SQL + ', [Notes]'
				SET @SQL = @SQL + ', [CreateDate]'
				SET @SQL = @SQL + ', [UpdateDate]'
				SET @SQL = @SQL + ', [CreateUserId]'
				SET @SQL = @SQL + ', [UpdateUserId]'
				SET @SQL = @SQL + ', [Active]'
				SET @SQL = @SQL + ', [Deleted]'
				SET @SQL = @SQL + ' FROM [dbo].[School]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [SchoolId],'
				SET @SQL = @SQL + ' [SchoolName],'
				SET @SQL = @SQL + ' [CorparationTypeId],'
				SET @SQL = @SQL + ' [SchoolTypeId],'
				SET @SQL = @SQL + ' [ProvinceId],'
				SET @SQL = @SQL + ' [TownId],'
				SET @SQL = @SQL + ' [Address],'
				SET @SQL = @SQL + ' [Phone],'
				SET @SQL = @SQL + ' [Fax],'
				SET @SQL = @SQL + ' [WebAddress],'
				SET @SQL = @SQL + ' [Notes],'
				SET @SQL = @SQL + ' [CreateDate],'
				SET @SQL = @SQL + ' [UpdateDate],'
				SET @SQL = @SQL + ' [CreateUserId],'
				SET @SQL = @SQL + ' [UpdateUserId],'
				SET @SQL = @SQL + ' [Active],'
				SET @SQL = @SQL + ' [Deleted]'
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
-- Date Created: 15 Ocak 2019 Salı

-- Created By:  ()
-- Purpose: Inserts a record into the School table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_School_Insert
(

	@SchoolId int    OUTPUT,

	@SchoolName varchar (100)  ,

	@CorparationTypeId tinyint   ,

	@SchoolTypeId tinyint   ,

	@ProvinceId int   ,

	@TownId int   ,

	@Address varchar (500)  ,

	@Phone varchar (15)  ,

	@Fax varchar (15)  ,

	@WebAddress varchar (100)  ,

	@Notes varchar (MAX)  ,

	@CreateDate datetime   ,

	@UpdateDate datetime   ,

	@CreateUserId int   ,

	@UpdateUserId int   ,

	@Active bit   ,

	@Deleted bit   
)
AS


				
				INSERT INTO [dbo].[School]
					(
					[SchoolName]
					,[CorparationTypeId]
					,[SchoolTypeId]
					,[ProvinceId]
					,[TownId]
					,[Address]
					,[Phone]
					,[Fax]
					,[WebAddress]
					,[Notes]
					,[CreateDate]
					,[UpdateDate]
					,[CreateUserId]
					,[UpdateUserId]
					,[Active]
					,[Deleted]
					)
				VALUES
					(
					@SchoolName
					,@CorparationTypeId
					,@SchoolTypeId
					,@ProvinceId
					,@TownId
					,@Address
					,@Phone
					,@Fax
					,@WebAddress
					,@Notes
					,@CreateDate
					,@UpdateDate
					,@CreateUserId
					,@UpdateUserId
					,@Active
					,@Deleted
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
-- Date Created: 15 Ocak 2019 Salı

-- Created By:  ()
-- Purpose: Updates a record in the School table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_School_Update
(

	@SchoolId int   ,

	@SchoolName varchar (100)  ,

	@CorparationTypeId tinyint   ,

	@SchoolTypeId tinyint   ,

	@ProvinceId int   ,

	@TownId int   ,

	@Address varchar (500)  ,

	@Phone varchar (15)  ,

	@Fax varchar (15)  ,

	@WebAddress varchar (100)  ,

	@Notes varchar (MAX)  ,

	@CreateDate datetime   ,

	@UpdateDate datetime   ,

	@CreateUserId int   ,

	@UpdateUserId int   ,

	@Active bit   ,

	@Deleted bit   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[School]
				SET
					[SchoolName] = @SchoolName
					,[CorparationTypeId] = @CorparationTypeId
					,[SchoolTypeId] = @SchoolTypeId
					,[ProvinceId] = @ProvinceId
					,[TownId] = @TownId
					,[Address] = @Address
					,[Phone] = @Phone
					,[Fax] = @Fax
					,[WebAddress] = @WebAddress
					,[Notes] = @Notes
					,[CreateDate] = @CreateDate
					,[UpdateDate] = @UpdateDate
					,[CreateUserId] = @CreateUserId
					,[UpdateUserId] = @UpdateUserId
					,[Active] = @Active
					,[Deleted] = @Deleted
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
-- Date Created: 15 Ocak 2019 Salı

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
-- Date Created: 15 Ocak 2019 Salı

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
					[CorparationTypeId],
					[SchoolTypeId],
					[ProvinceId],
					[TownId],
					[Address],
					[Phone],
					[Fax],
					[WebAddress],
					[Notes],
					[CreateDate],
					[UpdateDate],
					[CreateUserId],
					[UpdateUserId],
					[Active],
					[Deleted]
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
-- Date Created: 15 Ocak 2019 Salı

-- Created By:  ()
-- Purpose: Finds records in the School table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_School_Find
(

	@SearchUsingOR bit   = null ,

	@SchoolId int   = null ,

	@SchoolName varchar (100)  = null ,

	@CorparationTypeId tinyint   = null ,

	@SchoolTypeId tinyint   = null ,

	@ProvinceId int   = null ,

	@TownId int   = null ,

	@Address varchar (500)  = null ,

	@Phone varchar (15)  = null ,

	@Fax varchar (15)  = null ,

	@WebAddress varchar (100)  = null ,

	@Notes varchar (MAX)  = null ,

	@CreateDate datetime   = null ,

	@UpdateDate datetime   = null ,

	@CreateUserId int   = null ,

	@UpdateUserId int   = null ,

	@Active bit   = null ,

	@Deleted bit   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [SchoolId]
	, [SchoolName]
	, [CorparationTypeId]
	, [SchoolTypeId]
	, [ProvinceId]
	, [TownId]
	, [Address]
	, [Phone]
	, [Fax]
	, [WebAddress]
	, [Notes]
	, [CreateDate]
	, [UpdateDate]
	, [CreateUserId]
	, [UpdateUserId]
	, [Active]
	, [Deleted]
    FROM
	[dbo].[School]
    WHERE 
	 ([SchoolId] = @SchoolId OR @SchoolId IS NULL)
	AND ([SchoolName] = @SchoolName OR @SchoolName IS NULL)
	AND ([CorparationTypeId] = @CorparationTypeId OR @CorparationTypeId IS NULL)
	AND ([SchoolTypeId] = @SchoolTypeId OR @SchoolTypeId IS NULL)
	AND ([ProvinceId] = @ProvinceId OR @ProvinceId IS NULL)
	AND ([TownId] = @TownId OR @TownId IS NULL)
	AND ([Address] = @Address OR @Address IS NULL)
	AND ([Phone] = @Phone OR @Phone IS NULL)
	AND ([Fax] = @Fax OR @Fax IS NULL)
	AND ([WebAddress] = @WebAddress OR @WebAddress IS NULL)
	AND ([Notes] = @Notes OR @Notes IS NULL)
	AND ([CreateDate] = @CreateDate OR @CreateDate IS NULL)
	AND ([UpdateDate] = @UpdateDate OR @UpdateDate IS NULL)
	AND ([CreateUserId] = @CreateUserId OR @CreateUserId IS NULL)
	AND ([UpdateUserId] = @UpdateUserId OR @UpdateUserId IS NULL)
	AND ([Active] = @Active OR @Active IS NULL)
	AND ([Deleted] = @Deleted OR @Deleted IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [SchoolId]
	, [SchoolName]
	, [CorparationTypeId]
	, [SchoolTypeId]
	, [ProvinceId]
	, [TownId]
	, [Address]
	, [Phone]
	, [Fax]
	, [WebAddress]
	, [Notes]
	, [CreateDate]
	, [UpdateDate]
	, [CreateUserId]
	, [UpdateUserId]
	, [Active]
	, [Deleted]
    FROM
	[dbo].[School]
    WHERE 
	 ([SchoolId] = @SchoolId AND @SchoolId is not null)
	OR ([SchoolName] = @SchoolName AND @SchoolName is not null)
	OR ([CorparationTypeId] = @CorparationTypeId AND @CorparationTypeId is not null)
	OR ([SchoolTypeId] = @SchoolTypeId AND @SchoolTypeId is not null)
	OR ([ProvinceId] = @ProvinceId AND @ProvinceId is not null)
	OR ([TownId] = @TownId AND @TownId is not null)
	OR ([Address] = @Address AND @Address is not null)
	OR ([Phone] = @Phone AND @Phone is not null)
	OR ([Fax] = @Fax AND @Fax is not null)
	OR ([WebAddress] = @WebAddress AND @WebAddress is not null)
	OR ([Notes] = @Notes AND @Notes is not null)
	OR ([CreateDate] = @CreateDate AND @CreateDate is not null)
	OR ([UpdateDate] = @UpdateDate AND @UpdateDate is not null)
	OR ([CreateUserId] = @CreateUserId AND @CreateUserId is not null)
	OR ([UpdateUserId] = @UpdateUserId AND @UpdateUserId is not null)
	OR ([Active] = @Active AND @Active is not null)
	OR ([Deleted] = @Deleted AND @Deleted is not null)
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
-- Date Created: 15 Ocak 2019 Salı

-- Created By:  ()
-- Purpose: Gets all records from the Reason table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Reason_Get_List

AS


				
				SELECT
					[ReasonId],
					[ReasonKey],
					[ReasonValue],
					[CreateDate],
					[UpdateDate],
					[CreateUserId],
					[UpdateUserId],
					[Active],
					[Deleted]
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
-- Date Created: 15 Ocak 2019 Salı

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
				SET @SQL = @SQL + ', [CreateDate]'
				SET @SQL = @SQL + ', [UpdateDate]'
				SET @SQL = @SQL + ', [CreateUserId]'
				SET @SQL = @SQL + ', [UpdateUserId]'
				SET @SQL = @SQL + ', [Active]'
				SET @SQL = @SQL + ', [Deleted]'
				SET @SQL = @SQL + ' FROM [dbo].[Reason]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [ReasonId],'
				SET @SQL = @SQL + ' [ReasonKey],'
				SET @SQL = @SQL + ' [ReasonValue],'
				SET @SQL = @SQL + ' [CreateDate],'
				SET @SQL = @SQL + ' [UpdateDate],'
				SET @SQL = @SQL + ' [CreateUserId],'
				SET @SQL = @SQL + ' [UpdateUserId],'
				SET @SQL = @SQL + ' [Active],'
				SET @SQL = @SQL + ' [Deleted]'
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
-- Date Created: 15 Ocak 2019 Salı

-- Created By:  ()
-- Purpose: Inserts a record into the Reason table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Reason_Insert
(

	@ReasonId int    OUTPUT,

	@ReasonKey int   ,

	@ReasonValue nvarchar (300)  ,

	@CreateDate datetime   ,

	@UpdateDate datetime   ,

	@CreateUserId int   ,

	@UpdateUserId int   ,

	@Active bit   ,

	@Deleted bit   
)
AS


				
				INSERT INTO [dbo].[Reason]
					(
					[ReasonKey]
					,[ReasonValue]
					,[CreateDate]
					,[UpdateDate]
					,[CreateUserId]
					,[UpdateUserId]
					,[Active]
					,[Deleted]
					)
				VALUES
					(
					@ReasonKey
					,@ReasonValue
					,@CreateDate
					,@UpdateDate
					,@CreateUserId
					,@UpdateUserId
					,@Active
					,@Deleted
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
-- Date Created: 15 Ocak 2019 Salı

-- Created By:  ()
-- Purpose: Updates a record in the Reason table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Reason_Update
(

	@ReasonId int   ,

	@ReasonKey int   ,

	@ReasonValue nvarchar (300)  ,

	@CreateDate datetime   ,

	@UpdateDate datetime   ,

	@CreateUserId int   ,

	@UpdateUserId int   ,

	@Active bit   ,

	@Deleted bit   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[Reason]
				SET
					[ReasonKey] = @ReasonKey
					,[ReasonValue] = @ReasonValue
					,[CreateDate] = @CreateDate
					,[UpdateDate] = @UpdateDate
					,[CreateUserId] = @CreateUserId
					,[UpdateUserId] = @UpdateUserId
					,[Active] = @Active
					,[Deleted] = @Deleted
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
-- Date Created: 15 Ocak 2019 Salı

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
-- Date Created: 15 Ocak 2019 Salı

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
					[ReasonValue],
					[CreateDate],
					[UpdateDate],
					[CreateUserId],
					[UpdateUserId],
					[Active],
					[Deleted]
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
-- Date Created: 15 Ocak 2019 Salı

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
					[ReasonValue],
					[CreateDate],
					[UpdateDate],
					[CreateUserId],
					[UpdateUserId],
					[Active],
					[Deleted]
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
-- Date Created: 15 Ocak 2019 Salı

-- Created By:  ()
-- Purpose: Finds records in the Reason table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Reason_Find
(

	@SearchUsingOR bit   = null ,

	@ReasonId int   = null ,

	@ReasonKey int   = null ,

	@ReasonValue nvarchar (300)  = null ,

	@CreateDate datetime   = null ,

	@UpdateDate datetime   = null ,

	@CreateUserId int   = null ,

	@UpdateUserId int   = null ,

	@Active bit   = null ,

	@Deleted bit   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [ReasonId]
	, [ReasonKey]
	, [ReasonValue]
	, [CreateDate]
	, [UpdateDate]
	, [CreateUserId]
	, [UpdateUserId]
	, [Active]
	, [Deleted]
    FROM
	[dbo].[Reason]
    WHERE 
	 ([ReasonId] = @ReasonId OR @ReasonId IS NULL)
	AND ([ReasonKey] = @ReasonKey OR @ReasonKey IS NULL)
	AND ([ReasonValue] = @ReasonValue OR @ReasonValue IS NULL)
	AND ([CreateDate] = @CreateDate OR @CreateDate IS NULL)
	AND ([UpdateDate] = @UpdateDate OR @UpdateDate IS NULL)
	AND ([CreateUserId] = @CreateUserId OR @CreateUserId IS NULL)
	AND ([UpdateUserId] = @UpdateUserId OR @UpdateUserId IS NULL)
	AND ([Active] = @Active OR @Active IS NULL)
	AND ([Deleted] = @Deleted OR @Deleted IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [ReasonId]
	, [ReasonKey]
	, [ReasonValue]
	, [CreateDate]
	, [UpdateDate]
	, [CreateUserId]
	, [UpdateUserId]
	, [Active]
	, [Deleted]
    FROM
	[dbo].[Reason]
    WHERE 
	 ([ReasonId] = @ReasonId AND @ReasonId is not null)
	OR ([ReasonKey] = @ReasonKey AND @ReasonKey is not null)
	OR ([ReasonValue] = @ReasonValue AND @ReasonValue is not null)
	OR ([CreateDate] = @CreateDate AND @CreateDate is not null)
	OR ([UpdateDate] = @UpdateDate AND @UpdateDate is not null)
	OR ([CreateUserId] = @CreateUserId AND @CreateUserId is not null)
	OR ([UpdateUserId] = @UpdateUserId AND @UpdateUserId is not null)
	OR ([Active] = @Active AND @Active is not null)
	OR ([Deleted] = @Deleted AND @Deleted is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_QuestionFormGroup_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_QuestionFormGroup_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_QuestionFormGroup_Get_List
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 15 Ocak 2019 Salı

-- Created By:  ()
-- Purpose: Gets all records from the QuestionFormGroup table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_QuestionFormGroup_Get_List

AS


				
				SELECT
					[GroupId],
					[GroupName],
					[LineNumber],
					[CreateDate],
					[UpdateDate],
					[CreateUserId],
					[UpdateUserId],
					[Active],
					[Deleted]
				FROM
					[dbo].[QuestionFormGroup]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_QuestionFormGroup_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_QuestionFormGroup_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_QuestionFormGroup_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 15 Ocak 2019 Salı

-- Created By:  ()
-- Purpose: Gets records from the QuestionFormGroup table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_QuestionFormGroup_GetPaged
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
					SET @OrderBy = '[GroupId]'
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
				SET @SQL = @SQL + ', [GroupId]'
				SET @SQL = @SQL + ', [GroupName]'
				SET @SQL = @SQL + ', [LineNumber]'
				SET @SQL = @SQL + ', [CreateDate]'
				SET @SQL = @SQL + ', [UpdateDate]'
				SET @SQL = @SQL + ', [CreateUserId]'
				SET @SQL = @SQL + ', [UpdateUserId]'
				SET @SQL = @SQL + ', [Active]'
				SET @SQL = @SQL + ', [Deleted]'
				SET @SQL = @SQL + ' FROM [dbo].[QuestionFormGroup]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [GroupId],'
				SET @SQL = @SQL + ' [GroupName],'
				SET @SQL = @SQL + ' [LineNumber],'
				SET @SQL = @SQL + ' [CreateDate],'
				SET @SQL = @SQL + ' [UpdateDate],'
				SET @SQL = @SQL + ' [CreateUserId],'
				SET @SQL = @SQL + ' [UpdateUserId],'
				SET @SQL = @SQL + ' [Active],'
				SET @SQL = @SQL + ' [Deleted]'
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
				SET @SQL = @SQL + ' FROM [dbo].[QuestionFormGroup]'
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

	

-- Drop the dbo.sp_QuestionFormGroup_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_QuestionFormGroup_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_QuestionFormGroup_Insert
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 15 Ocak 2019 Salı

-- Created By:  ()
-- Purpose: Inserts a record into the QuestionFormGroup table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_QuestionFormGroup_Insert
(

	@GroupId int    OUTPUT,

	@GroupName varchar (250)  ,

	@LineNumber int   ,

	@CreateDate datetime   ,

	@UpdateDate datetime   ,

	@CreateUserId int   ,

	@UpdateUserId int   ,

	@Active bit   ,

	@Deleted bit   
)
AS


				
				INSERT INTO [dbo].[QuestionFormGroup]
					(
					[GroupName]
					,[LineNumber]
					,[CreateDate]
					,[UpdateDate]
					,[CreateUserId]
					,[UpdateUserId]
					,[Active]
					,[Deleted]
					)
				VALUES
					(
					@GroupName
					,@LineNumber
					,@CreateDate
					,@UpdateDate
					,@CreateUserId
					,@UpdateUserId
					,@Active
					,@Deleted
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

	

-- Drop the dbo.sp_QuestionFormGroup_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_QuestionFormGroup_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_QuestionFormGroup_Update
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 15 Ocak 2019 Salı

-- Created By:  ()
-- Purpose: Updates a record in the QuestionFormGroup table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_QuestionFormGroup_Update
(

	@GroupId int   ,

	@GroupName varchar (250)  ,

	@LineNumber int   ,

	@CreateDate datetime   ,

	@UpdateDate datetime   ,

	@CreateUserId int   ,

	@UpdateUserId int   ,

	@Active bit   ,

	@Deleted bit   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[QuestionFormGroup]
				SET
					[GroupName] = @GroupName
					,[LineNumber] = @LineNumber
					,[CreateDate] = @CreateDate
					,[UpdateDate] = @UpdateDate
					,[CreateUserId] = @CreateUserId
					,[UpdateUserId] = @UpdateUserId
					,[Active] = @Active
					,[Deleted] = @Deleted
				WHERE
[GroupId] = @GroupId 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_QuestionFormGroup_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_QuestionFormGroup_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_QuestionFormGroup_Delete
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 15 Ocak 2019 Salı

-- Created By:  ()
-- Purpose: Deletes a record in the QuestionFormGroup table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_QuestionFormGroup_Delete
(

	@GroupId int   
)
AS


				DELETE FROM [dbo].[QuestionFormGroup] WITH (ROWLOCK) 
				WHERE
					[GroupId] = @GroupId
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_QuestionFormGroup_GetByGroupId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_QuestionFormGroup_GetByGroupId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_QuestionFormGroup_GetByGroupId
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 15 Ocak 2019 Salı

-- Created By:  ()
-- Purpose: Select records from the QuestionFormGroup table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_QuestionFormGroup_GetByGroupId
(

	@GroupId int   
)
AS


				SELECT
					[GroupId],
					[GroupName],
					[LineNumber],
					[CreateDate],
					[UpdateDate],
					[CreateUserId],
					[UpdateUserId],
					[Active],
					[Deleted]
				FROM
					[dbo].[QuestionFormGroup]
				WHERE
					[GroupId] = @GroupId
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_QuestionFormGroup_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_QuestionFormGroup_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_QuestionFormGroup_Find
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 15 Ocak 2019 Salı

-- Created By:  ()
-- Purpose: Finds records in the QuestionFormGroup table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_QuestionFormGroup_Find
(

	@SearchUsingOR bit   = null ,

	@GroupId int   = null ,

	@GroupName varchar (250)  = null ,

	@LineNumber int   = null ,

	@CreateDate datetime   = null ,

	@UpdateDate datetime   = null ,

	@CreateUserId int   = null ,

	@UpdateUserId int   = null ,

	@Active bit   = null ,

	@Deleted bit   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [GroupId]
	, [GroupName]
	, [LineNumber]
	, [CreateDate]
	, [UpdateDate]
	, [CreateUserId]
	, [UpdateUserId]
	, [Active]
	, [Deleted]
    FROM
	[dbo].[QuestionFormGroup]
    WHERE 
	 ([GroupId] = @GroupId OR @GroupId IS NULL)
	AND ([GroupName] = @GroupName OR @GroupName IS NULL)
	AND ([LineNumber] = @LineNumber OR @LineNumber IS NULL)
	AND ([CreateDate] = @CreateDate OR @CreateDate IS NULL)
	AND ([UpdateDate] = @UpdateDate OR @UpdateDate IS NULL)
	AND ([CreateUserId] = @CreateUserId OR @CreateUserId IS NULL)
	AND ([UpdateUserId] = @UpdateUserId OR @UpdateUserId IS NULL)
	AND ([Active] = @Active OR @Active IS NULL)
	AND ([Deleted] = @Deleted OR @Deleted IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [GroupId]
	, [GroupName]
	, [LineNumber]
	, [CreateDate]
	, [UpdateDate]
	, [CreateUserId]
	, [UpdateUserId]
	, [Active]
	, [Deleted]
    FROM
	[dbo].[QuestionFormGroup]
    WHERE 
	 ([GroupId] = @GroupId AND @GroupId is not null)
	OR ([GroupName] = @GroupName AND @GroupName is not null)
	OR ([LineNumber] = @LineNumber AND @LineNumber is not null)
	OR ([CreateDate] = @CreateDate AND @CreateDate is not null)
	OR ([UpdateDate] = @UpdateDate AND @UpdateDate is not null)
	OR ([CreateUserId] = @CreateUserId AND @CreateUserId is not null)
	OR ([UpdateUserId] = @UpdateUserId AND @UpdateUserId is not null)
	OR ([Active] = @Active AND @Active is not null)
	OR ([Deleted] = @Deleted AND @Deleted is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_SeanceQuestionOption_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_SeanceQuestionOption_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_SeanceQuestionOption_Get_List
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 15 Ocak 2019 Salı

-- Created By:  ()
-- Purpose: Gets all records from the SeanceQuestionOption table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_SeanceQuestionOption_Get_List

AS


				
				SELECT
					[OptionId],
					[QuestionId],
					[OptionName]
				FROM
					[dbo].[SeanceQuestionOption]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_SeanceQuestionOption_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_SeanceQuestionOption_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_SeanceQuestionOption_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 15 Ocak 2019 Salı

-- Created By:  ()
-- Purpose: Gets records from the SeanceQuestionOption table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_SeanceQuestionOption_GetPaged
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
				SET @SQL = @SQL + ' FROM [dbo].[SeanceQuestionOption]'
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
				SET @SQL = @SQL + ' FROM [dbo].[SeanceQuestionOption]'
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

	

-- Drop the dbo.sp_SeanceQuestionOption_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_SeanceQuestionOption_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_SeanceQuestionOption_Insert
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 15 Ocak 2019 Salı

-- Created By:  ()
-- Purpose: Inserts a record into the SeanceQuestionOption table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_SeanceQuestionOption_Insert
(

	@OptionId int    OUTPUT,

	@QuestionId int   ,

	@OptionName varchar (300)  
)
AS


				
				INSERT INTO [dbo].[SeanceQuestionOption]
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

	

-- Drop the dbo.sp_SeanceQuestionOption_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_SeanceQuestionOption_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_SeanceQuestionOption_Update
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 15 Ocak 2019 Salı

-- Created By:  ()
-- Purpose: Updates a record in the SeanceQuestionOption table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_SeanceQuestionOption_Update
(

	@OptionId int   ,

	@QuestionId int   ,

	@OptionName varchar (300)  
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[SeanceQuestionOption]
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

	

-- Drop the dbo.sp_SeanceQuestionOption_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_SeanceQuestionOption_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_SeanceQuestionOption_Delete
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 15 Ocak 2019 Salı

-- Created By:  ()
-- Purpose: Deletes a record in the SeanceQuestionOption table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_SeanceQuestionOption_Delete
(

	@OptionId int   
)
AS


				DELETE FROM [dbo].[SeanceQuestionOption] WITH (ROWLOCK) 
				WHERE
					[OptionId] = @OptionId
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_SeanceQuestionOption_GetByQuestionId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_SeanceQuestionOption_GetByQuestionId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_SeanceQuestionOption_GetByQuestionId
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 15 Ocak 2019 Salı

-- Created By:  ()
-- Purpose: Select records from the SeanceQuestionOption table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_SeanceQuestionOption_GetByQuestionId
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
					[dbo].[SeanceQuestionOption]
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

	

-- Drop the dbo.sp_SeanceQuestionOption_GetByOptionId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_SeanceQuestionOption_GetByOptionId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_SeanceQuestionOption_GetByOptionId
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 15 Ocak 2019 Salı

-- Created By:  ()
-- Purpose: Select records from the SeanceQuestionOption table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_SeanceQuestionOption_GetByOptionId
(

	@OptionId int   
)
AS


				SELECT
					[OptionId],
					[QuestionId],
					[OptionName]
				FROM
					[dbo].[SeanceQuestionOption]
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

	

-- Drop the dbo.sp_SeanceQuestionOption_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_SeanceQuestionOption_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_SeanceQuestionOption_Find
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 15 Ocak 2019 Salı

-- Created By:  ()
-- Purpose: Finds records in the SeanceQuestionOption table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_SeanceQuestionOption_Find
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
	[dbo].[SeanceQuestionOption]
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
	[dbo].[SeanceQuestionOption]
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
-- Date Created: 15 Ocak 2019 Salı

-- Created By:  ()
-- Purpose: Gets all records from the Town table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Town_Get_List

AS


				
				SELECT
					[TownId],
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
					[UpdateTime],
					[CreateUserId],
					[UpdateUserId],
					[Active],
					[Deleted]
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
-- Date Created: 15 Ocak 2019 Salı

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
					SET @OrderBy = '[TownId]'
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
				SET @SQL = @SQL + ', [TownId]'
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
				SET @SQL = @SQL + ', [CreateUserId]'
				SET @SQL = @SQL + ', [UpdateUserId]'
				SET @SQL = @SQL + ', [Active]'
				SET @SQL = @SQL + ', [Deleted]'
				SET @SQL = @SQL + ' FROM [dbo].[Town]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [TownId],'
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
				SET @SQL = @SQL + ' [UpdateTime],'
				SET @SQL = @SQL + ' [CreateUserId],'
				SET @SQL = @SQL + ' [UpdateUserId],'
				SET @SQL = @SQL + ' [Active],'
				SET @SQL = @SQL + ' [Deleted]'
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
-- Date Created: 15 Ocak 2019 Salı

-- Created By:  ()
-- Purpose: Inserts a record into the Town table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Town_Insert
(

	@TownId int    OUTPUT,

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

	@UpdateTime time   ,

	@CreateUserId int   ,

	@UpdateUserId int   ,

	@Active bit   ,

	@Deleted bit   
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
					,[CreateUserId]
					,[UpdateUserId]
					,[Active]
					,[Deleted]
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
					,@CreateUserId
					,@UpdateUserId
					,@Active
					,@Deleted
					)
				-- Get the identity value
				SET @TownId = SCOPE_IDENTITY()
									
							
			

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
-- Date Created: 15 Ocak 2019 Salı

-- Created By:  ()
-- Purpose: Updates a record in the Town table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Town_Update
(

	@TownId int   ,

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

	@UpdateTime time   ,

	@CreateUserId int   ,

	@UpdateUserId int   ,

	@Active bit   ,

	@Deleted bit   
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
					,[CreateUserId] = @CreateUserId
					,[UpdateUserId] = @UpdateUserId
					,[Active] = @Active
					,[Deleted] = @Deleted
				WHERE
[TownId] = @TownId 
				
			

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
-- Date Created: 15 Ocak 2019 Salı

-- Created By:  ()
-- Purpose: Deletes a record in the Town table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Town_Delete
(

	@TownId int   
)
AS


				DELETE FROM [dbo].[Town] WITH (ROWLOCK) 
				WHERE
					[TownId] = @TownId
					
			

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
-- Date Created: 15 Ocak 2019 Salı

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
					[TownId],
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
					[UpdateTime],
					[CreateUserId],
					[UpdateUserId],
					[Active],
					[Deleted]
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

	

-- Drop the dbo.sp_Town_GetByTownId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_Town_GetByTownId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_Town_GetByTownId
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 15 Ocak 2019 Salı

-- Created By:  ()
-- Purpose: Select records from the Town table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Town_GetByTownId
(

	@TownId int   
)
AS


				SELECT
					[TownId],
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
					[UpdateTime],
					[CreateUserId],
					[UpdateUserId],
					[Active],
					[Deleted]
				FROM
					[dbo].[Town]
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

	

-- Drop the dbo.sp_Town_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_Town_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_Town_Find
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 15 Ocak 2019 Salı

-- Created By:  ()
-- Purpose: Finds records in the Town table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Town_Find
(

	@SearchUsingOR bit   = null ,

	@TownId int   = null ,

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

	@UpdateTime time   = null ,

	@CreateUserId int   = null ,

	@UpdateUserId int   = null ,

	@Active bit   = null ,

	@Deleted bit   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [TownId]
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
	, [CreateUserId]
	, [UpdateUserId]
	, [Active]
	, [Deleted]
    FROM
	[dbo].[Town]
    WHERE 
	 ([TownId] = @TownId OR @TownId IS NULL)
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
	AND ([CreateUserId] = @CreateUserId OR @CreateUserId IS NULL)
	AND ([UpdateUserId] = @UpdateUserId OR @UpdateUserId IS NULL)
	AND ([Active] = @Active OR @Active IS NULL)
	AND ([Deleted] = @Deleted OR @Deleted IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [TownId]
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
	, [CreateUserId]
	, [UpdateUserId]
	, [Active]
	, [Deleted]
    FROM
	[dbo].[Town]
    WHERE 
	 ([TownId] = @TownId AND @TownId is not null)
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
	OR ([CreateUserId] = @CreateUserId AND @CreateUserId is not null)
	OR ([UpdateUserId] = @UpdateUserId AND @UpdateUserId is not null)
	OR ([Active] = @Active AND @Active is not null)
	OR ([Deleted] = @Deleted AND @Deleted is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_SeanceReason_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_SeanceReason_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_SeanceReason_Get_List
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 15 Ocak 2019 Salı

-- Created By:  ()
-- Purpose: Gets all records from the SeanceReason table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_SeanceReason_Get_List

AS


				
				SELECT
					[RowId],
					[SeanceId],
					[ReasonId]
				FROM
					[dbo].[SeanceReason]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_SeanceReason_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_SeanceReason_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_SeanceReason_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 15 Ocak 2019 Salı

-- Created By:  ()
-- Purpose: Gets records from the SeanceReason table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_SeanceReason_GetPaged
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
				SET @SQL = @SQL + ' FROM [dbo].[SeanceReason]'
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
				SET @SQL = @SQL + ' FROM [dbo].[SeanceReason]'
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

	

-- Drop the dbo.sp_SeanceReason_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_SeanceReason_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_SeanceReason_Insert
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 15 Ocak 2019 Salı

-- Created By:  ()
-- Purpose: Inserts a record into the SeanceReason table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_SeanceReason_Insert
(

	@RowId int    OUTPUT,

	@SeanceId int   ,

	@ReasonId int   
)
AS


				
				INSERT INTO [dbo].[SeanceReason]
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

	

-- Drop the dbo.sp_SeanceReason_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_SeanceReason_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_SeanceReason_Update
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 15 Ocak 2019 Salı

-- Created By:  ()
-- Purpose: Updates a record in the SeanceReason table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_SeanceReason_Update
(

	@RowId int   ,

	@SeanceId int   ,

	@ReasonId int   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[SeanceReason]
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

	

-- Drop the dbo.sp_SeanceReason_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_SeanceReason_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_SeanceReason_Delete
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 15 Ocak 2019 Salı

-- Created By:  ()
-- Purpose: Deletes a record in the SeanceReason table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_SeanceReason_Delete
(

	@RowId int   
)
AS


				DELETE FROM [dbo].[SeanceReason] WITH (ROWLOCK) 
				WHERE
					[RowId] = @RowId
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_SeanceReason_GetByReasonId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_SeanceReason_GetByReasonId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_SeanceReason_GetByReasonId
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 15 Ocak 2019 Salı

-- Created By:  ()
-- Purpose: Select records from the SeanceReason table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_SeanceReason_GetByReasonId
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
					[dbo].[SeanceReason]
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

	

-- Drop the dbo.sp_SeanceReason_GetBySeanceId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_SeanceReason_GetBySeanceId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_SeanceReason_GetBySeanceId
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 15 Ocak 2019 Salı

-- Created By:  ()
-- Purpose: Select records from the SeanceReason table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_SeanceReason_GetBySeanceId
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
					[dbo].[SeanceReason]
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

	

-- Drop the dbo.sp_SeanceReason_GetByRowId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_SeanceReason_GetByRowId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_SeanceReason_GetByRowId
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 15 Ocak 2019 Salı

-- Created By:  ()
-- Purpose: Select records from the SeanceReason table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_SeanceReason_GetByRowId
(

	@RowId int   
)
AS


				SELECT
					[RowId],
					[SeanceId],
					[ReasonId]
				FROM
					[dbo].[SeanceReason]
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

	

-- Drop the dbo.sp_SeanceReason_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_SeanceReason_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_SeanceReason_Find
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 15 Ocak 2019 Salı

-- Created By:  ()
-- Purpose: Finds records in the SeanceReason table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_SeanceReason_Find
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
	[dbo].[SeanceReason]
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
	[dbo].[SeanceReason]
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

	

-- Drop the dbo.sp_Teacher_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_Teacher_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_Teacher_Get_List
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 15 Ocak 2019 Salı

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
					[CreateDate],
					[UpdateDate],
					[CreateUserId],
					[UpdateUserId],
					[Active],
					[Deleted]
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
-- Date Created: 15 Ocak 2019 Salı

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
				SET @SQL = @SQL + ', [CreateDate]'
				SET @SQL = @SQL + ', [UpdateDate]'
				SET @SQL = @SQL + ', [CreateUserId]'
				SET @SQL = @SQL + ', [UpdateUserId]'
				SET @SQL = @SQL + ', [Active]'
				SET @SQL = @SQL + ', [Deleted]'
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
				SET @SQL = @SQL + ' [CreateDate],'
				SET @SQL = @SQL + ' [UpdateDate],'
				SET @SQL = @SQL + ' [CreateUserId],'
				SET @SQL = @SQL + ' [UpdateUserId],'
				SET @SQL = @SQL + ' [Active],'
				SET @SQL = @SQL + ' [Deleted]'
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
-- Date Created: 15 Ocak 2019 Salı

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

	@CreateDate datetime   ,

	@UpdateDate datetime   ,

	@CreateUserId int   ,

	@UpdateUserId int   ,

	@Active bit   ,

	@Deleted bit   
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
					,[CreateDate]
					,[UpdateDate]
					,[CreateUserId]
					,[UpdateUserId]
					,[Active]
					,[Deleted]
					)
				VALUES
					(
					@SchoolId
					,@FirstName
					,@LastName
					,@Phone
					,@Gsm
					,@Email
					,@CreateDate
					,@UpdateDate
					,@CreateUserId
					,@UpdateUserId
					,@Active
					,@Deleted
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
-- Date Created: 15 Ocak 2019 Salı

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

	@CreateDate datetime   ,

	@UpdateDate datetime   ,

	@CreateUserId int   ,

	@UpdateUserId int   ,

	@Active bit   ,

	@Deleted bit   
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
					,[CreateDate] = @CreateDate
					,[UpdateDate] = @UpdateDate
					,[CreateUserId] = @CreateUserId
					,[UpdateUserId] = @UpdateUserId
					,[Active] = @Active
					,[Deleted] = @Deleted
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
-- Date Created: 15 Ocak 2019 Salı

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
-- Date Created: 15 Ocak 2019 Salı

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
					[CreateDate],
					[UpdateDate],
					[CreateUserId],
					[UpdateUserId],
					[Active],
					[Deleted]
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
-- Date Created: 15 Ocak 2019 Salı

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
					[CreateDate],
					[UpdateDate],
					[CreateUserId],
					[UpdateUserId],
					[Active],
					[Deleted]
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
-- Date Created: 15 Ocak 2019 Salı

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

	@CreateDate datetime   = null ,

	@UpdateDate datetime   = null ,

	@CreateUserId int   = null ,

	@UpdateUserId int   = null ,

	@Active bit   = null ,

	@Deleted bit   = null 
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
	, [CreateDate]
	, [UpdateDate]
	, [CreateUserId]
	, [UpdateUserId]
	, [Active]
	, [Deleted]
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
	AND ([CreateDate] = @CreateDate OR @CreateDate IS NULL)
	AND ([UpdateDate] = @UpdateDate OR @UpdateDate IS NULL)
	AND ([CreateUserId] = @CreateUserId OR @CreateUserId IS NULL)
	AND ([UpdateUserId] = @UpdateUserId OR @UpdateUserId IS NULL)
	AND ([Active] = @Active OR @Active IS NULL)
	AND ([Deleted] = @Deleted OR @Deleted IS NULL)
						
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
	, [CreateDate]
	, [UpdateDate]
	, [CreateUserId]
	, [UpdateUserId]
	, [Active]
	, [Deleted]
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
	OR ([CreateDate] = @CreateDate AND @CreateDate is not null)
	OR ([UpdateDate] = @UpdateDate AND @UpdateDate is not null)
	OR ([CreateUserId] = @CreateUserId AND @CreateUserId is not null)
	OR ([UpdateUserId] = @UpdateUserId AND @UpdateUserId is not null)
	OR ([Active] = @Active AND @Active is not null)
	OR ([Deleted] = @Deleted AND @Deleted is not null)
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
-- Date Created: 15 Ocak 2019 Salı

-- Created By:  ()
-- Purpose: Gets all records from the Wippsi table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Wippsi_Get_List

AS


				
				SELECT
					[WippsiId],
					[SeanceId],
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
					[Notes],
					[TestDate],
					[CreateDate],
					[UpdateDate],
					[CreateUserId],
					[UpdateUserId],
					[Active],
					[Deleted]
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
-- Date Created: 15 Ocak 2019 Salı

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
					SET @OrderBy = '[WippsiId]'
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
				SET @SQL = @SQL + ', [WippsiId]'
				SET @SQL = @SQL + ', [SeanceId]'
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
				SET @SQL = @SQL + ', [Notes]'
				SET @SQL = @SQL + ', [TestDate]'
				SET @SQL = @SQL + ', [CreateDate]'
				SET @SQL = @SQL + ', [UpdateDate]'
				SET @SQL = @SQL + ', [CreateUserId]'
				SET @SQL = @SQL + ', [UpdateUserId]'
				SET @SQL = @SQL + ', [Active]'
				SET @SQL = @SQL + ', [Deleted]'
				SET @SQL = @SQL + ' FROM [dbo].[Wippsi]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [WippsiId],'
				SET @SQL = @SQL + ' [SeanceId],'
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
				SET @SQL = @SQL + ' [Notes],'
				SET @SQL = @SQL + ' [TestDate],'
				SET @SQL = @SQL + ' [CreateDate],'
				SET @SQL = @SQL + ' [UpdateDate],'
				SET @SQL = @SQL + ' [CreateUserId],'
				SET @SQL = @SQL + ' [UpdateUserId],'
				SET @SQL = @SQL + ' [Active],'
				SET @SQL = @SQL + ' [Deleted]'
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
-- Date Created: 15 Ocak 2019 Salı

-- Created By:  ()
-- Purpose: Inserts a record into the Wippsi table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Wippsi_Insert
(

	@WippsiId int    OUTPUT,

	@SeanceId int   ,

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

	@Notes nvarchar (MAX)  ,

	@TestDate datetime   ,

	@CreateDate datetime   ,

	@UpdateDate datetime   ,

	@CreateUserId int   ,

	@UpdateUserId int   ,

	@Active bit   ,

	@Deleted bit   
)
AS


				
				INSERT INTO [dbo].[Wippsi]
					(
					[SeanceId]
					,[GeneralRawScore]
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
					,[Notes]
					,[TestDate]
					,[CreateDate]
					,[UpdateDate]
					,[CreateUserId]
					,[UpdateUserId]
					,[Active]
					,[Deleted]
					)
				VALUES
					(
					@SeanceId
					,@GeneralRawScore
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
					,@Notes
					,@TestDate
					,@CreateDate
					,@UpdateDate
					,@CreateUserId
					,@UpdateUserId
					,@Active
					,@Deleted
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
-- Date Created: 15 Ocak 2019 Salı

-- Created By:  ()
-- Purpose: Updates a record in the Wippsi table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Wippsi_Update
(

	@WippsiId int   ,

	@SeanceId int   ,

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

	@Notes nvarchar (MAX)  ,

	@TestDate datetime   ,

	@CreateDate datetime   ,

	@UpdateDate datetime   ,

	@CreateUserId int   ,

	@UpdateUserId int   ,

	@Active bit   ,

	@Deleted bit   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[Wippsi]
				SET
					[SeanceId] = @SeanceId
					,[GeneralRawScore] = @GeneralRawScore
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
					,[Notes] = @Notes
					,[TestDate] = @TestDate
					,[CreateDate] = @CreateDate
					,[UpdateDate] = @UpdateDate
					,[CreateUserId] = @CreateUserId
					,[UpdateUserId] = @UpdateUserId
					,[Active] = @Active
					,[Deleted] = @Deleted
				WHERE
[WippsiId] = @WippsiId 
				
			

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
-- Date Created: 15 Ocak 2019 Salı

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
					[WippsiId] = @WippsiId
					
			

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
-- Date Created: 15 Ocak 2019 Salı

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
					[WippsiId],
					[SeanceId],
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
					[Notes],
					[TestDate],
					[CreateDate],
					[UpdateDate],
					[CreateUserId],
					[UpdateUserId],
					[Active],
					[Deleted]
				FROM
					[dbo].[Wippsi]
				WHERE
					[WippsiId] = @WippsiId
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
-- Date Created: 15 Ocak 2019 Salı

-- Created By:  ()
-- Purpose: Finds records in the Wippsi table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Wippsi_Find
(

	@SearchUsingOR bit   = null ,

	@WippsiId int   = null ,

	@SeanceId int   = null ,

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

	@Notes nvarchar (MAX)  = null ,

	@TestDate datetime   = null ,

	@CreateDate datetime   = null ,

	@UpdateDate datetime   = null ,

	@CreateUserId int   = null ,

	@UpdateUserId int   = null ,

	@Active bit   = null ,

	@Deleted bit   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [WippsiId]
	, [SeanceId]
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
	, [Notes]
	, [TestDate]
	, [CreateDate]
	, [UpdateDate]
	, [CreateUserId]
	, [UpdateUserId]
	, [Active]
	, [Deleted]
    FROM
	[dbo].[Wippsi]
    WHERE 
	 ([WippsiId] = @WippsiId OR @WippsiId IS NULL)
	AND ([SeanceId] = @SeanceId OR @SeanceId IS NULL)
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
	AND ([Notes] = @Notes OR @Notes IS NULL)
	AND ([TestDate] = @TestDate OR @TestDate IS NULL)
	AND ([CreateDate] = @CreateDate OR @CreateDate IS NULL)
	AND ([UpdateDate] = @UpdateDate OR @UpdateDate IS NULL)
	AND ([CreateUserId] = @CreateUserId OR @CreateUserId IS NULL)
	AND ([UpdateUserId] = @UpdateUserId OR @UpdateUserId IS NULL)
	AND ([Active] = @Active OR @Active IS NULL)
	AND ([Deleted] = @Deleted OR @Deleted IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [WippsiId]
	, [SeanceId]
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
	, [Notes]
	, [TestDate]
	, [CreateDate]
	, [UpdateDate]
	, [CreateUserId]
	, [UpdateUserId]
	, [Active]
	, [Deleted]
    FROM
	[dbo].[Wippsi]
    WHERE 
	 ([WippsiId] = @WippsiId AND @WippsiId is not null)
	OR ([SeanceId] = @SeanceId AND @SeanceId is not null)
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
	OR ([Notes] = @Notes AND @Notes is not null)
	OR ([TestDate] = @TestDate AND @TestDate is not null)
	OR ([CreateDate] = @CreateDate AND @CreateDate is not null)
	OR ([UpdateDate] = @UpdateDate AND @UpdateDate is not null)
	OR ([CreateUserId] = @CreateUserId AND @CreateUserId is not null)
	OR ([UpdateUserId] = @UpdateUserId AND @UpdateUserId is not null)
	OR ([Active] = @Active AND @Active is not null)
	OR ([Deleted] = @Deleted AND @Deleted is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_SeanceQuestionAnswer_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_SeanceQuestionAnswer_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_SeanceQuestionAnswer_Get_List
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 15 Ocak 2019 Salı

-- Created By:  ()
-- Purpose: Gets all records from the SeanceQuestionAnswer table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_SeanceQuestionAnswer_Get_List

AS


				
				SELECT
					[RowId],
					[ClientId],
					[QuestionId],
					[OptionId],
					[CreateOn],
					[UpdateOn]
				FROM
					[dbo].[SeanceQuestionAnswer]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_SeanceQuestionAnswer_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_SeanceQuestionAnswer_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_SeanceQuestionAnswer_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 15 Ocak 2019 Salı

-- Created By:  ()
-- Purpose: Gets records from the SeanceQuestionAnswer table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_SeanceQuestionAnswer_GetPaged
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
				SET @SQL = @SQL + ' FROM [dbo].[SeanceQuestionAnswer]'
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
				SET @SQL = @SQL + ' FROM [dbo].[SeanceQuestionAnswer]'
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

	

-- Drop the dbo.sp_SeanceQuestionAnswer_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_SeanceQuestionAnswer_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_SeanceQuestionAnswer_Insert
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 15 Ocak 2019 Salı

-- Created By:  ()
-- Purpose: Inserts a record into the SeanceQuestionAnswer table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_SeanceQuestionAnswer_Insert
(

	@RowId int    OUTPUT,

	@ClientId int   ,

	@QuestionId int   ,

	@OptionId int   ,

	@CreateOn smalldatetime   ,

	@UpdateOn smalldatetime   
)
AS


				
				INSERT INTO [dbo].[SeanceQuestionAnswer]
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

	

-- Drop the dbo.sp_SeanceQuestionAnswer_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_SeanceQuestionAnswer_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_SeanceQuestionAnswer_Update
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 15 Ocak 2019 Salı

-- Created By:  ()
-- Purpose: Updates a record in the SeanceQuestionAnswer table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_SeanceQuestionAnswer_Update
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
					[dbo].[SeanceQuestionAnswer]
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

	

-- Drop the dbo.sp_SeanceQuestionAnswer_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_SeanceQuestionAnswer_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_SeanceQuestionAnswer_Delete
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 15 Ocak 2019 Salı

-- Created By:  ()
-- Purpose: Deletes a record in the SeanceQuestionAnswer table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_SeanceQuestionAnswer_Delete
(

	@RowId int   
)
AS


				DELETE FROM [dbo].[SeanceQuestionAnswer] WITH (ROWLOCK) 
				WHERE
					[RowId] = @RowId
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_SeanceQuestionAnswer_GetByClientId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_SeanceQuestionAnswer_GetByClientId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_SeanceQuestionAnswer_GetByClientId
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 15 Ocak 2019 Salı

-- Created By:  ()
-- Purpose: Select records from the SeanceQuestionAnswer table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_SeanceQuestionAnswer_GetByClientId
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
					[dbo].[SeanceQuestionAnswer]
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

	

-- Drop the dbo.sp_SeanceQuestionAnswer_GetByQuestionId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_SeanceQuestionAnswer_GetByQuestionId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_SeanceQuestionAnswer_GetByQuestionId
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 15 Ocak 2019 Salı

-- Created By:  ()
-- Purpose: Select records from the SeanceQuestionAnswer table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_SeanceQuestionAnswer_GetByQuestionId
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
					[dbo].[SeanceQuestionAnswer]
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

	

-- Drop the dbo.sp_SeanceQuestionAnswer_GetByOptionId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_SeanceQuestionAnswer_GetByOptionId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_SeanceQuestionAnswer_GetByOptionId
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 15 Ocak 2019 Salı

-- Created By:  ()
-- Purpose: Select records from the SeanceQuestionAnswer table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_SeanceQuestionAnswer_GetByOptionId
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
					[dbo].[SeanceQuestionAnswer]
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

	

-- Drop the dbo.sp_SeanceQuestionAnswer_GetByRowId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_SeanceQuestionAnswer_GetByRowId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_SeanceQuestionAnswer_GetByRowId
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 15 Ocak 2019 Salı

-- Created By:  ()
-- Purpose: Select records from the SeanceQuestionAnswer table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_SeanceQuestionAnswer_GetByRowId
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
					[dbo].[SeanceQuestionAnswer]
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

	

-- Drop the dbo.sp_SeanceQuestionAnswer_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_SeanceQuestionAnswer_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_SeanceQuestionAnswer_Find
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 15 Ocak 2019 Salı

-- Created By:  ()
-- Purpose: Finds records in the SeanceQuestionAnswer table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_SeanceQuestionAnswer_Find
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
	[dbo].[SeanceQuestionAnswer]
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
	[dbo].[SeanceQuestionAnswer]
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

	

-- Drop the dbo.sp_Street_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_Street_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_Street_Get_List
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 15 Ocak 2019 Salı

-- Created By:  ()
-- Purpose: Gets all records from the Street table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Street_Get_List

AS


				
				SELECT
					[StreetId],
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
					[UpdateTime],
					[CreateUserId],
					[UpdateUserId],
					[Active],
					[Deleted]
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
-- Date Created: 15 Ocak 2019 Salı

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
					SET @OrderBy = '[StreetId]'
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
				SET @SQL = @SQL + ', [StreetId]'
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
				SET @SQL = @SQL + ', [CreateUserId]'
				SET @SQL = @SQL + ', [UpdateUserId]'
				SET @SQL = @SQL + ', [Active]'
				SET @SQL = @SQL + ', [Deleted]'
				SET @SQL = @SQL + ' FROM [dbo].[Street]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [StreetId],'
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
				SET @SQL = @SQL + ' [UpdateTime],'
				SET @SQL = @SQL + ' [CreateUserId],'
				SET @SQL = @SQL + ' [UpdateUserId],'
				SET @SQL = @SQL + ' [Active],'
				SET @SQL = @SQL + ' [Deleted]'
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
-- Date Created: 15 Ocak 2019 Salı

-- Created By:  ()
-- Purpose: Inserts a record into the Street table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Street_Insert
(

	@StreetId int    OUTPUT,

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

	@UpdateTime time   ,

	@CreateUserId int   ,

	@UpdateUserId int   ,

	@Active bit   ,

	@Deleted bit   
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
					,[CreateUserId]
					,[UpdateUserId]
					,[Active]
					,[Deleted]
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
					,@CreateUserId
					,@UpdateUserId
					,@Active
					,@Deleted
					)
				-- Get the identity value
				SET @StreetId = SCOPE_IDENTITY()
									
							
			

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
-- Date Created: 15 Ocak 2019 Salı

-- Created By:  ()
-- Purpose: Updates a record in the Street table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Street_Update
(

	@StreetId int   ,

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

	@UpdateTime time   ,

	@CreateUserId int   ,

	@UpdateUserId int   ,

	@Active bit   ,

	@Deleted bit   
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
					,[CreateUserId] = @CreateUserId
					,[UpdateUserId] = @UpdateUserId
					,[Active] = @Active
					,[Deleted] = @Deleted
				WHERE
[StreetId] = @StreetId 
				
			

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
-- Date Created: 15 Ocak 2019 Salı

-- Created By:  ()
-- Purpose: Deletes a record in the Street table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Street_Delete
(

	@StreetId int   
)
AS


				DELETE FROM [dbo].[Street] WITH (ROWLOCK) 
				WHERE
					[StreetId] = @StreetId
					
			

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
-- Date Created: 15 Ocak 2019 Salı

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
					[StreetId],
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
					[UpdateTime],
					[CreateUserId],
					[UpdateUserId],
					[Active],
					[Deleted]
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

	

-- Drop the dbo.sp_Street_GetByStreetId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_Street_GetByStreetId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_Street_GetByStreetId
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 15 Ocak 2019 Salı

-- Created By:  ()
-- Purpose: Select records from the Street table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Street_GetByStreetId
(

	@StreetId int   
)
AS


				SELECT
					[StreetId],
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
					[UpdateTime],
					[CreateUserId],
					[UpdateUserId],
					[Active],
					[Deleted]
				FROM
					[dbo].[Street]
				WHERE
					[StreetId] = @StreetId
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
-- Date Created: 15 Ocak 2019 Salı

-- Created By:  ()
-- Purpose: Finds records in the Street table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Street_Find
(

	@SearchUsingOR bit   = null ,

	@StreetId int   = null ,

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

	@UpdateTime time   = null ,

	@CreateUserId int   = null ,

	@UpdateUserId int   = null ,

	@Active bit   = null ,

	@Deleted bit   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [StreetId]
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
	, [CreateUserId]
	, [UpdateUserId]
	, [Active]
	, [Deleted]
    FROM
	[dbo].[Street]
    WHERE 
	 ([StreetId] = @StreetId OR @StreetId IS NULL)
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
	AND ([CreateUserId] = @CreateUserId OR @CreateUserId IS NULL)
	AND ([UpdateUserId] = @UpdateUserId OR @UpdateUserId IS NULL)
	AND ([Active] = @Active OR @Active IS NULL)
	AND ([Deleted] = @Deleted OR @Deleted IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [StreetId]
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
	, [CreateUserId]
	, [UpdateUserId]
	, [Active]
	, [Deleted]
    FROM
	[dbo].[Street]
    WHERE 
	 ([StreetId] = @StreetId AND @StreetId is not null)
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
	OR ([CreateUserId] = @CreateUserId AND @CreateUserId is not null)
	OR ([UpdateUserId] = @UpdateUserId AND @UpdateUserId is not null)
	OR ([Active] = @Active AND @Active is not null)
	OR ([Deleted] = @Deleted AND @Deleted is not null)
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
-- Date Created: 15 Ocak 2019 Salı

-- Created By:  ()
-- Purpose: Gets all records from the QuestionForm table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_QuestionForm_Get_List

AS


				
				SELECT
					[QuestionId],
					[GroupId],
					[QuestionRef],
					[QuestionName],
					[LineNumber],
					[Status],
					[CreateDate],
					[UpdateDate],
					[CreateUserId],
					[UpdateUserId],
					[Active],
					[Deleted]
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
-- Date Created: 15 Ocak 2019 Salı

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
				SET @SQL = @SQL + ', [GroupId]'
				SET @SQL = @SQL + ', [QuestionRef]'
				SET @SQL = @SQL + ', [QuestionName]'
				SET @SQL = @SQL + ', [LineNumber]'
				SET @SQL = @SQL + ', [Status]'
				SET @SQL = @SQL + ', [CreateDate]'
				SET @SQL = @SQL + ', [UpdateDate]'
				SET @SQL = @SQL + ', [CreateUserId]'
				SET @SQL = @SQL + ', [UpdateUserId]'
				SET @SQL = @SQL + ', [Active]'
				SET @SQL = @SQL + ', [Deleted]'
				SET @SQL = @SQL + ' FROM [dbo].[QuestionForm]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [QuestionId],'
				SET @SQL = @SQL + ' [GroupId],'
				SET @SQL = @SQL + ' [QuestionRef],'
				SET @SQL = @SQL + ' [QuestionName],'
				SET @SQL = @SQL + ' [LineNumber],'
				SET @SQL = @SQL + ' [Status],'
				SET @SQL = @SQL + ' [CreateDate],'
				SET @SQL = @SQL + ' [UpdateDate],'
				SET @SQL = @SQL + ' [CreateUserId],'
				SET @SQL = @SQL + ' [UpdateUserId],'
				SET @SQL = @SQL + ' [Active],'
				SET @SQL = @SQL + ' [Deleted]'
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
-- Date Created: 15 Ocak 2019 Salı

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

	@Status bit   ,

	@CreateDate datetime   ,

	@UpdateDate datetime   ,

	@CreateUserId int   ,

	@UpdateUserId int   ,

	@Active bit   ,

	@Deleted bit   
)
AS


				
				INSERT INTO [dbo].[QuestionForm]
					(
					[GroupId]
					,[QuestionRef]
					,[QuestionName]
					,[LineNumber]
					,[Status]
					,[CreateDate]
					,[UpdateDate]
					,[CreateUserId]
					,[UpdateUserId]
					,[Active]
					,[Deleted]
					)
				VALUES
					(
					@GroupId
					,@QuestionRef
					,@QuestionName
					,@LineNumber
					,@Status
					,@CreateDate
					,@UpdateDate
					,@CreateUserId
					,@UpdateUserId
					,@Active
					,@Deleted
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
-- Date Created: 15 Ocak 2019 Salı

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

	@Status bit   ,

	@CreateDate datetime   ,

	@UpdateDate datetime   ,

	@CreateUserId int   ,

	@UpdateUserId int   ,

	@Active bit   ,

	@Deleted bit   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[QuestionForm]
				SET
					[GroupId] = @GroupId
					,[QuestionRef] = @QuestionRef
					,[QuestionName] = @QuestionName
					,[LineNumber] = @LineNumber
					,[Status] = @Status
					,[CreateDate] = @CreateDate
					,[UpdateDate] = @UpdateDate
					,[CreateUserId] = @CreateUserId
					,[UpdateUserId] = @UpdateUserId
					,[Active] = @Active
					,[Deleted] = @Deleted
				WHERE
[QuestionId] = @QuestionId 
				
			

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
-- Date Created: 15 Ocak 2019 Salı

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
					[QuestionId] = @QuestionId
					
			

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
-- Date Created: 15 Ocak 2019 Salı

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
					[QuestionId],
					[GroupId],
					[QuestionRef],
					[QuestionName],
					[LineNumber],
					[Status],
					[CreateDate],
					[UpdateDate],
					[CreateUserId],
					[UpdateUserId],
					[Active],
					[Deleted]
				FROM
					[dbo].[QuestionForm]
				WHERE
					[GroupId] = @GroupId
				
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
-- Date Created: 15 Ocak 2019 Salı

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
					[QuestionId],
					[GroupId],
					[QuestionRef],
					[QuestionName],
					[LineNumber],
					[Status],
					[CreateDate],
					[UpdateDate],
					[CreateUserId],
					[UpdateUserId],
					[Active],
					[Deleted]
				FROM
					[dbo].[QuestionForm]
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

	

-- Drop the dbo.sp_QuestionForm_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_QuestionForm_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_QuestionForm_Find
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 15 Ocak 2019 Salı

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

	@Status bit   = null ,

	@CreateDate datetime   = null ,

	@UpdateDate datetime   = null ,

	@CreateUserId int   = null ,

	@UpdateUserId int   = null ,

	@Active bit   = null ,

	@Deleted bit   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [QuestionId]
	, [GroupId]
	, [QuestionRef]
	, [QuestionName]
	, [LineNumber]
	, [Status]
	, [CreateDate]
	, [UpdateDate]
	, [CreateUserId]
	, [UpdateUserId]
	, [Active]
	, [Deleted]
    FROM
	[dbo].[QuestionForm]
    WHERE 
	 ([QuestionId] = @QuestionId OR @QuestionId IS NULL)
	AND ([GroupId] = @GroupId OR @GroupId IS NULL)
	AND ([QuestionRef] = @QuestionRef OR @QuestionRef IS NULL)
	AND ([QuestionName] = @QuestionName OR @QuestionName IS NULL)
	AND ([LineNumber] = @LineNumber OR @LineNumber IS NULL)
	AND ([Status] = @Status OR @Status IS NULL)
	AND ([CreateDate] = @CreateDate OR @CreateDate IS NULL)
	AND ([UpdateDate] = @UpdateDate OR @UpdateDate IS NULL)
	AND ([CreateUserId] = @CreateUserId OR @CreateUserId IS NULL)
	AND ([UpdateUserId] = @UpdateUserId OR @UpdateUserId IS NULL)
	AND ([Active] = @Active OR @Active IS NULL)
	AND ([Deleted] = @Deleted OR @Deleted IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [QuestionId]
	, [GroupId]
	, [QuestionRef]
	, [QuestionName]
	, [LineNumber]
	, [Status]
	, [CreateDate]
	, [UpdateDate]
	, [CreateUserId]
	, [UpdateUserId]
	, [Active]
	, [Deleted]
    FROM
	[dbo].[QuestionForm]
    WHERE 
	 ([QuestionId] = @QuestionId AND @QuestionId is not null)
	OR ([GroupId] = @GroupId AND @GroupId is not null)
	OR ([QuestionRef] = @QuestionRef AND @QuestionRef is not null)
	OR ([QuestionName] = @QuestionName AND @QuestionName is not null)
	OR ([LineNumber] = @LineNumber AND @LineNumber is not null)
	OR ([Status] = @Status AND @Status is not null)
	OR ([CreateDate] = @CreateDate AND @CreateDate is not null)
	OR ([UpdateDate] = @UpdateDate AND @UpdateDate is not null)
	OR ([CreateUserId] = @CreateUserId AND @CreateUserId is not null)
	OR ([UpdateUserId] = @UpdateUserId AND @UpdateUserId is not null)
	OR ([Active] = @Active AND @Active is not null)
	OR ([Deleted] = @Deleted AND @Deleted is not null)
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
-- Date Created: 15 Ocak 2019 Salı

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
-- Date Created: 15 Ocak 2019 Salı

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
-- Date Created: 15 Ocak 2019 Salı

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
-- Date Created: 15 Ocak 2019 Salı

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
-- Date Created: 15 Ocak 2019 Salı

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
-- Date Created: 15 Ocak 2019 Salı

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
-- Date Created: 15 Ocak 2019 Salı

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
-- Date Created: 15 Ocak 2019 Salı

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

	

-- Drop the dbo.sp_ClientFather_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_ClientFather_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_ClientFather_Get_List
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 15 Ocak 2019 Salı

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
					[Notes],
					[CreateDate],
					[UpdateDate],
					[CreateUserId],
					[UpdateUserId],
					[Active],
					[Deleted]
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
-- Date Created: 15 Ocak 2019 Salı

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
				SET @SQL = @SQL + ', [Notes]'
				SET @SQL = @SQL + ', [CreateDate]'
				SET @SQL = @SQL + ', [UpdateDate]'
				SET @SQL = @SQL + ', [CreateUserId]'
				SET @SQL = @SQL + ', [UpdateUserId]'
				SET @SQL = @SQL + ', [Active]'
				SET @SQL = @SQL + ', [Deleted]'
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
				SET @SQL = @SQL + ' [Notes],'
				SET @SQL = @SQL + ' [CreateDate],'
				SET @SQL = @SQL + ' [UpdateDate],'
				SET @SQL = @SQL + ' [CreateUserId],'
				SET @SQL = @SQL + ' [UpdateUserId],'
				SET @SQL = @SQL + ' [Active],'
				SET @SQL = @SQL + ' [Deleted]'
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
-- Date Created: 15 Ocak 2019 Salı

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

	@Notes nvarchar (500)  ,

	@CreateDate datetime   ,

	@UpdateDate datetime   ,

	@CreateUserId int   ,

	@UpdateUserId int   ,

	@Active bit   ,

	@Deleted bit   
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
					,[Notes]
					,[CreateDate]
					,[UpdateDate]
					,[CreateUserId]
					,[UpdateUserId]
					,[Active]
					,[Deleted]
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
					,@Notes
					,@CreateDate
					,@UpdateDate
					,@CreateUserId
					,@UpdateUserId
					,@Active
					,@Deleted
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
-- Date Created: 15 Ocak 2019 Salı

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

	@Notes nvarchar (500)  ,

	@CreateDate datetime   ,

	@UpdateDate datetime   ,

	@CreateUserId int   ,

	@UpdateUserId int   ,

	@Active bit   ,

	@Deleted bit   
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
					,[Notes] = @Notes
					,[CreateDate] = @CreateDate
					,[UpdateDate] = @UpdateDate
					,[CreateUserId] = @CreateUserId
					,[UpdateUserId] = @UpdateUserId
					,[Active] = @Active
					,[Deleted] = @Deleted
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
-- Date Created: 15 Ocak 2019 Salı

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
-- Date Created: 15 Ocak 2019 Salı

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
					[Notes],
					[CreateDate],
					[UpdateDate],
					[CreateUserId],
					[UpdateUserId],
					[Active],
					[Deleted]
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
-- Date Created: 15 Ocak 2019 Salı

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

	@Notes nvarchar (500)  = null ,

	@CreateDate datetime   = null ,

	@UpdateDate datetime   = null ,

	@CreateUserId int   = null ,

	@UpdateUserId int   = null ,

	@Active bit   = null ,

	@Deleted bit   = null 
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
	, [Notes]
	, [CreateDate]
	, [UpdateDate]
	, [CreateUserId]
	, [UpdateUserId]
	, [Active]
	, [Deleted]
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
	AND ([Notes] = @Notes OR @Notes IS NULL)
	AND ([CreateDate] = @CreateDate OR @CreateDate IS NULL)
	AND ([UpdateDate] = @UpdateDate OR @UpdateDate IS NULL)
	AND ([CreateUserId] = @CreateUserId OR @CreateUserId IS NULL)
	AND ([UpdateUserId] = @UpdateUserId OR @UpdateUserId IS NULL)
	AND ([Active] = @Active OR @Active IS NULL)
	AND ([Deleted] = @Deleted OR @Deleted IS NULL)
						
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
	, [Notes]
	, [CreateDate]
	, [UpdateDate]
	, [CreateUserId]
	, [UpdateUserId]
	, [Active]
	, [Deleted]
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
	OR ([Notes] = @Notes AND @Notes is not null)
	OR ([CreateDate] = @CreateDate AND @CreateDate is not null)
	OR ([UpdateDate] = @UpdateDate AND @UpdateDate is not null)
	OR ([CreateUserId] = @CreateUserId AND @CreateUserId is not null)
	OR ([UpdateUserId] = @UpdateUserId AND @UpdateUserId is not null)
	OR ([Active] = @Active AND @Active is not null)
	OR ([Deleted] = @Deleted AND @Deleted is not null)
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
-- Date Created: 15 Ocak 2019 Salı

-- Created By:  ()
-- Purpose: Gets all records from the ClientMother table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_ClientMother_Get_List

AS


				
				SELECT
					[MotherId],
					[FullName],
					[Title],
					[Email],
					[Fax],
					[HomePhone],
					[BusinessPhone],
					[MobilePhone],
					[JobId],
					[Notes],
					[CreateDate],
					[UpdateDate],
					[CreateUserId],
					[UpdateUserId],
					[Active],
					[Deleted]
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
-- Date Created: 15 Ocak 2019 Salı

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
					SET @OrderBy = '[MotherId]'
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
				SET @SQL = @SQL + ', [MotherId]'
				SET @SQL = @SQL + ', [FullName]'
				SET @SQL = @SQL + ', [Title]'
				SET @SQL = @SQL + ', [Email]'
				SET @SQL = @SQL + ', [Fax]'
				SET @SQL = @SQL + ', [HomePhone]'
				SET @SQL = @SQL + ', [BusinessPhone]'
				SET @SQL = @SQL + ', [MobilePhone]'
				SET @SQL = @SQL + ', [JobId]'
				SET @SQL = @SQL + ', [Notes]'
				SET @SQL = @SQL + ', [CreateDate]'
				SET @SQL = @SQL + ', [UpdateDate]'
				SET @SQL = @SQL + ', [CreateUserId]'
				SET @SQL = @SQL + ', [UpdateUserId]'
				SET @SQL = @SQL + ', [Active]'
				SET @SQL = @SQL + ', [Deleted]'
				SET @SQL = @SQL + ' FROM [dbo].[ClientMother]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [MotherId],'
				SET @SQL = @SQL + ' [FullName],'
				SET @SQL = @SQL + ' [Title],'
				SET @SQL = @SQL + ' [Email],'
				SET @SQL = @SQL + ' [Fax],'
				SET @SQL = @SQL + ' [HomePhone],'
				SET @SQL = @SQL + ' [BusinessPhone],'
				SET @SQL = @SQL + ' [MobilePhone],'
				SET @SQL = @SQL + ' [JobId],'
				SET @SQL = @SQL + ' [Notes],'
				SET @SQL = @SQL + ' [CreateDate],'
				SET @SQL = @SQL + ' [UpdateDate],'
				SET @SQL = @SQL + ' [CreateUserId],'
				SET @SQL = @SQL + ' [UpdateUserId],'
				SET @SQL = @SQL + ' [Active],'
				SET @SQL = @SQL + ' [Deleted]'
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
-- Date Created: 15 Ocak 2019 Salı

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

	@Notes nvarchar (500)  ,

	@CreateDate datetime   ,

	@UpdateDate datetime   ,

	@CreateUserId int   ,

	@UpdateUserId int   ,

	@Active bit   ,

	@Deleted bit   
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
					,[Notes]
					,[CreateDate]
					,[UpdateDate]
					,[CreateUserId]
					,[UpdateUserId]
					,[Active]
					,[Deleted]
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
					,@Notes
					,@CreateDate
					,@UpdateDate
					,@CreateUserId
					,@UpdateUserId
					,@Active
					,@Deleted
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
-- Date Created: 15 Ocak 2019 Salı

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

	@Notes nvarchar (500)  ,

	@CreateDate datetime   ,

	@UpdateDate datetime   ,

	@CreateUserId int   ,

	@UpdateUserId int   ,

	@Active bit   ,

	@Deleted bit   
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
					,[Notes] = @Notes
					,[CreateDate] = @CreateDate
					,[UpdateDate] = @UpdateDate
					,[CreateUserId] = @CreateUserId
					,[UpdateUserId] = @UpdateUserId
					,[Active] = @Active
					,[Deleted] = @Deleted
				WHERE
[MotherId] = @MotherId 
				
			

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
-- Date Created: 15 Ocak 2019 Salı

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
					[MotherId] = @MotherId
					
			

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
-- Date Created: 15 Ocak 2019 Salı

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
					[MotherId],
					[FullName],
					[Title],
					[Email],
					[Fax],
					[HomePhone],
					[BusinessPhone],
					[MobilePhone],
					[JobId],
					[Notes],
					[CreateDate],
					[UpdateDate],
					[CreateUserId],
					[UpdateUserId],
					[Active],
					[Deleted]
				FROM
					[dbo].[ClientMother]
				WHERE
					[MotherId] = @MotherId
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
-- Date Created: 15 Ocak 2019 Salı

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

	@Notes nvarchar (500)  = null ,

	@CreateDate datetime   = null ,

	@UpdateDate datetime   = null ,

	@CreateUserId int   = null ,

	@UpdateUserId int   = null ,

	@Active bit   = null ,

	@Deleted bit   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [MotherId]
	, [FullName]
	, [Title]
	, [Email]
	, [Fax]
	, [HomePhone]
	, [BusinessPhone]
	, [MobilePhone]
	, [JobId]
	, [Notes]
	, [CreateDate]
	, [UpdateDate]
	, [CreateUserId]
	, [UpdateUserId]
	, [Active]
	, [Deleted]
    FROM
	[dbo].[ClientMother]
    WHERE 
	 ([MotherId] = @MotherId OR @MotherId IS NULL)
	AND ([FullName] = @FullName OR @FullName IS NULL)
	AND ([Title] = @Title OR @Title IS NULL)
	AND ([Email] = @Email OR @Email IS NULL)
	AND ([Fax] = @Fax OR @Fax IS NULL)
	AND ([HomePhone] = @HomePhone OR @HomePhone IS NULL)
	AND ([BusinessPhone] = @BusinessPhone OR @BusinessPhone IS NULL)
	AND ([MobilePhone] = @MobilePhone OR @MobilePhone IS NULL)
	AND ([JobId] = @JobId OR @JobId IS NULL)
	AND ([Notes] = @Notes OR @Notes IS NULL)
	AND ([CreateDate] = @CreateDate OR @CreateDate IS NULL)
	AND ([UpdateDate] = @UpdateDate OR @UpdateDate IS NULL)
	AND ([CreateUserId] = @CreateUserId OR @CreateUserId IS NULL)
	AND ([UpdateUserId] = @UpdateUserId OR @UpdateUserId IS NULL)
	AND ([Active] = @Active OR @Active IS NULL)
	AND ([Deleted] = @Deleted OR @Deleted IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [MotherId]
	, [FullName]
	, [Title]
	, [Email]
	, [Fax]
	, [HomePhone]
	, [BusinessPhone]
	, [MobilePhone]
	, [JobId]
	, [Notes]
	, [CreateDate]
	, [UpdateDate]
	, [CreateUserId]
	, [UpdateUserId]
	, [Active]
	, [Deleted]
    FROM
	[dbo].[ClientMother]
    WHERE 
	 ([MotherId] = @MotherId AND @MotherId is not null)
	OR ([FullName] = @FullName AND @FullName is not null)
	OR ([Title] = @Title AND @Title is not null)
	OR ([Email] = @Email AND @Email is not null)
	OR ([Fax] = @Fax AND @Fax is not null)
	OR ([HomePhone] = @HomePhone AND @HomePhone is not null)
	OR ([BusinessPhone] = @BusinessPhone AND @BusinessPhone is not null)
	OR ([MobilePhone] = @MobilePhone AND @MobilePhone is not null)
	OR ([JobId] = @JobId AND @JobId is not null)
	OR ([Notes] = @Notes AND @Notes is not null)
	OR ([CreateDate] = @CreateDate AND @CreateDate is not null)
	OR ([UpdateDate] = @UpdateDate AND @UpdateDate is not null)
	OR ([CreateUserId] = @CreateUserId AND @CreateUserId is not null)
	OR ([UpdateUserId] = @UpdateUserId AND @UpdateUserId is not null)
	OR ([Active] = @Active AND @Active is not null)
	OR ([Deleted] = @Deleted AND @Deleted is not null)
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
-- Date Created: 15 Ocak 2019 Salı

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
					[CreateDate],
					[UpdateDate],
					[CreateUserId],
					[UpdateUserId],
					[Active],
					[Deleted]
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
-- Date Created: 15 Ocak 2019 Salı

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
				SET @SQL = @SQL + ', [CreateDate]'
				SET @SQL = @SQL + ', [UpdateDate]'
				SET @SQL = @SQL + ', [CreateUserId]'
				SET @SQL = @SQL + ', [UpdateUserId]'
				SET @SQL = @SQL + ', [Active]'
				SET @SQL = @SQL + ', [Deleted]'
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
				SET @SQL = @SQL + ' [CreateDate],'
				SET @SQL = @SQL + ' [UpdateDate],'
				SET @SQL = @SQL + ' [CreateUserId],'
				SET @SQL = @SQL + ' [UpdateUserId],'
				SET @SQL = @SQL + ' [Active],'
				SET @SQL = @SQL + ' [Deleted]'
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
-- Date Created: 15 Ocak 2019 Salı

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

	@CreateDate datetime   ,

	@UpdateDate datetime   ,

	@CreateUserId int   ,

	@UpdateUserId int   ,

	@Active bit   ,

	@Deleted bit   
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
					,[CreateDate]
					,[UpdateDate]
					,[CreateUserId]
					,[UpdateUserId]
					,[Active]
					,[Deleted]
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
					,@CreateDate
					,@UpdateDate
					,@CreateUserId
					,@UpdateUserId
					,@Active
					,@Deleted
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
-- Date Created: 15 Ocak 2019 Salı

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

	@CreateDate datetime   ,

	@UpdateDate datetime   ,

	@CreateUserId int   ,

	@UpdateUserId int   ,

	@Active bit   ,

	@Deleted bit   
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
					,[CreateDate] = @CreateDate
					,[UpdateDate] = @UpdateDate
					,[CreateUserId] = @CreateUserId
					,[UpdateUserId] = @UpdateUserId
					,[Active] = @Active
					,[Deleted] = @Deleted
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
-- Date Created: 15 Ocak 2019 Salı

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
-- Date Created: 15 Ocak 2019 Salı

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
					[CreateDate],
					[UpdateDate],
					[CreateUserId],
					[UpdateUserId],
					[Active],
					[Deleted]
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
-- Date Created: 15 Ocak 2019 Salı

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

	@CreateDate datetime   = null ,

	@UpdateDate datetime   = null ,

	@CreateUserId int   = null ,

	@UpdateUserId int   = null ,

	@Active bit   = null ,

	@Deleted bit   = null 
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
	, [CreateDate]
	, [UpdateDate]
	, [CreateUserId]
	, [UpdateUserId]
	, [Active]
	, [Deleted]
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
	AND ([CreateDate] = @CreateDate OR @CreateDate IS NULL)
	AND ([UpdateDate] = @UpdateDate OR @UpdateDate IS NULL)
	AND ([CreateUserId] = @CreateUserId OR @CreateUserId IS NULL)
	AND ([UpdateUserId] = @UpdateUserId OR @UpdateUserId IS NULL)
	AND ([Active] = @Active OR @Active IS NULL)
	AND ([Deleted] = @Deleted OR @Deleted IS NULL)
						
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
	, [CreateDate]
	, [UpdateDate]
	, [CreateUserId]
	, [UpdateUserId]
	, [Active]
	, [Deleted]
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
	OR ([CreateDate] = @CreateDate AND @CreateDate is not null)
	OR ([UpdateDate] = @UpdateDate AND @UpdateDate is not null)
	OR ([CreateUserId] = @CreateUserId AND @CreateUserId is not null)
	OR ([UpdateUserId] = @UpdateUserId AND @UpdateUserId is not null)
	OR ([Active] = @Active AND @Active is not null)
	OR ([Deleted] = @Deleted AND @Deleted is not null)
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
-- Date Created: 15 Ocak 2019 Salı

-- Created By:  ()
-- Purpose: Gets all records from the Province table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Province_Get_List

AS


				
				SELECT
					[ProvinceId],
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
					[CreateUserId],
					[UpdateUserId],
					[Active],
					[Deleted]
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
-- Date Created: 15 Ocak 2019 Salı

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
					SET @OrderBy = '[ProvinceId]'
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
				SET @SQL = @SQL + ', [ProvinceId]'
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
				SET @SQL = @SQL + ', [CreateUserId]'
				SET @SQL = @SQL + ', [UpdateUserId]'
				SET @SQL = @SQL + ', [Active]'
				SET @SQL = @SQL + ', [Deleted]'
				SET @SQL = @SQL + ' FROM [dbo].[Province]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [ProvinceId],'
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
				SET @SQL = @SQL + ' [CreateUserId],'
				SET @SQL = @SQL + ' [UpdateUserId],'
				SET @SQL = @SQL + ' [Active],'
				SET @SQL = @SQL + ' [Deleted]'
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
-- Date Created: 15 Ocak 2019 Salı

-- Created By:  ()
-- Purpose: Inserts a record into the Province table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Province_Insert
(

	@ProvinceId int    OUTPUT,

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

	@UpdateTime time   ,

	@CreateUserId int   ,

	@UpdateUserId int   ,

	@Active bit   ,

	@Deleted bit   
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
					,[CreateUserId]
					,[UpdateUserId]
					,[Active]
					,[Deleted]
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
					,@CreateUserId
					,@UpdateUserId
					,@Active
					,@Deleted
					)
				-- Get the identity value
				SET @ProvinceId = SCOPE_IDENTITY()
									
							
			

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
-- Date Created: 15 Ocak 2019 Salı

-- Created By:  ()
-- Purpose: Updates a record in the Province table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Province_Update
(

	@ProvinceId int   ,

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

	@UpdateTime time   ,

	@CreateUserId int   ,

	@UpdateUserId int   ,

	@Active bit   ,

	@Deleted bit   
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
					,[CreateUserId] = @CreateUserId
					,[UpdateUserId] = @UpdateUserId
					,[Active] = @Active
					,[Deleted] = @Deleted
				WHERE
[ProvinceId] = @ProvinceId 
				
			

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
-- Date Created: 15 Ocak 2019 Salı

-- Created By:  ()
-- Purpose: Deletes a record in the Province table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Province_Delete
(

	@ProvinceId int   
)
AS


				DELETE FROM [dbo].[Province] WITH (ROWLOCK) 
				WHERE
					[ProvinceId] = @ProvinceId
					
			

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
-- Date Created: 15 Ocak 2019 Salı

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
					[ProvinceId],
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
					[CreateUserId],
					[UpdateUserId],
					[Active],
					[Deleted]
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

	

-- Drop the dbo.sp_Province_GetByProvinceId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_Province_GetByProvinceId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_Province_GetByProvinceId
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 15 Ocak 2019 Salı

-- Created By:  ()
-- Purpose: Select records from the Province table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Province_GetByProvinceId
(

	@ProvinceId int   
)
AS


				SELECT
					[ProvinceId],
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
					[CreateUserId],
					[UpdateUserId],
					[Active],
					[Deleted]
				FROM
					[dbo].[Province]
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

	

-- Drop the dbo.sp_Province_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_Province_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_Province_Find
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 15 Ocak 2019 Salı

-- Created By:  ()
-- Purpose: Finds records in the Province table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Province_Find
(

	@SearchUsingOR bit   = null ,

	@ProvinceId int   = null ,

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

	@UpdateTime time   = null ,

	@CreateUserId int   = null ,

	@UpdateUserId int   = null ,

	@Active bit   = null ,

	@Deleted bit   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [ProvinceId]
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
	, [CreateUserId]
	, [UpdateUserId]
	, [Active]
	, [Deleted]
    FROM
	[dbo].[Province]
    WHERE 
	 ([ProvinceId] = @ProvinceId OR @ProvinceId IS NULL)
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
	AND ([CreateUserId] = @CreateUserId OR @CreateUserId IS NULL)
	AND ([UpdateUserId] = @UpdateUserId OR @UpdateUserId IS NULL)
	AND ([Active] = @Active OR @Active IS NULL)
	AND ([Deleted] = @Deleted OR @Deleted IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [ProvinceId]
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
	, [CreateUserId]
	, [UpdateUserId]
	, [Active]
	, [Deleted]
    FROM
	[dbo].[Province]
    WHERE 
	 ([ProvinceId] = @ProvinceId AND @ProvinceId is not null)
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
	OR ([CreateUserId] = @CreateUserId AND @CreateUserId is not null)
	OR ([UpdateUserId] = @UpdateUserId AND @UpdateUserId is not null)
	OR ([Active] = @Active AND @Active is not null)
	OR ([Deleted] = @Deleted AND @Deleted is not null)
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
-- Date Created: 15 Ocak 2019 Salı

-- Created By:  ()
-- Purpose: Gets all records from the CalenderAge table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_CalenderAge_Get_List

AS


				
				SELECT
					[CalenderAgeId],
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
-- Date Created: 15 Ocak 2019 Salı

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
					SET @OrderBy = '[CalenderAgeId]'
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
				SET @SQL = @SQL + ', [CalenderAgeId]'
				SET @SQL = @SQL + ', [AgeValue]'
				SET @SQL = @SQL + ' FROM [dbo].[CalenderAge]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [CalenderAgeId],'
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
-- Date Created: 15 Ocak 2019 Salı

-- Created By:  ()
-- Purpose: Inserts a record into the CalenderAge table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_CalenderAge_Insert
(

	@CalenderAgeId int    OUTPUT,

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
				SET @CalenderAgeId = SCOPE_IDENTITY()
									
							
			

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
-- Date Created: 15 Ocak 2019 Salı

-- Created By:  ()
-- Purpose: Updates a record in the CalenderAge table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_CalenderAge_Update
(

	@CalenderAgeId int   ,

	@AgeValue varchar (50)  
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[CalenderAge]
				SET
					[AgeValue] = @AgeValue
				WHERE
[CalenderAgeId] = @CalenderAgeId 
				
			

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
-- Date Created: 15 Ocak 2019 Salı

-- Created By:  ()
-- Purpose: Deletes a record in the CalenderAge table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_CalenderAge_Delete
(

	@CalenderAgeId int   
)
AS


				DELETE FROM [dbo].[CalenderAge] WITH (ROWLOCK) 
				WHERE
					[CalenderAgeId] = @CalenderAgeId
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_CalenderAge_GetByCalenderAgeId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_CalenderAge_GetByCalenderAgeId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_CalenderAge_GetByCalenderAgeId
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 15 Ocak 2019 Salı

-- Created By:  ()
-- Purpose: Select records from the CalenderAge table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_CalenderAge_GetByCalenderAgeId
(

	@CalenderAgeId int   
)
AS


				SELECT
					[CalenderAgeId],
					[AgeValue]
				FROM
					[dbo].[CalenderAge]
				WHERE
					[CalenderAgeId] = @CalenderAgeId
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
-- Date Created: 15 Ocak 2019 Salı

-- Created By:  ()
-- Purpose: Finds records in the CalenderAge table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_CalenderAge_Find
(

	@SearchUsingOR bit   = null ,

	@CalenderAgeId int   = null ,

	@AgeValue varchar (50)  = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [CalenderAgeId]
	, [AgeValue]
    FROM
	[dbo].[CalenderAge]
    WHERE 
	 ([CalenderAgeId] = @CalenderAgeId OR @CalenderAgeId IS NULL)
	AND ([AgeValue] = @AgeValue OR @AgeValue IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [CalenderAgeId]
	, [AgeValue]
    FROM
	[dbo].[CalenderAge]
    WHERE 
	 ([CalenderAgeId] = @CalenderAgeId AND @CalenderAgeId is not null)
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

	

-- Drop the dbo.sp_Client_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_Client_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_Client_Get_List
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 15 Ocak 2019 Salı

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
					[FirstContactAge],
					[BirthDate],
					[CalenderAgeId],
					[FullName],
					[MiddleName],
					[Reference],
					[MotherId],
					[FatherId],
					[AddressId],
					[IdCard],
					[Gender],
					[Blood],
					[Pediatrician],
					[CountOfChild],
					[FamilyStatus],
					[Notes],
					[CreateDate],
					[UpdateDate],
					[CreateUserId],
					[UpdateUserId],
					[Active],
					[Deleted]
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
-- Date Created: 15 Ocak 2019 Salı

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
				SET @SQL = @SQL + ', [FirstContactAge]'
				SET @SQL = @SQL + ', [BirthDate]'
				SET @SQL = @SQL + ', [CalenderAgeId]'
				SET @SQL = @SQL + ', [FullName]'
				SET @SQL = @SQL + ', [MiddleName]'
				SET @SQL = @SQL + ', [Reference]'
				SET @SQL = @SQL + ', [MotherId]'
				SET @SQL = @SQL + ', [FatherId]'
				SET @SQL = @SQL + ', [AddressId]'
				SET @SQL = @SQL + ', [IdCard]'
				SET @SQL = @SQL + ', [Gender]'
				SET @SQL = @SQL + ', [Blood]'
				SET @SQL = @SQL + ', [Pediatrician]'
				SET @SQL = @SQL + ', [CountOfChild]'
				SET @SQL = @SQL + ', [FamilyStatus]'
				SET @SQL = @SQL + ', [Notes]'
				SET @SQL = @SQL + ', [CreateDate]'
				SET @SQL = @SQL + ', [UpdateDate]'
				SET @SQL = @SQL + ', [CreateUserId]'
				SET @SQL = @SQL + ', [UpdateUserId]'
				SET @SQL = @SQL + ', [Active]'
				SET @SQL = @SQL + ', [Deleted]'
				SET @SQL = @SQL + ' FROM [dbo].[Client]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [ClientId],'
				SET @SQL = @SQL + ' [FileNumber],'
				SET @SQL = @SQL + ' [FirstContactDate],'
				SET @SQL = @SQL + ' [FirstContactAge],'
				SET @SQL = @SQL + ' [BirthDate],'
				SET @SQL = @SQL + ' [CalenderAgeId],'
				SET @SQL = @SQL + ' [FullName],'
				SET @SQL = @SQL + ' [MiddleName],'
				SET @SQL = @SQL + ' [Reference],'
				SET @SQL = @SQL + ' [MotherId],'
				SET @SQL = @SQL + ' [FatherId],'
				SET @SQL = @SQL + ' [AddressId],'
				SET @SQL = @SQL + ' [IdCard],'
				SET @SQL = @SQL + ' [Gender],'
				SET @SQL = @SQL + ' [Blood],'
				SET @SQL = @SQL + ' [Pediatrician],'
				SET @SQL = @SQL + ' [CountOfChild],'
				SET @SQL = @SQL + ' [FamilyStatus],'
				SET @SQL = @SQL + ' [Notes],'
				SET @SQL = @SQL + ' [CreateDate],'
				SET @SQL = @SQL + ' [UpdateDate],'
				SET @SQL = @SQL + ' [CreateUserId],'
				SET @SQL = @SQL + ' [UpdateUserId],'
				SET @SQL = @SQL + ' [Active],'
				SET @SQL = @SQL + ' [Deleted]'
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
-- Date Created: 15 Ocak 2019 Salı

-- Created By:  ()
-- Purpose: Inserts a record into the Client table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Client_Insert
(

	@ClientId int    OUTPUT,

	@FileNumber int   ,

	@FirstContactDate datetime   ,

	@FirstContactAge int   ,

	@BirthDate datetime   ,

	@CalenderAgeId tinyint   ,

	@FullName varchar (100)  ,

	@MiddleName varchar (100)  ,

	@Reference varchar (250)  ,

	@MotherId int   ,

	@FatherId int   ,

	@AddressId int   ,

	@IdCard varchar (11)  ,

	@Gender tinyint   ,

	@Blood tinyint   ,

	@Pediatrician varchar (100)  ,

	@CountOfChild int   ,

	@FamilyStatus tinyint   ,

	@Notes varchar (MAX)  ,

	@CreateDate datetime   ,

	@UpdateDate datetime   ,

	@CreateUserId int   ,

	@UpdateUserId int   ,

	@Active bit   ,

	@Deleted bit   
)
AS


				
				INSERT INTO [dbo].[Client]
					(
					[FileNumber]
					,[FirstContactDate]
					,[FirstContactAge]
					,[BirthDate]
					,[CalenderAgeId]
					,[FullName]
					,[MiddleName]
					,[Reference]
					,[MotherId]
					,[FatherId]
					,[AddressId]
					,[IdCard]
					,[Gender]
					,[Blood]
					,[Pediatrician]
					,[CountOfChild]
					,[FamilyStatus]
					,[Notes]
					,[CreateDate]
					,[UpdateDate]
					,[CreateUserId]
					,[UpdateUserId]
					,[Active]
					,[Deleted]
					)
				VALUES
					(
					@FileNumber
					,@FirstContactDate
					,@FirstContactAge
					,@BirthDate
					,@CalenderAgeId
					,@FullName
					,@MiddleName
					,@Reference
					,@MotherId
					,@FatherId
					,@AddressId
					,@IdCard
					,@Gender
					,@Blood
					,@Pediatrician
					,@CountOfChild
					,@FamilyStatus
					,@Notes
					,@CreateDate
					,@UpdateDate
					,@CreateUserId
					,@UpdateUserId
					,@Active
					,@Deleted
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
-- Date Created: 15 Ocak 2019 Salı

-- Created By:  ()
-- Purpose: Updates a record in the Client table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Client_Update
(

	@ClientId int   ,

	@FileNumber int   ,

	@FirstContactDate datetime   ,

	@FirstContactAge int   ,

	@BirthDate datetime   ,

	@CalenderAgeId tinyint   ,

	@FullName varchar (100)  ,

	@MiddleName varchar (100)  ,

	@Reference varchar (250)  ,

	@MotherId int   ,

	@FatherId int   ,

	@AddressId int   ,

	@IdCard varchar (11)  ,

	@Gender tinyint   ,

	@Blood tinyint   ,

	@Pediatrician varchar (100)  ,

	@CountOfChild int   ,

	@FamilyStatus tinyint   ,

	@Notes varchar (MAX)  ,

	@CreateDate datetime   ,

	@UpdateDate datetime   ,

	@CreateUserId int   ,

	@UpdateUserId int   ,

	@Active bit   ,

	@Deleted bit   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[Client]
				SET
					[FileNumber] = @FileNumber
					,[FirstContactDate] = @FirstContactDate
					,[FirstContactAge] = @FirstContactAge
					,[BirthDate] = @BirthDate
					,[CalenderAgeId] = @CalenderAgeId
					,[FullName] = @FullName
					,[MiddleName] = @MiddleName
					,[Reference] = @Reference
					,[MotherId] = @MotherId
					,[FatherId] = @FatherId
					,[AddressId] = @AddressId
					,[IdCard] = @IdCard
					,[Gender] = @Gender
					,[Blood] = @Blood
					,[Pediatrician] = @Pediatrician
					,[CountOfChild] = @CountOfChild
					,[FamilyStatus] = @FamilyStatus
					,[Notes] = @Notes
					,[CreateDate] = @CreateDate
					,[UpdateDate] = @UpdateDate
					,[CreateUserId] = @CreateUserId
					,[UpdateUserId] = @UpdateUserId
					,[Active] = @Active
					,[Deleted] = @Deleted
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
-- Date Created: 15 Ocak 2019 Salı

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
-- Date Created: 15 Ocak 2019 Salı

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
					[FirstContactAge],
					[BirthDate],
					[CalenderAgeId],
					[FullName],
					[MiddleName],
					[Reference],
					[MotherId],
					[FatherId],
					[AddressId],
					[IdCard],
					[Gender],
					[Blood],
					[Pediatrician],
					[CountOfChild],
					[FamilyStatus],
					[Notes],
					[CreateDate],
					[UpdateDate],
					[CreateUserId],
					[UpdateUserId],
					[Active],
					[Deleted]
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
-- Date Created: 15 Ocak 2019 Salı

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
					[FirstContactAge],
					[BirthDate],
					[CalenderAgeId],
					[FullName],
					[MiddleName],
					[Reference],
					[MotherId],
					[FatherId],
					[AddressId],
					[IdCard],
					[Gender],
					[Blood],
					[Pediatrician],
					[CountOfChild],
					[FamilyStatus],
					[Notes],
					[CreateDate],
					[UpdateDate],
					[CreateUserId],
					[UpdateUserId],
					[Active],
					[Deleted]
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
-- Date Created: 15 Ocak 2019 Salı

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
					[FirstContactAge],
					[BirthDate],
					[CalenderAgeId],
					[FullName],
					[MiddleName],
					[Reference],
					[MotherId],
					[FatherId],
					[AddressId],
					[IdCard],
					[Gender],
					[Blood],
					[Pediatrician],
					[CountOfChild],
					[FamilyStatus],
					[Notes],
					[CreateDate],
					[UpdateDate],
					[CreateUserId],
					[UpdateUserId],
					[Active],
					[Deleted]
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
-- Date Created: 15 Ocak 2019 Salı

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
					[FirstContactAge],
					[BirthDate],
					[CalenderAgeId],
					[FullName],
					[MiddleName],
					[Reference],
					[MotherId],
					[FatherId],
					[AddressId],
					[IdCard],
					[Gender],
					[Blood],
					[Pediatrician],
					[CountOfChild],
					[FamilyStatus],
					[Notes],
					[CreateDate],
					[UpdateDate],
					[CreateUserId],
					[UpdateUserId],
					[Active],
					[Deleted]
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
-- Date Created: 15 Ocak 2019 Salı

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
					[FirstContactAge],
					[BirthDate],
					[CalenderAgeId],
					[FullName],
					[MiddleName],
					[Reference],
					[MotherId],
					[FatherId],
					[AddressId],
					[IdCard],
					[Gender],
					[Blood],
					[Pediatrician],
					[CountOfChild],
					[FamilyStatus],
					[Notes],
					[CreateDate],
					[UpdateDate],
					[CreateUserId],
					[UpdateUserId],
					[Active],
					[Deleted]
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
-- Date Created: 15 Ocak 2019 Salı

-- Created By:  ()
-- Purpose: Finds records in the Client table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Client_Find
(

	@SearchUsingOR bit   = null ,

	@ClientId int   = null ,

	@FileNumber int   = null ,

	@FirstContactDate datetime   = null ,

	@FirstContactAge int   = null ,

	@BirthDate datetime   = null ,

	@CalenderAgeId tinyint   = null ,

	@FullName varchar (100)  = null ,

	@MiddleName varchar (100)  = null ,

	@Reference varchar (250)  = null ,

	@MotherId int   = null ,

	@FatherId int   = null ,

	@AddressId int   = null ,

	@IdCard varchar (11)  = null ,

	@Gender tinyint   = null ,

	@Blood tinyint   = null ,

	@Pediatrician varchar (100)  = null ,

	@CountOfChild int   = null ,

	@FamilyStatus tinyint   = null ,

	@Notes varchar (MAX)  = null ,

	@CreateDate datetime   = null ,

	@UpdateDate datetime   = null ,

	@CreateUserId int   = null ,

	@UpdateUserId int   = null ,

	@Active bit   = null ,

	@Deleted bit   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [ClientId]
	, [FileNumber]
	, [FirstContactDate]
	, [FirstContactAge]
	, [BirthDate]
	, [CalenderAgeId]
	, [FullName]
	, [MiddleName]
	, [Reference]
	, [MotherId]
	, [FatherId]
	, [AddressId]
	, [IdCard]
	, [Gender]
	, [Blood]
	, [Pediatrician]
	, [CountOfChild]
	, [FamilyStatus]
	, [Notes]
	, [CreateDate]
	, [UpdateDate]
	, [CreateUserId]
	, [UpdateUserId]
	, [Active]
	, [Deleted]
    FROM
	[dbo].[Client]
    WHERE 
	 ([ClientId] = @ClientId OR @ClientId IS NULL)
	AND ([FileNumber] = @FileNumber OR @FileNumber IS NULL)
	AND ([FirstContactDate] = @FirstContactDate OR @FirstContactDate IS NULL)
	AND ([FirstContactAge] = @FirstContactAge OR @FirstContactAge IS NULL)
	AND ([BirthDate] = @BirthDate OR @BirthDate IS NULL)
	AND ([CalenderAgeId] = @CalenderAgeId OR @CalenderAgeId IS NULL)
	AND ([FullName] = @FullName OR @FullName IS NULL)
	AND ([MiddleName] = @MiddleName OR @MiddleName IS NULL)
	AND ([Reference] = @Reference OR @Reference IS NULL)
	AND ([MotherId] = @MotherId OR @MotherId IS NULL)
	AND ([FatherId] = @FatherId OR @FatherId IS NULL)
	AND ([AddressId] = @AddressId OR @AddressId IS NULL)
	AND ([IdCard] = @IdCard OR @IdCard IS NULL)
	AND ([Gender] = @Gender OR @Gender IS NULL)
	AND ([Blood] = @Blood OR @Blood IS NULL)
	AND ([Pediatrician] = @Pediatrician OR @Pediatrician IS NULL)
	AND ([CountOfChild] = @CountOfChild OR @CountOfChild IS NULL)
	AND ([FamilyStatus] = @FamilyStatus OR @FamilyStatus IS NULL)
	AND ([Notes] = @Notes OR @Notes IS NULL)
	AND ([CreateDate] = @CreateDate OR @CreateDate IS NULL)
	AND ([UpdateDate] = @UpdateDate OR @UpdateDate IS NULL)
	AND ([CreateUserId] = @CreateUserId OR @CreateUserId IS NULL)
	AND ([UpdateUserId] = @UpdateUserId OR @UpdateUserId IS NULL)
	AND ([Active] = @Active OR @Active IS NULL)
	AND ([Deleted] = @Deleted OR @Deleted IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [ClientId]
	, [FileNumber]
	, [FirstContactDate]
	, [FirstContactAge]
	, [BirthDate]
	, [CalenderAgeId]
	, [FullName]
	, [MiddleName]
	, [Reference]
	, [MotherId]
	, [FatherId]
	, [AddressId]
	, [IdCard]
	, [Gender]
	, [Blood]
	, [Pediatrician]
	, [CountOfChild]
	, [FamilyStatus]
	, [Notes]
	, [CreateDate]
	, [UpdateDate]
	, [CreateUserId]
	, [UpdateUserId]
	, [Active]
	, [Deleted]
    FROM
	[dbo].[Client]
    WHERE 
	 ([ClientId] = @ClientId AND @ClientId is not null)
	OR ([FileNumber] = @FileNumber AND @FileNumber is not null)
	OR ([FirstContactDate] = @FirstContactDate AND @FirstContactDate is not null)
	OR ([FirstContactAge] = @FirstContactAge AND @FirstContactAge is not null)
	OR ([BirthDate] = @BirthDate AND @BirthDate is not null)
	OR ([CalenderAgeId] = @CalenderAgeId AND @CalenderAgeId is not null)
	OR ([FullName] = @FullName AND @FullName is not null)
	OR ([MiddleName] = @MiddleName AND @MiddleName is not null)
	OR ([Reference] = @Reference AND @Reference is not null)
	OR ([MotherId] = @MotherId AND @MotherId is not null)
	OR ([FatherId] = @FatherId AND @FatherId is not null)
	OR ([AddressId] = @AddressId AND @AddressId is not null)
	OR ([IdCard] = @IdCard AND @IdCard is not null)
	OR ([Gender] = @Gender AND @Gender is not null)
	OR ([Blood] = @Blood AND @Blood is not null)
	OR ([Pediatrician] = @Pediatrician AND @Pediatrician is not null)
	OR ([CountOfChild] = @CountOfChild AND @CountOfChild is not null)
	OR ([FamilyStatus] = @FamilyStatus AND @FamilyStatus is not null)
	OR ([Notes] = @Notes AND @Notes is not null)
	OR ([CreateDate] = @CreateDate AND @CreateDate is not null)
	OR ([UpdateDate] = @UpdateDate AND @UpdateDate is not null)
	OR ([CreateUserId] = @CreateUserId AND @CreateUserId is not null)
	OR ([UpdateUserId] = @UpdateUserId AND @UpdateUserId is not null)
	OR ([Active] = @Active AND @Active is not null)
	OR ([Deleted] = @Deleted AND @Deleted is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_ClientEducation_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_ClientEducation_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_ClientEducation_Get_List
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 15 Ocak 2019 Salı

-- Created By:  ()
-- Purpose: Gets all records from the ClientEducation table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_ClientEducation_Get_List

AS


				
				SELECT
					[EducationId],
					[ClientId],
					[SchoolId],
					[ClassRoom],
					[TeacherId],
					[Notes],
					[CreateDate],
					[UpdateDate],
					[CreateUserId],
					[UpdateUserId],
					[Active],
					[Deleted]
				FROM
					[dbo].[ClientEducation]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_ClientEducation_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_ClientEducation_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_ClientEducation_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 15 Ocak 2019 Salı

-- Created By:  ()
-- Purpose: Gets records from the ClientEducation table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_ClientEducation_GetPaged
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
					SET @OrderBy = '[EducationId]'
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
				SET @SQL = @SQL + ', [EducationId]'
				SET @SQL = @SQL + ', [ClientId]'
				SET @SQL = @SQL + ', [SchoolId]'
				SET @SQL = @SQL + ', [ClassRoom]'
				SET @SQL = @SQL + ', [TeacherId]'
				SET @SQL = @SQL + ', [Notes]'
				SET @SQL = @SQL + ', [CreateDate]'
				SET @SQL = @SQL + ', [UpdateDate]'
				SET @SQL = @SQL + ', [CreateUserId]'
				SET @SQL = @SQL + ', [UpdateUserId]'
				SET @SQL = @SQL + ', [Active]'
				SET @SQL = @SQL + ', [Deleted]'
				SET @SQL = @SQL + ' FROM [dbo].[ClientEducation]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [EducationId],'
				SET @SQL = @SQL + ' [ClientId],'
				SET @SQL = @SQL + ' [SchoolId],'
				SET @SQL = @SQL + ' [ClassRoom],'
				SET @SQL = @SQL + ' [TeacherId],'
				SET @SQL = @SQL + ' [Notes],'
				SET @SQL = @SQL + ' [CreateDate],'
				SET @SQL = @SQL + ' [UpdateDate],'
				SET @SQL = @SQL + ' [CreateUserId],'
				SET @SQL = @SQL + ' [UpdateUserId],'
				SET @SQL = @SQL + ' [Active],'
				SET @SQL = @SQL + ' [Deleted]'
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
				SET @SQL = @SQL + ' FROM [dbo].[ClientEducation]'
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

	

-- Drop the dbo.sp_ClientEducation_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_ClientEducation_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_ClientEducation_Insert
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 15 Ocak 2019 Salı

-- Created By:  ()
-- Purpose: Inserts a record into the ClientEducation table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_ClientEducation_Insert
(

	@EducationId int    OUTPUT,

	@ClientId int   ,

	@SchoolId int   ,

	@ClassRoom varchar (50)  ,

	@TeacherId int   ,

	@Notes varchar (500)  ,

	@CreateDate datetime   ,

	@UpdateDate datetime   ,

	@CreateUserId int   ,

	@UpdateUserId int   ,

	@Active bit   ,

	@Deleted bit   
)
AS


				
				INSERT INTO [dbo].[ClientEducation]
					(
					[ClientId]
					,[SchoolId]
					,[ClassRoom]
					,[TeacherId]
					,[Notes]
					,[CreateDate]
					,[UpdateDate]
					,[CreateUserId]
					,[UpdateUserId]
					,[Active]
					,[Deleted]
					)
				VALUES
					(
					@ClientId
					,@SchoolId
					,@ClassRoom
					,@TeacherId
					,@Notes
					,@CreateDate
					,@UpdateDate
					,@CreateUserId
					,@UpdateUserId
					,@Active
					,@Deleted
					)
				-- Get the identity value
				SET @EducationId = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_ClientEducation_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_ClientEducation_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_ClientEducation_Update
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 15 Ocak 2019 Salı

-- Created By:  ()
-- Purpose: Updates a record in the ClientEducation table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_ClientEducation_Update
(

	@EducationId int   ,

	@ClientId int   ,

	@SchoolId int   ,

	@ClassRoom varchar (50)  ,

	@TeacherId int   ,

	@Notes varchar (500)  ,

	@CreateDate datetime   ,

	@UpdateDate datetime   ,

	@CreateUserId int   ,

	@UpdateUserId int   ,

	@Active bit   ,

	@Deleted bit   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[ClientEducation]
				SET
					[ClientId] = @ClientId
					,[SchoolId] = @SchoolId
					,[ClassRoom] = @ClassRoom
					,[TeacherId] = @TeacherId
					,[Notes] = @Notes
					,[CreateDate] = @CreateDate
					,[UpdateDate] = @UpdateDate
					,[CreateUserId] = @CreateUserId
					,[UpdateUserId] = @UpdateUserId
					,[Active] = @Active
					,[Deleted] = @Deleted
				WHERE
[EducationId] = @EducationId 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_ClientEducation_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_ClientEducation_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_ClientEducation_Delete
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 15 Ocak 2019 Salı

-- Created By:  ()
-- Purpose: Deletes a record in the ClientEducation table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_ClientEducation_Delete
(

	@EducationId int   
)
AS


				DELETE FROM [dbo].[ClientEducation] WITH (ROWLOCK) 
				WHERE
					[EducationId] = @EducationId
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_ClientEducation_GetByClientId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_ClientEducation_GetByClientId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_ClientEducation_GetByClientId
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 15 Ocak 2019 Salı

-- Created By:  ()
-- Purpose: Select records from the ClientEducation table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_ClientEducation_GetByClientId
(

	@ClientId int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[EducationId],
					[ClientId],
					[SchoolId],
					[ClassRoom],
					[TeacherId],
					[Notes],
					[CreateDate],
					[UpdateDate],
					[CreateUserId],
					[UpdateUserId],
					[Active],
					[Deleted]
				FROM
					[dbo].[ClientEducation]
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

	

-- Drop the dbo.sp_ClientEducation_GetBySchoolId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_ClientEducation_GetBySchoolId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_ClientEducation_GetBySchoolId
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 15 Ocak 2019 Salı

-- Created By:  ()
-- Purpose: Select records from the ClientEducation table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_ClientEducation_GetBySchoolId
(

	@SchoolId int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[EducationId],
					[ClientId],
					[SchoolId],
					[ClassRoom],
					[TeacherId],
					[Notes],
					[CreateDate],
					[UpdateDate],
					[CreateUserId],
					[UpdateUserId],
					[Active],
					[Deleted]
				FROM
					[dbo].[ClientEducation]
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

	

-- Drop the dbo.sp_ClientEducation_GetByEducationId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_ClientEducation_GetByEducationId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_ClientEducation_GetByEducationId
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 15 Ocak 2019 Salı

-- Created By:  ()
-- Purpose: Select records from the ClientEducation table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_ClientEducation_GetByEducationId
(

	@EducationId int   
)
AS


				SELECT
					[EducationId],
					[ClientId],
					[SchoolId],
					[ClassRoom],
					[TeacherId],
					[Notes],
					[CreateDate],
					[UpdateDate],
					[CreateUserId],
					[UpdateUserId],
					[Active],
					[Deleted]
				FROM
					[dbo].[ClientEducation]
				WHERE
					[EducationId] = @EducationId
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_ClientEducation_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_ClientEducation_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_ClientEducation_Find
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 15 Ocak 2019 Salı

-- Created By:  ()
-- Purpose: Finds records in the ClientEducation table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_ClientEducation_Find
(

	@SearchUsingOR bit   = null ,

	@EducationId int   = null ,

	@ClientId int   = null ,

	@SchoolId int   = null ,

	@ClassRoom varchar (50)  = null ,

	@TeacherId int   = null ,

	@Notes varchar (500)  = null ,

	@CreateDate datetime   = null ,

	@UpdateDate datetime   = null ,

	@CreateUserId int   = null ,

	@UpdateUserId int   = null ,

	@Active bit   = null ,

	@Deleted bit   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [EducationId]
	, [ClientId]
	, [SchoolId]
	, [ClassRoom]
	, [TeacherId]
	, [Notes]
	, [CreateDate]
	, [UpdateDate]
	, [CreateUserId]
	, [UpdateUserId]
	, [Active]
	, [Deleted]
    FROM
	[dbo].[ClientEducation]
    WHERE 
	 ([EducationId] = @EducationId OR @EducationId IS NULL)
	AND ([ClientId] = @ClientId OR @ClientId IS NULL)
	AND ([SchoolId] = @SchoolId OR @SchoolId IS NULL)
	AND ([ClassRoom] = @ClassRoom OR @ClassRoom IS NULL)
	AND ([TeacherId] = @TeacherId OR @TeacherId IS NULL)
	AND ([Notes] = @Notes OR @Notes IS NULL)
	AND ([CreateDate] = @CreateDate OR @CreateDate IS NULL)
	AND ([UpdateDate] = @UpdateDate OR @UpdateDate IS NULL)
	AND ([CreateUserId] = @CreateUserId OR @CreateUserId IS NULL)
	AND ([UpdateUserId] = @UpdateUserId OR @UpdateUserId IS NULL)
	AND ([Active] = @Active OR @Active IS NULL)
	AND ([Deleted] = @Deleted OR @Deleted IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [EducationId]
	, [ClientId]
	, [SchoolId]
	, [ClassRoom]
	, [TeacherId]
	, [Notes]
	, [CreateDate]
	, [UpdateDate]
	, [CreateUserId]
	, [UpdateUserId]
	, [Active]
	, [Deleted]
    FROM
	[dbo].[ClientEducation]
    WHERE 
	 ([EducationId] = @EducationId AND @EducationId is not null)
	OR ([ClientId] = @ClientId AND @ClientId is not null)
	OR ([SchoolId] = @SchoolId AND @SchoolId is not null)
	OR ([ClassRoom] = @ClassRoom AND @ClassRoom is not null)
	OR ([TeacherId] = @TeacherId AND @TeacherId is not null)
	OR ([Notes] = @Notes AND @Notes is not null)
	OR ([CreateDate] = @CreateDate AND @CreateDate is not null)
	OR ([UpdateDate] = @UpdateDate AND @UpdateDate is not null)
	OR ([CreateUserId] = @CreateUserId AND @CreateUserId is not null)
	OR ([UpdateUserId] = @UpdateUserId AND @UpdateUserId is not null)
	OR ([Active] = @Active AND @Active is not null)
	OR ([Deleted] = @Deleted AND @Deleted is not null)
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
-- Date Created: 15 Ocak 2019 Salı

-- Created By:  ()
-- Purpose: Gets all records from the Area table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Area_Get_List

AS


				
				SELECT
					[AreaId],
					[AreaName],
					[CreateDate],
					[UpdateDate],
					[CreateUserId],
					[UpdateUserId],
					[Active],
					[Deleted]
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
-- Date Created: 15 Ocak 2019 Salı

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
					SET @OrderBy = '[AreaId]'
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
				SET @SQL = @SQL + ', [AreaId]'
				SET @SQL = @SQL + ', [AreaName]'
				SET @SQL = @SQL + ', [CreateDate]'
				SET @SQL = @SQL + ', [UpdateDate]'
				SET @SQL = @SQL + ', [CreateUserId]'
				SET @SQL = @SQL + ', [UpdateUserId]'
				SET @SQL = @SQL + ', [Active]'
				SET @SQL = @SQL + ', [Deleted]'
				SET @SQL = @SQL + ' FROM [dbo].[Area]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [AreaId],'
				SET @SQL = @SQL + ' [AreaName],'
				SET @SQL = @SQL + ' [CreateDate],'
				SET @SQL = @SQL + ' [UpdateDate],'
				SET @SQL = @SQL + ' [CreateUserId],'
				SET @SQL = @SQL + ' [UpdateUserId],'
				SET @SQL = @SQL + ' [Active],'
				SET @SQL = @SQL + ' [Deleted]'
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
-- Date Created: 15 Ocak 2019 Salı

-- Created By:  ()
-- Purpose: Inserts a record into the Area table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Area_Insert
(

	@AreaId int    OUTPUT,

	@AreaName nvarchar (50)  ,

	@CreateDate datetime   ,

	@UpdateDate datetime   ,

	@CreateUserId int   ,

	@UpdateUserId int   ,

	@Active bit   ,

	@Deleted bit   
)
AS


				
				INSERT INTO [dbo].[Area]
					(
					[AreaName]
					,[CreateDate]
					,[UpdateDate]
					,[CreateUserId]
					,[UpdateUserId]
					,[Active]
					,[Deleted]
					)
				VALUES
					(
					@AreaName
					,@CreateDate
					,@UpdateDate
					,@CreateUserId
					,@UpdateUserId
					,@Active
					,@Deleted
					)
				-- Get the identity value
				SET @AreaId = SCOPE_IDENTITY()
									
							
			

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
-- Date Created: 15 Ocak 2019 Salı

-- Created By:  ()
-- Purpose: Updates a record in the Area table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Area_Update
(

	@AreaId int   ,

	@AreaName nvarchar (50)  ,

	@CreateDate datetime   ,

	@UpdateDate datetime   ,

	@CreateUserId int   ,

	@UpdateUserId int   ,

	@Active bit   ,

	@Deleted bit   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[Area]
				SET
					[AreaName] = @AreaName
					,[CreateDate] = @CreateDate
					,[UpdateDate] = @UpdateDate
					,[CreateUserId] = @CreateUserId
					,[UpdateUserId] = @UpdateUserId
					,[Active] = @Active
					,[Deleted] = @Deleted
				WHERE
[AreaId] = @AreaId 
				
			

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
-- Date Created: 15 Ocak 2019 Salı

-- Created By:  ()
-- Purpose: Deletes a record in the Area table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Area_Delete
(

	@AreaId int   
)
AS


				DELETE FROM [dbo].[Area] WITH (ROWLOCK) 
				WHERE
					[AreaId] = @AreaId
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_Area_GetByAreaId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_Area_GetByAreaId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_Area_GetByAreaId
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 15 Ocak 2019 Salı

-- Created By:  ()
-- Purpose: Select records from the Area table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Area_GetByAreaId
(

	@AreaId int   
)
AS


				SELECT
					[AreaId],
					[AreaName],
					[CreateDate],
					[UpdateDate],
					[CreateUserId],
					[UpdateUserId],
					[Active],
					[Deleted]
				FROM
					[dbo].[Area]
				WHERE
					[AreaId] = @AreaId
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
-- Date Created: 15 Ocak 2019 Salı

-- Created By:  ()
-- Purpose: Finds records in the Area table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Area_Find
(

	@SearchUsingOR bit   = null ,

	@AreaId int   = null ,

	@AreaName nvarchar (50)  = null ,

	@CreateDate datetime   = null ,

	@UpdateDate datetime   = null ,

	@CreateUserId int   = null ,

	@UpdateUserId int   = null ,

	@Active bit   = null ,

	@Deleted bit   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [AreaId]
	, [AreaName]
	, [CreateDate]
	, [UpdateDate]
	, [CreateUserId]
	, [UpdateUserId]
	, [Active]
	, [Deleted]
    FROM
	[dbo].[Area]
    WHERE 
	 ([AreaId] = @AreaId OR @AreaId IS NULL)
	AND ([AreaName] = @AreaName OR @AreaName IS NULL)
	AND ([CreateDate] = @CreateDate OR @CreateDate IS NULL)
	AND ([UpdateDate] = @UpdateDate OR @UpdateDate IS NULL)
	AND ([CreateUserId] = @CreateUserId OR @CreateUserId IS NULL)
	AND ([UpdateUserId] = @UpdateUserId OR @UpdateUserId IS NULL)
	AND ([Active] = @Active OR @Active IS NULL)
	AND ([Deleted] = @Deleted OR @Deleted IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [AreaId]
	, [AreaName]
	, [CreateDate]
	, [UpdateDate]
	, [CreateUserId]
	, [UpdateUserId]
	, [Active]
	, [Deleted]
    FROM
	[dbo].[Area]
    WHERE 
	 ([AreaId] = @AreaId AND @AreaId is not null)
	OR ([AreaName] = @AreaName AND @AreaName is not null)
	OR ([CreateDate] = @CreateDate AND @CreateDate is not null)
	OR ([UpdateDate] = @UpdateDate AND @UpdateDate is not null)
	OR ([CreateUserId] = @CreateUserId AND @CreateUserId is not null)
	OR ([UpdateUserId] = @UpdateUserId AND @UpdateUserId is not null)
	OR ([Active] = @Active AND @Active is not null)
	OR ([Deleted] = @Deleted AND @Deleted is not null)
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
-- Date Created: 15 Ocak 2019 Salı

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
					[CreateDate],
					[UpdateDate],
					[CreateUserId],
					[UpdateUserId],
					[Active],
					[Deleted]
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
-- Date Created: 15 Ocak 2019 Salı

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
				SET @SQL = @SQL + ', [CreateDate]'
				SET @SQL = @SQL + ', [UpdateDate]'
				SET @SQL = @SQL + ', [CreateUserId]'
				SET @SQL = @SQL + ', [UpdateUserId]'
				SET @SQL = @SQL + ', [Active]'
				SET @SQL = @SQL + ', [Deleted]'
				SET @SQL = @SQL + ' FROM [dbo].[Job]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [JobId],'
				SET @SQL = @SQL + ' [JobCode],'
				SET @SQL = @SQL + ' [JobName],'
				SET @SQL = @SQL + ' [CreateDate],'
				SET @SQL = @SQL + ' [UpdateDate],'
				SET @SQL = @SQL + ' [CreateUserId],'
				SET @SQL = @SQL + ' [UpdateUserId],'
				SET @SQL = @SQL + ' [Active],'
				SET @SQL = @SQL + ' [Deleted]'
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
-- Date Created: 15 Ocak 2019 Salı

-- Created By:  ()
-- Purpose: Inserts a record into the Job table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Job_Insert
(

	@JobId int    OUTPUT,

	@JobCode varchar (10)  ,

	@JobName nvarchar (255)  ,

	@CreateDate datetime   ,

	@UpdateDate datetime   ,

	@CreateUserId int   ,

	@UpdateUserId int   ,

	@Active bit   ,

	@Deleted bit   
)
AS


				
				INSERT INTO [dbo].[Job]
					(
					[JobCode]
					,[JobName]
					,[CreateDate]
					,[UpdateDate]
					,[CreateUserId]
					,[UpdateUserId]
					,[Active]
					,[Deleted]
					)
				VALUES
					(
					@JobCode
					,@JobName
					,@CreateDate
					,@UpdateDate
					,@CreateUserId
					,@UpdateUserId
					,@Active
					,@Deleted
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
-- Date Created: 15 Ocak 2019 Salı

-- Created By:  ()
-- Purpose: Updates a record in the Job table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Job_Update
(

	@JobId int   ,

	@JobCode varchar (10)  ,

	@JobName nvarchar (255)  ,

	@CreateDate datetime   ,

	@UpdateDate datetime   ,

	@CreateUserId int   ,

	@UpdateUserId int   ,

	@Active bit   ,

	@Deleted bit   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[Job]
				SET
					[JobCode] = @JobCode
					,[JobName] = @JobName
					,[CreateDate] = @CreateDate
					,[UpdateDate] = @UpdateDate
					,[CreateUserId] = @CreateUserId
					,[UpdateUserId] = @UpdateUserId
					,[Active] = @Active
					,[Deleted] = @Deleted
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
-- Date Created: 15 Ocak 2019 Salı

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
-- Date Created: 15 Ocak 2019 Salı

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
					[CreateDate],
					[UpdateDate],
					[CreateUserId],
					[UpdateUserId],
					[Active],
					[Deleted]
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
-- Date Created: 15 Ocak 2019 Salı

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
					[CreateDate],
					[UpdateDate],
					[CreateUserId],
					[UpdateUserId],
					[Active],
					[Deleted]
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
-- Date Created: 15 Ocak 2019 Salı

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

	@CreateDate datetime   = null ,

	@UpdateDate datetime   = null ,

	@CreateUserId int   = null ,

	@UpdateUserId int   = null ,

	@Active bit   = null ,

	@Deleted bit   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [JobId]
	, [JobCode]
	, [JobName]
	, [CreateDate]
	, [UpdateDate]
	, [CreateUserId]
	, [UpdateUserId]
	, [Active]
	, [Deleted]
    FROM
	[dbo].[Job]
    WHERE 
	 ([JobId] = @JobId OR @JobId IS NULL)
	AND ([JobCode] = @JobCode OR @JobCode IS NULL)
	AND ([JobName] = @JobName OR @JobName IS NULL)
	AND ([CreateDate] = @CreateDate OR @CreateDate IS NULL)
	AND ([UpdateDate] = @UpdateDate OR @UpdateDate IS NULL)
	AND ([CreateUserId] = @CreateUserId OR @CreateUserId IS NULL)
	AND ([UpdateUserId] = @UpdateUserId OR @UpdateUserId IS NULL)
	AND ([Active] = @Active OR @Active IS NULL)
	AND ([Deleted] = @Deleted OR @Deleted IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [JobId]
	, [JobCode]
	, [JobName]
	, [CreateDate]
	, [UpdateDate]
	, [CreateUserId]
	, [UpdateUserId]
	, [Active]
	, [Deleted]
    FROM
	[dbo].[Job]
    WHERE 
	 ([JobId] = @JobId AND @JobId is not null)
	OR ([JobCode] = @JobCode AND @JobCode is not null)
	OR ([JobName] = @JobName AND @JobName is not null)
	OR ([CreateDate] = @CreateDate AND @CreateDate is not null)
	OR ([UpdateDate] = @UpdateDate AND @UpdateDate is not null)
	OR ([CreateUserId] = @CreateUserId AND @CreateUserId is not null)
	OR ([UpdateUserId] = @UpdateUserId AND @UpdateUserId is not null)
	OR ([Active] = @Active AND @Active is not null)
	OR ([Deleted] = @Deleted AND @Deleted is not null)
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
-- Date Created: 15 Ocak 2019 Salı

-- Created By:  ()
-- Purpose: Gets all records from the Neighborhood table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Neighborhood_Get_List

AS


				
				SELECT
					[NeighborhoodId],
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
					[UpdateTime],
					[CreateUserId],
					[UpdateUserId],
					[Active],
					[Deleted]
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
-- Date Created: 15 Ocak 2019 Salı

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
					SET @OrderBy = '[NeighborhoodId]'
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
				SET @SQL = @SQL + ', [NeighborhoodId]'
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
				SET @SQL = @SQL + ', [CreateUserId]'
				SET @SQL = @SQL + ', [UpdateUserId]'
				SET @SQL = @SQL + ', [Active]'
				SET @SQL = @SQL + ', [Deleted]'
				SET @SQL = @SQL + ' FROM [dbo].[Neighborhood]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [NeighborhoodId],'
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
				SET @SQL = @SQL + ' [UpdateTime],'
				SET @SQL = @SQL + ' [CreateUserId],'
				SET @SQL = @SQL + ' [UpdateUserId],'
				SET @SQL = @SQL + ' [Active],'
				SET @SQL = @SQL + ' [Deleted]'
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
-- Date Created: 15 Ocak 2019 Salı

-- Created By:  ()
-- Purpose: Inserts a record into the Neighborhood table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Neighborhood_Insert
(

	@NeighborhoodId int    OUTPUT,

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

	@UpdateTime time   ,

	@CreateUserId int   ,

	@UpdateUserId int   ,

	@Active bit   ,

	@Deleted bit   
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
					,[CreateUserId]
					,[UpdateUserId]
					,[Active]
					,[Deleted]
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
					,@CreateUserId
					,@UpdateUserId
					,@Active
					,@Deleted
					)
				-- Get the identity value
				SET @NeighborhoodId = SCOPE_IDENTITY()
									
							
			

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
-- Date Created: 15 Ocak 2019 Salı

-- Created By:  ()
-- Purpose: Updates a record in the Neighborhood table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Neighborhood_Update
(

	@NeighborhoodId int   ,

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

	@UpdateTime time   ,

	@CreateUserId int   ,

	@UpdateUserId int   ,

	@Active bit   ,

	@Deleted bit   
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
					,[CreateUserId] = @CreateUserId
					,[UpdateUserId] = @UpdateUserId
					,[Active] = @Active
					,[Deleted] = @Deleted
				WHERE
[NeighborhoodId] = @NeighborhoodId 
				
			

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
-- Date Created: 15 Ocak 2019 Salı

-- Created By:  ()
-- Purpose: Deletes a record in the Neighborhood table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Neighborhood_Delete
(

	@NeighborhoodId int   
)
AS


				DELETE FROM [dbo].[Neighborhood] WITH (ROWLOCK) 
				WHERE
					[NeighborhoodId] = @NeighborhoodId
					
			

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
-- Date Created: 15 Ocak 2019 Salı

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
					[NeighborhoodId],
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
					[UpdateTime],
					[CreateUserId],
					[UpdateUserId],
					[Active],
					[Deleted]
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

	

-- Drop the dbo.sp_Neighborhood_GetByNeighborhoodId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_Neighborhood_GetByNeighborhoodId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_Neighborhood_GetByNeighborhoodId
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 15 Ocak 2019 Salı

-- Created By:  ()
-- Purpose: Select records from the Neighborhood table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Neighborhood_GetByNeighborhoodId
(

	@NeighborhoodId int   
)
AS


				SELECT
					[NeighborhoodId],
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
					[UpdateTime],
					[CreateUserId],
					[UpdateUserId],
					[Active],
					[Deleted]
				FROM
					[dbo].[Neighborhood]
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

	

-- Drop the dbo.sp_Neighborhood_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_Neighborhood_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_Neighborhood_Find
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 15 Ocak 2019 Salı

-- Created By:  ()
-- Purpose: Finds records in the Neighborhood table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Neighborhood_Find
(

	@SearchUsingOR bit   = null ,

	@NeighborhoodId int   = null ,

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

	@UpdateTime time   = null ,

	@CreateUserId int   = null ,

	@UpdateUserId int   = null ,

	@Active bit   = null ,

	@Deleted bit   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [NeighborhoodId]
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
	, [CreateUserId]
	, [UpdateUserId]
	, [Active]
	, [Deleted]
    FROM
	[dbo].[Neighborhood]
    WHERE 
	 ([NeighborhoodId] = @NeighborhoodId OR @NeighborhoodId IS NULL)
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
	AND ([CreateUserId] = @CreateUserId OR @CreateUserId IS NULL)
	AND ([UpdateUserId] = @UpdateUserId OR @UpdateUserId IS NULL)
	AND ([Active] = @Active OR @Active IS NULL)
	AND ([Deleted] = @Deleted OR @Deleted IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [NeighborhoodId]
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
	, [CreateUserId]
	, [UpdateUserId]
	, [Active]
	, [Deleted]
    FROM
	[dbo].[Neighborhood]
    WHERE 
	 ([NeighborhoodId] = @NeighborhoodId AND @NeighborhoodId is not null)
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
	OR ([CreateUserId] = @CreateUserId AND @CreateUserId is not null)
	OR ([UpdateUserId] = @UpdateUserId AND @UpdateUserId is not null)
	OR ([Active] = @Active AND @Active is not null)
	OR ([Deleted] = @Deleted AND @Deleted is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_QuestionFormOption_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_QuestionFormOption_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_QuestionFormOption_Get_List
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 15 Ocak 2019 Salı

-- Created By:  ()
-- Purpose: Gets all records from the QuestionFormOption table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_QuestionFormOption_Get_List

AS


				
				SELECT
					[OptionId],
					[QuestionId],
					[OptionName],
					[CreateDate],
					[UpdateDate],
					[CreateUserId],
					[UpdateUserId],
					[Active],
					[Deleted]
				FROM
					[dbo].[QuestionFormOption]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_QuestionFormOption_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_QuestionFormOption_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_QuestionFormOption_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 15 Ocak 2019 Salı

-- Created By:  ()
-- Purpose: Gets records from the QuestionFormOption table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_QuestionFormOption_GetPaged
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
				SET @SQL = @SQL + ', [CreateDate]'
				SET @SQL = @SQL + ', [UpdateDate]'
				SET @SQL = @SQL + ', [CreateUserId]'
				SET @SQL = @SQL + ', [UpdateUserId]'
				SET @SQL = @SQL + ', [Active]'
				SET @SQL = @SQL + ', [Deleted]'
				SET @SQL = @SQL + ' FROM [dbo].[QuestionFormOption]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [OptionId],'
				SET @SQL = @SQL + ' [QuestionId],'
				SET @SQL = @SQL + ' [OptionName],'
				SET @SQL = @SQL + ' [CreateDate],'
				SET @SQL = @SQL + ' [UpdateDate],'
				SET @SQL = @SQL + ' [CreateUserId],'
				SET @SQL = @SQL + ' [UpdateUserId],'
				SET @SQL = @SQL + ' [Active],'
				SET @SQL = @SQL + ' [Deleted]'
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
				SET @SQL = @SQL + ' FROM [dbo].[QuestionFormOption]'
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

	

-- Drop the dbo.sp_QuestionFormOption_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_QuestionFormOption_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_QuestionFormOption_Insert
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 15 Ocak 2019 Salı

-- Created By:  ()
-- Purpose: Inserts a record into the QuestionFormOption table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_QuestionFormOption_Insert
(

	@OptionId int    OUTPUT,

	@QuestionId int   ,

	@OptionName varchar (300)  ,

	@CreateDate datetime   ,

	@UpdateDate datetime   ,

	@CreateUserId int   ,

	@UpdateUserId int   ,

	@Active bit   ,

	@Deleted bit   
)
AS


				
				INSERT INTO [dbo].[QuestionFormOption]
					(
					[QuestionId]
					,[OptionName]
					,[CreateDate]
					,[UpdateDate]
					,[CreateUserId]
					,[UpdateUserId]
					,[Active]
					,[Deleted]
					)
				VALUES
					(
					@QuestionId
					,@OptionName
					,@CreateDate
					,@UpdateDate
					,@CreateUserId
					,@UpdateUserId
					,@Active
					,@Deleted
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

	

-- Drop the dbo.sp_QuestionFormOption_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_QuestionFormOption_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_QuestionFormOption_Update
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 15 Ocak 2019 Salı

-- Created By:  ()
-- Purpose: Updates a record in the QuestionFormOption table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_QuestionFormOption_Update
(

	@OptionId int   ,

	@QuestionId int   ,

	@OptionName varchar (300)  ,

	@CreateDate datetime   ,

	@UpdateDate datetime   ,

	@CreateUserId int   ,

	@UpdateUserId int   ,

	@Active bit   ,

	@Deleted bit   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[QuestionFormOption]
				SET
					[QuestionId] = @QuestionId
					,[OptionName] = @OptionName
					,[CreateDate] = @CreateDate
					,[UpdateDate] = @UpdateDate
					,[CreateUserId] = @CreateUserId
					,[UpdateUserId] = @UpdateUserId
					,[Active] = @Active
					,[Deleted] = @Deleted
				WHERE
[OptionId] = @OptionId 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_QuestionFormOption_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_QuestionFormOption_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_QuestionFormOption_Delete
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 15 Ocak 2019 Salı

-- Created By:  ()
-- Purpose: Deletes a record in the QuestionFormOption table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_QuestionFormOption_Delete
(

	@OptionId int   
)
AS


				DELETE FROM [dbo].[QuestionFormOption] WITH (ROWLOCK) 
				WHERE
					[OptionId] = @OptionId
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_QuestionFormOption_GetByQuestionId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_QuestionFormOption_GetByQuestionId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_QuestionFormOption_GetByQuestionId
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 15 Ocak 2019 Salı

-- Created By:  ()
-- Purpose: Select records from the QuestionFormOption table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_QuestionFormOption_GetByQuestionId
(

	@QuestionId int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[OptionId],
					[QuestionId],
					[OptionName],
					[CreateDate],
					[UpdateDate],
					[CreateUserId],
					[UpdateUserId],
					[Active],
					[Deleted]
				FROM
					[dbo].[QuestionFormOption]
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

	

-- Drop the dbo.sp_QuestionFormOption_GetByOptionId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_QuestionFormOption_GetByOptionId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_QuestionFormOption_GetByOptionId
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 15 Ocak 2019 Salı

-- Created By:  ()
-- Purpose: Select records from the QuestionFormOption table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_QuestionFormOption_GetByOptionId
(

	@OptionId int   
)
AS


				SELECT
					[OptionId],
					[QuestionId],
					[OptionName],
					[CreateDate],
					[UpdateDate],
					[CreateUserId],
					[UpdateUserId],
					[Active],
					[Deleted]
				FROM
					[dbo].[QuestionFormOption]
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

	

-- Drop the dbo.sp_QuestionFormOption_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_QuestionFormOption_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_QuestionFormOption_Find
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 15 Ocak 2019 Salı

-- Created By:  ()
-- Purpose: Finds records in the QuestionFormOption table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_QuestionFormOption_Find
(

	@SearchUsingOR bit   = null ,

	@OptionId int   = null ,

	@QuestionId int   = null ,

	@OptionName varchar (300)  = null ,

	@CreateDate datetime   = null ,

	@UpdateDate datetime   = null ,

	@CreateUserId int   = null ,

	@UpdateUserId int   = null ,

	@Active bit   = null ,

	@Deleted bit   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [OptionId]
	, [QuestionId]
	, [OptionName]
	, [CreateDate]
	, [UpdateDate]
	, [CreateUserId]
	, [UpdateUserId]
	, [Active]
	, [Deleted]
    FROM
	[dbo].[QuestionFormOption]
    WHERE 
	 ([OptionId] = @OptionId OR @OptionId IS NULL)
	AND ([QuestionId] = @QuestionId OR @QuestionId IS NULL)
	AND ([OptionName] = @OptionName OR @OptionName IS NULL)
	AND ([CreateDate] = @CreateDate OR @CreateDate IS NULL)
	AND ([UpdateDate] = @UpdateDate OR @UpdateDate IS NULL)
	AND ([CreateUserId] = @CreateUserId OR @CreateUserId IS NULL)
	AND ([UpdateUserId] = @UpdateUserId OR @UpdateUserId IS NULL)
	AND ([Active] = @Active OR @Active IS NULL)
	AND ([Deleted] = @Deleted OR @Deleted IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [OptionId]
	, [QuestionId]
	, [OptionName]
	, [CreateDate]
	, [UpdateDate]
	, [CreateUserId]
	, [UpdateUserId]
	, [Active]
	, [Deleted]
    FROM
	[dbo].[QuestionFormOption]
    WHERE 
	 ([OptionId] = @OptionId AND @OptionId is not null)
	OR ([QuestionId] = @QuestionId AND @QuestionId is not null)
	OR ([OptionName] = @OptionName AND @OptionName is not null)
	OR ([CreateDate] = @CreateDate AND @CreateDate is not null)
	OR ([UpdateDate] = @UpdateDate AND @UpdateDate is not null)
	OR ([CreateUserId] = @CreateUserId AND @CreateUserId is not null)
	OR ([UpdateUserId] = @UpdateUserId AND @UpdateUserId is not null)
	OR ([Active] = @Active AND @Active is not null)
	OR ([Deleted] = @Deleted AND @Deleted is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_QuestionFormAnswer_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_QuestionFormAnswer_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_QuestionFormAnswer_Get_List
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 15 Ocak 2019 Salı

-- Created By:  ()
-- Purpose: Gets all records from the QuestionFormAnswer table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_QuestionFormAnswer_Get_List

AS


				
				SELECT
					[RowId],
					[ClientId],
					[QuestionId],
					[OptionId],
					[Description],
					[CreateDate],
					[UpdateDate],
					[CreateUserId],
					[UpdateUserId],
					[Active],
					[Deleted]
				FROM
					[dbo].[QuestionFormAnswer]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_QuestionFormAnswer_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_QuestionFormAnswer_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_QuestionFormAnswer_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 15 Ocak 2019 Salı

-- Created By:  ()
-- Purpose: Gets records from the QuestionFormAnswer table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_QuestionFormAnswer_GetPaged
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
				SET @SQL = @SQL + ', [Description]'
				SET @SQL = @SQL + ', [CreateDate]'
				SET @SQL = @SQL + ', [UpdateDate]'
				SET @SQL = @SQL + ', [CreateUserId]'
				SET @SQL = @SQL + ', [UpdateUserId]'
				SET @SQL = @SQL + ', [Active]'
				SET @SQL = @SQL + ', [Deleted]'
				SET @SQL = @SQL + ' FROM [dbo].[QuestionFormAnswer]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [RowId],'
				SET @SQL = @SQL + ' [ClientId],'
				SET @SQL = @SQL + ' [QuestionId],'
				SET @SQL = @SQL + ' [OptionId],'
				SET @SQL = @SQL + ' [Description],'
				SET @SQL = @SQL + ' [CreateDate],'
				SET @SQL = @SQL + ' [UpdateDate],'
				SET @SQL = @SQL + ' [CreateUserId],'
				SET @SQL = @SQL + ' [UpdateUserId],'
				SET @SQL = @SQL + ' [Active],'
				SET @SQL = @SQL + ' [Deleted]'
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
				SET @SQL = @SQL + ' FROM [dbo].[QuestionFormAnswer]'
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

	

-- Drop the dbo.sp_QuestionFormAnswer_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_QuestionFormAnswer_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_QuestionFormAnswer_Insert
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 15 Ocak 2019 Salı

-- Created By:  ()
-- Purpose: Inserts a record into the QuestionFormAnswer table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_QuestionFormAnswer_Insert
(

	@RowId int    OUTPUT,

	@ClientId int   ,

	@QuestionId int   ,

	@OptionId int   ,

	@Description nvarchar (MAX)  ,

	@CreateDate datetime   ,

	@UpdateDate datetime   ,

	@CreateUserId int   ,

	@UpdateUserId int   ,

	@Active bit   ,

	@Deleted bit   
)
AS


				
				INSERT INTO [dbo].[QuestionFormAnswer]
					(
					[ClientId]
					,[QuestionId]
					,[OptionId]
					,[Description]
					,[CreateDate]
					,[UpdateDate]
					,[CreateUserId]
					,[UpdateUserId]
					,[Active]
					,[Deleted]
					)
				VALUES
					(
					@ClientId
					,@QuestionId
					,@OptionId
					,@Description
					,@CreateDate
					,@UpdateDate
					,@CreateUserId
					,@UpdateUserId
					,@Active
					,@Deleted
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

	

-- Drop the dbo.sp_QuestionFormAnswer_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_QuestionFormAnswer_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_QuestionFormAnswer_Update
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 15 Ocak 2019 Salı

-- Created By:  ()
-- Purpose: Updates a record in the QuestionFormAnswer table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_QuestionFormAnswer_Update
(

	@RowId int   ,

	@ClientId int   ,

	@QuestionId int   ,

	@OptionId int   ,

	@Description nvarchar (MAX)  ,

	@CreateDate datetime   ,

	@UpdateDate datetime   ,

	@CreateUserId int   ,

	@UpdateUserId int   ,

	@Active bit   ,

	@Deleted bit   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[QuestionFormAnswer]
				SET
					[ClientId] = @ClientId
					,[QuestionId] = @QuestionId
					,[OptionId] = @OptionId
					,[Description] = @Description
					,[CreateDate] = @CreateDate
					,[UpdateDate] = @UpdateDate
					,[CreateUserId] = @CreateUserId
					,[UpdateUserId] = @UpdateUserId
					,[Active] = @Active
					,[Deleted] = @Deleted
				WHERE
[RowId] = @RowId 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_QuestionFormAnswer_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_QuestionFormAnswer_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_QuestionFormAnswer_Delete
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 15 Ocak 2019 Salı

-- Created By:  ()
-- Purpose: Deletes a record in the QuestionFormAnswer table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_QuestionFormAnswer_Delete
(

	@RowId int   
)
AS


				DELETE FROM [dbo].[QuestionFormAnswer] WITH (ROWLOCK) 
				WHERE
					[RowId] = @RowId
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.sp_QuestionFormAnswer_GetByClientId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_QuestionFormAnswer_GetByClientId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_QuestionFormAnswer_GetByClientId
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 15 Ocak 2019 Salı

-- Created By:  ()
-- Purpose: Select records from the QuestionFormAnswer table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_QuestionFormAnswer_GetByClientId
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
					[Description],
					[CreateDate],
					[UpdateDate],
					[CreateUserId],
					[UpdateUserId],
					[Active],
					[Deleted]
				FROM
					[dbo].[QuestionFormAnswer]
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

	

-- Drop the dbo.sp_QuestionFormAnswer_GetByQuestionId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_QuestionFormAnswer_GetByQuestionId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_QuestionFormAnswer_GetByQuestionId
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 15 Ocak 2019 Salı

-- Created By:  ()
-- Purpose: Select records from the QuestionFormAnswer table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_QuestionFormAnswer_GetByQuestionId
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
					[Description],
					[CreateDate],
					[UpdateDate],
					[CreateUserId],
					[UpdateUserId],
					[Active],
					[Deleted]
				FROM
					[dbo].[QuestionFormAnswer]
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

	

-- Drop the dbo.sp_QuestionFormAnswer_GetByOptionId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_QuestionFormAnswer_GetByOptionId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_QuestionFormAnswer_GetByOptionId
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 15 Ocak 2019 Salı

-- Created By:  ()
-- Purpose: Select records from the QuestionFormAnswer table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_QuestionFormAnswer_GetByOptionId
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
					[Description],
					[CreateDate],
					[UpdateDate],
					[CreateUserId],
					[UpdateUserId],
					[Active],
					[Deleted]
				FROM
					[dbo].[QuestionFormAnswer]
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

	

-- Drop the dbo.sp_QuestionFormAnswer_GetByRowId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_QuestionFormAnswer_GetByRowId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_QuestionFormAnswer_GetByRowId
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 15 Ocak 2019 Salı

-- Created By:  ()
-- Purpose: Select records from the QuestionFormAnswer table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_QuestionFormAnswer_GetByRowId
(

	@RowId int   
)
AS


				SELECT
					[RowId],
					[ClientId],
					[QuestionId],
					[OptionId],
					[Description],
					[CreateDate],
					[UpdateDate],
					[CreateUserId],
					[UpdateUserId],
					[Active],
					[Deleted]
				FROM
					[dbo].[QuestionFormAnswer]
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

	

-- Drop the dbo.sp_QuestionFormAnswer_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_QuestionFormAnswer_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_QuestionFormAnswer_Find
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 15 Ocak 2019 Salı

-- Created By:  ()
-- Purpose: Finds records in the QuestionFormAnswer table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_QuestionFormAnswer_Find
(

	@SearchUsingOR bit   = null ,

	@RowId int   = null ,

	@ClientId int   = null ,

	@QuestionId int   = null ,

	@OptionId int   = null ,

	@Description nvarchar (MAX)  = null ,

	@CreateDate datetime   = null ,

	@UpdateDate datetime   = null ,

	@CreateUserId int   = null ,

	@UpdateUserId int   = null ,

	@Active bit   = null ,

	@Deleted bit   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [RowId]
	, [ClientId]
	, [QuestionId]
	, [OptionId]
	, [Description]
	, [CreateDate]
	, [UpdateDate]
	, [CreateUserId]
	, [UpdateUserId]
	, [Active]
	, [Deleted]
    FROM
	[dbo].[QuestionFormAnswer]
    WHERE 
	 ([RowId] = @RowId OR @RowId IS NULL)
	AND ([ClientId] = @ClientId OR @ClientId IS NULL)
	AND ([QuestionId] = @QuestionId OR @QuestionId IS NULL)
	AND ([OptionId] = @OptionId OR @OptionId IS NULL)
	AND ([Description] = @Description OR @Description IS NULL)
	AND ([CreateDate] = @CreateDate OR @CreateDate IS NULL)
	AND ([UpdateDate] = @UpdateDate OR @UpdateDate IS NULL)
	AND ([CreateUserId] = @CreateUserId OR @CreateUserId IS NULL)
	AND ([UpdateUserId] = @UpdateUserId OR @UpdateUserId IS NULL)
	AND ([Active] = @Active OR @Active IS NULL)
	AND ([Deleted] = @Deleted OR @Deleted IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [RowId]
	, [ClientId]
	, [QuestionId]
	, [OptionId]
	, [Description]
	, [CreateDate]
	, [UpdateDate]
	, [CreateUserId]
	, [UpdateUserId]
	, [Active]
	, [Deleted]
    FROM
	[dbo].[QuestionFormAnswer]
    WHERE 
	 ([RowId] = @RowId AND @RowId is not null)
	OR ([ClientId] = @ClientId AND @ClientId is not null)
	OR ([QuestionId] = @QuestionId AND @QuestionId is not null)
	OR ([OptionId] = @OptionId AND @OptionId is not null)
	OR ([Description] = @Description AND @Description is not null)
	OR ([CreateDate] = @CreateDate AND @CreateDate is not null)
	OR ([UpdateDate] = @UpdateDate AND @UpdateDate is not null)
	OR ([CreateUserId] = @CreateUserId AND @CreateUserId is not null)
	OR ([UpdateUserId] = @UpdateUserId AND @UpdateUserId is not null)
	OR ([Active] = @Active AND @Active is not null)
	OR ([Deleted] = @Deleted AND @Deleted is not null)
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
-- Date Created: 15 Ocak 2019 Salı

-- Created By:  ()
-- Purpose: Gets all records from the ObservationForm_Group table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_ObservationForm_Group_Get_List

AS


				
				SELECT
					[GroupId],
					[GroupName],
					[LineNumber],
					[CreateDate],
					[UpdateDate],
					[CreateUserId],
					[UpdateUserId],
					[Active],
					[Deleted]
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
-- Date Created: 15 Ocak 2019 Salı

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
					SET @OrderBy = '[GroupId]'
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
				SET @SQL = @SQL + ', [GroupId]'
				SET @SQL = @SQL + ', [GroupName]'
				SET @SQL = @SQL + ', [LineNumber]'
				SET @SQL = @SQL + ', [CreateDate]'
				SET @SQL = @SQL + ', [UpdateDate]'
				SET @SQL = @SQL + ', [CreateUserId]'
				SET @SQL = @SQL + ', [UpdateUserId]'
				SET @SQL = @SQL + ', [Active]'
				SET @SQL = @SQL + ', [Deleted]'
				SET @SQL = @SQL + ' FROM [dbo].[ObservationForm_Group]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [GroupId],'
				SET @SQL = @SQL + ' [GroupName],'
				SET @SQL = @SQL + ' [LineNumber],'
				SET @SQL = @SQL + ' [CreateDate],'
				SET @SQL = @SQL + ' [UpdateDate],'
				SET @SQL = @SQL + ' [CreateUserId],'
				SET @SQL = @SQL + ' [UpdateUserId],'
				SET @SQL = @SQL + ' [Active],'
				SET @SQL = @SQL + ' [Deleted]'
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
-- Date Created: 15 Ocak 2019 Salı

-- Created By:  ()
-- Purpose: Inserts a record into the ObservationForm_Group table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_ObservationForm_Group_Insert
(

	@GroupId int    OUTPUT,

	@GroupName varchar (250)  ,

	@LineNumber int   ,

	@CreateDate datetime   ,

	@UpdateDate datetime   ,

	@CreateUserId int   ,

	@UpdateUserId int   ,

	@Active bit   ,

	@Deleted bit   
)
AS


				
				INSERT INTO [dbo].[ObservationForm_Group]
					(
					[GroupName]
					,[LineNumber]
					,[CreateDate]
					,[UpdateDate]
					,[CreateUserId]
					,[UpdateUserId]
					,[Active]
					,[Deleted]
					)
				VALUES
					(
					@GroupName
					,@LineNumber
					,@CreateDate
					,@UpdateDate
					,@CreateUserId
					,@UpdateUserId
					,@Active
					,@Deleted
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
-- Date Created: 15 Ocak 2019 Salı

-- Created By:  ()
-- Purpose: Updates a record in the ObservationForm_Group table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_ObservationForm_Group_Update
(

	@GroupId int   ,

	@GroupName varchar (250)  ,

	@LineNumber int   ,

	@CreateDate datetime   ,

	@UpdateDate datetime   ,

	@CreateUserId int   ,

	@UpdateUserId int   ,

	@Active bit   ,

	@Deleted bit   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[ObservationForm_Group]
				SET
					[GroupName] = @GroupName
					,[LineNumber] = @LineNumber
					,[CreateDate] = @CreateDate
					,[UpdateDate] = @UpdateDate
					,[CreateUserId] = @CreateUserId
					,[UpdateUserId] = @UpdateUserId
					,[Active] = @Active
					,[Deleted] = @Deleted
				WHERE
[GroupId] = @GroupId 
				
			

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
-- Date Created: 15 Ocak 2019 Salı

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
					[GroupId] = @GroupId
					
			

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
-- Date Created: 15 Ocak 2019 Salı

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
					[GroupId],
					[GroupName],
					[LineNumber],
					[CreateDate],
					[UpdateDate],
					[CreateUserId],
					[UpdateUserId],
					[Active],
					[Deleted]
				FROM
					[dbo].[ObservationForm_Group]
				WHERE
					[GroupId] = @GroupId
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
-- Date Created: 15 Ocak 2019 Salı

-- Created By:  ()
-- Purpose: Finds records in the ObservationForm_Group table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_ObservationForm_Group_Find
(

	@SearchUsingOR bit   = null ,

	@GroupId int   = null ,

	@GroupName varchar (250)  = null ,

	@LineNumber int   = null ,

	@CreateDate datetime   = null ,

	@UpdateDate datetime   = null ,

	@CreateUserId int   = null ,

	@UpdateUserId int   = null ,

	@Active bit   = null ,

	@Deleted bit   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [GroupId]
	, [GroupName]
	, [LineNumber]
	, [CreateDate]
	, [UpdateDate]
	, [CreateUserId]
	, [UpdateUserId]
	, [Active]
	, [Deleted]
    FROM
	[dbo].[ObservationForm_Group]
    WHERE 
	 ([GroupId] = @GroupId OR @GroupId IS NULL)
	AND ([GroupName] = @GroupName OR @GroupName IS NULL)
	AND ([LineNumber] = @LineNumber OR @LineNumber IS NULL)
	AND ([CreateDate] = @CreateDate OR @CreateDate IS NULL)
	AND ([UpdateDate] = @UpdateDate OR @UpdateDate IS NULL)
	AND ([CreateUserId] = @CreateUserId OR @CreateUserId IS NULL)
	AND ([UpdateUserId] = @UpdateUserId OR @UpdateUserId IS NULL)
	AND ([Active] = @Active OR @Active IS NULL)
	AND ([Deleted] = @Deleted OR @Deleted IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [GroupId]
	, [GroupName]
	, [LineNumber]
	, [CreateDate]
	, [UpdateDate]
	, [CreateUserId]
	, [UpdateUserId]
	, [Active]
	, [Deleted]
    FROM
	[dbo].[ObservationForm_Group]
    WHERE 
	 ([GroupId] = @GroupId AND @GroupId is not null)
	OR ([GroupName] = @GroupName AND @GroupName is not null)
	OR ([LineNumber] = @LineNumber AND @LineNumber is not null)
	OR ([CreateDate] = @CreateDate AND @CreateDate is not null)
	OR ([UpdateDate] = @UpdateDate AND @UpdateDate is not null)
	OR ([CreateUserId] = @CreateUserId AND @CreateUserId is not null)
	OR ([UpdateUserId] = @UpdateUserId AND @UpdateUserId is not null)
	OR ([Active] = @Active AND @Active is not null)
	OR ([Deleted] = @Deleted AND @Deleted is not null)
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
-- Date Created: 15 Ocak 2019 Salı

-- Created By:  ()
-- Purpose: Gets all records from the ObservationForm table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_ObservationForm_Get_List

AS


				
				SELECT
					[QuestionId],
					[GroupId],
					[QuestionRef],
					[QuestionName],
					[LineNumber],
					[Status],
					[CreateUserId],
					[UpdateUserId],
					[Active],
					[Deleted]
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
-- Date Created: 15 Ocak 2019 Salı

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
				SET @SQL = @SQL + ', [GroupId]'
				SET @SQL = @SQL + ', [QuestionRef]'
				SET @SQL = @SQL + ', [QuestionName]'
				SET @SQL = @SQL + ', [LineNumber]'
				SET @SQL = @SQL + ', [Status]'
				SET @SQL = @SQL + ', [CreateUserId]'
				SET @SQL = @SQL + ', [UpdateUserId]'
				SET @SQL = @SQL + ', [Active]'
				SET @SQL = @SQL + ', [Deleted]'
				SET @SQL = @SQL + ' FROM [dbo].[ObservationForm]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [QuestionId],'
				SET @SQL = @SQL + ' [GroupId],'
				SET @SQL = @SQL + ' [QuestionRef],'
				SET @SQL = @SQL + ' [QuestionName],'
				SET @SQL = @SQL + ' [LineNumber],'
				SET @SQL = @SQL + ' [Status],'
				SET @SQL = @SQL + ' [CreateUserId],'
				SET @SQL = @SQL + ' [UpdateUserId],'
				SET @SQL = @SQL + ' [Active],'
				SET @SQL = @SQL + ' [Deleted]'
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
-- Date Created: 15 Ocak 2019 Salı

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

	@Status bit   ,

	@CreateUserId int   ,

	@UpdateUserId int   ,

	@Active bit   ,

	@Deleted bit   
)
AS


				
				INSERT INTO [dbo].[ObservationForm]
					(
					[GroupId]
					,[QuestionRef]
					,[QuestionName]
					,[LineNumber]
					,[Status]
					,[CreateUserId]
					,[UpdateUserId]
					,[Active]
					,[Deleted]
					)
				VALUES
					(
					@GroupId
					,@QuestionRef
					,@QuestionName
					,@LineNumber
					,@Status
					,@CreateUserId
					,@UpdateUserId
					,@Active
					,@Deleted
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
-- Date Created: 15 Ocak 2019 Salı

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

	@Status bit   ,

	@CreateUserId int   ,

	@UpdateUserId int   ,

	@Active bit   ,

	@Deleted bit   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[ObservationForm]
				SET
					[GroupId] = @GroupId
					,[QuestionRef] = @QuestionRef
					,[QuestionName] = @QuestionName
					,[LineNumber] = @LineNumber
					,[Status] = @Status
					,[CreateUserId] = @CreateUserId
					,[UpdateUserId] = @UpdateUserId
					,[Active] = @Active
					,[Deleted] = @Deleted
				WHERE
[QuestionId] = @QuestionId 
				
			

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
-- Date Created: 15 Ocak 2019 Salı

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
					[QuestionId] = @QuestionId
					
			

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
-- Date Created: 15 Ocak 2019 Salı

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
					[QuestionId],
					[GroupId],
					[QuestionRef],
					[QuestionName],
					[LineNumber],
					[Status],
					[CreateUserId],
					[UpdateUserId],
					[Active],
					[Deleted]
				FROM
					[dbo].[ObservationForm]
				WHERE
					[GroupId] = @GroupId
				
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
-- Date Created: 15 Ocak 2019 Salı

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
					[QuestionId],
					[GroupId],
					[QuestionRef],
					[QuestionName],
					[LineNumber],
					[Status],
					[CreateUserId],
					[UpdateUserId],
					[Active],
					[Deleted]
				FROM
					[dbo].[ObservationForm]
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

	

-- Drop the dbo.sp_ObservationForm_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_ObservationForm_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_ObservationForm_Find
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 15 Ocak 2019 Salı

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

	@Status bit   = null ,

	@CreateUserId int   = null ,

	@UpdateUserId int   = null ,

	@Active bit   = null ,

	@Deleted bit   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [QuestionId]
	, [GroupId]
	, [QuestionRef]
	, [QuestionName]
	, [LineNumber]
	, [Status]
	, [CreateUserId]
	, [UpdateUserId]
	, [Active]
	, [Deleted]
    FROM
	[dbo].[ObservationForm]
    WHERE 
	 ([QuestionId] = @QuestionId OR @QuestionId IS NULL)
	AND ([GroupId] = @GroupId OR @GroupId IS NULL)
	AND ([QuestionRef] = @QuestionRef OR @QuestionRef IS NULL)
	AND ([QuestionName] = @QuestionName OR @QuestionName IS NULL)
	AND ([LineNumber] = @LineNumber OR @LineNumber IS NULL)
	AND ([Status] = @Status OR @Status IS NULL)
	AND ([CreateUserId] = @CreateUserId OR @CreateUserId IS NULL)
	AND ([UpdateUserId] = @UpdateUserId OR @UpdateUserId IS NULL)
	AND ([Active] = @Active OR @Active IS NULL)
	AND ([Deleted] = @Deleted OR @Deleted IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [QuestionId]
	, [GroupId]
	, [QuestionRef]
	, [QuestionName]
	, [LineNumber]
	, [Status]
	, [CreateUserId]
	, [UpdateUserId]
	, [Active]
	, [Deleted]
    FROM
	[dbo].[ObservationForm]
    WHERE 
	 ([QuestionId] = @QuestionId AND @QuestionId is not null)
	OR ([GroupId] = @GroupId AND @GroupId is not null)
	OR ([QuestionRef] = @QuestionRef AND @QuestionRef is not null)
	OR ([QuestionName] = @QuestionName AND @QuestionName is not null)
	OR ([LineNumber] = @LineNumber AND @LineNumber is not null)
	OR ([Status] = @Status AND @Status is not null)
	OR ([CreateUserId] = @CreateUserId AND @CreateUserId is not null)
	OR ([UpdateUserId] = @UpdateUserId AND @UpdateUserId is not null)
	OR ([Active] = @Active AND @Active is not null)
	OR ([Deleted] = @Deleted AND @Deleted is not null)
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
-- Date Created: 15 Ocak 2019 Salı

-- Created By:  ()
-- Purpose: Gets all records from the ObservationForm_Option table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_ObservationForm_Option_Get_List

AS


				
				SELECT
					[OptionId],
					[QuestionId],
					[OptionName],
					[CreateDate],
					[UpdateDate],
					[CreateUserId],
					[UpdateUserId],
					[Active],
					[Deleted]
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
-- Date Created: 15 Ocak 2019 Salı

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
				SET @SQL = @SQL + ', [CreateDate]'
				SET @SQL = @SQL + ', [UpdateDate]'
				SET @SQL = @SQL + ', [CreateUserId]'
				SET @SQL = @SQL + ', [UpdateUserId]'
				SET @SQL = @SQL + ', [Active]'
				SET @SQL = @SQL + ', [Deleted]'
				SET @SQL = @SQL + ' FROM [dbo].[ObservationForm_Option]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [OptionId],'
				SET @SQL = @SQL + ' [QuestionId],'
				SET @SQL = @SQL + ' [OptionName],'
				SET @SQL = @SQL + ' [CreateDate],'
				SET @SQL = @SQL + ' [UpdateDate],'
				SET @SQL = @SQL + ' [CreateUserId],'
				SET @SQL = @SQL + ' [UpdateUserId],'
				SET @SQL = @SQL + ' [Active],'
				SET @SQL = @SQL + ' [Deleted]'
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
-- Date Created: 15 Ocak 2019 Salı

-- Created By:  ()
-- Purpose: Inserts a record into the ObservationForm_Option table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_ObservationForm_Option_Insert
(

	@OptionId int    OUTPUT,

	@QuestionId int   ,

	@OptionName varchar (300)  ,

	@CreateDate datetime   ,

	@UpdateDate datetime   ,

	@CreateUserId int   ,

	@UpdateUserId int   ,

	@Active bit   ,

	@Deleted bit   
)
AS


				
				INSERT INTO [dbo].[ObservationForm_Option]
					(
					[QuestionId]
					,[OptionName]
					,[CreateDate]
					,[UpdateDate]
					,[CreateUserId]
					,[UpdateUserId]
					,[Active]
					,[Deleted]
					)
				VALUES
					(
					@QuestionId
					,@OptionName
					,@CreateDate
					,@UpdateDate
					,@CreateUserId
					,@UpdateUserId
					,@Active
					,@Deleted
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
-- Date Created: 15 Ocak 2019 Salı

-- Created By:  ()
-- Purpose: Updates a record in the ObservationForm_Option table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_ObservationForm_Option_Update
(

	@OptionId int   ,

	@QuestionId int   ,

	@OptionName varchar (300)  ,

	@CreateDate datetime   ,

	@UpdateDate datetime   ,

	@CreateUserId int   ,

	@UpdateUserId int   ,

	@Active bit   ,

	@Deleted bit   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[ObservationForm_Option]
				SET
					[QuestionId] = @QuestionId
					,[OptionName] = @OptionName
					,[CreateDate] = @CreateDate
					,[UpdateDate] = @UpdateDate
					,[CreateUserId] = @CreateUserId
					,[UpdateUserId] = @UpdateUserId
					,[Active] = @Active
					,[Deleted] = @Deleted
				WHERE
[OptionId] = @OptionId 
				
			

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
-- Date Created: 15 Ocak 2019 Salı

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
					[OptionId] = @OptionId
					
			

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
-- Date Created: 15 Ocak 2019 Salı

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
					[OptionId],
					[QuestionId],
					[OptionName],
					[CreateDate],
					[UpdateDate],
					[CreateUserId],
					[UpdateUserId],
					[Active],
					[Deleted]
				FROM
					[dbo].[ObservationForm_Option]
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

	

-- Drop the dbo.sp_ObservationForm_Option_GetByOptionId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_ObservationForm_Option_GetByOptionId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_ObservationForm_Option_GetByOptionId
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 15 Ocak 2019 Salı

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
					[OptionId],
					[QuestionId],
					[OptionName],
					[CreateDate],
					[UpdateDate],
					[CreateUserId],
					[UpdateUserId],
					[Active],
					[Deleted]
				FROM
					[dbo].[ObservationForm_Option]
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

	

-- Drop the dbo.sp_ObservationForm_Option_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_ObservationForm_Option_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_ObservationForm_Option_Find
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 15 Ocak 2019 Salı

-- Created By:  ()
-- Purpose: Finds records in the ObservationForm_Option table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_ObservationForm_Option_Find
(

	@SearchUsingOR bit   = null ,

	@OptionId int   = null ,

	@QuestionId int   = null ,

	@OptionName varchar (300)  = null ,

	@CreateDate datetime   = null ,

	@UpdateDate datetime   = null ,

	@CreateUserId int   = null ,

	@UpdateUserId int   = null ,

	@Active bit   = null ,

	@Deleted bit   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [OptionId]
	, [QuestionId]
	, [OptionName]
	, [CreateDate]
	, [UpdateDate]
	, [CreateUserId]
	, [UpdateUserId]
	, [Active]
	, [Deleted]
    FROM
	[dbo].[ObservationForm_Option]
    WHERE 
	 ([OptionId] = @OptionId OR @OptionId IS NULL)
	AND ([QuestionId] = @QuestionId OR @QuestionId IS NULL)
	AND ([OptionName] = @OptionName OR @OptionName IS NULL)
	AND ([CreateDate] = @CreateDate OR @CreateDate IS NULL)
	AND ([UpdateDate] = @UpdateDate OR @UpdateDate IS NULL)
	AND ([CreateUserId] = @CreateUserId OR @CreateUserId IS NULL)
	AND ([UpdateUserId] = @UpdateUserId OR @UpdateUserId IS NULL)
	AND ([Active] = @Active OR @Active IS NULL)
	AND ([Deleted] = @Deleted OR @Deleted IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [OptionId]
	, [QuestionId]
	, [OptionName]
	, [CreateDate]
	, [UpdateDate]
	, [CreateUserId]
	, [UpdateUserId]
	, [Active]
	, [Deleted]
    FROM
	[dbo].[ObservationForm_Option]
    WHERE 
	 ([OptionId] = @OptionId AND @OptionId is not null)
	OR ([QuestionId] = @QuestionId AND @QuestionId is not null)
	OR ([OptionName] = @OptionName AND @OptionName is not null)
	OR ([CreateDate] = @CreateDate AND @CreateDate is not null)
	OR ([UpdateDate] = @UpdateDate AND @UpdateDate is not null)
	OR ([CreateUserId] = @CreateUserId AND @CreateUserId is not null)
	OR ([UpdateUserId] = @UpdateUserId AND @UpdateUserId is not null)
	OR ([Active] = @Active AND @Active is not null)
	OR ([Deleted] = @Deleted AND @Deleted is not null)
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
-- Date Created: 15 Ocak 2019 Salı

-- Created By:  ()
-- Purpose: Gets all records from the ObservationForm_Answer table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_ObservationForm_Answer_Get_List

AS


				
				SELECT
					[RowId],
					[ClientId],
					[QuestionId],
					[OptionId],
					[Description],
					[CreateDate],
					[UpdateDate],
					[CreateUserId],
					[UpdateUserId],
					[Active],
					[Deleted]
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
-- Date Created: 15 Ocak 2019 Salı

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
				SET @SQL = @SQL + ', [Description]'
				SET @SQL = @SQL + ', [CreateDate]'
				SET @SQL = @SQL + ', [UpdateDate]'
				SET @SQL = @SQL + ', [CreateUserId]'
				SET @SQL = @SQL + ', [UpdateUserId]'
				SET @SQL = @SQL + ', [Active]'
				SET @SQL = @SQL + ', [Deleted]'
				SET @SQL = @SQL + ' FROM [dbo].[ObservationForm_Answer]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [RowId],'
				SET @SQL = @SQL + ' [ClientId],'
				SET @SQL = @SQL + ' [QuestionId],'
				SET @SQL = @SQL + ' [OptionId],'
				SET @SQL = @SQL + ' [Description],'
				SET @SQL = @SQL + ' [CreateDate],'
				SET @SQL = @SQL + ' [UpdateDate],'
				SET @SQL = @SQL + ' [CreateUserId],'
				SET @SQL = @SQL + ' [UpdateUserId],'
				SET @SQL = @SQL + ' [Active],'
				SET @SQL = @SQL + ' [Deleted]'
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
-- Date Created: 15 Ocak 2019 Salı

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

	@CreateDate datetime   ,

	@UpdateDate datetime   ,

	@CreateUserId int   ,

	@UpdateUserId int   ,

	@Active bit   ,

	@Deleted bit   
)
AS


				
				INSERT INTO [dbo].[ObservationForm_Answer]
					(
					[ClientId]
					,[QuestionId]
					,[OptionId]
					,[Description]
					,[CreateDate]
					,[UpdateDate]
					,[CreateUserId]
					,[UpdateUserId]
					,[Active]
					,[Deleted]
					)
				VALUES
					(
					@ClientId
					,@QuestionId
					,@OptionId
					,@Description
					,@CreateDate
					,@UpdateDate
					,@CreateUserId
					,@UpdateUserId
					,@Active
					,@Deleted
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
-- Date Created: 15 Ocak 2019 Salı

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

	@CreateDate datetime   ,

	@UpdateDate datetime   ,

	@CreateUserId int   ,

	@UpdateUserId int   ,

	@Active bit   ,

	@Deleted bit   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[ObservationForm_Answer]
				SET
					[ClientId] = @ClientId
					,[QuestionId] = @QuestionId
					,[OptionId] = @OptionId
					,[Description] = @Description
					,[CreateDate] = @CreateDate
					,[UpdateDate] = @UpdateDate
					,[CreateUserId] = @CreateUserId
					,[UpdateUserId] = @UpdateUserId
					,[Active] = @Active
					,[Deleted] = @Deleted
				WHERE
[RowId] = @RowId 
				
			

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
-- Date Created: 15 Ocak 2019 Salı

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
					[RowId] = @RowId
					
			

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
-- Date Created: 15 Ocak 2019 Salı

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
					[RowId],
					[ClientId],
					[QuestionId],
					[OptionId],
					[Description],
					[CreateDate],
					[UpdateDate],
					[CreateUserId],
					[UpdateUserId],
					[Active],
					[Deleted]
				FROM
					[dbo].[ObservationForm_Answer]
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

	

-- Drop the dbo.sp_ObservationForm_Answer_GetByQuestionId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_ObservationForm_Answer_GetByQuestionId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_ObservationForm_Answer_GetByQuestionId
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 15 Ocak 2019 Salı

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
					[RowId],
					[ClientId],
					[QuestionId],
					[OptionId],
					[Description],
					[CreateDate],
					[UpdateDate],
					[CreateUserId],
					[UpdateUserId],
					[Active],
					[Deleted]
				FROM
					[dbo].[ObservationForm_Answer]
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

	

-- Drop the dbo.sp_ObservationForm_Answer_GetByOptionId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_ObservationForm_Answer_GetByOptionId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_ObservationForm_Answer_GetByOptionId
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 15 Ocak 2019 Salı

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
					[RowId],
					[ClientId],
					[QuestionId],
					[OptionId],
					[Description],
					[CreateDate],
					[UpdateDate],
					[CreateUserId],
					[UpdateUserId],
					[Active],
					[Deleted]
				FROM
					[dbo].[ObservationForm_Answer]
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

	

-- Drop the dbo.sp_ObservationForm_Answer_GetByRowId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_ObservationForm_Answer_GetByRowId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_ObservationForm_Answer_GetByRowId
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 15 Ocak 2019 Salı

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
					[RowId],
					[ClientId],
					[QuestionId],
					[OptionId],
					[Description],
					[CreateDate],
					[UpdateDate],
					[CreateUserId],
					[UpdateUserId],
					[Active],
					[Deleted]
				FROM
					[dbo].[ObservationForm_Answer]
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

	

-- Drop the dbo.sp_ObservationForm_Answer_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.sp_ObservationForm_Answer_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.sp_ObservationForm_Answer_Find
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: 15 Ocak 2019 Salı

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

	@CreateDate datetime   = null ,

	@UpdateDate datetime   = null ,

	@CreateUserId int   = null ,

	@UpdateUserId int   = null ,

	@Active bit   = null ,

	@Deleted bit   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [RowId]
	, [ClientId]
	, [QuestionId]
	, [OptionId]
	, [Description]
	, [CreateDate]
	, [UpdateDate]
	, [CreateUserId]
	, [UpdateUserId]
	, [Active]
	, [Deleted]
    FROM
	[dbo].[ObservationForm_Answer]
    WHERE 
	 ([RowId] = @RowId OR @RowId IS NULL)
	AND ([ClientId] = @ClientId OR @ClientId IS NULL)
	AND ([QuestionId] = @QuestionId OR @QuestionId IS NULL)
	AND ([OptionId] = @OptionId OR @OptionId IS NULL)
	AND ([Description] = @Description OR @Description IS NULL)
	AND ([CreateDate] = @CreateDate OR @CreateDate IS NULL)
	AND ([UpdateDate] = @UpdateDate OR @UpdateDate IS NULL)
	AND ([CreateUserId] = @CreateUserId OR @CreateUserId IS NULL)
	AND ([UpdateUserId] = @UpdateUserId OR @UpdateUserId IS NULL)
	AND ([Active] = @Active OR @Active IS NULL)
	AND ([Deleted] = @Deleted OR @Deleted IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [RowId]
	, [ClientId]
	, [QuestionId]
	, [OptionId]
	, [Description]
	, [CreateDate]
	, [UpdateDate]
	, [CreateUserId]
	, [UpdateUserId]
	, [Active]
	, [Deleted]
    FROM
	[dbo].[ObservationForm_Answer]
    WHERE 
	 ([RowId] = @RowId AND @RowId is not null)
	OR ([ClientId] = @ClientId AND @ClientId is not null)
	OR ([QuestionId] = @QuestionId AND @QuestionId is not null)
	OR ([OptionId] = @OptionId AND @OptionId is not null)
	OR ([Description] = @Description AND @Description is not null)
	OR ([CreateDate] = @CreateDate AND @CreateDate is not null)
	OR ([UpdateDate] = @UpdateDate AND @UpdateDate is not null)
	OR ([CreateUserId] = @CreateUserId AND @CreateUserId is not null)
	OR ([UpdateUserId] = @UpdateUserId AND @UpdateUserId is not null)
	OR ([Active] = @Active AND @Active is not null)
	OR ([Deleted] = @Deleted AND @Deleted is not null)
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
-- Date Created: 15 Ocak 2019 Salı

-- Created By:  ()
-- Purpose: Gets all records from the Wiscr table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Wiscr_Get_List

AS


				
				SELECT
					[WiscrId],
					[SeanceId],
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
					[Notes],
					[TestDate],
					[CreateDate],
					[UpdateDate],
					[CreateUserId],
					[UpdateUserId],
					[Active],
					[Deleted]
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
-- Date Created: 15 Ocak 2019 Salı

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
					SET @OrderBy = '[WiscrId]'
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
				SET @SQL = @SQL + ', [WiscrId]'
				SET @SQL = @SQL + ', [SeanceId]'
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
				SET @SQL = @SQL + ', [Notes]'
				SET @SQL = @SQL + ', [TestDate]'
				SET @SQL = @SQL + ', [CreateDate]'
				SET @SQL = @SQL + ', [UpdateDate]'
				SET @SQL = @SQL + ', [CreateUserId]'
				SET @SQL = @SQL + ', [UpdateUserId]'
				SET @SQL = @SQL + ', [Active]'
				SET @SQL = @SQL + ', [Deleted]'
				SET @SQL = @SQL + ' FROM [dbo].[Wiscr]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [WiscrId],'
				SET @SQL = @SQL + ' [SeanceId],'
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
				SET @SQL = @SQL + ' [Notes],'
				SET @SQL = @SQL + ' [TestDate],'
				SET @SQL = @SQL + ' [CreateDate],'
				SET @SQL = @SQL + ' [UpdateDate],'
				SET @SQL = @SQL + ' [CreateUserId],'
				SET @SQL = @SQL + ' [UpdateUserId],'
				SET @SQL = @SQL + ' [Active],'
				SET @SQL = @SQL + ' [Deleted]'
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
-- Date Created: 15 Ocak 2019 Salı

-- Created By:  ()
-- Purpose: Inserts a record into the Wiscr table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Wiscr_Insert
(

	@WiscrId int    OUTPUT,

	@SeanceId int   ,

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

	@CubesPatternRawScore int   ,

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

	@Notes nvarchar (MAX)  ,

	@TestDate datetime   ,

	@CreateDate datetime   ,

	@UpdateDate datetime   ,

	@CreateUserId int   ,

	@UpdateUserId int   ,

	@Active bit   ,

	@Deleted bit   
)
AS


				
				INSERT INTO [dbo].[Wiscr]
					(
					[SeanceId]
					,[GeneralRawScore]
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
					,[Notes]
					,[TestDate]
					,[CreateDate]
					,[UpdateDate]
					,[CreateUserId]
					,[UpdateUserId]
					,[Active]
					,[Deleted]
					)
				VALUES
					(
					@SeanceId
					,@GeneralRawScore
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
					,@Notes
					,@TestDate
					,@CreateDate
					,@UpdateDate
					,@CreateUserId
					,@UpdateUserId
					,@Active
					,@Deleted
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
-- Date Created: 15 Ocak 2019 Salı

-- Created By:  ()
-- Purpose: Updates a record in the Wiscr table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Wiscr_Update
(

	@WiscrId int   ,

	@SeanceId int   ,

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

	@CubesPatternRawScore int   ,

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

	@Notes nvarchar (MAX)  ,

	@TestDate datetime   ,

	@CreateDate datetime   ,

	@UpdateDate datetime   ,

	@CreateUserId int   ,

	@UpdateUserId int   ,

	@Active bit   ,

	@Deleted bit   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[Wiscr]
				SET
					[SeanceId] = @SeanceId
					,[GeneralRawScore] = @GeneralRawScore
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
					,[Notes] = @Notes
					,[TestDate] = @TestDate
					,[CreateDate] = @CreateDate
					,[UpdateDate] = @UpdateDate
					,[CreateUserId] = @CreateUserId
					,[UpdateUserId] = @UpdateUserId
					,[Active] = @Active
					,[Deleted] = @Deleted
				WHERE
[WiscrId] = @WiscrId 
				
			

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
-- Date Created: 15 Ocak 2019 Salı

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
					[WiscrId] = @WiscrId
					
			

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
-- Date Created: 15 Ocak 2019 Salı

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
					[WiscrId],
					[SeanceId],
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
					[Notes],
					[TestDate],
					[CreateDate],
					[UpdateDate],
					[CreateUserId],
					[UpdateUserId],
					[Active],
					[Deleted]
				FROM
					[dbo].[Wiscr]
				WHERE
					[WiscrId] = @WiscrId
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
-- Date Created: 15 Ocak 2019 Salı

-- Created By:  ()
-- Purpose: Finds records in the Wiscr table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.sp_Wiscr_Find
(

	@SearchUsingOR bit   = null ,

	@WiscrId int   = null ,

	@SeanceId int   = null ,

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

	@CubesPatternRawScore int   = null ,

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

	@Notes nvarchar (MAX)  = null ,

	@TestDate datetime   = null ,

	@CreateDate datetime   = null ,

	@UpdateDate datetime   = null ,

	@CreateUserId int   = null ,

	@UpdateUserId int   = null ,

	@Active bit   = null ,

	@Deleted bit   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [WiscrId]
	, [SeanceId]
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
	, [Notes]
	, [TestDate]
	, [CreateDate]
	, [UpdateDate]
	, [CreateUserId]
	, [UpdateUserId]
	, [Active]
	, [Deleted]
    FROM
	[dbo].[Wiscr]
    WHERE 
	 ([WiscrId] = @WiscrId OR @WiscrId IS NULL)
	AND ([SeanceId] = @SeanceId OR @SeanceId IS NULL)
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
	AND ([Notes] = @Notes OR @Notes IS NULL)
	AND ([TestDate] = @TestDate OR @TestDate IS NULL)
	AND ([CreateDate] = @CreateDate OR @CreateDate IS NULL)
	AND ([UpdateDate] = @UpdateDate OR @UpdateDate IS NULL)
	AND ([CreateUserId] = @CreateUserId OR @CreateUserId IS NULL)
	AND ([UpdateUserId] = @UpdateUserId OR @UpdateUserId IS NULL)
	AND ([Active] = @Active OR @Active IS NULL)
	AND ([Deleted] = @Deleted OR @Deleted IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [WiscrId]
	, [SeanceId]
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
	, [Notes]
	, [TestDate]
	, [CreateDate]
	, [UpdateDate]
	, [CreateUserId]
	, [UpdateUserId]
	, [Active]
	, [Deleted]
    FROM
	[dbo].[Wiscr]
    WHERE 
	 ([WiscrId] = @WiscrId AND @WiscrId is not null)
	OR ([SeanceId] = @SeanceId AND @SeanceId is not null)
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
	OR ([Notes] = @Notes AND @Notes is not null)
	OR ([TestDate] = @TestDate AND @TestDate is not null)
	OR ([CreateDate] = @CreateDate AND @CreateDate is not null)
	OR ([UpdateDate] = @UpdateDate AND @UpdateDate is not null)
	OR ([CreateUserId] = @CreateUserId AND @CreateUserId is not null)
	OR ([UpdateUserId] = @UpdateUserId AND @UpdateUserId is not null)
	OR ([Active] = @Active AND @Active is not null)
	OR ([Deleted] = @Deleted AND @Deleted is not null)
	SELECT @@ROWCOUNT			
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
-- Date Created: 15 Ocak 2019 Salı

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
                        [CreateUserId],
                        [UpdateUserId],
                        [Active],
                        [Deleted],
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
-- Date Created: 15 Ocak 2019 Salı

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
                    SET @SQL = @SQL + ', [CreateUserId]'
                    SET @SQL = @SQL + ', [UpdateUserId]'
                    SET @SQL = @SQL + ', [Active]'
                    SET @SQL = @SQL + ', [Deleted]'
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
                    SET @SQL = @SQL + ' [CreateUserId],'
                    SET @SQL = @SQL + ' [UpdateUserId],'
                    SET @SQL = @SQL + ' [Active],'
                    SET @SQL = @SQL + ' [Deleted],'
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

