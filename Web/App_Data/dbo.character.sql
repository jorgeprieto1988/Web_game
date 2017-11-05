CREATE TABLE [dbo].[character] (
    [name]       VARCHAR (50) NOT NULL,
    [race]       INT          NOT NULL,
    [health]     INT          NULL,
    [attack]     INT          NULL,
    [defense]    INT          NULL,
    [experience] INT          NULL,
    [level]      INT          NULL,
    [gold]       INT          NULL,
    [points]     INT          NULL,
    [player_email] VARCHAR(50) NULL, 
    CONSTRAINT [PK_character] PRIMARY KEY CLUSTERED ([name] ASC)
);

