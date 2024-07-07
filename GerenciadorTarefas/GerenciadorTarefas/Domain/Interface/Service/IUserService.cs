using GerenciadorTarefas.Model;

namespace GerenciadorTarefas.Domain.Interface.Service
{
    public interface IUserService
    {
        public Task<User> Create(User user);
        public Task<int> Update(User user);
        public Task<bool> Delete(int userId);
        public Task<List<User>> List();
    }
}
