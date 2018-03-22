using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectMvvm.Models
{
    public interface IDependencyService
    {
        T Get<T>() where T : class;
    }
}
