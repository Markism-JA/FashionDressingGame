-- MySQL dump 10.13  Distrib 8.0.40, for Linux (x86_64)
--
-- Host: localhost    Database: FashionGameDb
-- ------------------------------------------------------
-- Server version	8.0.40-0ubuntu0.24.04.1

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `Appearances`
--

DROP TABLE IF EXISTS `Appearances`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Appearances` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `SkinTone` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `EyeColor` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `HairStyle` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `HairColor` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `FaceShape` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Freckles` tinyint(1) NOT NULL,
  `Dimples` tinyint(1) NOT NULL,
  `Acne` tinyint(1) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Appearances`
--

LOCK TABLES `Appearances` WRITE;
/*!40000 ALTER TABLE `Appearances` DISABLE KEYS */;
INSERT INTO `Appearances` VALUES (1,'Café au Lait','Silver','Afro','Silver','Diamond',1,1,1),(4,'Tan','Golden Brown','Braided Crown','Pink','Diamond',1,0,0);
/*!40000 ALTER TABLE `Appearances` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Bottoms`
--

DROP TABLE IF EXISTS `Bottoms`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Bottoms` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Type` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Material` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Bottoms`
--

LOCK TABLES `Bottoms` WRITE;
/*!40000 ALTER TABLE `Bottoms` DISABLE KEYS */;
INSERT INTO `Bottoms` VALUES (1,'Jeans','Silk'),(4,'Jeans','Silk');
/*!40000 ALTER TABLE `Bottoms` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Characters`
--

DROP TABLE IF EXISTS `Characters`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Characters` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `AppearanceID` int DEFAULT NULL,
  `ClothingID` int DEFAULT NULL,
  `Name` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Gender` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Height` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Age` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `CharacterGrade` int NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_ECharacter_Appearance` (`AppearanceID`),
  KEY `IX_ECharacter_Clothing` (`ClothingID`),
  CONSTRAINT `FK_Characters_Appearances_AppearanceID` FOREIGN KEY (`AppearanceID`) REFERENCES `Appearances` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `FK_Characters_Clothings_ClothingID` FOREIGN KEY (`ClothingID`) REFERENCES `Clothings` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Characters`
--

LOCK TABLES `Characters` WRITE;
/*!40000 ALTER TABLE `Characters` DISABLE KEYS */;
INSERT INTO `Characters` VALUES (1,1,1,'CHESTER JUICY','Male','Tall','Senior',171),(4,4,4,'cai','Female','Giant','Teen',183);
/*!40000 ALTER TABLE `Characters` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Clothings`
--

DROP TABLE IF EXISTS `Clothings`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Clothings` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `TopId` int DEFAULT NULL,
  `BottomId` int DEFAULT NULL,
  `Shoe` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Accessory` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Gloves` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `JewelryId` int DEFAULT NULL,
  `OutfitTheme` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `FormalWear` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `OuterWearId` int DEFAULT NULL,
  `Hat` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_EClothing_Bottom` (`BottomId`),
  KEY `IX_EClothing_Jewelry` (`JewelryId`),
  KEY `IX_EClothing_OuterWear` (`OuterWearId`),
  KEY `IX_EClothing_Top` (`TopId`),
  CONSTRAINT `FK_Clothings_Bottoms_BottomId` FOREIGN KEY (`BottomId`) REFERENCES `Bottoms` (`Id`),
  CONSTRAINT `FK_Clothings_Jewelries_JewelryId` FOREIGN KEY (`JewelryId`) REFERENCES `Jewelries` (`Id`),
  CONSTRAINT `FK_Clothings_OuterWears_OuterWearId` FOREIGN KEY (`OuterWearId`) REFERENCES `OuterWears` (`Id`),
  CONSTRAINT `FK_Clothings_Tops_TopId` FOREIGN KEY (`TopId`) REFERENCES `Tops` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Clothings`
--

LOCK TABLES `Clothings` WRITE;
/*!40000 ALTER TABLE `Clothings` DISABLE KEYS */;
INSERT INTO `Clothings` VALUES (1,1,1,'Stiletto Heels','Umbrella','Cut-out',1,'Fantasy','Wedding',1,'Turban'),(4,4,4,'Stiletto Heels','Umbrella','Punk',4,'Fantasy','Black Tie',4,'Fedora');
/*!40000 ALTER TABLE `Clothings` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Jewelries`
--

DROP TABLE IF EXISTS `Jewelries`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Jewelries` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Watches` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `Earrings` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `Chains` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `Anklets` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `Cufflinks` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Jewelries`
--

LOCK TABLES `Jewelries` WRITE;
/*!40000 ALTER TABLE `Jewelries` DISABLE KEYS */;
INSERT INTO `Jewelries` VALUES (1,'Luxury Watch','Hoop','Chains','Beaded Anklet','Cufflinks'),(4,'Luxury Watch','Hoop','Chains','Beaded Anklet','Cufflinks');
/*!40000 ALTER TABLE `Jewelries` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `OuterWears`
--

DROP TABLE IF EXISTS `OuterWears`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `OuterWears` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `OuterWearType` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `OuterWearName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `OuterWears`
--

LOCK TABLES `OuterWears` WRITE;
/*!40000 ALTER TABLE `OuterWears` DISABLE KEYS */;
INSERT INTO `OuterWears` VALUES (1,'Motorcycle Jacket','Double-breasted Coat'),(4,'Pea Coat','Cardigan');
/*!40000 ALTER TABLE `OuterWears` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Tops`
--

DROP TABLE IF EXISTS `Tops`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Tops` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Type` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Material` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Tops`
--

LOCK TABLES `Tops` WRITE;
/*!40000 ALTER TABLE `Tops` DISABLE KEYS */;
INSERT INTO `Tops` VALUES (1,'Bodysuit','Silk'),(4,'T-shirt','Silk');
/*!40000 ALTER TABLE `Tops` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `__EFMigrationsHistory`
--

DROP TABLE IF EXISTS `__EFMigrationsHistory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `__EFMigrationsHistory` (
  `MigrationId` varchar(150) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `ProductVersion` varchar(32) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`MigrationId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `__EFMigrationsHistory`
--

LOCK TABLES `__EFMigrationsHistory` WRITE;
/*!40000 ALTER TABLE `__EFMigrationsHistory` DISABLE KEYS */;
INSERT INTO `__EFMigrationsHistory` VALUES ('20241212090550_InitialCreate','8.0.0');
/*!40000 ALTER TABLE `__EFMigrationsHistory` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-12-19 12:46:50
