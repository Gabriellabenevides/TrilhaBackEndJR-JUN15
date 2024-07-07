using GerenciadorTarefas.Model;

namespace GerenciadorTarefas.Domain.Interface.Repository
{
    public interface ITarefaRepository
    {
        public Task <Tarefa> Create(Tarefa tarefa);
        public Task<int> Update(Tarefa tarefa);
        public Task<bool> Delete(int tarefaId);
        public Task<List<Tarefa>> List();
    }
}
