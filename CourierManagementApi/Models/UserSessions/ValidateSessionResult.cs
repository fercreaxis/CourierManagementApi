﻿using System;
using System.ComponentModel.DataAnnotations;

namespace CourierManagementAPI.Models.UserSessions
{
    public class ValidateSessionResult
    {
        [Key]
        public Guid id { get; set; }
        public int code { get; set; }
        public string message { get; set; }
    }
}
