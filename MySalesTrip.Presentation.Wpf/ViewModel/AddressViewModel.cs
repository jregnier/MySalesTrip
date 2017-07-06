using GalaSoft.MvvmLight;
using MySalesApp.Business.Models;
using System;

namespace MySalesTrip.Presentation.Wpf.ViewModel
{
    public class AddressViewModel : ViewModelBase
    {
        private Address _addressModel;

        /// <summary>
        /// Initializes a new instance of the <see cref="AddressViewModel"/> class.
        /// </summary>
        /// <param name="addressModel"></param>
        public AddressViewModel(Address addressModel)
        {
            _addressModel = addressModel ?? throw new ArgumentNullException(nameof(addressModel));
        }

        /// <summary>
        /// Gets or sets the city.
        /// </summary>
        public string City
        {
            get { return _addressModel.City; }

            set
            {
                if (value == _addressModel.City)
                {
                    return;
                }

                _addressModel.City = value;
                RaisePropertyChanged(() => City);
            }
        }

        /// <summary>
        /// Gets or sets the country.
        /// </summary>
        public string Country
        {
            get { return _addressModel.Country; }

            set
            {
                if (value == _addressModel.Country)
                {
                    return;
                }

                _addressModel.Country = value;
                RaisePropertyChanged(() => Country);
            }
        }

        /// <summary>
        /// Gets or sets the postal code.
        /// </summary>
        public string PostalCode
        {
            get { return _addressModel.PostalCode; }

            set
            {
                if (value == _addressModel.PostalCode)
                {
                    return;
                }

                _addressModel.PostalCode = value;
                RaisePropertyChanged(() => PostalCode);
            }
        }

        /// <summary>
        /// Gets or sets the province.
        /// </summary>
        public string Province
        {
            get { return _addressModel.Province; }

            set
            {
                if (value == _addressModel.Province)
                {
                    return;
                }

                _addressModel.Province = value;
                RaisePropertyChanged(() => Province);
            }
        }

        /// <summary>
        /// Gets or sets the street name.
        /// </summary>
        public string Street
        {
            get { return _addressModel.StreetAddress; }

            set
            {
                if (value == _addressModel.StreetAddress)
                {
                    return;
                }

                _addressModel.StreetAddress = value;
                RaisePropertyChanged(() => Street);
            }
        }
    }
}