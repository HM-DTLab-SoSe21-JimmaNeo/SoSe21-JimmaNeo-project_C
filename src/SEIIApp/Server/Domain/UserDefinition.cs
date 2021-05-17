using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SEIIApp.Server.Domain
{
    public class UserDefinition
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public LoginCredentialsDefinition LoginCredentials { get; set; }

    }
    
}
