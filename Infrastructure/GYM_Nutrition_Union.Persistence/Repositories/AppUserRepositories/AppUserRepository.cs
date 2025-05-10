using GYM_Nurition.Domain.Entities;
using GYM_Nutrition_Union.Application.Interfaces.AppUserInterfaces;
using GYM_Nutrition_Union.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM_Nutrition_Union.Persistence.Repositories.AppUserRepositories
{
    public class AppUserRepository : IAppUserRepository
    {
         private readonly GYM_Nutrition_Context _context;
    public AppUserRepository(GYM_Nutrition_Context context) { _context = context; }

    public async Task<bool> EmailExistAsync(string email)
        => await _context.AppUsers
                         .AnyAsync(u => u.AppUserEmail.ToLower() == email.ToLower());

        public async Task<AppUser> GetByEmailAsync(string email)
        {
            return await _context.AppUsers
                                .FirstOrDefaultAsync(u => u.AppUserEmail.ToLower() == email.ToLower());
        }
    }
}
