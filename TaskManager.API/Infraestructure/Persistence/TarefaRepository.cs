using Microsoft.EntityFrameworkCore;
using System.Linq;
using TaskManager.API.Domain.Entities;
using TaskManager.API.Domain.Interfaces;

namespace TaskManager.API.Infraestructure.Persistence
{
    public class TarefaRepository : ITarefaRepository
    {
        private readonly AppDbContext _context;

        public TarefaRepository(AppDbContext context)
        {
            _context = context;

        }

        public async Task AddAsync(Tarefa tarefa)
        {
            await _context.Tarefas.AddAsync(tarefa);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var tarefa = await _context.Tarefas.FindAsync(id);
            if (tarefa is null) return;

            _context.Tarefas.Remove(tarefa);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Tarefa>> GetAllAsync()
        {
            return await _context.Tarefas.ToListAsync();
        }

        public async Task<Tarefa?> GetByIdAsync(int id)
        {
            var tarefa = await _context.Tarefas.FindAsync(id);
            return tarefa;
        }

        public async Task UpdateAsync(Tarefa tarefa)
        {
            _context.Tarefas.Update(tarefa);
            await _context.SaveChangesAsync();
        }
    }
}
