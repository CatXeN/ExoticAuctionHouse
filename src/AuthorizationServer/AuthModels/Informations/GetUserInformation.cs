using AuthModels.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthModels.Informations
{
    public class GetUserInformation
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Attributes { get; set; }
        public Roles Role { get; set; }
    }
}
