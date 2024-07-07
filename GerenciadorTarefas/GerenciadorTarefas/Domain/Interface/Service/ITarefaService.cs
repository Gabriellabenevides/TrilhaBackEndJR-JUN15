using GerenciadorTarefas.Model;

namespace GerenciadorTarefas.Domain.Interface.Service
{
    public interface ITarefaService
    {
        public Task<bool> Create(Tarefa tarefa);
        public Task<int> Update(Tarefa tarefa);
        public Task<bool> Delete(int tarefaId);
        public Task<List<Tarefa>> List();
    }
}
