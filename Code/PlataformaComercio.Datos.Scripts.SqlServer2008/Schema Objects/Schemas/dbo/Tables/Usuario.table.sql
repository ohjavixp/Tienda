CREATE TABLE [dbo].[Usuario] (
    [UserId]         UNIQUEIDENTIFIER NOT NULL,
    [UserName]       VARCHAR (50)     NOT NULL,
    [Password]       VARCHAR (50)     NOT NULL,
    [Name]           VARCHAR (50)     NOT NULL,
    [LastName]       VARCHAR (50)     NULL,
    [EmailAddress]   VARCHAR (100)    NOT NULL,
    [BirthDate]      DATE             NOT NULL,
    [PhoneNumber]    VARCHAR (20)     NOT NULL,
    [PhoneNumberExt] VARCHAR (10)     NULL,
    [MobileNumber]   VARCHAR (10)     NULL,
    [Sex]            BIT              NOT NULL,
    [SendInfo]       BIT              NOT NULL,
    [ShareInfo]      BIT              NOT NULL
);



