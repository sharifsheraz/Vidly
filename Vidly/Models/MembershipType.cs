﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class MembershipType
    {
        public byte ID { get; set; }
        public short SignUpFee { get; set; }
        public byte DurationInMonths { get; set; }
        public byte DiscountRate { get; set; }
        public String MembershipName { get; set; }
        public static readonly byte Unknown = 0;
        public static readonly byte PayAsYouGo = 1;

    }
}