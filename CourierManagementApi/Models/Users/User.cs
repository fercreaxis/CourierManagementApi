using System;
using System.ComponentModel.DataAnnotations;

namespace ApproveX_API.Models.Users
{
    public class User
    {
        [Key]
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public int roleId { get; set; }
        public int roleEntityId { get; set; }
        public string roleEntityName { get; set; }
        public string passwordSalt { get; set; }
        public DateTime lastLoginDate { get; set; }
        public DateTime lastPasswordChangedDate { get; set; }
        public DateTime createdDate { get; set; }
        public DateTime lastUpdateDate { get; set; }
        public bool isLocked { get; set; }
        public int failedLoginAttemptsCount { get; set; }
        public bool active { get; set; }
        #nullable enable
        public string? sessionId { get; set; }
        public string? authToken { get; set; }
        public string? roleName { get; set; }



        /*
         * 
            username	varchar
            password	varchar
            passwordSalt	varchar
            firstName	varchar
            lastName	varchar
            roleId	int
            roleEntityId	int
            lastLogin	datetime
            lastPasswordChangedDate	datetime
            createdDate	datetime
            lastUpdatedDate	datetime
            isLocked	bit
            failedLoginAttemptsCount	int
            active	int
         * 
         */

    }
}
