﻿using Castle.Windsor;
using Castle.Windsor.Installer;
using ControllerTestApi.Installer;
using ControllerTestApi.Resolver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ControllerTestApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        private static IWindsorContainer container;

        private static void BootstrapContainer()
        {
            container = new WindsorContainer()
                .Install(FromAssembly.This());
            var controllerFactory = new WindsorControllerFactory(container.Kernel);
            ControllerBuilder.Current.SetControllerFactory(controllerFactory);
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            GlobalConfiguration.Configuration.Services.Replace(typeof(IAssembliesResolver), new CustomAssemblyResolver());
            BootstrapContainer();
        }
    }
}
