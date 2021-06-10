using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Torito.Core.Handlers.Interfaces;
using Torito.Data.Persistance.DataModels;

namespace Torito.Core.Handlers.Implementations
{
    public abstract class BaseHandler<T> : IHandler<T> where T : class
    {
        private readonly IList<IReceiver<T>> _receivers;

        public BaseHandler(params IReceiver<T>[] receivers)
        {
            _receivers = receivers;
        }

        public virtual void Handle(T obj)
        {
            foreach (var receiver in _receivers)
            {
                receiver.Handle(obj);
            }
        }

        public virtual void SetNext(IReceiver<T> obj) => _receivers.Add(obj);
    }
}
