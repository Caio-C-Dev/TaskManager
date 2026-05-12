using TaskManager.API.Application.UseCases.CriarTarefa;
using TaskManager.API.Domain.Entities;
using TaskManager.API.Domain.Interfaces;

namespace TaskManager.API.Application.UseCases
{
    public class CriarTarefaUseCase
    {
        private readonly ITarefaRepository _repository;

        public CriarTarefaUseCase(ITarefaRepository repository)
        {
            _repository = repository;
        }

        public async Task<CriarTarefaResponse> ExecuteAsync(CriarTarefaRequest request)
        {
            var tarefa = new Tarefa(request.Nome, request.Descricao);

            await _repository.AddAsync(tarefa);

            return new CriarTarefaResponse
            {
                Id = tarefa.Id,
                Nome = tarefa.Nome,
                DataCriacao = tarefa.DataCriacao,
                Concluida = tarefa.Concluida,
            };
        }
    }
}