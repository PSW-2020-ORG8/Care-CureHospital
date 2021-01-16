CREATE TABLE `Anamnesies` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Description` longtext CHARACTER SET utf8mb4 NULL,
    CONSTRAINT `PK_Anamnesies` PRIMARY KEY (`Id`)
);

CREATE TABLE `MedicalExaminationReport` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Comment` longtext CHARACTER SET utf8mb4 NULL,
    `PublishingDate` datetime(6) NOT NULL,
    `MedicalExaminationId` int NOT NULL,
    CONSTRAINT `PK_MedicalExaminationReport` PRIMARY KEY (`Id`)
);

CREATE TABLE `Prescription` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Comment` longtext CHARACTER SET utf8mb4 NULL,
    `PublishingDate` datetime(6) NOT NULL,
    `MedicalExaminationId` int NOT NULL,
    CONSTRAINT `PK_Prescription` PRIMARY KEY (`Id`)
);

CREATE TABLE `Diagnosies` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Name` longtext CHARACTER SET utf8mb4 NULL,
    `AnamnesisId` int NOT NULL,
    CONSTRAINT `PK_Diagnosies` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_Diagnosies_Anamnesies_AnamnesisId` FOREIGN KEY (`AnamnesisId`) REFERENCES `Anamnesies` (`Id`) ON DELETE CASCADE
);

CREATE TABLE `MedicalRecords` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `AnamnesisId` int NOT NULL,
    `ActiveMedicalRecord` tinyint(1) NOT NULL,
    `PatientId` int NOT NULL,
    CONSTRAINT `PK_MedicalRecords` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_MedicalRecords_Anamnesies_AnamnesisId` FOREIGN KEY (`AnamnesisId`) REFERENCES `Anamnesies` (`Id`) ON DELETE CASCADE
);

CREATE TABLE `Symptomes` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Name` longtext CHARACTER SET utf8mb4 NULL,
    `AnamnesisId` int NOT NULL,
    CONSTRAINT `PK_Symptomes` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_Symptomes_Anamnesies_AnamnesisId` FOREIGN KEY (`AnamnesisId`) REFERENCES `Anamnesies` (`Id`) ON DELETE CASCADE
);

CREATE TABLE `Allergies` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Name` longtext CHARACTER SET utf8mb4 NULL,
    `MedicalRecordId` int NOT NULL,
    CONSTRAINT `PK_Allergies` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_Allergies_MedicalRecords_MedicalRecordId` FOREIGN KEY (`MedicalRecordId`) REFERENCES `MedicalRecords` (`Id`) ON DELETE CASCADE
);

CREATE TABLE `Medicaments` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Name` longtext CHARACTER SET utf8mb4 NULL,
    `MedicalRecordId` int NOT NULL,
    `PrescriptionId` int NOT NULL,
    CONSTRAINT `PK_Medicaments` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_Medicaments_MedicalRecords_MedicalRecordId` FOREIGN KEY (`MedicalRecordId`) REFERENCES `MedicalRecords` (`Id`) ON DELETE CASCADE,
    CONSTRAINT `FK_Medicaments_Prescription_PrescriptionId` FOREIGN KEY (`PrescriptionId`) REFERENCES `Prescription` (`Id`) ON DELETE CASCADE
);

INSERT INTO `Anamnesies` (`Id`, `Description`)
VALUES (1, 'Pacijent je dobro');
INSERT INTO `Anamnesies` (`Id`, `Description`)
VALUES (2, 'Pacijent je loše');
INSERT INTO `Anamnesies` (`Id`, `Description`)
VALUES (3, 'Pacijent je vrlo dobro');

INSERT INTO `MedicalExaminationReport` (`Id`, `Comment`, `MedicalExaminationId`, `PublishingDate`)
VALUES (1, 'Pacijent je dobro i nema vecih problema', 3, '2020-09-20 10:30:00');
INSERT INTO `MedicalExaminationReport` (`Id`, `Comment`, `MedicalExaminationId`, `PublishingDate`)
VALUES (2, 'Pacijent je veoma dobro i nema vecih problema', 4, '2020-11-23 10:30:00');
INSERT INTO `MedicalExaminationReport` (`Id`, `Comment`, `MedicalExaminationId`, `PublishingDate`)
VALUES (3, 'Pacijent ima virus', 2, '2020-09-12 10:30:00');
INSERT INTO `MedicalExaminationReport` (`Id`, `Comment`, `MedicalExaminationId`, `PublishingDate`)
VALUES (4, 'Pacijent je lose', 2, '2020-10-14 10:30:00');
INSERT INTO `MedicalExaminationReport` (`Id`, `Comment`, `MedicalExaminationId`, `PublishingDate`)
VALUES (5, 'Pacijent ima virus', 2, '2020-11-18 10:30:00');

INSERT INTO `Prescription` (`Id`, `Comment`, `MedicalExaminationId`, `PublishingDate`)
VALUES (1, 'Redovno koristite prepisane lekove', 4, '2020-11-30 10:30:00');
INSERT INTO `Prescription` (`Id`, `Comment`, `MedicalExaminationId`, `PublishingDate`)
VALUES (2, 'Svakodnevno koristite prepisani lek', 3, '2020-09-12 10:30:00');
INSERT INTO `Prescription` (`Id`, `Comment`, `MedicalExaminationId`, `PublishingDate`)
VALUES (3, 'Redovno koristite prepisane lekove', 2, '2020-12-25 10:30:00');
INSERT INTO `Prescription` (`Id`, `Comment`, `MedicalExaminationId`, `PublishingDate`)
VALUES (4, 'Ne preskacite konzumiranje leka', 2, '2020-10-12 03:30:00');
INSERT INTO `Prescription` (`Id`, `Comment`, `MedicalExaminationId`, `PublishingDate`)
VALUES (5, 'Redovno koristite prepisane lekove', 4, '2020-11-26 10:30:00');

INSERT INTO `Diagnosies` (`Id`, `AnamnesisId`, `Name`)
VALUES (1, 1, 'Prehlada');
INSERT INTO `Diagnosies` (`Id`, `AnamnesisId`, `Name`)
VALUES (2, 2, 'Virus');
INSERT INTO `Diagnosies` (`Id`, `AnamnesisId`, `Name`)
VALUES (3, 2, 'Migrena');

INSERT INTO `MedicalRecords` (`Id`, `ActiveMedicalRecord`, `AnamnesisId`, `PatientId`)
VALUES (1, TRUE, 1, 1);
INSERT INTO `MedicalRecords` (`Id`, `ActiveMedicalRecord`, `AnamnesisId`, `PatientId`)
VALUES (2, TRUE, 1, 2);
INSERT INTO `MedicalRecords` (`Id`, `ActiveMedicalRecord`, `AnamnesisId`, `PatientId`)
VALUES (3, TRUE, 1, 3);
INSERT INTO `MedicalRecords` (`Id`, `ActiveMedicalRecord`, `AnamnesisId`, `PatientId`)
VALUES (4, TRUE, 1, 4);
INSERT INTO `MedicalRecords` (`Id`, `ActiveMedicalRecord`, `AnamnesisId`, `PatientId`)
VALUES (5, TRUE, 1, 5);
INSERT INTO `MedicalRecords` (`Id`, `ActiveMedicalRecord`, `AnamnesisId`, `PatientId`)
VALUES (6, TRUE, 1, 6);

INSERT INTO `Symptomes` (`Id`, `AnamnesisId`, `Name`)
VALUES (2, 1, 'Kašalj');
INSERT INTO `Symptomes` (`Id`, `AnamnesisId`, `Name`)
VALUES (1, 2, 'Temperatura');
INSERT INTO `Symptomes` (`Id`, `AnamnesisId`, `Name`)
VALUES (3, 2, 'Glavobolja');

INSERT INTO `Allergies` (`Id`, `MedicalRecordId`, `Name`)
VALUES (1, 1, 'Penicilin');
INSERT INTO `Allergies` (`Id`, `MedicalRecordId`, `Name`)
VALUES (4, 1, 'Ambrozija');
INSERT INTO `Allergies` (`Id`, `MedicalRecordId`, `Name`)
VALUES (3, 2, 'Panadol');
INSERT INTO `Allergies` (`Id`, `MedicalRecordId`, `Name`)
VALUES (2, 3, 'Brufen');

INSERT INTO `Medicaments` (`Id`, `MedicalRecordId`, `Name`, `PrescriptionId`)
VALUES (1, 1, 'Brufen', 1);
INSERT INTO `Medicaments` (`Id`, `MedicalRecordId`, `Name`, `PrescriptionId`)
VALUES (5, 1, 'Panadol', 2);
INSERT INTO `Medicaments` (`Id`, `MedicalRecordId`, `Name`, `PrescriptionId`)
VALUES (2, 2, 'Panadol', 1);
INSERT INTO `Medicaments` (`Id`, `MedicalRecordId`, `Name`, `PrescriptionId`)
VALUES (3, 3, 'Paracetamol', 3);
INSERT INTO `Medicaments` (`Id`, `MedicalRecordId`, `Name`, `PrescriptionId`)
VALUES (4, 4, 'Vitamin B', 2);

CREATE INDEX `IX_Allergies_MedicalRecordId` ON `Allergies` (`MedicalRecordId`);

CREATE INDEX `IX_Diagnosies_AnamnesisId` ON `Diagnosies` (`AnamnesisId`);

CREATE INDEX `IX_MedicalRecords_AnamnesisId` ON `MedicalRecords` (`AnamnesisId`);

CREATE INDEX `IX_Medicaments_MedicalRecordId` ON `Medicaments` (`MedicalRecordId`);

CREATE INDEX `IX_Medicaments_PrescriptionId` ON `Medicaments` (`PrescriptionId`);

CREATE INDEX `IX_Symptomes_AnamnesisId` ON `Symptomes` (`AnamnesisId`);

