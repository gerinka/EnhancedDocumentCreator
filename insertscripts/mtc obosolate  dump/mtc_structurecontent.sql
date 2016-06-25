CREATE DATABASE  IF NOT EXISTS `mtc` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `mtc`;
-- MySQL dump 10.13  Distrib 5.6.13, for Win32 (x86)
--
-- Host: localhost    Database: mtc
-- ------------------------------------------------------
-- Server version	5.6.16

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
-- Table structure for table `structurecontent`
--

DROP TABLE IF EXISTS `structurecontent`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `structurecontent` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `StructureElementId` int(11) NOT NULL,
  `Title` varchar(45) DEFAULT NULL,
  `Content` longblob,
  `DocumentId` int(11) NOT NULL,
  `Order` int(11) NOT NULL,
  `CurrentProgress` int(11) NOT NULL DEFAULT '0',
  PRIMARY KEY (`Id`),
  KEY `FK_StructureElement_ID_idx` (`StructureElementId`),
  KEY `FK_User_ID_idx` (`DocumentId`),
  CONSTRAINT `FK_StructureContentDocument_Id` FOREIGN KEY (`DocumentId`) REFERENCES `document` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `FK_StructureElementDocument_Id` FOREIGN KEY (`StructureElementId`) REFERENCES `structureelement` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `structurecontent`
--

LOCK TABLES `structurecontent` WRITE;
/*!40000 ALTER TABLE `structurecontent` DISABLE KEYS */;
INSERT INTO `structurecontent` VALUES (1,152,'Структура на документа',NULL,2,1,0),(2,153,'Съдържание','L\0o\0r\0e\0m\0 \0i\0p\0s\0u\0m\0 \0d\0o\0l\0o\0r\0 \0s\0i\0t\0 \0a\0m\0e\0t\0,\0 \0c\0o\0n\0s\0e\0c\0t\0e\0t\0u\0e\0r\0 \0a\0d\0i\0p\0i\0s\0c\0i\0n\0g\0 \0e\0l\0i\0t\0.\0 \0A\0e\0n\0e\0a\0n\0 \0c\0o\0m\0m\0o\0d\0o\0 \0l\0i\0g\0u\0l\0a\0 \0e\0g\0e\0t\0 \0d\0o\0l\0o\0r\0.\0 \0A\0e\0n\0e\0a\0n\0 \0m\0a\0s\0s\0a\0.\0 \0C\0u\0m\0 \0s\0o\0c\0i\0i\0s\0 \0n\0a\0t\0o\0q\0u\0e\0 \0p\0e\0n\0a\0t\0i\0b\0u\0s\0 \0e\0t\0 \0m\0a\0g\0n\0i\0s\0 \0d\0i\0s\0 \0p\0a\0r\0t\0u\0r\0i\0e\0n\0t\0 \0m\0o\0n\0t\0e\0s\0,\0 \0n\0a\0s\0c\0e\0t\0u\0r\0 \0r\0i\0d\0i\0c\0u\0l\0u\0s\0 \0m\0u\0s\0.\0 \0D\0o\0n\0e\0c\0 \0q\0u\0a\0m\0 \0f\0e\0l\0i\0s\0,\0 \0u\0l\0t\0r\0i\0c\0i\0e\0s\0 \0n\0e\0c\0,\0 \0p\0e\0l\0l\0e\0n\0t\0e\0s\0q\0u\0e\0 \0e\0u\0,\0 \0p\0r\0e\0t\0i\0u\0m\0 \0q\0u\0i\0s\0,\0 \0s\0e\0m\0.\0 \0N\0u\0l\0l\0a\0 \0c\0o\0n\0s\0e\0q\0u\0a\0t\0 \0m\0a\0s\0s\0a\0 \0q\0u\0i\0s\0 \0e\0n\0i\0m\0.\0 \0D\0o\0n\0e\0c\0 \0p\0e\0d\0e\0 \0j\0u\0s\0t\0o\0,\0 \0f\0r\0i\0n\0g\0i\0l\0l\0a\0 \0v\0e\0l\0,\0 \0a\0l\0i\0q\0u\0e\0t\0 \0n\0e\0c\0,\0 \0v\0u\0l\0p\0u\0t\0a\0t\0e\0 \0e\0g\0e\0t\0,\0 \0a\0r\0c\0u\0.\0 \0I\0n\0 \0e\0n\0i\0m\0 \0j\0u\0s\0t\0o\0,\0 \0r\0h\0o\0n\0c\0u\0s\0 \0u\0t\0,\0 \0i\0m\0p\0e\0r\0d\0i\0e\0t\0 \0a\0,\0 \0v\0e\0n\0e\0n\0a\0t\0i\0s\0 \0v\0i\0t\0a\0e\0,\0 \0j\0u\0s\0t\0o\0.\0 \0N\0u\0l\0l\0a\0m\0 \0d\0i\0c\0t\0u\0m\0 \0f\0e\0l\0i\0s\0 \0e\0u\0 \0p\0e\0d\0e\0 \0m\0o\0l\0l\0i\0s\0 \0p\0r\0e\0t\0i\0u\0m\0.\0 \0I\0n\0t\0e\0g\0e\0r\0 \0t\0i\0n\0c\0i\0d\0u\0n\0t\0.\0 \0C\0r\0a\0s\0 \0d\0a\0p\0i\0b\0u\0s\0.\0 \0V\0i\0v\0a\0m\0u\0s\0 \0e\0l\0e\0m\0e\0n\0t\0u\0m\0 \0s\0e\0m\0p\0e\0r\0 \0n\0i\0s\0i\0.\0 \0A\0e\0n\0e\0a\0n\0 \0v\0u\0l\0p\0u\0t\0a\0t\0e\0 \0e\0l\0e\0i\0f\0e\0n\0d\0 \0t\0e\0l\0l\0u\0s\0.\0 \0A\0e\0n\0e\0a\0n\0 \0l\0e\0o\0 \0l\0i\0g\0u\0l\0a\0,\0 \0p\0o\0r\0t\0t\0i\0t\0o\0r\0 \0e\0u\0,\0 \0c\0o\0n\0s\0e\0q\0u\0a\0t\0 \0v\0i\0t\0a\0e\0,\0 \0e\0l\0e\0i\0f\0e\0n\0d\0 \0a\0c\0,\0 \0e\0n\0i\0m\0.\0 \0A\0l\0i\0q\0u\0a\0m\0 \0l\0o\0r\0e\0m\0 \0a\0n\0t\0e\0,\0 \0d\0a\0p\0i\0b\0u\0s\0 \0i\0n\0,\0 \0v\0i\0v\0e\0r\0r\0a\0 \0q\0u\0i\0s\0,\0 \0f\0e\0u\0g\0i\0a\0t\0 \0a\0,\0 \0t\0e\0l\0l\0u\0s\0.\0 \0P\0h\0a\0s\0e\0l\0l\0u\0s\0 \0v\0i\0v\0e\0r\0r\0a\0 \0n\0u\0l\0l\0a\0 \0u\0t\0 \0m\0e\0t\0u\0s\0 \0v\0a\0r\0i\0u\0s\0 \0l\0a\0o\0r\0e\0e\0t\0.\0 \0Q\0u\0i\0s\0q\0u\0e\0 \0r\0u\0t\0r\0u\0m\0.\0 \0A\0e\0n\0e\0a\0n\0 \0i\0m\0p\0e\0r\0d\0i\0e\0t\0.\0 \0E\0t\0i\0a\0m\0 \0u\0l\0t\0r\0i\0c\0i\0e\0s\0 \0n\0i\0s\0i\0 \0v\0e\0l\0 \0a\0u\0g\0u\0e\0.\0 \0C\0u\0r\0a\0b\0i\0t\0u\0r\0 \0u\0l\0l\0a\0m\0c\0o\0r\0p\0e\0r\0 \0u\0l\0t\0r\0i\0c\0i\0e\0s\0 \0n\0i\0s\0i\0.\0 \0N\0a\0m\0 \0e\0g\0e\0t\0 \0d\0u\0i\0.\0 \0E\0t\0i\0a\0m\0 \0r\0h\0o\0n\0c\0u\0s\0.\0 \0M\0a\0e\0c\0e\0n\0a\0s\0 \0t\0e\0m\0p\0u\0s\0,\0 \0t\0e\0l\0l\0u\0s\0 \0e\0g\0e\0t\0 \0c\0o\0n\0d\0i\0m\0e\0n\0t\0u\0m\0 \0r\0h\0o\0n\0c\0u\0s\0,\0 \0s\0e\0m\0 \0q\0u\0a\0m\0 \0s\0e\0m\0p\0e\0r\0 \0l\0i\0b\0e\0r\0o\0,\0 \0s\0i\0t\0 \0a\0m\0e\0t\0 \0a\0d\0i\0p\0i\0s\0c\0i\0n\0g\0 \0s\0e\0m\0 \0n\0e\0q\0u\0e\0 \0s\0e\0d\0 \0i\0p\0s\0u\0m\0.\0 \0N\0a\0m\0 \0q\0u\0a\0m\0 \0n\0u\0n\0c\0,\0 \0b\0l\0a\0n\0d\0i\0t\0 \0v\0e\0l\0,\0 \0l\0u\0c\0t\0u\0s\0 \0p\0u\0l\0v\0i\0n\0a\0r\0,\0 \0h\0e\0n\0d\0r\0e\0r\0i\0t\0 \0i\0d\0,\0 \0l\0o\0r\0e\0m\0.\0 \0M\0a\0e\0c\0e\0n\0a\0s\0 \0n\0e\0c\0 \0o\0d\0i\0o\0 \0e\0t\0 \0a\0n\0t\0e\0 \0t\0i\0n\0c\0i\0d\0u\0n\0t\0 \0t\0e\0m\0p\0u\0s\0.\0 \0D\0o\0n\0e\0c\0 \0v\0i\0t\0a\0e\0 \0s\0a\0p\0i\0e\0n\0 \0u\0t\0 \0l\0i\0b\0e\0r\0o\0 \0v\0e\0n\0e\0n\0a\0t\0i\0s\0 \0f\0a\0u\0c\0i\0b\0u\0s\0.\0 \0N\0u\0l\0l\0a\0m\0 \0q\0u\0i\0s\0 \0a\0n\0t\0e\0.\0 \0E\0t\0i\0a\0m\0 \0s\0i\0t\0 \0a\0m\0e\0t\0 \0o\0r\0c\0i\0 \0e\0g\0e\0t\0 \0e\0r\0o\0s\0 \0f\0a\0u\0c\0i\0b\0u\0s\0 \0t\0i\0n\0c\0i\0d\0u\0n\0t\0.\0 \0D\0u\0i\0s\0 \0l\0e\0o\0.\0 \0S\0e\0d\0 \0f\0r\0i\0n\0g\0i\0l\0l\0a\0 \0m\0a\0u\0r\0i\0s\0 \0s\0i\0t\0 \0a\0m\0e\0t\0 \0n\0i\0b\0h\0.\0 \0D\0o\0n\0e\0c\0 \0s\0o\0d\0a\0l\0e\0s\0 \0s\0a\0g\0i\0t\0t\0i\0s\0 \0m\0a\0g\0n\0a\0.\0 \0S\0e\0d\0 \0c\0o\0n\0s\0e\0q\0u\0a\0t\0,\0 \0l\0e\0o\0 \0e\0g\0e\0t\0 \0b\0i\0b\0e\0n\0d\0u\0m\0 \0s\0o\0d\0a\0l\0e\0s\0,\0 \0a\0u\0g\0u\0e\0 \0v\0e\0l\0i\0t\0 \0c\0u\0r\0s\0u\0s\0 \0n\0u\0n\0c\0,\0 \0q\0u\0i\0s\0 \0g\0r\0a\0v\0i\0d\0a\0 \0m\0a\0g\0n\0a\0 \0m\0i\0 \0a\0 \0l\0i\0b\0e\0r\0o\0.\0 \0F\0u\0s\0c\0e\0 \0v\0u\0l\0p\0u\0t\0a\0t\0e\0 \0e\0l\0e\0i\0f\0e\0n\0d\0 \0s\0a\0p\0i\0e\0n\0.\0 \0V\0e\0s\0t\0i\0b\0u\0l\0u\0m\0 \0p\0u\0r\0u\0s\0 \0q\0u\0a\0m\0,\0 \0s\0c\0e\0l\0e\0r\0i\0s\0q\0u\0e\0 \0u\0t\0,\0 \0m\0o\0l\0l\0i\0s\0 \0s\0e\0d\0,\0 \0n\0o\0n\0u\0m\0m\0y\0 \0i\0d\0,\0 \0m\0e\0t\0u\0s\0.\0 \0N\0u\0l\0l\0a\0m\0 \0a\0c\0c\0u\0m\0s\0a\0n\0 \0l\0o\0r\0e\0m\0 \0i\0n\0 \0d\0u\0i\0.\0 \0C\0r\0a\0s\0 \0u\0l\0t\0r\0i\0c\0i\0e\0s\0 \0m\0i\0 \0e\0u\0 \0t\0u\0r\0p\0i\0s\0 \0h\0e\0n\0d\0r\0e\0r\0i\0t\0 \0f\0r\0i\0n\0g\0i\0l\0l\0a\0.\0 \0V\0e\0s\0t\0i\0b\0u\0l\0u\0m\0 \0a\0n\0t\0e\0 \0i\0p\0s\0u\0m\0 \0p\0r\0i\0m\0i\0s\0 \0i\0n\0 \0f\0a\0u\0c\0i\0b\0u\0s\0 \0o\0r\0c\0i\0 \0l\0u\0c\0t\0u\0s\0 \0e\0t\0 \0u\0l\0t\0r\0i\0c\0e\0s\0 \0p\0o\0s\0u\0e\0r\0e\0 \0c\0u\0b\0i\0l\0i\0a\0 \0C\0u\0r\0a\0e\0;\0 \0I\0n\0 \0a\0c\0 \0d\0u\0i\0 \0q\0u\0i\0s\0 \0m\0i\0 \0c\0o\0n\0s\0e\0c\0t\0e\0t\0u\0e\0r\0 \0l\0a\0c\0i\0n\0i\0a\0.\0 \0N\0a\0m\0 \0p\0r\0e\0t\0i\0u\0m\0 \0t\0u\0r\0p\0i\0s\0 \0e\0t\0 \0a\0r\0c\0u\0.\0 \0D\0u\0i\0s\0 \0a\0r\0c\0u\0 \0t\0o\0r\0t\0o\0r\0,\0 \0s\0u\0s\0c\0i\0p\0i\0t\0 \0e\0g\0e\0t\0,\0 \0i\0m\0p\0e\0r\0d\0i\0e\0t\0 \0n\0e\0c\0,\0 \0i\0m\0p\0e\0r\0d\0i\0e\0t\0 \0i\0a\0c\0u\0l\0i\0s\0,\0 \0i\0p\0s\0u\0m\0.\0 \0S\0e\0d\0 \0a\0l\0i\0q\0u\0a\0m\0 \0u\0l\0t\0r\0i\0c\0e\0s\0 \0m\0a\0u\0r\0i\0s\0.\0 \0I\0n\0t\0e\0g\0e\0r\0 \0a\0n\0t\0e\0 \0a\0r\0c\0u\0,\0 \0a\0c\0c\0u\0m\0s\0a\0n\0 \0a\0,\0 \0c\0o\0n\0s\0e\0c\0t\0e\0t\0u\0e\0r\0 \0e\0g\0e\0t\0,\0 \0p\0o\0s\0u\0e\0r\0e\0 \0u\0t\0,\0',2,0,100);
/*!40000 ALTER TABLE `structurecontent` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2016-05-23 16:56:05
