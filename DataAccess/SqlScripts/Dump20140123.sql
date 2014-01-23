CREATE DATABASE  IF NOT EXISTS `pcgstorage` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `pcgstorage`;
-- MySQL dump 10.13  Distrib 5.6.13, for Win32 (x86)
--
-- Host: localhost    Database: pcgstorage
-- ------------------------------------------------------
-- Server version	5.7.3-m13

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
-- Table structure for table `charactercard`
--

DROP TABLE IF EXISTS `charactercard`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `charactercard` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(45) NOT NULL,
  `BaseHandSize` int(11) NOT NULL,
  `BaseLightArmors` int(11) NOT NULL,
  `BaseHeavyArmors` int(11) NOT NULL,
  `BaseWeapons` int(11) NOT NULL,
  `BaseWeaponCards` int(11) NOT NULL,
  `BaseSpellCards` int(11) NOT NULL,
  `BaseArmorCards` int(11) NOT NULL,
  `BaseItemCards` int(11) NOT NULL,
  `BaseAllyCards` int(11) NOT NULL,
  `BaseBlessingCards` int(11) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=85 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `charactercard`
--

LOCK TABLES `charactercard` WRITE;
/*!40000 ALTER TABLE `charactercard` DISABLE KEYS */;
INSERT INTO `charactercard` VALUES (1,'Kyra',5,2,2,1,2,3,2,1,1,6),(2,'Sajan',4,0,0,0,0,0,0,4,3,8),(3,'Lem',6,1,0,1,1,4,0,2,3,5),(77,'Lini',5,1,0,1,0,6,0,2,3,4),(78,'Valeros',4,2,2,2,5,0,3,2,2,3),(79,'Amiri',4,2,1,2,5,0,2,2,2,4),(80,'Ezren',6,0,0,0,1,8,0,3,3,0),(81,'Seoni',6,0,0,0,0,3,0,3,4,5),(82,'Harsk',5,2,0,2,5,0,1,3,1,5),(83,'Merisiel',5,2,0,1,2,0,1,6,2,4),(84,'Seelah',4,2,2,2,3,1,3,0,2,6);
/*!40000 ALTER TABLE `charactercard` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `characterskill`
--

DROP TABLE IF EXISTS `characterskill`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `characterskill` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `PartyCharacterId` int(11) NOT NULL,
  `SkillId` int(11) NOT NULL,
  `SelectedAdjustment` int(11) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `fk_characterskills_partycharacter_idx` (`PartyCharacterId`),
  KEY `fk_characterskills_skills_idx` (`SkillId`),
  CONSTRAINT `fk_characterskill_partycharacter` FOREIGN KEY (`PartyCharacterId`) REFERENCES `partycharacter` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_characterskill_skill` FOREIGN KEY (`SkillId`) REFERENCES `skill` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `characterskill`
--

LOCK TABLES `characterskill` WRITE;
/*!40000 ALTER TABLE `characterskill` DISABLE KEYS */;
INSERT INTO `characterskill` VALUES (1,3,1,1),(2,4,1,3),(3,4,4,1),(4,4,6,1),(5,4,7,1);
/*!40000 ALTER TABLE `characterskill` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `party`
--

DROP TABLE IF EXISTS `party`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `party` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(100) NOT NULL,
  `PcgUserId` int(11) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `fk_pcguser_id_idx` (`PcgUserId`),
  CONSTRAINT `fk_party_pcguser` FOREIGN KEY (`PcgUserId`) REFERENCES `pcguser` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `party`
--

LOCK TABLES `party` WRITE;
/*!40000 ALTER TABLE `party` DISABLE KEYS */;
INSERT INTO `party` VALUES (1,'a1',7),(2,'a2qqq',7),(3,'rrrr',7);
/*!40000 ALTER TABLE `party` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `partycharacter`
--

DROP TABLE IF EXISTS `partycharacter`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `partycharacter` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `PartyId` int(11) NOT NULL,
  `CharacterCardId` int(11) NOT NULL,
  `LightArmors` int(11) DEFAULT NULL,
  `HeavyArmors` int(11) DEFAULT NULL,
  `Weapons` int(11) DEFAULT NULL,
  `WeaponCards` int(11) DEFAULT NULL,
  `SpellCards` int(11) DEFAULT NULL,
  `ArmorCards` int(11) DEFAULT NULL,
  `ItemCards` int(11) DEFAULT NULL,
  `AllyCards` int(11) DEFAULT NULL,
  `BlessingCards` int(11) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `fk_party_id_idx` (`PartyId`),
  KEY `fk_charactercard_id_idx` (`CharacterCardId`),
  CONSTRAINT `fk_partycharacter_charactercard` FOREIGN KEY (`CharacterCardId`) REFERENCES `charactercard` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_partycharacter_party` FOREIGN KEY (`PartyId`) REFERENCES `party` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `partycharacter`
--

LOCK TABLES `partycharacter` WRITE;
/*!40000 ALTER TABLE `partycharacter` DISABLE KEYS */;
INSERT INTO `partycharacter` VALUES (1,1,1,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),(3,2,3,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),(4,2,1,1,1,0,2,3,2,1,1,6),(6,3,2,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),(7,1,81,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),(8,1,2,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),(9,1,3,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),(10,1,77,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),(11,1,78,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),(12,1,79,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),(13,1,80,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),(14,1,82,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),(15,1,83,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),(16,1,84,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL);
/*!40000 ALTER TABLE `partycharacter` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `pcguser`
--

DROP TABLE IF EXISTS `pcguser`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `pcguser` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Email` varchar(200) NOT NULL,
  `Password` varchar(100) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `pcguser`
--

LOCK TABLES `pcguser` WRITE;
/*!40000 ALTER TABLE `pcguser` DISABLE KEYS */;
INSERT INTO `pcguser` VALUES (1,'kje@efigame.com','metoo101'),(2,'kje@efigame.com','metoo1'),(3,'abc@abc.com','abc'),(4,'qwe@qwe.qwe','qwe'),(5,'q1@q1.com','q1'),(6,'z1@z1.z1','z1'),(7,'z2@z2.z2','z2');
/*!40000 ALTER TABLE `pcguser` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `power`
--

DROP TABLE IF EXISTS `power`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `power` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Text` varchar(500) NOT NULL,
  `Number` int(11) NOT NULL,
  `Dice` int(11) DEFAULT NULL,
  `Adjustment` int(11) DEFAULT NULL,
  `CharacterCardId` int(11) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `fk_power_charactercard_id_idx` (`CharacterCardId`),
  CONSTRAINT `fk_power_charactercard_id` FOREIGN KEY (`CharacterCardId`) REFERENCES `charactercard` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `power`
--

LOCK TABLES `power` WRITE;
/*!40000 ALTER TABLE `power` DISABLE KEYS */;
INSERT INTO `power` VALUES (1,'Instead of your first exploration on a turn, you may reveal a card with the Divine trait to choose a character at your location. Shuffle 1d4+1 {format:addition} random cards from his discard pile into his deck, then discard the card you revealed.',1,4,1,1),(2,'Add 1d8 {format:addition} with the Magic trait to your check to defeat a bane with the Undead trait.',2,8,0,1);
/*!40000 ALTER TABLE `power` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `skill`
--

DROP TABLE IF EXISTS `skill`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `skill` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(45) NOT NULL,
  `Dice` int(11) NOT NULL,
  `CharacterCardId` int(11) NOT NULL,
  `PossibleAddons` int(11) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `fk_charactercard_id_idx` (`CharacterCardId`),
  CONSTRAINT `fk_skill_charactercard` FOREIGN KEY (`CharacterCardId`) REFERENCES `charactercard` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=73 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `skill`
--

LOCK TABLES `skill` WRITE;
/*!40000 ALTER TABLE `skill` DISABLE KEYS */;
INSERT INTO `skill` VALUES (1,'Strength',6,1,4),(3,'Dexterity',4,1,1),(4,'Constitution',6,1,2),(6,'Intelligence',6,1,2),(7,'Wisdom',12,1,4),(9,'Charisma',6,1,2),(10,'Strength',6,2,2),(11,'Dexterity',10,2,4),(13,'Constitution',6,2,2),(15,'Intelligence',6,2,2),(16,'Wisdom',8,2,3),(17,'Charisma',6,2,2),(18,'Strength',4,3,2),(19,'Dexterity',8,3,3),(20,'Constitution',6,3,2),(21,'Intelligence',6,3,2),(23,'Wisdom',6,3,2),(24,'Charisma',10,3,4),(25,'Strength',4,77,2),(26,'Dexterity',6,77,2),(27,'Constitution',8,77,2),(28,'Intelligence',6,77,2),(29,'Wisdom',10,77,4),(30,'Charisma',8,77,3),(31,'Strength',10,78,4),(32,'Dexterity',8,78,2),(33,'Constitution',8,78,4),(34,'Intelligence',6,78,1),(35,'Wisdom',4,78,2),(36,'Charisma',6,78,2),(37,'Strength',12,79,4),(38,'Dexterity',6,79,3),(39,'Consitution',8,79,4),(40,'Intelligence',4,79,1),(41,'Wisdom',6,79,1),(42,'Charisma',6,79,2),(43,'Strength',6,80,1),(44,'Dexterity',6,80,3),(45,'Constitution',4,80,2),(46,'Intelligence',12,80,4),(47,'Wisdom',8,80,2),(48,'Charisma',6,80,3),(49,'Strength',4,81,1),(50,'Dexterity',8,81,3),(51,'Constitution',6,81,2),(52,'Intelligence',6,81,3),(53,'Wisdom',6,81,2),(54,'Charisma',12,81,4),(55,'Strength',6,82,3),(56,'Dexterity',8,82,4),(57,'Constitution',12,82,3),(58,'Intelligence',6,82,1),(59,'Wisdom',6,82,3),(60,'Charisma',4,82,1),(61,'Strength',8,83,3),(62,'Dexterity',12,83,4),(63,'Constitution',6,83,2),(64,'Intelligence',4,83,3),(65,'Wisdom',6,83,1),(66,'Charisma',6,83,2),(67,'Strength',8,84,4),(68,'Dexterity',4,84,1),(69,'Constitution',8,84,3),(70,'Intelligence',4,84,2),(71,'Wisdom',8,84,3),(72,'Charisma',10,84,2);
/*!40000 ALTER TABLE `skill` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `subskill`
--

DROP TABLE IF EXISTS `subskill`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `subskill` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(45) NOT NULL,
  `BaseSkillId` int(11) NOT NULL,
  `Adjustment` int(11) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `fk_subskills_skills_id_idx` (`BaseSkillId`),
  CONSTRAINT `fk_subskill_skill` FOREIGN KEY (`BaseSkillId`) REFERENCES `skill` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=31 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `subskill`
--

LOCK TABLES `subskill` WRITE;
/*!40000 ALTER TABLE `subskill` DISABLE KEYS */;
INSERT INTO `subskill` VALUES (1,'Melee',1,2),(2,'Fortitute',4,3),(3,'Divine',7,2),(4,'Acrobatics',11,2),(5,'Fortitude',13,2),(6,'Knowledge',21,3),(7,'Arcane',24,1),(8,'Diplomacy',24,3),(9,'Divine',24,1),(10,'Knowledge',28,3),(11,'Divine',29,1),(12,'Survival',29,2),(13,'Melee',31,3),(14,'Diplomacy',36,2),(15,'Melee',37,2),(16,'Survival',41,3),(17,'Arcane',46,2),(18,'Knowledge',46,2),(19,'Diplomacy',54,2),(20,'Arcane',54,2),(21,'Ranged',56,3),(22,'Fortitude',57,2),(23,'Perception',59,2),(24,'Survival',59,2),(25,'Acrobatics',62,2),(26,'Disable',62,2),(27,'Stealth',62,2),(28,'Perception',65,2),(29,'Melee',67,2),(30,'Divine',71,2);
/*!40000 ALTER TABLE `subskill` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2014-01-23 22:47:10
