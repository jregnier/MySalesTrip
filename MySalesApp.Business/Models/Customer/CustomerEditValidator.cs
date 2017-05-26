using FluentValidation;
using MySalesApp.Data.Repositories;

namespace MySalesApp.Business.Models
{
    public class CustomerEditValidator : AbstractValidator<CustomerEdit>
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerEditValidator(ICustomerRepository customerRepository)
        {
            this._customerRepository = customerRepository;

            RuleFor(c => c.Name)
                .NotEmpty();
        }
    }
}
