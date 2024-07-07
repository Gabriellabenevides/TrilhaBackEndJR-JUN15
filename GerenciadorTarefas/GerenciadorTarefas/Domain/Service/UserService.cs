using GerenciadorTarefas.Domain.Interface.Repository;
using GerenciadorTarefas.Domain.Interface.Service;
using GerenciadorTarefas.Domain.Repository;
using GerenciadorTarefas.Model;

namespace GerenciadorTarefas.Domain.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<User> Create(User user)
        {
            var result = await _repository.Create(user);
            return result;
        }

        public async Task<bool> Delete(int userId)
        {
            var result = await _repository.Delete(userId);
            return result;
        }

        public async Task<List<User>> List()
        {
            var result = await _repository.List();
            return result;
        }

        public async Task<int> Update(User user)
        {
            var result = await _repository.Update(user);
            return result;
        }
    }
}
