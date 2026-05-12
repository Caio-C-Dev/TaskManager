using NSubstitute;
using TaskManager.API.Application.UseCases.ConcluirTarefa;
using TaskManager.API.Domain.Entities;
using TaskManager.API.Domain.Interfaces;

namespace TaskManager.Tests.UseCases
{
    public class ConcluirTarefaUseCaseTests
    {
        private readonly ITarefaRepository _repository;
        private readonly ConcluirTarefaUseCase _useCase;

        public ConcluirTarefaUseCaseTests()
        {
            _repository = Substitute.For<ITarefaRepository>();
            _useCase = new ConcluirTarefaUseCase(_repository);
        }

        [Fact]
        public async Task ExecuteAsync_DeveLancarExcecao_QuandoTarefaNaoEncontrada()
        {
            _repository.GetByIdAsync(Arg.Any<int>()).Returns((Tarefa?)null);

            await Assert.ThrowsAsync<KeyNotFoundException>(
                () => _useCase.ExecuteAsync(99)
            );
        }
    }
}
