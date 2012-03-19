// $Date:  $
// $Revision:  $

using System;

namespace VCalendar
{
    /// <summary>Days of the week</summary>
    [Flags]
    public enum DaysOfWeek
    {
        /// <summary>Flag value indicating Sunday.</summary>
        Sunday = 1,

        /// <summary>Flag value indicating Monday.</summary>
        Monday = 2,

        /// <summary>Flag value indicating Tuesday.</summary>
        Tuesday = 4,

        /// <summary>Flag value indicating Wednesday.</summary>
        Wednesday = 8,

        /// <summary>Flag value indicating Thursday.</summary>
        Thursday = 16,

        /// <summary>Flag value indicating Friday.</summary>
        Friday = 32,

        /// <summary>Flag value indicating Saturday.</summary>
        Saturday = 64
    }
}
