use HealthClinicDB;
CREATE TABLE `Rooms` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `FromDateTime` datetime(6) NOT NULL,
    `ToDateTime` datetime(6) NOT NULL,
    `RoomId` longtext CHARACTER SET utf8mb4 NULL,
    `DoctorId` int NOT NULL,
    CONSTRAINT `PK_Rooms` PRIMARY KEY (`Id`)
);

CREATE TABLE `DoctorWorkDays` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Date` datetime(6) NOT NULL,
    `DoctorId` int NOT NULL,
    `RoomId` int NOT NULL,
    CONSTRAINT `PK_DoctorWorkDays` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_DoctorWorkDays_Rooms_RoomId` FOREIGN KEY (`RoomId`) REFERENCES `Rooms` (`Id`) ON DELETE CASCADE
);

CREATE TABLE `MedicalExaminations` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `FromDateTime` datetime(6) NOT NULL,
    `ToDateTime` datetime(6) NOT NULL,
    `ShortDescription` longtext CHARACTER SET utf8mb4 NULL,
    `SurveyFilled` tinyint(1) NOT NULL,
    `RoomId` int NOT NULL,
    `DoctorId` int NOT NULL,
    `PatientId` int NOT NULL,
    CONSTRAINT `PK_MedicalExaminations` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_MedicalExaminations_Rooms_RoomId` FOREIGN KEY (`RoomId`) REFERENCES `Rooms` (`Id`) ON DELETE CASCADE
);

CREATE TABLE `Appointments` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Canceled` tinyint(1) NOT NULL,
    `CancellationDate` datetime(6) NOT NULL,
    `StartTime` datetime(6) NOT NULL,
    `EndTime` datetime(6) NOT NULL,
    `MedicalExaminationId` int NOT NULL,
    `DoctorWorkDayId` int NOT NULL,
    CONSTRAINT `PK_Appointments` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_Appointments_DoctorWorkDays_DoctorWorkDayId` FOREIGN KEY (`DoctorWorkDayId`) REFERENCES `DoctorWorkDays` (`Id`) ON DELETE CASCADE,
    CONSTRAINT `FK_Appointments_MedicalExaminations_MedicalExaminationId` FOREIGN KEY (`MedicalExaminationId`) REFERENCES `MedicalExaminations` (`Id`) ON DELETE CASCADE
);

INSERT INTO `Rooms` (`Id`, `DoctorId`, `FromDateTime`, `RoomId`, `ToDateTime`)
VALUES (1, 1, '0001-01-01 00:00:00', '101', '0001-01-01 00:00:00');

INSERT INTO `Rooms` (`Id`, `DoctorId`, `FromDateTime`, `RoomId`, `ToDateTime`)
VALUES (2, 1, '0001-01-01 00:00:00', '201', '0001-01-01 00:00:00');

INSERT INTO `Rooms` (`Id`, `DoctorId`, `FromDateTime`, `RoomId`, `ToDateTime`)
VALUES (3, 1, '0001-01-01 00:00:00', '301', '0001-01-01 00:00:00');

INSERT INTO `DoctorWorkDays` (`Id`, `Date`, `DoctorId`, `RoomId`)
VALUES (1, '2020-12-20 00:00:00', 1, 1);
INSERT INTO `DoctorWorkDays` (`Id`, `Date`, `DoctorId`, `RoomId`)
VALUES (5, '2021-12-21 00:00:00', 2, 3);
INSERT INTO `DoctorWorkDays` (`Id`, `Date`, `DoctorId`, `RoomId`)
VALUES (9, '2020-11-29 00:00:00', 6, 3);
INSERT INTO `DoctorWorkDays` (`Id`, `Date`, `DoctorId`, `RoomId`)
VALUES (12, '2020-12-22 00:00:00', 2, 2);
INSERT INTO `DoctorWorkDays` (`Id`, `Date`, `DoctorId`, `RoomId`)
VALUES (8, '2020-11-28 00:00:00', 7, 2);
INSERT INTO `DoctorWorkDays` (`Id`, `Date`, `DoctorId`, `RoomId`)
VALUES (7, '2020-11-23 00:00:00', 8, 2);
INSERT INTO `DoctorWorkDays` (`Id`, `Date`, `DoctorId`, `RoomId`)
VALUES (3, '2021-12-25 00:00:00', 3, 2);
INSERT INTO `DoctorWorkDays` (`Id`, `Date`, `DoctorId`, `RoomId`)
VALUES (4, '2020-12-20 00:00:00', 4, 3);
INSERT INTO `DoctorWorkDays` (`Id`, `Date`, `DoctorId`, `RoomId`)
VALUES (2, '2021-12-18 00:00:00', 2, 2);
INSERT INTO `DoctorWorkDays` (`Id`, `Date`, `DoctorId`, `RoomId`)
VALUES (13, '2020-12-28 00:00:00', 1, 3);
INSERT INTO `DoctorWorkDays` (`Id`, `Date`, `DoctorId`, `RoomId`)
VALUES (14, '2021-04-04 00:00:00', 1, 1);
INSERT INTO `DoctorWorkDays` (`Id`, `Date`, `DoctorId`, `RoomId`)
VALUES (11, '2020-12-24 00:00:00', 1, 1);
INSERT INTO `DoctorWorkDays` (`Id`, `Date`, `DoctorId`, `RoomId`)
VALUES (6, '2020-11-21 00:00:00', 9, 1);
INSERT INTO `DoctorWorkDays` (`Id`, `Date`, `DoctorId`, `RoomId`)
VALUES (10, '2020-11-30 00:00:00', 5, 3);

INSERT INTO `MedicalExaminations` (`Id`, `DoctorId`, `FromDateTime`, `PatientId`, `RoomId`, `ShortDescription`, `SurveyFilled`, `ToDateTime`)
VALUES (3, 2, '0001-01-01 00:00:00', 1, 3, 'Sve je bilo u redu na pregledu', FALSE, '0001-01-01 00:00:00');
INSERT INTO `MedicalExaminations` (`Id`, `DoctorId`, `FromDateTime`, `PatientId`, `RoomId`, `ShortDescription`, `SurveyFilled`, `ToDateTime`)
VALUES (6, 4, '0001-01-01 00:00:00', 1, 3, 'Sve je bilo u redu na pregledu', FALSE, '0001-01-01 00:00:00');
INSERT INTO `MedicalExaminations` (`Id`, `DoctorId`, `FromDateTime`, `PatientId`, `RoomId`, `ShortDescription`, `SurveyFilled`, `ToDateTime`)
VALUES (9, 7, '0001-01-01 00:00:00', 5, 2, 'Pacijenta je boleo stomak', FALSE, '0001-01-01 00:00:00');
INSERT INTO `MedicalExaminations` (`Id`, `DoctorId`, `FromDateTime`, `PatientId`, `RoomId`, `ShortDescription`, `SurveyFilled`, `ToDateTime`)
VALUES (2, 2, '0001-01-01 00:00:00', 1, 2, 'Pacijent je imao glavobolju', FALSE, '0001-01-01 00:00:00');
INSERT INTO `MedicalExaminations` (`Id`, `DoctorId`, `FromDateTime`, `PatientId`, `RoomId`, `ShortDescription`, `SurveyFilled`, `ToDateTime`)
VALUES (5, 2, '0001-01-01 00:00:00', 3, 2, 'Pacijenta je boleo stomak', FALSE, '0001-01-01 00:00:00');
INSERT INTO `MedicalExaminations` (`Id`, `DoctorId`, `FromDateTime`, `PatientId`, `RoomId`, `ShortDescription`, `SurveyFilled`, `ToDateTime`)
VALUES (4, 3, '0001-01-01 00:00:00', 1, 2, 'Pacijenta je boleo stomak', FALSE, '0001-01-01 00:00:00');
INSERT INTO `MedicalExaminations` (`Id`, `DoctorId`, `FromDateTime`, `PatientId`, `RoomId`, `ShortDescription`, `SurveyFilled`, `ToDateTime`)
VALUES (10, 6, '0001-01-01 00:00:00', 6, 3, 'Sve je bilo u redu na pregledu', FALSE, '0001-01-01 00:00:00');
INSERT INTO `MedicalExaminations` (`Id`, `DoctorId`, `FromDateTime`, `PatientId`, `RoomId`, `ShortDescription`, `SurveyFilled`, `ToDateTime`)
VALUES (13, 1, '0001-01-01 00:00:00', 1, 1, 'Pacijenta je boleo stomak', FALSE, '0001-01-01 00:00:00');
INSERT INTO `MedicalExaminations` (`Id`, `DoctorId`, `FromDateTime`, `PatientId`, `RoomId`, `ShortDescription`, `SurveyFilled`, `ToDateTime`)
VALUES (12, 9, '0001-01-01 00:00:00', 1, 1, 'Pacijenta je boleo stomak', FALSE, '0001-01-01 00:00:00');
INSERT INTO `MedicalExaminations` (`Id`, `DoctorId`, `FromDateTime`, `PatientId`, `RoomId`, `ShortDescription`, `SurveyFilled`, `ToDateTime`)
VALUES (7, 9, '0001-01-01 00:00:00', 5, 1, 'Sve je bilo u redu na pregledu', FALSE, '0001-01-01 00:00:00');
INSERT INTO `MedicalExaminations` (`Id`, `DoctorId`, `FromDateTime`, `PatientId`, `RoomId`, `ShortDescription`, `SurveyFilled`, `ToDateTime`)
VALUES (1, 1, '0001-01-01 00:00:00', 2, 1, 'Sve je bilo u redu na pregledu', FALSE, '0001-01-01 00:00:00');
INSERT INTO `MedicalExaminations` (`Id`, `DoctorId`, `FromDateTime`, `PatientId`, `RoomId`, `ShortDescription`, `SurveyFilled`, `ToDateTime`)
VALUES (8, 8, '0001-01-01 00:00:00', 5, 2, 'Pacijenta je boleo stomak', FALSE, '0001-01-01 00:00:00');
INSERT INTO `MedicalExaminations` (`Id`, `DoctorId`, `FromDateTime`, `PatientId`, `RoomId`, `ShortDescription`, `SurveyFilled`, `ToDateTime`)
VALUES (11, 5, '0001-01-01 00:00:00', 6, 3, 'Sve je bilo u redu na pregledu', FALSE, '0001-01-01 00:00:00');

INSERT INTO `Appointments` (`Id`, `Canceled`, `CancellationDate`, `DoctorWorkDayId`, `EndTime`, `MedicalExaminationId`, `StartTime`)
VALUES (1, FALSE, '0001-01-01 00:00:00', 1, '2020-12-20 08:30:00', 1, '2020-12-20 08:00:00');
INSERT INTO `Appointments` (`Id`, `Canceled`, `CancellationDate`, `DoctorWorkDayId`, `EndTime`, `MedicalExaminationId`, `StartTime`)
VALUES (9, TRUE, '2020-11-18 08:00:00', 6, '2020-11-21 08:30:00', 7, '2020-11-21 08:00:00');
INSERT INTO `Appointments` (`Id`, `Canceled`, `CancellationDate`, `DoctorWorkDayId`, `EndTime`, `MedicalExaminationId`, `StartTime`)
VALUES (14, TRUE, '2020-11-18 08:00:00', 6, '2020-11-21 09:30:00', 12, '2020-11-21 09:00:00');
INSERT INTO `Appointments` (`Id`, `Canceled`, `CancellationDate`, `DoctorWorkDayId`, `EndTime`, `MedicalExaminationId`, `StartTime`)
VALUES (15, FALSE, '0001-01-01 00:00:00', 14, '2021-04-04 09:30:00', 12, '2021-04-04 09:00:00');
INSERT INTO `Appointments` (`Id`, `Canceled`, `CancellationDate`, `DoctorWorkDayId`, `EndTime`, `MedicalExaminationId`, `StartTime`)
VALUES (2, FALSE, '0001-01-01 00:00:00', 2, '2021-12-18 09:00:00', 2, '2021-12-18 08:30:00');
INSERT INTO `Appointments` (`Id`, `Canceled`, `CancellationDate`, `DoctorWorkDayId`, `EndTime`, `MedicalExaminationId`, `StartTime`)
VALUES (3, TRUE, '2020-12-22 08:30:00', 3, '2021-12-25 09:00:00', 4, '2021-12-25 08:30:00');
INSERT INTO `Appointments` (`Id`, `Canceled`, `CancellationDate`, `DoctorWorkDayId`, `EndTime`, `MedicalExaminationId`, `StartTime`)
VALUES (7, FALSE, '0001-01-01 00:00:00', 2, '2020-12-18 16:00:00', 5, '2020-12-18 15:30:00');
INSERT INTO `Appointments` (`Id`, `Canceled`, `CancellationDate`, `DoctorWorkDayId`, `EndTime`, `MedicalExaminationId`, `StartTime`)
VALUES (10, TRUE, '2020-11-20 08:00:00', 7, '2020-11-23 08:30:00', 8, '2020-11-23 08:00:00');
INSERT INTO `Appointments` (`Id`, `Canceled`, `CancellationDate`, `DoctorWorkDayId`, `EndTime`, `MedicalExaminationId`, `StartTime`)
VALUES (11, TRUE, '2020-11-25 08:00:00', 8, '2020-11-28 08:30:00', 9, '2020-11-28 08:00:00');
INSERT INTO `Appointments` (`Id`, `Canceled`, `CancellationDate`, `DoctorWorkDayId`, `EndTime`, `MedicalExaminationId`, `StartTime`)
VALUES (5, FALSE, '0001-01-01 00:00:00', 4, '2020-12-10 12:30:00', 4, '2020-12-10 12:00:00');
INSERT INTO `Appointments` (`Id`, `Canceled`, `CancellationDate`, `DoctorWorkDayId`, `EndTime`, `MedicalExaminationId`, `StartTime`)
VALUES (6, FALSE, '0001-01-01 00:00:00', 4, '2020-12-09 16:00:00', 2, '2020-12-09 15:30:00');
INSERT INTO `Appointments` (`Id`, `Canceled`, `CancellationDate`, `DoctorWorkDayId`, `EndTime`, `MedicalExaminationId`, `StartTime`)
VALUES (8, FALSE, '0001-01-01 00:00:00', 5, '2021-12-21 09:00:00', 3, '2021-12-21 08:30:00');
INSERT INTO `Appointments` (`Id`, `Canceled`, `CancellationDate`, `DoctorWorkDayId`, `EndTime`, `MedicalExaminationId`, `StartTime`)
VALUES (4, FALSE, '0001-01-01 00:00:00', 4, '2020-12-20 09:00:00', 6, '2020-12-20 08:30:00');
INSERT INTO `Appointments` (`Id`, `Canceled`, `CancellationDate`, `DoctorWorkDayId`, `EndTime`, `MedicalExaminationId`, `StartTime`)
VALUES (12, TRUE, '2020-11-26 08:00:00', 9, '2020-11-29 08:30:00', 10, '2020-11-29 08:00:00');
INSERT INTO `Appointments` (`Id`, `Canceled`, `CancellationDate`, `DoctorWorkDayId`, `EndTime`, `MedicalExaminationId`, `StartTime`)
VALUES (13, TRUE, '2020-11-27 08:00:00', 10, '2020-11-30 08:30:00', 11, '2020-11-30 08:00:00');

CREATE INDEX `IX_Appointments_DoctorWorkDayId` ON `Appointments` (`DoctorWorkDayId`);

CREATE INDEX `IX_Appointments_MedicalExaminationId` ON `Appointments` (`MedicalExaminationId`);

CREATE INDEX `IX_DoctorWorkDays_RoomId` ON `DoctorWorkDays` (`RoomId`);

CREATE INDEX `IX_MedicalExaminations_RoomId` ON `MedicalExaminations` (`RoomId`);

