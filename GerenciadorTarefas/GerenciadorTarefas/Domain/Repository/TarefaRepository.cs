using GerenciadorTarefas.DataBase;
using GerenciadorTarefas.Domain.Interface.Repository;
using GerenciadorTarefas.Model;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorTarefas.Domain.Repository
{
    public class TarefaRepository : ITarefaRepository
    {
        private readonly Context _context;
        public TarefaRepository(Context context) { _context = context; }

        public async Task<Tarefa> Create(Tarefa tarefa)
        {
            var ret = await _context.Tarefas.AddAsync(tarefa);

            await _context.SaveChangesAsync();

            ret.State = EntityState.Detached;

            return ret.Entity;
        }

        public async Task<bool> Delete(int tarefaId)
        {
            var tarefa = await _context.Tarefas.FindAsync(tarefaId);
            _context.Tarefas.Remove(tarefa);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<List<Tarefa>> List()
        {
            List<Tarefa> list = await _context.Tarefas.OrderBy(p => p.Titulo).ToListAsync();
            return list;
        }

        public async Task<int> Update(Tarefa tarefa)
        {
            _context.Entry(tarefa).State = EntityState.Modified;

            return await _context.SaveChangesAsync();
        }
    }
}
