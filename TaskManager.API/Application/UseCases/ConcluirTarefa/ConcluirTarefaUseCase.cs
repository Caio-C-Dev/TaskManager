using TaskManager.API.Domain.Interfaces;

namespace TaskManager.API.Application.UseCases.ConcluirTarefa
{
    public class ConcluirTarefaUseCase
    {
        private readonly ITarefaRepository _tarefaRepository;
        
        public ConcluirTarefaUseCase(ITarefaRepository tarefaRepository)
        {
            _tarefaRepository = tarefaRepository;
        }

        public async Task ExecuteAsync(int id)
        {
            var tarefa = await _tarefaRepository.GetByIdAsync(id);

            if (tarefa is null)
            {
                throw new KeyNotFoundException("Tarefa não encontrada!");
            }

            tarefa.Concluir();

            await _tarefaRepository.UpdateAsync(tarefa);
        }
    }

}
