using Autofac;
using MaterialDesignThemes.Wpf;

namespace MySalesTrip.Presentation.Wpf.ViewModel
{
    public class ViewModelModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<MainViewModel>().As<IMainView>();
            builder.RegisterType<TripsViewModel>().As<ITabbedContent>();
            builder.RegisterType<CustomersViewModel>().As<ITabbedContent>();
            builder.RegisterType<SnackbarMessageQueue>().As<ISnackbarMessageQueue>();
            builder.RegisterType<CustomerViewModel>();
        }
    }
}
