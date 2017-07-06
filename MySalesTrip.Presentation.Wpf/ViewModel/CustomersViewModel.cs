using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using MySalesApp.Business.Models;
using MySalesApp.Business.Models.Customer;
using MySalesApp.Service.CustomerServices;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Data;

namespace MySalesTrip.Presentation.Wpf.ViewModel
{
    /// <summary>
    /// View model for interacting with customers.
    /// </summary>
    public class CustomersViewModel : ViewModelBase, ITabbedContent, ILoadData
    {
        private readonly ICustomerListService _customerListService;
        private readonly ICustomerEditService _customerEditService;
        private RelayCommand _addNewCustomerCommand;
        private ObservableCollection<CustomerList> _customerCollection;
        private ICollectionView _customerCollectionView;
        private CustomerViewModel.EditFactory _customerEditViewModelFactory;
        private CustomerViewModel _selectedCustomer;
        private CustomerList _selectedCustomerModel;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomersViewModel"/> class.
        /// </summary>
        /// <param name="customerListService"></param>
        public CustomersViewModel(
            ICustomerListService customerListService,
            ICustomerEditService customerEditService,
            CustomerViewModel.EditFactory customerEditViewModelFactory)
        {
            _customerListService = customerListService ?? throw new ArgumentNullException(nameof(customerListService));
            _customerEditService = customerEditService ?? throw new ArgumentNullException(nameof(customerEditService));
            _customerEditViewModelFactory = customerEditViewModelFactory ?? throw new ArgumentNullException(nameof(customerEditViewModelFactory));
        }

        /// <summary>
        /// Gets a command used to add a new customer.
        /// </summary>
        public RelayCommand AddNewCustomerCommand
        {
            get
            {
                if (_addNewCustomerCommand == null)
                {
                    _addNewCustomerCommand = new RelayCommand(() =>
                    {
                        SelectedCustomer = _customerEditViewModelFactory(_customerEditService.New());
                    });
                }

                return _addNewCustomerCommand;
            }
        }

        /// <summary>
        /// Gets the collection of customers.
        /// </summary>
        public ICollectionView CustomerCollectionView
        {
            get
            {
                if (_customerCollectionView == null)
                {
                    _customerCollectionView = CollectionViewSource.GetDefaultView(_customerCollection);
                }

                return _customerCollectionView;
            }
        }

        /// <inheritdoc/>
        public string Header => "Customers";

        /// <summary>
        /// Gets or set the selected customer.
        /// </summary>
        public CustomerViewModel SelectedCustomer
        {
            get { return _selectedCustomer; }
            set
            {
                if (value == _selectedCustomer)
                {
                    return;
                }

                _selectedCustomer = value;
                RaisePropertyChanged(() => SelectedCustomer);
            }
        }

        /// <summary>
        /// Gets or sets the selected customer in the list.
        /// </summary>
        public CustomerList SelectedCustomerModel
        {
            get { return _selectedCustomerModel; }

            set
            {
                if (value == _selectedCustomerModel)
                {
                    return;
                }

                _selectedCustomerModel = value;
                RaisePropertyChanged(() => SelectedCustomerModel);

                if (_selectedCustomerModel != null)
                {
                    //SelectedCustomer = _customerEditViewModelFactory(_selectedCustomerModel.Id);
                }
            }
        }

        /// <inheritdoc/>
        public int Sequence => 2;

        /// <inheritdoc/>
        public async Task LoadData()
        {
            _customerCollection = new ObservableCollection<CustomerList>(await _customerListService.GetAllAsync());
        }
    }
}