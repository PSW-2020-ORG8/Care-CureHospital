use EventSourcingDB;
CREATE TABLE `LoginEvents` (
    `Id` char(36) NOT NULL,
    `TimeStamp` datetime(6) NOT NULL,
    `UserName` longtext CHARACTER SET utf8mb4 NULL,
    `UserId` int NOT NULL,
    CONSTRAINT `PK_LoginEvents` PRIMARY KEY (`Id`)
);

CREATE TABLE `URLEvents` (
    `Id` char(36) NOT NULL,
    `TimeStamp` datetime(6) NOT NULL,
    `Url` longtext CHARACTER SET utf8mb4 NULL,
    `Method` longtext CHARACTER SET utf8mb4 NULL,
    CONSTRAINT `PK_URLEvents` PRIMARY KEY (`Id`)
);

