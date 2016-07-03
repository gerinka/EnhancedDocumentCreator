CREATE DATABASE  IF NOT EXISTS `mtc` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `mtc`;
-- MySQL dump 10.13  Distrib 5.7.9, for Win32 (AMD64)
--
-- Host: localhost    Database: mtc
-- ------------------------------------------------------
-- Server version	5.6.30

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `document`
--

DROP TABLE IF EXISTS `document`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `document` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `UserId` int(11) NOT NULL,
  `Deadline` datetime NOT NULL,
  `Title` varchar(100) NOT NULL,
  `CurrentProgress` int(11) NOT NULL DEFAULT '0',
  `MentorId` int(11) DEFAULT NULL,
  `DocumentTemplateId` int(11) NOT NULL,
  `DocumentState` int(11) NOT NULL DEFAULT '1',
  `MaxCycle` int(11) NOT NULL DEFAULT '1',
  `CurrentCycle` int(11) NOT NULL DEFAULT '1',
  `ActiveTasksCount` int(3) NOT NULL DEFAULT '1',
  PRIMARY KEY (`Id`),
  KEY `FK_DIplomasUser_ID_idx` (`UserId`),
  KEY `FK_DocumentMentor_ID_idx` (`MentorId`),
  KEY `FK_DocumentDocumentTemplate_ID_idx` (`DocumentTemplateId`),
  CONSTRAINT `FK_DocumentDocumentTemplate_ID` FOREIGN KEY (`DocumentTemplateId`) REFERENCES `documenttemplate` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `FK_DocumentMentor_ID` FOREIGN KEY (`MentorId`) REFERENCES `user` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `FK_DocumentUser_ID` FOREIGN KEY (`UserId`) REFERENCES `user` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=37 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `documentstructurerelation`
--

DROP TABLE IF EXISTS `documentstructurerelation`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `documentstructurerelation` (
  `DocumentTemplateId` int(11) NOT NULL,
  `StructureElementId` int(11) NOT NULL,
  PRIMARY KEY (`DocumentTemplateId`,`StructureElementId`),
  KEY `FK_DocumentTemplate_ID_idx` (`DocumentTemplateId`),
  KEY `FK_StructureElement_ID_idx` (`StructureElementId`),
  CONSTRAINT `FK_DocumentTemplate_ID` FOREIGN KEY (`DocumentTemplateId`) REFERENCES `documenttemplate` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `FK_StructureElement_ID` FOREIGN KEY (`StructureElementId`) REFERENCES `structureelement` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `documentstructurerelation`
--

LOCK TABLES `documentstructurerelation` WRITE;
/*!40000 ALTER TABLE `documentstructurerelation` DISABLE KEYS */;
INSERT INTO `documentstructurerelation` (`DocumentTemplateId`, `StructureElementId`) VALUES (1,115),(1,116),(1,117),(1,118),(1,119),(1,120),(1,121),(1,122),(1,123),(1,124),(1,125),(1,126),(1,127),(1,128),(1,129),(1,130),(1,131),(1,132),(1,133),(1,134),(1,135),(1,136),(1,137),(1,138),(1,139),(1,140),(1,141),(1,142),(1,143),(1,144),(1,145),(1,146),(1,147),(1,148),(1,149),(1,150),(1,151),(2,152),(2,153),(3,168),(3,169),(3,170),(3,171),(3,172),(3,173),(3,174),(3,175),(3,176),(3,177),(3,178),(3,179),(3,180),(3,181);
/*!40000 ALTER TABLE `documentstructurerelation` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `documenttemplate`
--

DROP TABLE IF EXISTS `documenttemplate`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `documenttemplate` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(45) DEFAULT NULL,
  `Description` varchar(100) DEFAULT NULL,
  `IsActive` tinyint(4) NOT NULL DEFAULT '0',
  `MinWordCount` int(11) NOT NULL DEFAULT '1',
  `ActiveTasksCount` int(3) NOT NULL DEFAULT '1',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `documenttemplate`
--

LOCK TABLES `documenttemplate` WRITE;
/*!40000 ALTER TABLE `documenttemplate` DISABLE KEYS */;
INSERT INTO `documenttemplate` (`Id`, `Name`, `Description`, `IsActive`, `MinWordCount`) VALUES (1,'Дипломен проект',NULL,1,200),(2,'СРС',NULL,1,200),(3,'Тестови шаблон',NULL,1,200),(4,'Друго',NULL,0,200);
/*!40000 ALTER TABLE `documenttemplate` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `keyword`
--

DROP TABLE IF EXISTS `keyword`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `keyword` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(124) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=23 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `keywordstructurecontentrelation`
--

DROP TABLE IF EXISTS `keywordstructurecontentrelation`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `keywordstructurecontentrelation` (
  `KeywordId` int(11) NOT NULL,
  `StructureContentId` int(11) NOT NULL,
  PRIMARY KEY (`KeywordId`,`StructureContentId`),
  KEY `FK_StructureContent_Id_idx` (`StructureContentId`),
  CONSTRAINT `FK_KeywordId_Id` FOREIGN KEY (`KeywordId`) REFERENCES `keyword` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `FK_StructureContentId_Id` FOREIGN KEY (`StructureContentId`) REFERENCES `structurecontent` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `structurecontent`
--

DROP TABLE IF EXISTS `structurecontent`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `structurecontent` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `StructureElementId` int(11) NOT NULL,
  `Title` varchar(245) DEFAULT NULL,
  `Content` longblob,
  `DocumentId` int(11) NOT NULL,
  `Order` int(11) NOT NULL,
  `CurrentProgress` int(11) NOT NULL DEFAULT '0',
  `MinWordCount` int(11) NOT NULL DEFAULT '1',
  PRIMARY KEY (`Id`),
  KEY `FK_StructureElement_ID_idx` (`StructureElementId`),
  KEY `FK_User_ID_idx` (`DocumentId`),
  CONSTRAINT `FK_StructureContentDocument_Id` FOREIGN KEY (`DocumentId`) REFERENCES `document` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `FK_StructureElementDocument_Id` FOREIGN KEY (`StructureElementId`) REFERENCES `structureelement` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=215 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `structureelement`
--

DROP TABLE IF EXISTS `structureelement`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `structureelement` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Title` varchar(255) DEFAULT NULL,
  `StructureTypeId` int(11) NOT NULL,
  `Description` varchar(455) DEFAULT NULL,
  `Order` int(11) DEFAULT NULL,
  `MinWordCount` int(11) NOT NULL DEFAULT '1',
  PRIMARY KEY (`Id`),
  UNIQUE KEY `ID_UNIQUE` (`Id`),
  UNIQUE KEY `Title_Order_UNIQUE` (`Title`,`Order`)
) ENGINE=InnoDB AUTO_INCREMENT=183 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `structureelement`
--

LOCK TABLES `structureelement` WRITE;
/*!40000 ALTER TABLE `structureelement` DISABLE KEYS */;
INSERT INTO `structureelement` (`Id`, `Title`, `StructureTypeId`, `Description`, `Order`, `MinWordCount`) VALUES (115,'Увод',3,NULL,1,200),(116,'Цел и задачи на дипломната работа',4,NULL,2,200),(117,'Актуалност на проблема и мотивация',4,NULL,1,200),(118,'Очаквани ползи от реализацията',4,NULL,3,200),(119,'Структура на дипломната работа',4,NULL,4,200),(120,'Преглед на предметната област',3,NULL,2,200),(121,'Основни дефиниции',4,NULL,1,200),(122,'Подходи, методи (евентуално модели и стандарти) за решаване на проблемите',4,NULL,2,200),(123,'Съществуващи решения (практически реализации)',4,NULL,3,200),(124,'Избор на критерии за сравнение и сравнителен анализ на решения/методи/стандарти/...',4,NULL,4,200),(125,'Изводи',4,NULL,5,50),(126,'Използвани технологии, платформи и/или методологии ',3,NULL,3,200),(127,'Изисквания към средствата (технологии, платформи и методологии)',4,NULL,1,200),(128,'Видове средства (технологии, платформи и методологии) и начин и място за използването им – сравненителен анализ',4,NULL,2,200),(129,'Избор на средствата (технологии, платформи и методологии)',4,NULL,3,200),(130,'Изводи',4,NULL,4,50),(131,'Анализ',3,NULL,4,200),(132,'Концептуален модел',4,NULL,1,200),(133,'Потребителски (функционални) изисквания (права, роли, статуси, диаграми, ...)',4,NULL,2,200),(134,'Качествени (нефункционални) изисквания (като напр. преносимост, използваемост, скалируемост, поддръжка, ...)',4,NULL,3,200),(135,'Работни (бизнес) процеси',4,NULL,4,200),(136,'Проектиране',3,NULL,5,200),(137,'Обща архитектура – напр. слоеве, модули, блокове, компоненти...',4,NULL,1,200),(138,'Модел на данните (напр. база данни, файлова структура, ...)',4,NULL,2,200),(139,'Диаграми (на структура и поведение - по слоеве и модули, с извадки от кода)',4,NULL,3,200),(140,'Потребителски интерфейс (опционално)',4,NULL,4,200),(141,'Ресурсни и спомагателни модули (опционално)',4,NULL,5,200),(142,'Реализация, тестване/експерименти и (евентуално) внедряване',3,NULL,6,200),(143,'Реализация на модулите',4,NULL,1,200),(144,'Системна интеграция (опционално)',4,NULL,2,200),(145,'Планиране на тестването - тестови сценарии, процедури, ...',4,NULL,3,200),(146,'Модулно и системно тестване',4,NULL,4,200),(147,'Анализ на резултатите от тестването и начин на отразяването им',4,NULL,5,200),(148,'Експериментално внедряване (технологични изисквания, инсталиране, условия, използване, ...)',4,NULL,6,200),(149,'Заключение',3,NULL,7,200),(150,'Обобщение на изпълнението на началните цели',4,NULL,1,200),(151,'Насоки за бъдещо развитие и усъвършенстване',4,NULL,2,200),(152,'Структура на документа',3,NULL,1,200),(153,'Съдържание',4,NULL,1,200),(168,'Въведение',3,NULL,1,200),(169,'Цел',4,NULL,1,200),(170,'Проблем',4,NULL,2,200),(171,'За кого е документа',4,NULL,3,200),(172,'Планиране',3,NULL,2,200),(173,'Основни определения',4,NULL,1,200),(174,'Изготвяне на план за действие',4,NULL,2,200),(175,'Нужни средства',4,NULL,3,200),(176,'Реализация',3,NULL,3,200),(177,'Първа разработка',4,NULL,1,200),(178,'Чистене на проблеми и бъгове',4,NULL,2,200),(179,'Извод',3,NULL,4,200),(180,'Реално решение',4,NULL,1,200),(181,'Бъдещо развитие',4,NULL,2,200),(182,'Тестова опционална подсекция',4,NULL,2,200);
/*!40000 ALTER TABLE `structureelement` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `structurerelation`
--

DROP TABLE IF EXISTS `structurerelation`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `structurerelation` (
  `StructureElementParentId` int(11) NOT NULL,
  `StructureElementChildId` int(11) NOT NULL,
  KEY `FK_StructureElement_Parent_idx` (`StructureElementParentId`),
  KEY `FK_StructureElement_Child_idx` (`StructureElementChildId`),
  CONSTRAINT `FK_StructureElement_Child` FOREIGN KEY (`StructureElementChildId`) REFERENCES `structureelement` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `FK_StructureElement_Parent` FOREIGN KEY (`StructureElementParentId`) REFERENCES `structureelement` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `structurerelation`
--

LOCK TABLES `structurerelation` WRITE;
/*!40000 ALTER TABLE `structurerelation` DISABLE KEYS */;
INSERT INTO `structurerelation` (`StructureElementParentId`, `StructureElementChildId`) VALUES (115,116),(115,117),(115,118),(115,119),(120,121),(120,122),(120,123),(120,124),(120,125),(126,127),(126,128),(126,129),(126,130),(131,132),(131,133),(131,134),(131,135),(131,125),(136,137),(136,138),(136,139),(136,140),(136,141),(142,143),(142,144),(142,145),(142,146),(142,147),(142,148),(149,150),(149,151),(152,153),(168,169),(168,170),(168,171),(172,173),(172,174),(172,175),(176,177),(176,178),(179,180),(179,181),(152,182);
/*!40000 ALTER TABLE `structurerelation` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `task`
--

DROP TABLE IF EXISTS `task`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `task` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Title` varchar(245) NOT NULL,
  `AssignTo` int(11) DEFAULT NULL,
  `TaskState` int(11) NOT NULL,
  `Deadline` datetime NOT NULL,
  `DocumentId` int(11) NOT NULL,
  `NumberInsideDocument` int(11) NOT NULL DEFAULT '1',
  `TaskType` int(11) NOT NULL,
  `StructureContentId` int(11) DEFAULT NULL,
  `Cycle` int(11) NOT NULL DEFAULT '1',
  PRIMARY KEY (`Id`),
  KEY `FK_TaskDiploma_Id_idx` (`DocumentId`),
  KEY `FK_TaskUser_Id_idx` (`AssignTo`),
  KEY `FK_TaskStructureContent_Id_idx` (`StructureContentId`),
  CONSTRAINT `FK_TaskDocument_Id` FOREIGN KEY (`DocumentId`) REFERENCES `document` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `FK_TaskStructureContent_Id` FOREIGN KEY (`StructureContentId`) REFERENCES `structurecontent` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `FK_TaskUser_Id` FOREIGN KEY (`AssignTo`) REFERENCES `user` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=425 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `user`
--

DROP TABLE IF EXISTS `user`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `user` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `FirstName` varchar(45) NOT NULL,
  `MiddleName` varchar(45) DEFAULT NULL,
  `FamilyName` varchar(45) NOT NULL,
  `Email` varchar(45) NOT NULL,
  `Password` varchar(45) NOT NULL,
  `ExperiencePoints` int(11) DEFAULT NULL,
  `Level` smallint(6) DEFAULT NULL,
  `FirstDocumentStructure` int(2) DEFAULT '1',
  `FirstTaskBoard` int(2) DEFAULT '1',
  `FirstWritingContent` int(2) DEFAULT '1',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2016-06-25 18:40:05
