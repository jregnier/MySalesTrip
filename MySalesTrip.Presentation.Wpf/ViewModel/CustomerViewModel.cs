using GalaSoft.MvvmLight;
using MySalesApp.Business.Models;
using MySalesApp.Service.CustomerServices;
using System;
using System.Threading.Tasks;

namespace MySalesTrip.Presentation.Wpf.ViewModel
{
    public class CustomerViewModel : ViewModelBase
    {
        public delegate CustomerViewModel EditFactory(CustomerEdit customer);
        private readonly ICustomerEditService _customerEditService;
        private CustomerEdit _customerModel;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerViewModel"/> class.
        /// </summary>
        public CustomerViewModel(
            CustomerEdit customer,
            ICustomerEditService customerEditService)
        {
            _customerEditService = customerEditService ?? throw new ArgumentNullException(nameof(customerEditService));

            _customerModel = customer;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerViewModel"/> class.
        /// </summary>
        public CustomerViewModel(ICustomerEditService customerEditService)
        {
            _customerEditService = customerEditService ?? throw new ArgumentNullException(nameof(customerEditService));
        }

        /// <summary>
        /// Gets or sets the name of the customer.
        /// </summary>
        public string Name
        {
            get
            {
                return _customerModel.Name;
            }

            set
            {
                if (value == _customerModel.Name)
                {
                    return;
                }

                _customerModel.Name = value;
                RaisePropertyChanged(() => Name);
            }
        }
    }
}

