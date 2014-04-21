CREATE PROC dbo.spSearchStatistics_Add
@SearchWord varchar(300),
@SearchDateTime datetime,
@FoundItems bit
AS
INSERT INTO [SearchStatistics]
           ([SearchWord]
           ,[SearchDateTime]
           ,[FoundItems])
     VALUES
           (@SearchWord,
           @SearchDateTime,
           @FoundItems)
