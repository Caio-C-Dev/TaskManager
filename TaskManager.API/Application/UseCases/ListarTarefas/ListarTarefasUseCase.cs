using TaskManager.API.Domain.Interfaces;

namespace TaskManager.API.Application.UseCases.ListarTarefas
{
    public class ListarTarefasUseCase
    {
        private readonly ITarefaRepository _tarefaRepository;

        public ListarTarefasUseCase(ITarefaRepository tarefaRepository)
        {
            _tarefaRepository = tarefaRepository;
        }

        public async Task<List<ListarTarefasResponse>> ExecuteAsync()
        {
            var tarefas = await _tarefaRepository.GetAllAsync();
            return tarefas.Select(t => new ListarTarefasResponse
            {
                Id = t.Id,
                Nome = t.Nome,
                DataCriacao = t.DataCriacao,
                Concluida = t.Concluida,
            }).ToList();

        }
    }
}
