using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Torito.Core.Handlers.Interfaces;
using Torito.Data.Persistance.DataModels;

namespace Torito.Core.Handlers.Implementations
{
    public class TweetDboAddressCleanHandler : BaseHandler<TweetDbo>, IHandler<TweetDbo>
    {
        // Issue with dependency injection.
        //public TweetDboAddressCleanHandler(params IReceiver<TweetDbo>[] receivers) : base(receivers)
        public TweetDboAddressCleanHandler(IEnumerable<IReceiver<TweetDbo>> receivers) : base(receivers.ToArray())
        {

        }

        public override void Handle(TweetDbo obj)
        {
            obj.AddressText ??= obj.Text;
            base.Handle(obj);
        }
    }
}
