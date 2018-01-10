
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 01/09/2018 03:20:19
-- Generated from EDMX file: C:\Users\Scott\Documents\Visual Studio 2015\Projects\Footballin\DataSync\GameStatsData.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [ffstats];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[away_team]', 'U') IS NOT NULL
    DROP TABLE [dbo].[away_team];
GO
IF OBJECT_ID(N'[dbo].[data_drives]', 'U') IS NOT NULL
    DROP TABLE [dbo].[data_drives];
GO
IF OBJECT_ID(N'[dbo].[defense_stats]', 'U') IS NOT NULL
    DROP TABLE [dbo].[defense_stats];
GO
IF OBJECT_ID(N'[dbo].[drive_play_players]', 'U') IS NOT NULL
    DROP TABLE [dbo].[drive_play_players];
GO
IF OBJECT_ID(N'[dbo].[drive_plays]', 'U') IS NOT NULL
    DROP TABLE [dbo].[drive_plays];
GO
IF OBJECT_ID(N'[dbo].[fumbles_stats]', 'U') IS NOT NULL
    DROP TABLE [dbo].[fumbles_stats];
GO
IF OBJECT_ID(N'[dbo].[home_team]', 'U') IS NOT NULL
    DROP TABLE [dbo].[home_team];
GO
IF OBJECT_ID(N'[dbo].[kicking_stats]', 'U') IS NOT NULL
    DROP TABLE [dbo].[kicking_stats];
GO
IF OBJECT_ID(N'[dbo].[kickret_stats]', 'U') IS NOT NULL
    DROP TABLE [dbo].[kickret_stats];
GO
IF OBJECT_ID(N'[dbo].[passing_stats]', 'U') IS NOT NULL
    DROP TABLE [dbo].[passing_stats];
GO
IF OBJECT_ID(N'[dbo].[punting_stats]', 'U') IS NOT NULL
    DROP TABLE [dbo].[punting_stats];
GO
IF OBJECT_ID(N'[dbo].[puntret_stats]', 'U') IS NOT NULL
    DROP TABLE [dbo].[puntret_stats];
GO
IF OBJECT_ID(N'[dbo].[receiving_stats]', 'U') IS NOT NULL
    DROP TABLE [dbo].[receiving_stats];
GO
IF OBJECT_ID(N'[dbo].[Root]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Root];
GO
IF OBJECT_ID(N'[dbo].[rushing_stats]', 'U') IS NOT NULL
    DROP TABLE [dbo].[rushing_stats];
GO
IF OBJECT_ID(N'[dbo].[scrsummary_data]', 'U') IS NOT NULL
    DROP TABLE [dbo].[scrsummary_data];
GO
IF OBJECT_ID(N'[dbo].[team_stats]', 'U') IS NOT NULL
    DROP TABLE [dbo].[team_stats];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'away_team'
CREATE TABLE [dbo].[away_team] (
    [eid] nchar(10)  NOT NULL,
    [abbr] nchar(10)  NULL,
    [team_to] nchar(10)  NULL,
    [players] nchar(10)  NULL,
    [score_1] nchar(10)  NULL,
    [score_2] nchar(10)  NULL,
    [score_3] nchar(10)  NULL,
    [score_4] nchar(10)  NULL,
    [score_5] nchar(10)  NULL,
    [score_t] nchar(10)  NULL
);
GO

-- Creating table 'home_team'
CREATE TABLE [dbo].[home_team] (
    [eid] nchar(10)  NOT NULL,
    [abbr] nchar(10)  NULL,
    [team_to] nchar(10)  NULL,
    [players] nchar(10)  NULL,
    [score_1] nchar(10)  NULL,
    [score_2] nchar(10)  NULL,
    [score_3] nchar(10)  NULL,
    [score_4] nchar(10)  NULL,
    [score_5] nchar(10)  NULL,
    [score_t] nchar(10)  NULL
);
GO

-- Creating table 'passing_stats'
CREATE TABLE [dbo].[passing_stats] (
    [eid_playerid] nchar(30)  NOT NULL,
    [playerid] nchar(30)  NULL,
    [name] nchar(30)  NULL,
    [att] nchar(10)  NULL,
    [cmp] nchar(10)  NULL,
    [yds] nchar(10)  NULL,
    [tds] nchar(10)  NULL,
    [ints] nchar(10)  NULL,
    [twopta] nchar(10)  NULL,
    [twoptm] nchar(10)  NULL,
    [home_or_away] nchar(10)  NULL
);
GO

-- Creating table 'rushing_stats'
CREATE TABLE [dbo].[rushing_stats] (
    [eid_playerid] nchar(30)  NOT NULL,
    [playerid] nchar(30)  NULL,
    [name] nchar(30)  NULL,
    [att] nchar(10)  NULL,
    [yds] nchar(10)  NULL,
    [tds] nchar(10)  NULL,
    [lng] nchar(10)  NULL,
    [lngtd] nchar(10)  NULL,
    [twopta] nchar(10)  NULL,
    [twoptm] nchar(10)  NULL,
    [home_or_away] nchar(10)  NULL
);
GO

-- Creating table 'receiving_stats'
CREATE TABLE [dbo].[receiving_stats] (
    [eid_playerid] nchar(30)  NOT NULL,
    [playerid] nchar(30)  NULL,
    [name] nchar(30)  NULL,
    [rec] nchar(10)  NULL,
    [yds] nchar(10)  NULL,
    [tds] nchar(10)  NULL,
    [lng] nchar(10)  NULL,
    [lngtd] nchar(10)  NULL,
    [twopta] nchar(10)  NULL,
    [twoptm] nchar(10)  NULL,
    [home_or_away] nchar(10)  NULL
);
GO

-- Creating table 'fumbles_stats'
CREATE TABLE [dbo].[fumbles_stats] (
    [eid_playerid] nchar(30)  NOT NULL,
    [playerid] nchar(30)  NULL,
    [name] nchar(30)  NULL,
    [tot] nchar(10)  NULL,
    [rcv] nchar(10)  NULL,
    [trcv] nchar(10)  NULL,
    [yds] nchar(10)  NULL,
    [lost] nchar(10)  NULL,
    [home_or_away] nchar(10)  NULL
);
GO

-- Creating table 'kicking_stats'
CREATE TABLE [dbo].[kicking_stats] (
    [eid_playerid] nchar(30)  NOT NULL,
    [playerid] nchar(30)  NULL,
    [name] nchar(30)  NULL,
    [fgm] nchar(10)  NULL,
    [fga] nchar(10)  NULL,
    [fgyds] nchar(10)  NULL,
    [totpfg] nchar(10)  NULL,
    [xpmade] nchar(10)  NULL,
    [xpmissed] nchar(10)  NULL,
    [xpa] nchar(10)  NULL,
    [xpb] nchar(10)  NULL,
    [xptot] nchar(10)  NULL,
    [home_or_away] nchar(10)  NULL
);
GO

-- Creating table 'punting_stats'
CREATE TABLE [dbo].[punting_stats] (
    [eid_playerid] nchar(30)  NOT NULL,
    [playerid] nchar(30)  NULL,
    [name] nchar(30)  NULL,
    [pts] nchar(10)  NULL,
    [yds] nchar(10)  NULL,
    [avg] nchar(10)  NULL,
    [i20] nchar(10)  NULL,
    [lng] nchar(10)  NULL,
    [home_or_away] nchar(10)  NULL
);
GO

-- Creating table 'kickret_stats'
CREATE TABLE [dbo].[kickret_stats] (
    [eid_playerid] nchar(30)  NOT NULL,
    [playerid] nchar(30)  NULL,
    [name] nchar(30)  NULL,
    [ret] nchar(10)  NULL,
    [avg] nchar(10)  NULL,
    [tds] nchar(10)  NULL,
    [lng] nchar(10)  NULL,
    [lngtd] nchar(10)  NULL,
    [home_or_away] nchar(10)  NULL
);
GO

-- Creating table 'puntret_stats'
CREATE TABLE [dbo].[puntret_stats] (
    [eid_playerid] nchar(30)  NOT NULL,
    [playerid] nchar(30)  NULL,
    [name] nchar(30)  NULL,
    [ret] nchar(10)  NULL,
    [avg] nchar(10)  NULL,
    [tds] nchar(10)  NULL,
    [lng] nchar(10)  NULL,
    [lngtd] nchar(10)  NULL,
    [home_or_away] nchar(10)  NULL
);
GO

-- Creating table 'defense_stats'
CREATE TABLE [dbo].[defense_stats] (
    [eid_playerid] nchar(30)  NOT NULL,
    [playerid] nchar(30)  NULL,
    [name] nchar(30)  NULL,
    [tkl] nchar(10)  NULL,
    [ast] nchar(10)  NULL,
    [sk] nchar(10)  NULL,
    [int] nchar(10)  NULL,
    [ffum] nchar(10)  NULL,
    [home_or_away] nchar(10)  NULL
);
GO

-- Creating table 'Roots'
CREATE TABLE [dbo].[Roots] (
    [eid] nchar(10)  NOT NULL,
    [weather] nchar(10)  NULL,
    [media] nchar(10)  NULL,
    [yl] nchar(10)  NULL,
    [qtr] nchar(30)  NULL,
    [note] nchar(10)  NULL,
    [down] nchar(10)  NULL,
    [togo] nchar(10)  NULL,
    [redzone] nchar(10)  NULL,
    [clock] nchar(10)  NULL,
    [posteam] nchar(10)  NULL,
    [stadium] nchar(10)  NULL
);
GO

-- Creating table 'team_stats'
CREATE TABLE [dbo].[team_stats] (
    [eid_location] nchar(30)  NOT NULL,
    [team_abbr] nchar(10)  NULL,
    [totfd] nchar(10)  NULL,
    [totyds] nchar(10)  NULL,
    [pyds] nchar(10)  NULL,
    [ryds] nchar(10)  NULL,
    [pen] nchar(10)  NULL,
    [penyds] nchar(10)  NULL,
    [trnovr] nchar(10)  NULL,
    [pt] nchar(10)  NULL,
    [ptyds] nchar(10)  NULL,
    [ptavg] nchar(10)  NULL,
    [top] nchar(10)  NULL,
    [home_or_away] nchar(10)  NULL
);
GO

-- Creating table 'drive_plays'
CREATE TABLE [dbo].[drive_plays] (
    [eid_drivenum_playnum] nchar(50)  NOT NULL,
    [drive_num] nchar(10)  NULL,
    [playnum] nchar(10)  NULL,
    [sp] nchar(10)  NULL,
    [qtr] nchar(30)  NULL,
    [down] nchar(10)  NULL,
    [time] nchar(10)  NULL,
    [yrdln] nchar(10)  NULL,
    [ydstogo] nchar(10)  NULL,
    [ydsnet] nchar(10)  NULL,
    [posteam] nchar(10)  NULL,
    [desc] nchar(2000)  NULL,
    [note] nchar(50)  NULL
);
GO

-- Creating table 'drive_play_players'
CREATE TABLE [dbo].[drive_play_players] (
    [eid_drive_play_playerid_sequence] nchar(300)  NOT NULL,
    [drivenum] nchar(10)  NULL,
    [playnum] nchar(10)  NULL,
    [playerid] nchar(15)  NULL,
    [sequence] nchar(10)  NULL,
    [clubcode] nchar(20)  NULL,
    [playerName] nchar(30)  NULL,
    [statId] nchar(10)  NULL,
    [yards] nchar(10)  NULL
);
GO

-- Creating table 'scrsummary_data'
CREATE TABLE [dbo].[scrsummary_data] (
    [eid_scrid] nchar(30)  NOT NULL,
    [scr_id] nchar(10)  NULL,
    [type] nchar(10)  NULL,
    [desc] nchar(500)  NULL,
    [qtr] nchar(30)  NULL,
    [team] nchar(10)  NULL,
    [players] nchar(500)  NULL
);
GO

-- Creating table 'data_drives'
CREATE TABLE [dbo].[data_drives] (
    [eid_drivenumber] nchar(30)  NOT NULL,
    [drivenumber] nchar(10)  NULL,
    [posteam] nchar(10)  NULL,
    [qtr] nchar(30)  NULL,
    [redzone] nchar(10)  NULL,
    [fds] int  NULL,
    [result] nchar(20)  NULL,
    [penyds] int  NULL,
    [ydsgained] int  NULL,
    [numplays] int  NULL,
    [postime] nchar(10)  NULL,
    [start_qtr] nchar(10)  NULL,
    [start_time] nchar(10)  NULL,
    [start_yrdln] nchar(10)  NULL,
    [start_team] nchar(10)  NULL,
    [end_qtr] nchar(10)  NULL,
    [end_time] nchar(10)  NULL,
    [end_yrdln] nchar(10)  NULL,
    [end_team] nchar(10)  NULL
);
GO

-- Creating table 'lu_player'
CREATE TABLE [dbo].[lu_player] (
    [PlayerId] nvarchar(max)  NOT NULL,
    [PlayerName] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [eid] in table 'away_team'
ALTER TABLE [dbo].[away_team]
ADD CONSTRAINT [PK_away_team]
    PRIMARY KEY CLUSTERED ([eid] ASC);
GO

-- Creating primary key on [eid] in table 'home_team'
ALTER TABLE [dbo].[home_team]
ADD CONSTRAINT [PK_home_team]
    PRIMARY KEY CLUSTERED ([eid] ASC);
GO

-- Creating primary key on [eid_playerid] in table 'passing_stats'
ALTER TABLE [dbo].[passing_stats]
ADD CONSTRAINT [PK_passing_stats]
    PRIMARY KEY CLUSTERED ([eid_playerid] ASC);
GO

-- Creating primary key on [eid_playerid] in table 'rushing_stats'
ALTER TABLE [dbo].[rushing_stats]
ADD CONSTRAINT [PK_rushing_stats]
    PRIMARY KEY CLUSTERED ([eid_playerid] ASC);
GO

-- Creating primary key on [eid_playerid] in table 'receiving_stats'
ALTER TABLE [dbo].[receiving_stats]
ADD CONSTRAINT [PK_receiving_stats]
    PRIMARY KEY CLUSTERED ([eid_playerid] ASC);
GO

-- Creating primary key on [eid_playerid] in table 'fumbles_stats'
ALTER TABLE [dbo].[fumbles_stats]
ADD CONSTRAINT [PK_fumbles_stats]
    PRIMARY KEY CLUSTERED ([eid_playerid] ASC);
GO

-- Creating primary key on [eid_playerid] in table 'kicking_stats'
ALTER TABLE [dbo].[kicking_stats]
ADD CONSTRAINT [PK_kicking_stats]
    PRIMARY KEY CLUSTERED ([eid_playerid] ASC);
GO

-- Creating primary key on [eid_playerid] in table 'punting_stats'
ALTER TABLE [dbo].[punting_stats]
ADD CONSTRAINT [PK_punting_stats]
    PRIMARY KEY CLUSTERED ([eid_playerid] ASC);
GO

-- Creating primary key on [eid_playerid] in table 'kickret_stats'
ALTER TABLE [dbo].[kickret_stats]
ADD CONSTRAINT [PK_kickret_stats]
    PRIMARY KEY CLUSTERED ([eid_playerid] ASC);
GO

-- Creating primary key on [eid_playerid] in table 'puntret_stats'
ALTER TABLE [dbo].[puntret_stats]
ADD CONSTRAINT [PK_puntret_stats]
    PRIMARY KEY CLUSTERED ([eid_playerid] ASC);
GO

-- Creating primary key on [eid_playerid] in table 'defense_stats'
ALTER TABLE [dbo].[defense_stats]
ADD CONSTRAINT [PK_defense_stats]
    PRIMARY KEY CLUSTERED ([eid_playerid] ASC);
GO

-- Creating primary key on [eid] in table 'Roots'
ALTER TABLE [dbo].[Roots]
ADD CONSTRAINT [PK_Roots]
    PRIMARY KEY CLUSTERED ([eid] ASC);
GO

-- Creating primary key on [eid_location] in table 'team_stats'
ALTER TABLE [dbo].[team_stats]
ADD CONSTRAINT [PK_team_stats]
    PRIMARY KEY CLUSTERED ([eid_location] ASC);
GO

-- Creating primary key on [eid_drivenum_playnum] in table 'drive_plays'
ALTER TABLE [dbo].[drive_plays]
ADD CONSTRAINT [PK_drive_plays]
    PRIMARY KEY CLUSTERED ([eid_drivenum_playnum] ASC);
GO

-- Creating primary key on [eid_drive_play_playerid_sequence] in table 'drive_play_players'
ALTER TABLE [dbo].[drive_play_players]
ADD CONSTRAINT [PK_drive_play_players]
    PRIMARY KEY CLUSTERED ([eid_drive_play_playerid_sequence] ASC);
GO

-- Creating primary key on [eid_scrid] in table 'scrsummary_data'
ALTER TABLE [dbo].[scrsummary_data]
ADD CONSTRAINT [PK_scrsummary_data]
    PRIMARY KEY CLUSTERED ([eid_scrid] ASC);
GO

-- Creating primary key on [eid_drivenumber] in table 'data_drives'
ALTER TABLE [dbo].[data_drives]
ADD CONSTRAINT [PK_data_drives]
    PRIMARY KEY CLUSTERED ([eid_drivenumber] ASC);
GO

-- Creating primary key on [PlayerId] in table 'lu_player'
ALTER TABLE [dbo].[lu_player]
ADD CONSTRAINT [PK_lu_player]
    PRIMARY KEY CLUSTERED ([PlayerId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------