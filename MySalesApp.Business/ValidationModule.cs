using Autofac;
using FluentValidation;
using MySalesApp.Business.Models;

namespace MySalesApp.Business
{
    public class ValidationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ModelValidationFactory>().As<IValidatorFactory>().InstancePerDependency();
            builder.RegisterType<CustomerEditValidator>().As<IValidator<CustomerEdit>>().InstancePerDependency();
        }
    }
}
