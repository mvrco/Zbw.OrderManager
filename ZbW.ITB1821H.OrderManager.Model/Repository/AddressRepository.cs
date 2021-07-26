using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ZbW.ITB1821H.OrderManager.Model.Context;

namespace ZbW.ITB1821H.OrderManager.Model.Repository
{
    public class AddressRepository : RepositoryBase<Address>
    {
        public AddressRepository(DatabaseContext context) : base(context) { }

        public new List<Address> GetAll(Func<Address, bool> filter)
        {
            using (_context)
            {
                return _context.Set<Address>()
                    .Include(x => x.Customers)
                    .Where(filter)
                    .ToList();
            }
        }

        public new List<Address> GetAll()
        {
            using (_context)
            {
                return _context.Set<Address>()
                    .Include(x => x.Customers)
                    .ToList();
            }
        }

        public new Address GetSingle(int pkValue)
        {
            using (_context)
            {
                return _context.Set<Address>()
                    .Include(x => x.Customers)
                    .FirstOrDefault(x => x.Id == pkValue);
            }
        }
    }
}
