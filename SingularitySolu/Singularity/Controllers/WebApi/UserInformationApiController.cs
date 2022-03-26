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
    public class UserInformationApiController : ApiController
    {
        [HttpPost]
        public HttpResult<UserJson> AddOrEditUser(UserJson json)
        {
            string error = string.Empty;
            var result = new HttpResult<UserJson>();
            try
            {
                if (IsValidToSaveUser(json, out error))
                {
                    using (SingularityDbContext db = new SingularityDbContext())
                    {
                        if (json.Id==0)
                        {
                            HR_User hr_user = new HR_User();
                            //hr_user.Id = json.Id;
                            hr_user.Email = json.Email;
                            hr_user.FirstName = json.FirstName;
                            hr_user.LastName = json.LastName;
                            hr_user.Password = json.Password;
                            hr_user.RoleId = json.RoleId;
                            hr_user.VerificationCode = json.VerificationCode;
                            hr_user.CreateDate = DateTime.Now;
                            hr_user.UpdateDate = DateTime.Now;
                            hr_user.CreateBy = 0;
                            hr_user.UpdateBy = 0;
                            hr_user.Status = true;
                            hr_user.Remark = "";
                            hr_user.History = "";
                            hr_user.IsDeleted = false;
                            db.HR_User.Add(hr_user);
                            db.SaveChanges();
                            result.Errors.Add("Saved Successfully ");
                        }
                        else
                        {
                            var updateUser = db.HR_User.SingleOrDefault(x => x.Id == json.Id);
                            updateUser.History ="First Name: "+ updateUser.FirstName +", "
                                                +"Last Name: "+ updateUser.LastName + ", "
                                                + "Email: " + updateUser.Email + ", "
                                                + "Password: " + updateUser.Password + ", "
                                                + "Role: " + updateUser.HR_Role.Name + ", ";
                            updateUser.Email=json.Email;
                            updateUser.FirstName = json.FirstName;
                            updateUser.LastName = json.LastName;
                            updateUser.Password = json.Password;
                            updateUser.RoleId = json.RoleId;
                            updateUser.VerificationCode = json.VerificationCode;
                            updateUser.CreateDate = DateTime.Now;
                            updateUser.UpdateDate = DateTime.Now;
                            updateUser.CreateBy = 0;
                            updateUser.UpdateBy = 0;
                            updateUser.Status = true;
                            updateUser.Remark = "";
                            updateUser.IsDeleted = false;
                            db.SaveChanges();
                            result.Errors.Add("Update Successfully ");
                        }
                    }
                    result.HasError = false;
                    result.Errors.Add(error);
                    result.Data = json;
                }
                else
                {
                    result.HasError = true;
                    result.Errors.Add(error);
                    result.Data = json;
                }

            }

            catch (Exception ex)
            {

            }
            return result;
        }
        //local method should be private 
        private bool IsValidToSaveUser(UserJson newObj, out string error)
        {
            error = "";
            if (newObj.FirstName == null || newObj.FirstName == "")
            {
                error += "First Name is not valid.";
                return false;
            }
            if (newObj.LastName == null || newObj.LastName == "")
            {
                error += "Last Name is not valid.";
                return false;
            }
            if (newObj.Email == null || newObj.Email == "")
            {
                error += "Email is not valid.";
                return false;
            }
            if (newObj.Password == null || newObj.Password == "")
            {
                error += "Password is not valid.";
                return false;
            }
            if (newObj.RoleId == 0)
            {
                error += "Role is not valid.";
                return false;
            }

            return true;
        }

        [HttpGet]
        public HttpResult<UserJson> GetUserById(int id)
        {
            string error = string.Empty;
            var result = new HttpResult<UserJson>();

            using (SingularityDbContext db = new SingularityDbContext())
            {
                result.DataExtra.RoleList = db.HR_Role.Select(r => new { Id = r.Id, RoleName = r.Name }).ToList();
            }

            if (id == 0)
            {
                UserJson userJson = new UserJson();
                result.Data = userJson;
            }
            else
            {
                using (SingularityDbContext db = new SingularityDbContext())
                {
                    var user = db.HR_User.SingleOrDefault(x => x.Id == id);
                    UserJson userJson = new UserJson();
                    userJson.Id = user.Id;
                    userJson.FirstName = user.FirstName;
                    userJson.LastName = user.LastName;
                    userJson.Email = user.Email;
                    userJson.Password = user.Password;
                    userJson.RoleId = user.RoleId;
                    userJson.CreateDate = user.CreateDate;
                    userJson.UpdateDate = user.UpdateDate;
                    userJson.CreateBy = user.CreateBy;
                    userJson.UpdateBy = user.UpdateBy;
                    userJson.History = user.History;

                    result.Data = userJson;
                }
            }

            return result;
        }


        [HttpDelete]
        public HttpResult<UserJson> DeleteUserById(int id)
        {
            string error = string.Empty;
            var result = new HttpResult<UserJson>();

            if (id!=0)
            {
                using (SingularityDbContext db = new SingularityDbContext())
                {
                    var deleteUser = db.HR_User.SingleOrDefault(x => x.Id == id);
                    deleteUser.IsDeleted = true;
                    db.SaveChanges();
                }
            }
            else
            {

            }

            return result;
        }

    }
}
