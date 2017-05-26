using Autofac;
using FluentValidation;
using System;

namespace MySalesApp.Business.Models
{
    public class ModelValidationFactory : ValidatorFactoryBase
    {
        private readonly IComponentContext _context;

        public ModelValidationFactory(IComponentContext context)
        {
            _context = context;
        }

        public override IValidator CreateInstance(Type validatorType)
        {
            return _context.Resolve(validatorType) as IValidator;
        }
    }
}