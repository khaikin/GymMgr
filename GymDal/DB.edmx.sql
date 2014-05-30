
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 04/22/2014 14:46:21
-- Generated from EDMX file: C:\Users\iliak\Documents\Visual Studio 2010\Projects\GymMgr\GymDal\DB.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [GymDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_CustomerPayment]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Payments] DROP CONSTRAINT [FK_CustomerPayment];
GO
IF OBJECT_ID(N'[dbo].[FK_CustomerWorkoutProgram]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Customers] DROP CONSTRAINT [FK_CustomerWorkoutProgram];
GO
IF OBJECT_ID(N'[dbo].[FK_LogInCustomer]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[LogIns] DROP CONSTRAINT [FK_LogInCustomer];
GO
IF OBJECT_ID(N'[dbo].[FK_WorkoutExerciseWorkout]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Workouts] DROP CONSTRAINT [FK_WorkoutExerciseWorkout];
GO
IF OBJECT_ID(N'[dbo].[FK_WorkoutProgramWorkoutExercise]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Workouts] DROP CONSTRAINT [FK_WorkoutProgramWorkoutExercise];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Customers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Customers];
GO
IF OBJECT_ID(N'[dbo].[LogIns]', 'U') IS NOT NULL
    DROP TABLE [dbo].[LogIns];
GO
IF OBJECT_ID(N'[dbo].[Payments]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Payments];
GO
IF OBJECT_ID(N'[dbo].[WorkoutExercises]', 'U') IS NOT NULL
    DROP TABLE [dbo].[WorkoutExercises];
GO
IF OBJECT_ID(N'[dbo].[WorkoutPrograms]', 'U') IS NOT NULL
    DROP TABLE [dbo].[WorkoutPrograms];
GO
IF OBJECT_ID(N'[dbo].[Workouts]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Workouts];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Customers'
CREATE TABLE [dbo].[Customers] (
    [id] int IDENTITY(1,1) NOT NULL,
    [FirstName] nvarchar(100)  NOT NULL,
    [LastName] nvarchar(100)  NOT NULL,
    [IdentificationNumber] nvarchar(10)  NOT NULL,
    [BirthDate] datetime  NOT NULL,
    [Email] nvarchar(100)  NOT NULL,
    [Address] nvarchar(100)  NOT NULL,
    [CreationTimeStamp] datetime  NOT NULL,
    [Active] bit  NOT NULL,
    [WorkoutProgram_Id] int  NULL
);
GO

-- Creating table 'Payments'
CREATE TABLE [dbo].[Payments] (
    [id] int IDENTITY(1,1) NOT NULL,
    [Amount] float  NOT NULL,
    [TimeStamp] datetime  NOT NULL,
    [From] datetime  NOT NULL,
    [To] datetime  NOT NULL,
    [Comments] nvarchar(max)  NOT NULL,
    [Customer_id] int  NOT NULL
);
GO

-- Creating table 'WorkoutPrograms'
CREATE TABLE [dbo].[WorkoutPrograms] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'WorkoutExercises'
CREATE TABLE [dbo].[WorkoutExercises] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Image] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Workouts'
CREATE TABLE [dbo].[Workouts] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Repetitions] int  NOT NULL,
    [Sets] int  NOT NULL,
    [WorkoutPrograms_Id] int  NOT NULL,
    [WorkoutProgram_Id] int  NOT NULL,
    [WorkoutExercise_Id] int  NOT NULL
);
GO

-- Creating table 'LogIns'
CREATE TABLE [dbo].[LogIns] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [TimeStamp] datetime  NOT NULL,
    [Customer_id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [id] in table 'Customers'
ALTER TABLE [dbo].[Customers]
ADD CONSTRAINT [PK_Customers]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Payments'
ALTER TABLE [dbo].[Payments]
ADD CONSTRAINT [PK_Payments]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [Id] in table 'WorkoutPrograms'
ALTER TABLE [dbo].[WorkoutPrograms]
ADD CONSTRAINT [PK_WorkoutPrograms]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'WorkoutExercises'
ALTER TABLE [dbo].[WorkoutExercises]
ADD CONSTRAINT [PK_WorkoutExercises]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Workouts'
ALTER TABLE [dbo].[Workouts]
ADD CONSTRAINT [PK_Workouts]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'LogIns'
ALTER TABLE [dbo].[LogIns]
ADD CONSTRAINT [PK_LogIns]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Customer_id] in table 'Payments'
ALTER TABLE [dbo].[Payments]
ADD CONSTRAINT [FK_CustomerPayment]
    FOREIGN KEY ([Customer_id])
    REFERENCES [dbo].[Customers]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CustomerPayment'
CREATE INDEX [IX_FK_CustomerPayment]
ON [dbo].[Payments]
    ([Customer_id]);
GO

-- Creating foreign key on [WorkoutProgram_Id] in table 'Customers'
ALTER TABLE [dbo].[Customers]
ADD CONSTRAINT [FK_CustomerWorkoutProgram]
    FOREIGN KEY ([WorkoutProgram_Id])
    REFERENCES [dbo].[WorkoutPrograms]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CustomerWorkoutProgram'
CREATE INDEX [IX_FK_CustomerWorkoutProgram]
ON [dbo].[Customers]
    ([WorkoutProgram_Id]);
GO

-- Creating foreign key on [WorkoutProgram_Id] in table 'Workouts'
ALTER TABLE [dbo].[Workouts]
ADD CONSTRAINT [FK_WorkoutProgramWorkoutExercise]
    FOREIGN KEY ([WorkoutProgram_Id])
    REFERENCES [dbo].[WorkoutPrograms]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_WorkoutProgramWorkoutExercise'
CREATE INDEX [IX_FK_WorkoutProgramWorkoutExercise]
ON [dbo].[Workouts]
    ([WorkoutProgram_Id]);
GO

-- Creating foreign key on [WorkoutExercise_Id] in table 'Workouts'
ALTER TABLE [dbo].[Workouts]
ADD CONSTRAINT [FK_WorkoutExerciseWorkout]
    FOREIGN KEY ([WorkoutExercise_Id])
    REFERENCES [dbo].[WorkoutExercises]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_WorkoutExerciseWorkout'
CREATE INDEX [IX_FK_WorkoutExerciseWorkout]
ON [dbo].[Workouts]
    ([WorkoutExercise_Id]);
GO

-- Creating foreign key on [Customer_id] in table 'LogIns'
ALTER TABLE [dbo].[LogIns]
ADD CONSTRAINT [FK_LogInCustomer]
    FOREIGN KEY ([Customer_id])
    REFERENCES [dbo].[Customers]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_LogInCustomer'
CREATE INDEX [IX_FK_LogInCustomer]
ON [dbo].[LogIns]
    ([Customer_id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------