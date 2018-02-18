﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prj_Soap.Service
{
    public class LocalDateTimeService
    {
        public static string CHINA_STANDARD_TIME = "China Standard Time";
        public LocalDateTimeService()
        {

        }
        public DateTime GetLocalDateTime(string location)
        {
            var localTime = DateTime.Now;
            TimeZoneInfo destTz =
            TimeZoneInfo.FindSystemTimeZoneById(location);
            var datetime = TimeZoneInfo.ConvertTime(localTime, TimeZoneInfo.Local, destTz);
            return datetime;
        }
    }
}