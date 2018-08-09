using PassWeb.Infrastructure.IRepositories;
using PassWeb.Infrastructure.Repositories;
using PassWeb.Interfaces;
using PassWeb.Services;
using System.Web.Mvc;
using Unity;
using Unity.AspNet.Mvc;

namespace PassWeb.App_Start
{
    public class UnityConfig
    {
        public static IUnityContainer Container;

        public static void RegisterComponents()
        {
            Container = new UnityContainer();
            Container.RegisterType<IUserRepository, UserRepository>();
            Container.RegisterType<IUserService, UserService>();
            Container.RegisterType<ILoginService, LoginService>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(Container));
        }
    }
}