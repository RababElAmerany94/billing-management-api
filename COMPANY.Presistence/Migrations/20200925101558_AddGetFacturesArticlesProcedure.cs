using Microsoft.EntityFrameworkCore.Migrations;

namespace COMPANY.Presistence.Migrations
{
    public partial class AddGetFacturesArticlesProcedure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
CREATE PROCEDURE `GetArticlesFactures`(
	IN `DateStart` DATE,
	IN `DateEnd` DATE,
	IN `InAgencesData` BOOL,
	IN `ClientId` varchar(256),
	IN `UserId` varchar(256),
	IN `AgenceId` varchar(256),
	IN `Status` VARCHAR(50)
)
BEGIN
	DECLARE ARTICLES LONGTEXT DEFAULT '';
	SET @FACTURECOUNT = 0;
    SET @SQLSTATEMENT = '';
    
    IF LENGTH(UserId) > 0 THEN
		SET @SQLSTATEMENT = CONCAT(' FROM Factures 
						INNER JOIN FactureDevis on Factures.Id = FactureDevis.FactureId
						INNER JOIN Devis on Devis.Id = FactureDevis.DevisId and Devis.UserId=\'', UserId ,'\' ');
    ELSE
		SET @SQLSTATEMENT = CONCAT(' FROM Factures ');
    END IF;
    
	SET @SQLSTATEMENT = CONCAT(@SQLSTATEMENT,' WHERE Factures.Type != 1 && Factures.Status in (', Status, ') ');

	IF DateStart IS NOT NULL THEN
		SET @SQLSTATEMENT = CONCAT(@SQLSTATEMENT,' AND DATE(Factures.DateCreation)>=\'', DateStart,'\' ');
    END IF;
    
    IF DateEnd IS NOT NULL THEN
		SET @SQLSTATEMENT = CONCAT(@SQLSTATEMENT,' AND DATE(Factures.DateCreation) <=\'', DateEnd,'\' ');
    END IF;

	IF InAgencesData THEN
		SET @SQLSTATEMENT = CONCAT(@SQLSTATEMENT,' AND Factures.AgenceId is not null ');
		IF LENGTH(AgenceId) > 0 THEN 
			SET @SQLSTATEMENT = CONCAT(@SQLSTATEMENT,' AND Factures.AgenceId =\'', AgenceId,'\'');
		END IF;
	ELSE
		SET @SQLSTATEMENT = CONCAT(@SQLSTATEMENT,' AND Factures.AgenceId is null ');
	END IF;

	IF LENGTH(ClientId) > 0 THEN
		SET @SQLSTATEMENT = CONCAT(@SQLSTATEMENT,' AND Factures.ClientId=\'',ClientId,'\'');
	END IF;
	
	SET @COUTSTATEMENT = CONCAT('SELECT COUNT(DISTINCT(Factures.Articles)) INTO @FACTURECOUNT ', @SQLSTATEMENT);

	PREPARE stmt FROM @COUTSTATEMENT;
	EXECUTE stmt;
	DEALLOCATE PREPARE stmt;

	SET @i = 0;
	SET @FIRST = TRUE;

	WHILE @i < @FACTURECOUNT DO

		SET @ARTICLESTMP = '';
		SET @SQLSELECTSTATEMENT = CONCAT('SELECT DISTINCT(Factures.Id), SUBSTRING( JSON_COMPACT(Factures.Articles), 2, (CHARACTER_LENGTH(JSON_COMPACT(Factures.Articles))-2) ) as Articles ', @SQLSTATEMENT, ' LIMIT ', @i, ',90');
		SET @SQLSELECTSTATEMENT = CONCAT('SELECT GROUP_CONCAT(sub.Articles) INTO @ARTICLESTMP FROM (', @SQLSELECTSTATEMENT,') as sub');

		PREPARE stmt FROM @SQLSELECTSTATEMENT;
		EXECUTE stmt;
		DEALLOCATE PREPARE stmt;

		IF @FIRST THEN
			SET @ARTICLES = @ARTICLESTMP;
			SET @FIRST = FALSE;
		ELSE
			SET @ARTICLES = CONCAT_WS(',',@ARTICLES,@ARTICLESTMP);
		END IF;

		SET @i := @i + 90;
	END WHILE;

	SELECT CONCAT('[',@ARTICLES,']') AS Articles;

END");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP PROCEDURE IF EXISTS `GetArticlesFactures`");
        }
    }
}
