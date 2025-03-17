using Avantik.Web.Service.Model.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avantik.Web.Service.Entity.Agency;
using Avantik.Web.Service.COMHelper;
using System.Runtime.InteropServices;
using Avantik.Web.Service.Exception.Booking;
using Avantik.Web.Service.Entity.Booking;
using Avantik.Web.Service.Entity;

namespace Avantik.Web.Service.Model.COM
{
    public class VoucherService : RunComplus, IVoucherService
    {
        string _server = string.Empty;
        public VoucherService(string server, string user, string pass, string domain)
            : base(user, pass, domain)
        {
            _server = server;
        }

        public Voucher GetVoucher(Voucher vc)
        {
         

            return new Voucher();
        }
    }
}
