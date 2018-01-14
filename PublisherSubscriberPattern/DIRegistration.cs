using Autofac;
using PublisherSubscriberPattern.Extension;
namespace PublisherSubscriberPattern
{
    public static class DIRegistration
    {
        public static void RegisterTypes(ContainerBuilder builder)
        {
            builder.RegisterType<Calculator>().As<ICalculator>();           
        }
    }
}
