using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TradeHike.Application.Interfaces;
using TradeHike.Domain.Entities;
using TradeHike.Persistence.Context;

namespace TradeHike.Persistence.Repositories.AppUserRepositories
{
    public class AppUserRepository : IAppUserRepository
    {
        private readonly MyContext _context;

        public AppUserRepository(MyContext context)
        {
            _context = context;
        }

        public Task<List<AppUser>> GetByFilterAsync(Expression<Func<AppUser, bool>> filter)
        {
            throw new NotImplementedException();
        }
    }
}
