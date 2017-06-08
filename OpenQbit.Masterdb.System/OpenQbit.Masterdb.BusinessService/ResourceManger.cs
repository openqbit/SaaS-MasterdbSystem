using OpenQbit.Masterdb.BusinessService.Contracts;
using OpenQbit.Masterdb.Common.Utils.Logs;
using OpenQbit.Masterdb.DataAccess.DAL.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQbit.Masterdb.Common.Model;

namespace OpenQbit.Masterdb.BusinessService
{
   public class ResourceManger : RResourceManger
    {
        private IRepository _repository;

        private ILogger _log;

        [InjectionConstructor]    // Constructore  inject
        public InvoiceManger(IRepository repository, ILogger log)
        {
            this._repository = repository;
            this._log = log;
        }


        [Dependency] //for setters
        public IRepository Repository
        {
            get { return _repository; }
            set { _repository = value; }
        }

        [Dependency] //for setters
        public ILogger Logger
        {
            get { return _log; }
            set { _log = value; }
        }


        [InjectionMethod] // for methodes
        public void SetRepository(IRepository repository)
        {
            _repository = repository;
        }

        public bool RecoredInvoice(Invoice invoice) //Add Invoice
        {
            _log.LogError("");

            return _repository.Create<Invoice>(invoice);

            //throw new NotImplementedException();
        }

        public bool RecoredInvoice(Resorce resource)
        {
            throw new NotImplementedException();
        }
    }
}
