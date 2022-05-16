
DROP TABLE IF EXISTS `tb_ADN`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tb_ADN` (
  `id` int NOT NULL AUTO_INCREMENT,
  `CadenaADN` varchar(500) DEFAULT NULL,
  `EsMutante` tinyint(1) DEFAULT NULL,
  `Descripcion_Not_Mutante` varchar(200) DEFAULT NULL,
  PRIMARY KEY (`id`)
);
/*!40101 SET character_set_client = @saved_cs_client */;


CREATE VIEW `vw_stats` AS
    SELECT 
        `sub`.`count_mutant_dna` AS `count_mutant_dna`,
        `sub`.`count_human_dna` AS `count_human_dna`,
        ROUND((`sub`.`count_mutant_dna` / `sub`.`count_human_dna`),
                1) AS `ratio`
    FROM
        (SELECT 
            COUNT((CASE
                    WHEN (`tb_ADN`.`EsMutante` = TRUE) THEN 1
                END)) AS `count_mutant_dna`,
                COUNT((CASE
                    WHEN (`tb_ADN`.`EsMutante` = FALSE) THEN 1
                END)) AS `count_human_dna`
        FROM
            `db_a86fc5_mutants`.`tb_ADN`) `sub`