using PublisherSubscriberPattern.Extension;
using System;

namespace PublisherSubscriberPattern.Publish
{
    public class MathPublisher : IPublisher<double>
    {
        public event EventHandler<DataPublisherEventArgs<double>> DataPublish;
        private ICalculator _calculator;

        public MathPublisher(ICalculator calculator)
        {
            _calculator = calculator;
        }

        public void OnDataPublish(DataPublisherEventArgs<double> args)
        {
            DataPublish?.Invoke(this, args);
        }

        public void PublishData(double data)
        {
            double _data = _calculator.Addition(data, 100);

            DataPublisherEventArgs<double> message = (DataPublisherEventArgs<double>)Activator.CreateInstance(typeof(DataPublisherEventArgs<double>), new object[] { _data });
            OnDataPublish(message);
        }      
    }
}
