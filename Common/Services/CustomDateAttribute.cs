using System;
using System.ComponentModel.DataAnnotations;

namespace Common
{
    public class CustomDateAttribute : RangeAttribute
    {
        public CustomDateAttribute()
            : base(typeof(DateTime),
                DateTime.Now.ToShortDateString(),
                DateTime.Now.AddYears(1).ToShortDateString())
        {
        }
    }
}