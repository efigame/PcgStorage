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
-- Table structure for table `adventure`
--

DROP TABLE IF EXISTS `adventure`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `adventure` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(200) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `adventure`
--

LOCK TABLES `adventure` WRITE;
/*!40000 ALTER TABLE `adventure` DISABLE KEYS */;
INSERT INTO `adventure` VALUES (1,'Rise of the Runelords'),(2,'Skull & Shackles'),(3,'Promotional');
/*!40000 ALTER TABLE `adventure` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `card`
--

DROP TABLE IF EXISTS `card`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `card` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(200) NOT NULL,
  `DeckId` int(11) NOT NULL,
  `CardTypeId` int(11) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `fk_card_deck_id_idx` (`DeckId`),
  KEY `fk_card_cardtype_id_idx` (`CardTypeId`),
  CONSTRAINT `fk_card_cardtype_id` FOREIGN KEY (`CardTypeId`) REFERENCES `cardtype` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_card_deck_id` FOREIGN KEY (`DeckId`) REFERENCES `deck` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=277 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `card`
--

LOCK TABLES `card` WRITE;
/*!40000 ALTER TABLE `card` DISABLE KEYS */;
INSERT INTO `card` VALUES (1,'Ezren',1,1),(2,'Harsk',1,1),(3,'Kyra',1,1),(4,'Lem',1,1),(5,'Merisiel',1,1),(6,'Seoni',1,1),(7,'Valeros',1,1),(8,'Amiri',2,1),(9,'Lini',2,1),(10,'Sajan',2,1),(11,'Seelah',2,1),(12,'Rise of the Runelords',1,2),(13,'Perils of the Lost Coast',1,3),(14,'Brigandoom',1,4),(15,'The Poison Pill',1,4),(16,'Black Fang\'s Dungeon',1,4),(17,'Academy',1,5),(18,'Apothecary',1,5),(19,'City Gate',1,5),(20,'Deeper Dungeons',1,5),(21,'Desecrated Vault',1,5),(22,'Farmhouse',1,5),(23,'Garrison',1,5),(24,'General Store',1,5),(25,'Guard Tower',1,5),(26,'Mountain Peak',1,5),(27,'Prison',1,5),(28,'Sandpoint Cathedral',1,5),(29,'Shrine to Lamashtu',1,5),(30,'Temple',1,5),(31,'Thassilonian Dungeon',1,5),(32,'The Old Light',1,5),(33,'Throne Room',1,5),(34,'Treacherous Cave',1,5),(35,'Town Square',1,5),(36,'Village House',1,5),(37,'Warrens',1,5),(38,'Waterfront',1,5),(39,'Wooden Bridge',1,5),(40,'Woods',1,5),(41,'Black Fang',1,6),(42,'Jubrayl Vhiski',1,6),(43,'Pillbug Podicker',1,6),(44,'Ancient Skeleton',1,7),(45,'Bandit',1,7),(46,'Poison Trap',1,7),(47,'Bugbear',1,8),(48,'Bunyip',1,8),(49,'Cultist',1,8),(50,'Enchanter',1,8),(51,'Ghost',1,8),(52,'Ghoul',1,8),(53,'Giant Gecko',1,8),(54,'Goblin Commando',1,8),(55,'Goblin Warrior',1,8),(56,'Hell Hound',1,8),(57,'Hill Giant',1,8),(58,'Mercenary',1,8),(59,'Ogre',1,8),(60,'Plague Zombie',1,8),(61,'Rat Swarm',1,8),(62,'Scout',1,8),(63,'Shadow',1,8),(64,'Siren',1,8),(65,'Skeleton',1,8),(66,'Sneak',1,8),(67,'Spectre',1,8),(68,'Traitor',1,8),(69,'Warlord',1,8),(70,'Werewolf',1,8),(71,'Xulgath',1,8),(72,'Zombie',1,8),(73,'Zombie Giant',1,8),(74,'Ambush',1,9),(75,'Battered Chest',1,9),(76,'Collapsed Ceiling',1,9),(77,'Explosive Runes',1,9),(78,'Large Chest',1,9),(79,'Locked Passage',1,9),(80,'Mystic Inscription',1,9),(81,'Pit Trap',1,9),(82,'Skeleton Horde',1,9),(83,'Trapped Locker',1,9),(84,'Trapped Passageway',1,9),(85,'Treasure Map',1,9),(86,'Bastard Sword',1,10),(87,'Battleaxe',1,10),(88,'Dagger',1,10),(89,'Dart',1,10),(90,'Flaming Mace +1',1,10),(91,'Glaive',1,10),(92,'Greataxe',1,10),(93,'Heavy Crossbow',1,10),(94,'Light Crossbow',1,10),(95,'Longbow',1,10),(96,'Longspear',1,10),(97,'Longsword',1,10),(98,'Longsword +1',1,10),(99,'Mace',1,10),(100,'Quarterstaff',1,10),(101,'Returning Throwing Axe +1',1,10),(102,'Scimitar',1,10),(103,'Shock Longbow +1',1,10),(104,'Short Sword',1,10),(105,'Shortbow',1,10),(106,'Sling',1,10),(107,'Spiked Chain',1,10),(108,'Starknife',1,10),(109,'Throwing Axe',1,10),(110,'Warhammer',1,10),(111,'Warhammer +1',1,10),(112,'Acid Arrow',1,11),(113,'Aid',1,11),(114,'Arcane Armor',1,11),(115,'Augury',1,11),(116,'Charm Person',1,11),(117,'Cure',1,11),(118,'Detect Evil',1,11),(119,'Detect Magic',1,11),(120,'Find Traps',1,11),(121,'Force Missile',1,11),(122,'Glibness',1,11),(123,'Guidance',1,11),(124,'Holy Light',1,11),(125,'Inflict',1,11),(126,'Invisibility',1,11),(127,'Levitate',1,11),(128,'Lightning Touch',1,11),(129,'Mending',1,11),(130,'Mirror Image',1,11),(131,'Sanctuary',1,11),(132,'Sleep',1,11),(133,'Strength',1,11),(134,'Chain Mail',1,13),(135,'Elven Chain Shirt',1,13),(136,'Half-Plate',1,13),(137,'Leather Armor',1,13),(138,'Magic Chain Mail',1,13),(139,'Magic Half-Plate',1,13),(140,'Magic Leather Armor',1,13),(141,'Magic Shield',1,13),(142,'Wooden Shield',1,13),(143,'Amulet of Fortitude',1,14),(144,'Amulet of Life',1,14),(145,'Blast Stone',1,14),(146,'Boots of Elvenkind',1,14),(147,'Bracers of Protection',1,14),(148,'Caltrops',1,14),(149,'Cape of Escape',1,14),(150,'Codex',1,14),(151,'Crowbar',1,14),(152,'Holy Candle',1,14),(153,'Holy Water',1,14),(154,'Luckstone',1,14),(155,'Masterwork Tools',1,14),(156,'Mattock',1,14),(157,'Potion of Energy Resistance',1,14),(158,'Potion of Fortitude',1,14),(159,'Potion of Ghostly Form',1,14),(160,'Potion of Glibness',1,14),(161,'Potion of Healing',1,14),(162,'Potion of Hiding',1,14),(163,'Potion of Vision',1,14),(164,'Spyglass',1,14),(165,'Thieve\'s Tools',1,14),(166,'Token of Remembrance',1,14),(167,'Tome of Knowledge',1,14),(168,'Acolyte',1,15),(169,'Archer',1,15),(170,'Burglar',1,15),(171,'Crow',1,15),(172,'Father Zantus',1,15),(173,'Guard',1,15),(174,'Guide',1,15),(175,'Mayor Kendra Deverin',1,15),(176,'Night Watch',1,15),(177,'Sage',1,15),(178,'Shalelu Andosana',1,15),(179,'Sheriff Hemlock',1,15),(180,'Soldier',1,15),(181,'Standard Bearer',1,15),(182,'Troubadour',1,15),(183,'Blessing of Calistria',1,16),(184,'Blessing of Desna',1,16),(185,'Blessing of Erastil',1,16),(186,'Blessing of Gorum',1,16),(187,'Blessing of Iomedae',1,16),(188,'Blessing of Irori',1,16),(189,'Blessing of Pharasma',1,16),(190,'Blessing of Sarenrae',1,16),(191,'Blessing of Shelyn',1,16),(192,'Blessing of the Gods',1,16),(193,'Blessing of Torag',1,16),(194,'Fire Sneeze',9,11),(195,'Poog of Zarongel',9,15),(196,'Blessing of Zarongel',9,16),(197,'Satyr',2,8),(198,'Secret Stash',2,9),(199,'Allying Dart +1',2,10),(200,'Deathbane Light Crossbow +1',2,10),(201,'Greatsword',2,10),(202,'Icy Longspear +1',2,10),(203,'Amulet of Mighty Fists',2,14),(204,'Crown of Charisma',2,14),(205,'Eyes of the Eagle',2,14),(206,'Sage\'s journal',2,14),(207,'Dog',2,15),(208,'Saber-Toothed Tiger',2,15),(209,'Snake',2,15),(210,'Burnt Offerings',3,3),(211,'Attack on Sandpoint',3,4),(212,'Local Heroes',3,4),(213,'Trouble in Sandpoint',3,4),(214,'Approach to Thistletop',3,4),(215,'Thistletop Delve',3,4),(216,'Catacombs of Wrath',3,5),(217,'Glassworks',3,5),(218,'Goblin Fortress',3,5),(219,'Junk Beach',3,5),(220,'Nettlemaze',3,5),(221,'Swallowtail Festival',3,5),(222,'The Rusty Dragon',3,5),(223,'Erylium',3,6),(224,'Gogmurt',3,6),(225,'Nualia',3,6),(226,'Ripnugget and Stickfoot',3,6),(227,'The Sandpoint Devil',3,6),(228,'Bruthazmus',3,7),(229,'Goblin Raider',3,7),(230,'Koruvus',3,7),(231,'Lyrie Akenja',3,7),(232,'Orik Vancaskerkin',3,7),(233,'Tangletooth',3,7),(234,'Tsuto Kaikitsu',3,7),(235,'Wrathful Sinspawn',3,7),(236,'Attic Whisperer',3,8),(237,'Giant Hermit Crab',3,8),(238,'Goblin Cutpurse',3,8),(239,'Goblin Dog',3,8),(240,'Goblin Pyro',3,8),(241,'Goblin Snake',3,8),(242,'Goblin Warchanter',3,8),(243,'Tickwood Boar',3,8),(244,'Yeth Hound',3,8),(245,'Goblin Raid',3,9),(246,'Monster in the Closet',3,9),(247,'Pit of Malfeshnekor',3,9),(248,'Shopkeeper\'s Daughter',3,9),(249,'Slashing Blade',3,9),(250,'Bastard Sword +1',3,10),(251,'Dagger +1',3,10),(252,'Dogslicer',3,10),(253,'Dogslicer +1',3,10),(254,'Longbow +1',3,10),(255,'Short Sword +1',3,10),(256,'Enfeeble',3,11),(257,'Fiery Weapon',3,11),(258,'Frost Ray',3,11),(259,'Scorching Ray',3,11),(260,'Speed',3,11),(261,'Sihedron  Medallion',3,12),(262,'Elven Breastplate',3,13),(263,'Shield of Fire Resistance',3,13),(264,'Potion of Gracefulness',3,14),(265,'Potion of Ruggedness',3,14),(266,'Staff of Minor Healing',3,14),(267,'Wand of Force Missile',3,14),(268,'Wand of Shield',3,14),(269,'Aldern Foxglove',3,15),(270,'Ameik Kaijitsu',3,15),(271,'Cyrdak Drokkus',3,15),(272,'Grizzled Mercenary',3,15),(273,'Ilsoari Gandethus',3,15),(274,'Toad',3,15),(275,'Ven Vinder',3,15),(276,'Blessing of Lamashtu',3,16);
/*!40000 ALTER TABLE `card` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `cardtype`
--

DROP TABLE IF EXISTS `cardtype`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `cardtype` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(100) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cardtype`
--

LOCK TABLES `cardtype` WRITE;
/*!40000 ALTER TABLE `cardtype` DISABLE KEYS */;
INSERT INTO `cardtype` VALUES (1,'Character'),(2,'Adventure Path'),(3,'Adventure'),(4,'Scenario'),(5,'Location'),(6,'Villain'),(7,'Henchman'),(8,'Monster'),(9,'Barrier'),(10,'Weapon'),(11,'Spell'),(12,'Loot'),(13,'Armor'),(14,'Item'),(15,'Ally'),(16,'Blessing');
/*!40000 ALTER TABLE `cardtype` ENABLE KEYS */;
UNLOCK TABLES;

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
  `FavoredCardType` varchar(45) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=85 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `charactercard`
--

LOCK TABLES `charactercard` WRITE;
/*!40000 ALTER TABLE `charactercard` DISABLE KEYS */;
INSERT INTO `charactercard` VALUES (1,'Kyra',5,2,2,1,2,3,2,1,1,6,6,4,5,4,2,2,8,'Blessing'),(2,'Sajan',4,0,0,0,0,0,0,4,3,8,6,3,1,0,6,5,10,'Item'),(3,'Lem',6,1,0,1,1,4,0,2,3,5,6,3,6,1,4,5,6,'Your choice'),(77,'Lini',5,1,0,1,0,6,0,2,3,4,5,1,8,1,4,6,5,'Ally'),(78,'Valeros',4,2,2,2,5,0,3,2,2,3,6,8,0,5,4,4,4,'Weapon'),(79,'Amiri',4,2,1,2,5,0,2,2,2,4,5,8,0,3,5,3,6,'Weapon'),(80,'Ezren',6,0,0,0,1,8,0,3,3,0,8,2,11,1,6,5,0,'Spell'),(81,'Seoni',6,0,0,0,0,3,0,3,4,5,7,1,6,0,6,5,7,'Spell'),(82,'Harsk',5,2,0,2,5,0,1,3,1,5,6,6,2,2,5,4,6,'Weapon'),(83,'Merisiel',5,2,0,1,2,0,1,6,2,4,6,4,1,2,9,3,6,'Item'),(84,'Seelah',4,2,2,2,3,1,3,0,2,6,5,5,3,5,0,4,8,'Armor');
/*!40000 ALTER TABLE `charactercard` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `characterdeck`
--

DROP TABLE IF EXISTS `characterdeck`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `characterdeck` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `PartyCharacterId` int(11) NOT NULL,
  `CardId` int(11) NOT NULL,
  `Count` int(11) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `fk_characterdeck_partycharacter_id_idx` (`PartyCharacterId`),
  KEY `fk_characterdeck_card_idx` (`CardId`),
  CONSTRAINT `fk_characterdeck_card` FOREIGN KEY (`CardId`) REFERENCES `card` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_characterdeck_partycharacter_id` FOREIGN KEY (`PartyCharacterId`) REFERENCES `partycharacter` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `characterdeck`
--

LOCK TABLES `characterdeck` WRITE;
/*!40000 ALTER TABLE `characterdeck` DISABLE KEYS */;
/*!40000 ALTER TABLE `characterdeck` ENABLE KEYS */;
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
-- Table structure for table `deck`
--

DROP TABLE IF EXISTS `deck`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `deck` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(45) NOT NULL,
  `AdventureId` int(11) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `fk_deck_adventure_id_idx` (`AdventureId`),
  CONSTRAINT `fk_deck_adventure_id` FOREIGN KEY (`AdventureId`) REFERENCES `adventure` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `deck`
--

LOCK TABLES `deck` WRITE;
/*!40000 ALTER TABLE `deck` DISABLE KEYS */;
INSERT INTO `deck` VALUES (1,'Base Set',1),(2,'Character Add-On',1),(3,'Deck 1',1),(4,'Deck 2',1),(5,'Deck 3',1),(6,'Deck 4',1),(7,'Deck 5',1),(8,'Deck 6',1),(9,'Promotional',3);
/*!40000 ALTER TABLE `deck` ENABLE KEYS */;
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

-- Dump completed on 2014-01-29 21:52:06
