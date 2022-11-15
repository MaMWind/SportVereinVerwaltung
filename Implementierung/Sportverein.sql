/*CREATE DATABASE SportVereinVerwaltung;

GO*/

use SportVereinVerwaltung;

GO

IF OBJECT_ID('Spieler')IS NOT NULL
    DROP TABLE Spieler;

IF OBJECT_ID('Spiele_Team')IS NOT NULL
    DROP TABLE Spiele_Team;

IF OBJECT_ID('Trainer')IS NOT NULL
    DROP TABLE Trainer;

IF OBJECT_ID('Spiele')IS NOT NULL
    DROP TABLE Spiele;
IF OBJECT_ID('Team')IS NOT NULL
    DROP TABLE Team;
GO


Create Table Team (
	team_id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	team_name nVarChar(100) NOT NULL
);

CREATE Table Spieler (
	spieler_id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	spieler_name nVarChar(100) NOT NULL,
	Position nVarChar(50) NOT NULL,
	team_id iNT,
	CONSTRAINT foreignKeyTeam FOREIGN KEY(team_id)
	REFERENCES Team(team_id)
);

CREATE TABLE TRAINER (
	trainer_id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	trainer_name nVarChar(100) NOT NULL,
	team_id INT,
	CONSTRAINT foreignKeyTeamTrainer FOREIGN KEY (team_id)
	REFERENCES Team(team_id)
);

CREATE TABLE Spiele (
	spiel_id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	uhrzeit DATETIME NOT NULL,
	ort nVarChar(100) NOT NULL
);

CREATE TABLE Spiele_Team (
	spiel_id INT,
	team_id INT,
	CONSTRAINT pk_spiele_team PRIMARY KEY (spiel_id, team_id),
	CONSTRAINT foreignKeySpiele FOREIGN KEY (spiel_id)
	REFERENCES Spiele(spiel_id),
	CONSTRAINT foreignKeyTeamID FOREIGN KEY (team_id)
	REFERENCES Team(team_id)
);

INSERT INTO Team VALUES('EINS'),('NNO'),('T1');

INSERT INTO Spieler VALUES('Noway','Mid', 2), ('Faker', 'Mid', 3), ('Tolkin', 'Top', 1);

INSERT INTO Trainer VALUES('Grabbz', 2), ('kkoma', 3);

INSERT INTO Spiele VALUES('20221224 12:00:00 PM', 'Seoul');

INSERT INTO Spiele_Team VALUES(1, 2), (1,3);
