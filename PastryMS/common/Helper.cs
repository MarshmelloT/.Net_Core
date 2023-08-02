using System;
using System.Collections.Generic;
using System.Text;

namespace common
{
    public class Helper : IHelper
    {
        private IServiceProvider _serviceProvider;

        public Helper(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public T GetServie<T>()
        {
            return (T)GetServie(typeof(T));
        }

        public object GetServie(Type serviceType)
        {
            return _serviceProvider.GetService(serviceType);

        }
    }
}
