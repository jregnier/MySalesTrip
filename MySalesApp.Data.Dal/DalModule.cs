using Autofac;
using LiteDB;
using MySalesApp.Data.Dal.Repositories;
using MySalesApp.Data.Repositories;

namespace MySalesApp.Data.Dal
{
    public class Dalmodule : Module
    {
        public string DBPath { get; set; }

        protected override void Load(ContainerBuilder builder)
        {
            var db = new LiteDatabase(DBPath);

            builder.RegisterType<LiteDbConnection>().As<IDbConnection>();
            builder.RegisterInstance(db);
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerDependency();
            builder.RegisterType<CustomerRepository>().As<ICustomerRepository>();
        }
    }
}
