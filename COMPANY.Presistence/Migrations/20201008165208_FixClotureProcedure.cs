using Microsoft.EntityFrameworkCore.Migrations;

namespace COMPANY.Presistence.Migrations
{
    public partial class FixClotureProcedure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
			migrationBuilder.Sql("DROP PROCEDURE IF EXISTS `ClotureComptable`");
			migrationBuilder.Sql(@"CREATE PROCEDURE `ClotureComptable`(
	IN `dateStart` DATE,
	IN `dateEnd` DATE,
	IN `_agenceId` varchar(256)
)
BEGIN

	SET SQL_SAFE_UPDATES = 0;
	SET @ROWCOUNT = 0;

	IF length(_agenceId) > 0  then
		-- factures
		UPDATE Factures SET Comptabilise = 1 WHERE DATE(DateCreation) >= DATE(dateStart) AND DATE(DateCreation) <= DATE(dateEnd) AND AgenceId = _agenceId;
		set @ROWCOUNT=@ROWCOUNT+ROW_COUNT();
		-- avoirs
		UPDATE Avoirs SET Comptabilise = 1 WHERE DATE(DateCreation) >= DATE(dateStart) AND DATE(DateCreation) <= DATE(dateEnd)  AND AgenceId = _agenceId;
		set @ROWCOUNT=@ROWCOUNT+ROW_COUNT();
		-- paiements
		UPDATE Paiements SET Comptabilise = 1 WHERE DATE(DatePaiement) >= DATE(dateStart) AND DATE(DatePaiement) <= DATE(dateEnd)  AND AgenceId = _agenceId;
		set @ROWCOUNT=@ROWCOUNT+ROW_COUNT();
	ELSE 
		set @ROWCOUNT=@ROWCOUNT+ROW_COUNT();
		-- factures
		UPDATE Factures SET Comptabilise = 1 WHERE DATE(DateCreation) >= DATE(dateStart) AND DATE(DateCreation) <= DATE(dateEnd) AND AgenceId is null;
		set @ROWCOUNT=@ROWCOUNT+ROW_COUNT();
		-- avoirs
		UPDATE Avoirs SET Comptabilise = 1 WHERE DATE(DateCreation) >= DATE(dateStart) AND DATE(DateCreation) <= DATE(dateEnd)  AND AgenceId is null;
		set @ROWCOUNT=@ROWCOUNT+ROW_COUNT();
		-- paiements
		UPDATE Paiements SET Comptabilise = 1 WHERE DATE(DatePaiement) >= DATE(dateStart) AND DATE(DatePaiement) <= DATE(dateEnd)  AND AgenceId is null;
		set @ROWCOUNT=@ROWCOUNT+ROW_COUNT();
	END IF;

	SELECT @ROWCOUNT as `RowEffected`;
END");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
			migrationBuilder.Sql("DROP PROCEDURE IF EXISTS `ClotureComptable`");
			migrationBuilder.Sql(@"
                CREATE PROCEDURE `ClotureComptable`(
					`dateStart` DATE,
					`dateEnd` DATE,
					`_agenceId` varchar(256)
				)
				BEGIN

					SET SQL_SAFE_UPDATES = 0;
					SET @ROWCOUNT = 0;

					IF length(_agenceId) > 0  then
						-- factures
						UPDATE Factures SET Comptabilise = 1 WHERE DATE(DateCreation) >= DATE(dateStart) AND DATE(DateCreation) <= DATE(dateEnd) AND AgenceId = _agenceId;
						set @ROWCOUNT=@ROWCOUNT+ROW_COUNT();
						-- avoirs
						UPDATE Avoirs SET Comptabilise = 1 WHERE DATE(DateCreation) >= DATE(dateStart) AND DATE(DateCreation) <= DATE(dateEnd)  AND AgenceId = _agenceId;
						set @ROWCOUNT=@ROWCOUNT+ROW_COUNT();
						-- paiements
						UPDATE Paiements SET Comptabilise = 1 WHERE DATE(DatePaiment) >= DATE(dateStart) AND DATE(DatePaiment) <= DATE(dateEnd)  AND AgenceId = _agenceId;
						set @ROWCOUNT=@ROWCOUNT+ROW_COUNT();
					ELSE 
						set @ROWCOUNT=@ROWCOUNT+ROW_COUNT();
						-- factures
						UPDATE Factures SET Comptabilise = 1 WHERE DATE(DateCreation) >= DATE(dateStart) AND DATE(DateCreation) <= DATE(dateEnd) AND AgenceId is null;
						set @ROWCOUNT=@ROWCOUNT+ROW_COUNT();
						-- avoirs
						UPDATE Avoirs SET Comptabilise = 1 WHERE DATE(DateCreation) >= DATE(dateStart) AND DATE(DateCreation) <= DATE(dateEnd)  AND AgenceId is null;
						set @ROWCOUNT=@ROWCOUNT+ROW_COUNT();
						-- paiements
						UPDATE Paiements SET Comptabilise = 1 WHERE DATE(DatePaiment) >= DATE(dateStart) AND DATE(DatePaiment) <= DATE(dateEnd)  AND AgenceId is null;
						set @ROWCOUNT=@ROWCOUNT+ROW_COUNT();
					END IF;

					SELECT @ROWCOUNT as `RowEffected`;
				END
            ");
		}
    }
}
