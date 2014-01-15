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
            return new PcgStorageEntities();
        }

        public DataContext()
        {
            _context = new PcgStorageEntities();
        }

        public DataContext(PcgStorageEntities context)
        {
            _context = context;
        }
    }
}
