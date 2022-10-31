using Microsoft.EntityFrameworkCore;
using Spipama.Domain.Context;
using Spipama.Infrastructure.Data.Interfaces;
using SPIPAMA.Domain.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spipama.Infrastructure.Data.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseModel, new()
    {
        public readonly SpipamaPublicWebDbContext _context;
        public GenericRepository(SpipamaPublicWebDbContext context)
        {
            _context = context;
        }
        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _context.Set<T>().Where(i => i.IsDeleted == false && i.Id == id).FirstOrDefaultAsync();
        }
      
    }
}
