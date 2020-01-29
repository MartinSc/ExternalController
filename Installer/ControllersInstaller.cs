using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using ControllerTestApi.Controllers;
using ExternalControllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace ControllerTestApi.Installer
{
    public class ControllersInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
           container.Register(Classes.FromThisAssembly()
                .BasedOn<ApiController>()
                .LifestyleTransient());

            container.Register(Classes.FromThisAssembly()
              .BasedOn<Controller>()
              .LifestyleTransient());

            container.Register(
                Classes.FromAssemblyNamed("ExternalControllers")
                .BasedOn<ApiController>()
                .LifestyleTransient());

            container.Register(
                Classes.FromAssemblyNamed("ExternalControllers")
                .BasedOn<Controller>()
                .LifestyleTransient());

        }
    }
}