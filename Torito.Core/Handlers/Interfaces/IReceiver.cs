using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Torito.Core.Handlers
{
    public interface IReceiver<T> where T : class
    {
        void Handle(T request);
    }
}
