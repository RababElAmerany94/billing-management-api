using Microsoft.EntityFrameworkCore.Migrations;

namespace COMPANY.Presistence.Migrations
{
    public partial class RemoveProcedureFacturesArticles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP PROCEDURE IF EXISTS `GetFacturesArticlesByCategory`");
            migrationBuilder.Sql(@"DROP PROCEDURE IF EXISTS `GetFacturesArticlesQuantities`");
            migrationBuilder.Sql(@"DROP PROCEDURE IF EXISTS `GetFacturesArticlesTotals`");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
			migrationBuilder.Sql(@"
				CREATE PROCEDURE `GetFacturesArticlesByCategory`(
					`DateStart` DATE,
					`DateEnd` DATE,
					`ClientId` VARCHAR(255),
					`AgenceId` VARCHAR(255),
					`Status` VARCHAR(50)
				)
				BEGIN

					SET @FACTURECOUNT = 0;

					SET @SQLSTATEMENT = CONCAT(' FROM factures WHERE Type != 1 AND DATE(DateCreation)>=\'',DateStart,'\' AND DATE(DateCreation) <= \'',DateEnd,'\' AND Status in (',Status,')');

					IF LENGTH(AgenceId)  > 0 THEN 
						SET @SQLSTATEMENT = CONCAT(@SQLSTATEMENT,' AND AgenceId =\'', AgenceId,'\'');
					END IF;
    
					IF LENGTH(ClientId)  > 0 THEN 
						SET @SQLSTATEMENT = CONCAT(@SQLSTATEMENT,' AND ClientId =\'', ClientId,'\'');
					END IF;

					set @COUTSTATEMENT = CONCAT('select count(*) INTO @FACTURECOUNT ',@SQLSTATEMENT);

					PREPARE stmt from @COUTSTATEMENT;
					EXECUTE stmt;
					DEALLOCATE PREPARE stmt;

					DROP TEMPORARY TABLE IF EXISTS `CategoryTmp`;
					CREATE TEMPORARY TABLE IF NOT EXISTS `CategoryTmp` (`Id` int primary key auto_increment,  `Name` varchar(255), `Total` decimal);

					SET @i = 0;

					WHILE @i < @FACTURECOUNT DO

						SET @ARTICLES = '';
						SET @SQLSELECTSTATEMENT = CONCAT('SELECT Articles INTO @ARTICLES ', @SQLSTATEMENT, ' LIMIT ',@i,',1');

						PREPARE stmt from @SQLSELECTSTATEMENT;
						EXECUTE stmt;
						DEALLOCATE PREPARE stmt;

						SET @COUTARTICLES = JSON_LENGTH(@ARTICLES);
		
						SET @j = 0;
						WHILE @j < @COUTARTICLES DO
							INSERT INTO `CategoryTmp` (`Name`,`Total`) VALUES (REPLACE(JSON_EXTRACT(@ARTICLES, CONCAT('$[',@j, '].category.name')),'" + '"' + @"',''),JSON_EXTRACT(@ARTICLES, CONCAT('$[',@j, '].totalHT')));
							SET @j := @j + 1;
							END WHILE;

							SET @i = @i + 1;

							END WHILE;

							SELECT Name, SUM(Total) as Total from CategoryTmp where Total > 0 group by Name;

							DROP TEMPORARY TABLE if EXISTS `CategoryTmp`;

					END");

			migrationBuilder.Sql(@"
				CREATE PROCEDURE `GetFacturesArticlesQuantities`(
					`DateStart` DATE,
					`DateEnd` DATE,
					`ClientId` VARCHAR(255),
					`AgenceId` VARCHAR(255),
					`Status` VARCHAR(50)
				)
				BEGIN

					SET @FACTURECOUNT = 0;

					SET @SQLSTATEMENT = CONCAT(' FROM factures WHERE Type != 1 AND DATE(DateCreation)>=\'',DateStart,'\' AND DATE(DateCreation) <= \'',DateEnd,'\' AND Status in (',Status,')');

					IF LENGTH(AgenceId) > 0 THEN 
						SET @SQLSTATEMENT = CONCAT(@SQLSTATEMENT,' AND AgenceId =\'', AgenceId,'\'');
					END IF;
    
					IF LENGTH(ClientId) > 0 THEN 
						SET @SQLSTATEMENT = CONCAT(@SQLSTATEMENT,' AND ClientId =\'', ClientId,'\'');
					END IF;

					set @COUTSTATEMENT = CONCAT('select count(*) INTO @FACTURECOUNT ',@SQLSTATEMENT);

					PREPARE stmt from @COUTSTATEMENT;
					EXECUTE stmt;
					DEALLOCATE PREPARE stmt;

					DROP TEMPORARY TABLE IF EXISTS `ArticlesTmp`;
					CREATE TEMPORARY TABLE IF NOT EXISTS `ArticlesTmp` (`Id` int primary key auto_increment,  `Name` varchar(255), `Qte` double);

					SET @i = 0;

					WHILE @i < @FACTURECOUNT DO

						SET @ARTICLES = '';
						SET @SQLSELECTSTATEMENT = CONCAT('SELECT Articles INTO @ARTICLES ', @SQLSTATEMENT, ' LIMIT ',@i,',1');

						PREPARE stmt from @SQLSELECTSTATEMENT;
						EXECUTE stmt;
						DEALLOCATE PREPARE stmt;

						SET @COUTARTICLES = JSON_LENGTH(@ARTICLES);
		
						SET @j = 0;
						WHILE @j < @COUTARTICLES DO
							INSERT INTO `ArticlesTmp` (`Name`,`Qte`) VALUES (REPLACE(JSON_EXTRACT(@ARTICLES, CONCAT('$[',@j, '].designation')),'" + '"' + @"',''),JSON_EXTRACT(@ARTICLES, CONCAT('$[',@j, '].qte')));
							SET @j := @j + 1;
							END WHILE;

							SET @i = @i + 1;

							END WHILE;

							SELECT Name, SUM(Qte) as Quantity from ArticlesTmp  where Qte > 0 group by Name;

							DROP TEMPORARY TABLE if EXISTS `ArticlesTmp`;

						END
			");


			migrationBuilder.Sql(@"
				CREATE PROCEDURE `GetFacturesArticlesTotals`(
					`DateStart` DATE,
					`DateEnd` DATE,
					`ClientId` VARCHAR(255),
					`AgenceId` VARCHAR(255),
					`Status` VARCHAR(50)
				)
				BEGIN

					SET @FACTURECOUNT = 0;

					SET @SQLSTATEMENT = CONCAT(' FROM factures WHERE Type != 1 AND DATE(DateCreation)>=\'',DateStart,'\' AND DATE(DateCreation) <= \'',DateEnd,'\' AND Status in (',Status,')');

					IF LENGTH(AgenceId) > 0 THEN 
						SET @SQLSTATEMENT = CONCAT(@SQLSTATEMENT,' AND AgenceId =\'', AgenceId,'\'');
					END IF;
    
					IF LENGTH(ClientId) > 0 THEN 
						SET @SQLSTATEMENT = CONCAT(@SQLSTATEMENT,' AND ClientId =\'', ClientId,'\'');
					END IF;

					set @COUTSTATEMENT = CONCAT('select count(*) INTO @FACTURECOUNT ',@SQLSTATEMENT);

					PREPARE stmt from @COUTSTATEMENT;
					EXECUTE stmt;
					DEALLOCATE PREPARE stmt;

					DROP TEMPORARY TABLE IF EXISTS `ArticlesTmp`;
					CREATE TEMPORARY TABLE IF NOT EXISTS `ArticlesTmp` (`Id` int primary key auto_increment,  `Name` varchar(255), `Total` decimal);

					SET @i = 0;

					WHILE @i < @FACTURECOUNT DO

						SET @ARTICLES = '';
						SET @SQLSELECTSTATEMENT = CONCAT('SELECT Articles INTO @ARTICLES ', @SQLSTATEMENT, ' LIMIT ',@i,',1');

						PREPARE stmt from @SQLSELECTSTATEMENT;
						EXECUTE stmt;
						DEALLOCATE PREPARE stmt;

						SET @COUTARTICLES = JSON_LENGTH(@ARTICLES);
		
						SET @j = 0;
						WHILE @j < @COUTARTICLES DO
							INSERT INTO `ArticlesTmp` (`Name`,`Total`) VALUES (REPLACE(JSON_EXTRACT(@ARTICLES, CONCAT('$[',@j, '].designation')),'" + '"' + @"',''),JSON_EXTRACT(@ARTICLES, CONCAT('$[',@j, '].totalHT')));
							SET @j := @j + 1;
							END WHILE;

							SET @i = @i + 1;

							END WHILE;

							SELECT Name, SUM(Total) as Total from ArticlesTmp where Total > 0 group by Name;

							DROP TEMPORARY TABLE if EXISTS `ArticlesTmp`;

						END
			");
		}
    }
}
