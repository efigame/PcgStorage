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
  `PossibleHandSize` int(11) NOT NULL,
  `PossibleWeaponCards` int(11) NOT NULL,
  `PossibleSpellCards` int(11) NOT NULL,
  `PossibleArmorCards` int(11) NOT NULL,
  `PossibleItemCards` int(11) NOT NULL,
  `PossibleAllyCards` int(11) NOT NULL,
  `PossibleBlessingCards` int(11) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=85 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `charactercard`
--

LOCK TABLES `charactercard` WRITE;
/*!40000 ALTER TABLE `charactercard` DISABLE KEYS */;
INSERT INTO `charactercard` VALUES (1,'Kyra',5,2,2,1,2,3,2,1,1,6,6,4,5,4,2,2,8),(2,'Sajan',4,0,0,0,0,0,0,4,3,8,6,3,1,0,6,5,10),(3,'Lem',6,1,0,1,1,4,0,2,3,5,6,3,6,1,4,5,6),(77,'Lini',5,1,0,1,0,6,0,2,3,4,5,1,8,1,4,6,5),(78,'Valeros',4,2,2,2,5,0,3,2,2,3,6,8,0,5,4,4,4),(79,'Amiri',4,2,1,2,5,0,2,2,2,4,5,8,0,3,5,3,6),(80,'Ezren',6,0,0,0,1,8,0,3,3,0,8,2,11,1,6,5,0),(81,'Seoni',6,0,0,0,0,3,0,3,4,5,7,1,6,0,6,5,7),(82,'Harsk',5,2,0,2,5,0,1,3,1,5,6,6,2,2,5,4,6),(83,'Merisiel',5,2,0,1,2,0,1,6,2,4,6,4,1,2,9,3,6),(84,'Seelah',4,2,2,2,3,1,3,0,2,6,5,5,3,5,0,4,8);
/*!40000 ALTER TABLE `charactercard` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `characterpower`
--

DROP TABLE IF EXISTS `characterpower`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `characterpower` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `PartyCharacterId` int(11) NOT NULL,
  `PowerId` int(11) NOT NULL,
  `SelectedPowers` int(11) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `fk_characterpower_partycharacter_id_idx` (`PartyCharacterId`),
  KEY `fk_characterpower_power_id_idx` (`PowerId`),
  CONSTRAINT `fk_characterpower_partycharacter_id` FOREIGN KEY (`PartyCharacterId`) REFERENCES `partycharacter` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_characterpower_power_id` FOREIGN KEY (`PowerId`) REFERENCES `power` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `characterpower`
--

LOCK TABLES `characterpower` WRITE;
/*!40000 ALTER TABLE `characterpower` DISABLE KEYS */;
INSERT INTO `characterpower` VALUES (1,23,16,3),(2,18,3,3),(3,25,20,1),(4,25,19,1);
/*!40000 ALTER TABLE `characterpower` ENABLE KEYS */;
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
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `characterskill`
--

LOCK TABLES `characterskill` WRITE;
/*!40000 ALTER TABLE `characterskill` DISABLE KEYS */;
INSERT INTO `characterskill` VALUES (1,3,1,1),(2,4,1,3),(3,4,4,1),(4,4,6,1),(5,4,7,1),(6,8,11,3),(7,8,13,1),(8,8,16,1),(9,18,11,0),(10,18,13,1),(11,23,46,1),(12,23,48,1),(13,25,57,2);
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
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `party`
--

LOCK TABLES `party` WRITE;
/*!40000 ALTER TABLE `party` DISABLE KEYS */;
INSERT INTO `party` VALUES (1,'a1',7),(2,'a2qqq',7),(3,'rrrr',7),(4,'z2',7);
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
  `HandSize` int(11) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `fk_party_id_idx` (`PartyId`),
  KEY `fk_charactercard_id_idx` (`CharacterCardId`),
  CONSTRAINT `fk_partycharacter_charactercard` FOREIGN KEY (`CharacterCardId`) REFERENCES `charactercard` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_partycharacter_party` FOREIGN KEY (`PartyId`) REFERENCES `party` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=28 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `partycharacter`
--

LOCK TABLES `partycharacter` WRITE;
/*!40000 ALTER TABLE `partycharacter` DISABLE KEYS */;
INSERT INTO `partycharacter` VALUES (1,1,1,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),(3,2,3,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),(4,2,1,1,1,0,2,3,2,1,1,6,6),(6,3,2,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),(7,1,81,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),(8,1,2,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),(9,1,3,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),(10,1,77,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),(11,1,78,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),(12,1,79,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),(13,1,80,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),(14,1,82,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),(15,1,83,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),(16,1,84,2,2,2,3,1,3,0,2,6,5),(17,4,1,2,2,1,2,3,2,1,1,6,6),(18,4,2,0,0,0,1,0,0,4,3,10,6),(19,4,3,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),(20,4,77,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),(21,4,78,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),(22,4,79,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),(23,4,80,0,0,0,1,8,0,3,3,0,8),(24,4,81,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),(25,4,82,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),(26,4,83,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),(27,4,84,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL);
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
) ENGINE=InnoDB AUTO_INCREMENT=25 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `power`
--

LOCK TABLES `power` WRITE;
/*!40000 ALTER TABLE `power` DISABLE KEYS */;
INSERT INTO `power` VALUES (1,'Instead of your first exploration on a turn, you may reveal a card with the Divine trait to choose a character at your location. Shuffle 1d4+1 ({format:check} +2) random cards from his discard pile into his deck, then discard the card you revealed.',1,0,0,1),(2,'Add 1d8 ({format:check} +1) with the Magic trait to your check to defeat a bane with the Undead trait.',2,0,0,1),(3,'When you attempt a combat check without playing a weapon, you may use your Dexterity die instead of your Strength die ({format:check} and add the Magic trait) ({format:check} and the Fire trait).',1,NULL,NULL,2),(4,'You may play any number of blessings on your combat check; recharge them instead of discarding them.',2,NULL,NULL,2),(5,'Once per check, you may recharge a card to add 1d4 ({format:check}+1) ({format:check}+2) to a check attempted by another character at your location.',1,NULL,NULL,3),(6,'At the start of your turn, you may exchange 1 card in your hand with 1 card of the same type in your discard pile.',2,NULL,NULL,3),(7,'When you play an ally with the Animal trait, you may recharge it instead of discarding it.',1,NULL,NULL,77),(8,'You may reveal an ally with the Animal trait to add 1d4 ({format:check}+1) ({format:check}+2) to your check.',2,NULL,NULL,77),(9,'You may discard a card to roll d10 instead of your Strength or Dexterity die for any check.',3,NULL,NULL,77),(10,'Add 1d4 ({format:check}+1) ({format:check}+2) to another character\'s combat check at your location.',1,NULL,NULL,78),(11,'When you play a weapon, you may recharge it instead of discarding it.',2,NULL,NULL,78),(12,'You may bury a card from your hand to add 1d10 ({format:check}+1) to your Strength, Melee, or Constitution check.',1,NULL,NULL,79),(13,'You may move at the end of your turn ({format:check} and / or move another character to the location where you end your turn).',2,NULL,NULL,79),(14,'After you play a spell with the Arcane trait, you may examine the top card of your deck; if it\'s a spell, you may put it in your hand.',1,NULL,NULL,80),(15,'If you acquire a card with the Magic trait during an exploration, you may immediately explore again.',2,NULL,NULL,80),(16,'{format:check} Add 1 ({format:check} 2) to your check to recharge a card.',3,NULL,NULL,80),(17,'For your combat check, you may discard a card to roll your Arcane die + 1d6 ({format:check}+1) ({format:check}+2) with the Attack, Fire, and Magic traits. This counts as playing a spell.',1,NULL,NULL,81),(18,'You automatically succeed at your check to recharge a spell ({format:check} or item) with the Arcane trait.',2,NULL,NULL,81),(19,'At the end of your turn, you may examine the top card ({format:check} or bottom card) of your location deck.',1,NULL,NULL,82),(20,'You may recharge a card to add 1d4 ({format:check} +1) ({format:check} +2) to a combat check at another location.',2,NULL,NULL,82),(21,'You may evade your encounter.',1,NULL,NULL,83),(22,'If you are the only character at your location, you may recharge a card to add 1d6 ({format:check} + 1) ({format:check} + 2) to your combat check, or discard it to add an additional 1d6.',2,NULL,NULL,83),(23,'You may discard the top card of your deck to add 1d6 ({format:check} +1) to your check. If the top card was a blessing ({format:check} or spell), recharge it instead of discarding it.',1,NULL,NULL,84),(24,'You may examine the top card of you location deck at the start ({format:check} or end) of your turn. If it\'s a boon, put in on the bottom of the deck.',2,NULL,NULL,84);
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

-- Dump completed on 2014-01-26 22:16:44
