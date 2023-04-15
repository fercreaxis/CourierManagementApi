using System;
using System.ComponentModel.DataAnnotations;

namespace CourierManagementAPI.Models.Shared
{
    public class JsonResult
    {
        [Key]
        public Guid id { get; set; }
        public string result { get; set; }

    }
}
