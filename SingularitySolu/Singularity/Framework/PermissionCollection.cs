using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Singularity.Framework
{
    public class PermissionCollection
    {
        public sealed class HR_User
        {
            public const int CanView = 1001;
            public const int CanAdd = 1002;
            public const int CanEdit = 1003;
            public const int CanDelete = 1004;
        }
    }
}