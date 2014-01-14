using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class DataContext : IDataContext
    {
        private PcgStorageEntities _context;

        public PcgStorageEntities GetDataContext()
        {
            if (_context == null)
                return new PcgStorageEntities();
            else
                return _context;
        }

        public DataContext(PcgStorageEntities context)
        {
            _context = context;
        }
    }
}
