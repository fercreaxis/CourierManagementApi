using System;
using System.ComponentModel.DataAnnotations;

namespace ApproveX_API.Models.Shared
{
    public class JsonResult
    {
        [Key]
        public Guid id { get; set; }
        public string result { get; set; }

    }
}
