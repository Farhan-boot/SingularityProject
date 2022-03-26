using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Singularity.Models
{
    public class SettingsJson
    {
        public int Id { get; set; }
        public Nullable<int> UserId { get; set; }
        public Nullable<bool> CanView { get; set; }
        public Nullable<bool> CanAdd { get; set; }
        public Nullable<bool> CanEdit { get; set; }
        public Nullable<bool> CanDelete { get; set; }
    }
}