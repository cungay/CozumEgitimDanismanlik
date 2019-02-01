

#region Using Directives
using System;
using System.ComponentModel;
using System.Collections;
using System.Xml.Serialization;
using System.Data;

using Ekip.Framework.Entities;
using Ekip.Framework.Entities.Validation;

using Ekip.Framework.Data;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using System.Linq;

#endregion

namespace Ekip.Framework.Services
{
    /// <summary>
    /// An component type implementation of the 'CalendarAge' table.
    /// </summary>
    /// <remarks>
    /// All custom implementations should be done here.
    /// </remarks>
    [CLSCompliant(true)]
    public partial class CalendarAgeService : Ekip.Framework.Services.CalendarAgeServiceBase
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the CalendarAgeService class.
        /// </summary>
        public CalendarAgeService() : base()
        {
        }

        #endregion Constructors

        public CalendarAge CalcCalendarAge(DateTime birthDate, DateTime reference)
        {
            CalendarAge calendarAge = null;
            int years = 0;
            int months = 0;
            int days = 0;

            if ((reference.Year - birthDate.Year) > 0 ||
                (((reference.Year - birthDate.Year) == 0) && ((birthDate.Month < reference.Month) ||
                  ((birthDate.Month == reference.Month) && (birthDate.Day <= reference.Day)))))
            {
                int DaysInBdayMonth = DateTime.DaysInMonth(birthDate.Year, birthDate.Month);
                int DaysRemain = reference.Day + (DaysInBdayMonth - birthDate.Day);

                if (reference.Month > birthDate.Month)
                {
                    years = reference.Year - birthDate.Year;
                    months = reference.Month - (birthDate.Month + 1) + Math.Abs(DaysRemain / DaysInBdayMonth);
                    days = (DaysRemain % DaysInBdayMonth + DaysInBdayMonth) % DaysInBdayMonth;
                }
                else if (reference.Month == birthDate.Month)
                {
                    if (reference.Day >= birthDate.Day)
                    {
                        years = reference.Year - birthDate.Year;
                        months = 0;
                        days = reference.Day - birthDate.Day;
                    }
                    else
                    {
                        years = (reference.Year - 1) - birthDate.Year;
                        months = 11;
                        days = DateTime.DaysInMonth(birthDate.Year, birthDate.Month) - (birthDate.Day - reference.Day);
                    }
                }
                else
                {
                    years = (reference.Year - 1) - birthDate.Year;
                    months = reference.Month + (11 - birthDate.Month) + Math.Abs(DaysRemain / DaysInBdayMonth);
                    days = (DaysRemain % DaysInBdayMonth + DaysInBdayMonth) % DaysInBdayMonth;
                }

                calendarAge = GetByYearAndMonth(years, months).FirstOrDefault();

                if (calendarAge != null)
                {
                    calendarAge.Years = years;
                    calendarAge.Months = months;
                    calendarAge.Days = days;
                }
            }
            return calendarAge;
        }
    }
}
