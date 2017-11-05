CREATE TABLE [dbo].[usuarios] (
    [email]     VARCHAR (50) NOT NULL,
    [nick_name] VARCHAR (50) UNIQUE NOT NULL,
    [password]  VARCHAR (20) NOT NULL,
    CONSTRAINT [PK_user] PRIMARY KEY CLUSTERED ([email] ASC)
);

