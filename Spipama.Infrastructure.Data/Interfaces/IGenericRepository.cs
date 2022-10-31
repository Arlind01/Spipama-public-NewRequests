using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spipama.Infrastructure.Data.Interfaces
{
 
        public interface IGenericRepository<T> where T : class
        {
            Task<T> GetByIdAsync(Guid id);
        }
}
