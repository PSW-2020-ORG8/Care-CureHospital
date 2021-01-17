CREATE TABLE `Advertisement` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `PharmacyName` longtext CHARACTER SET utf8mb4 NULL,
    `Percent` double NOT NULL,
    `Period` longtext CHARACTER SET utf8mb4 NULL,
    `Manufacturer` longtext CHARACTER SET utf8mb4 NULL,
    CONSTRAINT `PK_Advertisement` PRIMARY KEY (`Id`)
);

CREATE TABLE `PatientFeedbacks` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Text` longtext CHARACTER SET utf8mb4 NULL,
    `PublishingDate` datetime(6) NOT NULL,
    `IsForPublishing` tinyint(1) NOT NULL,
    `IsPublished` tinyint(1) NOT NULL,
    `IsAnonymous` tinyint(1) NOT NULL,
    `PatientId` int NOT NULL,
    CONSTRAINT `PK_PatientFeedbacks` PRIMARY KEY (`Id`)
);

CREATE TABLE `Questions` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `QuestionText` longtext CHARACTER SET utf8mb4 NULL,
    `QuestionType` int NOT NULL,
    CONSTRAINT `PK_Questions` PRIMARY KEY (`Id`)
);

CREATE TABLE `Surveys` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Title` longtext CHARACTER SET utf8mb4 NULL,
    `CommentSurvey` longtext CHARACTER SET utf8mb4 NULL,
    `PublishingDate` datetime(6) NOT NULL,
    `MedicalExaminationId` int NOT NULL,
    CONSTRAINT `PK_Surveys` PRIMARY KEY (`Id`)
);

CREATE TABLE `Answers` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Grade` int NOT NULL,
    `QuestionId` int NOT NULL,
    `SurveyId` int NOT NULL,
    CONSTRAINT `PK_Answers` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_Answers_Questions_QuestionId` FOREIGN KEY (`QuestionId`) REFERENCES `Questions` (`Id`) ON DELETE CASCADE,
    CONSTRAINT `FK_Answers_Surveys_SurveyId` FOREIGN KEY (`SurveyId`) REFERENCES `Surveys` (`Id`) ON DELETE CASCADE
);

INSERT INTO `Advertisement` (`Id`, `Manufacturer`, `Percent`, `Period`, `PharmacyName`)
VALUES (1, 'Sandoz lekovi', 10.0, '01.01.2021. - 02.02.2021.', 'Janković');
INSERT INTO `Advertisement` (`Id`, `Manufacturer`, `Percent`, `Period`, `PharmacyName`)
VALUES (2, 'Galenika lekovi', 15.0, '05.01.2021. - 12.03.2021.', 'Sarić');
INSERT INTO `Advertisement` (`Id`, `Manufacturer`, `Percent`, `Period`, `PharmacyName`)
VALUES (3, 'Pfizer lekovi', 25.0, '08.01.2021. - 22.04.2021.', 'Zegin');

INSERT INTO `PatientFeedbacks` (`Id`, `IsAnonymous`, `IsForPublishing`, `IsPublished`, `PatientId`, `PublishingDate`, `Text`)
VALUES (1, FALSE, TRUE, TRUE, 1, '2020-10-30 10:30:00', 'Iako rečenica nema značenje, ona ima dugu istoriju. Nju su nekoliko vekova koristili tipografi da bi prikazali najistaknutije osobine svojih fontova. Koristi se zbog toga što slova koja su uključena u nju, kao i razmak između slova u tim kombinacijama na najbolji mogući način otkrivaju težinu, dizajn i druge važne funkcije slovnog oblika.');
INSERT INTO `PatientFeedbacks` (`Id`, `IsAnonymous`, `IsForPublishing`, `IsPublished`, `PatientId`, `PublishingDate`, `Text`)
VALUES (2, TRUE, TRUE, TRUE, 2, '2020-08-15 09:17:00', 'Iako rečenica nema značenje, ona ima dugu istoriju. Nju su nekoliko vekova koristili tipografi da bi prikazali najistaknutije osobine svojih fontova. Koristi se zbog toga što slova koja su uključena u nju, kao i razmak između slova u tim kombinacijama na najbolji mogući način otkrivaju težinu, dizajn i druge važne funkcije slovnog oblika.');
INSERT INTO `PatientFeedbacks` (`Id`, `IsAnonymous`, `IsForPublishing`, `IsPublished`, `PatientId`, `PublishingDate`, `Text`)
VALUES (3, TRUE, TRUE, FALSE, 3, '2020-09-03 11:30:00', 'Iako rečenica nema značenje, ona ima dugu istoriju. Nju su nekoliko vekova koristili tipografi da bi prikazali najistaknutije osobine svojih fontova. Koristi se zbog toga što slova koja su uključena u nju, kao i razmak između slova u tim kombinacijama na najbolji mogući način otkrivaju težinu, dizajn i druge važne funkcije slovnog oblika.');
INSERT INTO `PatientFeedbacks` (`Id`, `IsAnonymous`, `IsForPublishing`, `IsPublished`, `PatientId`, `PublishingDate`, `Text`)
VALUES (4, FALSE, FALSE, FALSE, 4, '2020-11-06 08:30:00', 'Iako rečenica nema značenje, ona ima dugu istoriju. Nju su nekoliko vekova koristili tipografi da bi prikazali najistaknutije osobine svojih fontova. Koristi se zbog toga što slova koja su uključena u nju, kao i razmak između slova u tim kombinacijama na najbolji mogući način otkrivaju težinu, dizajn i druge važne funkcije slovnog oblika.');
INSERT INTO `PatientFeedbacks` (`Id`, `IsAnonymous`, `IsForPublishing`, `IsPublished`, `PatientId`, `PublishingDate`, `Text`)
VALUES (5, FALSE, FALSE, FALSE, 2, '2020-10-18 07:30:00', 'Iako rečenica nema značenje, ona ima dugu istoriju. Nju su nekoliko vekova koristili tipografi da bi prikazali najistaknutije osobine svojih fontova. Koristi se zbog toga što slova koja su uključena u nju, kao i razmak između slova u tim kombinacijama na najbolji mogući način otkrivaju težinu, dizajn i druge važne funkcije slovnog oblika.');
INSERT INTO `PatientFeedbacks` (`Id`, `IsAnonymous`, `IsForPublishing`, `IsPublished`, `PatientId`, `PublishingDate`, `Text`)
VALUES (6, TRUE, TRUE, FALSE, 4, '2020-10-15 06:30:00', 'Iako rečenica nema značenje, ona ima dugu istoriju. Nju su nekoliko vekova koristili tipografi da bi prikazali najistaknutije osobine svojih fontova. Koristi se zbog toga što slova koja su uključena u nju, kao i razmak između slova u tim kombinacijama na najbolji mogući način otkrivaju težinu, dizajn i druge važne funkcije slovnog oblika.');

INSERT INTO `Questions` (`Id`, `QuestionText`, `QuestionType`)
VALUES (9, 'Opremljenost bolnice', 2);
INSERT INTO `Questions` (`Id`, `QuestionText`, `QuestionType`)
VALUES (8, 'Higijena unutar bolnice', 2);
INSERT INTO `Questions` (`Id`, `QuestionText`, `QuestionType`)
VALUES (7, 'Ispunjenost vremena zakazanog termina i vreme provedeno u cekonici', 2);
INSERT INTO `Questions` (`Id`, `QuestionText`, `QuestionType`)
VALUES (6, 'Profesionalizam u obavljanju svoji duznosti medicinskog osoblja', 1);
INSERT INTO `Questions` (`Id`, `QuestionText`, `QuestionType`)
VALUES (1, 'Ljubaznost doktora prema pacijentu', 0);
INSERT INTO `Questions` (`Id`, `QuestionText`, `QuestionType`)
VALUES (4, 'Ljubaznost medicinskog osoblja prema pacijentu', 1);
INSERT INTO `Questions` (`Id`, `QuestionText`, `QuestionType`)
VALUES (3, 'Pružanje informacija od strane doktora o mom zdravstvenom stanju i mogućnostima lečenja', 0);
INSERT INTO `Questions` (`Id`, `QuestionText`, `QuestionType`)
VALUES (2, 'Posvećenost doktora pacijentu', 0);
INSERT INTO `Questions` (`Id`, `QuestionText`, `QuestionType`)
VALUES (5, 'Posvećenost medicinskog osoblja pacijentu', 1);

INSERT INTO `Surveys` (`Id`, `CommentSurvey`, `MedicalExaminationId`, `PublishingDate`, `Title`)
VALUES (1, 'Sve je super u bolnici', 1, '2020-11-06 08:30:00', 'Naslov');
INSERT INTO `Surveys` (`Id`, `CommentSurvey`, `MedicalExaminationId`, `PublishingDate`, `Title`)
VALUES (2, 'Sve je super u bolnici', 2, '2020-11-06 08:30:00', 'Naslov');

INSERT INTO `Answers` (`Id`, `Grade`, `QuestionId`, `SurveyId`)
VALUES (1, 1, 1, 1);
INSERT INTO `Answers` (`Id`, `Grade`, `QuestionId`, `SurveyId`)
VALUES (16, 2, 7, 2);
INSERT INTO `Answers` (`Id`, `Grade`, `QuestionId`, `SurveyId`)
VALUES (15, 2, 6, 2);
INSERT INTO `Answers` (`Id`, `Grade`, `QuestionId`, `SurveyId`)
VALUES (14, 1, 5, 2);
INSERT INTO `Answers` (`Id`, `Grade`, `QuestionId`, `SurveyId`)
VALUES (13, 3, 4, 2);
INSERT INTO `Answers` (`Id`, `Grade`, `QuestionId`, `SurveyId`)
VALUES (12, 4, 3, 2);
INSERT INTO `Answers` (`Id`, `Grade`, `QuestionId`, `SurveyId`)
VALUES (11, 4, 2, 2);
INSERT INTO `Answers` (`Id`, `Grade`, `QuestionId`, `SurveyId`)
VALUES (10, 2, 1, 2);
INSERT INTO `Answers` (`Id`, `Grade`, `QuestionId`, `SurveyId`)
VALUES (9, 3, 9, 2);
INSERT INTO `Answers` (`Id`, `Grade`, `QuestionId`, `SurveyId`)
VALUES (8, 1, 8, 1);
INSERT INTO `Answers` (`Id`, `Grade`, `QuestionId`, `SurveyId`)
VALUES (7, 1, 7, 1);
INSERT INTO `Answers` (`Id`, `Grade`, `QuestionId`, `SurveyId`)
VALUES (6, 4, 6, 1);
INSERT INTO `Answers` (`Id`, `Grade`, `QuestionId`, `SurveyId`)
VALUES (5, 0, 5, 1);
INSERT INTO `Answers` (`Id`, `Grade`, `QuestionId`, `SurveyId`)
VALUES (4, 3, 4, 1);
INSERT INTO `Answers` (`Id`, `Grade`, `QuestionId`, `SurveyId`)
VALUES (3, 2, 3, 1);
INSERT INTO `Answers` (`Id`, `Grade`, `QuestionId`, `SurveyId`)
VALUES (2, 4, 2, 1);
INSERT INTO `Answers` (`Id`, `Grade`, `QuestionId`, `SurveyId`)
VALUES (17, 4, 8, 2);
INSERT INTO `Answers` (`Id`, `Grade`, `QuestionId`, `SurveyId`)
VALUES (18, 3, 9, 2);

CREATE INDEX `IX_Answers_QuestionId` ON `Answers` (`QuestionId`);

CREATE INDEX `IX_Answers_SurveyId` ON `Answers` (`SurveyId`);

