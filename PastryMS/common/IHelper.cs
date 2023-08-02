using System;
using System.Collections.Generic;
using System.Text;

namespace common
{
    public  interface IHelper
    {
        T GetServie<T>();
        object GetServie(Type serviceType);
    }
}
