using GerenciadorTarefas.Domain.Interface.Repository;
using GerenciadorTarefas.Domain.Interface.Service;
using GerenciadorTarefas.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GerenciadorTarefas.Domain.Service
{
    public class TarefaService : ITarefaService
    {
        private readonly ITarefaRepository _repository;

        public TarefaService(ITarefaRepository repository)
        {
            _repository = repository;
        }

        public async Task<Tarefa> Create(Tarefa tarefa)
        {
            var result = await _repository.Create(tarefa);
            return result;
        }

        public async Task<bool> Delete(int tarefaId)
        {
            var result = await _repository.Delete(tarefaId);
            return result;
        }

        public async Task<List<Tarefa>> List()
        {
            var result = await _repository.List();
            return result;
        }

        public async Task<int> Update(Tarefa tarefa)
        {
            var result = await _repository.Update(tarefa);
            return result;
        }
    }
}
