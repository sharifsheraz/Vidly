using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Web.Http;
using System.Web.Mvc;
using Unity;
using Unity.Injection;
using Unity.Lifetime;
using Unity.Mvc5;
using Vidly.Controllers;
using Vidly.Models;
using Vidly.Repositories;
using Vidly.Repositories.Core;
using Vidly.Repositories.Persistent;

namespace Vidly
{
	public static class UnityConfig
	{
		public static UnityContainer Container { get; private set; }
		public static void RegisterComponents()
		{
			var container = new UnityContainer();

			// register all your components with the container here
			// it is NOT necessary to register your controllers

			// e.g. container.RegisterType<ITestService, TestService>();
			container.RegisterType<DbContext, ApplicationDbContext>(new HierarchicalLifetimeManager());
			container.RegisterType<UserManager<ApplicationUser>>(new HierarchicalLifetimeManager());
			container.RegisterType<IUserStore<ApplicationUser>, UserStore<ApplicationUser>>(new HierarchicalLifetimeManager());
			container.RegisterType<AccountController>(new InjectionConstructor());
			container.RegisterType<IUnitOfWork, UnitOfWork>();

			Container = container;

			GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);
			DependencyResolver.SetResolver(new UnityDependencyResolver(container));
		}
	}
}