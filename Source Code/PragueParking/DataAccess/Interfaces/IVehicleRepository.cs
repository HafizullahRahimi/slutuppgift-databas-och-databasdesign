using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public interface IVehicleRepository
    {
        public bool Insert();
        public bool Delete();
        public bool Update();
        public bool Read();
        public bool GetCount();
    }
}
