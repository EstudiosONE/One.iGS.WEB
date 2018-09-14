﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace One.iGS.API.Models.Common
{
    public class PeopleAddress
    {
        public string AddressType { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string DoorNumber { get; set; }
        public string Description { get; set; }
    }
}