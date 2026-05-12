using NSubstitute;
using TaskManager.API.Application.UseCases;
using TaskManager.API.Application.UseCases.CriarTarefa;
using TaskManager.API.Domain.Entities;
using TaskManager.API.Domain.Interfaces;

namespace TaskManager.Tests.UseCases
{
    public class CriarTarefaUseCaseTests
    {
        private readonly ITarefaRepository _repository;
        private readonly CriarTarefaUseCase _useCase;

        public CriarTarefaUseCaseTests()
        {
            _repository = Substitute.For<ITarefaRepository>();
            _useCase = new CriarTarefaUseCase(_repository);
        }

        [Fact]
        public async Task ExecuteAsync_DeveCriarTarefa_QuandoDadosValidos()
        {
            // Arrange
            var request = new CriarTarefaRequest
            {
                Nome = "Estudar testes",
                Descricao = "Aprender xUnit e NSubstitute"
            };

            // Act
            var response = await _useCase.ExecuteAsync(request);

            // Assert
            Assert.Equal(request.Nome, response.Nome);
            Assert.False(response.Concluida);
            await _repository.Received(1).AddAsync(Arg.Any<Tarefa>());
        }
    }
}
