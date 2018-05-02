using System;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using L.Pos.Web.App_Start;
using L.Pos.Web.Controllers;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using L.Pos.DataAccess.Repository;
using System.Reflection;
using SimpleInjector.Integration.Web.Mvc;
using L.Pos.Domain.Entity;
using L.Pos.DataAccess.Common;
using System.Web.Http;

namespace L.Pos.Web
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            GlobalConfiguration.Configure(WebApiConfig.Register);

            Bootstrap();
        }

        public void Bootstrap()
        {
            // Create the container as usual.
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            // Register your types, for instance:
            #region SQL Server DB
            container.Register<SQLServerContext>(Lifestyle.Singleton);
            container.Register<IUnitOfWork<SQLServerContext>, UnitOfWork<SQLServerContext>>(Lifestyle.Singleton);
            container.Register<IUserRepo, UserRepo>(Lifestyle.Scoped);
            container.Register<IRoleRepo, RoleRepo>(Lifestyle.Scoped);
            #endregion

            #region Others DB
            container.Register<MySQLContext>(Lifestyle.Singleton);
            container.Register<IUnitOfWork<MySQLContext>, UnitOfWork<MySQLContext>>(Lifestyle.Singleton);
            container.Register<IRepository<User, MySQLContext>, Repository<User, MySQLContext>>(Lifestyle.Scoped);
            #endregion


            // This is an extension method from the integration package.
            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());

            container.Verify();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            var exception = Server.GetLastError();
            var httpContext = ((HttpApplication)sender).Context;
            httpContext.Response.Clear();
            httpContext.ClearError();

            if (new HttpRequestWrapper(httpContext.Request).IsAjaxRequest())
            {
                return;
            }

            ExecuteErrorController(httpContext, exception as HttpException);
        }

        private void ExecuteErrorController(HttpContext httpContext, HttpException exception)
        {
            var routeData = new RouteData();
            routeData.Values["controller"] = "Error";

            if (exception != null && exception.GetHttpCode() == (int)HttpStatusCode.NotFound)
            {
                routeData.Values["action"] = "NotFound";
            }
            else
            {
                routeData.Values["action"] = "InternalServerError";
            }

            using (Controller controller = new ErrorController())
            {
                ((IController)controller).Execute(new RequestContext(new HttpContextWrapper(httpContext), routeData));
            }
        }
    }
}