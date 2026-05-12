using TaskManager.API.Domain.Entities;

namespace TaskManager.API.Domain.Interfaces
{
    public interface ITarefaRepository
    {
        Task<List<Tarefa>> GetAllAsync();
        Task<Tarefa?> GetByIdAsync(int id);
        Task AddAsync(Tarefa tarefa);
        Task UpdateAsync(Tarefa tarefa);
        Task DeleteAsync(int id);
    }
}
