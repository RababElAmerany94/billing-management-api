namespace COMPANY.Application.Utilities
{
    using COMPANY.Application.DataInteraction.DataAccess;
    using COMPANY.Application.Enums;
    using System;
    using System.Threading.Tasks;

    public static class DateExtension
    {

        /// <summary>
        /// get range of date from period enum
        /// </summary>
        /// <param name="periodeComptableDataAccess">the period comptable data access</param>
        /// <param name="agenceId">the id of agence</param>
        /// <param name="period">the period enumeration</param>
        /// <param name="dateFrom">the date from</param>
        /// <param name="dateTo">the date to</param>
        /// <returns>date from and date to</returns>
        public static async Task<(DateTime? dateFrom, DateTime? dateTo)> GetDateRangeFromPeriodEnum(
            this IPeriodeComptableDataAccess periodeComptableDataAccess,
            string agenceId,
            Period period,
            DateTime? dateFrom,
            DateTime? dateTo)
        {
            var firstDayOfMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);

            switch (period)
            {
                case Period.Interval:
                    return (dateFrom, dateTo);

                case Period.CurrentMonth:
                    return (firstDayOfMonth,
                            new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month)));

                case Period.LastThreeMonths:
                    return (firstDayOfMonth.AddMonths(-3), firstDayOfMonth);

                case Period.LastSixMonths:
                    return (firstDayOfMonth.AddMonths(-6), firstDayOfMonth);

                case Period.CurrentYear:
                    return (new DateTime(DateTime.Now.Year, 01, 01),
                            new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, 12)));

                case Period.LastYear:
                    return (new DateTime(DateTime.Now.Year - 1, 01, 01),
                            new DateTime(DateTime.Now.Year - 1, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year - 1, 12)));

                case Period.CurrentAccountingYear:
                    var currentAccountingPeriod = await periodeComptableDataAccess.GetCurrentPeriodeComptableAsync(agenceId);

                    if (currentAccountingPeriod is null)
                        return (
                            new DateTime(DateTime.Now.Year, 1, 1),
                            new DateTime(DateTime.Now.Year, 12, 31)
                       );
                    else
                        return (
                            currentAccountingPeriod.DateDebut,
                            currentAccountingPeriod.DateDebut.AddMonths(currentAccountingPeriod.Period)
                        );

                case Period.All:
                default:
                    return (default, default);
            }
        }
    }
}
