using GerenciadorTarefas.DataBase;
using GerenciadorTarefas.Domain.Interface.Repository;
using GerenciadorTarefas.Model;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorTarefas.Domain.Repository
{
    public class TarefaRepository : ITarefaRepository
    {
        private readonly Context _context;

        public TarefaRepository(Context context)
        {
            _context = context;
        }

        public async Task<Tarefa> Create(Tarefa tarefa)
        {
            var result = await _context.Tarefas.AddAsync(tarefa);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<bool> Delete(int tarefaId)
        {
            var tarefa = await _context.Tarefas.FindAsync(tarefaId);
            if (tarefa == null)
                return false;

            _context.Tarefas.Remove(tarefa);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Tarefa>> List()
        {
            return await _context.Tarefas.ToListAsync();
        }

        public async Task<int> Update(Tarefa tarefa)
        {
            _context.Entry(tarefa).State = EntityState.Modified;
            return await _context.SaveChangesAsync();
        }
    }
}
