-- MySQL dump 10.13  Distrib 5.5.50, for debian-linux-gnu (x86_64)
--
-- Host: 0.0.0.0    Database: pset7
-- ------------------------------------------------------
-- Server version	5.5.50-0ubuntu0.14.04.1

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
-- Table structure for table `history`
--

DROP TABLE IF EXISTS `history`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `history` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `user_id` int(10) unsigned NOT NULL,
  `symbol` varchar(255) NOT NULL,
  `shares` int(10) unsigned NOT NULL,
  `price` decimal(65,4) unsigned NOT NULL,
  `date` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `type` varchar(5) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `user_id` (`user_id`)
) ENGINE=InnoDB AUTO_INCREMENT=49 DEFAULT CHARSET=latin1 COMMENT='0 sell 1 is buy';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `history`
--

LOCK TABLES `history` WRITE;
/*!40000 ALTER TABLE `history` DISABLE KEYS */;
INSERT INTO `history` VALUES (9,39,'AAPL',1,140.9200,'2017-03-24 01:20:02','Buy'),(10,39,'AAPL',1001,140.9300,'2017-03-24 18:52:20','Sell'),(11,39,'TSLA',5000,260.2100,'2017-03-24 18:52:39','Sell'),(12,39,'TSLA',5000,260.2600,'2017-03-24 18:53:07','Buy'),(13,39,'AAPL',1001,140.9201,'2017-03-24 18:53:16','Buy'),(14,39,'N/A',0,30.1000,'2017-03-24 19:45:30','Add'),(15,40,'AAPL',10,140.7000,'2017-03-24 19:48:12','Buy'),(16,40,'GOOG',10,813.1507,'2017-03-24 19:48:21','Buy'),(17,40,'MSFT',1,64.9000,'2017-03-24 19:48:29','Buy'),(18,40,'TSLA',1,260.7800,'2017-03-24 19:48:41','Buy'),(19,40,'TSLA',1,260.7800,'2017-03-24 19:48:41','Buy'),(20,40,'TSLA',2,261.0000,'2017-03-24 19:49:25','Sell'),(21,40,'TSLA',1,261.0800,'2017-03-24 19:49:33','Buy'),(22,40,'CCV',1,25.5600,'2017-03-24 19:50:00','Buy'),(23,40,'CCV',1,25.5600,'2017-03-24 19:50:15','Sell'),(24,40,'TSLA',1,260.7900,'2017-03-24 19:50:36','Buy'),(25,40,'N/A',0,500.0000,'2017-03-24 19:50:51','Add'),(26,40,'CCV',1,25.5600,'2017-03-24 19:51:05','Buy'),(30,41,'N/A',0,500.0000,'2017-03-24 20:20:20','Add'),(33,41,'AAPL',1,140.6400,'2017-03-24 20:51:15','Buy'),(34,39,'AAPL',1001,140.6400,'2017-03-25 03:19:40','Sell'),(35,39,'TSLA',5000,263.1600,'2017-03-25 03:19:48','Sell'),(36,39,'BABA',10000,108.0400,'2017-03-25 03:19:55','Sell'),(37,39,'CCV',1000,25.5600,'2017-03-25 03:20:02','Sell'),(38,39,'AMD',109000,13.7000,'2017-03-25 03:20:09','Sell'),(39,39,'BAC',45000,23.1200,'2017-03-25 03:20:15','Sell'),(40,39,'MSFT',100,64.9800,'2017-03-25 03:22:27','Sell'),(41,39,'HYU.DE',1000,42.5000,'2017-03-25 03:27:37','Buy'),(42,39,'HYU.DE',1000,42.5000,'2017-03-25 03:37:11','Buy'),(43,39,'HYU.DE',1000,42.5000,'2017-03-25 03:38:03','Buy'),(44,39,'HYU.DE',1000,42.5000,'2017-03-25 03:38:09','Sell'),(45,39,'HYU.DE',100000,42.5000,'2017-03-25 03:38:51','Buy'),(46,39,'AAPL',25000,140.6400,'2017-03-25 03:39:22','Buy'),(47,39,'AAPL',25000,140.6400,'2017-03-25 03:39:38','Sell'),(48,39,'HYU.DE',100000,42.5000,'2017-03-25 03:39:42','Sell');
/*!40000 ALTER TABLE `history` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `portfolios`
--

DROP TABLE IF EXISTS `portfolios`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `portfolios` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `user_id` int(10) unsigned NOT NULL,
  `symbol` varchar(255) NOT NULL,
  `shares` int(10) unsigned NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `user_id` (`user_id`,`symbol`),
  UNIQUE KEY `user_id_2` (`user_id`,`symbol`)
) ENGINE=InnoDB AUTO_INCREMENT=34 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `portfolios`
--

LOCK TABLES `portfolios` WRITE;
/*!40000 ALTER TABLE `portfolios` DISABLE KEYS */;
INSERT INTO `portfolios` VALUES (20,40,'AAPL',10),(21,40,'GOOG',10),(22,40,'MSFT',1),(25,40,'TSLA',2),(28,40,'CCV',1);
/*!40000 ALTER TABLE `portfolios` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `users`
--

DROP TABLE IF EXISTS `users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `users` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `username` varchar(255) NOT NULL,
  `hash` varchar(255) NOT NULL,
  `cash` decimal(65,4) unsigned NOT NULL DEFAULT '0.0000',
  PRIMARY KEY (`id`),
  UNIQUE KEY `username` (`username`)
) ENGINE=InnoDB AUTO_INCREMENT=42 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `users`
--

LOCK TABLES `users` WRITE;
/*!40000 ALTER TABLE `users` DISABLE KEYS */;
INSERT INTO `users` VALUES (1,'andi','$2y$10$c.e4DK7pVyLT.stmHxgAleWq4yViMmkwKz3x8XCo4b/u3r8g5OTnS',10000.0000),(2,'caesar','$2y$10$0p2dlmu6HnhzEMf9UaUIfuaQP7tFVDMxgFcVs0irhGqhOxt6hJFaa',10000.0000),(3,'eli','$2y$10$COO6EnTVrCPCEddZyWeEJeH9qPCwPkCS0jJpusNiru.XpRN6Jf7HW',10000.0000),(4,'hdan','$2y$10$o9a4ZoHqVkVHSno6j.k34.wC.qzgeQTBHiwa3rpnLq7j2PlPJHo1G',10000.0000),(5,'jason','$2y$10$ci2zwcWLJmSSqyhCnHKUF.AjoysFMvlIb1w4zfmCS7/WaOrmBnLNe',10000.0000),(6,'john','$2y$10$dy.LVhWgoxIQHAgfCStWietGdJCPjnNrxKNRs5twGcMrQvAPPIxSy',10000.0000),(7,'levatich','$2y$10$fBfk7L/QFiplffZdo6etM.096pt4Oyz2imLSp5s8HUAykdLXaz6MK',10000.0000),(8,'rob','$2y$10$3pRWcBbGdAdzdDiVVybKSeFq6C50g80zyPRAxcsh2t5UnwAkG.I.2',10000.0000),(9,'skroob','$2y$10$395b7wODm.o2N7W5UZSXXuXwrC0OtFB17w4VjPnCIn/nvv9e4XUQK',10000.0000),(10,'zamyla','$2y$10$UOaRF0LGOaeHG4oaEkfO4O7vfI34B1W23WqHr9zCpXL68hfQsS3/e',10000.0000),(39,'dachsund','$2y$10$F.x2T6onaE7IFQeu4Qf7nuHH98x9hRchX59GPOTILQL6LEJXRtYoO',8353739.7299),(40,'Dylan','$2y$10$RYi5Z2Pxnf1.kukHY2XLkukFnCrEN.kgd57qELyrXsu2itqT36obG',474.5100),(41,'aaw','$2y$10$IolpsUYOp7ojwCY7rZCsE.GH4v5JWUlLfkCFnIUjiZaP1aT9mBRti',10000.0000);
/*!40000 ALTER TABLE `users` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2017-03-25  3:45:29
