﻿using HRLeaveManagement.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRLeaveManagement.Application.DTOs
{
    public class LeaveTypeDto
    {
        public string Name { get; set; } = String.Empty;
        public int DefaultDays { get; set; }
    }
}
