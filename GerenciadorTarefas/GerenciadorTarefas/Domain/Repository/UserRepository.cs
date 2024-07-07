using GerenciadorTarefas.DataBase;
using GerenciadorTarefas.Domain.Interface.Repository;
using GerenciadorTarefas.Model;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorTarefas.Domain.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly Context _context;
        public UserRepository(Context context)
        {
            _context = context;
        }
        public async Task<User> Create(User user)
        {
            var result = await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<bool> Delete(int userId)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user == null)
                return false;

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<User>> List()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<int> Update(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
            return await _context.SaveChangesAsync();
        }
    }
}
