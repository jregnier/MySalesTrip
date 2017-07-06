using Autofac;
using MySalesApp.Service.CustomerServices;

namespace MySalesApp.Service
{
    public class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CustomerEditService>().As<ICustomerEditService>();
            builder.RegisterType<CustomerListService>().As<ICustomerListService>();
        }
    }
}
