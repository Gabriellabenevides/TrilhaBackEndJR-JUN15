using GerenciadorTarefas.Domain.Interface.Service;
using GerenciadorTarefas.Domain.Repository;
using GerenciadorTarefas.Model;

namespace GerenciadorTarefas.Domain.Service
{
    public class TarefaService : ITarefaService
    {
        private readonly TarefaRepository _repository;
        public TarefaService(TarefaRepository repository)
        {
            _repository = repository;
        }
        public async Task<bool> Create(Tarefa tarefa)
        {

            var result = await _repository.Create(tarefa);
            return true;
        }

        public async Task<bool> Delete(int tarefaId)
        {
            await _repository.Delete(tarefaId);
            return true;
        }

        public async Task<List<Tarefa>> List()
        {
            var tarefa = await _repository.List();

            return tarefa;
        }

        public async Task<int> Update(Tarefa tarefa)
        {
            return await _repository.Update(tarefa);
        }
    }
}
