using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Data
{
    public class BaseRepository<T> where T : class
    {
        private readonly ApplicationDbContext _dbcontext;

        public BaseRepository(ApplicationDbContext dbcontext) 
        {
            _dbcontext = dbcontext;
        }

        public virtual async Task<IEnumerable<T>> GetAll() 
        {
            return await _dbcontext.Set<T>().ToListAsync();
        }
    }
}
