using MRTwitter.Interfaces;
using MRTwitter.Services;
using Ninject;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MRTwitter.DependencyInjection
{
    class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;
        public NinjectDependencyResolver()
        {
            kernel = new StandardKernel();
            AddBindings();
        }
        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
        private void AddBindings()
        {
            kernel.Bind<ITwitterService>().To<TwitterService>();
        }
    }
}