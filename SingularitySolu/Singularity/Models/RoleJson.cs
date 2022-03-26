using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Singularity.Models
{
    public class RoleJson
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public System.DateTime CreateDate { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
        public int CreateBy { get; set; }
        public Nullable<int> UpdateBy { get; set; }
        public bool Status { get; set; }
    }
}