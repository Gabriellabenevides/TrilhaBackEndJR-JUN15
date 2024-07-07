using System.ComponentModel.DataAnnotations;

namespace GerenciadorTarefas.Model
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Senha { get; set; }

        public ICollection<Tarefa> Tarefas { get; set; }
    }
}
