using Ninject;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestApplication.BL.Builder.Abstract;
using TestApplication.BL.Builder.Concrete;
using TestApplication.BL.Helpers.Abstract;
using TestApplication.BL.Helpers.Concrete;
using TestApplication.BL.Managers.Abstract;
using TestApplication.BL.Managers.Concrete;
using TestApplication.BL.Models;

namespace TestApplication.Infrastructure
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        IKernel ninjectKernel;

        public NinjectControllerFactory()
        {
            ninjectKernel = new StandardKernel();
            AddBindings();
        }

        protected override IController GetControllerInstance(System.Web.Routing.RequestContext requestContext, Type controllerType)
        {
            // получение объекта контроллера из контейнера
            // используя его тип
            return controllerType == null ? null : (IController)ninjectKernel.Get(controllerType);

        }
        private void AddBindings()
        {
            ninjectKernel.Bind<IColorChooseHelper>().To<ConsoleColorChooseHelper>();
            ninjectKernel.Bind<ICoordinatesManager>().To<XMLLineCoordinatesManager>().WithConstructorArgument("DataPath", ConfigurationManager.AppSettings["CoordinatesDataPath"].ToString());

        }
    }
}