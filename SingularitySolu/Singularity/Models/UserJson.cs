using Singularity.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Singularity.Models
{
    public class UserJson
    {
        public UserJson()
        {
            Role= new RoleJson();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public string VerificationCode { get; set; }
        public System.DateTime CreateDate { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
        public int CreateBy { get; set; }
        public Nullable<int> UpdateBy { get; set; }
        public bool Status { get; set; }
        public string Remark { get; set; }
        public string History { get; set; }
        public bool IsDeleted { get; set; }

        public RoleJson Role { get; set; }


       

    }
}