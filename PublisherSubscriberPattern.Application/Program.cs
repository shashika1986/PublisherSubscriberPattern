using System;
using PublisherSubscriberPattern.Publish;
using PublisherSubscriberPattern.Subscribe;
using Autofac;
using PublisherSubscriberPattern.Extension;

namespace PublisherSubscriberPattern.Application
{
    class Program
    {
        public static IContainer container;

        static void Main(string[] args)
        {
            ConfigAutofac();

            IPublisher<double> mathPublisher = new MathPublisher(container.Resolve<ICalculator>());
            MathSubscriber mathSub = new MathSubscriber(mathPublisher);
            Console.Write("Please enter a decimal value here: ");
            var userInput = Console.ReadLine();
            double value;

            if (Double.TryParse(userInput, out value))
            {
                mathPublisher.PublishData(value);
                Console.WriteLine("Subscriber received: " + mathSub.Value.ToString());
            }
            else
            {
                Console.WriteLine("Invalid input number.");
            }
            Console.ReadKey();
        }

        private static void ConfigAutofac()
        {
            var builder = new ContainerBuilder();
            DIRegistration.RegisterTypes(builder);            
            container = builder.Build();
        }
    }
}
