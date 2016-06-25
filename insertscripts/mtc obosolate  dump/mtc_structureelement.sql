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
  PRIMARY KEY (`Id`),
  UNIQUE KEY `ID_UNIQUE` (`Id`),
  UNIQUE KEY `Title_Order_UNIQUE` (`Title`,`Order`)
) ENGINE=InnoDB AUTO_INCREMENT=182 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `structureelement`
--

LOCK TABLES `structureelement` WRITE;
/*!40000 ALTER TABLE `structureelement` DISABLE KEYS */;
INSERT INTO `structureelement` VALUES (115,'Увод',3,NULL,1),(116,'Цел и задачи на дипломната работа',4,NULL,1),(117,'Актуалност на проблема и мотивация',4,NULL,2),(118,'Очаквани ползи от реализацията',4,NULL,3),(119,'Структура на дипломната работа',4,NULL,4),(120,'Преглед на предметната област',3,NULL,2),(121,'Основни дефиниции',4,NULL,1),(122,'Подходи, методи (евентуално модели и стандарти) за решаване на проблемите',4,NULL,2),(123,'Съществуващи решения (практически реализации)',4,NULL,3),(124,'Избор на критерии за сравнение и сравнителен анализ на решения/методи/стандарти/...',4,NULL,4),(125,'Изводи',4,NULL,5),(126,'Използвани технологии, платформи и/или методологии ',3,NULL,3),(127,'Изисквания към средствата (технологии, платформи и методологии)',4,NULL,1),(128,'Видове средства (технологии, платформи и методологии) и начин и място за използването им – сравненителен анализ',4,NULL,2),(129,'Избор на средствата (технологии, платформи и методологии)',4,NULL,3),(130,'Изводи',4,NULL,4),(131,'Анализ',3,NULL,4),(132,'Концептуален модел',4,NULL,1),(133,'Потребителски (функционални) изисквания (права, роли, статуси, диаграми, ...)',4,NULL,2),(134,'Качествени (нефункционални) изисквания (като напр. преносимост, използваемост, скалируемост, поддръжка, ...)',4,NULL,3),(135,'Работни (бизнес) процеси',4,NULL,4),(136,'Проектиране',3,NULL,5),(137,'Обща архитектура – напр. слоеве, модули, блокове, компоненти...',4,NULL,1),(138,'Модел на данните (напр. база данни, файлова структура, ...)',4,NULL,2),(139,'Диаграми (на структура и поведение - по слоеве и модули, с извадки от кода)',4,NULL,3),(140,'Потребителски интерфейс (опционално)',4,NULL,4),(141,'Ресурсни и спомагателни модули (опционално)',4,NULL,5),(142,'Реализация, тестване/експерименти и (евентуално) внедряване',3,NULL,6),(143,'Реализация на модулите',4,NULL,1),(144,'Системна интеграция (опционално)',4,NULL,2),(145,'Планиране на тестването - тестови сценарии, процедури, ...',4,NULL,3),(146,'Модулно и системно тестване',4,NULL,4),(147,'Анализ на резултатите от тестването и начин на отразяването им',4,NULL,5),(148,'Експериментално внедряване (технологични изисквания, инсталиране, условия, използване, ...)',4,NULL,6),(149,'Заключение',3,NULL,7),(150,'Обобщение на изпълнението на началните цели',4,NULL,1),(151,'Насоки за бъдещо развитие и усъвършенстване',4,NULL,2),(152,'Структура на документа',3,NULL,1),(153,'Съдържание',4,NULL,1),(168,'Въведение',3,NULL,1),(169,'Цел',4,NULL,1),(170,'Проблем',4,NULL,2),(171,'За кого е документа',4,NULL,3),(172,'Планиране',3,NULL,2),(173,'Основни определения',4,NULL,1),(174,'Изготвяне на план за действие',4,NULL,2),(175,'Нужни средства',4,NULL,3),(176,'Реализация',3,NULL,3),(177,'Първа разработка',4,NULL,1),(178,'Чистене на проблеми и бъгове',4,NULL,2),(179,'Извод',3,NULL,4),(180,'Реално решение',4,NULL,1),(181,'Бъдещо развитие',4,NULL,2);
/*!40000 ALTER TABLE `structureelement` ENABLE KEYS */;
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
