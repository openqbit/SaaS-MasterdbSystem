using OpenQbit.Masterdb.Common.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenQbit.Masterdb.BusinessService.Contracts
{
   public interface RResourceManger
    {
        bool RecoredInvoice(Resorce resource);
    }
}
