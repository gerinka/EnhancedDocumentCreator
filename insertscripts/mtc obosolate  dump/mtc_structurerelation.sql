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
INSERT INTO `structurerelation` VALUES (115,116),(115,117),(115,118),(115,119),(120,121),(120,122),(120,123),(120,124),(120,125),(126,127),(126,128),(126,129),(126,130),(131,132),(131,133),(131,134),(131,135),(131,125),(136,137),(136,138),(136,139),(136,140),(136,141),(142,143),(142,144),(142,145),(142,146),(142,147),(142,148),(149,150),(149,151),(152,153),(168,169),(168,170),(168,171),(172,173),(172,174),(172,175),(176,177),(176,178),(179,180),(179,181);
/*!40000 ALTER TABLE `structurerelation` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2016-05-23 16:56:04
