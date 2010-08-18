using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Services;
using System.ServiceModel;

namespace AmxMobile.Services.Web
{
    public class ServicesHostFactory : DataServiceHostFactory
    {
        public ServicesHostFactory()
        {
        }

        public override ServiceHostBase CreateServiceHost(string constructorString, Uri[] baseAddresses)
        {
            ServiceHostBase host =  base.CreateServiceHost(constructorString, baseAddresses);
            if (host == null)
                throw new InvalidOperationException("'host' is null.");

            // return...
            return host;
        }

        protected override System.ServiceModel.ServiceHost CreateServiceHost(Type serviceType, Uri[] baseAddresses)
        {
            ServiceHost host = base.CreateServiceHost(serviceType, baseAddresses);
            if (host == null)
                throw new InvalidOperationException("'host' is null.");

            return host;
        }
    }
}
