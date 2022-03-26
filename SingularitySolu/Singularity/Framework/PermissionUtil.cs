using Singularity.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Singularity.Framework
{
    public class PermissionUtil
    {
        SingularityDbContext db = new SingularityDbContext();
        //public static bool HasPermission(int permissionNo, out string error)
        //{
        //    error = string.Empty;

        //    //if (HttpUtil.Profile == null)
        //    //{
        //    //    error = "Your session has been expired please login again.";
        //    //    return false;
        //    //}

        //    var query = db.HR_RolePremissionMap.Where(ur => ur.Id == 1).ToList().Select(ur => ur.RoleId);
        //    //from ur in db.UAC_RoleUserMap
        //    //where ur.UserId == HttpUtil.Profile.UserId
        //    //select ur.RoleId;

        //    var permissions =
        //        db.HR_RolePremissionMap.Where(rp => query.Contains(rp.RoleId) && rp.PermissionNo == permissionNo)
        //            .Select(rp => rp.PermissionNo);

        //    //from rp in db.UAC_RolePremissionMap
        //    //where query.Contains(rp.RoleId) && rp.PermissionNo == permissionNo
        //    //select rp.PermissionNo;

        //    var hasPermission = permissions.Any();

        //    if (!hasPermission)
        //    {
        //        error = "Sorry, you are not permitted to do this task.";
        //        return false;
        //    }
        //    return true;
        //}
    }
}