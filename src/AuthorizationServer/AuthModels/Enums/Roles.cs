using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthModels.Enums
{
    public enum Roles
    {
        [Description("User")]
        User,
        [Description("Admin")]
        Admin
    }
}
