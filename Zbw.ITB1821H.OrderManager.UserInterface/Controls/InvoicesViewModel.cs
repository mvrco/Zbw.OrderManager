using log4net;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using ZbW.ITB1821H.OrderManager.Controls;
using ZbW.ITB1821H.OrderManager.Model.Repository;
using ZbW.ITB1821H.OrderManager.Model.Service;
using ZbW.ITB1821H.OrderManager.Model.Service.Interfaces;

namespace ZbW.ITB1821H.OrderManager.UserInterface.Controls
{
    public class InvoicesViewModel : BaseViewModel
    {
        private IInvoiceService _invoiceService;
        public InvoicesViewModel() : base(LogManager.GetLogger(nameof(InvoicesViewModel)))
        {
            _invoiceService = new InvoiceService(new InvoiceRepository());
            Invoices = _invoiceService.Get();
        }

        private System.Collections.IEnumerable invoices;

        public System.Collections.IEnumerable Invoices { get => invoices; set => invoices = value; }
    }
}
