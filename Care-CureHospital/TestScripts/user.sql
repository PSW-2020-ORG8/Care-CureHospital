use HealthClinicDB;
CREATE TABLE `Countries` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Name` longtext CHARACTER SET utf8mb4 NULL,
    CONSTRAINT `PK_Countries` PRIMARY KEY (`Id`)
);

CREATE TABLE `Specialitation` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `SpecialitationForDoctor` longtext CHARACTER SET utf8mb4 NULL,
    CONSTRAINT `PK_Specialitation` PRIMARY KEY (`Id`)
);

CREATE TABLE `Cities` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Name` longtext CHARACTER SET utf8mb4 NULL,
    `Address` longtext CHARACTER SET utf8mb4 NULL,
    `CountryId` int NOT NULL,
    CONSTRAINT `PK_Cities` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_Cities_Countries_CountryId` FOREIGN KEY (`CountryId`) REFERENCES `Countries` (`Id`) ON DELETE CASCADE
);

CREATE TABLE `Doctor` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Name` longtext CHARACTER SET utf8mb4 NULL,
    `ParentName` longtext CHARACTER SET utf8mb4 NULL,
    `Surname` longtext CHARACTER SET utf8mb4 NULL,
    `Gender` int NOT NULL,
    `Jmbg` longtext CHARACTER SET utf8mb4 NULL,
    `IdentityCard` longtext CHARACTER SET utf8mb4 NULL,
    `HealthInsuranceCard` longtext CHARACTER SET utf8mb4 NULL,
    `BloodGroup` int NOT NULL,
    `DateOfBirth` datetime(6) NOT NULL,
    `ContactNumber` longtext CHARACTER SET utf8mb4 NULL,
    `EMail` longtext CHARACTER SET utf8mb4 NULL,
    `CityId` int NOT NULL,
    `Username` longtext CHARACTER SET utf8mb4 NULL,
    `Password` longtext CHARACTER SET utf8mb4 NULL,
    `Role` longtext CHARACTER SET utf8mb4 NULL,
    `SpecialitationId` int NOT NULL,
    CONSTRAINT `PK_Doctor` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_Doctor_Cities_CityId` FOREIGN KEY (`CityId`) REFERENCES `Cities` (`Id`) ON DELETE CASCADE,
    CONSTRAINT `FK_Doctor_Specialitation_SpecialitationId` FOREIGN KEY (`SpecialitationId`) REFERENCES `Specialitation` (`Id`) ON DELETE CASCADE
);

CREATE TABLE `Patients` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Name` longtext CHARACTER SET utf8mb4 NULL,
    `ParentName` longtext CHARACTER SET utf8mb4 NULL,
    `Surname` longtext CHARACTER SET utf8mb4 NULL,
    `Gender` int NOT NULL,
    `Jmbg` longtext CHARACTER SET utf8mb4 NULL,
    `IdentityCard` longtext CHARACTER SET utf8mb4 NULL,
    `HealthInsuranceCard` longtext CHARACTER SET utf8mb4 NULL,
    `BloodGroup` int NOT NULL,
    `DateOfBirth` datetime(6) NOT NULL,
    `ContactNumber` longtext CHARACTER SET utf8mb4 NULL,
    `EMail` longtext CHARACTER SET utf8mb4 NULL,
    `CityId` int NOT NULL,
    `Username` longtext CHARACTER SET utf8mb4 NULL,
    `Password` longtext CHARACTER SET utf8mb4 NULL,
    `Role` longtext CHARACTER SET utf8mb4 NULL,
    `GuestAccount` tinyint(1) NOT NULL,
    `Blocked` tinyint(1) NOT NULL,
    `Malicious` tinyint(1) NOT NULL,
    CONSTRAINT `PK_Patients` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_Patients_Cities_CityId` FOREIGN KEY (`CityId`) REFERENCES `Cities` (`Id`) ON DELETE CASCADE
);

CREATE TABLE `SystemAdministrators` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Name` longtext CHARACTER SET utf8mb4 NULL,
    `ParentName` longtext CHARACTER SET utf8mb4 NULL,
    `Surname` longtext CHARACTER SET utf8mb4 NULL,
    `Gender` int NOT NULL,
    `Jmbg` longtext CHARACTER SET utf8mb4 NULL,
    `IdentityCard` longtext CHARACTER SET utf8mb4 NULL,
    `HealthInsuranceCard` longtext CHARACTER SET utf8mb4 NULL,
    `BloodGroup` int NOT NULL,
    `DateOfBirth` datetime(6) NOT NULL,
    `ContactNumber` longtext CHARACTER SET utf8mb4 NULL,
    `EMail` longtext CHARACTER SET utf8mb4 NULL,
    `CityId` int NOT NULL,
    `Username` longtext CHARACTER SET utf8mb4 NULL,
    `Password` longtext CHARACTER SET utf8mb4 NULL,
    `Role` longtext CHARACTER SET utf8mb4 NULL,
    CONSTRAINT `PK_SystemAdministrators` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_SystemAdministrators_Cities_CityId` FOREIGN KEY (`CityId`) REFERENCES `Cities` (`Id`) ON DELETE CASCADE
);

INSERT INTO `Countries` (`Id`, `Name`)
VALUES (1, 'Srbija');

INSERT INTO `Specialitation` (`Id`, `SpecialitationForDoctor`)
VALUES (1, 'Lekar opste prakse');
INSERT INTO `Specialitation` (`Id`, `SpecialitationForDoctor`)
VALUES (2, 'Ortoped');
INSERT INTO `Specialitation` (`Id`, `SpecialitationForDoctor`)
VALUES (3, 'Kardiolog');
INSERT INTO `Specialitation` (`Id`, `SpecialitationForDoctor`)
VALUES (4, 'Dermatolog');
INSERT INTO `Specialitation` (`Id`, `SpecialitationForDoctor`)
VALUES (5, 'Endokrinolog');

INSERT INTO `Cities` (`Id`, `Address`, `CountryId`, `Name`)
VALUES (1, 'Brace Jerkovic 1', 1, 'Beograd');

INSERT INTO `Cities` (`Id`, `Address`, `CountryId`, `Name`)
VALUES (2, 'Bulevar Cara Lazara 1', 1, 'Novi Sad');

INSERT INTO `Doctor` (`Id`, `BloodGroup`, `CityId`, `ContactNumber`, `DateOfBirth`, `EMail`, `Gender`, `HealthInsuranceCard`, `IdentityCard`, `Jmbg`, `Name`, `ParentName`, `Password`, `Role`, `SpecialitationId`, `Surname`, `Username`)
VALUES (2, 0, 1, '06345111144', '2004-01-01 03:03:03', 'aca@gmail.com', 0, NULL, NULL, '13212312312312', 'Aleksandar', NULL, '123', NULL, 1, 'Aleksic', 'aca');
INSERT INTO `Doctor` (`Id`, `BloodGroup`, `CityId`, `ContactNumber`, `DateOfBirth`, `EMail`, `Gender`, `HealthInsuranceCard`, `IdentityCard`, `Jmbg`, `Name`, `ParentName`, `Password`, `Role`, `SpecialitationId`, `Surname`, `Username`)
VALUES (4, 0, 1, '06345111144', '2004-01-01 03:03:03', 'nikola@gmail.com', 0, NULL, NULL, '13316712312312', 'Nikola', NULL, '123', NULL, 1, 'Nikic', 'nikola');
INSERT INTO `Doctor` (`Id`, `BloodGroup`, `CityId`, `ContactNumber`, `DateOfBirth`, `EMail`, `Gender`, `HealthInsuranceCard`, `IdentityCard`, `Jmbg`, `Name`, `ParentName`, `Password`, `Role`, `SpecialitationId`, `Surname`, `Username`)
VALUES (6, 0, 1, '06345111144', '2004-01-01 03:03:03', 'vuk@gmail.com', 0, NULL, NULL, '13316712312312', 'Vuk', NULL, '123', NULL, 3, 'Vukic', 'vuk');
INSERT INTO `Doctor` (`Id`, `BloodGroup`, `CityId`, `ContactNumber`, `DateOfBirth`, `EMail`, `Gender`, `HealthInsuranceCard`, `IdentityCard`, `Jmbg`, `Name`, `ParentName`, `Password`, `Role`, `SpecialitationId`, `Surname`, `Username`)
VALUES (8, 0, 1, '06345111144', '2004-01-01 03:03:03', 'marija@gmail.com', 0, NULL, NULL, '13316712312312', 'Marija', NULL, '123', NULL, 4, 'Marijic', 'marija');
INSERT INTO `Doctor` (`Id`, `BloodGroup`, `CityId`, `ContactNumber`, `DateOfBirth`, `EMail`, `Gender`, `HealthInsuranceCard`, `IdentityCard`, `Jmbg`, `Name`, `ParentName`, `Password`, `Role`, `SpecialitationId`, `Surname`, `Username`)
VALUES (9, 0, 1, '06345111144', '2004-01-01 03:03:03', 'tanja@gmail.com', 0, NULL, NULL, '13316712312312', 'Tanja', NULL, '123', NULL, 5, 'Tankosic', 'tanja');
INSERT INTO `Doctor` (`Id`, `BloodGroup`, `CityId`, `ContactNumber`, `DateOfBirth`, `EMail`, `Gender`, `HealthInsuranceCard`, `IdentityCard`, `Jmbg`, `Name`, `ParentName`, `Password`, `Role`, `SpecialitationId`, `Surname`, `Username`)
VALUES (7, 0, 2, '06345111144', '2005-01-01 03:03:03', 'helena@gmail.com', 0, NULL, NULL, '13312367312312', 'Helena', NULL, '123', NULL, 4, 'Kostic', 'helena');
INSERT INTO `Doctor` (`Id`, `BloodGroup`, `CityId`, `ContactNumber`, `DateOfBirth`, `EMail`, `Gender`, `HealthInsuranceCard`, `IdentityCard`, `Jmbg`, `Name`, `ParentName`, `Password`, `Role`, `SpecialitationId`, `Surname`, `Username`)
VALUES (5, 0, 2, '06345111144', '2005-01-01 03:03:03', 'mihajlo@gmail.com', 0, NULL, NULL, '13312367312312', 'Mihajlo', NULL, '123', NULL, 3, 'Mihajlovic', 'mihajlo');
INSERT INTO `Doctor` (`Id`, `BloodGroup`, `CityId`, `ContactNumber`, `DateOfBirth`, `EMail`, `Gender`, `HealthInsuranceCard`, `IdentityCard`, `Jmbg`, `Name`, `ParentName`, `Password`, `Role`, `SpecialitationId`, `Surname`, `Username`)
VALUES (1, 0, 2, '06345111144', '2000-01-01 03:03:03', 'milan@gmail.com', 0, NULL, NULL, '13312312312312', 'Milan', NULL, '123', NULL, 1, 'Petrovic', 'milan');
INSERT INTO `Doctor` (`Id`, `BloodGroup`, `CityId`, `ContactNumber`, `DateOfBirth`, `EMail`, `Gender`, `HealthInsuranceCard`, `IdentityCard`, `Jmbg`, `Name`, `ParentName`, `Password`, `Role`, `SpecialitationId`, `Surname`, `Username`)
VALUES (3, 0, 2, '06345111144', '2005-01-01 03:03:03', 'jovan@gmail.com', 0, NULL, NULL, '13312367312312', 'Jovan', NULL, '123', NULL, 2, 'Jovic', 'jovan');

INSERT INTO `Patients` (`Id`, `Blocked`, `BloodGroup`, `CityId`, `ContactNumber`, `DateOfBirth`, `EMail`, `Gender`, `GuestAccount`, `HealthInsuranceCard`, `IdentityCard`, `Jmbg`, `Malicious`, `Name`, `ParentName`, `Password`, `Role`, `Surname`, `Username`)
VALUES (4, FALSE, 2, 2, '063555356', '2004-01-01 03:03:03', 'luna@gmail.com', 1, FALSE, '52312312312', '127123123', '12312316712312', FALSE, 'Luna', 'Jovan', '123', 'Patient', 'Lunic', 'luna');
INSERT INTO `Patients` (`Id`, `Blocked`, `BloodGroup`, `CityId`, `ContactNumber`, `DateOfBirth`, `EMail`, `Gender`, `GuestAccount`, `HealthInsuranceCard`, `IdentityCard`, `Jmbg`, `Malicious`, `Name`, `ParentName`, `Password`, `Role`, `Surname`, `Username`)
VALUES (2, FALSE, 2, 2, '0635235333', '2001-01-01 03:03:03', 'zika@gmail.com', 0, FALSE, '712312312312', '124123123', '12342312312312', FALSE, 'Zika', 'Pera', '123', 'Patient', 'Zikic', 'zika');
INSERT INTO `Patients` (`Id`, `Blocked`, `BloodGroup`, `CityId`, `ContactNumber`, `DateOfBirth`, `EMail`, `Gender`, `GuestAccount`, `HealthInsuranceCard`, `IdentityCard`, `Jmbg`, `Malicious`, `Name`, `ParentName`, `Password`, `Role`, `Surname`, `Username`)
VALUES (6, FALSE, 2, 2, '063555312', '2004-01-01 03:03:03', 'marko@gmail.com', 0, FALSE, '52312312311', '127123333', '12312316712344', TRUE, 'Marko', 'Jovan', '123', 'Patient', 'Markovic', 'marko');
INSERT INTO `Patients` (`Id`, `Blocked`, `BloodGroup`, `CityId`, `ContactNumber`, `DateOfBirth`, `EMail`, `Gender`, `GuestAccount`, `HealthInsuranceCard`, `IdentityCard`, `Jmbg`, `Malicious`, `Name`, `ParentName`, `Password`, `Role`, `Surname`, `Username`)
VALUES (3, FALSE, 0, 1, '0635557673', '2002-01-01 03:03:03', 'mica@gmail.com', 0, FALSE, '62312312312', '163123123', '12312512312312', FALSE, 'Mica', 'Jelena', '123', 'Patient', 'Micic', 'mica');
INSERT INTO `Patients` (`Id`, `Blocked`, `BloodGroup`, `CityId`, `ContactNumber`, `DateOfBirth`, `EMail`, `Gender`, `GuestAccount`, `HealthInsuranceCard`, `IdentityCard`, `Jmbg`, `Malicious`, `Name`, `ParentName`, `Password`, `Role`, `Surname`, `Username`)
VALUES (1, FALSE, 2, 1, '063554533', '2000-01-01 03:03:03', 'pera@gmail.com', 0, FALSE, '32312312312', '123123123', '13312312312312', FALSE, 'Petar', 'Zika', '123', 'Patient', 'Petrovic', 'pera');
INSERT INTO `Patients` (`Id`, `Blocked`, `BloodGroup`, `CityId`, `ContactNumber`, `DateOfBirth`, `EMail`, `Gender`, `GuestAccount`, `HealthInsuranceCard`, `IdentityCard`, `Jmbg`, `Malicious`, `Name`, `ParentName`, `Password`, `Role`, `Surname`, `Username`)
VALUES (5, FALSE, 2, 2, '063775356', '2004-01-01 03:03:03', 'ivan@gmail.com', 0, FALSE, '52318812312', '127199123', '12344316712312', TRUE, 'Ivan', 'Luka', '123', 'Patient', 'Ivanovic', 'ivan');

INSERT INTO `SystemAdministrators` (`Id`, `BloodGroup`, `CityId`, `ContactNumber`, `DateOfBirth`, `EMail`, `Gender`, `HealthInsuranceCard`, `IdentityCard`, `Jmbg`, `Name`, `ParentName`, `Password`, `Role`, `Surname`, `Username`)
VALUES (1, 0, 1, '063775356', '1998-01-01 03:03:03', 'vladislav@gmail.com', 0, NULL, NULL, '12312316712345', 'Vladislav', NULL, 'admin1', 'Admin', 'Petkovic', 'admin1');
INSERT INTO `SystemAdministrators` (`Id`, `BloodGroup`, `CityId`, `ContactNumber`, `DateOfBirth`, `EMail`, `Gender`, `HealthInsuranceCard`, `IdentityCard`, `Jmbg`, `Name`, `ParentName`, `Password`, `Role`, `Surname`, `Username`)
VALUES (2, 0, 1, '063775356', '1998-01-01 03:03:03', 'dusan@gmail.com', 0, NULL, NULL, '12312316712345', 'Dusan', NULL, 'admin2', 'Admin', 'Vasiljev', 'admin2');

CREATE INDEX `IX_Cities_CountryId` ON `Cities` (`CountryId`);

CREATE INDEX `IX_Doctor_CityId` ON `Doctor` (`CityId`);

CREATE INDEX `IX_Doctor_SpecialitationId` ON `Doctor` (`SpecialitationId`);

CREATE INDEX `IX_Patients_CityId` ON `Patients` (`CityId`);

CREATE INDEX `IX_SystemAdministrators_CityId` ON `SystemAdministrators` (`CityId`);

