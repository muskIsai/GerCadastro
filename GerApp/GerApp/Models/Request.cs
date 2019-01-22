﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GerApp.Models
{
    public class Request
    {
        public int RequestID { get; set; }
        public DateTime RequestDate { get; set; }

        public RequestStatus Status { get; set; }
        
    }
    public enum RequestStatus
    {
        Submitted,
        Approved,
        Rejected,
    }
}