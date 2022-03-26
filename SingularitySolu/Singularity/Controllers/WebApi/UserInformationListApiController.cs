using Singularity.Data;
using Singularity.Framework;
using Singularity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;

namespace Singularity.Controllers.WebApi
{
    public class UserInformationListApiController : ApiController
    {
        [HttpGet]
        public HttpListResult<UserJson> GetUserList()
        {
            string error = string.Empty;
            var result = new HttpListResult<UserJson>();

            var userListJson = new List<UserJson>();

            using (SingularityDbContext db = new SingularityDbContext())
            {
                var user = db.HR_User.Include(x=>x.HR_Role).Where(x=>x.IsDeleted==false).ToList();

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
    }
}
