using Singularity.Data;
using Singularity.Framework;
using Singularity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Singularity.Controllers.WebApi
{
    public class SettingsApiController : ApiController
    {
        [HttpGet]
        public HttpResult<SettingsJson> GetSettings()
        {
            string error = string.Empty;
            var result = new HttpResult<SettingsJson>();
            var userListJson = new List<SettingsJson>();
            using (SingularityDbContext db = new SingularityDbContext())
            {
                var sett = db.HR_Settings.FirstOrDefault();
                if (sett!=null)
                {
                    SettingsJson settingsJson = new SettingsJson();
                    settingsJson.Id = sett.Id;
                    settingsJson.UserId = sett.UserId;
                    settingsJson.CanView = sett.CanView;
                    settingsJson.CanAdd = sett.CanAdd;
                    settingsJson.CanEdit = sett.CanEdit;
                    settingsJson.CanDelete = sett.CanDelete;
                    result.Data = settingsJson;
                }
                else
                {
                    SettingsJson settingsJson = new SettingsJson();
                    settingsJson.Id = 0;
                    settingsJson.UserId = 0;
                    settingsJson.CanView = true;
                    settingsJson.CanAdd = true;
                    settingsJson.CanEdit = true;
                    settingsJson.CanDelete = true;
                    result.Data = settingsJson;
                }
            }
            return result;
        }


        [HttpPost]
        public HttpResult<SettingsJson> SaveSettings(SettingsJson json)
        {
            string error = string.Empty;
            var result = new HttpResult<SettingsJson>();

            using (SingularityDbContext db = new SingularityDbContext())
            {
                var Setting = db.HR_Settings.FirstOrDefault();
                if (Setting != null)
                {
                    Setting.CanView = json.CanView;
                    Setting.CanAdd = json.CanAdd;
                    Setting.CanEdit = json.CanEdit;
                    Setting.CanDelete = json.CanDelete;
                    db.SaveChanges();
                }
                else
                {
                    var obj = new HR_Settings();
                    obj.UserId = json.UserId;
                    obj.CanView = true;
                    obj.CanAdd = true;
                    obj.CanEdit = true;
                    obj.CanDelete = true;
                    db.HR_Settings.Add(obj);
                    db.SaveChanges();
                }

            }
            return result;
        }






    }
}
