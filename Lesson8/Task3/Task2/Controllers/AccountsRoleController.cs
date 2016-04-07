using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using Test3Task.Models;
using WebMatrix.WebData;

namespace Test3Task.Controllers
{
    public class AccountsRoleController : Controller
    {
        DatabaseContext db=new DatabaseContext();
        // GET: AccountsRole
        [Authorize(Roles = "Admin")]
        public ActionResult AccountsRoleList()
        {
            var roles = (SimpleRoleProvider)Roles.Provider;
            IEnumerable<UserProfile> userProfilesList = db.UserProfiles;
            List<AccountsRole> userRoles=new List<AccountsRole>();

            foreach (var user  in userProfilesList)
            {
                AccountsRole accountsRole=new AccountsRole();
                accountsRole.UserId = user.UserId;
                accountsRole.UserName = user.UserName;
                accountsRole.Role = roles.GetRolesForUser(user.UserName);
                userRoles.Add(accountsRole);
            }


            return View(userRoles);
        }
        [Authorize(Roles = "Admin")]
        public ActionResult AccountsChangeRole(int userId=0)
        {
            UserProfile user = db.UserProfiles.Find(userId);
            var roles = (SimpleRoleProvider)Roles.Provider;
            ViewBag.Role = new SelectList(roles.GetAllRoles(), "Role");
            return View(user);
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult AccountsChangeRole(UserProfile user, string role)
        {
            string[] userRoles=Roles.GetRolesForUser(user.UserName);
            Roles.RemoveUserFromRoles(user.UserName,userRoles);
            Roles.AddUserToRole(user.UserName, role);
            return RedirectToAction("AccountsRoleList");
        }
    }
}