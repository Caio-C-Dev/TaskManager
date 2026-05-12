using TaskManager.API.Domain.Interfaces;

namespace TaskManager.API.Application.UseCases.EditarTarefas
{
    public class EditarTarefaUseCase

    {
        private readonly ITarefaRepository _tarefaRepository;

        public EditarTarefaUseCase(ITarefaRepository tarefaRepository)
        {
            _tarefaRepository = tarefaRepository;
        }

        public async Task ExecuteAsync(int id, EditarTarefaRequest request)
        {
            var tarefa = await _tarefaRepository.GetByIdAsync(id);

            if (tarefa is null)
            {
                throw new KeyNotFoundException("Tarefa não encontrada!");
            }

            tarefa.Editar(request.Nome, request.Descricao);
            await _tarefaRepository.UpdateAsync(tarefa);
        }
    }
}
