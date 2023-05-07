CREATE DATABASE  IF NOT EXISTS `payspacedb` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `payspacedb`;
-- MySQL dump 10.13  Distrib 8.0.22, for Win64 (x86_64)
--
-- Host: localhost    Database: payspacedb
-- ------------------------------------------------------
-- Server version	8.0.22

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `brackets`
--

DROP TABLE IF EXISTS `brackets`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `brackets` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `PercentageRate` int NOT NULL,
  `From` bigint NOT NULL,
  `To` bigint NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=16 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `brackets`
--

LOCK TABLES `brackets` WRITE;
/*!40000 ALTER TABLE `brackets` DISABLE KEYS */;
INSERT INTO `brackets` VALUES (1,10,0,8350),(2,15,8351,33950),(3,25,33951,82250),(4,28,82251,171550),(5,33,171551,372950),(6,35,372951,9999999999);
/*!40000 ALTER TABLE `brackets` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `calculations`
--

DROP TABLE IF EXISTS `calculations`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `calculations` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `PostalCodeId` int NOT NULL,
  `CreatedDate` datetime NOT NULL,
  `MonthlyIncome` decimal(10,2) NOT NULL,
  `CalculatedValue` decimal(10,2) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `fk_calculations_postalcodes_idx` (`PostalCodeId`),
  CONSTRAINT `fk_calculations_postalcodes` FOREIGN KEY (`PostalCodeId`) REFERENCES `postalcodes` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=26 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `calculations`
--

LOCK TABLES `calculations` WRITE;
/*!40000 ALTER TABLE `calculations` DISABLE KEYS */;
INSERT INTO `calculations` VALUES (15,4,'2023-05-07 15:25:02',10000.00,27319.32),(16,3,'2023-05-07 15:25:35',10000.00,21000.00),(17,3,'2023-05-07 15:30:14',10000.00,21000.00),(18,3,'2023-05-07 15:40:39',10000.00,21000.00),(19,3,'2023-05-07 15:43:24',10000.00,21000.00),(20,4,'2023-05-07 15:45:17',20000.00,64341.49),(21,3,'2023-05-07 15:45:48',10000.00,21000.00),(22,4,'2023-05-07 15:46:05',60000.00,229682.14),(23,4,'2023-05-07 15:50:50',10000.00,27319.32),(24,4,'2023-05-07 15:54:13',10000.00,27319.32),(25,3,'2023-05-07 15:54:19',10000.00,21000.00);
/*!40000 ALTER TABLE `calculations` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `postalcodes`
--

DROP TABLE IF EXISTS `postalcodes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `postalcodes` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Code` varchar(10) NOT NULL,
  `CalculationType` varchar(255) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `postalcodes`
--

LOCK TABLES `postalcodes` WRITE;
/*!40000 ALTER TABLE `postalcodes` DISABLE KEYS */;
INSERT INTO `postalcodes` VALUES (1,'7441','Progressive'),(2,'A100','Flat Value'),(3,'7000','Flat Rate'),(4,'1000','Progressive');
/*!40000 ALTER TABLE `postalcodes` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-05-07 15:58:02
