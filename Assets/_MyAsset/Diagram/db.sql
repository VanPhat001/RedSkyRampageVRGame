-- MySQL dump 10.13  Distrib 8.0.38, for macos14 (arm64)
--
-- Host: 127.0.0.1    Database: unity_db
-- ------------------------------------------------------
-- Server version	8.0.36

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
-- Table structure for table `tbl_friend`
--

DROP TABLE IF EXISTS `tbl_friend`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_friend` (
  `id` int NOT NULL AUTO_INCREMENT,
  `player_id_1` int NOT NULL,
  `player_id_2` int NOT NULL,
  `time_created` datetime DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`),
  UNIQUE KEY `player_id_1` (`player_id_1`,`player_id_2`),
  KEY `player_id_2` (`player_id_2`),
  CONSTRAINT `tbl_friend_ibfk_1` FOREIGN KEY (`player_id_1`) REFERENCES `tbl_player` (`id`) ON DELETE CASCADE,
  CONSTRAINT `tbl_friend_ibfk_2` FOREIGN KEY (`player_id_2`) REFERENCES `tbl_player` (`id`) ON DELETE CASCADE,
  CONSTRAINT `tbl_friend_chk_1` CHECK ((`player_id_1` < `player_id_2`))
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_friend`
--

LOCK TABLES `tbl_friend` WRITE;
/*!40000 ALTER TABLE `tbl_friend` DISABLE KEYS */;
/*!40000 ALTER TABLE `tbl_friend` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_map`
--

DROP TABLE IF EXISTS `tbl_map`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_map` (
  `id` int NOT NULL AUTO_INCREMENT,
  `map_name` varchar(200) DEFAULT NULL,
  `time_created` datetime DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_map`
--

LOCK TABLES `tbl_map` WRITE;
/*!40000 ALTER TABLE `tbl_map` DISABLE KEYS */;
/*!40000 ALTER TABLE `tbl_map` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_map_info`
--

DROP TABLE IF EXISTS `tbl_map_info`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_map_info` (
  `id` int NOT NULL AUTO_INCREMENT,
  `player_id` int NOT NULL,
  `map_id` int NOT NULL,
  `star` decimal(3,1) DEFAULT NULL,
  `is_complete` bit(1) NOT NULL DEFAULT b'0',
  `time_update` datetime DEFAULT NULL,
  `time_created` datetime DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`),
  KEY `player_id` (`player_id`),
  KEY `map_id` (`map_id`),
  CONSTRAINT `tbl_map_info_ibfk_1` FOREIGN KEY (`player_id`) REFERENCES `tbl_player` (`id`) ON DELETE CASCADE,
  CONSTRAINT `tbl_map_info_ibfk_2` FOREIGN KEY (`map_id`) REFERENCES `tbl_map` (`id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_map_info`
--

LOCK TABLES `tbl_map_info` WRITE;
/*!40000 ALTER TABLE `tbl_map_info` DISABLE KEYS */;
/*!40000 ALTER TABLE `tbl_map_info` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_player`
--

DROP TABLE IF EXISTS `tbl_player`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_player` (
  `id` int NOT NULL AUTO_INCREMENT,
  `username` char(40) NOT NULL,
  `password` char(40) NOT NULL,
  `display_name` varchar(100) DEFAULT 'player''s display name',
  `date_of_birth` datetime DEFAULT NULL,
  `location` varchar(200) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci DEFAULT NULL,
  `time_created` datetime DEFAULT CURRENT_TIMESTAMP,
  `gender` enum('MALE','FEMALE','OTHER') DEFAULT 'MALE',
  `email` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `username` (`username`)
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_player`
--

LOCK TABLES `tbl_player` WRITE;
/*!40000 ALTER TABLE `tbl_player` DISABLE KEYS */;
INSERT INTO `tbl_player` VALUES (1,'user1','1234','Người chơi 1','2024-10-03 00:00:00','Can Tho, Vietnam','2024-10-07 17:49:09','MALE','gugu@gmail.com'),(2,'user2','1234','Người chơi vô danh','2024-10-01 00:00:00','Hà Nội, Vietnam','2024-10-07 17:50:26','OTHER','vodanh@gmail.com'),(3,'user3','1234','Ninja123','2024-10-01 00:00:00','Hà Nội, Vietnam','2024-10-07 17:50:26','OTHER','vodanh@gmail.com'),(4,'user4','1234','Bú đá nói iu e <3','2024-10-01 00:00:00','Hà Nội, Vietnam','2024-10-07 17:50:26','OTHER','vodanh@gmail.com');
/*!40000 ALTER TABLE `tbl_player` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_request`
--

DROP TABLE IF EXISTS `tbl_request`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_request` (
  `id` int NOT NULL AUTO_INCREMENT,
  `player_send_id` int NOT NULL,
  `player_receive_id` int NOT NULL,
  `time_created` datetime DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`),
  UNIQUE KEY `player_send_id` (`player_send_id`,`player_receive_id`),
  KEY `player_receive_id` (`player_receive_id`),
  CONSTRAINT `tbl_request_ibfk_1` FOREIGN KEY (`player_send_id`) REFERENCES `tbl_player` (`id`) ON DELETE CASCADE,
  CONSTRAINT `tbl_request_ibfk_2` FOREIGN KEY (`player_receive_id`) REFERENCES `tbl_player` (`id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_request`
--

LOCK TABLES `tbl_request` WRITE;
/*!40000 ALTER TABLE `tbl_request` DISABLE KEYS */;
/*!40000 ALTER TABLE `tbl_request` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-10-24 23:46:00
