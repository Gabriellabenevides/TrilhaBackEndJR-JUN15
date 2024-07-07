using GerenciadorTarefas.Model;

namespace GerenciadorTarefas.Domain.Interface.Repository
{
    public interface IUserRepository
    {
        public Task<User> Create(User user);
        public Task<int> Update(User user);
        public Task<bool> Delete(int userId);
        public Task<List<User>> List();
    }
}
