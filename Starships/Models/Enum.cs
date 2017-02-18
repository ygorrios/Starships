using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static Starships.Models.EnumerableExtensions;

namespace Starships.Models
{
    public enum Dias
    {
        [StringValue("Years")]
        [StringDescription("365")]
        year = 365,
        [StringValue("Years")]
        [StringDescription("365")]
        years = 365,
        [StringValue("Month")]
        [StringDescription("30")]
        month = 30,
        [StringValue("Months")]
        [StringDescription("30")]
        months = 30,
        [StringValue("Week")]
        [StringDescription("7")]
        week = 7,
        [StringValue("Weeks")]
        [StringDescription("7")]
        weeks = 7,
        [StringValue("Day")]
        [StringDescription("1")]
        day = 1,
        [StringValue("Days")]
        [StringDescription("1")]
        days = 1
    }
}