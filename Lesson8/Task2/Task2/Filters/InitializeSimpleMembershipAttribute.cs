using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Threading;
using System.Web.Mvc;
using System.Web.Security;
using Test3Task.Models;
using WebMatrix.WebData;

namespace Test3Task.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public sealed class InitializeSimpleMembershipAttribute : ActionFilterAttribute
    {
        private static SimpleMembershipInitializer _initializer;
        private static object _initializerLock = new object();
        private static bool _isInitialized;

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            LazyInitializer.EnsureInitialized(ref _initializer, ref _isInitialized,ref _initializerLock);
        }

        private class SimpleMembershipInitializer
        {
            public SimpleMembershipInitializer()
            {
                Database.SetInitializer<DatabaseContext>(null);
                try
                {
                    using (var context = new DatabaseContext())
                    {
                        if (!context.Database.Exists())
                        {
                           ((IObjectContextAdapter)context).ObjectContext.CreateDatabase();   
                        }
                    }
                    // Настройка  ASP.NET Simple Membership
                    // 1 параметр - имя строки подключения к базе данных.
                    // 2 параметр - таблица, которая содержит информацию о пользователях
                    // 3 параметр - имя колонки в таблице, которая отвечает за хранение логина
                    // 4 параметр - autoCreateTables автоматическое создание таблиц если они не существуют в базе
                    WebSecurity.InitializeDatabaseConnection("DatabaseContext","UserProfile","UserId","UserName",autoCreateTables:true);

                    SimpleRoleProvider roles = (SimpleRoleProvider) Roles.Provider;
                    SimpleMembershipProvider membership = (SimpleMembershipProvider) Membership.Provider;

                    if (!roles.RoleExists("User"))
                    {
                        roles.CreateRole("User");
                    }

                    if (!roles.RoleExists("Admin"))
                    {
                        roles.CreateRole("Admin");
                    }

                    if (membership.GetUser("user1",false)==null)
                    {
                        membership.CreateUserAndAccount("user1", "123");
                        roles.AddUsersToRoles(new []{"user1"},new []{"User"});
                    }
                    if (membership.GetUser("admin", false) == null)
                    {
                        membership.CreateUserAndAccount("admin", "123");
                        roles.AddUsersToRoles(new []{"admin"},new []{"Admin"});
                    }
                }
                catch (Exception ex)
                {
                    
                    throw new InvalidOperationException(String.Format("The ASP.NET Simple Membership data couldnt be initialized Error {0}",ex));
                }
            }
        }
    }
}