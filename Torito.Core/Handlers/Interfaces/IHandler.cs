using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Torito.Core.Handlers.Interfaces
{
    public interface IHandler<T> where T : class
    {
        void Handle(T obj);

        void SetNext(IReceiver<T> obj);
    }
}
