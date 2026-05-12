using TaskManager.API.Domain.Interfaces;

namespace TaskManager.API.Application.UseCases.DeletarTarefa
{
    public class DeletarTarefaUseCase
    {
        private readonly ITarefaRepository _tarefaRepository;

        public DeletarTarefaUseCase(ITarefaRepository tarefaRepository)
        {
            _tarefaRepository = tarefaRepository;
        }

        public async Task ExecuteAsync(int id)
        {
            var tarefa = await _tarefaRepository.GetByIdAsync(id);

            if(tarefa is null)
            {
                throw new KeyNotFoundException("Tarefa não encontrada!");
            }

            await _tarefaRepository.DeleteAsync(id);
        }
    }
}
