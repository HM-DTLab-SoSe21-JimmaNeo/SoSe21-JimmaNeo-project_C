using System;
using System.Collections.Generic;
using SEIIApp.Shared.Moduldto;

namespace SEIIApp.Shared
{
    public class UserDto
    {
        public String UserID { get; set; }
        public String SurName { get; set; }
        public String LastName { get; set; }
        public String UserName { get; set; }
        public String Email { get; set; }
        public DateTime RegisterDate { get; set; }
        public List<ModulDto> Modules { get; set; }

        public UserDto()
        {
            UserID = "0";
            SurName = "Max";
            LastName = "Mustermann";
            UserName = "maxmuster";
            Email = "max@musermann.de";
            RegisterDate = DateTime.Now;
        }
    }
}