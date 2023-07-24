using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthModels.Authorization
{
    public interface IPermissionAccess
    {
        public int GetUserId();
    }
}
