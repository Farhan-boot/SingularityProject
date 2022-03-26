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
    public class RecoveryApiController : ApiController
    {
        [HttpGet]
        public HttpListResult<UserJson> GetDeleteUserList()
        {
            string error = string.Empty;
            var result = new HttpListResult<UserJson>();

            var userListJson = new List<UserJson>();

            using (SingularityDbContext db = new SingularityDbContext())
            {
                var user = db.HR_User.Where(x => x.IsDeleted == true).ToList();

                foreach (var u in user)
                {
                    UserJson userJson = new UserJson();
                    userJson.Id = u.Id;
                    userJson.FirstName = u.FirstName;
                    userJson.LastName = u.LastName;
                    userJson.Email = u.Email;
                    userJson.Password = u.Password;
                    userJson.Role.Name = u.HR_Role.Name.ToString();

                    userListJson.Add(userJson);
                }
                result.Data = userListJson;
            }

            return result;
        }



        [HttpPost]
        public HttpResult<UserJson> UndoUser(UserJson user) {

            var result = new HttpResult<UserJson>();
            using (SingularityDbContext db = new SingularityDbContext())
            {
                var undoUser = db.HR_User.SingleOrDefault(x => x.Id == user.Id);
                undoUser.IsDeleted = false;
                db.SaveChanges();
                result.HasError = false;
            }
            return result;
        }

    }
}
