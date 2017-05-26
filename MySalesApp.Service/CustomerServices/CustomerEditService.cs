using FluentValidation;
using MySalesApp.Business.Models;
using MySalesApp.Data;
using MySalesApp.Data.Entities;
using MySalesApp.Data.Repositories;
using System.Threading.Tasks;
using System.Linq;
using System;

namespace MySalesApp.Service.CustomerServices
{
    public class CustomerEditService : ICustomerEditService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICustomerRepository _customerRepository;
        private readonly IValidator<CustomerEdit> _customerValidator;

        public CustomerEditService(
            ICustomerRepository customerRepository, 
            IUnitOfWork unitOfWork,
            IValidator<CustomerEdit> customerValidator)
        {
            _customerRepository = customerRepository;
            _unitOfWork = unitOfWork;
            _customerValidator = customerValidator;
        }

        public async Task CreateAsync(CustomerEdit customer)
        {
            _unitOfWork.BeginTransaction();

            var result = await _customerValidator.ValidateAsync(customer);

            if (!result.IsValid)
            {
                // TODO: do something...
            }

            // TODO: Use auto mapper;
            var entity = new CustomerEntity()
            {
                Name = customer.Name,
                Addresses = customer.Addresses
                    .Select(a => new AddressEntity()
                    {
                        City = a.City, 
                        Country = a.Country,
                        PostalCode = a.PostalCode,
                        Province = a.PostalCode,
                        StreetAddress = a.StreetAddress
                    })
                    .ToList()
            };

            try
            {
                _customerRepository.Create(entity);
                _unitOfWork.SaveChanges();
            }
            catch (Exception ex)
            {
                // TODO: do something...
            }
        }

        public async Task EditAsync(CustomerEdit customer)
        {
            _unitOfWork.BeginTransaction();

            var result = await _customerValidator.ValidateAsync(customer);

            if (!result.IsValid)
            {
                // TODO: do something...
            }

            // TODO: Use auto mapper;
            var entity = new CustomerEntity()
            {
                Id = customer.Id,
                Name = customer.Name,
                Addresses = customer.Addresses
                    .Select(a => new AddressEntity()
                    {
                        City = a.City,
                        Country = a.Country,
                        PostalCode = a.PostalCode,
                        Province = a.PostalCode,
                        StreetAddress = a.StreetAddress
                    })
                    .ToList()
            };

            try
            {
                _customerRepository.Create(entity);
                _unitOfWork.SaveChanges();
            }
            catch (Exception ex)
            {
                // TODO: do something...
            }
        }

        public async Task<CustomerEdit> GetById(int id)
        {
            var customer = await Task.Run(() => _customerRepository.GetById(id));

            return new CustomerEdit()
            {
                Name = customer.Name,
                Addresses = customer.Addresses
                    .Select(a => new Address()
                    {
                        City = a.City,
                        Country = a.Country,
                        PostalCode = a.PostalCode,
                        Province = a.PostalCode,
                        StreetAddress = a.StreetAddress
                    })
                    .ToList()
            };
        }
    }
}
